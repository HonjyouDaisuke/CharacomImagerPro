/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2016/06/20
 * 時刻: 10:22
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
namespace CharacomImagerPro
{
	partial class MultiInputDialog
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button btnOne;
		private System.Windows.Forms.Button btnLineAll;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		
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
			this.btnOne = new System.Windows.Forms.Button();
			this.btnLineAll = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnAll = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOne
			// 
			this.btnOne.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.btnOne.Location = new System.Drawing.Point(16, 85);
			this.btnOne.Margin = new System.Windows.Forms.Padding(4);
			this.btnOne.Name = "btnOne";
			this.btnOne.Size = new System.Drawing.Size(100, 29);
			this.btnOne.TabIndex = 0;
			this.btnOne.Text = "１つだけ";
			this.btnOne.UseVisualStyleBackColor = true;
			// 
			// btnLineAll
			// 
			this.btnLineAll.DialogResult = System.Windows.Forms.DialogResult.No;
			this.btnLineAll.Location = new System.Drawing.Point(124, 85);
			this.btnLineAll.Margin = new System.Windows.Forms.Padding(4);
			this.btnLineAll.Name = "btnLineAll";
			this.btnLineAll.Size = new System.Drawing.Size(133, 29);
			this.btnLineAll.TabIndex = 1;
			this.btnLineAll.Text = "縦一列すべて";
			this.btnLineAll.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(406, 85);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 29);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "キャンセル";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(16, 15);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(43, 40);
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox1Paint);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(67, 18);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(436, 38);
			this.label1.TabIndex = 4;
			this.label1.Text = "データをひとつだけ投入するか、縦一列すべてを投入するか、画面上のすべてを投入するかを選択してください。";
			// 
			// btnAll
			// 
			this.btnAll.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAll.Location = new System.Drawing.Point(265, 85);
			this.btnAll.Margin = new System.Windows.Forms.Padding(4);
			this.btnAll.Name = "btnAll";
			this.btnAll.Size = new System.Drawing.Size(133, 29);
			this.btnAll.TabIndex = 5;
			this.btnAll.Text = "画面上のすべて";
			this.btnAll.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(2, 66);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(518, 15);
			this.label2.TabIndex = 6;
			this.label2.Text = "※画面上すべてのデータを投入する際は、画面左側から投入します。";
			// 
			// MultiInputDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(516, 120);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnAll);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnLineAll);
			this.Controls.Add(this.btnOne);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MultiInputDialog";
			this.Text = "データ投入確認";
			this.Load += new System.EventHandler(this.MultiInputDialogLoad);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnAll;
	}
}
