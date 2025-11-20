using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2;

public class PurchaseForm : Form
{
	private IContainer components = null;

	private Button button1;

	private Label label4;

	private Label label1;

	private Label label2;

	public PurchaseForm()
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowsFormsApp2.PurchaseForm));
		this.button1 = new System.Windows.Forms.Button();
		this.label4 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.button1.BackColor = System.Drawing.Color.Transparent;
		this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.button1.Location = new System.Drawing.Point(64, 50);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(34, 23);
		this.button1.TabIndex = 8;
		this.button1.Text = "Ок";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		this.label4.Location = new System.Drawing.Point(19, 9);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(126, 25);
		this.label4.TabIndex = 9;
		this.label4.Text = "Оплачено.";
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		this.label1.Location = new System.Drawing.Point(11, 34);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(76, 13);
		this.label1.TabIndex = 10;
		this.label1.Text = "Доствака в";
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		this.label2.Location = new System.Drawing.Point(83, 34);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(62, 13);
		this.label2.TabIndex = 11;
		this.label2.Text = "КАИТ 20.";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FloralWhite;
		base.ClientSize = new System.Drawing.Size(157, 81);
		base.ControlBox = false;
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.button1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "PurchaseForm";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "SignUpForm";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
