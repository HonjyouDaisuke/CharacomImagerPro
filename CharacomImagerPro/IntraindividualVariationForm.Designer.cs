/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2012/03/12
 * 時刻: 11:18
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
namespace CharacomImagerPro
{
	partial class IntraindividualVariationForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntraindividualVariationForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dgvLegend = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnMakeGraph = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnSaveAs = new System.Windows.Forms.ToolStripButton();
            this.BtnCopyWindow = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.btnRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPreview = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.saveFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDlg = new System.Windows.Forms.PrintPreviewDialog();
            this.printDlg = new System.Windows.Forms.PrintDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLegend)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(400, 35);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 393);
            this.panel1.TabIndex = 2;
            this.panel1.SizeChanged += new System.EventHandler(this.Panel1SizeChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bullet_arrow_up.png");
            this.imageList1.Images.SetKeyName(1, "bullet_arrow_down.png");
            this.imageList1.Images.SetKeyName(2, "delete.png");
            this.imageList1.Images.SetKeyName(3, "bullet_arrow_left.png");
            this.imageList1.Images.SetKeyName(4, "bullet_arrow_right.png");
            // 
            // dgvLegend
            // 
            this.dgvLegend.AllowUserToAddRows = false;
            this.dgvLegend.AllowUserToDeleteRows = false;
            this.dgvLegend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLegend.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvLegend.Location = new System.Drawing.Point(16, 68);
            this.dgvLegend.Margin = new System.Windows.Forms.Padding(4);
            this.dgvLegend.Name = "dgvLegend";
            this.dgvLegend.RowHeadersVisible = false;
            this.dgvLegend.RowHeadersWidth = 51;
            this.dgvLegend.RowTemplate.Height = 21;
            this.dgvLegend.Size = new System.Drawing.Size(372, 292);
            this.dgvLegend.TabIndex = 21;
            this.dgvLegend.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLegendCellEnter);
            this.dgvLegend.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLegendCellValueChanged);
            this.dgvLegend.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvLegendEditingControlShowing);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "No.";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 30;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "項目名";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Column3.DisplayStyleForCurrentCellOnly = true;
            this.Column3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column3.HeaderText = "線色";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column3.Width = 70;
            // 
            // Column4
            // 
            this.Column4.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Column4.DisplayStyleForCurrentCellOnly = true;
            this.Column4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column4.HeaderText = "マーク色";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.Width = 70;
            // 
            // btnMakeGraph
            // 
            this.btnMakeGraph.Image = ((System.Drawing.Image)(resources.GetObject("btnMakeGraph.Image")));
            this.btnMakeGraph.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMakeGraph.Location = new System.Drawing.Point(16, 368);
            this.btnMakeGraph.Margin = new System.Windows.Forms.Padding(4);
            this.btnMakeGraph.Name = "btnMakeGraph";
            this.btnMakeGraph.Size = new System.Drawing.Size(115, 29);
            this.btnMakeGraph.TabIndex = 22;
            this.btnMakeGraph.Text = "グラフを作成";
            this.btnMakeGraph.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMakeGraph.UseVisualStyleBackColor = true;
            this.btnMakeGraph.Click += new System.EventHandler(this.BtnMakeGraphClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.btnSave,
            this.btnSaveAs,
            this.BtnCopyWindow,
            this.toolStripSeparator1,
            this.btnUndo,
            this.btnRedo,
            this.toolStripSeparator2,
            this.btnAdd,
            this.btnDel,
            this.toolStripSeparator3,
            this.btnPreview,
            this.btnPrint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1273, 27);
            this.toolStrip1.TabIndex = 23;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(29, 24);
            this.btnOpen.Text = "toolStripButton1";
            this.btnOpen.ToolTipText = "開く";
            this.btnOpen.Click += new System.EventHandler(this.BtnOpenClick);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(29, 24);
            this.btnSave.ToolTipText = "保存";
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.Image")));
            this.btnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(29, 24);
            this.btnSaveAs.Text = "toolStripButton1";
            this.btnSaveAs.ToolTipText = "名前をつけて保存";
            this.btnSaveAs.Click += new System.EventHandler(this.BtnSaveAsClick);
            // 
            // BtnCopyWindow
            // 
            this.BtnCopyWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnCopyWindow.Image = ((System.Drawing.Image)(resources.GetObject("BtnCopyWindow.Image")));
            this.BtnCopyWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCopyWindow.Name = "BtnCopyWindow";
            this.BtnCopyWindow.Size = new System.Drawing.Size(29, 24);
            this.BtnCopyWindow.Text = "ウィンドウをコピーウィンドウをコピー";
            this.BtnCopyWindow.Click += new System.EventHandler(this.BtnCopyWindowClick);
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
            this.btnUndo.Size = new System.Drawing.Size(29, 24);
            this.btnUndo.Text = "toolStripButton3";
            this.btnUndo.ToolTipText = "元に戻す";
            this.btnUndo.Click += new System.EventHandler(this.BtnUndoClick);
            // 
            // btnRedo
            // 
            this.btnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRedo.Image = ((System.Drawing.Image)(resources.GetObject("btnRedo.Image")));
            this.btnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(29, 24);
            this.btnRedo.Text = "toolStripButton4";
            this.btnRedo.ToolTipText = "やり直し";
            this.btnRedo.Click += new System.EventHandler(this.BtnRedoClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(29, 24);
            this.btnAdd.Text = "文字種を追加";
            this.btnAdd.Click += new System.EventHandler(this.BtnAddClick);
            // 
            // btnDel
            // 
            this.btnDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(29, 24);
            this.btnDel.Text = "文字種を削除";
            this.btnDel.Click += new System.EventHandler(this.BtnDelClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // btnPreview
            // 
            this.btnPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
            this.btnPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(29, 24);
            this.btnPreview.Text = "toolStripButton6";
            this.btnPreview.ToolTipText = "印刷プレビュー";
            this.btnPreview.Click += new System.EventHandler(this.BtnPreviewClick);
            // 
            // btnPrint
            // 
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(29, 24);
            this.btnPrint.Text = "toolStripButton5";
            this.btnPrint.ToolTipText = "印刷";
            this.btnPrint.Click += new System.EventHandler(this.BtnPrintClick);
            // 
            // saveFileDlg
            // 
            this.saveFileDlg.Filter = "個人内変動ファイル(*.civ)|*.civ|すべてのファイル(*.*)|*.*";
            this.saveFileDlg.Title = "名前をつけて保存する(個人内変動データ)";
            // 
            // openFileDlg
            // 
            this.openFileDlg.Filter = "個人内変動ファイル(*.civ)|*.civ|すべてのファイル(*.*)|*.*";
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocumentPrintPage);
            // 
            // printPreviewDlg
            // 
            this.printPreviewDlg.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDlg.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDlg.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDlg.Document = this.printDocument;
            this.printPreviewDlg.Enabled = true;
            this.printPreviewDlg.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDlg.Icon")));
            this.printPreviewDlg.Name = "printPreviewDlg";
            this.printPreviewDlg.Visible = false;
            // 
            // printDlg
            // 
            this.printDlg.Document = this.printDocument;
            this.printDlg.UseEXDialog = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 29);
            this.label1.TabIndex = 25;
            this.label1.Text = "特徴抽出法：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(112, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 29);
            this.label2.TabIndex = 26;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IntraindividualVariationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 437);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnMakeGraph);
            this.Controls.Add(this.dgvLegend);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "IntraindividualVariationForm";
            this.Text = "個人内変動";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IntraindividualVariationFormFormClosing);
            this.Load += new System.EventHandler(this.IntraindividualVariationFormLoad);
            this.Shown += new System.EventHandler(this.IntraindividualVariationFormShown);
            this.SizeChanged += new System.EventHandler(this.IntraindividualVariationFormSizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.IntraindividualVariationFormPaint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLegend)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripButton btnSaveAs;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PrintDialog printDlg;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDlg;
		private System.Drawing.Printing.PrintDocument printDocument;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton btnDel;
		private System.Windows.Forms.ToolStripButton btnAdd;
		private System.Windows.Forms.OpenFileDialog openFileDlg;
		private System.Windows.Forms.SaveFileDialog saveFileDlg;
		private System.Windows.Forms.ToolStripButton btnPreview;
		private System.Windows.Forms.ToolStripButton btnPrint;
		private System.Windows.Forms.ToolStripButton btnRedo;
		private System.Windows.Forms.ToolStripButton btnUndo;
		private System.Windows.Forms.ToolStripButton btnSave;
		private System.Windows.Forms.ToolStripButton btnOpen;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.Button btnMakeGraph;
		private System.Windows.Forms.DataGridViewComboBoxColumn Column4;
		private System.Windows.Forms.DataGridViewComboBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridView dgvLegend;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStripButton BtnCopyWindow;
	}
}
