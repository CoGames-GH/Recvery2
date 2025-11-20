using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace YourNamespace;

public static class ImageLoader
{
	public static void LoadImageFromDatabase(string connectionString, object idValue, PictureBox pictureBox, 
		PictureBoxSizeMode sizeMode = PictureBoxSizeMode.StretchImage)
	{
		if (string.IsNullOrEmpty(connectionString))
		{
			throw new ArgumentException("Строка подключения не может быть пустой.");
		}
		if (pictureBox == null)
		{
			throw new ArgumentNullException("pictureBox");
		}
		try
		{
			using SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();
			string query = "SELECT Products.ImageUrl FROM Products WHERE Products.ID = @Id";
			using (SqlCommand command = new SqlCommand(query, connection))
			{
				command.Parameters.AddWithValue("@Id", idValue);
				object result = command.ExecuteScalar();
				if (result != null && !string.IsNullOrEmpty(result.ToString()))
				{
					string imageUrl = result.ToString();
					using WebClient webClient = new WebClient();
					webClient.DownloadDataCompleted += delegate(object sender, DownloadDataCompletedEventArgs e)
					{
						if (e.Error == null && e.Result != null)
						{
							MemoryStream stream = new MemoryStream(e.Result);
							pictureBox.Image = Image.FromStream(stream);
							pictureBox.SizeMode = sizeMode;
						}
						else
						{
							MessageBox.Show("Ошибка загрузки изображения: " + e.Error?.Message,
								"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					};
					webClient.DownloadDataAsync(new Uri(imageUrl));
				}
				else
				{
					MessageBox.Show("Изображение не найдено в базе данных.", "Информация",
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					pictureBox.Image = null;
				}
			}
			connection.Close();
		}
		catch (Exception ex)
		{
			MessageBox.Show("Ошибка при работе с базой данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}
}
