/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2012/01/25
 * 時刻: 16:25
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
namespace CharacomImagerPro
{
	partial class PluralCheckUp
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
			this.dgvCheckUps = new System.Windows.Forms.DataGridView();
			this.btnCheckUp = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.lblCheckupRuiji = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colRuiji = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvCheckUps)).BeginInit();
			this.groupBox6.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvCheckUps
			// 
			this.dgvCheckUps.AllowUserToAddRows = false;
			this.dgvCheckUps.AllowUserToDeleteRows = false;
			this.dgvCheckUps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCheckUps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.colNo,
									this.colRuiji});
			this.dgvCheckUps.Location = new System.Drawing.Point(12, 55);
			this.dgvCheckUps.Name = "dgvCheckUps";
			this.dgvCheckUps.ReadOnly = true;
			this.dgvCheckUps.RowHeadersVisible = false;
			this.dgvCheckUps.RowTemplate.Height = 21;
			this.dgvCheckUps.Size = new System.Drawing.Size(240, 229);
			this.dgvCheckUps.TabIndex = 0;
			// 
			// btnCheckUp
			// 
			this.btnCheckUp.Location = new System.Drawing.Point(74, 290);
			this.btnCheckUp.Name = "btnCheckUp";
			this.btnCheckUp.Size = new System.Drawing.Size(75, 23);
			this.btnCheckUp.TabIndex = 1;
			this.btnCheckUp.Text = "照合";
			this.btnCheckUp.UseVisualStyleBackColor = true;
			this.btnCheckUp.Click += new System.EventHandler(this.BtnCheckUpClick);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.lblCheckupRuiji);
			this.groupBox6.Controls.Add(this.label18);
			this.groupBox6.Location = new System.Drawing.Point(12, 319);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(240, 44);
			this.groupBox6.TabIndex = 12;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "照合結果";
			// 
			// lblCheckupRuiji
			// 
			this.lblCheckupRuiji.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblCheckupRuiji.Location = new System.Drawing.Point(58, 15);
			this.lblCheckupRuiji.Name = "lblCheckupRuiji";
			this.lblCheckupRuiji.Size = new System.Drawing.Size(82, 23);
			this.lblCheckupRuiji.TabIndex = 9;
			this.lblCheckupRuiji.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label18
			// 
			this.label18.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label18.Location = new System.Drawing.Point(7, 15);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(65, 23);
			this.label18.TabIndex = 10;
			this.label18.Text = "類似度：";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// colNo
			// 
			this.colNo.HeaderText = "No";
			this.colNo.Name = "colNo";
			this.colNo.ReadOnly = true;
			this.colNo.Width = 30;
			// 
			// colRuiji
			// 
			this.colRuiji.HeaderText = "類似度";
			this.colRuiji.Name = "colRuiji";
			this.colRuiji.ReadOnly = true;
			// 
			// PluralCheckUp
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(319, 373);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.btnCheckUp);
			this.Controls.Add(this.dgvCheckUps);
			this.Name = "PluralCheckUp";
			this.Text = "PluralCheckUp";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.PluralCheckUpDragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.PluralCheckUpDragEnter);
			((System.ComponentModel.ISupportInitialize)(this.dgvCheckUps)).EndInit();
			this.groupBox6.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label lblCheckupRuiji;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Button btnCheckUp;
		private System.Windows.Forms.DataGridViewTextBoxColumn colRuiji;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
		private System.Windows.Forms.DataGridView dgvCheckUps;
	}
}
