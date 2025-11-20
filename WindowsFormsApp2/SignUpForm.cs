using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2;

public class SignUpForm : Form
{
	private string connectionString = "Server=" + Environment.MachineName + ";Database=ClientsAndOrders;Integrated Security=SSPI;";

	private IContainer components = null;

	private TextBox textBox1;

	private TextBox textBox2;

	private Label label1;

	private Label label2;

	private Button button1;

	private Label label4;

	private TextBox textBox3;

	private Label label3;

	private Label label5;

	private TextBox textBox4;

	private Label label6;

	private Label label7;

	private TextBox textBox5;

	private TextBox textBox6;

	public SignUpForm()
	{
		InitializeComponent();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		string username = textBox1.Text;
		string firstname = textBox2.Text;
		string secondname = textBox3.Text;
		string surname = textBox6.Text;
		string password = textBox5.Text;
		string hashedPassword = PasswordHasher.HashPassword(password);
		using (SqlConnection conn = new SqlConnection(connectionString))
		{
			string query1 = "INSERT INTO Clients (FirstName, SecondName, SurName) " +
				"VALUES (@Firstname, @Secondname, @Surname);DECLARE @MaxID INT; SELECT @MaxID = ISNULL(MAX(Id), 0) FROM Clients;" +
				" DBCC CHECKIDENT ('Clients', RESEED, @MaxID);";
			string query2 = "SELECT Clients.Id FROM Clients WHERE FirstName = @Firstname OR SecondName = @Secondname OR SurName = @Surname;";
			string query3 = "INSERT INTO Accounts (Login_, Password_, IdClient) VALUES (@Username, @PasswordHash, @Idclient);" +
				"DECLARE @MaxID INT; SELECT @MaxID = ISNULL(MAX(Id), 0) FROM Accounts; DBCC CHECKIDENT ('Accounts', RESEED, @MaxID);";
			SqlCommand cmd1 = new SqlCommand(query1, conn);
			cmd1.Parameters.AddWithValue("@Firstname", firstname);
			cmd1.Parameters.AddWithValue("@Secondname", secondname);
			cmd1.Parameters.AddWithValue("@Surname", surname);
			SqlCommand cmd2 = new SqlCommand(query2, conn);
			cmd2.Parameters.AddWithValue("@Firstname", firstname);
			cmd2.Parameters.AddWithValue("@Secondname", secondname);
			cmd2.Parameters.AddWithValue("@Surname", surname);
			conn.Open();
			cmd1.ExecuteNonQuery();
			int clientid = (int)cmd2.ExecuteScalar();
			SqlCommand cmd3 = new SqlCommand(query3, conn);
			cmd3.Parameters.AddWithValue("@Username", username);
			cmd3.Parameters.AddWithValue("@PasswordHash", hashedPassword);
			cmd3.Parameters.AddWithValue("@Idclient", clientid);
			cmd3.ExecuteNonQuery();
			conn.Close();
		}
		Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowsFormsApp2.SignUpForm));
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.button1 = new System.Windows.Forms.Button();
		this.label4 = new System.Windows.Forms.Label();
		this.textBox3 = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.textBox4 = new System.Windows.Forms.TextBox();
		this.label6 = new System.Windows.Forms.Label();
		this.label7 = new System.Windows.Forms.Label();
		this.textBox5 = new System.Windows.Forms.TextBox();
		this.textBox6 = new System.Windows.Forms.TextBox();
		base.SuspendLayout();
		this.textBox1.Location = new System.Drawing.Point(133, 37);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(211, 20);
		this.textBox1.TabIndex = 1;
		this.textBox2.Location = new System.Drawing.Point(133, 63);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(211, 20);
		this.textBox2.TabIndex = 2;
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(26, 40);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(38, 13);
		this.label1.TabIndex = 3;
		this.label1.Text = "Логин";
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(25, 92);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(56, 13);
		this.label2.TabIndex = 4;
		this.label2.Text = "Фамилия";
		this.button1.BackColor = System.Drawing.Color.Transparent;
		this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.button1.Location = new System.Drawing.Point(117, 199);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(128, 23);
		this.button1.TabIndex = 8;
		this.button1.Text = "Зарегистрироваться";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		this.label4.Location = new System.Drawing.Point(112, 9);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(149, 25);
		this.label4.TabIndex = 9;
		this.label4.Text = "Регистрация";
		this.textBox3.Location = new System.Drawing.Point(133, 92);
		this.textBox3.Name = "textBox3";
		this.textBox3.Size = new System.Drawing.Size(211, 20);
		this.textBox3.TabIndex = 10;
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(25, 66);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(29, 13);
		this.label3.TabIndex = 11;
		this.label3.Text = "Имя";
		this.label5.AutoSize = true;
		this.label5.Location = new System.Drawing.Point(25, 147);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(45, 13);
		this.label5.TabIndex = 17;
		this.label5.Text = "Пароль";
		this.textBox4.Location = new System.Drawing.Point(133, 173);
		this.textBox4.Name = "textBox4";
		this.textBox4.PasswordChar = '*';
		this.textBox4.Size = new System.Drawing.Size(211, 20);
		this.textBox4.TabIndex = 16;
		this.label6.AutoSize = true;
		this.label6.Location = new System.Drawing.Point(25, 173);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(102, 13);
		this.label6.TabIndex = 15;
		this.label6.Text = "Повторите Пароль";
		this.label7.AutoSize = true;
		this.label7.Location = new System.Drawing.Point(26, 121);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(54, 13);
		this.label7.TabIndex = 14;
		this.label7.Text = "Отчество";
		this.textBox5.Location = new System.Drawing.Point(133, 144);
		this.textBox5.Name = "textBox5";
		this.textBox5.PasswordChar = '*';
		this.textBox5.Size = new System.Drawing.Size(211, 20);
		this.textBox5.TabIndex = 13;
		this.textBox6.Location = new System.Drawing.Point(133, 118);
		this.textBox6.Name = "textBox6";
		this.textBox6.Size = new System.Drawing.Size(211, 20);
		this.textBox6.TabIndex = 12;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FloralWhite;
		base.ClientSize = new System.Drawing.Size(363, 232);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.textBox4);
		base.Controls.Add(this.label6);
		base.Controls.Add(this.label7);
		base.Controls.Add(this.textBox5);
		base.Controls.Add(this.textBox6);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.textBox3);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.textBox2);
		base.Controls.Add(this.textBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "SignUpForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Регистрация";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
