/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2011/12/22
 * 時刻: 14:49
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
namespace CharacomImagerPro
{
	partial class VersionInfoForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VersionInfoForm));
			this.lblTitle = new System.Windows.Forms.Label();
			this.lblVersion = new System.Windows.Forms.Label();
			this.lblBuild = new System.Windows.Forms.Label();
			this.lblDescription = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblCopyright = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.imgIcon = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.imgIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTitle
			// 
			this.lblTitle.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblTitle.Location = new System.Drawing.Point(105, 9);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(205, 23);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Title";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblVersion
			// 
			this.lblVersion.Location = new System.Drawing.Point(197, 74);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(140, 23);
			this.lblVersion.TabIndex = 1;
			this.lblVersion.Text = "Ver.Build.Revision";
			this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblBuild
			// 
			this.lblBuild.Location = new System.Drawing.Point(197, 92);
			this.lblBuild.Name = "lblBuild";
			this.lblBuild.Size = new System.Drawing.Size(140, 23);
			this.lblBuild.TabIndex = 2;
			this.lblBuild.Text = "BuildDate";
			this.lblBuild.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblDescription
			// 
			this.lblDescription.Location = new System.Drawing.Point(67, 32);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(278, 42);
			this.lblDescription.TabIndex = 3;
			this.lblDescription.Text = "Description";
			this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(91, 74);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "バージョン情報：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(91, 92);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "ビルド日付：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblCopyright
			// 
			this.lblCopyright.Location = new System.Drawing.Point(12, 115);
			this.lblCopyright.Name = "lblCopyright";
			this.lblCopyright.Size = new System.Drawing.Size(252, 23);
			this.lblCopyright.TabIndex = 6;
			this.lblCopyright.Text = "copyright";
			this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(270, 115);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 7;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// imgIcon
			// 
			this.imgIcon.Image = ((System.Drawing.Image)(resources.GetObject("imgIcon.Image")));
			this.imgIcon.Location = new System.Drawing.Point(12, 9);
			this.imgIcon.Name = "imgIcon";
			this.imgIcon.Size = new System.Drawing.Size(73, 75);
			this.imgIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imgIcon.TabIndex = 8;
			this.imgIcon.TabStop = false;
			// 
			// VersionInfoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(349, 143);
			this.Controls.Add(this.imgIcon);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.lblCopyright);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblDescription);
			this.Controls.Add(this.lblBuild);
			this.Controls.Add(this.lblVersion);
			this.Controls.Add(this.lblTitle);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "VersionInfoForm";
			this.Text = "VersionInfoForm";
			this.Load += new System.EventHandler(this.VersionInfoFormLoad);
			((System.ComponentModel.ISupportInitialize)(this.imgIcon)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.PictureBox imgIcon;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label lblCopyright;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.Label lblBuild;
		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.Label lblTitle;
	}
}
