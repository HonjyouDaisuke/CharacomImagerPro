/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2012/03/14
 * 時刻: 10:38
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
namespace CharacomImagerPro
{
	/// <summary>
	/// Description of IntraindividualGraph.
	/// </summary>
	public partial class IntraindividualGraph : Form
	{
		Bitmap _viewBitmap = new Bitmap(570, 360);
		ImageEffect imageEffect = new ImageEffect();
		string sComment;
		IntraindividualVariationForm ivf;
		
		public IntraindividualVariationForm Ivf {
			get { return ivf; }
			set { ivf = value; }
		}
		
		public string SComment {
			get { return sComment; }
			set { sComment = value; }
		}
		
		public Bitmap ViewBitmap {
			get { return _viewBitmap; }
			set { _viewBitmap = value; }
		}
		
		public IntraindividualGraph()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void GraphImagePaint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImage(_viewBitmap, 0, 0, GraphImage.Width, GraphImage.Height);
		}
		
		#region DataGridViewへの追加
		public void dgvColsAdd(string title, int width)
		{
			dgvData.Columns.Add(title, title);
			if(dgvData.Columns.Count > 0){
				dgvData.Columns[dgvData.Columns.Count - 1].Width = width;
				//System.Diagnostics.Debug.WriteLine("colnum=" + (dgvData.Columns.Count - 1).ToString() + " title=" + dgvData.Columns[dgvData.Columns.Count - 1].HeaderText.ToString() + " width=" + dgvData.Columns[dgvData.Columns.Count - 1].Width.ToString());
			}
		}
		public void dgvCellBackColor(int row, int col, Color c)
		{
			dgvData.Rows[row].Cells[col].Style.BackColor = c;
		}
		public void dgvRowsAdd(string title, Color c)
		{
			dgvData.Rows.Add();
			dgvData.Rows[dgvData.Rows.Count - 1].Cells[1].Value = title;
			//dgvData.Rows[dgvData.Rows.Count - 1].Cells[0].Style.ForeColor = c;
		}
		public void dgvDataAdd(int row, int col, string data, Color c)
		{
			dgvData.Rows[row].Cells[col].Value = data;
			//dgvData.Rows[row].Cells[col].Style.ForeColor = c;
		}
		#endregion
		
		#region 一番初めのカレントセルに設定
		public void SetFirstActiveCell()
		{
			if(dgvData.Rows.Count > 0 && dgvData.Columns.Count > 1){
				dgvData.CurrentCell = dgvData[1, 0];
			}
		}
		#endregion
		
		#region コメントをセット
		public void TxtCommentSet(string comment)
		{
			txtComment.Text = comment;
		}
		#endregion
		
		void IntraindividualGraphSizeChanged(object sender, EventArgs e)
		{
			Point p;
			panel1.Height = (int)((double)(this.Height - 80)*0.65);
			panel1.Width = this.Width - 3 - 6 - 21 - txtComment.Width;
			GraphImage.Invalidate();
			dgvData.Height = (int)((double)(this.Height - 80)*0.35);
			dgvData.Width = this.Width - 3 - 6 - 21 - txtComment.Width;
			p = new Point( dgvData.Location.X, 10 + GraphImage.Height + 25);
			dgvData.Location = p;
			
			txtComment.Height = this.Height - 69;
			txtComment.Location = new Point(this.Width - 21 - txtComment.Width, txtComment.Location.Y);
			//System.Diagnostics.Debug.WriteLine(this.Height.ToString() + "->" + GraphImage.Height.ToString() + ":" + dgvData.Height.ToString());
			
		}
		
		void BtnCopyClick(object sender, EventArgs e)
		{
			Bitmap clipBmp = new Bitmap(_viewBitmap);
	
			imageEffect.BitmapDrawFrame(clipBmp);
			Clipboard.SetImage(clipBmp);
			
			clipBmp.Dispose();
		}
		
		#region ウィンドウをコピー
		// 2020.08.24 D.Honjyou 三崎さんからの要望により追加
		void BtnCopyWindowClick(object sender, EventArgs e)
		{
			//フォームからスクリーンショットを撮る　
			Bitmap clipBmp = new Bitmap(this.Width, this.Height);
			this.DrawToBitmap(clipBmp, new Rectangle(0, 0, this.Width, this.Height));
			Clipboard.SetImage(clipBmp);
			clipBmp.Dispose();
		}
		#endregion
		
		#region 画像ファイルかどうかの判定
		bool IsImageFile(string str)
		{
			bool bRet = false;
			switch (Path.GetExtension(str).ToLower()) {
				case ".jpeg":
				case ".jpg":
				case ".jpe":
				case ".gif":
				case ".bmp":
				case ".png":
					bRet = true;
					break;
				default:
					bRet = false;
					break;
			}
			return(bRet);
		}
		#endregion
		
		void BtnImageSaveClick(object sender, EventArgs e)
		{
			if(saveImageDialog.ShowDialog() == DialogResult.OK){
				if(IsImageFile(saveImageDialog.FileName)){
					Bitmap clipBmp = new Bitmap(_viewBitmap);
	
					imageEffect.BitmapDrawFrame(clipBmp);
					clipBmp.Save(saveImageDialog.FileName);
				}
			}
		}
		
		void BtnUndoClick(object sender, EventArgs e)
		{
			
		}
		
		void BtnRedoClick(object sender, EventArgs e)
		{
			
		}
		
		void BtnPreviewClick(object sender, EventArgs e)
		{
			ivf.BtnPreviewClick(sender, e);
		}
		
		void BtnPrintClick(object sender, EventArgs e)
		{
			ivf.BtnPrintClick(sender, e);
		}
		
	}
}
