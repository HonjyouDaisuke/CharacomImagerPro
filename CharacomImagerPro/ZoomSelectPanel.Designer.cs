/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2011/10/19
 * 時刻: 15:40
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
namespace CharacomImagerPro
{
	partial class ZoomSelectPanel
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZoomSelectPanel));
			this.btn400 = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.btn300 = new System.Windows.Forms.RadioButton();
			this.btn200 = new System.Windows.Forms.RadioButton();
			this.btn150 = new System.Windows.Forms.RadioButton();
			this.btn100 = new System.Windows.Forms.RadioButton();
			this.btn50 = new System.Windows.Forms.RadioButton();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn400
			// 
			this.btn400.Location = new System.Drawing.Point(12, 28);
			this.btn400.Name = "btn400";
			this.btn400.Size = new System.Drawing.Size(104, 24);
			this.btn400.TabIndex = 0;
			this.btn400.TabStop = true;
			this.btn400.Text = "400%";
			this.btn400.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "倍率";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn300
			// 
			this.btn300.Location = new System.Drawing.Point(12, 52);
			this.btn300.Name = "btn300";
			this.btn300.Size = new System.Drawing.Size(104, 24);
			this.btn300.TabIndex = 2;
			this.btn300.TabStop = true;
			this.btn300.Text = "300%";
			this.btn300.UseVisualStyleBackColor = true;
			// 
			// btn200
			// 
			this.btn200.Location = new System.Drawing.Point(12, 76);
			this.btn200.Name = "btn200";
			this.btn200.Size = new System.Drawing.Size(104, 24);
			this.btn200.TabIndex = 3;
			this.btn200.TabStop = true;
			this.btn200.Text = "200%";
			this.btn200.UseVisualStyleBackColor = true;
			// 
			// btn150
			// 
			this.btn150.Location = new System.Drawing.Point(86, 28);
			this.btn150.Name = "btn150";
			this.btn150.Size = new System.Drawing.Size(104, 24);
			this.btn150.TabIndex = 4;
			this.btn150.TabStop = true;
			this.btn150.Text = "150%";
			this.btn150.UseVisualStyleBackColor = true;
			// 
			// btn100
			// 
			this.btn100.Location = new System.Drawing.Point(86, 52);
			this.btn100.Name = "btn100";
			this.btn100.Size = new System.Drawing.Size(104, 24);
			this.btn100.TabIndex = 5;
			this.btn100.TabStop = true;
			this.btn100.Text = "100%";
			this.btn100.UseVisualStyleBackColor = true;
			// 
			// btn50
			// 
			this.btn50.Location = new System.Drawing.Point(86, 76);
			this.btn50.Name = "btn50";
			this.btn50.Size = new System.Drawing.Size(104, 24);
			this.btn50.TabIndex = 6;
			this.btn50.TabStop = true;
			this.btn50.Text = "50%";
			this.btn50.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(2, 106);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(78, 26);
			this.btnOK.TabIndex = 7;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.BtnOKClick);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(86, 106);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(78, 26);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "キャンセル";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// ZoomSelectPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(169, 136);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btn50);
			this.Controls.Add(this.btn100);
			this.Controls.Add(this.btn150);
			this.Controls.Add(this.btn200);
			this.Controls.Add(this.btn300);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn400);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ZoomSelectPanel";
			this.Text = "ズーム";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.RadioButton btn50;
		private System.Windows.Forms.RadioButton btn100;
		private System.Windows.Forms.RadioButton btn150;
		private System.Windows.Forms.RadioButton btn200;
		private System.Windows.Forms.RadioButton btn300;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton btn400;
	}
}
