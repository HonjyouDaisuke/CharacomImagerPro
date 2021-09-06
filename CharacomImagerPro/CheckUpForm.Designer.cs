/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2011/10/17
 * 時刻: 13:04
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
namespace CharacomImagerPro
{
	partial class CheckUpForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckUpForm));
			this.dgvGroupA = new System.Windows.Forms.DataGridView();
			this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Image = new System.Windows.Forms.DataGridViewImageColumn();
			this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Check = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.subMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.OpenMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.UndoMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.RedoMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.DeleteMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.CopyMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.PrintMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.PreViewMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.groupA = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label14 = new System.Windows.Forms.Label();
			this.DispersionGraphA = new System.Windows.Forms.PictureBox();
			this.lblRuijiAMax = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblVarA = new System.Windows.Forms.Label();
			this.groupB = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.DispersionGraphB = new System.Windows.Forms.PictureBox();
			this.label5 = new System.Windows.Forms.Label();
			this.lblRuijiBMax = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblVarB = new System.Windows.Forms.Label();
			this.dgvGroupB = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnCheckUp = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.lblRuijiLabel = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.lblCheckupRuiji = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnOpen = new System.Windows.Forms.ToolStripButton();
			this.btnSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnUndo = new System.Windows.Forms.ToolStripButton();
			this.btnRedo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnCopy = new System.Windows.Forms.ToolStripButton();
			this.btnPrint = new System.Windows.Forms.ToolStripButton();
			this.btnPreView = new System.Windows.Forms.ToolStripButton();
			this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDlg = new System.Windows.Forms.SaveFileDialog();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			((System.ComponentModel.ISupportInitialize)(this.dgvGroupA)).BeginInit();
			this.subMenu.SuspendLayout();
			this.groupA.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DispersionGraphA)).BeginInit();
			this.groupB.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DispersionGraphB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvGroupB)).BeginInit();
			this.groupBox6.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvGroupA
			// 
			this.dgvGroupA.AllowDrop = true;
			this.dgvGroupA.AllowUserToAddRows = false;
			this.dgvGroupA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGroupA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.No,
									this.Image,
									this.Address,
									this.Check});
			this.dgvGroupA.ContextMenuStrip = this.subMenu;
			this.dgvGroupA.Location = new System.Drawing.Point(6, 18);
			this.dgvGroupA.Name = "dgvGroupA";
			this.dgvGroupA.RowHeadersVisible = false;
			this.dgvGroupA.RowTemplate.Height = 80;
			this.dgvGroupA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvGroupA.Size = new System.Drawing.Size(256, 116);
			this.dgvGroupA.TabIndex = 0;
			this.dgvGroupA.DragEnter += new System.Windows.Forms.DragEventHandler(this.DgvGroupADragEnter);
			this.dgvGroupA.SelectionChanged += new System.EventHandler(this.DgvGroupASelectionChanged);
			this.dgvGroupA.DragDrop += new System.Windows.Forms.DragEventHandler(this.DgvGroupADragDrop);
			// 
			// No
			// 
			this.No.HeaderText = "No.";
			this.No.Name = "No";
			this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.No.Width = 30;
			// 
			// Image
			// 
			this.Image.HeaderText = "イメージ";
			this.Image.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
			this.Image.Name = "Image";
			this.Image.Width = 80;
			// 
			// Address
			// 
			this.Address.HeaderText = "ファイル名";
			this.Address.Name = "Address";
			this.Address.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Address.Width = 90;
			// 
			// Check
			// 
			this.Check.HeaderText = "類似度";
			this.Check.Name = "Check";
			this.Check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Check.Width = 50;
			// 
			// subMenu
			// 
			this.subMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.OpenMenu,
									this.SaveMenu,
									this.toolStripMenuItem2,
									this.UndoMenu,
									this.RedoMenu,
									this.toolStripMenuItem1,
									this.DeleteMenu,
									this.toolStripMenuItem3,
									this.CopyMenu,
									this.PrintMenu,
									this.PreViewMenu});
			this.subMenu.Name = "subMenu";
			this.subMenu.Size = new System.Drawing.Size(161, 198);
			this.subMenu.Opened += new System.EventHandler(this.SubMenuOpened);
			// 
			// OpenMenu
			// 
			this.OpenMenu.Image = ((System.Drawing.Image)(resources.GetObject("OpenMenu.Image")));
			this.OpenMenu.Name = "OpenMenu";
			this.OpenMenu.Size = new System.Drawing.Size(160, 22);
			this.OpenMenu.Text = "開く";
			this.OpenMenu.Click += new System.EventHandler(this.OpenMenuClick);
			// 
			// SaveMenu
			// 
			this.SaveMenu.Image = ((System.Drawing.Image)(resources.GetObject("SaveMenu.Image")));
			this.SaveMenu.Name = "SaveMenu";
			this.SaveMenu.Size = new System.Drawing.Size(160, 22);
			this.SaveMenu.Text = "保存";
			this.SaveMenu.Click += new System.EventHandler(this.SaveMenuClick);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(157, 6);
			// 
			// UndoMenu
			// 
			this.UndoMenu.Image = ((System.Drawing.Image)(resources.GetObject("UndoMenu.Image")));
			this.UndoMenu.Name = "UndoMenu";
			this.UndoMenu.Size = new System.Drawing.Size(160, 22);
			this.UndoMenu.Text = "元に戻す";
			this.UndoMenu.Click += new System.EventHandler(this.UndoMenuClick);
			// 
			// RedoMenu
			// 
			this.RedoMenu.Image = ((System.Drawing.Image)(resources.GetObject("RedoMenu.Image")));
			this.RedoMenu.Name = "RedoMenu";
			this.RedoMenu.Size = new System.Drawing.Size(160, 22);
			this.RedoMenu.Text = "やり直し";
			this.RedoMenu.Click += new System.EventHandler(this.RedoMenuClick);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(157, 6);
			// 
			// DeleteMenu
			// 
			this.DeleteMenu.Image = ((System.Drawing.Image)(resources.GetObject("DeleteMenu.Image")));
			this.DeleteMenu.Name = "DeleteMenu";
			this.DeleteMenu.Size = new System.Drawing.Size(160, 22);
			this.DeleteMenu.Text = "項目を削除";
			this.DeleteMenu.Click += new System.EventHandler(this.DeleteMenuClick);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(157, 6);
			// 
			// CopyMenu
			// 
			this.CopyMenu.Image = ((System.Drawing.Image)(resources.GetObject("CopyMenu.Image")));
			this.CopyMenu.Name = "CopyMenu";
			this.CopyMenu.Size = new System.Drawing.Size(160, 22);
			this.CopyMenu.Text = "コピー";
			this.CopyMenu.Click += new System.EventHandler(this.CopyMenuClick);
			// 
			// PrintMenu
			// 
			this.PrintMenu.Image = ((System.Drawing.Image)(resources.GetObject("PrintMenu.Image")));
			this.PrintMenu.Name = "PrintMenu";
			this.PrintMenu.Size = new System.Drawing.Size(160, 22);
			this.PrintMenu.Text = "印刷";
			this.PrintMenu.Click += new System.EventHandler(this.PrintMenuClick);
			// 
			// PreViewMenu
			// 
			this.PreViewMenu.Image = ((System.Drawing.Image)(resources.GetObject("PreViewMenu.Image")));
			this.PreViewMenu.Name = "PreViewMenu";
			this.PreViewMenu.Size = new System.Drawing.Size(160, 22);
			this.PreViewMenu.Text = "印刷プレビュー";
			this.PreViewMenu.Click += new System.EventHandler(this.PreViewMenuClick);
			// 
			// groupA
			// 
			this.groupA.Controls.Add(this.groupBox4);
			this.groupA.Controls.Add(this.dgvGroupA);
			this.groupA.Location = new System.Drawing.Point(2, 27);
			this.groupA.Name = "groupA";
			this.groupA.Size = new System.Drawing.Size(269, 385);
			this.groupA.TabIndex = 2;
			this.groupA.TabStop = false;
			this.groupA.Text = "グループA";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.label14);
			this.groupBox4.Controls.Add(this.DispersionGraphA);
			this.groupBox4.Controls.Add(this.lblRuijiAMax);
			this.groupBox4.Controls.Add(this.label1);
			this.groupBox4.Controls.Add(this.lblVarA);
			this.groupBox4.Location = new System.Drawing.Point(0, 258);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(269, 124);
			this.groupBox4.TabIndex = 18;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "ばらつき";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(6, 96);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(55, 23);
			this.label14.TabIndex = 9;
			this.label14.Text = "類似度：";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// DispersionGraphA
			// 
			this.DispersionGraphA.BackColor = System.Drawing.Color.White;
			this.DispersionGraphA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.DispersionGraphA.Location = new System.Drawing.Point(6, 18);
			this.DispersionGraphA.Name = "DispersionGraphA";
			this.DispersionGraphA.Size = new System.Drawing.Size(256, 50);
			this.DispersionGraphA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.DispersionGraphA.TabIndex = 17;
			this.DispersionGraphA.TabStop = false;
			this.DispersionGraphA.Paint += new System.Windows.Forms.PaintEventHandler(this.DispersionGraphAPaint);
			// 
			// lblRuijiAMax
			// 
			this.lblRuijiAMax.Location = new System.Drawing.Point(65, 96);
			this.lblRuijiAMax.Name = "lblRuijiAMax";
			this.lblRuijiAMax.Size = new System.Drawing.Size(194, 23);
			this.lblRuijiAMax.TabIndex = 11;
			this.lblRuijiAMax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label1.Location = new System.Drawing.Point(6, 73);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "分散：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblVarA
			// 
			this.lblVarA.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblVarA.Location = new System.Drawing.Point(65, 73);
			this.lblVarA.Name = "lblVarA";
			this.lblVarA.Size = new System.Drawing.Size(194, 23);
			this.lblVarA.TabIndex = 4;
			this.lblVarA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupB
			// 
			this.groupB.Controls.Add(this.groupBox5);
			this.groupB.Controls.Add(this.dgvGroupB);
			this.groupB.Location = new System.Drawing.Point(277, 27);
			this.groupB.Name = "groupB";
			this.groupB.Size = new System.Drawing.Size(269, 385);
			this.groupB.TabIndex = 3;
			this.groupB.TabStop = false;
			this.groupB.Text = "グループB";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.DispersionGraphB);
			this.groupBox5.Controls.Add(this.label5);
			this.groupBox5.Controls.Add(this.lblRuijiBMax);
			this.groupBox5.Controls.Add(this.label3);
			this.groupBox5.Controls.Add(this.lblVarB);
			this.groupBox5.Location = new System.Drawing.Point(0, 258);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(269, 124);
			this.groupBox5.TabIndex = 20;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "ばらつき";
			// 
			// DispersionGraphB
			// 
			this.DispersionGraphB.BackColor = System.Drawing.Color.White;
			this.DispersionGraphB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.DispersionGraphB.Location = new System.Drawing.Point(6, 18);
			this.DispersionGraphB.Name = "DispersionGraphB";
			this.DispersionGraphB.Size = new System.Drawing.Size(256, 50);
			this.DispersionGraphB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.DispersionGraphB.TabIndex = 19;
			this.DispersionGraphB.TabStop = false;
			this.DispersionGraphB.Paint += new System.Windows.Forms.PaintEventHandler(this.DispersionGraphBPaint);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 96);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(55, 23);
			this.label5.TabIndex = 7;
			this.label5.Text = "類似度：";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblRuijiBMax
			// 
			this.lblRuijiBMax.Location = new System.Drawing.Point(65, 96);
			this.lblRuijiBMax.Name = "lblRuijiBMax";
			this.lblRuijiBMax.Size = new System.Drawing.Size(194, 23);
			this.lblRuijiBMax.TabIndex = 13;
			this.lblRuijiBMax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label3.Location = new System.Drawing.Point(6, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "分散：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblVarB
			// 
			this.lblVarB.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblVarB.Location = new System.Drawing.Point(65, 73);
			this.lblVarB.Name = "lblVarB";
			this.lblVarB.Size = new System.Drawing.Size(194, 23);
			this.lblVarB.TabIndex = 6;
			this.lblVarB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dgvGroupB
			// 
			this.dgvGroupB.AllowDrop = true;
			this.dgvGroupB.AllowUserToAddRows = false;
			this.dgvGroupB.AllowUserToDeleteRows = false;
			this.dgvGroupB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGroupB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.dataGridViewTextBoxColumn1,
									this.dataGridViewImageColumn1,
									this.dataGridViewTextBoxColumn2,
									this.dataGridViewImageColumn2});
			this.dgvGroupB.ContextMenuStrip = this.subMenu;
			this.dgvGroupB.Location = new System.Drawing.Point(6, 18);
			this.dgvGroupB.Name = "dgvGroupB";
			this.dgvGroupB.RowHeadersVisible = false;
			this.dgvGroupB.RowTemplate.Height = 80;
			this.dgvGroupB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvGroupB.Size = new System.Drawing.Size(256, 116);
			this.dgvGroupB.TabIndex = 0;
			this.dgvGroupB.DragEnter += new System.Windows.Forms.DragEventHandler(this.DgvGroupBDragEnter);
			this.dgvGroupB.SelectionChanged += new System.EventHandler(this.DgvGroupBSelectionChanged);
			this.dgvGroupB.DragDrop += new System.Windows.Forms.DragEventHandler(this.DgvGroupBDragDrop);
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.HeaderText = "No.";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn1.Width = 30;
			// 
			// dataGridViewImageColumn1
			// 
			this.dataGridViewImageColumn1.HeaderText = "イメージ";
			this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
			this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
			this.dataGridViewImageColumn1.Width = 80;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.HeaderText = "ファイル名";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn2.Width = 90;
			// 
			// dataGridViewImageColumn2
			// 
			this.dataGridViewImageColumn2.HeaderText = "類似度";
			this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
			this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewImageColumn2.Width = 50;
			// 
			// btnCheckUp
			// 
			this.btnCheckUp.Location = new System.Drawing.Point(236, 415);
			this.btnCheckUp.Name = "btnCheckUp";
			this.btnCheckUp.Size = new System.Drawing.Size(75, 23);
			this.btnCheckUp.TabIndex = 10;
			this.btnCheckUp.Text = "↓照合↓";
			this.btnCheckUp.UseVisualStyleBackColor = true;
			this.btnCheckUp.Click += new System.EventHandler(this.BtnCheckUpClick);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.lblRuijiLabel);
			this.groupBox6.Controls.Add(this.label23);
			this.groupBox6.Controls.Add(this.lblCheckupRuiji);
			this.groupBox6.Controls.Add(this.label18);
			this.groupBox6.Location = new System.Drawing.Point(2, 436);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(544, 85);
			this.groupBox6.TabIndex = 11;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "照合結果";
			// 
			// lblRuijiLabel
			// 
			this.lblRuijiLabel.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblRuijiLabel.Location = new System.Drawing.Point(294, 15);
			this.lblRuijiLabel.Name = "lblRuijiLabel";
			this.lblRuijiLabel.Size = new System.Drawing.Size(244, 60);
			this.lblRuijiLabel.TabIndex = 13;
			this.lblRuijiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label23
			// 
			this.label23.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label23.Location = new System.Drawing.Point(203, 34);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(96, 23);
			this.label23.TabIndex = 14;
			this.label23.Text = "判定結果：";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblCheckupRuiji
			// 
			this.lblCheckupRuiji.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblCheckupRuiji.ForeColor = System.Drawing.Color.Red;
			this.lblCheckupRuiji.Location = new System.Drawing.Point(78, 34);
			this.lblCheckupRuiji.Name = "lblCheckupRuiji";
			this.lblCheckupRuiji.Size = new System.Drawing.Size(106, 23);
			this.lblCheckupRuiji.TabIndex = 9;
			this.lblCheckupRuiji.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label18
			// 
			this.label18.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label18.Location = new System.Drawing.Point(6, 34);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(95, 23);
			this.label18.TabIndex = 10;
			this.label18.Text = "類似度：";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.btnOpen,
									this.btnSave,
									this.toolStripSeparator1,
									this.btnUndo,
									this.btnRedo,
									this.toolStripSeparator2,
									this.btnCopy,
									this.btnPrint,
									this.btnPreView,
									this.toolStripLabel1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(552, 25);
			this.toolStrip1.TabIndex = 12;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnOpen
			// 
			this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
			this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(23, 22);
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
			this.btnSave.Size = new System.Drawing.Size(23, 22);
			this.btnSave.Text = "保存";
			this.btnSave.ToolTipText = "保存";
			this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// btnUndo
			// 
			this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
			this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnUndo.Name = "btnUndo";
			this.btnUndo.Size = new System.Drawing.Size(23, 22);
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
			this.btnRedo.Size = new System.Drawing.Size(23, 22);
			this.btnRedo.Text = "toolStripButton2";
			this.btnRedo.ToolTipText = "やり直し";
			this.btnRedo.Click += new System.EventHandler(this.BtnRedoClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// btnCopy
			// 
			this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
			this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(23, 22);
			this.btnCopy.Text = "toolStripButton1";
			this.btnCopy.ToolTipText = "コピー";
			this.btnCopy.Click += new System.EventHandler(this.BtnCopyClick);
			// 
			// btnPrint
			// 
			this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
			this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(23, 22);
			this.btnPrint.Text = "toolStripButton1";
			this.btnPrint.ToolTipText = "印刷";
			this.btnPrint.Click += new System.EventHandler(this.BtnPrintClick);
			// 
			// btnPreView
			// 
			this.btnPreView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPreView.Image = ((System.Drawing.Image)(resources.GetObject("btnPreView.Image")));
			this.btnPreView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPreView.Name = "btnPreView";
			this.btnPreView.Size = new System.Drawing.Size(23, 22);
			this.btnPreView.Text = "toolStripButton1";
			this.btnPreView.Click += new System.EventHandler(this.BtnPreViewClick);
			// 
			// openFileDlg
			// 
			this.openFileDlg.Filter = "照合ファイル(*.cki)|*.cki|すべてのファイル(*.*)|*.*";
			// 
			// saveFileDlg
			// 
			this.saveFileDlg.Filter = "照合ファイル(*.cki)|*.cki|すべてのファイル(*.*)|*.*";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(80, 22);
			this.toolStripLabel1.Text = "特徴抽出法：";
			this.toolStripLabel1.Paint += new System.Windows.Forms.PaintEventHandler(this.ToolStripLabel1Paint);
			// 
			// CheckUpForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(552, 533);
			this.ContextMenuStrip = this.subMenu;
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.btnCheckUp);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.groupB);
			this.Controls.Add(this.groupA);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(568, 453);
			this.Name = "CheckUpForm";
			this.Text = "照合";
			this.Load += new System.EventHandler(this.CheckUpFormLoad);
			this.SizeChanged += new System.EventHandler(this.CheckUpFormSizeChanged);
			this.Shown += new System.EventHandler(this.CheckUpFormShown);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckUpFormFormClosing);
			((System.ComponentModel.ISupportInitialize)(this.dgvGroupA)).EndInit();
			this.subMenu.ResumeLayout(false);
			this.groupA.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DispersionGraphA)).EndInit();
			this.groupB.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DispersionGraphB)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvGroupB)).EndInit();
			this.groupBox6.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripButton btnPreView;
		private System.Windows.Forms.ToolStripMenuItem PreViewMenu;
		private System.Windows.Forms.ToolStripMenuItem PrintMenu;
		private System.Windows.Forms.ToolStripMenuItem CopyMenu;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem DeleteMenu;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem RedoMenu;
		private System.Windows.Forms.ToolStripMenuItem UndoMenu;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem SaveMenu;
		private System.Windows.Forms.ToolStripMenuItem OpenMenu;
		private System.Windows.Forms.ContextMenuStrip subMenu;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnRedo;
		private System.Windows.Forms.ToolStripButton btnUndo;
		private System.Windows.Forms.SaveFileDialog saveFileDlg;
		private System.Windows.Forms.OpenFileDialog openFileDlg;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnOpen;
		private System.Windows.Forms.ToolStripButton btnSave;
		private System.Windows.Forms.ToolStripButton btnPrint;
		private System.Windows.Forms.ToolStripButton btnCopy;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label lblCheckupRuiji;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label lblRuijiLabel;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Button btnCheckUp;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.PictureBox DispersionGraphB;
		private System.Windows.Forms.PictureBox DispersionGraphA;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblRuijiBMax;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label lblRuijiAMax;
		private System.Windows.Forms.Label lblVarB;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblVarA;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewImageColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridView dgvGroupB;
		private System.Windows.Forms.GroupBox groupB;
		private System.Windows.Forms.GroupBox groupA;
		private System.Windows.Forms.DataGridView dgvGroupA;
		private System.Windows.Forms.DataGridViewTextBoxColumn Check;
		private System.Windows.Forms.DataGridViewTextBoxColumn Address;
		private System.Windows.Forms.DataGridViewImageColumn Image;
		private System.Windows.Forms.DataGridViewTextBoxColumn No;
	}
}
