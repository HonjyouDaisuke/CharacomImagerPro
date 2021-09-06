/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2012/01/23
 * 時刻: 17:20
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
namespace CharacomImagerPro
{
	partial class CharaEditForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharaEditForm));
			this.imageBox = new System.Windows.Forms.PictureBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.cmbZoom = new System.Windows.Forms.ToolStripComboBox();
			this.cmbLineSize = new System.Windows.Forms.ToolStripComboBox();
			this.btnPencil = new System.Windows.Forms.ToolStripButton();
			this.btnEraser = new System.Windows.Forms.ToolStripButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageBox
			// 
			this.imageBox.Location = new System.Drawing.Point(0, 0);
			this.imageBox.Name = "imageBox";
			this.imageBox.Size = new System.Drawing.Size(320, 320);
			this.imageBox.TabIndex = 0;
			this.imageBox.TabStop = false;
			this.imageBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageBoxMouseMove);
			this.imageBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageBoxMouseDown);
			this.imageBox.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageBoxPaint);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripLabel1,
									this.cmbZoom,
									this.cmbLineSize,
									this.btnPencil,
									this.btnEraser});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(325, 26);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(32, 23);
			this.toolStripLabel1.Text = "倍率";
			// 
			// cmbZoom
			// 
			this.cmbZoom.Items.AddRange(new object[] {
									"400%",
									"300%",
									"200%",
									"150%",
									"100%",
									"50%"});
			this.cmbZoom.Name = "cmbZoom";
			this.cmbZoom.Size = new System.Drawing.Size(121, 26);
			this.cmbZoom.SelectedIndexChanged += new System.EventHandler(this.CmbZoomSelectedIndexChanged);
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
			this.cmbLineSize.Size = new System.Drawing.Size(75, 26);
			// 
			// btnPencil
			// 
			this.btnPencil.CheckOnClick = true;
			this.btnPencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPencil.Image = ((System.Drawing.Image)(resources.GetObject("btnPencil.Image")));
			this.btnPencil.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPencil.Name = "btnPencil";
			this.btnPencil.Size = new System.Drawing.Size(23, 23);
			this.btnPencil.Text = "toolStripButton1";
			this.btnPencil.ToolTipText = "鉛筆";
			this.btnPencil.CheckedChanged += new System.EventHandler(this.BtnPencilCheckedChanged);
			// 
			// btnEraser
			// 
			this.btnEraser.CheckOnClick = true;
			this.btnEraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEraser.Image = ((System.Drawing.Image)(resources.GetObject("btnEraser.Image")));
			this.btnEraser.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEraser.Name = "btnEraser";
			this.btnEraser.Size = new System.Drawing.Size(23, 23);
			this.btnEraser.Text = "toolStripButton2";
			this.btnEraser.CheckedChanged += new System.EventHandler(this.BtnEraserCheckedChanged);
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.imageBox);
			this.panel1.Location = new System.Drawing.Point(0, 26);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(322, 322);
			this.panel1.TabIndex = 2;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(164, 352);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.BtnOKClick);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(245, 352);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "キャンセル";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// CharaEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(325, 377);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "CharaEditForm";
			this.Text = "CharaEditForm";
			this.Shown += new System.EventHandler(this.CharaEditFormShown);
			((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.ToolStripComboBox cmbLineSize;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStripButton btnEraser;
		private System.Windows.Forms.ToolStripButton btnPencil;
		private System.Windows.Forms.ToolStripComboBox cmbZoom;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.PictureBox imageBox;
	}
}
