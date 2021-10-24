/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2011/10/25
 * 時刻: 13:00
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
namespace CharacomImagerPro
{
	/// <summary>
	/// Description of FrameDataClass.
	/// </summary>
	[Serializable]
	public class FrameDataClass
	{
		private Point gravity;
		private Point _topPoint;
		private Point _bottomPoint;
		
		public Point Gravity
  		{
    		set{this.gravity = value;}
    		get{return this.gravity;}
  		}

		public Point TopPoint { get => _topPoint; set => _topPoint = value; }
		public Point BottomPoint { get => _bottomPoint; set => _bottomPoint = value; }

		public int Height
		{
			get{return this.frame.Height;}
		}
		
		public int Width
		{
			get{return this.frame.Width;}
		}
		public long Area
		{
			get{return(this.frame.Height * this.frame.Width);}
		}
		
		public float Ratio
		{
			get{return((float)this.frame.Height / (float)this.frame.Width);}
		}
		
		private Rectangle frame;
		public Rectangle Frame {
			get { return frame; }
			set { frame = value; }
		}
		private Color frameColor;
		public Color FrameColor {
			get { return frameColor; }
			set { frameColor = value; }
		}
		private Bitmap bmp;
		
		public Bitmap Bmp {
			get { return bmp; }
			set { bmp = value; }
		}

        
        public FrameDataClass(int width, int height)
		{
			bmp = new Bitmap(width, height);
		}
		public FrameDataClass Clone()
		{
			return (FrameDataClass)MemberwiseClone();
		}
	}
}
