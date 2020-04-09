namespace WindowsFormsMessage
{
	partial class Form2
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.stringText = new System.Windows.Forms.TextBox();
			this.intText = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// stringText
			// 
			this.stringText.Location = new System.Drawing.Point(251, 116);
			this.stringText.Margin = new System.Windows.Forms.Padding(4);
			this.stringText.Name = "stringText";
			this.stringText.Size = new System.Drawing.Size(330, 28);
			this.stringText.TabIndex = 24;
			// 
			// intText
			// 
			this.intText.Location = new System.Drawing.Point(36, 116);
			this.intText.Margin = new System.Windows.Forms.Padding(4);
			this.intText.Name = "intText";
			this.intText.Size = new System.Drawing.Size(148, 28);
			this.intText.TabIndex = 23;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(32, 52);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(322, 24);
			this.label1.TabIndex = 22;
			this.label1.Text = "receive message from Form1";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(36, 174);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(802, 302);
			this.textBox1.TabIndex = 21;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(678, 42);
			this.button1.Margin = new System.Windows.Forms.Padding(4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(162, 52);
			this.button1.TabIndex = 20;
			this.button1.Text = "SendMessage";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(873, 518);
			this.Controls.Add(this.stringText);
			this.Controls.Add(this.intText);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button1);
			this.Name = "Form2";
			this.Text = "Form2";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox stringText;
		private System.Windows.Forms.TextBox intText;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
	}
}