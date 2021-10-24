/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2011/10/21
 * 時刻: 16:11
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of LapClass.
	/// </summary>
	public class LapClass
	{
		ImageEffect imageEffect = new ImageEffect();
		//プロパティ
		private Bitmap bmp;
		public Bitmap Bmp {
			get { return bmp; }
			set { bmp = value; }
		}

		private Bitmap srcBmp;
		private double r;

		private string fileName;		
		public string FileName {
			get { return fileName; }
			set { fileName = value; }
		}

        public Bitmap SrcBmp { get => srcBmp; set => srcBmp = value; }
        public double R { get => r; set => r = value; }

        public void BitmapInsert(Bitmap b)
		{
			bmp = new Bitmap(b.Width, b.Height);
			imageEffect.BitmapWhitening(bmp);
			imageEffect.BitmapCopy(b, bmp);
		}
		public LapClass()
		{
		}
	}
}
