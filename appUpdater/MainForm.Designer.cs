/*
 * SharpDevelopによって生成
 * ユーザ: 大介
 * 日付: 2020/01/23
 * 時刻: 22:29
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
namespace appUpdater
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.appIcon = new System.Windows.Forms.PictureBox();
			this.lblMessage = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.appIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// appIcon
			// 
			this.appIcon.Image = ((System.Drawing.Image)(resources.GetObject("appIcon.Image")));
			this.appIcon.Location = new System.Drawing.Point(9, 17);
			this.appIcon.Margin = new System.Windows.Forms.Padding(2);
			this.appIcon.Name = "appIcon";
			this.appIcon.Size = new System.Drawing.Size(34, 37);
			this.appIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.appIcon.TabIndex = 0;
			this.appIcon.TabStop = false;
			// 
			// lblMessage
			// 
			this.lblMessage.Font = new System.Drawing.Font("MS UI Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblMessage.Location = new System.Drawing.Point(48, 26);
			this.lblMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(263, 18);
			this.lblMessage.TabIndex = 1;
			this.lblMessage.Text = "アプリケーションの更新確認中・・・";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(320, 69);
			this.Controls.Add(this.lblMessage);
			this.Controls.Add(this.appIcon);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "アプリケーション更新プログラム";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.Shown += new System.EventHandler(this.MainFormShown);
			((System.ComponentModel.ISupportInitialize)(this.appIcon)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lblMessage;
		private System.Windows.Forms.PictureBox appIcon;
		
		
	}
}
