/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2013/12/01
 * 時刻: 15:54
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
namespace CharacomImagerPro
{
	partial class StanderdImageForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StanderdImageForm));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolBtnInput = new System.Windows.Forms.ToolStripButton();
			this.toolBtnCopy = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.cmbChara = new System.Windows.Forms.ToolStripComboBox();
			this.ImageBox = new System.Windows.Forms.PictureBox();
			this.btnInput = new System.Windows.Forms.Button();
			this.btnCopy = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolBtnInput,
									this.toolBtnCopy,
									this.toolStripSeparator1,
									this.toolStripLabel1,
									this.cmbChara});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(322, 26);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolBtnInput
			// 
			this.toolBtnInput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolBtnInput.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnInput.Image")));
			this.toolBtnInput.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolBtnInput.Name = "toolBtnInput";
			this.toolBtnInput.Size = new System.Drawing.Size(23, 23);
			this.toolBtnInput.Text = "取り込む";
			this.toolBtnInput.Click += new System.EventHandler(this.ToolBtnInputClick);
			// 
			// toolBtnCopy
			// 
			this.toolBtnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolBtnCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnCopy.Image")));
			this.toolBtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolBtnCopy.Name = "toolBtnCopy";
			this.toolBtnCopy.Size = new System.Drawing.Size(23, 23);
			this.toolBtnCopy.Text = "コピー";
			this.toolBtnCopy.Click += new System.EventHandler(this.ToolBtnCopyClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(44, 23);
			this.toolStripLabel1.Text = "文字種";
			// 
			// cmbChara
			// 
			this.cmbChara.Name = "cmbChara";
			this.cmbChara.Size = new System.Drawing.Size(75, 26);
			this.cmbChara.TextChanged += new System.EventHandler(this.CmbCharaTextChanged);
			// 
			// ImageBox
			// 
			this.ImageBox.Location = new System.Drawing.Point(0, 28);
			this.ImageBox.Name = "ImageBox";
			this.ImageBox.Size = new System.Drawing.Size(320, 320);
			this.ImageBox.TabIndex = 1;
			this.ImageBox.TabStop = false;
			this.ImageBox.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageBoxPaint);
			// 
			// btnInput
			// 
			this.btnInput.Location = new System.Drawing.Point(0, 354);
			this.btnInput.Name = "btnInput";
			this.btnInput.Size = new System.Drawing.Size(75, 23);
			this.btnInput.TabIndex = 2;
			this.btnInput.Text = "取り込む";
			this.btnInput.UseVisualStyleBackColor = true;
			this.btnInput.Click += new System.EventHandler(this.BtnInputClick);
			// 
			// btnCopy
			// 
			this.btnCopy.Location = new System.Drawing.Point(81, 354);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(75, 23);
			this.btnCopy.TabIndex = 3;
			this.btnCopy.Text = "コピー";
			this.btnCopy.UseVisualStyleBackColor = true;
			this.btnCopy.Click += new System.EventHandler(this.BtnCopyClick);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(245, 354);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "キャンセル";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// StanderdImageForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(322, 383);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnCopy);
			this.Controls.Add(this.btnInput);
			this.Controls.Add(this.ImageBox);
			this.Controls.Add(this.toolStrip1);
			this.Name = "StanderdImageForm";
			this.Text = "StanderdImageForm";
			this.Load += new System.EventHandler(this.StanderdImageFormLoad);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripComboBox cmbChara;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.PictureBox ImageBox;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnCopy;
		private System.Windows.Forms.Button btnInput;
		private System.Windows.Forms.ToolStripButton toolBtnCopy;
		private System.Windows.Forms.ToolStripButton toolBtnInput;
		private System.Windows.Forms.ToolStrip toolStrip1;
	}
}
