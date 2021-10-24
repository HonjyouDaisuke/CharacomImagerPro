/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2011/10/17
 * 時刻: 10:42
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
namespace CharacomImagerPro
{
	partial class CharaImageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharaImageForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.subMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.UndoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RedoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataCopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyWindowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAtMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageSaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.PreViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PageSetupMenuIte = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AlignmentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpDownArignMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LRAlignMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OverAlignMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeRightMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeLeftMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.LineCloseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.lblProcess = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblCoord = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.btnCopyTool = new System.Windows.Forms.ToolStripButton();
            this.btnSaveTool = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbZoomTool = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.comboColor = new System.Windows.Forms.ToolStripComboBox();
            this.btnPencil = new System.Windows.Forms.ToolStripButton();
            this.btnProperty = new System.Windows.Forms.ToolStripButton();
            this.btnGraviHou = new System.Windows.Forms.ToolStripButton();
            this.btnGraviJun = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintTool = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.btnRedo = new System.Windows.Forms.ToolStripButton();
            this.btnDataCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.comboGColor = new System.Windows.Forms.ToolStripComboBox();
            this.saveImageDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.saveCCIDialog = new System.Windows.Forms.SaveFileDialog();
            this.openCCIDialog = new System.Windows.Forms.OpenFileDialog();
            this.openImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.dgvFrameData = new System.Windows.Forms.DataGridView();
            this.colColor = new System.Windows.Forms.DataGridViewImageColumn();
            this.colHight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGravi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorImageList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGravity = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCSV = new System.Windows.Forms.Button();
            this.saveCSVDialog = new System.Windows.Forms.SaveFileDialog();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDlg = new System.Windows.Forms.PrintPreviewDialog();
            this.pageSetupDlg = new System.Windows.Forms.PageSetupDialog();
            this.printDlg = new System.Windows.Forms.PrintDialog();
            this.btnCopyWindow = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.subMenu.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFrameData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageBox
            // 
            this.ImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImageBox.ContextMenuStrip = this.subMenu;
            this.ImageBox.Location = new System.Drawing.Point(0, 0);
            this.ImageBox.Margin = new System.Windows.Forms.Padding(4);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(426, 400);
            this.ImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageBox.TabIndex = 0;
            this.ImageBox.TabStop = false;
            this.ImageBox.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageBoxPaint);
            this.ImageBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageBoxMouseDown);
            this.ImageBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageBoxMouseMove);
            this.ImageBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImageBoxMouseUp);
            // 
            // subMenu
            // 
            this.subMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.subMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UndoMenuItem,
            this.RedoMenuItem,
            this.toolStripMenuItem5,
            this.OpenMenuItem,
            this.ImportMenuItem,
            this.CopyMenuItem,
            this.DataCopyMenuItem,
            this.CopyWindowMenuItem,
            this.PasteMenuItem,
            this.CutMenuItem,
            this.toolStripMenuItem1,
            this.SaveMenuItem,
            this.SaveAtMenuItem,
            this.ImageSaveMenuItem,
            this.toolStripMenuItem4,
            this.PreViewMenuItem,
            this.PrintMenuItem,
            this.PageSetupMenuIte,
            this.toolStripMenuItem2,
            this.OpenNewMenuItem,
            this.AlignmentMenuItem,
            this.ZoomMenuItem,
            this.toolStripMenuItem3,
            this.LineCloseMenuItem,
            this.CloseMenuItem});
            this.subMenu.Name = "subMenu";
            this.subMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.subMenu.Size = new System.Drawing.Size(213, 554);
            this.subMenu.Opened += new System.EventHandler(this.SubMenuOpened);
            // 
            // UndoMenuItem
            // 
            this.UndoMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("UndoMenuItem.Image")));
            this.UndoMenuItem.Name = "UndoMenuItem";
            this.UndoMenuItem.Size = new System.Drawing.Size(212, 26);
            this.UndoMenuItem.Text = "元に戻す";
            this.UndoMenuItem.Click += new System.EventHandler(this.UndoMenuItemClick);
            // 
            // RedoMenuItem
            // 
            this.RedoMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RedoMenuItem.Image")));
            this.RedoMenuItem.Name = "RedoMenuItem";
            this.RedoMenuItem.Size = new System.Drawing.Size(212, 26);
            this.RedoMenuItem.Text = "やり直し";
            this.RedoMenuItem.Click += new System.EventHandler(this.RedoMenuItemClick);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(209, 6);
            // 
            // OpenMenuItem
            // 
            this.OpenMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenMenuItem.Image")));
            this.OpenMenuItem.Name = "OpenMenuItem";
            this.OpenMenuItem.Size = new System.Drawing.Size(212, 26);
            this.OpenMenuItem.Text = "開く";
            this.OpenMenuItem.Click += new System.EventHandler(this.OpenMenuItemClick);
            // 
            // ImportMenuItem
            // 
            this.ImportMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ImportMenuItem.Image")));
            this.ImportMenuItem.Name = "ImportMenuItem";
            this.ImportMenuItem.Size = new System.Drawing.Size(212, 26);
            this.ImportMenuItem.Text = "画像データのインポート";
            this.ImportMenuItem.Click += new System.EventHandler(this.ImportMenuItemClick);
            // 
            // CopyMenuItem
            // 
            this.CopyMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CopyMenuItem.Image")));
            this.CopyMenuItem.Name = "CopyMenuItem";
            this.CopyMenuItem.Size = new System.Drawing.Size(212, 26);
            this.CopyMenuItem.Text = "コピー";
            this.CopyMenuItem.Click += new System.EventHandler(this.CopyMenuItemClick);
            // 
            // DataCopyMenuItem
            // 
            this.DataCopyMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DataCopyMenuItem.Image")));
            this.DataCopyMenuItem.Name = "DataCopyMenuItem";
            this.DataCopyMenuItem.Size = new System.Drawing.Size(212, 26);
            this.DataCopyMenuItem.Text = "画像とデータをコピー";
            this.DataCopyMenuItem.Click += new System.EventHandler(this.DataCopyMenuItemClick);
            // 
            // CopyWindowMenuItem
            // 
            this.CopyWindowMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CopyWindowMenuItem.Image")));
            this.CopyWindowMenuItem.Name = "CopyWindowMenuItem";
            this.CopyWindowMenuItem.Size = new System.Drawing.Size(212, 26);
            this.CopyWindowMenuItem.Text = "ウィンドウをコピー";
            this.CopyWindowMenuItem.Click += new System.EventHandler(this.CopyWindowMenuItemClick);
            // 
            // PasteMenuItem
            // 
            this.PasteMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("PasteMenuItem.Image")));
            this.PasteMenuItem.Name = "PasteMenuItem";
            this.PasteMenuItem.Size = new System.Drawing.Size(212, 26);
            this.PasteMenuItem.Text = "貼り付け";
            this.PasteMenuItem.Click += new System.EventHandler(this.PasteMenuItemClick);
            // 
            // CutMenuItem
            // 
            this.CutMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CutMenuItem.Image")));
            this.CutMenuItem.Name = "CutMenuItem";
            this.CutMenuItem.Size = new System.Drawing.Size(212, 26);
            this.CutMenuItem.Text = "矩形の切り取り";
            this.CutMenuItem.Click += new System.EventHandler(this.CutMenuItemClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(209, 6);
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SaveMenuItem.Image")));
            this.SaveMenuItem.Name = "SaveMenuItem";
            this.SaveMenuItem.Size = new System.Drawing.Size(212, 26);
            this.SaveMenuItem.Text = "上書き保存";
            this.SaveMenuItem.Click += new System.EventHandler(this.SaveMenuItemClick);
            // 
            // SaveAtMenuItem
            // 
            this.SaveAtMenuItem.Name = "SaveAtMenuItem";
            this.SaveAtMenuItem.Size = new System.Drawing.Size(212, 26);
            this.SaveAtMenuItem.Text = "名前をつけて保存";
            this.SaveAtMenuItem.Click += new System.EventHandler(this.SaveAtMenuItemClick);
            // 
            // ImageSaveMenuItem
            // 
            this.ImageSaveMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ImageSaveMenuItem.Image")));
            this.ImageSaveMenuItem.Name = "ImageSaveMenuItem";
            this.ImageSaveMenuItem.Size = new System.Drawing.Size(212, 26);
            this.ImageSaveMenuItem.Text = "画像として保存";
            this.ImageSaveMenuItem.Click += new System.EventHandler(this.ImageSaveMenuItemClick);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(209, 6);
            // 
            // PreViewMenuItem
            // 
            this.PreViewMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("PreViewMenuItem.Image")));
            this.PreViewMenuItem.Name = "PreViewMenuItem";
            this.PreViewMenuItem.Size = new System.Drawing.Size(212, 26);
            this.PreViewMenuItem.Text = "印刷プレビュー";
            this.PreViewMenuItem.Click += new System.EventHandler(this.PreViewMenuItemClick);
            // 
            // PrintMenuItem
            // 
            this.PrintMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("PrintMenuItem.Image")));
            this.PrintMenuItem.Name = "PrintMenuItem";
            this.PrintMenuItem.Size = new System.Drawing.Size(212, 26);
            this.PrintMenuItem.Text = "印刷";
            this.PrintMenuItem.Click += new System.EventHandler(this.PrintMenuItemClick);
            // 
            // PageSetupMenuIte
            // 
            this.PageSetupMenuIte.Image = ((System.Drawing.Image)(resources.GetObject("PageSetupMenuIte.Image")));
            this.PageSetupMenuIte.Name = "PageSetupMenuIte";
            this.PageSetupMenuIte.Size = new System.Drawing.Size(212, 26);
            this.PageSetupMenuIte.Text = "ページ設定";
            this.PageSetupMenuIte.Click += new System.EventHandler(this.PageSetupMenuIteClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(209, 6);
            // 
            // OpenNewMenuItem
            // 
            this.OpenNewMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenNewMenuItem.Image")));
            this.OpenNewMenuItem.Name = "OpenNewMenuItem";
            this.OpenNewMenuItem.Size = new System.Drawing.Size(212, 26);
            this.OpenNewMenuItem.Text = "新しいウィンドウを開く";
            this.OpenNewMenuItem.Click += new System.EventHandler(this.OpenNewMenuItemClick);
            // 
            // AlignmentMenuItem
            // 
            this.AlignmentMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpDownArignMenuItem,
            this.LRAlignMenuItem,
            this.OverAlignMenuItem,
            this.ChangeRightMenuItem,
            this.ChangeLeftMenuItem});
            this.AlignmentMenuItem.Name = "AlignmentMenuItem";
            this.AlignmentMenuItem.Size = new System.Drawing.Size(212, 26);
            this.AlignmentMenuItem.Text = "整列";
            // 
            // UpDownArignMenuItem
            // 
            this.UpDownArignMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("UpDownArignMenuItem.Image")));
            this.UpDownArignMenuItem.Name = "UpDownArignMenuItem";
            this.UpDownArignMenuItem.Size = new System.Drawing.Size(255, 26);
            this.UpDownArignMenuItem.Text = "上下に並べて表示";
            this.UpDownArignMenuItem.Click += new System.EventHandler(this.UpDownArignMenuItemClick);
            // 
            // LRAlignMenuItem
            // 
            this.LRAlignMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("LRAlignMenuItem.Image")));
            this.LRAlignMenuItem.Name = "LRAlignMenuItem";
            this.LRAlignMenuItem.Size = new System.Drawing.Size(255, 26);
            this.LRAlignMenuItem.Text = "左右に並べて表示";
            this.LRAlignMenuItem.Click += new System.EventHandler(this.LRAlignMenuItemClick);
            // 
            // OverAlignMenuItem
            // 
            this.OverAlignMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OverAlignMenuItem.Image")));
            this.OverAlignMenuItem.Name = "OverAlignMenuItem";
            this.OverAlignMenuItem.Size = new System.Drawing.Size(255, 26);
            this.OverAlignMenuItem.Text = "重ねて表示";
            this.OverAlignMenuItem.Click += new System.EventHandler(this.OverAlignMenuItemClick);
            // 
            // ChangeRightMenuItem
            // 
            this.ChangeRightMenuItem.Name = "ChangeRightMenuItem";
            this.ChangeRightMenuItem.Size = new System.Drawing.Size(255, 26);
            this.ChangeRightMenuItem.Text = "右列のウインドウと入れ替え";
            this.ChangeRightMenuItem.Click += new System.EventHandler(this.ChangeRightMenuItemClick);
            // 
            // ChangeLeftMenuItem
            // 
            this.ChangeLeftMenuItem.Name = "ChangeLeftMenuItem";
            this.ChangeLeftMenuItem.Size = new System.Drawing.Size(255, 26);
            this.ChangeLeftMenuItem.Text = "左列のウインドウと入れ替え";
            this.ChangeLeftMenuItem.Click += new System.EventHandler(this.ChangeLeftMenuItemClick);
            // 
            // ZoomMenuItem
            // 
            this.ZoomMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ZoomMenuItem.Image")));
            this.ZoomMenuItem.Name = "ZoomMenuItem";
            this.ZoomMenuItem.Size = new System.Drawing.Size(212, 26);
            this.ZoomMenuItem.Text = "ズーム";
            this.ZoomMenuItem.Click += new System.EventHandler(this.ZoomMenuItemClick);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(209, 6);
            // 
            // LineCloseMenuItem
            // 
            this.LineCloseMenuItem.Name = "LineCloseMenuItem";
            this.LineCloseMenuItem.Size = new System.Drawing.Size(212, 26);
            this.LineCloseMenuItem.Text = "一列閉じる";
            this.LineCloseMenuItem.Click += new System.EventHandler(this.LineCloseMenuItemClick);
            // 
            // CloseMenuItem
            // 
            this.CloseMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CloseMenuItem.Image")));
            this.CloseMenuItem.Name = "CloseMenuItem";
            this.CloseMenuItem.Size = new System.Drawing.Size(212, 26);
            this.CloseMenuItem.Text = "閉じる";
            this.CloseMenuItem.Click += new System.EventHandler(this.CloseMenuItemClick);
            // 
            // StatusBar
            // 
            this.StatusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblProcess,
            this.toolSeparator2,
            this.lblCoord});
            this.StatusBar.Location = new System.Drawing.Point(0, 439);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.StatusBar.Size = new System.Drawing.Size(884, 26);
            this.StatusBar.TabIndex = 1;
            this.StatusBar.Text = "statusStrip1";
            // 
            // lblProcess
            // 
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(39, 20);
            this.lblProcess.Text = "標準";
            // 
            // toolSeparator2
            // 
            this.toolSeparator2.Name = "toolSeparator2";
            this.toolSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // lblCoord
            // 
            this.lblCoord.Name = "lblCoord";
            this.lblCoord.Size = new System.Drawing.Size(38, 20);
            this.lblCoord.Text = "(0,0)";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.ImageBox);
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 400);
            this.panel1.TabIndex = 2;
            // 
            // toolSeparator3
            // 
            this.toolSeparator3.Name = "toolSeparator3";
            this.toolSeparator3.Size = new System.Drawing.Size(6, 6);
            // 
            // ToolBar
            // 
            this.ToolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCopyTool,
            this.btnCopyWindow,
            this.btnSaveTool,
            this.toolStripSeparator2,
            this.cmbZoomTool,
            this.toolStripSeparator3,
            this.comboColor,
            this.btnPencil,
            this.btnProperty,
            this.btnGraviHou,
            this.btnGraviJun,
            this.toolStripSeparator1,
            this.btnPrintTool,
            this.toolStripSeparator4,
            this.btnUndo,
            this.btnRedo,
            this.btnDataCopy,
            this.toolStripSeparator5,
            this.toolStripLabel1,
            this.comboGColor});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Size = new System.Drawing.Size(884, 28);
            this.ToolBar.TabIndex = 3;
            this.ToolBar.Text = "toolStrip1";
            // 
            // btnCopyTool
            // 
            this.btnCopyTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopyTool.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyTool.Image")));
            this.btnCopyTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyTool.Name = "btnCopyTool";
            this.btnCopyTool.Size = new System.Drawing.Size(29, 25);
            this.btnCopyTool.Text = "toolStripButton1";
            this.btnCopyTool.ToolTipText = "コピー";
            this.btnCopyTool.Click += new System.EventHandler(this.BtnCopyToolClick);
            // 
            // btnSaveTool
            // 
            this.btnSaveTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveTool.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveTool.Image")));
            this.btnSaveTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveTool.Name = "btnSaveTool";
            this.btnSaveTool.Size = new System.Drawing.Size(29, 25);
            this.btnSaveTool.Text = "toolStripButton1";
            this.btnSaveTool.ToolTipText = "上書き保存";
            this.btnSaveTool.Click += new System.EventHandler(this.BtnSaveToolClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // cmbZoomTool
            // 
            this.cmbZoomTool.Items.AddRange(new object[] {
            "400%",
            "300%",
            "200%",
            "150%",
            "100%",
            "50%"});
            this.cmbZoomTool.Name = "cmbZoomTool";
            this.cmbZoomTool.Size = new System.Drawing.Size(99, 28);
            this.cmbZoomTool.ToolTipText = "倍率";
            this.cmbZoomTool.SelectedIndexChanged += new System.EventHandler(this.CmbZoomToolSelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // comboColor
            // 
            this.comboColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboColor.Name = "comboColor";
            this.comboColor.Size = new System.Drawing.Size(132, 28);
            this.comboColor.SelectedIndexChanged += new System.EventHandler(this.ComboColorSelectedIndexChanged);
            // 
            // btnPencil
            // 
            this.btnPencil.CheckOnClick = true;
            this.btnPencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPencil.Image = ((System.Drawing.Image)(resources.GetObject("btnPencil.Image")));
            this.btnPencil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPencil.Name = "btnPencil";
            this.btnPencil.Size = new System.Drawing.Size(29, 25);
            this.btnPencil.Text = "toolStripButton2";
            this.btnPencil.ToolTipText = "切り出し";
            // 
            // btnProperty
            // 
            this.btnProperty.CheckOnClick = true;
            this.btnProperty.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnProperty.Image = ((System.Drawing.Image)(resources.GetObject("btnProperty.Image")));
            this.btnProperty.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProperty.Name = "btnProperty";
            this.btnProperty.Size = new System.Drawing.Size(29, 25);
            this.btnProperty.Text = "詳細データ";
            this.btnProperty.CheckedChanged += new System.EventHandler(this.BtnPropertyCheckedChanged);
            // 
            // btnGraviHou
            // 
            this.btnGraviHou.Checked = true;
            this.btnGraviHou.CheckOnClick = true;
            this.btnGraviHou.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnGraviHou.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGraviHou.Image = ((System.Drawing.Image)(resources.GetObject("btnGraviHou.Image")));
            this.btnGraviHou.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGraviHou.Name = "btnGraviHou";
            this.btnGraviHou.Size = new System.Drawing.Size(29, 25);
            this.btnGraviHou.Text = "重心線(放射状)";
            this.btnGraviHou.CheckedChanged += new System.EventHandler(this.BtnGraviHouCheckedChanged);
            // 
            // btnGraviJun
            // 
            this.btnGraviJun.CheckOnClick = true;
            this.btnGraviJun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGraviJun.Image = ((System.Drawing.Image)(resources.GetObject("btnGraviJun.Image")));
            this.btnGraviJun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGraviJun.Name = "btnGraviJun";
            this.btnGraviJun.Size = new System.Drawing.Size(29, 25);
            this.btnGraviJun.Text = "重心線(連結)";
            this.btnGraviJun.CheckedChanged += new System.EventHandler(this.BtnGraviJunCheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // btnPrintTool
            // 
            this.btnPrintTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrintTool.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintTool.Image")));
            this.btnPrintTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintTool.Name = "btnPrintTool";
            this.btnPrintTool.Size = new System.Drawing.Size(29, 25);
            this.btnPrintTool.Text = "toolStripButton1";
            this.btnPrintTool.ToolTipText = "印刷";
            this.btnPrintTool.Click += new System.EventHandler(this.BtnPrintToolClick);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // btnUndo
            // 
            this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(29, 25);
            this.btnUndo.Text = "toolStripButton2";
            this.btnUndo.ToolTipText = "t元に戻す";
            this.btnUndo.Click += new System.EventHandler(this.BtnUndoClick);
            // 
            // btnRedo
            // 
            this.btnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRedo.Image = ((System.Drawing.Image)(resources.GetObject("btnRedo.Image")));
            this.btnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(29, 25);
            this.btnRedo.Text = "toolStripButton3";
            this.btnRedo.Click += new System.EventHandler(this.BtnRedoClick);
            // 
            // btnDataCopy
            // 
            this.btnDataCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDataCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnDataCopy.Image")));
            this.btnDataCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDataCopy.Name = "btnDataCopy";
            this.btnDataCopy.Size = new System.Drawing.Size(29, 25);
            this.btnDataCopy.Text = "画像とデータをコピー";
            this.btnDataCopy.ToolTipText = "画像とデータをコピー";
            this.btnDataCopy.Click += new System.EventHandler(this.BtnDataCopyClick);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(72, 25);
            this.toolStripLabel1.Text = "重心線色:";
            // 
            // comboGColor
            // 
            this.comboGColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGColor.Name = "comboGColor";
            this.comboGColor.Size = new System.Drawing.Size(132, 28);
            this.comboGColor.SelectedIndexChanged += new System.EventHandler(this.ComboGColorSelectedIndexChanged);
            // 
            // saveImageDialog
            // 
            this.saveImageDialog.Filter = "JPEG(*.jpeg)|*.jpeg|PNG (*.png)|*.png|GIF (*.gif)|*.gif|すべてのファイル|*.*";
            this.saveImageDialog.Title = "名前をつけて保存（画像）";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 23);
            // 
            // saveCCIDialog
            // 
            this.saveCCIDialog.Filter = "Characomデータ(*.cci)|*.cci|すべてのファイル|*.*";
            this.saveCCIDialog.Title = "名前をつけて保存(Characomデータ)";
            // 
            // openCCIDialog
            // 
            this.openCCIDialog.Filter = "Characomデータ(*.cci)|*.cci|すべてのファイル|*.*";
            this.openCCIDialog.Title = "ファイルを開く(Characomデータ)";
            // 
            // openImageDialog
            // 
            this.openImageDialog.Filter = "JPEG(*.jpeg)|*.jpeg;*.jpg|PNG (*.png)|*.png|GIF (*.gif)|*.gif|すべてのファイル|*.*";
            this.openImageDialog.Title = "ファイルを開く(画像)";
            // 
            // dgvFrameData
            // 
            this.dgvFrameData.AllowUserToAddRows = false;
            this.dgvFrameData.AllowUserToDeleteRows = false;
            this.dgvFrameData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFrameData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colColor,
            this.colHight,
            this.colWidth,
            this.colArea,
            this.colGravi,
            this.colDist});
            this.dgvFrameData.Location = new System.Drawing.Point(435, 128);
            this.dgvFrameData.Margin = new System.Windows.Forms.Padding(4);
            this.dgvFrameData.Name = "dgvFrameData";
            this.dgvFrameData.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFrameData.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFrameData.RowHeadersVisible = false;
            this.dgvFrameData.RowHeadersWidth = 51;
            this.dgvFrameData.RowTemplate.Height = 21;
            this.dgvFrameData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFrameData.Size = new System.Drawing.Size(447, 270);
            this.dgvFrameData.TabIndex = 5;
            this.dgvFrameData.SelectionChanged += new System.EventHandler(this.DgvFrameDataSelectionChanged);
            // 
            // colColor
            // 
            this.colColor.HeaderText = "色";
            this.colColor.MinimumWidth = 6;
            this.colColor.Name = "colColor";
            this.colColor.ReadOnly = true;
            this.colColor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colColor.Width = 40;
            // 
            // colHight
            // 
            this.colHight.HeaderText = "高さ";
            this.colHight.MinimumWidth = 6;
            this.colHight.Name = "colHight";
            this.colHight.ReadOnly = true;
            this.colHight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colHight.Width = 40;
            // 
            // colWidth
            // 
            this.colWidth.HeaderText = "幅";
            this.colWidth.MinimumWidth = 6;
            this.colWidth.Name = "colWidth";
            this.colWidth.ReadOnly = true;
            this.colWidth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colWidth.Width = 40;
            // 
            // colArea
            // 
            this.colArea.HeaderText = "面積";
            this.colArea.MinimumWidth = 6;
            this.colArea.Name = "colArea";
            this.colArea.ReadOnly = true;
            this.colArea.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colArea.Width = 60;
            // 
            // colGravi
            // 
            this.colGravi.HeaderText = "重心";
            this.colGravi.MinimumWidth = 6;
            this.colGravi.Name = "colGravi";
            this.colGravi.ReadOnly = true;
            this.colGravi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colGravi.Width = 60;
            // 
            // colDist
            // 
            this.colDist.HeaderText = "重心の距離";
            this.colDist.MinimumWidth = 6;
            this.colDist.Name = "colDist";
            this.colDist.ReadOnly = true;
            this.colDist.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDist.Width = 90;
            // 
            // colorImageList
            // 
            this.colorImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("colorImageList.ImageStream")));
            this.colorImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.colorImageList.Images.SetKeyName(0, "blue.png");
            this.colorImageList.Images.SetKeyName(1, "green.png");
            this.colorImageList.Images.SetKeyName(2, "red.png");
            this.colorImageList.Images.SetKeyName(3, "yellow.png");
            this.colorImageList.Images.SetKeyName(4, "purple.png");
            this.colorImageList.Images.SetKeyName(5, "orange.png");
            this.colorImageList.Images.SetKeyName(6, "skyblue.png");
            this.colorImageList.Images.SetKeyName(7, "pink.png");
            this.colorImageList.Images.SetKeyName(8, "brown.png");
            this.colorImageList.Images.SetKeyName(9, "gray.png");
            this.colorImageList.Images.SetKeyName(10, "black.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGravity);
            this.groupBox1.Controls.Add(this.txtArea);
            this.groupBox1.Controls.Add(this.txtWidth);
            this.groupBox1.Controls.Add(this.txtHeight);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(435, 36);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(447, 84);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "全体の隣接矩形";
            // 
            // txtGravity
            // 
            this.txtGravity.Location = new System.Drawing.Point(281, 50);
            this.txtGravity.Margin = new System.Windows.Forms.Padding(4);
            this.txtGravity.Name = "txtGravity";
            this.txtGravity.ReadOnly = true;
            this.txtGravity.Size = new System.Drawing.Size(145, 22);
            this.txtGravity.TabIndex = 7;
            this.txtGravity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(281, 21);
            this.txtArea.Margin = new System.Windows.Forms.Padding(4);
            this.txtArea.Name = "txtArea";
            this.txtArea.ReadOnly = true;
            this.txtArea.Size = new System.Drawing.Size(145, 22);
            this.txtArea.TabIndex = 6;
            this.txtArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(68, 49);
            this.txtWidth.Margin = new System.Windows.Forms.Padding(4);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ReadOnly = true;
            this.txtWidth.Size = new System.Drawing.Size(148, 22);
            this.txtWidth.TabIndex = 5;
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(68, 22);
            this.txtHeight.Margin = new System.Windows.Forms.Padding(4);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ReadOnly = true;
            this.txtHeight.Size = new System.Drawing.Size(148, 22);
            this.txtHeight.TabIndex = 4;
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(239, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "重心";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(239, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "面積";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(23, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "幅";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "高さ";
            // 
            // btnCSV
            // 
            this.btnCSV.Location = new System.Drawing.Point(781, 405);
            this.btnCSV.Margin = new System.Windows.Forms.Padding(4);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(100, 29);
            this.btnCSV.TabIndex = 7;
            this.btnCSV.Text = "エクスポート";
            this.btnCSV.UseVisualStyleBackColor = true;
            this.btnCSV.Click += new System.EventHandler(this.BtnCSVClick);
            // 
            // saveCSVDialog
            // 
            this.saveCSVDialog.Filter = "CSV(カンマ区切り)(*.csv)|*.csv|テキスト(タブ区切り)(*.txt)|*.txt|すべてのファイル|*.*";
            this.saveCSVDialog.Title = "データをエクスポート";
            // 
            // printDoc
            // 
            this.printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocPrintPage);
            // 
            // printPreviewDlg
            // 
            this.printPreviewDlg.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDlg.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDlg.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDlg.Document = this.printDoc;
            this.printPreviewDlg.Enabled = true;
            this.printPreviewDlg.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDlg.Icon")));
            this.printPreviewDlg.Name = "printPreviewDlg";
            this.printPreviewDlg.Visible = false;
            // 
            // pageSetupDlg
            // 
            this.pageSetupDlg.Document = this.printDoc;
            // 
            // printDlg
            // 
            this.printDlg.Document = this.printDoc;
            this.printDlg.UseEXDialog = true;
            // 
            // btnCopyWindow
            // 
            this.btnCopyWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopyWindow.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyWindow.Image")));
            this.btnCopyWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyWindow.Name = "btnCopyWindow";
            this.btnCopyWindow.Size = new System.Drawing.Size(29, 25);
            this.btnCopyWindow.Text = "ウィンドウをコピー";
            this.btnCopyWindow.Click += new System.EventHandler(this.CopyWindowMenuItemClick);
            // 
            // CharaImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 465);
            this.Controls.Add(this.btnCSV);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ToolBar);
            this.Controls.Add(this.dgvFrameData);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CharaImageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CharaImageForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CharaImageFormFormClosing);
            this.Load += new System.EventHandler(this.CharaImageFormLoad);
            this.Shown += new System.EventHandler(this.CharaImageFormShown);
            this.Resize += new System.EventHandler(this.CharaImageFormResize);
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.subMenu.ResumeLayout(false);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFrameData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripMenuItem ChangeLeftMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ChangeRightMenuItem;
		private System.Windows.Forms.ToolStripMenuItem LineCloseMenuItem;
		private System.Windows.Forms.ToolStripComboBox comboGColor;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton btnDataCopy;
		private System.Windows.Forms.ToolStripMenuItem DataCopyMenuItem;
		private System.Windows.Forms.ToolStripButton btnRedo;
		private System.Windows.Forms.ToolStripButton btnUndo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem RedoMenuItem;
		private System.Windows.Forms.ToolStripMenuItem UndoMenuItem;
		private System.Windows.Forms.ToolStripButton btnGraviJun;
		private System.Windows.Forms.ToolStripButton btnGraviHou;
		private System.Windows.Forms.PrintDialog printDlg;
		private System.Windows.Forms.PageSetupDialog pageSetupDlg;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDlg;
		private System.Drawing.Printing.PrintDocument printDoc;
		private System.Windows.Forms.ToolStripMenuItem CutMenuItem;
		private System.Windows.Forms.SaveFileDialog saveCSVDialog;
		private System.Windows.Forms.Button btnCSV;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDist;
		private System.Windows.Forms.TextBox txtGravity;
		private System.Windows.Forms.TextBox txtArea;
		private System.Windows.Forms.TextBox txtWidth;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtHeight;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ImageList colorImageList;
		private System.Windows.Forms.DataGridViewTextBoxColumn colGravi;
		private System.Windows.Forms.DataGridViewTextBoxColumn colArea;
		private System.Windows.Forms.DataGridViewTextBoxColumn colWidth;
		private System.Windows.Forms.DataGridViewTextBoxColumn colHight;
		private System.Windows.Forms.DataGridViewImageColumn colColor;
		private System.Windows.Forms.DataGridView dgvFrameData;
		private System.Windows.Forms.OpenFileDialog openImageDialog;
		private System.Windows.Forms.ToolStripMenuItem ImportMenuItem;
		private System.Windows.Forms.OpenFileDialog openCCIDialog;
		private System.Windows.Forms.SaveFileDialog saveCCIDialog;
		private System.Windows.Forms.ToolStripMenuItem OpenMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem ImageSaveMenuItem;
		private System.Windows.Forms.ToolStripMenuItem SaveMenuItem;
		private System.Windows.Forms.ToolStripButton btnProperty;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripButton btnPencil;
		private System.Windows.Forms.ToolStripComboBox comboColor;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.SaveFileDialog saveImageDialog;
		private System.Windows.Forms.ToolStripComboBox cmbZoomTool;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnPrintTool;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnSaveTool;
		private System.Windows.Forms.ToolStripButton btnCopyTool;
		private System.Windows.Forms.ToolStrip ToolBar;
		private System.Windows.Forms.ToolStripStatusLabel lblProcess;
		private System.Windows.Forms.ToolStripStatusLabel lblCoord;
		private System.Windows.Forms.ToolStripSeparator toolSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolSeparator3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem ZoomMenuItem;
		private System.Windows.Forms.ToolStripMenuItem OverAlignMenuItem;
		private System.Windows.Forms.ToolStripMenuItem LRAlignMenuItem;
		private System.Windows.Forms.ToolStripMenuItem UpDownArignMenuItem;
		private System.Windows.Forms.ToolStripMenuItem AlignmentMenuItem;
		private System.Windows.Forms.ToolStripMenuItem OpenNewMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem PageSetupMenuIte;
		private System.Windows.Forms.ToolStripMenuItem PrintMenuItem;
		private System.Windows.Forms.ToolStripMenuItem PreViewMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem CloseMenuItem;
		private System.Windows.Forms.ToolStripMenuItem SaveAtMenuItem;
		private System.Windows.Forms.ToolStripMenuItem PasteMenuItem;
		private System.Windows.Forms.ToolStripMenuItem CopyMenuItem;
		private System.Windows.Forms.ContextMenuStrip subMenu;
		private System.Windows.Forms.StatusStrip StatusBar;
		public System.Windows.Forms.PictureBox ImageBox;
		private System.Windows.Forms.ToolStripMenuItem CopyWindowMenuItem;
        private System.Windows.Forms.ToolStripButton btnCopyWindow;
    }
}
