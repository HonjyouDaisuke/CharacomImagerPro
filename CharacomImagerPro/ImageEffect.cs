/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2011/10/17
 * 時刻: 11:02
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CharacomImagerPro
{
	public static class EnumerableExtension
	{
		public static double Median(this IEnumerable<double> source)
		{
			if (source is null || !source.Any())
			{
				throw new InvalidOperationException("Cannot compute median for a null or empty set.");
			}

			var sortedList =
				source.OrderBy(number => number).ToList();

			int itemIndex = sortedList.Count / 2;

			if (sortedList.Count % 2 == 0)
			{
				// Even number of items.
				return (sortedList[itemIndex] + sortedList[itemIndex - 1]) / 2;
			}
			else
			{
				// Odd number of items.
				return sortedList[itemIndex];
			}
		}
	}
	/// <summary>
	/// Description of ImageEffect.
	/// </summary>
	[Serializable]
	public class ImageEffect
	{
		int ap = 0, bp = 0;
		/// <summary>
		/// 2次元の点をあらわす構造体
		/// </summary>
		public struct DoublePoint
		{
  			public double X; // x 座標
  			public double Y; // y 座標

  			public override string ToString()
  			{
   	 			return "(" + X + ", " + Y + ")";
  			}
		}
		
		public ImageEffect()
		{
		}
		
		#region 真っ白かどうかのチェック （戻り値：true→何か入っている, false→真っ白）
		/// <summary>
		/// 真っ白かどうかのチェック
		/// 戻り値(bool)：true⇒何か入っている、false⇒真っ白
		/// </summary>
		/// <param name="bmp">チェックする画像(Bitmap)</param>
		/// <returns></returns>
		public bool WhiteCanvasCheck(Bitmap bmp)
		{
			bool bRet = false;
			int i, j;
			
			for(j = 0; j<bmp.Height; j++){
				for(i = 0; i<bmp.Width; i++){
					if(ColorCompare(bmp.GetPixel(i, j), Color.White) != true){
						bRet = true;
					}
				}	
			}
			
			return bRet;
		}
		#endregion
		
		#region 色を変える
		/// <summary>
		/// すべてのドットの色を変更する。
		/// </summary>
		/// <param name="bmp">変更する画像(Bitmap)</param>
		/// <param name="SetC">適用する色</param>
		public void BmpColorChange(Bitmap bmp, Color SetC)
		{
			int i,j;
			
			for(i=0; i<bmp.Width; i++){
				for(j=0; j<bmp.Height; j++){
					if(ColorCompare(bmp.GetPixel(i,j), Color.Black) != true){
						bmp.SetPixel(i, j, SetC);
					}
				}
			}
		}
		#endregion

		#region Bitmapをコピー
		/// <summary>
		/// Bitmapをコピーする。
		/// </summary>
		/// <param name="src">もとの画像(Bitmap)</param>
		/// <param name="output">出力先の画像(Bitmap)</param>
		public void BitmapCopy(Bitmap src, Bitmap output)
		{
			Graphics gOut = Graphics.FromImage(output);
			gOut.DrawImage(src, 0, 0);
			gOut.Dispose();
		}
		#endregion
		
		#region Bitmapを位置を指定してコピー
		/// <summary>
		/// Bitmapをコピーする。
		/// </summary>
		/// <param name="src">もとの画像(Bitmap)</param>
		/// <param name="output">出力先の画像(Bitmap)</param>
		public void BitmapCopyXY(Bitmap src, Bitmap output, int x, int y)
		{
			Graphics gOut = Graphics.FromImage(output);
			gOut.DrawImage(src, x, y);
			gOut.Dispose();
		}
		#endregion
		
		#region Bitmapを位置とサイズを指定してコピー
		/// <summary>
		/// Bitmapをコピーする。
		/// </summary>
		/// <param name="src">もとの画像(Bitmap)</param>
		/// <param name="output">出力先の画像(Bitmap)</param>
		/// <param name="x">元画像から切り出す位置(X座標)</param>
		/// <param name="y">元画像から切り出す位置(Y座標)</param>
		/// <param name="width">元画像から幅</param>
		/// <param name="height">元画像から高さ(Bitmap)</param>
		public void BitmapCopyXYSize(Bitmap src, Bitmap output, int x, int y, int width, int height)
		{
			Graphics gOut = Graphics.FromImage(output);
			// 画像を切り出す矩形座標を設定する(ここでは左上からpictureBox2のサイズ分を指定)
			Rectangle rcDraw = new Rectangle(x, y, width, height);

			//gOut.DrawImage(src, x, y, width, height);
			gOut.DrawImage(src, 0, 0, rcDraw,GraphicsUnit.Pixel);
			
			gOut.Dispose();
		}
		#endregion
		
		#region Bitmapをストレッチコピー
		/// <summary>
		/// Bitmapをストレッチコピーする。
		/// もと画像を出力先画像のサイズに合わせてコピー
		/// </summary>
		/// <param name="src">元画像(Bitmap)</param>
		/// <param name="output">出力先画像(Bitmap)</param>
		public void BitmapStretchCopy(Bitmap src, Bitmap output)
		{
			Graphics gOut = Graphics.FromImage(output);
			
			gOut.InterpolationMode = InterpolationMode.NearestNeighbor;
			gOut.DrawImage(src, 0, 0, output.Width, output.Height);
			gOut.Dispose();
			
		}
		#endregion
		
		#region Bitmapをストレッチコピー
		/// <summary>
		/// Bitmapをストレッチコピーする。
		/// もと画像を出力先画像のサイズに合わせてコピー
		/// </summary>
		/// <param name="src">元画像(Bitmap)</param>
		/// <param name="output">出力先画像(Bitmap)</param>
		public void BitmapStretchCopyHQ(Bitmap src, Bitmap output)
		{
			Graphics gOut = Graphics.FromImage(output);
			
			gOut.InterpolationMode = InterpolationMode.HighQualityBicubic;
			gOut.DrawImage(src, 0, 0, output.Width, output.Height);
			gOut.Dispose();
			
		}
		#endregion
		
		#region Bitmapに外接枠をつける
		/// <summary>
		/// Bitmapに外接枠をつける。
		/// </summary>
		/// <param name="bmp">対象画像(Bitmap)</param>
		public void BitmapDrawFrame(Bitmap bmp)
		{
			Graphics gBmp = Graphics.FromImage(bmp);
			
			gBmp.DrawRectangle(Pens.Black, 0, 0, bmp.Width-1, bmp.Height-1);
			
			gBmp.Dispose();
		}
		#endregion
		
		#region Bitmapを白で塗りつぶす
		/// <summary>
		/// 画像を白で塗りつぶす。
		/// </summary>
		/// <param name="bmp">対象画像(Bitmap)</param>
		public void BitmapWhitening(Bitmap bmp)
		{
			//Graphicsへの継承
			Graphics gBitmap = Graphics.FromImage(bmp);
			
			//Whiteで初期化
			gBitmap.FillRectangle(Brushes.White, 0, 0, bmp.Width, bmp.Height);
			
			//Graphicsの開放
			gBitmap.Dispose();
		}
		#endregion
		
		#region Bitmapを指定色で塗りつぶす
		/// <summary>
		/// 画像を白で塗りつぶす。
		/// </summary>
		/// <param name="bmp">対象画像(Bitmap)</param>
		public void BitmapColoring(Bitmap bmp, Color c)
		{
			//Graphicsへの継承
			Graphics gBitmap = Graphics.FromImage(bmp);
			
			Brush b = new SolidBrush(c);
			//Whiteで初期化
			gBitmap.FillRectangle(b, 0, 0, bmp.Width, bmp.Height);
			
			//Graphicsの開放
			gBitmap.Dispose();
		}
		#endregion
		
		#region Bitmapを重ね合わせコピー
		/// <summary>
		/// 元画像に入力画像を重ね合わせコピーする。
		/// </summary>
		/// <param name="src">元画像(Bitmap)</param>
		/// <param name="input">入力画像(Bitmap)</param>
		public void BitmapImposeCopy(Bitmap src, Bitmap input)
		{
			Graphics g = Graphics.FromImage(src);
			
			input.MakeTransparent(Color.White);
			g.DrawImage(input, 0, 0, input.Width, input.Height);
			
			g.Dispose();
		}
		#endregion
		
		#region 2x2の点を打つ
		public void SetDoublePixel(Bitmap bmp, int x, int y)
		{
			Graphics g = Graphics.FromImage(bmp);
			g.FillRectangle(Brushes.Black, x, y, 2, 2);
			g.Dispose();
		}
		#endregion
		
		#region 色を比較する
		/// <summary>
		/// 色を比較する
		/// </summary>
		/// <param name="A">比較対象１（Color）</param>
		/// <param name="B">比較対象２（Color）</param>
		/// <returns>RGB全てが同じであればTrue　一つでも違っていればFalse　注意：A値は見ていない</returns>
		public bool ColorCompare(Color A, Color B)
		{
			bool iRet = false;
			
			if(A.R == B.R && A.G == B.G && A.B == B.B/** && A.A == B.A*/){
				iRet = true;
			}
			
			return(iRet);
		}
		#endregion
		
		#region 正規化を行う
		public void Normalize(Bitmap input, double R)
		{
			double r_ave, cXm, cYm, RRave;
			DoublePoint Gravi;
			int i, j, x, y;
			//double R = ((double)input.Height / 4.0) * 0.95;
			
			System.Diagnostics.Debug.WriteLine("Normalized");
			//キャンバスが真っ白だったらすぐ終了
			if(WhiteCanvasCheck(input) == false){
				return;
			}
			
			Bitmap bmp = new Bitmap(input.Width, input.Height);
			
			cXm = ((double) input.Width / 2.0);
			cYm = ((double) input.Height / 2.0);
			
			Gravi = GetGravityPointDouble(input);
			r_ave = TowMorment(input, Gravi);
			
			if(Double.IsNaN(r_ave)){
				return;
			}
			RRave = r_ave / R;
			
			for( j = 0; j < input.Height; j++){
				for( i = 0; i < input.Width; i++){
					x = (int)(RRave * ( (double)i - cXm) + Gravi.X);
					y = (int)(RRave * ( (double)j - cYm) + Gravi.Y);
					if( (x >= 0) && (x < input.Width) && (y >= 0) && (y < input.Height)){
						if( ColorCompare(input.GetPixel(x, y), Color.Black) == true){
							bmp.SetPixel( i, j, Color.Black);
						}
					}
				}
			}
			
			BitmapWhitening(input);
			BitmapCopy(bmp, input);
		}
		#endregion
		
		#region ２次モーメントの算出
		private double TowMorment(Bitmap bmp, DoublePoint GravPoint)
		{
			int i,j,sum;
			double r_ave;
			double sX, sY;
			
			sum = 0;
			r_ave = 0.0;
			
			for(j = 0; j < bmp.Height; j++){
				for(i = 0; i < bmp.Width; i++){
					if(ColorCompare( bmp.GetPixel(i, j), Color.Black) == true){
						sum++;
						sX = (double)i - GravPoint.X;
						sY = (double)j - GravPoint.Y;
						r_ave = r_ave + Math.Sqrt(Math.Pow(sX, 2) + Math.Pow(sY, 2));
					}
				}
			}
			
			r_ave = r_ave / (double)sum;
			return(r_ave);
		}
		#endregion
		
		#region 画素の0,1判定
		private int PointCheck(Bitmap bmp, int x, int y)
		{
			int iRet = 0;
			
			if(ColorCompare(bmp.GetPixel(x, y), Color.White) != true){
				iRet = 1;
			}
			return(iRet);
		}
		#endregion
		
		#region 重心を計算する(double版)
		public DoublePoint GetGravityPointDouble(Bitmap bmp)
		{
			// 重心を求める
            int i, j, sum_a, sum_b;
            DoublePoint GravityP = new DoublePoint();
            Color c;

            // x軸方向の重心

            sum_a = 0;	sum_b = 0;
            for(i = 0; i < bmp.Width; i++){
                for(j = 0; j < bmp.Height; j++){
            		c = bmp.GetPixel(i, j);
            		if(ColorCompare(c, Color.White) == false){
                        sum_a += i;
                        sum_b ++;
                    }
                }
            }
            GravityP.X = (sum_b != 0) ? (double)((double)sum_a / (double)sum_b) : 0.0;
            
            // y軸方向の重心
            sum_a = 0;	sum_b = 0;
            for(i = 0; i < bmp.Width; i++){
                for(j = 0; j < bmp.Height; j++){
            		c = bmp.GetPixel(i, j);
            		if(ColorCompare(c, Color.White) == false){
            			sum_a += j;
                        sum_b ++;
                    }
                }
            }
            GravityP.Y = (sum_b != 0) ? (double)((double)sum_a / (double)sum_b) : 0.0;

            return(GravityP);
		}
		#endregion

		#region 重心を計算する
		public Point GetGravityPoint(Bitmap bmp)
		{
			// 重心を求める
			int i, j, sum_a, sum_b;
			Point GravityP = new Point();
			Color c;

			// x軸方向の重心

			sum_a = 0; sum_b = 0;
			for (i = 0; i < bmp.Width; i++)
			{
				for (j = 0; j < bmp.Height; j++)
				{
					c = bmp.GetPixel(i, j);
					if (c.R != Color.White.R || c.G != Color.White.G || c.B != Color.White.B)
					{
						sum_a += i;
						sum_b++;
					}
				}
			}
			GravityP.X = (sum_b != 0) ? sum_a / sum_b : 0;

			// y軸方向の重心
			sum_a = 0; sum_b = 0;
			for (i = 0; i < bmp.Width; i++)
			{
				for (j = 0; j < bmp.Height; j++)
				{
					c = bmp.GetPixel(i, j);
					if (c.R != Color.White.R || c.G != Color.White.G || c.B != Color.White.B)
					{
						sum_a += j;
						sum_b++;
					}
				}
			}
			GravityP.Y = (sum_b != 0) ? sum_a / sum_b : 0;

			return (GravityP);
		}
		#endregion

		#region Top点・Bottom点を抽出
		/// <summary>
		/// 2021.10.03 D.Honjyou
		/// 頂点と底点を返す
		/// </summary>
		/// <param name="bmp"></param>
		/// <returns></returns>
		public Point [] GetTopBotomPoint(Bitmap bmp)
		{
			// 重心を求める
            int i, j, sum_a, sum_b;
            Point [] TBPoint = new Point[2];
			int maxx, minx, maxy, miny;
			Color c;

			maxx = 0;
			minx = 9999;
			maxy = 0;
			miny = 9999;
            
            // x軸方向の重心

            sum_a = 0;	sum_b = 0;
            for(j = 0; j < bmp.Height; j++)
			{
				for (i = 0; i < bmp.Width; i++)
				{
					c = bmp.GetPixel(i, j);
					if (!ColorCompare(c, Color.White))
					{
						if (miny > j)
						{
							miny = j;
							minx = i;
						}
						if (maxy < j)
						{
							maxy = j;
							maxx = i;
						}
					}	
                }
            }

			TBPoint[0].X = minx;TBPoint[0].Y = miny;
			TBPoint[1].X = maxx;TBPoint[1].Y = maxy;

            return(TBPoint);
		}
		#endregion
		
		#region センターラインの描画
		public void DrawCenterLine(Bitmap bmp, Color c){
			//Graphicsへの継承
			Graphics gBitmap = Graphics.FromImage(bmp);
			Pen p = new Pen(c);
			
			//センターラインの描画
			gBitmap.DrawLine(p, (float)(bmp.Width / 2.0), 0, (float)(bmp.Width / 2.0), bmp.Height);
			gBitmap.DrawLine(p, 0, (float)(bmp.Height / 2.0), bmp.Width, (float)(bmp.Height / 2.0));
			
			//Graphicsの開放
			gBitmap.Dispose();
		}
		#endregion
		
		#region 8x8ラインの描画
		public void Draw8x8Line(Bitmap bmp, Color c){
			//Graphicsへの継承
			Graphics gBitmap = Graphics.FromImage(bmp);
			Pen p = new Pen(c);
			
			for(int i=0; i<7; i++){
				//センターラインの描画
				gBitmap.DrawLine(p, (float)(bmp.Width / 8.0)*(i+1), 0, (float)(bmp.Width / 8.0)*(i+1), bmp.Height);
				gBitmap.DrawLine(p, 0, (float)(bmp.Height / 8.0)*(i+1), bmp.Width, (float)(bmp.Height / 8.0)*(i+1));
			}
			//Graphicsの開放
			gBitmap.Dispose();
		}
		public void Draw8x8x4Line(Bitmap bmp, Color c){
			//Graphicsへの継承
			Graphics gBitmap = Graphics.FromImage(bmp);
			Pen p = new Pen(c);
			
			for(int i=0; i<31; i++){
				//センターラインの描画
				gBitmap.DrawLine(p, (float)(bmp.Width / 32.0)*(i+1), 0, (float)(bmp.Width / 32.0)*(i+1), bmp.Height);
				gBitmap.DrawLine(p, 0, (float)(bmp.Height / 8.0)*(i+1), bmp.Width, (float)(bmp.Height / 8.0)*(i+1));
			}
			//Graphicsの開放
			gBitmap.Dispose();
		}
		#endregion
		
		#region ノイズ除去
		public void Median(Bitmap srcBmp)
        {
			double[] data = new double[25];
			Bitmap outBmp = new Bitmap(srcBmp.Width, srcBmp.Height);
			BitmapCopy(srcBmp, outBmp);

			for (int m = 2; m < srcBmp.Height - 2; m++)
			{
				for (int n = 2; n < srcBmp.Width - 2; n++)
				{
					for (int j = 0; j < 5; j++)
					{
						for (int i = 0; i < 5; i++)
						{
							data[5 * j + i] = ColorCompare(srcBmp.GetPixel(i + n - 2, j + m - 2), Color.White) ? 0 : 1;
						}
					}
					if (data.Median() > 0)
                    {
						outBmp.SetPixel(n, m, Color.Black);
					}
                    else
                    {
						outBmp.SetPixel(n, m, Color.White);
					}
				}

			}
			System.Diagnostics.Debug.WriteLine($"Median = {data.Median()}");
			BitmapCopy(outBmp, srcBmp);
		}
		public void Noize(Bitmap srcBmp)
		{
			int j,k,l,m,sum;
			int a,b,c,d,e;
			Bitmap outBmp = new Bitmap(srcBmp.Width, srcBmp.Height);
			BitmapCopy(srcBmp, outBmp);
			
			for(j = 1; j < outBmp.Height - 1; j++){
				for(k = 1; k < outBmp.Width - 1; k++){
					//細線化すると色が黒になってしまうバグ対応
					//2011.06.07 D.Honjyou
					//a = ColorCompare(outBmp.GetPixel(k, j), Color.Black) ? 1 : 0;
					//b = ColorCompare(outBmp.GetPixel(k, j-1), Color.Black) ? 1 : 0; 
					//c = ColorCompare(outBmp.GetPixel(k, j+1), Color.Black) ? 1 : 0; 
					//d = ColorCompare(outBmp.GetPixel(k-1, j), Color.Black) ? 1 : 0; 
					//e = ColorCompare(outBmp.GetPixel(k+1, j), Color.Black) ? 1 : 0; 
					a = ColorCompare(outBmp.GetPixel(k, j), Color.White) ? 0 : 1; 
					b = ColorCompare(outBmp.GetPixel(k, j-1), Color.White) ? 0 : 1; 
					c = ColorCompare(outBmp.GetPixel(k, j+1), Color.White) ? 0 : 1; 
					d = ColorCompare(outBmp.GetPixel(k-1, j), Color.White) ? 0 : 1; 
					e = ColorCompare(outBmp.GetPixel(k+1, j), Color.White) ? 0 : 1; 
					if(a==1 && (b+c+d+e)==0) outBmp.SetPixel(k, j, Color.White);
				}
			}
			for(j = 2; j < outBmp.Height - 2; j += 5){
				for(k = 2; k < outBmp.Width - 2; k += 5){
					if(ColorCompare(outBmp.GetPixel(k, j), Color.White)!=true){
						sum=0;a=0;b=0;c=0;d=0;
						
						for(l=(-2);l<3;l++){
							for(m=(-2);m<3;m++){
								sum += ColorCompare(outBmp.GetPixel(k + m, j + l), Color.White) ? 0 : 1;
							}
						}
						for(l=(-2);l<3;l++){
							c += ColorCompare(outBmp.GetPixel(k - 2, j + l), Color.White) ? 0 : 1;
							d += ColorCompare(outBmp.GetPixel(k + 2, j + l), Color.White) ? 0 : 1;
						}
						for(m=(-2);m<3;m++){
							a += ColorCompare(outBmp.GetPixel(k + m, j - 2), Color.White) ? 0 : 1;
							b += ColorCompare(outBmp.GetPixel(k + m, j + 2), Color.White) ? 0 : 1;
						}
						if(sum<10 && a==0 && b==0 && c==0 && d==0){
							for(l=(-2);l<3;l++){
								for(m=(-2);m<3;m++){
									outBmp.SetPixel(k + m, j + l, Color.White);
								}
							}
						}
					}
				}
			}
			BitmapCopy(outBmp, srcBmp);
		}
		#endregion
		
		#region 射影を行う
		public void DrawProjection(Bitmap srcBmp, Bitmap outBmp, Color c)
		{
			int PointNum;
			int i, j;
			Point [] SyaeiPsY = new Point[srcBmp.Height];
			Point [] SyaeiPsX = new Point[srcBmp.Width];
			Pen p = new Pen(c);
			Graphics gBitmap = Graphics.FromImage(outBmp);
			
			//BitmapCopy(srcBmp, outBmp);
			//縦方向射影
			for(i=0; i < srcBmp.Width; i++){
				PointNum = 0;
				for(j=0; j < srcBmp.Height; j++){
					//if( ColorCompare( srcBmp.GetPixel(i, j), Color.Black) == true){
					if( ColorCompare( srcBmp.GetPixel(i, j), c) == true){
						PointNum++;
					}
				}
				SyaeiPsX[i] = new Point(i, outBmp.Height - PointNum -1);
				//System.Diagnostics.Debug.WriteLine(i.ToString() + ":" + PointNum.ToString() + ";" + SyaeiPsX[i].ToString());
				//gBitmap.DrawLine(Pens.Blue, i, outBmp.Height - 1, i, outBmp.Height - PointNum -1);
			}
			//横方向射影
			for(j=0; j < srcBmp.Height; j++){
				PointNum = 0;
				for(i=0; i < srcBmp.Width; i++){
					//if( ColorCompare( srcBmp.GetPixel(i, j), Color.Black) == true){
					if( ColorCompare( srcBmp.GetPixel(i, j), c) == true){
						PointNum++;
					}
				}
				SyaeiPsY[j] = new Point(outBmp.Width - PointNum -1, j);
				//gBitmap.DrawLine(Pens.Red, outBmp.Width - 1, j, outBmp.Width - PointNum -1, j);
			}
			gBitmap.DrawLines(p, SyaeiPsY);
			gBitmap.DrawLines(p, SyaeiPsX);
			
			gBitmap.Dispose();
		}
		#endregion
		
		#region 標本化を行う
		public void DrawSampling(Bitmap srcBmp, Bitmap outBmp, Color c, int size)
		{
			int i,j,m,n;
			int sum;
			
			if(size == 0){
				size = 1;
			}
			int x_size = srcBmp.Width / size;
			int y_size = srcBmp.Height / size;
			
			double dr = (255.0 - (double)c.R)/25.0;
			double dg = (255.0 - (double)c.G)/25.0;
			double db = (255.0 - (double)c.B)/25.0;
			
			Graphics gBitmap = Graphics.FromImage(outBmp);
			SolidBrush br = new SolidBrush(Color.Black);
			
			for(j=0; j<y_size; j++){
				for(i=0; i<x_size; i++){
				    sum = 0;
				    for(n=0; n<(srcBmp.Height / y_size); n++){
				    	for(m=0; m<(srcBmp.Width / x_size); m++){
				    		if(ColorCompare(srcBmp.GetPixel(i*srcBmp.Width/x_size+m, j*srcBmp.Height/y_size+n), Color.White) != true){
				    			sum++;
				    		}
				    	}
				    }
				    if(sum < 25){
				    	br = new SolidBrush(Color.FromArgb(255 - sum*(int)dr, 255 - sum*(int)dg, 255 - sum*(int)db));
				    }else{
				    	br = new SolidBrush(c);
				    }
				    gBitmap.FillRectangle(br, i*srcBmp.Width/x_size, j*srcBmp.Height/y_size, i*srcBmp.Width/x_size+srcBmp.Width / x_size, j*srcBmp.Height/y_size+srcBmp.Height / y_size);
				}
			}
			gBitmap.Dispose();
		}
		#endregion
		
		#region 輪郭線追跡を行う
		
		//開始点から追跡
		private void Following(Bitmap bmp,int x,int y,int d, Color c)
		{
			// 現在のx座標、現在のy座標、データ配列
			int [] py = new int[8] {0,1,1,1,0,-1,-1,-1};
			int [] px = new int[8] {-1,-1,0,1,1,1,0,-1};
			int tx, ty;
			int k, n = d, t, wx = 0, wy = 0, x1, y1, sx, sy;
			int C = 1000;	//十分大きな値（整数）
			
			//終了位置の設定（追跡開始点）
			sx = x;
			sy = y;
			//反時計回りに調べる-初めの位置(sx,sy)に戻ってきたらループを抜ける
			//開始点より追跡開始
			for(t = 0; t < C; t++){
				//前回にラベルを付けた位置
				wx = x;	
				wy = y;
				k = 0;
				while(k < 8){
					//もしループ回数が8回を満たしていなければ満たすようにする
					if(n == 8) n = 0;
					//終了判定・追跡開始点と現在の位置が一致すれば戻る。
					if(sx == x + px[n] && sy == y + py[n]){
						return;//もし同じであればラスタスキャンへ戻る	
					}
					tx = x + px[n];
					ty = y + py[n];
					if(tx >= 0 && ty >=0 && tx < bmp.Width && ty < bmp.Height){
						if(ColorCompare(bmp.GetPixel(tx, ty),Color.White) != true){
							bmp.SetPixel(tx, ty, c);
							x = tx;	//ラベルを付けた場所(現在の位置)：x座標
							y = ty;	//ラベルを付けた場所(現在の位置)：y座標
							break;
						}
					}
					k++;
					n++;
				}
				//現在のラベル位置と前回のラベル位置の差を見る
				x1 = wx - x;
				y1 = wy - y;
				//スタート地点の決定
				for(k = 0; k < 8; k++){
					if(px[k] == x1 && py[k] == y1) n = k + 1;
				}
				//for(wa=0;wa<10000*(99-Rin_speed);wa++);
			}
		}
		//輪郭線追跡
		public void DrawEdgeFollowing(Bitmap srcBmp, Bitmap outBmp, Color c)
		{
			int i,j;
			BitmapCopy(srcBmp, outBmp);
			
			//順方向ラスタ(0-1)
			for(j = 0; j < outBmp.Height; j++){
				for(i = 0; i < outBmp.Width - 1; i++){
					//｛0－1｝の並びを探す
					if(ColorCompare(outBmp.GetPixel(i, j), Color.White) == true && ColorCompare(outBmp.GetPixel(i+1, j), Color.Black) == true){
						outBmp.SetPixel(i + 1, j, c);
						//data[j][i+1]=7;//ラベルを付ける
						//Rinkaku_View(hwnd,i,j-1);
						//ラベルを付けた場所（出発点）から追跡開始
						Following(outBmp, i + 1, j, 0, c);
						//kyoukai(hwnd,i+1,j,data,0);
					}
				}
			}
			
			//if(cif != null)cif.StatusProgressBarChange(2);
			
			//逆方向ラスタ(0-1)
			for(j = outBmp.Height - 1; j > 0; j--){
				for(i = outBmp.Width - 1; i > 1; i--){
					//｛0－1｝の並びを探す
					if(ColorCompare(outBmp.GetPixel(i, j), Color.White) == true && ColorCompare(outBmp.GetPixel(i-1, j), Color.Black) == true){
						outBmp.SetPixel(i - 1, j, c);
						//data[j][i-1]=7;//ラベルを付ける
						//Rinkaku_View(hwnd,i-2,j-1);
						//ラベルを付けた場所（出発点）から追跡開始
						Following(outBmp, i - 1, j, 4, c);
						//kyoukai(hwnd,i-1,j,data,4);
					}
				}
			}
			
			//if(cif != null)cif.StatusProgressBarChange(3);
			
			//縦方向ラスタ(0-1)
			for(j = 0; j < outBmp.Height - 1; j++){
				for(i = 0; i < outBmp.Width; i++){
					//｛0－1｝の並びを探す
					if(ColorCompare(outBmp.GetPixel(i, j), Color.White) == true && ColorCompare(outBmp.GetPixel(i, j+1), Color.Black) == true){
						outBmp.SetPixel(i, j + 1, c);
						//data[j+1][i]=7;//ラベルを付ける
						//Rinkaku_View(hwnd,i-1,j);
						//ラベルを付けた場所（出発点）から追跡開始
						Following(outBmp, i, j + 1, 6, c);
						//kyoukai(hwnd,i,j+1,data,6);
					}
				}
			}

			//if(cif != null)cif.StatusProgressBarChange(4);
			
			//下方向ラスタ(0-1)
			for(j = outBmp.Height - 1; j > 1; j--){
				for(i = outBmp.Width - 1; i > 0; i--){
					//｛0－1｝の並びを探す
					if(ColorCompare(outBmp.GetPixel(i, j), Color.White) == true && ColorCompare(outBmp.GetPixel(i, j-1), Color.Black) == true){
						outBmp.SetPixel(i, j - 1, c);
						//data[j-1][i]=7;//ラベルを付ける
						//Rinkaku_View(hwnd,i-1,j-2);
						//ラベルを付けた場所（出発点）から追跡開始
						Following(outBmp, i, j - 1, 2, c);
						//kyoukai(hwnd,j-1,i,data,2);
					}
				}
			}
			
			//if(cif != null)cif.StatusProgressBarChange(5);
			
		}		
		#endregion
		
		#region ラベリングを行う
		private void LabelingProc(Color [,] work, int size_x, int size_y, int x, int y, Color c, int proc)
		{
			int x1,x2,y1,y2,wx,wy;
	
			x1=x + 1; y1=y;
			x2=x - 1; y2=y;
			
	
			//右画素が０になったらループを抜ける
			if(x1 < size_x){
				while(work[y1, x1] == Color.Black){
					work[y1, x1] = c;
					//Label_View(hwnd,x1-1,y1-1,k);
					x1++;
					if(x1 >= size_x) break;
				}
			}
			//左画素が０になったらループを抜ける
			if(x2 > 0){
				while(work[y2, x2] == Color.Black){
					work[y2, x2] = c;
					//Label_View(hwnd,x2-1,y2-1,k);
					x2--;
					if(x2 <= 0) break;
				}
			}
			//右端の画素の位置から上下を調べる
			wx=x1-1;
			wy=y1;
			//Debug.WriteLine( wx.ToString() + "," + wy.ToString());
			while(x2!=wx && wx >= 0 && wx < size_x){
				//下の画素を調べる
				if(wy + 1 < size_y && wx > 0){
					if(work[wy+1, wx] == Color.Black){
						work[wy+1, wx] = c;
						//	Label_View(hwnd,wx-1,wy,k);
						LabelingProc(work, size_x, size_y, wx, wy + 1, c, proc);
					}
				}

				//上の画素を調べる
				if(wy - 1 >= 0 && wx > 0){
					if(work[wy-1, wx] == Color.Black){
						work[wy-1, wx] = c;
						//Label_View(hwnd,wx-1,wy-2,k);
						LabelingProc(work, size_x, size_y, wx, wy - 1, c, proc);
					}
				}
				/**
				//８近傍の場合
				if(Label_Kinbo==TRUE){
					//右下の画素を調べる
					if(data[wy+1][wx+1]==1){
						data[wy+1][wx+1]=k;
						Label_View(hwnd,wx,wy,k);
						labeling(hwnd,wx+1,wy+1,data,k);
					}
					//右上の画素を調べる
					if(data[wy-1][wx+1]==1){
						data[wy-1][wx+1]=k;
						Label_View(hwnd,wx,wy-2,k);
						labeling(hwnd,wx+1,wy-1,data,k);
					}
					//左下の画素を調べる
					if(data[wy+1][wx-1]==1){
						data[wy+1][wx-1]=k;
						Label_View(hwnd,wx-2,wy,k);
						labeling(hwnd,wx-1,wy+1,data,k);
					}
					//左上の画素を調べる
					if(data[wy+1][wx+1]==1){
						data[wy-1][wx-1]=k;
						Label_View(hwnd,wx-2,wy-2,k);
						labeling(hwnd,wx-1,wy-1,data,k);
					}
				}
				***/
				wx--;
			}
		}
		public void DrawLabeling(Bitmap srcBmp, Bitmap outBmp, int proc)
		{
			int i,j,k;
			Color [] LabelColor = {Color.Blue, Color.Green, Color.Red, Color.Gold, Color.MediumPurple, Color.OrangeRed,
								Color.LightSkyBlue, Color.Pink, Color.SaddleBrown, Color.DimGray};
			
			Color [,] work = new Color[srcBmp.Height, srcBmp.Width];
			
			Bitmap workBmp = new Bitmap(srcBmp.Width, srcBmp.Height);
			
			BitmapCopy(srcBmp, workBmp);
			
			//初期画像を配列に格納
			for(j = 0; j < workBmp.Height-1; j++){
				for(i = 0; i < workBmp.Width-1; i++){
					if(ColorCompare(srcBmp.GetPixel(i, j), Color.Black) == true){
						work[j, i] = Color.Black;
					}else{
						work[j, i] = Color.White;
					}
				}
			}
			
			k = 0;
			//順方向ラスタ(0-1)
			for(j = 0; j < workBmp.Height-1; j++){
				for(i = 0; i < workBmp.Width-1; i++){
					//{0-1}の並びを探す
					if(i == 0 && work[j, i] == Color.Black){
						//outBmp.SetPixel(i + 1, j, LabelColor[k]);
						work[j, i+1] = LabelColor[k];
						LabelingProc(work, workBmp.Width, workBmp.Height, i+1, j, LabelColor[k], proc);
						k++;
						if(k >= LabelColor.Length){
							k = 0;
						}
					}else if(work[j, i] == Color.White && work[j, i+1] == Color.Black){
						work[j, i+1] = LabelColor[k];
						LabelingProc(work, workBmp.Width, workBmp.Height, i+1, j, LabelColor[k], proc);
						k++;
						if(k >= LabelColor.Length){
							k = 0;
						}
					}
				}
			}
			
			//画像に戻す
			BitmapWhitening(workBmp);
			
			for(j = 0; j < workBmp.Height; j++){
				for(i = 0; i < workBmp.Width; i++){
					workBmp.SetPixel(i, j, work[j, i]);
				}
			}
			
			BitmapStretchCopy(workBmp, outBmp);
			workBmp.Dispose();
			//Label_Box_View(hwnd,data,k);
		}
		
		#endregion
		
		#region 距離変換を行う
		#region 最小値を求める
		public int Dist_Min(int a, int b, int c)
		{
			int mini;
			if(a <= b && a <= c) mini=a;
			else if(b <= a && b <= c) mini=b;
			else mini = c;
			return (mini);
		}
		#endregion
		
		#region 最大値を求める
		public int Dist_Max(int a ,int b ,int c ,int d)
		{
			int max;

			if(a>b && a>c && a>d) max = a;
			else if(b>a && b>c && b>d) max = b;
			else if(c>a && c>b && c>d) max = c;	
			else max = d;
		
			return(max);
		}
		#endregion

		public void DrawDistance(Bitmap srcBmp, Bitmap outBmp, Color c, int proc)
		{
			int [,] s = new int[srcBmp.Height, srcBmp.Width];
			int [,] g = new int[srcBmp.Height, srcBmp.Width];
			int [,] h = new int[srcBmp.Height, srcBmp.Width];
			int [,] k = new int[srcBmp.Height, srcBmp.Width];
						
			Bitmap gBmp = new Bitmap(srcBmp.Width, srcBmp.Height);
			Bitmap hBmp = new Bitmap(srcBmp.Width, srcBmp.Height);
			Bitmap iBmp = new Bitmap(srcBmp.Width, srcBmp.Height);
			
			Bitmap workBmp = new Bitmap(srcBmp.Width, srcBmp.Height);
			
			BitmapWhitening(workBmp);
			
			int i, j;
			int p1, p2, p3, p4;
			int max = 0;
			
			#region 1st Step 初期画像の作成
			//g(i,j); h(i,j); i(i,j)の初期化
			for(j = 0; j < srcBmp.Height; j++){
				for(i = 0; i < srcBmp.Width; i++){
					if(ColorCompare(srcBmp.GetPixel(i, j), Color.White) == true){
						//gBmp.SetPixel(i, j, Color.FromArgb(0,0,0));
						g[j,i] = 0;
						s[j,i] = 0;
					}else{
						g[j,i] = 255;
						s[j,i] = 1;
						//gBmp.SetPixel(i, j, Color.FromArgb(255,0,0));
					}
					h[j,i] = 0;
					k[j,i] = 0;
					//hBmp.SetPixel(i, j, Color.FromArgb(0,0,0));
					//iBmp.SetPixel(i, j, Color.FromArgb(0,0,0));
					
				}
			}		
			#endregion
			
			//if(cif != null)cif.StatusProgressBarChange(2);
			
			#region 2nd Step １回目の処理画像を求める
			for(j = 0; j < srcBmp.Height; j++){
				for(i = 0; i < srcBmp.Width; i++){
					/***
					p1 = ( i > 0 && j > 0) ? (int)gBmp.GetPixel(i - 1, j - 1).R : 0;
					p2 = ( j > 0 ) ? (int)hBmp.GetPixel(i, j - 1).R : 0;
					p3 = ( i > 0 ) ? (int)hBmp.GetPixel(i - 1, j).R : 0;
					p4 = ( i > 0 && j > 0) ? ((ColorCompare(srcBmp.GetPixel(i, j),Color.White) == true) ? 0 : 1) : 0;
					***/
					p1 = ( i > 0 && j > 0) ? g[j-1, i-1] : 0;
					p2 = ( j > 0 ) ? h[j-1, i] : 0;
					p3 = ( i > 0 ) ? h[j, i-1] : 0;
					p4 = ( i > 0 && j > 0) ? ((s[j, i] == 0) ? 0 : 1) : 0;
					
					//hBmp.SetPixel(i, j, Color.FromArgb(Dist_Min(p1, p2 + p4, p3 + p4), 0, 0));
					h[j, i] = Dist_Min(p1, p2 + p4, p3 + p4);
				}
			}
			#endregion
			
			//if(cif != null)cif.StatusProgressBarChange(3);
			
			#region 3rd Step 距離変換画像を求める
			for(j = srcBmp.Height - 1; j > 0; j--){
				for(i = srcBmp.Width - 1; i > 0; i--){
					/***
					p1 = (int)hBmp.GetPixel(i, j).R;
					p2 = ( j < srcBmp.Height - 1 ) ? (int)iBmp.GetPixel(i, j + 1).R : 0;
					p3 = ( i < srcBmp.Width  - 1 ) ? (int)iBmp.GetPixel(i + 1, j).R : 0;
					p4 = ( i > 0 && j > 0) ? ((ColorCompare(srcBmp.GetPixel(i, j),Color.White) == true) ? 0 : 1) : 0;
					***/
					p1 = h[j, i];
					p2 = ( j < srcBmp.Height - 1 ) ? k[j+1, i] : 0;
					p3 = ( i < srcBmp.Width  - 1 ) ? k[j, i+1] : 0;
					p4 = ( i > 0 && j > 0) ? ((s[j, i] == 0) ? 0 : 1) : 0;
					
					//iBmp.SetPixel(i, j, Color.FromArgb(Dist_Min(p1, p2 + p4, p3 + p4), 0, 0));
					k[j, i] = Dist_Min(p1, p2 + p4, p3 + p4);
				}
			}
			#endregion
			
			//if(cif != null)cif.StatusProgressBarChange(4);
			
			#region 最大値を探す
			for(j = 0; j < srcBmp.Height; j++){
				for(i = 0; i < srcBmp.Width; i++){
					//p1 = (int) iBmp.GetPixel(i, j).R;
					p1 = k[j, i];
					if( p1 > max ) max = p1;
				}
			}
			#endregion
			
			//if(cif != null)cif.StatusProgressBarChange(5);
			
			#region 出力画像へ色を変えて転送
			float r1,g1,b1;
			
			r1 = (float)c.R;
			g1 = (float)c.G;
			b1 = (float)c.B;
			//System.Diagnostics.Debug.WriteLine(r1.ToString()+","+g1.ToString()+","+b1.ToString()+":max="+max.ToString());
			for(j = 0; j < srcBmp.Height; j++){
				for(i = 0; i < srcBmp.Width; i++){
					//p1 = (int) iBmp.GetPixel(i, j).R;
					p1 = k[j, i];
					r1 = (float)c.R - (float)p1 * ((float)c.R / max);
					if(r1 < 0) r1 = 0;
					g1 = (float)c.G - (float)p1 * ((float)c.G / max);
					if(g1 < 0) g1 = 0;
					b1 = (float)c.B - (float)p1 * ((float)c.B / max);
					if(b1 < 0) b1 = 0;
					//if(p1 > 0)System.Diagnostics.Debug.WriteLine(p1.ToString() + ":"+r1.ToString()+",(255-"+p1.ToString()+"*("+c.B.ToString()+"/"+max.ToString()+")"+g1.ToString()+","+b1.ToString());
					if(p1 == 0)	workBmp.SetPixel(i, j, Color.White);
					else			workBmp.SetPixel(i, j, Color.FromArgb((int)r1, (int)g1, (int)b1));
					/**
					if((255 - p1 * ( 256 / max )) < 0){
						workBmp.SetPixel(i, j, Color.FromArgb(0, 255, 255));
					}else{
						workBmp.SetPixel(i, j, Color.FromArgb(255 - p1 * ( 256 / max ), 255, 255));
					}
					**/
					//Debug.Write(p1.ToString() + ",");
				}
				//System.Diagnostics.Debug.Write("\n");
				//Debug.Write("\n");
			}
			#endregion
			
			BitmapStretchCopy(workBmp, outBmp);
			workBmp.Dispose();
			//if(cif != null)cif.StatusProgressBarChange(6);
			
			//Debug.WriteLine("---AllEnd---!" + DateTime.Now.ToString());
			
			//BitmapCopy(iBmp, outBmp);
		}
		#endregion
		
		#region ドット色を変える
		public void DotChange(Bitmap bmp, Color c)
		{
			int i,j;
			Color GetC;
			
			for(j=0; j<bmp.Height; j++){
				for(i=0; i<bmp.Width; i++){
					GetC = bmp.GetPixel(i, j);
					
					if(ColorCompare(GetC, Color.White) != true && ColorCompare(GetC, c) != true){
						//System.Diagnostics.Debug.Write(GetC.ToString());
						bmp.SetPixel(i, j, c);
						
					}
				}
			}
		}
		#endregion

		#region 縦横比を算出する
		/// <summary>
		/// 縦横比を算出する。（出力は縦/横）
		/// 白画素以外であれば、対象画像として算出
		/// </summary>
		/// <param name="bmp"></param>
		public double GetAspect(Bitmap bmp)
		{
			int i, j;
			Color GetC;
			int minx, miny, maxx, maxy;

			minx = 999;
			miny = 999;
			maxx = 0;
			maxy = 0;

			for (j = 0; j < bmp.Height; j++)
			{
				for (i = 0; i < bmp.Width; i++)
				{
					GetC = bmp.GetPixel(i, j);

					if (ColorCompare(GetC, Color.White) != true)
					{
						if (maxx < i) maxx = i;
						if (maxy < j) maxy = j;
						if (minx > i) minx = i;
						if (miny > j) miny = j;
					}
				}
			}
			return (((double)(maxy - miny)) / (double)(maxx - minx));
		}
		#endregion

		#region 細線化を行う

		#region 細線化サーチ処理
		public void S_search(int[,] b,int x,int y,int[,] be)
		{
			byte [] c = new byte[9];
			byte [] cp = new byte[9];
			byte [] xi = new byte[9];
			
			// 8連結データ配列
			int [] py = new int[9] {0,-1,-1,-1,0,1,1,1,0};
			int [] px = new int[9] {1,1,0,-1,-1,-1,0,1,1};

			int i,n2,n1,s1,s2,s3,k,m,bx;
			
			n2=n1=s1=s2=s3=m=0;
	
	
			// 条件2：境界画素である条件
			for(i=0;i<8;i=i+2)
			{
				s1+=1-Math.Abs(b[y+py[i],x+px[i]]);
			}
	
			// 条件3：端点を削除しない条件
			for(i=0;i<8;i++)
			{
				s2+=Math.Abs(b[y+py[i],x+px[i]]);
			}
	
			// 条件4：孤立点を保存する条件
			// Ckの決定
			for(i=0;i<8;i++)
			{	
				if(b[y+py[i],x+px[i]] == 1) c[i]=1;
				else c[i]=0;
			}	
			for(i=0;i<8;i++)
			{
				s3+=c[i];
			}
	
			// 条件5：連結性を保存する条件
			for(i=0;i<9;i++)
			{
				if(Math.Abs(b[y+py[i],x+px[i]]) == 1) cp[i]=1;
				else cp[i]=0;
			}
			// Nc8(p0)を求める
			for(i=0;i<8;i=i+2)
				n1+=((1-Math.Abs(cp[i]))-(1-Math.Abs(cp[i]))*(1-Math.Abs(cp[i+1]))*(1-Math.Abs(cp[i+2])));

			// 条件6：線幅2に対する片側削除条件

			// 格納
			for(i=0;i<9;i++)
			{
				xi[i]=(byte)Math.Abs(b[y+py[i],x+px[i]]);
			}
			m=0;
			for(i=0;i<8;i++)
			{
				n2=0;
				bx=xi[i];
				xi[i]=0;// 0とする
				// Nc8(p0)を求める
				for(k=0;k<8;k=k+2)
					n2+=((1-Math.Abs(xi[k]))-(1-Math.Abs(xi[k]))*(1-Math.Abs(xi[k+1]))*(1-Math.Abs(xi[k+2])));
				// もとにもどす
				xi[i]=(byte)bx;

				if(n2==1 || b[y+py[i],x+px[i]]!=-1)
				{
					m++;
				}
			}
	
			//B(i,j)を-1にする(条件1から条件6をすべて満たすもの）
			if(b[y,x]==1 && s1>=1 && s2>=2 && s3>=1 && n1==1 && m==8)
				b[y,x]=-1;
		}
		#endregion
		
		#region 細線化メイン処理
		public void DrawTinning(Bitmap srcBmp, Bitmap outBmp, Color c)
		{
			int i,j,m,check;
			Color GetC = Color.White;
			int [,] b = new int[srcBmp.Height + 2, srcBmp.Width + 2];
			int [,] be = new int[srcBmp.Height + 2, srcBmp.Width + 2];
			Bitmap workBmp = new Bitmap(srcBmp.Width, srcBmp.Height);
			
			BitmapWhitening(workBmp);
			
			//準備
			for(i=0;i<srcBmp.Height+2;i++)
			{
				for(j=0;j<srcBmp.Width+2;j++)
				{
					b[i,j]=0;be[i,j]=0;
				}
			}
			for(i=0;i<srcBmp.Height;i++)
			{
				for(j=0;j<srcBmp.Width;j++)
				{
					/**ここを変更2014.01.08**/
     				Color tmpC = srcBmp.GetPixel(j, i);
     				if(ColorCompare(tmpC, c) == true){
      					b[i+1,j+1]=1;
      					be[i+1,j+1]=1;
     				}else{
      					b[i+1,j+1]=0;
      					be[i+1,j+1]=0;
     				}
     				//b[i+1,j+1]=PointCheck(srcBmp, j, i);
     				//be[i+1,j+1]=PointCheck(srcBmp, j, i);
     				//if(PointCheck(srcBmp, j, i) == 1) GetC = srcBmp.GetPixel(j, i);
     				/**ここまで***/
				}
			}
			
			//if(cif != null)cif.StatusProgressBarChange(2);
			
			//手順1
			do
			{
				check=0;
				for(i=0;i<srcBmp.Height+1;i++)
				{
					for(j=0;j<srcBmp.Width+1;j++)
					{
						//条件1：B(i,j)=1
						if(b[i+1,j+1]==1) S_search(b,j+1,i+1,be);			
					}
				}

				//手順2
				m=0;
				for(i=0;i<srcBmp.Height+1;i++)
				{
					for(j=0;j<srcBmp.Width+1;j++)
					{
						if(b[i+1,j+1]==-1)
						{
							b[i+1,j+1]=0;
							m++;
							check=1;
							be[i+1,j+1]=2;//変更した画素を保存しておく
						}
						else be[i+1,j+1]=b[i+1,j+1];
					}
				}
			}while(check!=0);
			
			//if(cif != null)cif.StatusProgressBarChange(3);
			
			BitmapWhitening(workBmp);
			for(i=0;i<srcBmp.Height;i++)
			{
				for(j=0;j<srcBmp.Width;j++)
				{
					//細線化をすると色が黒になってしまうバグ対応
					//2011.06.07 D.Honjyou
					//if(b[i+1, j+1] == 1) outBmp.SetPixel(j, i, GetC);
					//if(b[i+1, j+1] == 1) workBmp.SetPixel(j, i, c);
					//残像色変更のため変更
					//2011.10.05
					if(b[i+1, j+1] == 1){
						workBmp.SetPixel(j, i, c);
						if(j+1 < workBmp.Width) workBmp.SetPixel(j+1, i, c);
						if(i+1 < workBmp.Height)workBmp.SetPixel(j, i+1, c);
						if(j+1 < workBmp.Width && i+1 < workBmp.Height)workBmp.SetPixel(j+1, i+1, c);
					}else{
						//workBmp.SetPixel(j, i, Color.White);
					}
				}
			}
			BitmapStretchCopy(workBmp, outBmp);
			/**
			
			if(mode == 0){
				DotChange(logBmp, Color.Blue);
				BitmapImposeCopy(logBmp, outBmp);
				BitmapCopy(logBmp, outBmp);
			}
			//if(cif != null)cif.StatusProgressBarChange(4);
			***/
			workBmp.Dispose();
			
		}
		#endregion
		#endregion
		
		#region 2値化処理
		//Viewから色をGetする
		//RGBがすべて128以下だったら、Workに点を打つ
		//WorkをViewにコピーする
		public void ChrMonotoneProc(Bitmap bmp)
		{
			int i,j;
			Color GetC,PutC;
			double Y,ave,max;
			int [,] work = new int[bmp.Height, bmp.Width];
			
			long [] Hist = new long [256];
			int sum, count, n1, n2;
			int t, max_t, t_limit;
			long tmp;
			double ave1, ave2, var1,var2;
			double var_w, var_b, r;

			max_t	= 0;
			t_limit = 255;	//	[0,255]の256階調
			
			//Workを作成
			//Bitmap workBmp = new Bitmap(bmp.Width, bmp.Height);
			//BitmapWhitening(workBmp);
			
			#region 点をグレースケールに変換
			for(i=0; i<bmp.Width; i++){
				//Viewから色を取得する
				GetC = bmp.GetPixel( i, bmp.Height-1);
				if(GetC.R == 0 && GetC.G == 0 && GetC.B ==0){
					bmp.SetPixel( i, bmp.Height-1, Color.White);
				}
			}
			for(j=0; j<bmp.Height; j++){
				//Viewから色を取得する
				GetC = bmp.GetPixel( bmp.Width-1, j);
				if(GetC.R == 0 && GetC.G == 0 && GetC.B ==0){
					bmp.SetPixel( bmp.Width-1, j, Color.White);
				}
			}
			#endregion
			
			#region 点をグレースケールに変換
			for(j=0; j<bmp.Height; j++){
				for(i=0; i<bmp.Width; i++){
					//Viewから色を取得する
					GetC = bmp.GetPixel( i, j);
					
					Y = 0.299 * GetC.R + 0.587 * GetC.G + 0.114 * GetC.B;
					work[j, i] = (int)Y;
					
					//PutC = Color.FromArgb((int)Y, (int)Y, (int)Y);
					//workBmp.SetPixel(i, j, PutC);
				}
			}
			#endregion
			
			#region 判別分析法
			//ヒストグラムを初期化
			for(i=0; i<256; i++) Hist[i] = 0;
			
			//ヒストグラムを取得
			sum = 0; count = 0; ave = 0;
			for(j=0; j<bmp.Height; j++){
				for(i=0; i<bmp.Width; i++){
					//workから色を取得する
					//GetC = workBmp.GetPixel( i, j);
					//Hist[ GetC.R ]++;
					//sum = sum + GetC.R;
					Hist[work[j, i]]++;
					sum += work[j, i];
					count++;
				}
			}
			
			ave = sum/count;
	
			max = -1.0;
			for( t = 0; t < t_limit; t++ ) {
				n1 = n2 = 0;
				ave1 = ave2 = 0;
				var1 = var2 = 0;
				tmp= 0;
				for( i = 0; i < t; i++ ) {
					n1 = n1 + (int)Hist[i];
					tmp = tmp + Hist[i]*i;
				}
				//	クラス1について平均を求める
				if ( n1 != 0 ) {
					ave1 =  (double)tmp / (double)n1;
				}

				for( i = 0; i < t; i++ ) {
					var1 = var1 + (i-ave1)*(i-ave1)*Hist[i];
				}
				//	クラス1について分散を求める
				if ( n1 != 0 ) {
					var1 = var1/(double)n1;
				}

				tmp = 0;
				for( i = t; i < t_limit; i++ ) {
					n2 = n2 + (int)Hist[i];
					tmp = tmp + Hist[i]*i;
				}
				//	クラス2について平均を求める
				if ( n2 != 0 ) { 
					ave2 = (double)tmp / (double)n2;
				}

				for( i = t; i < t_limit; i++ ) {
            		var2 = var2 + (i-ave2)*(i-ave2)*Hist[i];
				}
				//	クラス2について分散を求める
				if ( n2 != 0 ) { 
					var2 = var2/(double)n2;
				}

				var_w = (n1*var1 + n2*var2);	//	分母(n1+n2)は必要ないから省略
				var_b = n1*(ave1-ave)*(ave1-ave) + n2*(ave2-ave)*(ave2-ave);
				r  = var_b / var_w;
				if ( r > max ) {
					max = r;
					max_t = t;
				}
			}
			#endregion
			
			BitmapWhitening(bmp);
			//点を2値に変換
			for(j=0; j<bmp.Height; j++){
				for(i=0; i<bmp.Width; i++){
					//Viewから色を取得する
					//GetC = workBmp.GetPixel( i, j);
					//PutC = (GetC.R > max_t) ? Color.White : Color.Black;
					
					PutC = (work[j, i] > max_t) ? Color.White : Color.Black;
					
					bmp.SetPixel(i, j, PutC);
				}
			}
			
			//WorkをProcとViewにコピー
			//BitmapCopy(workBmp, bmp);
			
			//workBmp.Dispose();
			
			//return(max_t);
		}		
		#endregion
	
		#region サーモグラフィの作成
		public Color GetThermoColor2(double Y)
		{
			int i;
			int r,g,b;
			int c = 256/42;
			Color retColor;
			
			i = 255 - (int)Y;
			if(i<42){
				r=0;
				g=0;
				b=0+(i-0)*c;
			}else if(i<84){
				r=0;
				g=0+(i-42)*c;
				b=255;
			}else if(i<126){
				r=0;
				g=255;
				b=255-(i-84)*c;
			}else if(i<168){
				r=0+(i-126)*c;
				g=255;
				b=0;
			}else if(i<210){
				r=255;
				g=255-(i-168)*c;
				b=0;
			}else{
				r=255;
				g=0+(i-210)*c;
				b=0+(i-210)*c;
			}
			if(r>255)r=255;
			if(g>255)g=255;
			if(b>255)b=255;
			if(r<0) r=0;
			if(g<0) g=0;
			if(b<0) b=0;
			
			retColor = Color.FromArgb(r,g,b);
			return(retColor);
		}
		public Color GetThermoColor(double Y, int Threshold)
		{
			int i;
			int x;
			int A;
			int r,g,b;
			int c;
			Color retColor;
			
			x = 255 - Threshold;
			A = (256 - x) / 6;
			if(A == 0) c=0;
			else c = 256 / A;
			
			i = 255 - (int)Y;
			//if(i > 0)System.Diagnostics.Debug.WriteLine("i = "+ i.ToString() + ": Y = "+Y.ToString());
			//i = 255 - (int)Y;
			//if(i > Threshold) i = 255;
			//else i = 0;
			if(i < x + 1 * A){
				//黒→青
				r=0;
				g=0;
				b=0+(i-x)*c;
			}else if(i < x + 2 * A){
				//青→水
				r=0;
				g=0+(i-(x + 1 * A))*c;
				b=255;
			}else if(i < x + 3 * A){
				//水→緑
				r=0;
				g=255;
				b=255-(i-(x + 2 * A))*c;
			}else if(i < x + 4 * A){
				//緑→黄
				r=0+(i-(x + 3 * A))*c;
				g=255;
				b=0;
			}else if(i < x + 5 * A){
				//黄→赤
				r=255;
				g=255-(i-(x + 4 * A))*c;
				b=0;
			}else{
				//赤→白
				r=255;
				g=0+(i-(x + 5 * A))*c;
				b=0+(i-(x + 5 * A))*c;
			}
			if(r>255)r=255;
			if(g>255)g=255;
			if(b>255)b=255;
			if(r<0) r=0;
			if(g<0) g=0;
			if(b<0) b=0;
			
			//r=i; g=i; b=i;
			retColor = Color.FromArgb(r,g,b);
			return(retColor);
		}
		public void DrawThermoGraphy(Bitmap src, Bitmap output)
		{
			int i,j;
			double Y;
			Color GetC,PutC;
			Pen p = new Pen(Color.White);
			#region 点をグレースケールに変換
			for(j=0; j<src.Height; j++){
				for(i=0; i<src.Width; i++){
					//srcから色を取得する
					GetC = src.GetPixel( i, j);
					
					Y = 0.299 * GetC.R + 0.587 * GetC.G + 0.114 * GetC.B;
					
					//if(Y > (double)Threshold) Y = 255.0;
					PutC = GetThermoColor2(Y/*, Threshold**/);
					output.SetPixel(i, j, PutC);
				}
			}
			#endregion
		}
		#endregion
		
		#region 特徴抽出(加重方向指数ヒストグラム特徴)
		private byte [,] GetArrayFromBmp(Bitmap bmp)
		{
			int i,j;
			byte [,] output = new byte[bmp.Height, bmp.Height];
			
			for(j=0; j<bmp.Height; j++){
				for(i=0; i<bmp.Width; i++){
					if(ColorCompare(bmp.GetPixel(i, j), Color.White))	output[j, i] = 0;
					else												output[j, i] = 1;
				}
			}
			return(output);
		}
		
		void dataSyoki(byte [] data)
		{
			int i;

			for(i=0;i<160*20;i++){
				data[i]=0;
			}
		}
		void data2Syoki(byte [,,] data2)
		{
			int i,j,k;

			for(k=0;k<16;k++){
				for(j=0;j<160;j++){
					for(i=0;i<160;i++){
						data2[k,j,i]=0;
					}
				}
			}
		}

		void data3Syoki(byte [,,] data3)
		{
  			int i,j,k;

 			for(k=0;k<16;k++){
    			for(j=0;j<16;j++){
      				for(i=0;i<16;i++){
        				data3[k,j,i]=0;
      				}
    			}
  			}
		}
		void data4Syoki(double [,,] data4)
		{
  			int i,j,k;

  			for(k=0;k<16;k++){
    			for(j=0;j<8;j++){
      				for(i=0;i<8;i++){
        				data4[k,j,i]=0.0;
      				}
    			}
  			}
		}
		void data5Syoki(double [,,] data5)
		{
  			int i,j,k;

  			for(k=0;k<8;k++){
    			for(j=0;j<8;j++){
      				for(i=0;i<8;i++){
        				data5[k,j,i]=0.0;
      				}
    			}
  			}
		}
		void data6Syoki(double [,,] data6)
		{
  			int i,j,k;

 			for(k=0;k<4;k++){
    			for(j=0;j<8;j++){
      				for(i=0;i<8;i++){
        				data6[k,j,i]=0.0;
      				}
    			}
  			}
		}
		
		void syokika(byte [,] dat3,byte [,] dat2)
		{
			int i,j;

			for(i=0;i<162;i++){
				for(j=0;j<162;j++){
					dat3[i,j] = 0;
				}
			}
			for(i=0;i<160;i++){
				for(j=0;j<160;j++){
					dat3[i+1,j+1]=dat2[i,j];
				}
			}
		}
		
		void tuiseki2(byte [,] dat3, byte [,,] data2,int ap,int bp,int x,int y,int bx,int by,int sc,int n)
		{
  			int i,j,data,sx,sy;
  			int [] px = {-1,-1,0,1,1,1,0,-1};
  			int [] py = {0,1,1,1,0,-1,-1,-1};
  			sx=x; sy=y;
  			bp=0; ap=0;
  			for(i=0;i<8;i++){
    			if(px[i]==bx-x && py[i]==by-y){
      				sc=i+1;
    			}
  			}
  			for(i=0;i<8;i++){
    			if(px[i]==x-bx && py[i]==y-by){
      				bp=(i+4)%8;
    			}
  			}
  			for(i=0;i<8;i++){
				if(0!=dat3[y+py[(sc+i)%8], x+px[(sc+i)%8]]){
      				dat3[y+py[(sc+i)%8], x+px[(sc+i)%8]]=7;
      				by=y; bx=x;
      				y+=py[(sc+i)%8]; x+=px[(sc+i)%8];
      				for(j=0;j<8;j++){
        				if(px[j]==bx-x && py[j]==by-y){
          					ap=j;
          					data=bp+ap;
          					data2[data, by-1, bx-1]++;
        				}
      				}
      				break;
    			}
  			}
		}
		void tuiseki(byte [,] dat3,byte [,,] data2,int ap,int bp,int x,int y,int n,int num)
		{
  			int i,j,data,sx,sy,sc,bx,by,check,sum;
  			int [] px = {-1,-1,0,1,1,1,0,-1};
  			int [] py = {0,1,1,1,0,-1,-1,-1};
  			sx=x; sy=y;
  			bx = 0; by=0;
  			bp=10;
  			sum=0;
  			sc=num;
  			check=0;
  			do{
    			if(check!=0){
      				for(i=0;i<8;i++){
        				if(px[i]==bx-x && py[i]==by-y){
          					sc=i+1;
        				}
      				}
      				for(i=0;i<8;i++){
        				if(px[i]==x-bx && py[i]==y-by){
          					bp=(i+4)%8;
        				}
      				}
    			}
    			check=1;
    			for(i=0;i<8;i++){
      				if(0!=dat3[y+py[(sc+i)%8],x+px[(sc+i)%8]]){
       					dat3[y+py[(sc+i)%8],x+px[(sc+i)%8]]=7;
        				by=y; bx=x;
       					y+=py[(sc+i)%8]; x+=px[(sc+i)%8];
        				for(j=0;j<8;j++){
          					if(px[j]==bx-x && py[j]==by-y){
            					ap=j;
            					data=bp+ap;
            					if(sum==1) data2[data,by-1,bx-1]++;
            					sum=1;

          					}
        				}
        				break;
      				}
    			}
  			}while(x!=sx || y!=sy);
  			x=sx; y=sy;
  			tuiseki2(dat3,data2,ap,bp,x,y,bx,by,sc,n);
		}
		void rasta(byte [,] dat3,byte [,,] data2,int ap,int bp)
		{
  			int i,j,n=3;
  			for(i=0;i<161;i++){
    			for(j=0;j<161;j++){
      				if(dat3[i,j]==0 && dat3[i,j+1]==1){
        				dat3[i,j+1]=7;
        				tuiseki(dat3,data2,ap,bp,j+1,i,n,0);
      				}
      				if(dat3[i,j]==1 && dat3[i,j+1]==0){
        				dat3[i,j]=7;
        				tuiseki(dat3,data2,ap,bp,j,i,n,4);
      				}
    			}
  			}
  			for(j=161;j>0;j--){
    			for(i=161;i>0;i--){
      				if(dat3[i,j]==0 && dat3[i-1,j]==1){
        				dat3[i-1,j]=7;
        				tuiseki(dat3,data2,ap,bp,j,i-1,n,2);
      				}
      				if(dat3[i,j]==1 && dat3[i-1,j]==0){
        				dat3[i,j]=7;
        				tuiseki(dat3,data2,ap,bp,j,i,n,6);
      				}
    			}
  			}
		}

		void ryousika(byte [,,] data2,byte [,,] data3)
		{
  			int i,j,k,m,n;
 
  			for(i=0;i<16;i++){
    			for(j=0;j<16;j++){
      				for(k=0;k<16;k++){
        				for(m=0;m<10;m++){
          					for(n=0;n<10;n++){
								data3[i,j,k]+=data2[i,(10*j)+m,(10*k)+n];
          					}
        				}
      				}
    			}
  			}
		}

		void gaus_fil<Type>(Type [,,] data3,double [,,] data4)
		{
  			int m,n,i,j,k;
  			double sum=0.0;
  			//Type work;
  			double [,] gaus={{0.00,0.09,0.17,0.09,0.00},
                             {0.09,0.57,1.05,0.57,0.09},
                             {0.17,1.05,1.94,1.05,0.17},
                             {0.09,0.57,1.05,0.57,0.09},
                             {0.00,0.09,0.17,0.09,0.00}};
  			System.Diagnostics.Debug.WriteLine(data4.GetLength(0).ToString() + "," + data4.GetLength(1).ToString() + "," + data4.GetLength(2).ToString());
  			for(i=0;i<data4.GetLength(0);i++){
    			for(j=0;j<8;j++){
      				for(k=0;k<8;k++){
						sum=0.0;
        				for(m=0;m<5;m++){
          					for(n=0;n<5;n++){
								if(2*j+m-2>0 && 2*j+m-2<16 && 2*k+n-2>0 && 2*k+n-2<16){
									//work = data3[i,2*j+m-2,2*k+n-2];
									//sum+=data3[i,2*j+m-2,2*k+n-2]*gaus[m,n];
									sum+=Convert.ToDouble(data3[i,2*j+m-2,2*k+n-2])*gaus[m,n];
								}
          					}
        				}
        				data4[i,j,k]=sum;
      				}
    			}
  			}
		}

		void houkou(double [,,] data4,double [,,] data5)
		{
  			int i,j,k;

  			for(i=0;i<16;i+=2){
    			for(j=0;j<8;j++){
      				for(k=0;k<8;k++){
        				if(i==0) data5[i/2,j,k]=data4[15,j,k]+data4[0,j,k]*2+data4[1,j,k];
						else data5[i/2,j,k]=data4[i-1,j,k]+data4[i,j,k]*2+data4[i+1,j,k];
      				}
    			}
  			}
		}

		void douitusi(double [,,] data5,double [,,] data6)
		{
  			int i,j,k;

  			for(i=0;i<8;i++){
    			for(j=0;j<8;j++){
     	 			for(k=0;k<8;k++){
        				if(i>3) data6[i-4,j,k]+=data5[i,j,k];
        				else data6[i,j,k]+=data5[i,j,k];
      				}
    			}
  			}
		}

		void kajyu_data(double [,,] data6,double [] nyuuryoku)
		{
  			int i,j,k;
  			for(i=0;i<256;i++){
    			nyuuryoku[i]=0;
  			}
  			for(i=0;i<4;i++){
    			for(j=0;j<8;j++){
      				for(k=0;k<8;k++){
        				nyuuryoku[i*64+j*8+k]=data6[i,j,k];
      				}
    			}
  			}
		}

		public void GetKajyu(Bitmap bmp, double [] kajyu, double [] kajyuView, double R)
		{
			int j,m,n;
			byte [,] data1 = new byte[bmp.Height, bmp.Height];
			byte [,] dat3 = new byte[bmp.Height + 2, bmp.Height + 2];
			byte [,,] data2 = new byte[16, bmp.Width, bmp.Height];
			byte [,,] data3 = new byte[16, 16, 16];
			double [,,] data4 = new double[16, 8, 8];
			double [,,] data5 = new double[8, 8, 8];
			double [,,] data6 = new double[4, 8, 8];
			double maxd, mind, work;
			double R1 = 10.0;
			
			Noize(bmp);
			Normalize(bmp, R);
			data1 = GetArrayFromBmp(bmp);
			data2Syoki(data2);
			data3Syoki(data3);
			data4Syoki(data4);
			data5Syoki(data5);
			data6Syoki(data6);
			
			syokika(dat3,data1);
			rasta(dat3,data2,ap,bp);
  			ryousika(data2,data3);
  			gaus_fil(data3,data4);
  			houkou(data4,data5);
  			douitusi(data5,data6);
  			
  			kajyu_data(data6, kajyu);
			maxd=0.0;
			mind=10000.0;
			for(j=0;j<4;j++){
				for(m=0;m<8;m++){
					for(n=0;n<8;n++){
						if(maxd<data6[j,m,n])maxd=data6[j,m,n];
						if(mind>data6[j,m,n])mind=data6[j,m,n];
					}
				}
			}
			work=(maxd-mind)/R1;
			for(j=0;j<4;j++){
				for(m=0;m<8;m++){
					for(n=0;n<8;n++){
						data6[j,m,n] = data6[j,m,n]/work;
					}
				}
			}
			kajyu_data(data6, kajyuView);
		}
		#endregion
		
		#region 特徴抽出(背景伝搬法)
		//セルの伝搬
		private void CellDenpan(byte [,] picture, int [,,] cell, int Height, int Width)
		{
			int a;
			int X, Y;
			byte [,] work = new byte[Height + 2, Width + 2];
			int [,] sisu = new int[,] {
										{ 5, 5, 6, 6, 6, 7, 7 },
										{ 5, 5, 5, 6, 7, 7, 7 },
										{ 4, 5, 5, 6, 7, 7, 0 },
										{ 4, 4, 4,-1, 0, 0, 0 },
										{ 4, 3, 3, 2, 1, 1, 0 },
										{ 3, 3, 3, 2, 1, 1, 1 },
										{ 3, 3, 2, 2, 2, 1, 1 },
									   };
			
			//サイズ+2のデータボックスに入れなおし
			for( int j=0; j<Height; j++){
				for(int i=0; i<Width; i++){
					work[j+1, i+1] = picture[j, i];
				}
			}
			// 「右上」「上」「左上」「左」方向からの伝搬
			for(int j=1; j<Height+1; j++){
				for(int i=1; i<Height+1; i++){
					a=0;
					if(work[j, i] == 0){
						//方向を定める
						X =  (int)work[j-1, i+1] + (int)work[j, i+1] + (int)work[j+1, i+1]
							-(int)work[j-1, i-1] - (int)work[j, i-1] - (int)work[j+1, i-1];
						Y =  (int)work[j-1, i-1] + (int)work[j-1, i] + (int)work[j-1, i+1]
							-(int)work[j+1, i-1] - (int)work[j+1, i] - (int)work[j+1, i+1];
						if( X != 0 || Y != 0){
							a = sisu[Y+3, X+3];
							cell[a, j, i] = 1;
						}
						//伝搬
						if( cell[1, j-1, i+1] != 0) cell[1, j, i] += cell[1, j-1, i+1] + 1;
						if( cell[2, j-1,   i] != 0) cell[2, j, i] += cell[2, j-1,   i] + 1;
						if( cell[3, j-1, i-1] != 0) cell[3, j, i] += cell[3, j-1, i-1] + 1;
						if( cell[4,   j, i-1] != 0) cell[4, j, i] += cell[4,   j, i-1] + 1;
						
					}
					
				}
				
			}
			// 「左下」「下」「右下」「右」方向からの伝搬
			for(int j=Height; j>0; j--){
				for(int i=Width; i>0; i--){
					if(work[j, i] == 0){
						//伝搬
						if( cell[5, j+1, i-1] != 0) cell[5, j, i] += cell[5, j+1, i-1] + 1;
						if( cell[6, j+1,   i] != 0) cell[6, j, i] += cell[6, j+1,   i] + 1;
						if( cell[7, j+1, i+1] != 0) cell[7, j, i] += cell[7, j+1, i+1] + 1;
						if( cell[0,   j, i+1] != 0) cell[0, j, i] += cell[0,   j, i+1] + 1;
						
					}
				}
			}
			
		}
		
		private void CellCompress(int [,,] cell, double [,,] cell2, int Height, int Width)
		{
			int xx, yy;
			int [] X = new int[Width];
			int [] Y = new int[Height];
			double [] v = new double[Height + Width];
			
			for(int i=0; i<Width; i++){
				X[i] = (i*16) / Width;
			}
			for(int j=0; j<Height; j++){
				Y[j] = (j*16) / Height;
			}
			
			//伝搬値をあらかじめ計算
		    v[0] = 0;
		    for(int i=1; i<Height+Width; i++) {
		    	v[i] = 1.0 / (double)i;
		    }
		    
		    //圧縮
		    for(int j=1; j<Height+1; j++){
		    	for(int i=1; i<Width+1; i++){
		    		xx = X[i-1];
		    		yy = Y[j-1];
		    		
		    		for(int n=0; n<8; n++){
		    			cell2[n, yy, xx] += v[ cell[n, j, i] ];
		    		}
		    	}
		    }
		}
		
		public void GetHaikei(Bitmap bmp, double [] haikei, double [] haikeiView, double R)
		{
			byte [,] data1 = new byte[bmp.Height, bmp.Width];
			int [,,] cell = new int[8, bmp.Height + 2, bmp.Width + 2];
			double [,,] cell2 = new double[8, 16, 16];
			double [,,] feature = new double[8, 8, 8];
			double maxd, mind, work;
			double R1 = 10.0;
			
			Noize(bmp);
			Normalize(bmp, R);
			data1 = GetArrayFromBmp(bmp);
			CellDenpan(data1, cell, bmp.Height, bmp.Width);
			CellCompress(cell, cell2, bmp.Height, bmp.Width);
			gaus_fil(cell2, feature);
			maxd=0.0;
			mind=10000.0;
			for(int j=0;j<8;j++){
				for(int m=0;m<8;m++){
					for(int n=0;n<8;n++){
						if(maxd<feature[j,m,n])maxd=feature[j,m,n];
						if(mind>feature[j,m,n])mind=feature[j,m,n];
					}
				}
			}
			work=(maxd-mind)/R1;
			for(int n=0; n<8; n++){
				for(int j=0; j<8; j++){
					for(int i=0; i<8; i++){
						haikei[n*64+j*8+i] = feature[n, j, i];
						haikeiView[n*64+j*8+i] = feature[n, j, i] / work;
					}
				}
			}
		}
		#endregion
		
		#region Pointsから矩形を出す
		private Rectangle GetRectangle(ArrayList Points)
		{
			int maxx, maxy, minx, miny;
			Rectangle r = new Rectangle();
			
			maxx = 0;
			maxy = 0;
			minx = 1000000;
			miny = 1000000;
			
			foreach(Point p in Points)
			{
				if(p.X < minx) minx = p.X;
				if(p.Y < miny) miny = p.Y;
				if(p.X > maxx) maxx = p.X;
				if(p.Y > maxy) maxy = p.Y;
			}
			
			r.X = minx;
			r.Y = miny;
			r.Width = Math.Abs(maxx - minx);
			r.Height = Math.Abs(maxy - miny);
			
			return(r);
		}
		#endregion
		
		#region 画像を切り出す
		public Rectangle ImageClipping(Bitmap bmp, ArrayList Points, Bitmap outBmp, Color c)
		{
			Bitmap work = new Bitmap(bmp.Width, bmp.Height);
			int maxx, maxy, minx, miny;
			Rectangle r = new Rectangle();
			Rectangle frame = new Rectangle();
			
			//準備
			BitmapWhitening(work);
			BitmapWhitening(outBmp);
			Graphics g = Graphics.FromImage(work);
			maxx = 0;
			maxy = 0;
			minx = 1000000;
			miny = 1000000;
			r = GetRectangle(Points);
			//System.Diagnostics.Debug.WriteLine(r.ToString());
			//System.Diagnostics.Debug.WriteLine(outBmp.Size.ToString());
			//workに多角形塗りつぶしを描画
			g.FillPolygon(Brushes.Red, (Point [])(Points.ToArray(typeof(Point))));
			g.Dispose();
			
			//workの青とbmp(source)の白以外を探す
			for(int j = r.Y; j < r.Y + r.Height; j++){
				for(int i = r.X; i < r.X + r.Width; i++){
					if(ColorCompare(bmp.GetPixel( i, j), Color.White) == false && ColorCompare(work.GetPixel( i, j), Color.Red) == true){
						outBmp.SetPixel(i, j, c);
						if(i < minx) minx = i;
						if(j < miny) miny = j;
						if(i > maxx) maxx = i;
						if(j > maxy) maxy = j;
					}
				}
			}
			
			work.Dispose();
			frame.X = minx;
			frame.Y = miny;
			frame.Width = Math.Abs(maxx - minx);
			frame.Height = Math.Abs(maxy - miny);
			return(frame);
		}
		#endregion
		
		#region 重心を描画(ポイント座標)
		public void DrawFrameGravityPoint(Bitmap bmp, Point Gravity, Color c)
		{
			Graphics g = Graphics.FromImage(bmp);
			Pen p = new Pen(c, 2);
			
			g.DrawLine(p, Gravity.X - 3, Gravity.Y - 3, Gravity.X + 3, Gravity.Y + 3);
			g.DrawLine(p, Gravity.X - 3, Gravity.Y + 3, Gravity.X + 3, Gravity.Y - 3);
			
			g.Dispose();
		}
		#endregion
		
		#region 重心を描画(線)
		public void DrawFrameGravityLine(Bitmap bmp, Point Gr1, Point Gr2, Color c)
		{
			Graphics g = Graphics.FromImage(bmp);
			Pen p = new Pen(c, 2);
			
			g.DrawLine(p, Gr1, Gr2);
			
			g.Dispose();
		}
		#endregion
		
		#region フレームを描画
		public void DrawFrameAtColor(Bitmap bmp, Rectangle r, Color c)
		{
			Graphics g = Graphics.FromImage(bmp);
			Pen p = new Pen(c,3);
			
			g.DrawRectangle(p, r);
			g.Dispose();
		}
		#endregion
		
		#region アクティブ フレームを描画
		public void DrawFrameActiveFrame(Bitmap bmp, Rectangle r, Color c)
		{
			Graphics g = Graphics.FromImage(bmp);
			
			Brush b = new SolidBrush(Color.FromArgb(60, c.R, c.G, c.B));
			g.FillRectangle(b, r);
			
			Pen p = new Pen(c,3);
			g.DrawRectangle(p, r);
			g.Dispose();
		}
		#endregion
		
		#region 画素数を取得する
		// Mode = 0 : 黒画素、 Mode = 1 : 白画素 Mode = 2 : 白画素以外
		public long GetPixelPoint(Bitmap bmp, int Mode)
		{
			int i, j;
			long sum;
			
			sum = 0;
			for(j = 0; j < bmp.Height; j++){
				for(i = 0; i < bmp.Width; i++){
					if( Mode == 0 ){
						if( ColorCompare(bmp.GetPixel(i, j), Color.Black) == true ){
							sum++ ;
						}
					}else if( Mode == 1 ){
						if( ColorCompare(bmp.GetPixel(i, j), Color.White) == true ){
							sum++;
						}
					}else{
						if( ColorCompare(bmp.GetPixel(i, j), Color.White) == false ){
							sum++;
						}
					}
				}
			}
			return(sum);
		}
		#endregion
		
		#region 画像ファイルかどうかのチェック
		public bool IsImageFile(string str)
		{
			bool bRet = false;
			switch (Path.GetExtension(str).ToLower()) {
				case ".jpeg":
				case ".jpg":
				case ".jpe":
				case ".gif":
				case ".bmp":
				case ".tiff":
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
		
		#region 画像フォーマットの取得
		public ImageFormat GetImageFormat(string FileName)
		{
			ImageFormat imf;
			switch (Path.GetExtension(FileName).ToLower()) {
				case ".jpeg":
				case ".jpg":
				case ".jpe":
					imf = ImageFormat.Jpeg;
					break;
				case ".gif":
					imf = ImageFormat.Gif;
					break;
				case ".bmp":
					imf = ImageFormat.Bmp;
					break;
				case ".png":
					imf = ImageFormat.Png;
					break;
				case ".tiff":
					imf = ImageFormat.Tiff;
					break;
				default:
					imf = null;
					break;
			}
			return(imf);
		}
		#endregion
		
	}
}
