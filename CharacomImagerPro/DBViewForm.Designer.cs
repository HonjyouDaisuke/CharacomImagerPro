/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2013/11/12
 * 時刻: 12:18
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
namespace CharacomImagerPro
{
	partial class DBViewForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBViewForm));
			this.ImageBox = new System.Windows.Forms.PictureBox();
			this.cmbMojiFolder = new System.Windows.Forms.ComboBox();
			this.cmbHitoFolder = new System.Windows.Forms.ComboBox();
			this.cmbImgFile = new System.Windows.Forms.ComboBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnMojiLeft = new System.Windows.Forms.Button();
			this.btnMojiRight = new System.Windows.Forms.Button();
			this.btnHitoRight = new System.Windows.Forms.Button();
			this.btnHitoLeft = new System.Windows.Forms.Button();
			this.btnImgRight = new System.Windows.Forms.Button();
			this.btnImgLeft = new System.Windows.Forms.Button();
			this.btnStandard = new System.Windows.Forms.Button();
			this.btnStroke = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
			this.SuspendLayout();
			// 
			// ImageBox
			// 
			this.ImageBox.Location = new System.Drawing.Point(12, 12);
			this.ImageBox.Name = "ImageBox";
			this.ImageBox.Size = new System.Drawing.Size(320, 320);
			this.ImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ImageBox.TabIndex = 0;
			this.ImageBox.TabStop = false;
			this.ImageBox.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageBoxPaint);
			// 
			// cmbMojiFolder
			// 
			this.cmbMojiFolder.FormattingEnabled = true;
			this.cmbMojiFolder.Location = new System.Drawing.Point(41, 339);
			this.cmbMojiFolder.Name = "cmbMojiFolder";
			this.cmbMojiFolder.Size = new System.Drawing.Size(258, 20);
			this.cmbMojiFolder.TabIndex = 1;
			this.cmbMojiFolder.SelectedIndexChanged += new System.EventHandler(this.CmbMojiFolderSelectedIndexChanged);
			this.cmbMojiFolder.TextChanged += new System.EventHandler(this.CmbMojiFolderTextChanged);
			// 
			// cmbHitoFolder
			// 
			this.cmbHitoFolder.FormattingEnabled = true;
			this.cmbHitoFolder.Location = new System.Drawing.Point(41, 365);
			this.cmbHitoFolder.Name = "cmbHitoFolder";
			this.cmbHitoFolder.Size = new System.Drawing.Size(258, 20);
			this.cmbHitoFolder.TabIndex = 2;
			this.cmbHitoFolder.SelectedIndexChanged += new System.EventHandler(this.CmbHitoFolderSelectedIndexChanged);
			this.cmbHitoFolder.TextChanged += new System.EventHandler(this.CmbHitoFolderTextChanged);
			// 
			// cmbImgFile
			// 
			this.cmbImgFile.FormattingEnabled = true;
			this.cmbImgFile.Location = new System.Drawing.Point(41, 391);
			this.cmbImgFile.Name = "cmbImgFile";
			this.cmbImgFile.Size = new System.Drawing.Size(258, 20);
			this.cmbImgFile.TabIndex = 3;
			this.cmbImgFile.SelectedIndexChanged += new System.EventHandler(this.CmbImgFileSelectedIndexChanged);
			this.cmbImgFile.TextChanged += new System.EventHandler(this.CmbImgFileTextChanged);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(12, 418);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "取込む";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.BtnOKClick);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(257, 418);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "閉じる";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// btnMojiLeft
			// 
			this.btnMojiLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnMojiLeft.Image")));
			this.btnMojiLeft.Location = new System.Drawing.Point(12, 337);
			this.btnMojiLeft.Name = "btnMojiLeft";
			this.btnMojiLeft.Size = new System.Drawing.Size(23, 23);
			this.btnMojiLeft.TabIndex = 6;
			this.btnMojiLeft.UseVisualStyleBackColor = true;
			this.btnMojiLeft.Click += new System.EventHandler(this.BtnMojiLeftClick);
			// 
			// btnMojiRight
			// 
			this.btnMojiRight.Image = ((System.Drawing.Image)(resources.GetObject("btnMojiRight.Image")));
			this.btnMojiRight.Location = new System.Drawing.Point(305, 337);
			this.btnMojiRight.Name = "btnMojiRight";
			this.btnMojiRight.Size = new System.Drawing.Size(23, 23);
			this.btnMojiRight.TabIndex = 7;
			this.btnMojiRight.UseVisualStyleBackColor = true;
			this.btnMojiRight.Click += new System.EventHandler(this.BtnMojiRightClick);
			// 
			// btnHitoRight
			// 
			this.btnHitoRight.Image = ((System.Drawing.Image)(resources.GetObject("btnHitoRight.Image")));
			this.btnHitoRight.Location = new System.Drawing.Point(305, 363);
			this.btnHitoRight.Name = "btnHitoRight";
			this.btnHitoRight.Size = new System.Drawing.Size(23, 23);
			this.btnHitoRight.TabIndex = 9;
			this.btnHitoRight.UseVisualStyleBackColor = true;
			this.btnHitoRight.Click += new System.EventHandler(this.BtnHitoRightClick);
			// 
			// btnHitoLeft
			// 
			this.btnHitoLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnHitoLeft.Image")));
			this.btnHitoLeft.Location = new System.Drawing.Point(12, 363);
			this.btnHitoLeft.Name = "btnHitoLeft";
			this.btnHitoLeft.Size = new System.Drawing.Size(23, 23);
			this.btnHitoLeft.TabIndex = 8;
			this.btnHitoLeft.UseVisualStyleBackColor = true;
			this.btnHitoLeft.Click += new System.EventHandler(this.BtnHitoLeftClick);
			// 
			// btnImgRight
			// 
			this.btnImgRight.Image = ((System.Drawing.Image)(resources.GetObject("btnImgRight.Image")));
			this.btnImgRight.Location = new System.Drawing.Point(305, 389);
			this.btnImgRight.Name = "btnImgRight";
			this.btnImgRight.Size = new System.Drawing.Size(23, 23);
			this.btnImgRight.TabIndex = 11;
			this.btnImgRight.UseVisualStyleBackColor = true;
			this.btnImgRight.Click += new System.EventHandler(this.BtnImgRightClick);
			// 
			// btnImgLeft
			// 
			this.btnImgLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnImgLeft.Image")));
			this.btnImgLeft.Location = new System.Drawing.Point(12, 389);
			this.btnImgLeft.Name = "btnImgLeft";
			this.btnImgLeft.Size = new System.Drawing.Size(23, 23);
			this.btnImgLeft.TabIndex = 10;
			this.btnImgLeft.UseVisualStyleBackColor = true;
			this.btnImgLeft.Click += new System.EventHandler(this.BtnImgLeftClick);
			// 
			// btnStandard
			// 
			this.btnStandard.Location = new System.Drawing.Point(93, 418);
			this.btnStandard.Name = "btnStandard";
			this.btnStandard.Size = new System.Drawing.Size(75, 23);
			this.btnStandard.TabIndex = 12;
			this.btnStandard.Text = "標準書体";
			this.btnStandard.UseVisualStyleBackColor = true;
			this.btnStandard.Click += new System.EventHandler(this.BtnStandardClick);
			// 
			// btnStroke
			// 
			this.btnStroke.Location = new System.Drawing.Point(174, 418);
			this.btnStroke.Name = "btnStroke";
			this.btnStroke.Size = new System.Drawing.Size(77, 23);
			this.btnStroke.TabIndex = 13;
			this.btnStroke.Text = "筆順";
			this.btnStroke.UseVisualStyleBackColor = true;
			this.btnStroke.Click += new System.EventHandler(this.BtnStrokeClick);
			// 
			// DBViewForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(340, 446);
			this.Controls.Add(this.btnStroke);
			this.Controls.Add(this.btnStandard);
			this.Controls.Add(this.btnImgRight);
			this.Controls.Add(this.btnImgLeft);
			this.Controls.Add(this.btnHitoRight);
			this.Controls.Add(this.btnHitoLeft);
			this.Controls.Add(this.btnMojiRight);
			this.Controls.Add(this.btnMojiLeft);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.cmbImgFile);
			this.Controls.Add(this.cmbHitoFolder);
			this.Controls.Add(this.cmbMojiFolder);
			this.Controls.Add(this.ImageBox);
			this.Name = "DBViewForm";
			this.Text = "DB参照";
			this.TopMost = true;
			this.Shown += new System.EventHandler(this.DBViewFormShown);
			((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btnStroke;
		private System.Windows.Forms.Button btnStandard;
		private System.Windows.Forms.Button btnImgLeft;
		private System.Windows.Forms.Button btnImgRight;
		private System.Windows.Forms.Button btnHitoLeft;
		private System.Windows.Forms.Button btnHitoRight;
		private System.Windows.Forms.Button btnMojiRight;
		private System.Windows.Forms.Button btnMojiLeft;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.ComboBox cmbImgFile;
		private System.Windows.Forms.ComboBox cmbHitoFolder;
		private System.Windows.Forms.ComboBox cmbMojiFolder;
		private System.Windows.Forms.PictureBox ImageBox;
	}
}
