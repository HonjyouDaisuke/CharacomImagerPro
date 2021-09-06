/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2012/03/14
 * 時刻: 10:38
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
namespace CharacomImagerPro
{
	partial class IntraindividualGraph
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntraindividualGraph));
			this.GraphImage = new System.Windows.Forms.PictureBox();
			this.dgvData = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnCopy = new System.Windows.Forms.ToolStripButton();
			this.btnImageSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnUndo = new System.Windows.Forms.ToolStripButton();
			this.btnRedo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnPreview = new System.Windows.Forms.ToolStripButton();
			this.btnPrint = new System.Windows.Forms.ToolStripButton();
			this.saveImageDialog = new System.Windows.Forms.SaveFileDialog();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.btnCopyWindow = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.GraphImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
			this.panel1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// GraphImage
			// 
			this.GraphImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.GraphImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GraphImage.Location = new System.Drawing.Point(0, 0);
			this.GraphImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.GraphImage.Name = "GraphImage";
			this.GraphImage.Size = new System.Drawing.Size(649, 416);
			this.GraphImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.GraphImage.TabIndex = 0;
			this.GraphImage.TabStop = false;
			this.GraphImage.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphImagePaint);
			// 
			// dgvData
			// 
			this.dgvData.AllowUserToAddRows = false;
			this.dgvData.AllowUserToDeleteRows = false;
			this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvData.Location = new System.Drawing.Point(4, 461);
			this.dgvData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.dgvData.Name = "dgvData";
			this.dgvData.ReadOnly = true;
			this.dgvData.RowHeadersVisible = false;
			this.dgvData.RowTemplate.Height = 21;
			this.dgvData.Size = new System.Drawing.Size(652, 234);
			this.dgvData.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.GraphImage);
			this.panel1.Location = new System.Drawing.Point(4, 35);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(651, 418);
			this.panel1.TabIndex = 2;
			// 
			// toolStrip1
			// 
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.btnCopy,
			this.btnImageSave,
			this.btnCopyWindow,
			this.toolStripSeparator1,
			this.btnUndo,
			this.btnRedo,
			this.toolStripSeparator2,
			this.btnPreview,
			this.btnPrint});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(937, 27);
			this.toolStrip1.TabIndex = 3;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnCopy
			// 
			this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
			this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(24, 24);
			this.btnCopy.Text = "コピー";
			this.btnCopy.Click += new System.EventHandler(this.BtnCopyClick);
			// 
			// btnImageSave
			// 
			this.btnImageSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnImageSave.Image = ((System.Drawing.Image)(resources.GetObject("btnImageSave.Image")));
			this.btnImageSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImageSave.Name = "btnImageSave";
			this.btnImageSave.Size = new System.Drawing.Size(24, 24);
			this.btnImageSave.Text = "画像として保存";
			this.btnImageSave.Click += new System.EventHandler(this.BtnImageSaveClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
			// 
			// btnUndo
			// 
			this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
			this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnUndo.Name = "btnUndo";
			this.btnUndo.Size = new System.Drawing.Size(24, 24);
			this.btnUndo.Text = "元に戻す";
			this.btnUndo.Click += new System.EventHandler(this.BtnUndoClick);
			// 
			// btnRedo
			// 
			this.btnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnRedo.Image = ((System.Drawing.Image)(resources.GetObject("btnRedo.Image")));
			this.btnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRedo.Name = "btnRedo";
			this.btnRedo.Size = new System.Drawing.Size(24, 24);
			this.btnRedo.Text = "やり直し";
			this.btnRedo.Click += new System.EventHandler(this.BtnRedoClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
			// 
			// btnPreview
			// 
			this.btnPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
			this.btnPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPreview.Name = "btnPreview";
			this.btnPreview.Size = new System.Drawing.Size(24, 24);
			this.btnPreview.Text = "印刷プレビュー";
			this.btnPreview.Click += new System.EventHandler(this.BtnPreviewClick);
			// 
			// btnPrint
			// 
			this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
			this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(24, 24);
			this.btnPrint.Text = "印刷";
			this.btnPrint.Click += new System.EventHandler(this.BtnPrintClick);
			// 
			// saveImageDialog
			// 
			this.saveImageDialog.Filter = "JPEG(*.jpeg)|*.jpeg|PNG (*.png)|*.png|GIF (*.gif)|*.gif|すべてのファイル|*.*";
			this.saveImageDialog.Title = "名前をつけて保存";
			// 
			// txtComment
			// 
			this.txtComment.Location = new System.Drawing.Point(664, 36);
			this.txtComment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.ReadOnly = true;
			this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtComment.Size = new System.Drawing.Size(265, 658);
			this.txtComment.TabIndex = 4;
			// 
			// btnCopyWindow
			// 
			this.btnCopyWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnCopyWindow.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyWindow.Image")));
			this.btnCopyWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCopyWindow.Name = "btnCopyWindow";
			this.btnCopyWindow.Size = new System.Drawing.Size(24, 24);
			this.btnCopyWindow.Text = "ウィンドウをコピー";
			this.btnCopyWindow.Click += new System.EventHandler(this.BtnCopyWindowClick);
			// 
			// IntraindividualGraph
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(937, 698);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.dgvData);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "IntraindividualGraph";
			this.Text = "個人内変動グラフ";
			this.SizeChanged += new System.EventHandler(this.IntraindividualGraphSizeChanged);
			((System.ComponentModel.ISupportInitialize)(this.GraphImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
			this.panel1.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.TextBox txtComment;
		private System.Windows.Forms.SaveFileDialog saveImageDialog;
		private System.Windows.Forms.ToolStripButton btnPrint;
		private System.Windows.Forms.ToolStripButton btnPreview;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnRedo;
		private System.Windows.Forms.ToolStripButton btnUndo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnImageSave;
		private System.Windows.Forms.ToolStripButton btnCopy;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView dgvData;
		private System.Windows.Forms.PictureBox GraphImage;
		private System.Windows.Forms.ToolStripButton btnCopyWindow;
	}
}
