/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2012/04/20
 * 時刻: 10:15
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
namespace CharacomImagerPro
{
	partial class RangeCompareGraph
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.GraphImage = new System.Windows.Forms.PictureBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.GraphImage)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.AutoSize = true;
			this.panel1.Controls.Add(this.GraphImage);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(570, 360);
			this.panel1.TabIndex = 0;
			this.panel1.Resize += new System.EventHandler(this.Panel1Resize);
			// 
			// GraphImage
			// 
			this.GraphImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.GraphImage.Location = new System.Drawing.Point(0, 0);
			this.GraphImage.Name = "GraphImage";
			this.GraphImage.Size = new System.Drawing.Size(570, 360);
			this.GraphImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.GraphImage.TabIndex = 0;
			this.GraphImage.TabStop = false;
			this.GraphImage.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphImagePaint);
			// 
			// RangeCompareGraph
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(570, 360);
			this.Controls.Add(this.panel1);
			this.Name = "RangeCompareGraph";
			this.Text = "変動比較グラフ　プレビュー";
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.GraphImage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.PictureBox GraphImage;
		private System.Windows.Forms.Panel panel1;
	}
}
