/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2013/02/10
 * 時刻: 16:46
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
namespace CharacomImagerPro
{
	partial class StringLapForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StringLapForm));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnFileOpen = new System.Windows.Forms.ToolStripButton();
			this.btnFileSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.btnCopy = new System.Windows.Forms.ToolStripButton();
			this.btnSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnUndo = new System.Windows.Forms.ToolStripButton();
			this.btnRedo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.btnPreview = new System.Windows.Forms.ToolStripButton();
			this.btnPrint = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnZoom = new System.Windows.Forms.ToolStripButton();
			this.comboZoom = new System.Windows.Forms.ToolStripComboBox();
			this.btnDrawFrame = new System.Windows.Forms.ToolStripButton();
			this.btnChara = new System.Windows.Forms.ToolStripButton();
			this.btnGraviHou = new System.Windows.Forms.ToolStripButton();
			this.btnGraviJun = new System.Windows.Forms.ToolStripButton();
			this.btnSyaei = new System.Windows.Forms.ToolStripButton();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnDown = new System.Windows.Forms.Button();
			this.btnUp = new System.Windows.Forms.Button();
			this.dgvLap = new System.Windows.Forms.DataGridView();
			this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
			this.colFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel1 = new System.Windows.Forms.Panel();
			this.LapImageBox = new System.Windows.Forms.PictureBox();
			this.SubMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSaveImage = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuUndo = new System.Windows.Forms.ToolStripMenuItem();
			this.menuRedo = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.menuPreview = new System.Windows.Forms.ToolStripMenuItem();
			this.menuPrint = new System.Windows.Forms.ToolStripMenuItem();
			this.menuPageSetup = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.menuZoom = new System.Windows.Forms.ToolStripMenuItem();
			this.menuNewWindow = new System.Windows.Forms.ToolStripMenuItem();
			this.menuLayout = new System.Windows.Forms.ToolStripMenuItem();
			this.menuUpDownAlign = new System.Windows.Forms.ToolStripMenuItem();
			this.menuLRAlign = new System.Windows.Forms.ToolStripMenuItem();
			this.menuOverAlign = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
			this.saveImageDialog = new System.Windows.Forms.SaveFileDialog();
			this.saveFileDlg = new System.Windows.Forms.SaveFileDialog();
			this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
			this.printDoc = new System.Drawing.Printing.PrintDocument();
			this.pageSetupDlg = new System.Windows.Forms.PageSetupDialog();
			this.printPreviewDlg = new System.Windows.Forms.PrintPreviewDialog();
			this.printDlg = new System.Windows.Forms.PrintDialog();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvLap)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LapImageBox)).BeginInit();
			this.SubMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.btnFileOpen,
									this.btnFileSave,
									this.toolStripSeparator4,
									this.btnCopy,
									this.btnSave,
									this.toolStripSeparator1,
									this.btnUndo,
									this.btnRedo,
									this.toolStripSeparator3,
									this.btnPreview,
									this.btnPrint,
									this.toolStripSeparator2,
									this.btnZoom,
									this.comboZoom,
									this.btnDrawFrame,
									this.btnChara,
									this.btnGraviHou,
									this.btnGraviJun,
									this.btnSyaei});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1285, 26);
			this.toolStrip1.TabIndex = 3;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnFileOpen
			// 
			this.btnFileOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnFileOpen.Image")));
			this.btnFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnFileOpen.Name = "btnFileOpen";
			this.btnFileOpen.Size = new System.Drawing.Size(23, 23);
			this.btnFileOpen.Text = "開く";
			this.btnFileOpen.Click += new System.EventHandler(this.BtnFileOpenClick);
			// 
			// btnFileSave
			// 
			this.btnFileSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnFileSave.Image = ((System.Drawing.Image)(resources.GetObject("btnFileSave.Image")));
			this.btnFileSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnFileSave.Name = "btnFileSave";
			this.btnFileSave.Size = new System.Drawing.Size(23, 23);
			this.btnFileSave.Text = "保存";
			this.btnFileSave.Click += new System.EventHandler(this.BtnFileSaveClick);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 26);
			// 
			// btnCopy
			// 
			this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
			this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(23, 23);
			this.btnCopy.Text = "toolStripButton1";
			this.btnCopy.ToolTipText = "コピー";
			this.btnCopy.Click += new System.EventHandler(this.BtnCopyClick);
			// 
			// btnSave
			// 
			this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
			this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(23, 23);
			this.btnSave.Text = "toolStripButton2";
			this.btnSave.ToolTipText = "画像として保存";
			this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
			// 
			// btnUndo
			// 
			this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
			this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnUndo.Name = "btnUndo";
			this.btnUndo.Size = new System.Drawing.Size(23, 23);
			this.btnUndo.Text = "toolStripButton1";
			this.btnUndo.ToolTipText = "元に戻す";
			this.btnUndo.Click += new System.EventHandler(this.BtnUndoClick);
			// 
			// btnRedo
			// 
			this.btnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnRedo.Image = ((System.Drawing.Image)(resources.GetObject("btnRedo.Image")));
			this.btnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRedo.Name = "btnRedo";
			this.btnRedo.Size = new System.Drawing.Size(23, 23);
			this.btnRedo.Text = "toolStripButton2";
			this.btnRedo.ToolTipText = "やり直し";
			this.btnRedo.Click += new System.EventHandler(this.BtnRedoClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
			// 
			// btnPreview
			// 
			this.btnPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
			this.btnPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPreview.Name = "btnPreview";
			this.btnPreview.Size = new System.Drawing.Size(23, 23);
			this.btnPreview.Text = "toolStripButton3";
			this.btnPreview.ToolTipText = "印刷プレビュー";
			this.btnPreview.Click += new System.EventHandler(this.BtnPreviewClick);
			// 
			// btnPrint
			// 
			this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
			this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(23, 23);
			this.btnPrint.Text = "toolStripButton4";
			this.btnPrint.ToolTipText = "印刷";
			this.btnPrint.Click += new System.EventHandler(this.BtnPrintClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
			// 
			// btnZoom
			// 
			this.btnZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnZoom.Image = ((System.Drawing.Image)(resources.GetObject("btnZoom.Image")));
			this.btnZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnZoom.Name = "btnZoom";
			this.btnZoom.Size = new System.Drawing.Size(23, 23);
			this.btnZoom.Text = "toolStripButton5";
			this.btnZoom.ToolTipText = "ズーム";
			this.btnZoom.Click += new System.EventHandler(this.BtnZoomClick);
			// 
			// comboZoom
			// 
			this.comboZoom.Items.AddRange(new object[] {
									"400%",
									"300%",
									"200%",
									"150%",
									"100%",
									"50%"});
			this.comboZoom.Name = "comboZoom";
			this.comboZoom.Size = new System.Drawing.Size(121, 26);
			this.comboZoom.ToolTipText = "倍率";
			this.comboZoom.SelectedIndexChanged += new System.EventHandler(this.ComboZoomSelectedIndexChanged);
			// 
			// btnDrawFrame
			// 
			this.btnDrawFrame.CheckOnClick = true;
			this.btnDrawFrame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnDrawFrame.Image = ((System.Drawing.Image)(resources.GetObject("btnDrawFrame.Image")));
			this.btnDrawFrame.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDrawFrame.Name = "btnDrawFrame";
			this.btnDrawFrame.Size = new System.Drawing.Size(23, 23);
			this.btnDrawFrame.Text = "切り出し矩形を表示";
			this.btnDrawFrame.CheckedChanged += new System.EventHandler(this.BtnDrawFrameCheckedChanged);
			// 
			// btnChara
			// 
			this.btnChara.Checked = true;
			this.btnChara.CheckOnClick = true;
			this.btnChara.CheckState = System.Windows.Forms.CheckState.Checked;
			this.btnChara.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnChara.Image = ((System.Drawing.Image)(resources.GetObject("btnChara.Image")));
			this.btnChara.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnChara.Name = "btnChara";
			this.btnChara.Size = new System.Drawing.Size(23, 23);
			this.btnChara.Text = "toolStripButton1";
			this.btnChara.ToolTipText = "文字画像の表示";
			this.btnChara.CheckedChanged += new System.EventHandler(this.BtnCharaCheckedChanged);
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
			this.btnGraviHou.Size = new System.Drawing.Size(23, 23);
			this.btnGraviHou.Text = "toolStripButton1";
			this.btnGraviHou.ToolTipText = "重心線(放射状)";
			this.btnGraviHou.CheckedChanged += new System.EventHandler(this.BtnGraviHouCheckedChanged);
			// 
			// btnGraviJun
			// 
			this.btnGraviJun.CheckOnClick = true;
			this.btnGraviJun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnGraviJun.Image = ((System.Drawing.Image)(resources.GetObject("btnGraviJun.Image")));
			this.btnGraviJun.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnGraviJun.Name = "btnGraviJun";
			this.btnGraviJun.Size = new System.Drawing.Size(23, 23);
			this.btnGraviJun.Text = "toolStripButton2";
			this.btnGraviJun.ToolTipText = "重心線(連結)";
			this.btnGraviJun.CheckedChanged += new System.EventHandler(this.BtnGraviJunCheckedChanged);
			// 
			// btnSyaei
			// 
			this.btnSyaei.CheckOnClick = true;
			this.btnSyaei.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnSyaei.Image = ((System.Drawing.Image)(resources.GetObject("btnSyaei.Image")));
			this.btnSyaei.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSyaei.Name = "btnSyaei";
			this.btnSyaei.Size = new System.Drawing.Size(23, 23);
			this.btnSyaei.Text = "toolStripButton1";
			this.btnSyaei.ToolTipText = "射影";
			this.btnSyaei.CheckedChanged += new System.EventHandler(this.BtnSyaeiCheckedChanged);
			// 
			// btnDelete
			// 
			this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
			this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDelete.Location = new System.Drawing.Point(664, 411);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 10;
			this.btnDelete.Text = "削除";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.BtnDeleteClick);
			// 
			// btnDown
			// 
			this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
			this.btnDown.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnDown.Location = new System.Drawing.Point(664, 466);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(75, 23);
			this.btnDown.TabIndex = 9;
			this.btnDown.Text = "ひとつ下へ";
			this.btnDown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDown.UseVisualStyleBackColor = true;
			this.btnDown.Click += new System.EventHandler(this.BtnDownClick);
			// 
			// btnUp
			// 
			this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
			this.btnUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnUp.Location = new System.Drawing.Point(664, 355);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(75, 23);
			this.btnUp.TabIndex = 8;
			this.btnUp.Text = "ひとつ上へ";
			this.btnUp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnUp.UseVisualStyleBackColor = true;
			this.btnUp.Click += new System.EventHandler(this.BtnUpClick);
			// 
			// dgvLap
			// 
			this.dgvLap.AllowUserToAddRows = false;
			this.dgvLap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvLap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.colImage,
									this.colFileName});
			this.dgvLap.Location = new System.Drawing.Point(0, 355);
			this.dgvLap.MultiSelect = false;
			this.dgvLap.Name = "dgvLap";
			this.dgvLap.RowHeadersVisible = false;
			this.dgvLap.RowTemplate.Height = 80;
			this.dgvLap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvLap.Size = new System.Drawing.Size(658, 134);
			this.dgvLap.TabIndex = 7;
			// 
			// colImage
			// 
			this.colImage.HeaderText = "イメージ";
			this.colImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
			this.colImage.Name = "colImage";
			this.colImage.Width = 320;
			// 
			// colFileName
			// 
			this.colFileName.HeaderText = "ファイル名";
			this.colFileName.Name = "colFileName";
			this.colFileName.Width = 300;
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.LapImageBox);
			this.panel1.Location = new System.Drawing.Point(0, 29);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1280, 320);
			this.panel1.TabIndex = 6;
			// 
			// LapImageBox
			// 
			this.LapImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.LapImageBox.Location = new System.Drawing.Point(0, 0);
			this.LapImageBox.Name = "LapImageBox";
			this.LapImageBox.Size = new System.Drawing.Size(1280, 320);
			this.LapImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.LapImageBox.TabIndex = 0;
			this.LapImageBox.TabStop = false;
			this.LapImageBox.Paint += new System.Windows.Forms.PaintEventHandler(this.LapImageBoxPaint);
			// 
			// SubMenu
			// 
			this.SubMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.menuFileOpen,
									this.menuFileSave,
									this.toolStripMenuItem5,
									this.menuCopy,
									this.menuSaveImage,
									this.toolStripMenuItem1,
									this.menuUndo,
									this.menuRedo,
									this.toolStripMenuItem4,
									this.menuPreview,
									this.menuPrint,
									this.menuPageSetup,
									this.toolStripMenuItem2,
									this.menuZoom,
									this.menuNewWindow,
									this.menuLayout,
									this.toolStripMenuItem3,
									this.menuClose});
			this.SubMenu.Name = "SubMenu";
			this.SubMenu.Size = new System.Drawing.Size(209, 320);
			// 
			// menuFileOpen
			// 
			this.menuFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("menuFileOpen.Image")));
			this.menuFileOpen.Name = "menuFileOpen";
			this.menuFileOpen.Size = new System.Drawing.Size(208, 22);
			this.menuFileOpen.Text = "開く";
			this.menuFileOpen.Click += new System.EventHandler(this.MenuFileOpenClick);
			// 
			// menuFileSave
			// 
			this.menuFileSave.Image = ((System.Drawing.Image)(resources.GetObject("menuFileSave.Image")));
			this.menuFileSave.Name = "menuFileSave";
			this.menuFileSave.Size = new System.Drawing.Size(208, 22);
			this.menuFileSave.Text = "保存";
			this.menuFileSave.Click += new System.EventHandler(this.MenuFileSaveClick);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(205, 6);
			// 
			// menuCopy
			// 
			this.menuCopy.Image = ((System.Drawing.Image)(resources.GetObject("menuCopy.Image")));
			this.menuCopy.Name = "menuCopy";
			this.menuCopy.Size = new System.Drawing.Size(208, 22);
			this.menuCopy.Text = "コピー";
			this.menuCopy.Click += new System.EventHandler(this.MenuCopyClick);
			// 
			// menuSaveImage
			// 
			this.menuSaveImage.Image = ((System.Drawing.Image)(resources.GetObject("menuSaveImage.Image")));
			this.menuSaveImage.Name = "menuSaveImage";
			this.menuSaveImage.Size = new System.Drawing.Size(208, 22);
			this.menuSaveImage.Text = "画像として保存";
			this.menuSaveImage.Click += new System.EventHandler(this.MenuSaveImageClick);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(205, 6);
			// 
			// menuUndo
			// 
			this.menuUndo.Image = ((System.Drawing.Image)(resources.GetObject("menuUndo.Image")));
			this.menuUndo.Name = "menuUndo";
			this.menuUndo.Size = new System.Drawing.Size(208, 22);
			this.menuUndo.Text = "元に戻す";
			this.menuUndo.Click += new System.EventHandler(this.MenuUndoClick);
			// 
			// menuRedo
			// 
			this.menuRedo.Image = ((System.Drawing.Image)(resources.GetObject("menuRedo.Image")));
			this.menuRedo.Name = "menuRedo";
			this.menuRedo.Size = new System.Drawing.Size(208, 22);
			this.menuRedo.Text = "やり直し";
			this.menuRedo.Click += new System.EventHandler(this.MenuRedoClick);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(205, 6);
			// 
			// menuPreview
			// 
			this.menuPreview.Image = ((System.Drawing.Image)(resources.GetObject("menuPreview.Image")));
			this.menuPreview.Name = "menuPreview";
			this.menuPreview.Size = new System.Drawing.Size(208, 22);
			this.menuPreview.Text = "印刷プレビュー";
			this.menuPreview.Click += new System.EventHandler(this.MenuPreviewClick);
			// 
			// menuPrint
			// 
			this.menuPrint.Image = ((System.Drawing.Image)(resources.GetObject("menuPrint.Image")));
			this.menuPrint.Name = "menuPrint";
			this.menuPrint.Size = new System.Drawing.Size(208, 22);
			this.menuPrint.Text = "印刷";
			this.menuPrint.Click += new System.EventHandler(this.MenuPrintClick);
			// 
			// menuPageSetup
			// 
			this.menuPageSetup.Image = ((System.Drawing.Image)(resources.GetObject("menuPageSetup.Image")));
			this.menuPageSetup.Name = "menuPageSetup";
			this.menuPageSetup.Size = new System.Drawing.Size(208, 22);
			this.menuPageSetup.Text = "ページ設定";
			this.menuPageSetup.Click += new System.EventHandler(this.MenuPageSetupClick);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(205, 6);
			// 
			// menuZoom
			// 
			this.menuZoom.Image = ((System.Drawing.Image)(resources.GetObject("menuZoom.Image")));
			this.menuZoom.Name = "menuZoom";
			this.menuZoom.Size = new System.Drawing.Size(208, 22);
			this.menuZoom.Text = "ズーム";
			this.menuZoom.Click += new System.EventHandler(this.MenuZoomClick);
			// 
			// menuNewWindow
			// 
			this.menuNewWindow.Image = ((System.Drawing.Image)(resources.GetObject("menuNewWindow.Image")));
			this.menuNewWindow.Name = "menuNewWindow";
			this.menuNewWindow.Size = new System.Drawing.Size(208, 22);
			this.menuNewWindow.Text = "新しいウィンドウを開く";
			this.menuNewWindow.Click += new System.EventHandler(this.MenuNewWindowClick);
			// 
			// menuLayout
			// 
			this.menuLayout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.menuUpDownAlign,
									this.menuLRAlign,
									this.menuOverAlign});
			this.menuLayout.Name = "menuLayout";
			this.menuLayout.Size = new System.Drawing.Size(208, 22);
			this.menuLayout.Text = "整列";
			// 
			// menuUpDownAlign
			// 
			this.menuUpDownAlign.Image = ((System.Drawing.Image)(resources.GetObject("menuUpDownAlign.Image")));
			this.menuUpDownAlign.Name = "menuUpDownAlign";
			this.menuUpDownAlign.Size = new System.Drawing.Size(172, 22);
			this.menuUpDownAlign.Text = "上下に並べて表示";
			this.menuUpDownAlign.Click += new System.EventHandler(this.MenuUpDownAlignClick);
			// 
			// menuLRAlign
			// 
			this.menuLRAlign.Image = ((System.Drawing.Image)(resources.GetObject("menuLRAlign.Image")));
			this.menuLRAlign.Name = "menuLRAlign";
			this.menuLRAlign.Size = new System.Drawing.Size(172, 22);
			this.menuLRAlign.Text = "左右に並べて表示";
			this.menuLRAlign.Click += new System.EventHandler(this.MenuLRAlignClick);
			// 
			// menuOverAlign
			// 
			this.menuOverAlign.Image = ((System.Drawing.Image)(resources.GetObject("menuOverAlign.Image")));
			this.menuOverAlign.Name = "menuOverAlign";
			this.menuOverAlign.Size = new System.Drawing.Size(172, 22);
			this.menuOverAlign.Text = "重ねて表示";
			this.menuOverAlign.Click += new System.EventHandler(this.MenuOverAlignClick);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(205, 6);
			// 
			// menuClose
			// 
			this.menuClose.Image = ((System.Drawing.Image)(resources.GetObject("menuClose.Image")));
			this.menuClose.Name = "menuClose";
			this.menuClose.Size = new System.Drawing.Size(208, 22);
			this.menuClose.Text = "閉じる";
			this.menuClose.Click += new System.EventHandler(this.MenuCloseClick);
			// 
			// saveImageDialog
			// 
			this.saveImageDialog.Filter = "JPEG(*.jpeg)|*.jpeg|PNG (*.png)|*.png|GIF (*.gif)|*.gif|すべてのファイル|*.*";
			this.saveImageDialog.Title = "名前をつけて保存";
			// 
			// saveFileDlg
			// 
			this.saveFileDlg.Filter = "文字列重ね合わせデータ(*.csl)|*.csl|すべてのファイル(*.*)|*.*";
			// 
			// openFileDlg
			// 
			this.openFileDlg.Filter = "文字列重ね合わせデータ(*.csl)|*.csl|すべてのファイル(*.*)|*.*";
			// 
			// printDoc
			// 
			this.printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocPrintPage);
			// 
			// pageSetupDlg
			// 
			this.pageSetupDlg.Document = this.printDoc;
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
			// printDlg
			// 
			this.printDlg.Document = this.printDoc;
			this.printDlg.UseEXDialog = true;
			// 
			// StringLapForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1285, 495);
			this.ContextMenuStrip = this.SubMenu;
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnDown);
			this.Controls.Add(this.btnUp);
			this.Controls.Add(this.dgvLap);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "StringLapForm";
			this.Text = "文字列重ね合せ";
			this.Load += new System.EventHandler(this.StringLapFormLoad);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.StringLapFormDragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.StringLapFormDragEnter);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StringLapFormFormClosing);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvLap)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.LapImageBox)).EndInit();
			this.SubMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.PrintDialog printDlg;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDlg;
		private System.Windows.Forms.PageSetupDialog pageSetupDlg;
		private System.Drawing.Printing.PrintDocument printDoc;
		private System.Windows.Forms.OpenFileDialog openFileDlg;
		private System.Windows.Forms.SaveFileDialog saveFileDlg;
		private System.Windows.Forms.SaveFileDialog saveImageDialog;
		private System.Windows.Forms.ToolStripMenuItem menuClose;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem menuOverAlign;
		private System.Windows.Forms.ToolStripMenuItem menuLRAlign;
		private System.Windows.Forms.ToolStripMenuItem menuUpDownAlign;
		private System.Windows.Forms.ToolStripMenuItem menuLayout;
		private System.Windows.Forms.ToolStripMenuItem menuNewWindow;
		private System.Windows.Forms.ToolStripMenuItem menuZoom;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem menuPageSetup;
		private System.Windows.Forms.ToolStripMenuItem menuPrint;
		private System.Windows.Forms.ToolStripMenuItem menuPreview;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem menuRedo;
		private System.Windows.Forms.ToolStripMenuItem menuUndo;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem menuSaveImage;
		private System.Windows.Forms.ToolStripMenuItem menuCopy;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem menuFileSave;
		private System.Windows.Forms.ToolStripMenuItem menuFileOpen;
		private System.Windows.Forms.ContextMenuStrip SubMenu;
		private System.Windows.Forms.PictureBox LapImageBox;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
		private System.Windows.Forms.DataGridViewImageColumn colImage;
		private System.Windows.Forms.DataGridView dgvLap;
		private System.Windows.Forms.Button btnUp;
		private System.Windows.Forms.Button btnDown;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.ToolStripButton btnSyaei;
		private System.Windows.Forms.ToolStripButton btnGraviJun;
		private System.Windows.Forms.ToolStripButton btnGraviHou;
		private System.Windows.Forms.ToolStripButton btnChara;
		private System.Windows.Forms.ToolStripButton btnDrawFrame;
		private System.Windows.Forms.ToolStripComboBox comboZoom;
		private System.Windows.Forms.ToolStripButton btnZoom;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnPrint;
		private System.Windows.Forms.ToolStripButton btnPreview;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton btnRedo;
		private System.Windows.Forms.ToolStripButton btnUndo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnSave;
		private System.Windows.Forms.ToolStripButton btnCopy;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton btnFileSave;
		private System.Windows.Forms.ToolStripButton btnFileOpen;
		private System.Windows.Forms.ToolStrip toolStrip1;
	}
}
