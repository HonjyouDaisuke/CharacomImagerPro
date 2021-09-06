/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2012/04/04
 * 時刻: 11:26
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
namespace CharacomImagerPro
{
	partial class RangeCompare
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RangeCompare));
			this.panel1 = new System.Windows.Forms.Panel();
			this.GraphImage = new System.Windows.Forms.PictureBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnOpen = new System.Windows.Forms.ToolStripButton();
			this.btnSave = new System.Windows.Forms.ToolStripButton();
			this.btnSaveAs = new System.Windows.Forms.ToolStripButton();
			this.BtnCopyWindow = new System.Windows.Forms.ToolStripButton();
			this.btnImageSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnUndo = new System.Windows.Forms.ToolStripButton();
			this.btnRedo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnGraph = new System.Windows.Forms.ToolStripButton();
			this.btnGraphCopy = new System.Windows.Forms.ToolStripButton();
			this.btnTableCopy = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.btnPrintPreview = new System.Windows.Forms.ToolStripButton();
			this.btnPrint = new System.Windows.Forms.ToolStripButton();
			this.saveFileDlg = new System.Windows.Forms.SaveFileDialog();
			this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
			this.SubMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuUndo = new System.Windows.Forms.ToolStripMenuItem();
			this.menuRedo = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.menuImageSave = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuGraphCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.CopyWindowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuListCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.menuPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
			this.menuPrint = new System.Windows.Forms.ToolStripMenuItem();
			this.menuPageSetup = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.saveImageFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.printDocument = new System.Drawing.Printing.PrintDocument();
			this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
			this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
			this.printDialog = new System.Windows.Forms.PrintDialog();
			this.dgvReference = new System.Windows.Forms.DataGridView();
			this.dgvJudge = new System.Windows.Forms.DataGridView();
			this.lblReferenceTitle = new System.Windows.Forms.Label();
			this.lblJudgeTitle = new System.Windows.Forms.Label();
			this.chkJudgeRange = new System.Windows.Forms.CheckBox();
			this.chkReferenceRange = new System.Windows.Forms.CheckBox();
			this.cmbJudgeColor = new System.Windows.Forms.ComboBox();
			this.lblJudgeColor = new System.Windows.Forms.Label();
			this.lblReferenceColor = new System.Windows.Forms.Label();
			this.cmbReferenceColor = new System.Windows.Forms.ComboBox();
			this.lblComment = new System.Windows.Forms.Label();
			this.lblPreView = new System.Windows.Forms.Label();
			this.chkR2 = new System.Windows.Forms.CheckBox();
			this.chkJudgeAve = new System.Windows.Forms.CheckBox();
			this.chkReferenceAve = new System.Windows.Forms.CheckBox();
			this.chkJudgeData = new System.Windows.Forms.CheckBox();
			this.chkReferenceData = new System.Windows.Forms.CheckBox();
			this.pJudgeB = new System.Windows.Forms.Panel();
			this.pJudgeA = new System.Windows.Forms.Panel();
			this.pReferenceA = new System.Windows.Forms.Panel();
			this.pReferenceB = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.GraphImage)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.SubMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvReference)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvJudge)).BeginInit();
			this.pJudgeB.SuspendLayout();
			this.pJudgeA.SuspendLayout();
			this.pReferenceA.SuspendLayout();
			this.pReferenceB.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.GraphImage);
			this.panel1.Location = new System.Drawing.Point(483, 551);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(187, 100);
			this.panel1.TabIndex = 3;
			// 
			// GraphImage
			// 
			this.GraphImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.GraphImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GraphImage.Location = new System.Drawing.Point(0, 0);
			this.GraphImage.Margin = new System.Windows.Forms.Padding(4);
			this.GraphImage.Name = "GraphImage";
			this.GraphImage.Size = new System.Drawing.Size(185, 98);
			this.GraphImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.GraphImage.TabIndex = 0;
			this.GraphImage.TabStop = false;
			this.GraphImage.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphImagePaint);
			// 
			// toolStrip1
			// 
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.btnOpen,
			this.btnSave,
			this.btnSaveAs,
			this.btnImageSave,
			this.BtnCopyWindow,
			this.toolStripSeparator1,
			this.btnUndo,
			this.btnRedo,
			this.toolStripSeparator2,
			this.btnGraph,
			this.btnGraphCopy,
			this.btnTableCopy,
			this.toolStripSeparator3,
			this.btnPrintPreview,
			this.btnPrint});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(724, 27);
			this.toolStrip1.TabIndex = 5;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnOpen
			// 
			this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
			this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(24, 24);
			this.btnOpen.Text = "ファイルを開く";
			this.btnOpen.ToolTipText = "開く";
			this.btnOpen.Click += new System.EventHandler(this.BtnOpenClick);
			// 
			// btnSave
			// 
			this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
			this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(24, 24);
			this.btnSave.Text = "保存";
			this.btnSave.ToolTipText = "保存";
			this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
			// 
			// btnSaveAs
			// 
			this.btnSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.Image")));
			this.btnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSaveAs.Name = "btnSaveAs";
			this.btnSaveAs.Size = new System.Drawing.Size(24, 24);
			this.btnSaveAs.Text = "名前をつけて保存";
			this.btnSaveAs.Click += new System.EventHandler(this.BtnSaveAsClick);
			// 
			// BtnCopyWindow
			// 
			this.BtnCopyWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnCopyWindow.Image = ((System.Drawing.Image)(resources.GetObject("BtnCopyWindow.Image")));
			this.BtnCopyWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnCopyWindow.Name = "BtnCopyWindow";
			this.BtnCopyWindow.Size = new System.Drawing.Size(24, 24);
			this.BtnCopyWindow.Text = "ウィンドウをコピー";
			this.BtnCopyWindow.Click += new System.EventHandler(this.BtnCopyWindowClick);
			// 
			// btnImageSave
			// 
			this.btnImageSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnImageSave.Image = ((System.Drawing.Image)(resources.GetObject("btnImageSave.Image")));
			this.btnImageSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImageSave.Name = "btnImageSave";
			this.btnImageSave.Size = new System.Drawing.Size(24, 24);
			this.btnImageSave.Text = "画像として保存";
			this.btnImageSave.ToolTipText = "画像として保存";
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
			this.btnUndo.ToolTipText = "元に戻す";
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
			this.btnRedo.ToolTipText = "やり直し";
			this.btnRedo.Click += new System.EventHandler(this.BtnRedoClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
			// 
			// btnGraph
			// 
			this.btnGraph.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnGraph.Image = ((System.Drawing.Image)(resources.GetObject("btnGraph.Image")));
			this.btnGraph.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnGraph.Name = "btnGraph";
			this.btnGraph.Size = new System.Drawing.Size(24, 24);
			this.btnGraph.Text = "グラフ作成";
			this.btnGraph.ToolTipText = "グラフを表示";
			this.btnGraph.Click += new System.EventHandler(this.BtnGraphClick);
			// 
			// btnGraphCopy
			// 
			this.btnGraphCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnGraphCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnGraphCopy.Image")));
			this.btnGraphCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnGraphCopy.Name = "btnGraphCopy";
			this.btnGraphCopy.Size = new System.Drawing.Size(24, 24);
			this.btnGraphCopy.Text = "グラフをコピー";
			this.btnGraphCopy.ToolTipText = "グラフをコピー";
			this.btnGraphCopy.Click += new System.EventHandler(this.BtnGraphCopyClick);
			// 
			// btnTableCopy
			// 
			this.btnTableCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnTableCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnTableCopy.Image")));
			this.btnTableCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnTableCopy.Name = "btnTableCopy";
			this.btnTableCopy.Size = new System.Drawing.Size(24, 24);
			this.btnTableCopy.Text = "表をコピー";
			this.btnTableCopy.ToolTipText = "一覧表をコピー";
			this.btnTableCopy.Click += new System.EventHandler(this.BtnTableCopyClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
			// 
			// btnPrintPreview
			// 
			this.btnPrintPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintPreview.Image")));
			this.btnPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPrintPreview.Name = "btnPrintPreview";
			this.btnPrintPreview.Size = new System.Drawing.Size(24, 24);
			this.btnPrintPreview.Text = "印刷プレビュー";
			this.btnPrintPreview.ToolTipText = "印刷プレビュー";
			this.btnPrintPreview.Click += new System.EventHandler(this.BtnPrintPreviewClick);
			// 
			// btnPrint
			// 
			this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
			this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(24, 24);
			this.btnPrint.Text = "印刷";
			this.btnPrint.ToolTipText = "印刷";
			this.btnPrint.Click += new System.EventHandler(this.BtnPrintClick);
			// 
			// saveFileDlg
			// 
			this.saveFileDlg.Filter = "変動比較ファイル(*.irc)|*.irc|すべてのファイル(*.*)|*.*";
			// 
			// openFileDlg
			// 
			this.openFileDlg.Filter = "変動比較ファイル(*.irc)|*.irc|すべてのファイル(*.*)|*.*";
			// 
			// SubMenu
			// 
			this.SubMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.SubMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.menuUndo,
			this.menuRedo,
			this.toolStripMenuItem4,
			this.menuOpen,
			this.menuSave,
			this.menuSaveAs,
			this.menuImageSave,
			this.toolStripMenuItem1,
			this.menuGraphCopy,
			this.CopyWindowMenuItem,
			this.menuListCopy,
			this.menuDelete,
			this.toolStripMenuItem2,
			this.menuPrintPreview,
			this.menuPrint,
			this.menuPageSetup,
			this.toolStripMenuItem3,
			this.menuClose});
			this.SubMenu.Name = "SubMenu";
			this.SubMenu.Size = new System.Drawing.Size(189, 392);
			this.SubMenu.Opened += new System.EventHandler(this.SubMenuOpened);
			// 
			// menuUndo
			// 
			this.menuUndo.Image = ((System.Drawing.Image)(resources.GetObject("menuUndo.Image")));
			this.menuUndo.Name = "menuUndo";
			this.menuUndo.Size = new System.Drawing.Size(188, 26);
			this.menuUndo.Text = "元に戻す";
			this.menuUndo.Click += new System.EventHandler(this.MenuUndoClick);
			// 
			// menuRedo
			// 
			this.menuRedo.Image = ((System.Drawing.Image)(resources.GetObject("menuRedo.Image")));
			this.menuRedo.Name = "menuRedo";
			this.menuRedo.Size = new System.Drawing.Size(188, 26);
			this.menuRedo.Text = "やり直し";
			this.menuRedo.Click += new System.EventHandler(this.MenuRedoClick);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(185, 6);
			// 
			// menuOpen
			// 
			this.menuOpen.Image = ((System.Drawing.Image)(resources.GetObject("menuOpen.Image")));
			this.menuOpen.Name = "menuOpen";
			this.menuOpen.Size = new System.Drawing.Size(188, 26);
			this.menuOpen.Text = "開く";
			this.menuOpen.Click += new System.EventHandler(this.MenuOpenClick);
			// 
			// menuSave
			// 
			this.menuSave.Image = ((System.Drawing.Image)(resources.GetObject("menuSave.Image")));
			this.menuSave.Name = "menuSave";
			this.menuSave.Size = new System.Drawing.Size(188, 26);
			this.menuSave.Text = "保存";
			this.menuSave.Click += new System.EventHandler(this.MenuSaveClick);
			// 
			// menuSaveAs
			// 
			this.menuSaveAs.Name = "menuSaveAs";
			this.menuSaveAs.Size = new System.Drawing.Size(188, 26);
			this.menuSaveAs.Text = "名前をつけて保存";
			this.menuSaveAs.Click += new System.EventHandler(this.MenuSaveAsClick);
			// 
			// menuImageSave
			// 
			this.menuImageSave.Image = ((System.Drawing.Image)(resources.GetObject("menuImageSave.Image")));
			this.menuImageSave.Name = "menuImageSave";
			this.menuImageSave.Size = new System.Drawing.Size(188, 26);
			this.menuImageSave.Text = "画像として保存";
			this.menuImageSave.Click += new System.EventHandler(this.MenuImageSaveClick);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(185, 6);
			// 
			// menuGraphCopy
			// 
			this.menuGraphCopy.Image = ((System.Drawing.Image)(resources.GetObject("menuGraphCopy.Image")));
			this.menuGraphCopy.Name = "menuGraphCopy";
			this.menuGraphCopy.Size = new System.Drawing.Size(188, 26);
			this.menuGraphCopy.Text = "グラフをコピー";
			this.menuGraphCopy.Click += new System.EventHandler(this.MenuGraphCopyClick);
			// 
			// CopyWindowMenuItem
			// 
			this.CopyWindowMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CopyWindowMenuItem.Image")));
			this.CopyWindowMenuItem.Name = "CopyWindowMenuItem";
			this.CopyWindowMenuItem.Size = new System.Drawing.Size(188, 26);
			this.CopyWindowMenuItem.Text = "ウィンドウをコピー";
			this.CopyWindowMenuItem.Click += new System.EventHandler(this.CopyWindowMenuItemClick);
			// 
			// menuListCopy
			// 
			this.menuListCopy.Image = ((System.Drawing.Image)(resources.GetObject("menuListCopy.Image")));
			this.menuListCopy.Name = "menuListCopy";
			this.menuListCopy.Size = new System.Drawing.Size(188, 26);
			this.menuListCopy.Text = "一覧表をコピー";
			this.menuListCopy.Click += new System.EventHandler(this.MenuListCopyClick);
			// 
			// menuDelete
			// 
			this.menuDelete.Image = ((System.Drawing.Image)(resources.GetObject("menuDelete.Image")));
			this.menuDelete.Name = "menuDelete";
			this.menuDelete.Size = new System.Drawing.Size(188, 26);
			this.menuDelete.Text = "一行削除";
			this.menuDelete.Click += new System.EventHandler(this.MenuDeleteClick);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(185, 6);
			// 
			// menuPrintPreview
			// 
			this.menuPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("menuPrintPreview.Image")));
			this.menuPrintPreview.Name = "menuPrintPreview";
			this.menuPrintPreview.Size = new System.Drawing.Size(188, 26);
			this.menuPrintPreview.Text = "印刷プレビュー";
			this.menuPrintPreview.Click += new System.EventHandler(this.MenuPrintPreviewClick);
			// 
			// menuPrint
			// 
			this.menuPrint.Image = ((System.Drawing.Image)(resources.GetObject("menuPrint.Image")));
			this.menuPrint.Name = "menuPrint";
			this.menuPrint.Size = new System.Drawing.Size(188, 26);
			this.menuPrint.Text = "印刷";
			this.menuPrint.Click += new System.EventHandler(this.MenuPrintClick);
			// 
			// menuPageSetup
			// 
			this.menuPageSetup.Image = ((System.Drawing.Image)(resources.GetObject("menuPageSetup.Image")));
			this.menuPageSetup.Name = "menuPageSetup";
			this.menuPageSetup.Size = new System.Drawing.Size(188, 26);
			this.menuPageSetup.Text = "ページ設定";
			this.menuPageSetup.Click += new System.EventHandler(this.MenuPageSetupClick);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(185, 6);
			// 
			// menuClose
			// 
			this.menuClose.Image = ((System.Drawing.Image)(resources.GetObject("menuClose.Image")));
			this.menuClose.Name = "menuClose";
			this.menuClose.Size = new System.Drawing.Size(188, 26);
			this.menuClose.Text = "閉じる";
			this.menuClose.Click += new System.EventHandler(this.MenuCloseClick);
			// 
			// txtComment
			// 
			this.txtComment.Location = new System.Drawing.Point(16, 551);
			this.txtComment.Margin = new System.Windows.Forms.Padding(4);
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtComment.Size = new System.Drawing.Size(457, 99);
			this.txtComment.TabIndex = 6;
			// 
			// saveImageFileDialog
			// 
			this.saveImageFileDialog.Filter = "JPEG(*.jpeg)|*.jpeg|PNG (*.png)|*.png|GIF (*.gif)|*.gif|すべてのファイル|*.*";
			// 
			// printDocument
			// 
			this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocumentPrintPage);
			// 
			// printPreviewDialog
			// 
			this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog.Document = this.printDocument;
			this.printPreviewDialog.Enabled = true;
			this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
			this.printPreviewDialog.Name = "printPreviewDialog";
			this.printPreviewDialog.Visible = false;
			// 
			// pageSetupDialog
			// 
			this.pageSetupDialog.Document = this.printDocument;
			// 
			// printDialog
			// 
			this.printDialog.Document = this.printDocument;
			this.printDialog.UseEXDialog = true;
			// 
			// dgvReference
			// 
			this.dgvReference.AllowDrop = true;
			this.dgvReference.AllowUserToAddRows = false;
			this.dgvReference.AllowUserToDeleteRows = false;
			this.dgvReference.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvReference.Location = new System.Drawing.Point(16, 329);
			this.dgvReference.Margin = new System.Windows.Forms.Padding(4);
			this.dgvReference.Name = "dgvReference";
			this.dgvReference.RowHeadersVisible = false;
			this.dgvReference.RowTemplate.Height = 21;
			this.dgvReference.Size = new System.Drawing.Size(641, 188);
			this.dgvReference.TabIndex = 1;
			this.dgvReference.DragDrop += new System.Windows.Forms.DragEventHandler(this.DgvReferenceDragDrop);
			this.dgvReference.DragEnter += new System.Windows.Forms.DragEventHandler(this.DgvReferenceDragEnter);
			// 
			// dgvJudge
			// 
			this.dgvJudge.AllowDrop = true;
			this.dgvJudge.AllowUserToAddRows = false;
			this.dgvJudge.AllowUserToDeleteRows = false;
			this.dgvJudge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvJudge.Location = new System.Drawing.Point(16, 71);
			this.dgvJudge.Margin = new System.Windows.Forms.Padding(4);
			this.dgvJudge.Name = "dgvJudge";
			this.dgvJudge.RowHeadersVisible = false;
			this.dgvJudge.RowTemplate.Height = 21;
			this.dgvJudge.Size = new System.Drawing.Size(655, 188);
			this.dgvJudge.TabIndex = 7;
			this.dgvJudge.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvJudgeCellEnter);
			this.dgvJudge.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvJudgeCellValueChanged);
			this.dgvJudge.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvJudgeDataError);
			this.dgvJudge.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvJudgeEditingControlShowing);
			this.dgvJudge.DragDrop += new System.Windows.Forms.DragEventHandler(this.DgvJudgeDragDrop);
			this.dgvJudge.DragEnter += new System.Windows.Forms.DragEventHandler(this.DgvJudgeDragEnter);
			// 
			// lblReferenceTitle
			// 
			this.lblReferenceTitle.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblReferenceTitle.Location = new System.Drawing.Point(0, 0);
			this.lblReferenceTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblReferenceTitle.Name = "lblReferenceTitle";
			this.lblReferenceTitle.Size = new System.Drawing.Size(79, 29);
			this.lblReferenceTitle.TabIndex = 8;
			this.lblReferenceTitle.Text = "対照資料";
			this.lblReferenceTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblJudgeTitle
			// 
			this.lblJudgeTitle.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblJudgeTitle.Location = new System.Drawing.Point(0, 0);
			this.lblJudgeTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblJudgeTitle.Name = "lblJudgeTitle";
			this.lblJudgeTitle.Size = new System.Drawing.Size(79, 29);
			this.lblJudgeTitle.TabIndex = 9;
			this.lblJudgeTitle.Text = "鑑定資料";
			this.lblJudgeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkJudgeRange
			// 
			this.chkJudgeRange.Checked = true;
			this.chkJudgeRange.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkJudgeRange.Location = new System.Drawing.Point(5, 0);
			this.chkJudgeRange.Margin = new System.Windows.Forms.Padding(4);
			this.chkJudgeRange.Name = "chkJudgeRange";
			this.chkJudgeRange.Size = new System.Drawing.Size(101, 30);
			this.chkJudgeRange.TabIndex = 10;
			this.chkJudgeRange.Text = "変動範囲";
			this.chkJudgeRange.UseVisualStyleBackColor = true;
			this.chkJudgeRange.CheckedChanged += new System.EventHandler(this.ChkJudgeRangeCheckedChanged);
			// 
			// chkReferenceRange
			// 
			this.chkReferenceRange.Checked = true;
			this.chkReferenceRange.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkReferenceRange.Location = new System.Drawing.Point(11, 0);
			this.chkReferenceRange.Margin = new System.Windows.Forms.Padding(4);
			this.chkReferenceRange.Name = "chkReferenceRange";
			this.chkReferenceRange.Size = new System.Drawing.Size(101, 30);
			this.chkReferenceRange.TabIndex = 11;
			this.chkReferenceRange.Text = "変動範囲";
			this.chkReferenceRange.UseVisualStyleBackColor = true;
			this.chkReferenceRange.CheckedChanged += new System.EventHandler(this.ChkReferenceRangeCheckedChanged);
			// 
			// cmbJudgeColor
			// 
			this.cmbJudgeColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbJudgeColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbJudgeColor.FormattingEnabled = true;
			this.cmbJudgeColor.Location = new System.Drawing.Point(173, 2);
			this.cmbJudgeColor.Margin = new System.Windows.Forms.Padding(4);
			this.cmbJudgeColor.Name = "cmbJudgeColor";
			this.cmbJudgeColor.Size = new System.Drawing.Size(160, 23);
			this.cmbJudgeColor.TabIndex = 12;
			this.cmbJudgeColor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.CmbJudgeColorDrawItem);
			this.cmbJudgeColor.SelectedIndexChanged += new System.EventHandler(this.CmbJudgeColorSelectedIndexChanged);
			// 
			// lblJudgeColor
			// 
			this.lblJudgeColor.Location = new System.Drawing.Point(115, 0);
			this.lblJudgeColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblJudgeColor.Name = "lblJudgeColor";
			this.lblJudgeColor.Size = new System.Drawing.Size(59, 29);
			this.lblJudgeColor.TabIndex = 13;
			this.lblJudgeColor.Text = "表示色";
			this.lblJudgeColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblReferenceColor
			// 
			this.lblReferenceColor.Location = new System.Drawing.Point(112, 0);
			this.lblReferenceColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblReferenceColor.Name = "lblReferenceColor";
			this.lblReferenceColor.Size = new System.Drawing.Size(59, 29);
			this.lblReferenceColor.TabIndex = 15;
			this.lblReferenceColor.Text = "表示色";
			this.lblReferenceColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbReferenceColor
			// 
			this.cmbReferenceColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbReferenceColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbReferenceColor.FormattingEnabled = true;
			this.cmbReferenceColor.Location = new System.Drawing.Point(179, 2);
			this.cmbReferenceColor.Margin = new System.Windows.Forms.Padding(4);
			this.cmbReferenceColor.Name = "cmbReferenceColor";
			this.cmbReferenceColor.Size = new System.Drawing.Size(160, 23);
			this.cmbReferenceColor.TabIndex = 14;
			this.cmbReferenceColor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.CmbReferenceColorDrawItem);
			this.cmbReferenceColor.SelectedIndexChanged += new System.EventHandler(this.CmbReferenceColorSelectedIndexChanged);
			// 
			// lblComment
			// 
			this.lblComment.Location = new System.Drawing.Point(16, 518);
			this.lblComment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblComment.Name = "lblComment";
			this.lblComment.Size = new System.Drawing.Size(79, 29);
			this.lblComment.TabIndex = 16;
			this.lblComment.Text = "コメント";
			this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPreView
			// 
			this.lblPreView.Location = new System.Drawing.Point(483, 518);
			this.lblPreView.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblPreView.Name = "lblPreView";
			this.lblPreView.Size = new System.Drawing.Size(105, 29);
			this.lblPreView.TabIndex = 17;
			this.lblPreView.Text = "グラフプレビュー";
			this.lblPreView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkR2
			// 
			this.chkR2.Checked = true;
			this.chkR2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkR2.Location = new System.Drawing.Point(239, 0);
			this.chkR2.Margin = new System.Windows.Forms.Padding(4);
			this.chkR2.Name = "chkR2";
			this.chkR2.Size = new System.Drawing.Size(97, 30);
			this.chkR2.TabIndex = 18;
			this.chkR2.Text = "平均除外";
			this.chkR2.UseVisualStyleBackColor = true;
			this.chkR2.Visible = false;
			this.chkR2.CheckedChanged += new System.EventHandler(this.ChkR2CheckedChanged);
			// 
			// chkJudgeAve
			// 
			this.chkJudgeAve.Checked = true;
			this.chkJudgeAve.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkJudgeAve.Location = new System.Drawing.Point(167, 0);
			this.chkJudgeAve.Margin = new System.Windows.Forms.Padding(4);
			this.chkJudgeAve.Name = "chkJudgeAve";
			this.chkJudgeAve.Size = new System.Drawing.Size(72, 30);
			this.chkJudgeAve.TabIndex = 19;
			this.chkJudgeAve.Text = "平均";
			this.chkJudgeAve.UseVisualStyleBackColor = true;
			this.chkJudgeAve.CheckedChanged += new System.EventHandler(this.ChkJudgeAveCheckedChanged);
			// 
			// chkReferenceAve
			// 
			this.chkReferenceAve.Checked = true;
			this.chkReferenceAve.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkReferenceAve.Location = new System.Drawing.Point(167, 0);
			this.chkReferenceAve.Margin = new System.Windows.Forms.Padding(4);
			this.chkReferenceAve.Name = "chkReferenceAve";
			this.chkReferenceAve.Size = new System.Drawing.Size(64, 30);
			this.chkReferenceAve.TabIndex = 20;
			this.chkReferenceAve.Text = "平均";
			this.chkReferenceAve.UseVisualStyleBackColor = true;
			this.chkReferenceAve.CheckedChanged += new System.EventHandler(this.ChkReferenceAveCheckedChanged);
			// 
			// chkJudgeData
			// 
			this.chkJudgeData.Checked = true;
			this.chkJudgeData.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkJudgeData.Location = new System.Drawing.Point(87, 0);
			this.chkJudgeData.Margin = new System.Windows.Forms.Padding(4);
			this.chkJudgeData.Name = "chkJudgeData";
			this.chkJudgeData.Size = new System.Drawing.Size(72, 30);
			this.chkJudgeData.TabIndex = 21;
			this.chkJudgeData.Text = "データ";
			this.chkJudgeData.UseVisualStyleBackColor = true;
			this.chkJudgeData.CheckedChanged += new System.EventHandler(this.ChkJudgeDataCheckedChanged);
			// 
			// chkReferenceData
			// 
			this.chkReferenceData.Checked = true;
			this.chkReferenceData.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkReferenceData.Location = new System.Drawing.Point(87, 0);
			this.chkReferenceData.Margin = new System.Windows.Forms.Padding(4);
			this.chkReferenceData.Name = "chkReferenceData";
			this.chkReferenceData.Size = new System.Drawing.Size(72, 30);
			this.chkReferenceData.TabIndex = 22;
			this.chkReferenceData.Text = "データ";
			this.chkReferenceData.UseVisualStyleBackColor = true;
			this.chkReferenceData.CheckedChanged += new System.EventHandler(this.ChkReferenceDataCheckedChanged);
			// 
			// pJudgeB
			// 
			this.pJudgeB.Controls.Add(this.cmbJudgeColor);
			this.pJudgeB.Controls.Add(this.lblJudgeColor);
			this.pJudgeB.Controls.Add(this.chkJudgeRange);
			this.pJudgeB.Location = new System.Drawing.Point(328, 38);
			this.pJudgeB.Margin = new System.Windows.Forms.Padding(4);
			this.pJudgeB.Name = "pJudgeB";
			this.pJudgeB.Size = new System.Drawing.Size(341, 30);
			this.pJudgeB.TabIndex = 23;
			// 
			// pJudgeA
			// 
			this.pJudgeA.Controls.Add(this.lblJudgeTitle);
			this.pJudgeA.Controls.Add(this.chkJudgeData);
			this.pJudgeA.Controls.Add(this.chkJudgeAve);
			this.pJudgeA.Location = new System.Drawing.Point(16, 38);
			this.pJudgeA.Margin = new System.Windows.Forms.Padding(4);
			this.pJudgeA.Name = "pJudgeA";
			this.pJudgeA.Size = new System.Drawing.Size(243, 30);
			this.pJudgeA.TabIndex = 24;
			// 
			// pReferenceA
			// 
			this.pReferenceA.Controls.Add(this.lblReferenceTitle);
			this.pReferenceA.Controls.Add(this.chkReferenceData);
			this.pReferenceA.Controls.Add(this.chkReferenceAve);
			this.pReferenceA.Controls.Add(this.chkR2);
			this.pReferenceA.Location = new System.Drawing.Point(16, 294);
			this.pReferenceA.Margin = new System.Windows.Forms.Padding(4);
			this.pReferenceA.Name = "pReferenceA";
			this.pReferenceA.Size = new System.Drawing.Size(347, 30);
			this.pReferenceA.TabIndex = 25;
			// 
			// pReferenceB
			// 
			this.pReferenceB.Controls.Add(this.chkReferenceRange);
			this.pReferenceB.Controls.Add(this.lblReferenceColor);
			this.pReferenceB.Controls.Add(this.cmbReferenceColor);
			this.pReferenceB.Location = new System.Drawing.Point(371, 292);
			this.pReferenceB.Margin = new System.Windows.Forms.Padding(4);
			this.pReferenceB.Name = "pReferenceB";
			this.pReferenceB.Size = new System.Drawing.Size(345, 30);
			this.pReferenceB.TabIndex = 26;
			// 
			// RangeCompare
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(724, 666);
			this.ContextMenuStrip = this.SubMenu;
			this.Controls.Add(this.pReferenceB);
			this.Controls.Add(this.pReferenceA);
			this.Controls.Add(this.pJudgeA);
			this.Controls.Add(this.pJudgeB);
			this.Controls.Add(this.lblPreView);
			this.Controls.Add(this.lblComment);
			this.Controls.Add(this.dgvJudge);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.dgvReference);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(739, 291);
			this.Name = "RangeCompare";
			this.Text = "個人内変動比較";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RangeCompareFormClosing);
			this.Load += new System.EventHandler(this.RangeCompareLoad);
			this.Shown += new System.EventHandler(this.RangeCompareShown);
			this.SizeChanged += new System.EventHandler(this.RangeCompareSizeChanged);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.GraphImage)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.SubMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvReference)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvJudge)).EndInit();
			this.pJudgeB.ResumeLayout(false);
			this.pJudgeA.ResumeLayout(false);
			this.pReferenceA.ResumeLayout(false);
			this.pReferenceB.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripButton btnSaveAs;
		private System.Windows.Forms.Panel pJudgeB;
		private System.Windows.Forms.Panel pJudgeA;
		private System.Windows.Forms.Panel pReferenceA;
		private System.Windows.Forms.Panel pReferenceB;
		private System.Windows.Forms.CheckBox chkReferenceData;
		private System.Windows.Forms.CheckBox chkJudgeData;
		private System.Windows.Forms.CheckBox chkReferenceAve;
		private System.Windows.Forms.CheckBox chkJudgeAve;
		private System.Windows.Forms.CheckBox chkR2;
		private System.Windows.Forms.Label lblReferenceTitle;
		private System.Windows.Forms.Label lblJudgeTitle;
		private System.Windows.Forms.Label lblJudgeColor;
		private System.Windows.Forms.Label lblReferenceColor;
		private System.Windows.Forms.Label lblComment;
		private System.Windows.Forms.Label lblPreView;
		private System.Windows.Forms.ComboBox cmbReferenceColor;
		private System.Windows.Forms.ComboBox cmbJudgeColor;
		private System.Windows.Forms.CheckBox chkReferenceRange;
		private System.Windows.Forms.CheckBox chkJudgeRange;
		private System.Windows.Forms.DataGridView dgvJudge;
		private System.Windows.Forms.ToolStripButton btnGraph;
		private System.Windows.Forms.DataGridView dgvReference;
		private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
		private System.Windows.Forms.ToolStripMenuItem menuDelete;
		private System.Windows.Forms.PrintDialog printDialog;
		private System.Windows.Forms.PageSetupDialog pageSetupDialog;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
		private System.Drawing.Printing.PrintDocument printDocument;
		private System.Windows.Forms.ToolStripButton btnImageSave;
		private System.Windows.Forms.SaveFileDialog saveImageFileDialog;
		private System.Windows.Forms.TextBox txtComment;
		private System.Windows.Forms.ToolStripMenuItem menuClose;
		private System.Windows.Forms.ToolStripMenuItem menuPageSetup;
		private System.Windows.Forms.ToolStripMenuItem menuPrint;
		private System.Windows.Forms.ToolStripMenuItem menuPrintPreview;
		private System.Windows.Forms.ToolStripMenuItem menuListCopy;
		private System.Windows.Forms.ToolStripMenuItem menuGraphCopy;
		private System.Windows.Forms.ToolStripMenuItem menuImageSave;
		private System.Windows.Forms.ToolStripMenuItem menuSave;
		private System.Windows.Forms.ToolStripMenuItem menuOpen;
		private System.Windows.Forms.ToolStripMenuItem menuRedo;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem menuUndo;
		private System.Windows.Forms.ContextMenuStrip SubMenu;
		private System.Windows.Forms.OpenFileDialog openFileDlg;
		private System.Windows.Forms.SaveFileDialog saveFileDlg;
		private System.Windows.Forms.ToolStripButton btnPrint;
		private System.Windows.Forms.ToolStripButton btnPrintPreview;
		private System.Windows.Forms.ToolStripButton btnTableCopy;
		private System.Windows.Forms.ToolStripButton btnGraphCopy;
		private System.Windows.Forms.ToolStripButton btnRedo;
		private System.Windows.Forms.ToolStripButton btnUndo;
		private System.Windows.Forms.ToolStripButton btnSave;
		private System.Windows.Forms.ToolStripButton btnOpen;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.PictureBox GraphImage;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStripMenuItem CopyWindowMenuItem;
		private System.Windows.Forms.ToolStripButton BtnCopyWindow;
	}
}
