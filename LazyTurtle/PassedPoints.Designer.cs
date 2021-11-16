namespace LazyTurtle
{
	partial class PassedPoints
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
			this.pointsTXT = new System.Windows.Forms.TextBox();
			this.okBTN = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cntLBL = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// pointsTXT
			// 
			this.pointsTXT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pointsTXT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pointsTXT.Location = new System.Drawing.Point(12, 42);
			this.pointsTXT.Multiline = true;
			this.pointsTXT.Name = "pointsTXT";
			this.pointsTXT.ReadOnly = true;
			this.pointsTXT.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.pointsTXT.Size = new System.Drawing.Size(550, 271);
			this.pointsTXT.TabIndex = 0;
			// 
			// okBTN
			// 
			this.okBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBTN.Location = new System.Drawing.Point(487, 322);
			this.okBTN.Name = "okBTN";
			this.okBTN.Size = new System.Drawing.Size(75, 44);
			this.okBTN.TabIndex = 1;
			this.okBTN.Text = "OK";
			this.okBTN.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.LimeGreen;
			this.label1.Location = new System.Drawing.Point(243, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(319, 33);
			this.label1.TabIndex = 2;
			this.label1.Text = "Overlapped Points";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Calibri", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.LimeGreen;
			this.label2.Location = new System.Drawing.Point(12, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(242, 33);
			this.label2.TabIndex = 3;
			this.label2.Text = "LazyTurtle";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.DimGray;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 337);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(74, 29);
			this.label3.TabIndex = 4;
			this.label3.Text = "Total:";
			// 
			// cntLBL
			// 
			this.cntLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cntLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cntLBL.ForeColor = System.Drawing.Color.Silver;
			this.cntLBL.Location = new System.Drawing.Point(102, 337);
			this.cntLBL.Name = "cntLBL";
			this.cntLBL.Size = new System.Drawing.Size(152, 23);
			this.cntLBL.TabIndex = 5;
			this.cntLBL.Text = "2,000";
			// 
			// PassedPoints
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(574, 378);
			this.Controls.Add(this.cntLBL);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.okBTN);
			this.Controls.Add(this.pointsTXT);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "PassedPoints";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PassedPoints";
			this.Load += new System.EventHandler(this.PassedPoints_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox pointsTXT;
		private System.Windows.Forms.Button okBTN;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label cntLBL;
	}
}