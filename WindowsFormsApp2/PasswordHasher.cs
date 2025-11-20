using System;
using System.Security.Cryptography;

namespace WindowsFormsApp2;

public class PasswordHasher
{
	private const int SaltSize = 16;

	private const int KeySize = 32;

	private const int Iterations = 100000;

	public static string HashPassword(string password)
	{
		using RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
		byte[] salt = new byte[16];
		rng.GetBytes(salt);
		using Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
		byte[] hash = pbkdf2.GetBytes(32);
		byte[] hashBytes = new byte[48];
		Array.Copy(salt, 0, hashBytes, 0, 16);
		Array.Copy(hash, 0, hashBytes, 16, 32);
		return $"{100000}.{Convert.ToBase64String(hashBytes)}";
	}

	public static bool VerifyPassword(string password, string hashedPassword)
	{
		string[] parts = hashedPassword.Split('.');
		if (parts.Length != 2)
		{
			return false;
		}
		int iterations = Convert.ToInt32(parts[0]);
		byte[] hashBytes = Convert.FromBase64String(parts[1]);
		if (hashBytes.Length != 48)
		{
			return false;
		}
		byte[] salt = new byte[16];
		Array.Copy(hashBytes, 0, salt, 0, 16);
		using Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
		byte[] computedHash = pbkdf2.GetBytes(32);
		for (int i = 0; i < 32; i++)
		{
			if (computedHash[i] != hashBytes[16 + i])
			{
				return false;
			}
		}
		return true;
	}
}
