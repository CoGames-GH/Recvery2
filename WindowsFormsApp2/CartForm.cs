using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2;

public class CartForm : Form
{
	private string connectionString = "Server=" + Environment.MachineName + ";Database=ClientsAndOrders;Integrated Security=SSPI;";

	private string AccountLogin = GlobalData1.Data;

	private int clientid = GlobalData2.Data;

	private IContainer components = null;

	private SplitContainer splitContainer1;

	private Button button1;

	private Label label2;

	private DataGridView dataGridView1;

	private Label label3;

	private Label label1;

	public CartForm()
	{
		InitializeComponent();
		if (AccountLogin != null)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				string query2 = "SELECT Clients.SecondName FROM Clients WHERE Id = @ClientID;";
				string query3 = "Select SUM(Products.Price) from Orders " +
					"inner join Products on Products.ID = Orders.ProductId where Orders.ClientId = @ClientId;";
				SqlCommand cmd2 = new SqlCommand(query2, conn);
				cmd2.Parameters.AddWithValue("@ClientID", clientid);
				SqlCommand cmd3 = new SqlCommand(query3, conn);
				cmd3.Parameters.AddWithValue("@ClientID", clientid);
				conn.Open();
				string UserName = (string)cmd2.ExecuteScalar();
				label2.Text = UserName;
				SqlDataAdapter ada = new SqlDataAdapter($"select Products.ProductName, Products.Price from Products " +
					$"inner join Orders on Products.ID = Orders.ProductId" +
					$" inner join Clients on Clients.Id = Orders.ClientId where Clients.Id = {clientid}", connectionString);
				DataSet ds = new DataSet();
				ada.Fill(ds);
				dataGridView1.ReadOnly = true;
				dataGridView1.DataSource = ds.Tables[0];
				label3.Text = Convert.ToString(cmd3.ExecuteScalar()) + " Руб.";
				conn.Close();
			}
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		PurchaseForm PF = new PurchaseForm();
		PF.ShowDialog();
		if (AccountLogin != null)
		{
			using SqlConnection conn = new SqlConnection(connectionString);
			GlobalData3.Data = "Оплачено";
			string query1 = "DELETE Orders FROM Orders WHERE Orders.ClientId = @clientid;" +
				"DECLARE @MaxID INT; SELECT @MaxID = ISNULL(MAX(Id), 0) FROM Orders;" +
				" DBCC CHECKIDENT ('Orders', RESEED, @MaxID);";
			SqlCommand cmd1 = new SqlCommand(query1, conn);
			cmd1.Parameters.AddWithValue("@clientid", clientid);
			conn.Open();
			cmd1.ExecuteNonQuery();
			conn.Close();
		}
		Close();
	}

	private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
		{
			DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[0];
			object cellValue = cell.Value;
			string Product = cellValue.ToString();
			using SqlConnection conn = new SqlConnection(connectionString);
			string query1 = "DELETE Orders FROM Orders WHERE Orders.Id = (SELECT min(Orders.Id) FROM Orders inner join Products ON Products.ID = Orders.ProductId WHERE Products.ProductName = @Product and Orders.ClientId = @ClientID);DECLARE @MaxID INT; SELECT @MaxID = ISNULL(MAX(Id), 0) FROM Orders; DBCC CHECKIDENT ('Orders', RESEED, @MaxID);";
			SqlCommand cmd1 = new SqlCommand(query1, conn);
			cmd1.Parameters.AddWithValue("@Product", Product);
			cmd1.Parameters.AddWithValue("@ClientID", clientid);
			SqlDataAdapter ada = new SqlDataAdapter($"select Products.ProductName, Products.Price from Products inner join Orders on Products.ID = Orders.ProductId inner join Clients on Clients.Id = Orders.ClientId where Clients.Id = {clientid}", connectionString);
			DataSet ds = new DataSet();
			conn.Open();
			cmd1.ExecuteNonQuery();
			ada.Fill(ds);
			dataGridView1.ReadOnly = true;
			dataGridView1.DataSource = ds.Tables[0];
			conn.Close();
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
		this.splitContainer1 = new System.Windows.Forms.SplitContainer();
		this.label2 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.dataGridView1 = new System.Windows.Forms.DataGridView();
		this.button1 = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
		base.SuspendLayout();
		this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
		this.splitContainer1.Location = new System.Drawing.Point(0, 0);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
		this.splitContainer1.Panel1.Controls.Add(this.label2);
		this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FloralWhite;
		this.splitContainer1.Panel2.Controls.Add(this.label3);
		this.splitContainer1.Panel2.Controls.Add(this.label1);
		this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
		this.splitContainer1.Panel2.Controls.Add(this.button1);
		this.splitContainer1.Size = new System.Drawing.Size(800, 450);
		this.splitContainer1.SplitterDistance = 100;
		this.splitContainer1.TabIndex = 0;
		this.label2.AutoSize = true;
		this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.label2.Location = new System.Drawing.Point(752, 9);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(36, 13);
		this.label2.TabIndex = 2;
		this.label2.Text = "Гость";
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(674, 283);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(35, 13);
		this.label3.TabIndex = 4;
		this.label3.Text = "label3";
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(632, 283);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(40, 13);
		this.label1.TabIndex = 3;
		this.label1.Text = "Итого:";
		this.dataGridView1.BackgroundColor = System.Drawing.Color.FloralWhite;
		this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView1.GridColor = System.Drawing.Color.Black;
		this.dataGridView1.Location = new System.Drawing.Point(3, 3);
		this.dataGridView1.Name = "dataGridView1";
		this.dataGridView1.Size = new System.Drawing.Size(794, 273);
		this.dataGridView1.TabIndex = 2;
		this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellContentClick);
		this.button1.Location = new System.Drawing.Point(713, 311);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(75, 23);
		this.button1.TabIndex = 0;
		this.button1.Text = "Заказать";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.SeaGreen;
		base.ClientSize = new System.Drawing.Size(800, 450);
		base.Controls.Add(this.splitContainer1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Name = "CartForm";
		base.Opacity = 0.98;
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel1.PerformLayout();
		this.splitContainer1.Panel2.ResumeLayout(false);
		this.splitContainer1.Panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
		this.splitContainer1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
		base.ResumeLayout(false);
	}
}
