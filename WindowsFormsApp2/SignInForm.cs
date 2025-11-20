using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2;

public class SignInForm : Form
{
	private string connectionString = "Server=" + Environment.MachineName + ";Database=ClientsAndOrders;Integrated Security=SSPI;";

	private IContainer components = null;

	private ProgressBar progressBar1;

	private Timer timer1;

	private TextBox textBox1;

	private TextBox textBox2;

	private Label label1;

	private Label label2;

	private Label label3;

	private Button button1;

	private Label label4;

	private Timer timer2;

	private Timer timer3;

	private Timer timer4;

	private Timer timer5;

	private Timer timer6;

	private Timer timer7;

	private Timer timer8;

	private Timer timer9;

	public SignInForm()
	{
		InitializeComponent();
		progressBar1.Width = 0;
		base.Load += SignInForm1;
	}

	private void SignInForm1(object sender, EventArgs e)
	{
		int interval2 = 99;
		int currentStep1 = 0;
		timer4.Interval = interval2;
		timer4.Tick += delegate
		{
			currentStep1++;
			if (currentStep1 >= 20)
			{
				timer4.Stop();
				AnimateFadeIn(progressBar1);
				timer4.Stop();
				timer4.Dispose();
			}
		};
		timer4.Start();
	}

	private void AnimateFadeIn(ProgressBar control)
	{
		int interval = 10;
		int opacityIncrement = 1;
		int interval2 = 5;
		timer1.Interval = interval;
		timer2.Interval = interval2;
		timer3.Interval = interval2;
		int currentStep = 0;
		if (currentStep <= 120)
		{
			timer2.Tick += delegate
			{
				currentStep++;
				control.Width += opacityIncrement;
				if (currentStep >= 60)
				{
					timer2.Stop();
					timer2.Dispose();
					timer1.Start();
				}
			};
		}
		timer1.Tick += delegate
		{
			currentStep++;
			control.Width += opacityIncrement;
			if (currentStep >= 260)
			{
				timer1.Stop();
				timer1.Dispose();
				timer3.Start();
			}
		};
		timer3.Tick += delegate
		{
			currentStep++;
			control.Width += opacityIncrement;
			if (currentStep >= 320)
			{
				control.Width = 320;
				timer3.Stop();
				timer3.Dispose();
			}
		};
		timer2.Start();
	}

	private void AnimateFilling(ProgressBar control)
	{
		int interval = 50;
		int opacityIncrement = 0;
		int interval2 = 25;
		timer6.Interval = interval;
		timer5.Interval = interval2;
		timer7.Interval = interval2;
		int currentStep = 0;
		if (currentStep <= 20)
		{
			timer5.Tick += delegate
			{
				currentStep++;
				progressBar1.Value += opacityIncrement;
				if (currentStep >= 20)
				{
					timer5.Stop();
					timer5.Dispose();
					timer6.Start();
				}
			};
		}
		timer6.Tick += delegate
		{
			currentStep++;
			progressBar1.Value += opacityIncrement;
			if (currentStep >= 80)
			{
				timer6.Stop();
				timer6.Dispose();
				timer7.Start();
			}
		};
		timer7.Tick += delegate
		{
			currentStep++;
			progressBar1.Value += opacityIncrement;
			if (currentStep >= 100)
			{
				control.Value = 100;
				timer7.Stop();
				timer7.Dispose();
			}
		};
		timer5.Start();
	}

	private void label3_Click(object sender, EventArgs e)
	{
		SignUpForm SUF = new SignUpForm();
		SUF.Show();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		AnimateFilling(progressBar1);
		string password = textBox2.Text;
		string login = textBox1.Text;
		using SqlConnection conn = new SqlConnection(connectionString);
		string query1 = "Select Accounts.Password_ from Accounts where Login_ = @Login;";
		string query2 = "SELECT Accounts.IdClient FROM Accounts WHERE Login_ = @login;";
		SqlCommand cmd1 = new SqlCommand(query1, conn);
		SqlCommand cmd2 = new SqlCommand(query2, conn);
		cmd1.Parameters.AddWithValue("@Login", login);
		cmd2.Parameters.AddWithValue("@Login", login);
		conn.Open();
		string PasswordHash = (string)cmd1.ExecuteScalar();
		if (PasswordHasher.VerifyPassword(password, PasswordHash))
		{
			timer9.Tick += delegate
			{
				if (progressBar1.Value == 100)
				{
					LoginForm loginForm = new LoginForm();
					timer9.Stop();
					timer9.Dispose();
					loginForm.ShowDialog();
					Close();
				}
			};
			GlobalData1.Data = login;
			GlobalData2.Data = (int)cmd2.ExecuteScalar();
			timer9.Start();
			return;
		}
		timer8.Tick += delegate
		{
			if (progressBar1.Value == 100)
			{
				LoginFormFalse loginFormFalse = new LoginFormFalse();
				timer8.Stop();
				timer8.Dispose();
				loginFormFalse.ShowDialog();
				progressBar1.Value = 0;
			}
		};
		timer8.Start();
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
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowsFormsApp2.SignInForm));
		this.progressBar1 = new System.Windows.Forms.ProgressBar();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.button1 = new System.Windows.Forms.Button();
		this.label4 = new System.Windows.Forms.Label();
		this.timer2 = new System.Windows.Forms.Timer(this.components);
		this.timer3 = new System.Windows.Forms.Timer(this.components);
		this.timer4 = new System.Windows.Forms.Timer(this.components);
		this.timer5 = new System.Windows.Forms.Timer(this.components);
		this.timer6 = new System.Windows.Forms.Timer(this.components);
		this.timer7 = new System.Windows.Forms.Timer(this.components);
		this.timer8 = new System.Windows.Forms.Timer(this.components);
		this.timer9 = new System.Windows.Forms.Timer(this.components);
		base.SuspendLayout();
		this.progressBar1.ForeColor = System.Drawing.Color.Red;
		this.progressBar1.Location = new System.Drawing.Point(-1, 116);
		this.progressBar1.Name = "progressBar1";
		this.progressBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.progressBar1.Size = new System.Drawing.Size(320, 28);
		this.progressBar1.TabIndex = 0;
		this.textBox1.Location = new System.Drawing.Point(76, 37);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(211, 20);
		this.textBox1.TabIndex = 1;
		this.textBox2.Location = new System.Drawing.Point(76, 63);
		this.textBox2.Name = "textBox2";
		this.textBox2.PasswordChar = '*';
		this.textBox2.Size = new System.Drawing.Size(211, 20);
		this.textBox2.TabIndex = 2;
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(26, 40);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(38, 13);
		this.label1.TabIndex = 3;
		this.label1.Text = "Логин";
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(26, 66);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(45, 13);
		this.label2.TabIndex = 4;
		this.label2.Text = "Пароль";
		this.label3.AutoSize = true;
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 204);
		this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
		this.label3.Location = new System.Drawing.Point(26, 92);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(72, 13);
		this.label3.TabIndex = 7;
		this.label3.Text = "Регистрация";
		this.label3.Click += new System.EventHandler(label3_Click);
		this.button1.BackColor = System.Drawing.Color.Transparent;
		this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.button1.Location = new System.Drawing.Point(212, 87);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(75, 23);
		this.button1.TabIndex = 8;
		this.button1.Text = "Вход";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		this.label4.Location = new System.Drawing.Point(125, 9);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(65, 25);
		this.label4.TabIndex = 9;
		this.label4.Text = "Вход";
		this.timer4.Interval = 10;
		this.timer5.Interval = 10;
		this.timer6.Interval = 10;
		this.timer7.Interval = 10;
		this.timer8.Interval = 10;
		this.timer9.Interval = 10;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FloralWhite;
		base.ClientSize = new System.Drawing.Size(317, 140);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.textBox2);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.progressBar1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "SignInForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Вход";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
