using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2;

public class LoginForm : Form
{
	private IContainer components = null;

	private Button button1;

	private Label label4;

	public LoginForm()
	{
		InitializeComponent();
	}

	private void button1_Click(object sender, EventArgs e)
	{
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowsFormsApp2.LoginForm));
		this.button1 = new System.Windows.Forms.Button();
		this.label4 = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.button1.BackColor = System.Drawing.Color.Transparent;
		this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.button1.Location = new System.Drawing.Point(105, 37);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(34, 23);
		this.button1.TabIndex = 8;
		this.button1.Text = "Ок";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		this.label4.Location = new System.Drawing.Point(12, 9);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(227, 25);
		this.label4.TabIndex = 9;
		this.label4.Text = "Вы успешно зашли.";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FloralWhite;
		base.ClientSize = new System.Drawing.Size(249, 69);
		base.ControlBox = false;
		base.Controls.Add(this.label4);
		base.Controls.Add(this.button1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "LoginForm";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "SignUpForm";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
