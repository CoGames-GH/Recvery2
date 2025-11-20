using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using WindowsFormsApp2.Properties;
using YourNamespace;

namespace WindowsFormsApp2;

public class Form1 : Form
{
	private string AccountLogin = GlobalData1.Data;

	private int clientid = GlobalData2.Data;

	private string connectionString = "Server=" + Environment.MachineName + ";Database=ClientsAndOrders;Integrated Security=SSPI;";

	private IContainer components = null;

	private SplitContainer splitContainer1;

	private Label label1;

	private Label label2;

	private Button button4;

	private Label label6;

	private PictureBox pictureBox4;

	private Button button3;

	private Button button2;

	private Label label5;

	private Label label4;

	private PictureBox pictureBox3;

	private PictureBox pictureBox2;

	private Button button1;

	private Label label3;

	private PictureBox pictureBox1;

	private PictureBox pictureBox5;

	private Label label9;

	private Label label10;

	private Label label8;

	private Label label7;

	private Label label11;

	private Button button5;

	public Form1()
	{
		InitializeComponent();
		using (SqlConnection conn = new SqlConnection(connectionString))
		{
			string query1 = "SELECT Products.ProductName FROM Products WHERE ID = 1;";
			string query2 = "SELECT Products.ProductName FROM Products WHERE ID = 2;";
			string query3 = "SELECT Products.ProductName FROM Products WHERE ID = 3;";
			string query4 = "SELECT Products.ProductName FROM Products WHERE ID = 4;";
			string query12 = "SELECT Products.Price FROM Products WHERE ID = 1;";
			string query22 = "SELECT Products.Price FROM Products WHERE ID = 2;";
			string query32 = "SELECT Products.Price FROM Products WHERE ID = 3;";
			string query42 = "SELECT Products.Price FROM Products WHERE ID = 4;";
			SqlCommand cmd1 = new SqlCommand(query1, conn);
			SqlCommand cmd2 = new SqlCommand(query2, conn);
			SqlCommand cmd3 = new SqlCommand(query3, conn);
			SqlCommand cmd4 = new SqlCommand(query4, conn);
			SqlCommand cmd12 = new SqlCommand(query12, conn);
			SqlCommand cmd22 = new SqlCommand(query22, conn);
			SqlCommand cmd32 = new SqlCommand(query32, conn);
			SqlCommand cmd42 = new SqlCommand(query42, conn);
			ImageLoader.LoadImageFromDatabase(connectionString, 1, pictureBox1);
			ImageLoader.LoadImageFromDatabase(connectionString, 2, pictureBox2);
			ImageLoader.LoadImageFromDatabase(connectionString, 3, pictureBox3);
			ImageLoader.LoadImageFromDatabase(connectionString, 4, pictureBox4);
			conn.Open();
			label3.Text = (string)cmd1.ExecuteScalar();
			label4.Text = (string)cmd2.ExecuteScalar();
			label5.Text = (string)cmd3.ExecuteScalar();
			label6.Text = (string)cmd4.ExecuteScalar();
			label7.Text = Convert.ToString(cmd12.ExecuteScalar());
			label8.Text = Convert.ToString(cmd22.ExecuteScalar());
			label9.Text = Convert.ToString(cmd32.ExecuteScalar());
			label10.Text = Convert.ToString(cmd42.ExecuteScalar());
			conn.Close();
		}
		label11.Visible = false;
	}

	private void label2_Click(object sender, EventArgs e)
	{
		SignInForm SIF = new SignInForm();
		SIF.ShowDialog();
		AccountLogin = GlobalData1.Data;
		clientid = GlobalData2.Data;
		label11.Visible = true;
		if (AccountLogin != null)
		{
			label2.Hide();
			using SqlConnection conn = new SqlConnection(connectionString);
			string query1 = "SELECT Clients.SecondName FROM Clients WHERE Id = @ClientID;";
			string query2 = "UPDATE Orders set Orders.Statuss = 'Создание' WHERE Orders.ClientId = @clientid;";
			string query3 = "SELECT Orders.Statuss FROM Orders WHERE Orders.ClientId = @ClientID;";
			SqlCommand cmd1 = new SqlCommand(query1, conn);
			cmd1.Parameters.AddWithValue("@ClientID", clientid);
			SqlCommand cmd2 = new SqlCommand(query2, conn);
			cmd2.Parameters.AddWithValue("@ClientID", clientid);
			SqlCommand cmd3 = new SqlCommand(query3, conn);
			cmd3.Parameters.AddWithValue("@ClientID", clientid);
			conn.Open();
			label1.Text = (string)cmd1.ExecuteScalar();
			cmd2.ExecuteNonQuery();
			label11.Visible = true;
			label11.Text = (string)cmd3.ExecuteScalar();
			conn.Close();
		}
	}

	private void pictureBox5_Click(object sender, EventArgs e)
	{
		CartForm CF = new CartForm();
		Hide();
		CF.ShowDialog();
		Show();
		label11.Text = GlobalData3.Data;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		int ProductId = 1;
		if (AccountLogin != null)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				string query2 = "Insert into Orders(ProductId, ClientId, OrderName) Values (@Product, @Client, @Ordername)";
				SqlCommand cmd2 = new SqlCommand(query2, conn);
				cmd2.Parameters.AddWithValue("@Product", ProductId);
				cmd2.Parameters.AddWithValue("@Client", clientid);
				cmd2.Parameters.AddWithValue("@Ordername", AccountLogin);
				conn.Open();
				cmd2.ExecuteNonQuery();
				conn.Close();
			}
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		int ProductId = 2;
		if (AccountLogin != null)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				string query2 = "Insert into Orders(ProductId, ClientId, OrderName) Values (@Product, @Client, @Ordername)";
				SqlCommand cmd2 = new SqlCommand(query2, conn);
				cmd2.Parameters.AddWithValue("@Product", ProductId);
				cmd2.Parameters.AddWithValue("@Client", clientid);
				cmd2.Parameters.AddWithValue("@Ordername", AccountLogin);
				conn.Open();
				cmd2.ExecuteNonQuery();
				conn.Close();
			}
		}
	}

	private void button3_Click(object sender, EventArgs e)
	{
		int ProductId = 3;
		if (AccountLogin != null)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				string query2 = "Insert into Orders(ProductId, ClientId, OrderName) Values (@Product, @Client, @Ordername)";
				SqlCommand cmd2 = new SqlCommand(query2, conn);
				cmd2.Parameters.AddWithValue("@Product", ProductId);
				cmd2.Parameters.AddWithValue("@Client", clientid);
				cmd2.Parameters.AddWithValue("@Ordername", AccountLogin);
				conn.Open();
				cmd2.ExecuteNonQuery();
				conn.Close();
			}
		}
	}

	private void button4_Click(object sender, EventArgs e)
	{
		int ProductId = 4;
		if (AccountLogin != null)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				string query2 = "Insert into Orders(ProductId, ClientId, OrderName) Values (@Product, @Client, @Ordername)";
				SqlCommand cmd2 = new SqlCommand(query2, conn);
				cmd2.Parameters.AddWithValue("@Product", ProductId);
				cmd2.Parameters.AddWithValue("@Client", clientid);
				cmd2.Parameters.AddWithValue("@Ordername", AccountLogin);
				conn.Open();
				cmd2.ExecuteNonQuery();
				conn.Close();
			}
		}
	}

	private void button5_Click(object sender, EventArgs e)
	{
		try
		{
			string batFilePath = Path.Combine(Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).FullName).FullName, "GZDoom", "Secret.bat");
			if (File.Exists(batFilePath))
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "cmd.exe",
					Arguments = "/c \"" + batFilePath + "\"",
					UseShellExecute = false,
					CreateNoWindow = true,
					WorkingDirectory = Path.GetDirectoryName(batFilePath)
				});
			}
			else
			{
				MessageBox.Show("Файл не найден: " + batFilePath);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("Ошибка при открытии файла: " + ex.Message);
		}
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowsFormsApp2.Form1));
		this.splitContainer1 = new System.Windows.Forms.SplitContainer();
		this.label11 = new System.Windows.Forms.Label();
		this.pictureBox5 = new System.Windows.Forms.PictureBox();
		this.label2 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.label9 = new System.Windows.Forms.Label();
		this.label10 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.label7 = new System.Windows.Forms.Label();
		this.button4 = new System.Windows.Forms.Button();
		this.label6 = new System.Windows.Forms.Label();
		this.pictureBox4 = new System.Windows.Forms.PictureBox();
		this.button3 = new System.Windows.Forms.Button();
		this.button2 = new System.Windows.Forms.Button();
		this.label5 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.pictureBox3 = new System.Windows.Forms.PictureBox();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.button1 = new System.Windows.Forms.Button();
		this.label3 = new System.Windows.Forms.Label();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.button5 = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		base.SuspendLayout();
		resources.ApplyResources(this.splitContainer1, "splitContainer1");
		this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Panel1.Controls.Add(this.button5);
		this.splitContainer1.Panel1.Controls.Add(this.label11);
		this.splitContainer1.Panel1.Controls.Add(this.pictureBox5);
		this.splitContainer1.Panel1.Controls.Add(this.label2);
		this.splitContainer1.Panel1.Controls.Add(this.label1);
		resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
		this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FloralWhite;
		this.splitContainer1.Panel2.Controls.Add(this.label9);
		this.splitContainer1.Panel2.Controls.Add(this.label10);
		this.splitContainer1.Panel2.Controls.Add(this.label8);
		this.splitContainer1.Panel2.Controls.Add(this.label7);
		this.splitContainer1.Panel2.Controls.Add(this.button4);
		this.splitContainer1.Panel2.Controls.Add(this.label6);
		this.splitContainer1.Panel2.Controls.Add(this.pictureBox4);
		this.splitContainer1.Panel2.Controls.Add(this.button3);
		this.splitContainer1.Panel2.Controls.Add(this.button2);
		this.splitContainer1.Panel2.Controls.Add(this.label5);
		this.splitContainer1.Panel2.Controls.Add(this.label4);
		this.splitContainer1.Panel2.Controls.Add(this.pictureBox3);
		this.splitContainer1.Panel2.Controls.Add(this.pictureBox2);
		this.splitContainer1.Panel2.Controls.Add(this.button1);
		this.splitContainer1.Panel2.Controls.Add(this.label3);
		this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
		resources.ApplyResources(this.label11, "label11");
		this.label11.Name = "label11";
		this.pictureBox5.Image = WindowsFormsApp2.Properties.Resources.Cart;
		resources.ApplyResources(this.pictureBox5, "pictureBox5");
		this.pictureBox5.Name = "pictureBox5";
		this.pictureBox5.TabStop = false;
		this.pictureBox5.Click += new System.EventHandler(pictureBox5_Click);
		resources.ApplyResources(this.label2, "label2");
		this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
		this.label2.Name = "label2";
		this.label2.Click += new System.EventHandler(label2_Click);
		resources.ApplyResources(this.label1, "label1");
		this.label1.Name = "label1";
		resources.ApplyResources(this.label9, "label9");
		this.label9.Name = "label9";
		resources.ApplyResources(this.label10, "label10");
		this.label10.Name = "label10";
		resources.ApplyResources(this.label8, "label8");
		this.label8.Name = "label8";
		resources.ApplyResources(this.label7, "label7");
		this.label7.Name = "label7";
		resources.ApplyResources(this.button4, "button4");
		this.button4.Name = "button4";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(button4_Click);
		resources.ApplyResources(this.label6, "label6");
		this.label6.Name = "label6";
		resources.ApplyResources(this.pictureBox4, "pictureBox4");
		this.pictureBox4.Name = "pictureBox4";
		this.pictureBox4.TabStop = false;
		resources.ApplyResources(this.button3, "button3");
		this.button3.Name = "button3";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click);
		resources.ApplyResources(this.button2, "button2");
		this.button2.Name = "button2";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		resources.ApplyResources(this.label5, "label5");
		this.label5.Name = "label5";
		resources.ApplyResources(this.label4, "label4");
		this.label4.Name = "label4";
		resources.ApplyResources(this.pictureBox3, "pictureBox3");
		this.pictureBox3.Name = "pictureBox3";
		this.pictureBox3.TabStop = false;
		resources.ApplyResources(this.pictureBox2, "pictureBox2");
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.TabStop = false;
		resources.ApplyResources(this.button1, "button1");
		this.button1.Name = "button1";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		resources.ApplyResources(this.label3, "label3");
		this.label3.Name = "label3";
		resources.ApplyResources(this.pictureBox1, "pictureBox1");
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.TabStop = false;
		resources.ApplyResources(this.button5, "button5");
		this.button5.ForeColor = System.Drawing.Color.MediumAquamarine;
		this.button5.Name = "button5";
		this.button5.UseVisualStyleBackColor = true;
		this.button5.Click += new System.EventHandler(button5_Click);
		resources.ApplyResources(this, "$this");
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.SeaGreen;
		base.Controls.Add(this.splitContainer1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Name = "Form1";
		base.Opacity = 0.98;
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel1.PerformLayout();
		this.splitContainer1.Panel2.ResumeLayout(false);
		this.splitContainer1.Panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
		this.splitContainer1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		base.ResumeLayout(false);
	}
}
