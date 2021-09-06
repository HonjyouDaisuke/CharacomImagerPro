/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2013/11/27
 * 時刻: 20:59
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
namespace CharacomImagerPro
{
	partial class DBSaveForm
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
			this.ImageBox = new System.Windows.Forms.PictureBox();
			this.cmbImgFile = new System.Windows.Forms.ComboBox();
			this.cmbHitoFolder = new System.Windows.Forms.ComboBox();
			this.cmbMojiFolder = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
			this.SuspendLayout();
			// 
			// ImageBox
			// 
			this.ImageBox.Location = new System.Drawing.Point(12, 12);
			this.ImageBox.Name = "ImageBox";
			this.ImageBox.Size = new System.Drawing.Size(160, 160);
			this.ImageBox.TabIndex = 0;
			this.ImageBox.TabStop = false;
			this.ImageBox.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageBoxPaint);
			// 
			// cmbImgFile
			// 
			this.cmbImgFile.FormattingEnabled = true;
			this.cmbImgFile.Location = new System.Drawing.Point(61, 230);
			this.cmbImgFile.Name = "cmbImgFile";
			this.cmbImgFile.Size = new System.Drawing.Size(111, 20);
			this.cmbImgFile.TabIndex = 6;
			this.cmbImgFile.SelectedIndexChanged += new System.EventHandler(this.CmbImgFileSelectedIndexChanged);
			this.cmbImgFile.TextUpdate += new System.EventHandler(this.CmbImgFileTextUpdate);
			// 
			// cmbHitoFolder
			// 
			this.cmbHitoFolder.FormattingEnabled = true;
			this.cmbHitoFolder.Location = new System.Drawing.Point(61, 204);
			this.cmbHitoFolder.Name = "cmbHitoFolder";
			this.cmbHitoFolder.Size = new System.Drawing.Size(111, 20);
			this.cmbHitoFolder.TabIndex = 5;
			this.cmbHitoFolder.SelectedIndexChanged += new System.EventHandler(this.CmbHitoFolderSelectedIndexChanged);
			this.cmbHitoFolder.TextUpdate += new System.EventHandler(this.CmbHitoFolderTextUpdate);
			// 
			// cmbMojiFolder
			// 
			this.cmbMojiFolder.FormattingEnabled = true;
			this.cmbMojiFolder.Location = new System.Drawing.Point(61, 178);
			this.cmbMojiFolder.Name = "cmbMojiFolder";
			this.cmbMojiFolder.Size = new System.Drawing.Size(111, 20);
			this.cmbMojiFolder.TabIndex = 4;
			this.cmbMojiFolder.SelectedIndexChanged += new System.EventHandler(this.CmbMojiFolderSelectedIndexChanged);
			this.cmbMojiFolder.TextUpdate += new System.EventHandler(this.CmbMojiFolderTextUpdate);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 176);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 23);
			this.label1.TabIndex = 7;
			this.label1.Text = "文字種";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 202);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 23);
			this.label2.TabIndex = 8;
			this.label2.Text = "対象者";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 228);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 23);
			this.label3.TabIndex = 9;
			this.label3.Text = "回数";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(12, 254);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(69, 23);
			this.btnOK.TabIndex = 10;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.BtnOKClick);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(101, 254);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(71, 23);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "キャンセル";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// DBSaveForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(183, 284);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbImgFile);
			this.Controls.Add(this.cmbHitoFolder);
			this.Controls.Add(this.cmbMojiFolder);
			this.Controls.Add(this.ImageBox);
			this.Name = "DBSaveForm";
			this.Text = "DB保存";
			((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbMojiFolder;
		private System.Windows.Forms.ComboBox cmbHitoFolder;
		private System.Windows.Forms.ComboBox cmbImgFile;
		private System.Windows.Forms.PictureBox ImageBox;
	}
}
