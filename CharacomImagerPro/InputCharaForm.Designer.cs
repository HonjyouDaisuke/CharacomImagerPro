/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2013/11/24
 * 時刻: 18:49
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
namespace CharacomImagerPro
{
	partial class InputCharaForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputCharaForm));
			this.panel1 = new System.Windows.Forms.Panel();
			this.ImageBox = new System.Windows.Forms.PictureBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnNew = new System.Windows.Forms.ToolStripButton();
			this.btnOpen = new System.Windows.Forms.ToolStripButton();
			this.btnSaveImage = new System.Windows.Forms.ToolStripButton();
			this.btnSaveDB = new System.Windows.Forms.ToolStripButton();
			this.btnPen = new System.Windows.Forms.ToolStripButton();
			this.btnEraser = new System.Windows.Forms.ToolStripButton();
			this.comboColor = new System.Windows.Forms.ToolStripComboBox();
			this.cmbLineSize = new System.Windows.Forms.ToolStripComboBox();
			this.btnString = new System.Windows.Forms.ToolStripButton();
			this.saveFileDlg = new System.Windows.Forms.SaveFileDialog();
			this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblPressure = new System.Windows.Forms.Label();
			this.lblPosition = new System.Windows.Forms.Label();
			this.lblDeviceName = new System.Windows.Forms.Label();
			this.lblWinTabID = new System.Windows.Forms.Label();
			this.prgPressuer = new System.Windows.Forms.ProgressBar();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.BtnCopyWindow = new System.Windows.Forms.ToolStripButton();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.ImageBox);
			this.panel1.Location = new System.Drawing.Point(16, 36);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(427, 400);
			this.panel1.TabIndex = 0;
			// 
			// ImageBox
			// 
			this.ImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ImageBox.Location = new System.Drawing.Point(0, 0);
			this.ImageBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.ImageBox.Name = "ImageBox";
			this.ImageBox.Size = new System.Drawing.Size(427, 400);
			this.ImageBox.TabIndex = 0;
			this.ImageBox.TabStop = false;
			this.ImageBox.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageBoxPaint);
			this.ImageBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageBoxMouseDown);
			this.ImageBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageBoxMouseMove);
			this.ImageBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImageBoxMouseUp);
			// 
			// toolStrip1
			// 
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.btnNew,
			this.btnOpen,
			this.btnSaveImage,
			this.BtnCopyWindow,
			this.btnSaveDB,
			this.btnPen,
			this.btnEraser,
			this.comboColor,
			this.cmbLineSize,
			this.btnString});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(445, 28);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnNew
			// 
			this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
			this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(24, 25);
			this.btnNew.Text = "白紙";
			this.btnNew.Click += new System.EventHandler(this.BtnNewClick);
			// 
			// btnOpen
			// 
			this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
			this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(24, 25);
			this.btnOpen.Text = "開く";
			this.btnOpen.Click += new System.EventHandler(this.BtnOpenClick);
			// 
			// btnSaveImage
			// 
			this.btnSaveImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnSaveImage.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveImage.Image")));
			this.btnSaveImage.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSaveImage.Name = "btnSaveImage";
			this.btnSaveImage.Size = new System.Drawing.Size(24, 25);
			this.btnSaveImage.Text = "画像として保存";
			this.btnSaveImage.Click += new System.EventHandler(this.BtnSaveImageClick);
			// 
			// btnSaveDB
			// 
			this.btnSaveDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnSaveDB.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveDB.Image")));
			this.btnSaveDB.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSaveDB.Name = "btnSaveDB";
			this.btnSaveDB.Size = new System.Drawing.Size(24, 25);
			this.btnSaveDB.Text = "DBへ保存";
			this.btnSaveDB.Click += new System.EventHandler(this.BtnSaveDBClick);
			// 
			// btnPen
			// 
			this.btnPen.Checked = true;
			this.btnPen.CheckState = System.Windows.Forms.CheckState.Checked;
			this.btnPen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPen.Image = ((System.Drawing.Image)(resources.GetObject("btnPen.Image")));
			this.btnPen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPen.Name = "btnPen";
			this.btnPen.Size = new System.Drawing.Size(24, 25);
			this.btnPen.Text = "えんぴつ";
			this.btnPen.Click += new System.EventHandler(this.BtnPenClick);
			// 
			// btnEraser
			// 
			this.btnEraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEraser.Image = ((System.Drawing.Image)(resources.GetObject("btnEraser.Image")));
			this.btnEraser.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEraser.Name = "btnEraser";
			this.btnEraser.Size = new System.Drawing.Size(24, 25);
			this.btnEraser.Text = "消しゴム";
			this.btnEraser.Click += new System.EventHandler(this.BtnEraserClick);
			// 
			// comboColor
			// 
			this.comboColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboColor.Name = "comboColor";
			this.comboColor.Size = new System.Drawing.Size(99, 28);
			this.comboColor.SelectedIndexChanged += new System.EventHandler(this.ComboColorSelectedIndexChanged);
			// 
			// cmbLineSize
			// 
			this.cmbLineSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLineSize.Items.AddRange(new object[] {
			"1",
			"3",
			"5",
			"8",
			"10"});
			this.cmbLineSize.Name = "cmbLineSize";
			this.cmbLineSize.Size = new System.Drawing.Size(99, 28);
			this.cmbLineSize.SelectedIndexChanged += new System.EventHandler(this.CmbLineSizeSelectedIndexChanged);
			// 
			// btnString
			// 
			this.btnString.CheckOnClick = true;
			this.btnString.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnString.Image = ((System.Drawing.Image)(resources.GetObject("btnString.Image")));
			this.btnString.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnString.Name = "btnString";
			this.btnString.Size = new System.Drawing.Size(24, 25);
			this.btnString.Text = "文字列";
			this.btnString.CheckedChanged += new System.EventHandler(this.BtnStringCheckedChanged);
			// 
			// saveFileDlg
			// 
			this.saveFileDlg.Filter = "JPEG(*.jpeg)|*.jpeg|PNG (*.png)|*.png|GIF (*.gif)|*.gif|すべてのファイル|*.*";
			this.saveFileDlg.Title = "名前をつけて保存";
			// 
			// openFileDlg
			// 
			this.openFileDlg.Filter = "JPEG(*.jpeg)|*.jpeg|PNG (*.png)|*.png|GIF (*.gif)|*.gif|すべてのファイル|*.*";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblPressure);
			this.groupBox1.Controls.Add(this.lblPosition);
			this.groupBox1.Controls.Add(this.lblDeviceName);
			this.groupBox1.Controls.Add(this.lblWinTabID);
			this.groupBox1.Controls.Add(this.prgPressuer);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(451, 36);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox1.Size = new System.Drawing.Size(235, 218);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "ペンタブレット情報";
			// 
			// lblPressure
			// 
			this.lblPressure.Location = new System.Drawing.Point(101, 125);
			this.lblPressure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblPressure.Name = "lblPressure";
			this.lblPressure.Size = new System.Drawing.Size(125, 29);
			this.lblPressure.TabIndex = 8;
			this.lblPressure.Text = "NPressuer";
			this.lblPressure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPosition
			// 
			this.lblPosition.Location = new System.Drawing.Point(101, 96);
			this.lblPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblPosition.Name = "lblPosition";
			this.lblPosition.Size = new System.Drawing.Size(125, 29);
			this.lblPosition.TabIndex = 7;
			this.lblPosition.Text = "Position";
			this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblDeviceName
			// 
			this.lblDeviceName.Location = new System.Drawing.Point(101, 68);
			this.lblDeviceName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblDeviceName.Name = "lblDeviceName";
			this.lblDeviceName.Size = new System.Drawing.Size(125, 29);
			this.lblDeviceName.TabIndex = 6;
			this.lblDeviceName.Text = "DeviceName";
			this.lblDeviceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblWinTabID
			// 
			this.lblWinTabID.Location = new System.Drawing.Point(101, 39);
			this.lblWinTabID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblWinTabID.Name = "lblWinTabID";
			this.lblWinTabID.Size = new System.Drawing.Size(125, 29);
			this.lblWinTabID.TabIndex = 5;
			this.lblWinTabID.Text = "ID";
			this.lblWinTabID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// prgPressuer
			// 
			this.prgPressuer.Location = new System.Drawing.Point(9, 158);
			this.prgPressuer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.prgPressuer.Name = "prgPressuer";
			this.prgPressuer.Size = new System.Drawing.Size(217, 29);
			this.prgPressuer.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(9, 125);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(133, 29);
			this.label4.TabIndex = 3;
			this.label4.Text = "筆圧：";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(9, 96);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(133, 29);
			this.label3.TabIndex = 2;
			this.label3.Text = "座標：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 68);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(133, 29);
			this.label2.TabIndex = 1;
			this.label2.Text = "デバイス名：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 39);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(133, 29);
			this.label1.TabIndex = 0;
			this.label1.Text = "WinTabID：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BtnCopyWindow
			// 
			this.BtnCopyWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnCopyWindow.Image = ((System.Drawing.Image)(resources.GetObject("BtnCopyWindow.Image")));
			this.BtnCopyWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnCopyWindow.Name = "BtnCopyWindow";
			this.BtnCopyWindow.Size = new System.Drawing.Size(24, 25);
			this.BtnCopyWindow.Text = "ウィンドウをコピー";
			this.BtnCopyWindow.Click += new System.EventHandler(this.BtnCopyWindowClick);
			// 
			// InputCharaForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(445, 436);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.panel1);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "InputCharaForm";
			this.Text = "文字入力";
			this.Load += new System.EventHandler(this.InputCharaFormLoad);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.Label lblPosition;
		private System.Windows.Forms.ProgressBar prgPressuer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblWinTabID;
		private System.Windows.Forms.Label lblDeviceName;
		private System.Windows.Forms.Label lblPressure;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ToolStripButton btnNew;
		private System.Windows.Forms.ToolStripButton btnString;
		private System.Windows.Forms.ToolStripComboBox cmbLineSize;
		private System.Windows.Forms.OpenFileDialog openFileDlg;
		private System.Windows.Forms.SaveFileDialog saveFileDlg;
		private System.Windows.Forms.ToolStripComboBox comboColor;
		private System.Windows.Forms.ToolStripButton btnEraser;
		private System.Windows.Forms.ToolStripButton btnPen;
		private System.Windows.Forms.ToolStripButton btnSaveDB;
		private System.Windows.Forms.ToolStripButton btnSaveImage;
		private System.Windows.Forms.ToolStripButton btnOpen;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.PictureBox ImageBox;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStripButton BtnCopyWindow;
	}
}
