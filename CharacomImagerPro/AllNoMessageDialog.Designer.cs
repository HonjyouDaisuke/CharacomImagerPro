/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2016/06/23
 * 時刻: 11:14
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
namespace CharacomImagerPro
{
	partial class AllNoMessageDialog
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnNo;
		private System.Windows.Forms.Button btnYes;
		private System.Windows.Forms.Button btnAllNo;
		
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
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnNo = new System.Windows.Forms.Button();
			this.btnYes = new System.Windows.Forms.Button();
			this.btnAllNo = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(59, 11);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(321, 38);
			this.label1.TabIndex = 9;
			this.label1.Text = "データをひとつだけ投入するか、縦一列すべてを投入するかを選択してくださ。";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(8, 9);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(43, 40);
			this.pictureBox1.TabIndex = 8;
			this.pictureBox1.TabStop = false;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(358, 58);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 29);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "キャンセル";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnNo
			// 
			this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
			this.btnNo.Location = new System.Drawing.Point(116, 58);
			this.btnNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnNo.Name = "btnNo";
			this.btnNo.Size = new System.Drawing.Size(105, 29);
			this.btnNo.TabIndex = 6;
			this.btnNo.Text = "いいえ(&N)";
			this.btnNo.UseVisualStyleBackColor = true;
			// 
			// btnYes
			// 
			this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.btnYes.Location = new System.Drawing.Point(8, 58);
			this.btnYes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnYes.Name = "btnYes";
			this.btnYes.Size = new System.Drawing.Size(100, 29);
			this.btnYes.TabIndex = 5;
			this.btnYes.Text = "はい(&Y)";
			this.btnYes.UseVisualStyleBackColor = true;
			// 
			// btnAllNo
			// 
			this.btnAllNo.DialogResult = System.Windows.Forms.DialogResult.Ignore;
			this.btnAllNo.Location = new System.Drawing.Point(229, 58);
			this.btnAllNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnAllNo.Name = "btnAllNo";
			this.btnAllNo.Size = new System.Drawing.Size(121, 29);
			this.btnAllNo.TabIndex = 10;
			this.btnAllNo.Text = "すべていいえ(&A)";
			this.btnAllNo.UseVisualStyleBackColor = true;
			// 
			// AllNoMessageDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(462, 92);
			this.Controls.Add(this.btnAllNo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnNo);
			this.Controls.Add(this.btnYes);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "AllNoMessageDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CharacomImagerPro";
			this.Load += new System.EventHandler(this.AllNoMessageDialogLoad);
			this.Shown += new System.EventHandler(this.AllNoMessageDialogShown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
