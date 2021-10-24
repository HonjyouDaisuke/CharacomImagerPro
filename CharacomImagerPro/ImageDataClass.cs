/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2011/10/31
 * 時刻: 11:24
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Windows;
using System.Drawing;
using System.Collections;
using System.ComponentModel;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of ImageDataClass.
	/// </summary>
	[Serializable]
	[TypeConverter(typeof(PropertyDisplayConverter))]
	public class ImageDataClass
	{
		//定数
		public const string Calc1Title = "01.全体の縦横比";
		public const string Calc1Disc  = "文字全体の縦横比を表しています。\n(読み取り専用)";
		public const string Calc2Title = "02.扁の縦横比";
		public const string Calc2Disc  = "扁として切り出した部分の縦横比を表しています。\n(読み取り専用)";
		public const string Calc3Title = "03.旁の縦横比";
		public const string Calc3Disc  = "旁として切り出した部分の縦横比を表しています。\n(読み取り専用)";
		public const string Calc4Title = "04.扁と旁の縦の比";
		public const string Calc4Disc  = "扁と旁の縦幅の比を表しています。\n(読み取り専用)";
		public const string Calc5Title = "05.扁と旁の横の比";
		public const string Calc5Disc  = "扁と旁の横幅の比を表しています。\n(読み取り専用)";
		public const string Calc6Title = "06.2.と3.の比";
		public const string Calc6Disc  = "扁の縦横比と旁の縦横比の比を表しています。\n(読み取り専用)";
		public const string Calc7Title = "07.扁と旁の面積比";
		public const string Calc7Disc  = "扁の面積と旁の面積の比を表しています。\n(読み取り専用)";
		public const string Calc8Title = "08.文字と扁の重心の距離";
		public const string Calc8Disc  = "文字の重心と旁の重心とのユークリッド距離を算出しています。\n(読み取り専用)";
		public const string Calc9Title = "09.文字と旁の重心の距離";
		public const string Calc9Disc  = "文字の重心と旁の重心とのユークリッド距離を算出しています。\n(読み取り専用)";
		public const string CalcATitle = "10.扁と旁の重心の距離";
		public const string CalcADisc  = "扁の重心と旁の重心のユークリッド距離を算出しています。\n(読み取り専用)";
		public const string WriterNameTitle = "筆者名";
		public const string WriterNameDisc  = "筆者名を入力してください。";
		public const string WriteStringTitle = "文 字";
		public const string WriteStringDisc  = "記載されている文字を入力してください。";
		public const string WriteDateTitle = "記録日";
		public const string WriteDateDisc  = "画像が記録された日を記載してください。";
		public const string PixelCountTitle = "画素数";
		public const string PixelCountDisc  = "黒画素の数を算出しています。\n(読み取り専用)";
		public const string AllGravityTitle = "全重心";
		public const string AllGravityDisc  = "文字全体の重心座標を表しています。";
		public const string FileNameTitle = "ファイル名";
		public const string FileNameDisc  = "";
		public const string FileSizeTitle = "更新日時";
		public const string FileSizeDisc  = "";
		
		private string writer_name;
		private string write_string;
		private string write_date;
		private Point allgravity;
		private long pixel_count;
		private Bitmap src_img;
		private Bitmap proc_img;
		private Bitmap view_img;
		private Bitmap src_img_small;
		private Bitmap jpeg_img;
		private ArrayList frameData = new ArrayList();
		private float _calc1;
		private float _calc2;
		private float _calc3;
		private float _calc4;
		private float _calc5;
		private float _calc6;
		private float _calc7;
		private float _calc8;
		private float _calc9;
		private float _calcA;
		private Rectangle _allRect;
		private string filename;
		private DateTime updatetime;
		public const int BitmapWidth = 320;
		public const int BitmapHeight = 320;
		public const int SmallWidth = 160;
		public const int SmallHeight = 160;
		private int frame_width;
		private int frame_height;
		private Color _gravityColor = new Color();
		
		private ImageEffect imageEffect = new ImageEffect();
		
		#region 重心色のプロパティ
		public Color GravityColor {
			get { return _gravityColor; }
			set { _gravityColor = value; }
		}
		#endregion

		#region 表示色プロパティ
		//2021.09.25 D.Honyou
		private Color _dispColor;
		public Color DispColor { get => _dispColor; set => _dispColor = value; }

		#endregion

		#region Bitmapの初期化処理
		private void InitBitmaps()
		{
			//Bitmapの作成
			src_img = new Bitmap(frame_width / 2, frame_height / 2);
			proc_img = new Bitmap(frame_width, frame_height);
			view_img = new Bitmap(frame_width, frame_height);
			src_img_small = new Bitmap(frame_width, frame_height);
			jpeg_img = new Bitmap(frame_width, frame_height);
			
			//src_img = new Bitmap(SmallWidth, SmallHeight);
			//proc_img = new Bitmap(BitmapWidth, BitmapHeight);
			//view_img = new Bitmap(BitmapWidth, BitmapHeight);
			//src_img_small = new Bitmap(BitmapWidth, BitmapHeight);
			//jpeg_img = new Bitmap(BitmapWidth, BitmapWidth);
			
			//Bitmapを白で初期化
			imageEffect.BitmapWhitening(src_img);
			imageEffect.BitmapWhitening(proc_img);
			imageEffect.BitmapWhitening(view_img);
			imageEffect.BitmapWhitening(src_img_small);
			imageEffect.BitmapWhitening(jpeg_img);
		}
		#endregion
		
		#region 全体の矩形プロパティ
		[Browsable(false)]
		public Rectangle AllRect
		{
			get{return this._allRect;}
			set{this._allRect = value;}
		}
		#endregion

		#region ユークリッド距離の算出
		float GetDistance(Point A, Point B)
		{
			float x, y, distance;
			
			x = (float)Math.Abs(A.X - B.X);
			y = (float)Math.Abs(A.Y - B.Y);
			distance = (float)Math.Sqrt((x * x) + (y * y));
			
			return distance;
		}
		#endregion
		
		#region ファイル名プロパティ
		[PropertyDisplayName(FileNameTitle)]
		[Description(FileNameDisc)]
		[Category("ファイル情報")]
		public string Filename
		{
			set{this.filename = value;}
			get{return this.filename;}
		}
		#endregion
		
		#region 更新日時プロパティ
		[PropertyDisplayName(FileSizeTitle)]
		[Category("ファイル情報")]
		public DateTime Updatetime
		{
			set{this.updatetime = value;}
			get{return updatetime;}
		}
		#endregion
		
		#region 筆者名プロパティ
		[PropertyDisplayName(WriterNameTitle)]
		[Description(WriterNameDisc)]
		[Category("記録情報")]
		public string WriterName
		{
			set{this.writer_name = value;}
			get{return this.writer_name;}
		}
		#endregion
		
		#region 文字プロパティ
		[PropertyDisplayName(WriteStringTitle)]
		[Description(WriteStringDisc)]
		[Category("記録情報")]
		public string WriteString
		{
			set{this.write_string = value;}
			get{return this.write_string;}
		}
		#endregion
		
		#region 記録日プロパティ
		[PropertyDisplayName(WriteDateTitle)]
		[Description(WriteDateDisc)]
		[Category("記録情報")]
		public string WriteDate
		{
			set{this.write_date = value;}
			get{return this.write_date;}
		}
		#endregion
		
		#region 重心プロパティ
		[PropertyDisplayName(AllGravityTitle)]
		[Description(AllGravityDisc)]
		[Category("画素情報")]
		public Point AllGravity
		{
			set{this.allgravity = value;}
			get{return this.allgravity;}
		}
		#endregion
		
		#region 画素数プロパティ
		[PropertyDisplayName(PixelCountTitle)]
		[Description(PixelCountDisc)]
		[Category("画素情報")]
		public long PixelCount
		{
			set{this.pixel_count = value;}
			get{return this.pixel_count;}
		}
		#endregion
		
		#region SrcImageプロパティ
		[Browsable(false)]
		public Bitmap SrcImage
		{
			set{this.src_img = value;}
			get{return this.src_img;}
		}
		#endregion
		
		#region ProcImageプロパティ
		[Browsable(false)]
		public Bitmap ProcImage
		{
			set{this.proc_img = value;}
			get{return this.proc_img;}
		}
		#endregion
		
		#region ViewImageプロパティ
		[Browsable(false)]
		public Bitmap ViewImage
		{
			set{this.view_img = value;}
			get{return this.view_img;}
		}
		#endregion
		
		#region SrcImageSmallプロパティ
		[Browsable(false)]
		public Bitmap SrcImageSmall
		{
			set{this.src_img_small = value;}
			get{return this.src_img_small;}
		}
		#endregion
		
		#region JpegImageプロパティ
		[Browsable(false)]
		public Bitmap JpegImage
		{
			set{this.jpeg_img = value;}
			get{return this.jpeg_img;}
		}
		#endregion
		
		#region FrameDataプロパティ
		[Browsable(false)]
		public ArrayList FrameData
		{
			set{this.frameData = value;}
			get{return this.frameData;}
		}
		#endregion
		
		#region 計算値1のプロパティ
		[PropertyDisplayName(Calc1Title)]
		[Description(Calc1Disc)]
		[Category("編と旁の計算値")]
		/// <summary>
		/// 全体の縦横比
		/// </summary>
		public string Calc1
		{
			get{return this._calc1.ToString("f3");}
			set{ }
		}
		#endregion
		
		#region 計算値2のプロパティ
		[PropertyDisplayName(Calc2Title)]
		[Description(Calc2Disc)]
		[Category("編と旁の計算値")]
		/// <summary>
		/// 扁の縦横比
		/// </summary>
		public string Calc2
		{
			get{return this._calc2.ToString("f3");}
			set{ }
		}
		#endregion
		
		#region 計算値3のプロパティ
		[PropertyDisplayName(Calc3Title)]
		[Description(Calc3Disc)]
		[Category("編と旁の計算値")]
		/// <summary>
		/// 旁の縦横比
		/// </summary>
		public string Calc3
		{
			get{return this._calc3.ToString("f3");}
			set{ }
		}
		#endregion	
		
		#region 計算値4のプロパティ
		[PropertyDisplayName(Calc4Title)]
		[Description(Calc4Disc)]
		[Category("編と旁の計算値")]
		/// <summary>
		/// 扁と旁の縦の比
		/// </summary>
		public string Calc4
		{
			get{return this._calc4.ToString("f3");}
			set{ }
		}
		#endregion
		
		#region 計算値5のプロパティ
		[PropertyDisplayName(Calc5Title)]
		[Description(Calc5Disc)]
		[Category("編と旁の計算値")]
		/// <summary>
		/// 扁と旁の横の比
		/// </summary>
		public string Calc5
		{
			get{return this._calc5.ToString("f3");}
			set{ }
		}
		#endregion
		
		#region 計算値6のプロパティ
		[PropertyDisplayName(Calc6Title)]
		[Description(Calc6Disc)]
		[Category("編と旁の計算値")]
		/// <summary>
		/// 2.と3.の比
		/// </summary>
		public string Calc6
		{
			get{return this._calc6.ToString("f3");}
			set{ }
		}
		#endregion
		
		#region 計算値7のプロパティ
		[PropertyDisplayName(Calc7Title)]
		[Description(Calc7Disc)]
		[Category("編と旁の計算値")]
		/// <summary>
		/// 扁と旁の面積比
		/// </summary>
		public string Calc7
		{
			get{return this._calc7.ToString("f3");}
			set{ }
		}
		#endregion
		
		#region 計算値8のプロパティ
		[PropertyDisplayName(Calc8Title)]
		[Description(Calc8Disc)]
		[Category("編と旁の計算値")]
		/// <summary>
		/// 文字と扁の重心の距離
		/// </summary>
		public string Calc8
		{
			get{return this._calc8.ToString("f3");}
			set{ }
		}
		#endregion
		
		#region 計算値9のプロパティ
		[PropertyDisplayName(Calc9Title)]
		[Description(Calc9Disc)]
		[Category("編と旁の計算値")]
		/// <summary>
		/// 文字と旁の重心の距離
		/// </summary>
		public string Calc9
		{
			get{return this._calc9.ToString("f3");}
			set{ }
		}
		#endregion
		
		#region 計算値Aのプロパティ
		[PropertyDisplayName(CalcATitle)]
		[Description(CalcADisc)]
		[Category("編と旁の計算値")]
		/// <summary>
		/// 扁と旁の重心の距離
		/// </summary>
		public string CalcA
		{
			get{return this._calcA.ToString("f3");}
			set{ }
		}

        #endregion

        #region 計算値の計算
        public void FrameCalc()
		{
			if(this.FrameData.Count < 1){
				return;
			}else if(this.FrameData.Count < 2){
				FrameDataClass fd1 = new FrameDataClass(frame_width, frame_height);
				fd1 = (FrameDataClass)FrameData[0];
				//dgvContexture.Rows[0].Cells[ 2].Value = (((float)maxY - (float)minY) / ((float)maxX - (float)minX)).ToString("f3");
				//this._calc1 = 
				this._calc2 = ((float)fd1.Height / (float)fd1.Width);
				this._calc8 = GetDistance(this.AllGravity, fd1.Gravity);
				//dgvContexture.Rows[7].Cells[ 2].Value = GetDistance(AllGravityP, FrameGrav[0]).ToString("f1");
			}else{
				int maxX,maxY,minX,minY;
				int a,b,c,d;
				FrameDataClass fd1 = new FrameDataClass(frame_width, frame_height);
				FrameDataClass fd2 = new FrameDataClass(frame_width, frame_height);
				fd1 = (FrameDataClass)FrameData[0];
				fd2 = (FrameDataClass)FrameData[1];
				
				maxX = 0;
				minY =0;
				minX = 0;
				maxY = 0;
				
				a=fd1.Frame.X;
				b=fd1.Frame.X + fd1.Frame.Width;
				c=fd2.Frame.X;
				d=fd2.Frame.X + fd2.Frame.Width;
				
				if(a>b && a>c && a>d){
					maxX = a;
				}
				if(b>a && b>c && b>d){
					maxX = b;
				}
				if(c>a && c>b && c>d){
					maxX = c;
				}
				if(d>=a && d>=c && d>=b){
					maxX = d;
				}
				
				if(a<b && a<c && a<d){
					minX = a;
				}
				if(b<a && b<c && b<d){
					minX = b;
				}
				if(c<a && c<b && c<d){
					minX = c;
				}
				if(d<=a && d<=c && d<=b){
					minX = d;
				}
				
				
				a=fd1.Frame.Y;
				b=fd1.Frame.Y + fd1.Frame.Height;
				c=fd2.Frame.Y;
				d=fd2.Frame.Y + fd2.Frame.Height;
				
				if(a>b && a>c && a>d){
					maxY = a;
				}
				if(b>a && b>c && b>d){
					maxY = b;
				}
				if(c>a && c>b && c>d){
					maxY = c;
				}
				if(d>=a && d>=c && d>=b){
					maxY = d;
				}
				
				if(a<b && a<c && a<d){
					minY = a;
				}
				if(b<a && b<c && b<d){
					minY = b;
				}
				if(c<a && c<b && c<d){
					minY = c;
				}
				if(d<=a && d<=c && d<=b){
					minY = d;
				}
				
				this._calc1 = ((float)maxY - (float)minY) / ((float)maxX - (float)minX);
				this._calc2 = (float)fd1.Height / (float)fd1.Width;
				this._calc3 = (float)fd2.Height / (float)fd2.Width;
				this._calc4 = (float)fd1.Height / (float)fd2.Height;
				this._calc5 = (float)fd1.Width / (float)fd2.Width;
				this._calc6 = ((float)fd1.Height / (float)fd1.Width) / ((float)fd2.Height / (float)fd2.Width);
				this._calc7 = ((float)fd1.Height * (float)fd1.Width ) / ((float)fd2.Height * (float)fd2.Width );
				this._calc8 = GetDistance(this.AllGravity, fd1.Gravity);
				this._calc9 = GetDistance(this.AllGravity, fd2.Gravity);
				this._calcA = GetDistance(fd2.Gravity, fd1.Gravity);
			}
		}
		#endregion
		
		#region FrameDataへフレームの追加
		/// <summary>
		/// FrameDataの追加
		/// </summary>
		/// <param name="fd">フレームデータ</param>
		public void FrameData_Add(FrameDataClass fd)
		{
			if(this.frameData == null){
				this.frameData = new ArrayList();
			}
			this.frameData.Add(fd);
			
			FrameCalc();
		}
		#endregion
		
		#region FrameDataへフレームの挿入
		/// <summary>
		/// FrameDataの追加
		/// </summary>
		/// <param name="fd">フレームデータ</param>
		public void FrameData_Insert(int index, FrameDataClass fd)
		{
			if(this.frameData == null){
				this.frameData = new ArrayList();
			}
			this.frameData.Insert(index, fd);
			
			FrameCalc();
		}
		#endregion
		
		#region FrameDataの削除
		public void FrameData_Delete(int index)
		{
			this.frameData.RemoveAt(index);
		}
		#endregion
		
		public ImageDataClass(int width, int height)
		{
			frame_width = width;
			frame_height = height;
			
			frameData = new ArrayList();
			
			_gravityColor = Color.Maroon;
			InitBitmaps();
		}
	}
}
