/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2012/04/20
 * 時刻: 10:15
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of RangeCompareGraph.
	/// </summary>
	public partial class RangeCompareGraph : Form
	{
		Bitmap graphBmp = new Bitmap(570, 360);
		ImageEffect imageEffect = new ImageEffect();
		
		public RangeCompareGraph()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			imageEffect.BitmapWhitening(graphBmp);
			GraphImage.AutoSize = true;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public void GraphUpdate(Bitmap bmp)
		{
			imageEffect.BitmapStretchCopy(bmp, graphBmp);
		}
		
		void GraphImagePaint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(graphBmp, 0, 0, GraphImage.Width, GraphImage.Height);
		}
		
		void Panel1Resize(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(panel1.Width.ToString() + "," + panel1.Height.ToString() + "-" + GraphImage.Width.ToString() + "," + GraphImage.Height.ToString());
			//GraphImage.Width = panel1.Width;
			//GraphImage.Height = panel1.Height;
			//GraphImage.Invalidate();
		}
	}
}
