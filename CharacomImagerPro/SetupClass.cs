/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2011/11/29
 * 時刻: 13:26
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;

namespace CharacomImagerPro
{
	/// <summary>
	/// Description of SetupClass.
	/// </summary>
	[Serializable]
	public class SetupClass
	{
		public const int ColorNum = 50;
		
		public SetupClass()
		{
			SetDefault();
		}
		
		#region デフォルト設定
		public void SetDefault()
		{
			StrDBDir = "";
			CenterLineVisible = true;
			EightLineVisible = true;
			
			CenterLineColor = Color.Magenta;
			EightLineColor = Color.AliceBlue;
			
			RecentlyFileNum = 5;
			WindowListNum = 5;
			
			CharaNormalize = true;
			CharaR = 38.0;
			StringNormalize = true;
			StringR = 152.0;
			
			//自動更新
			BAutoUpdate = true;
			BForceUpdate = false;
			
			//閾値配列
			Threshold[0,0] = 0.9537;		Threshold[1,0] = 139.25;
			Threshold[0,1] = 0.9436;		Threshold[1,1] = 160.60;
			Threshold[0,2] = 0.9357;		Threshold[1,2] = 173.24;
			Threshold[0,3] = 0.9268;		Threshold[1,3] = 186.31;
			Threshold[0,4] = 0.9102;		Threshold[1,4] = 206.76;
			
			//MainWindowサイズ
			RWindowBounds = new Rectangle(0, 0, 1141, 888);
			
			//コメント
			Comment[0] = "同一筆者の可能性が極めて高い";
			Comment[1] = "同一筆者の可能性が高い";
			Comment[2] = "同一筆者の可能性がある";
			Comment[3] = "異なる筆者の可能性がある";
			Comment[4] = "異なる筆者の可能性が高い";
			Comment[5] = "異なる筆者の可能性が極めて高い";
			
			//コメント表示色
			CommColor[0] = Color.LimeGreen;
			CommColor[1] = Color.LimeGreen;
			CommColor[2] = Color.Black;
			CommColor[3] = Color.Black;
			CommColor[4] = Color.Red;
			CommColor[5] = Color.Red;
			
			//コメント太字
			CommBold[0] = true;
			CommBold[1] = false;
			CommBold[2] = false;
			CommBold[3] = false;
			CommBold[4] = false;
			CommBold[5] = true;
			
			Noize = true;
			Normalize = true;
			
			HonninCheckUp = 0;
			TaninCheckup = 2;
			
			LeftIn = true;
			RightIn = false;
			
			Kajyu = true;
			Haikei = false;
			
			DisplayColor[0] = Color.FromArgb(255,0,0,0);
			DisplayColor[1] = Color.FromArgb(255,255,255,128);
			DisplayColor[2] = Color.FromArgb(255,128,255,128);
			DisplayColor[3] = Color.FromArgb(255,0,255,128);
			DisplayColor[4] = Color.FromArgb(255,128,255,255);
			DisplayColor[5] = Color.FromArgb(255,0,128,255);
			DisplayColor[6] = Color.FromArgb(255,255,128,192);
			DisplayColor[7] = Color.FromArgb(255,255,128,255);
			DisplayColor[8] = Color.FromArgb(255,255,0,0);
			DisplayColor[9] = Color.FromArgb(255,255,255,0);
			DisplayColor[10] = Color.FromArgb(255,128,255,0);
			DisplayColor[11] = Color.FromArgb(255,0,255,64);
			DisplayColor[12] = Color.FromArgb(255,0,255,255);
			DisplayColor[13] = Color.FromArgb(255,0,128,192);
			DisplayColor[14] = Color.FromArgb(255,128,128,192);
			DisplayColor[15] = Color.FromArgb(255,255,0,255);
			DisplayColor[16] = Color.FromArgb(255,128,64,64);
			DisplayColor[17] = Color.FromArgb(255,255,128,64);
			DisplayColor[18] = Color.FromArgb(255,0,255,0);
			DisplayColor[19] = Color.FromArgb(255,0,128,128);
			DisplayColor[20] = Color.FromArgb(255,0,64,128);
			DisplayColor[21] = Color.FromArgb(255,128,128,255);
			DisplayColor[22] = Color.FromArgb(255,128,0,64);
			DisplayColor[23] = Color.FromArgb(255,255,0,128);
			DisplayColor[24] = Color.FromArgb(255,128,0,0);
			DisplayColor[25] = Color.FromArgb(255,255,128,0);
			DisplayColor[26] = Color.FromArgb(255,0,128,0);
			DisplayColor[27] = Color.FromArgb(255,0,128,64);
			DisplayColor[28] = Color.FromArgb(255,0,0,255);
			DisplayColor[29] = Color.FromArgb(255,0,0,160);
			DisplayColor[30] = Color.FromArgb(255,128,0,128);
			DisplayColor[31] = Color.FromArgb(255,128,0,255);
			DisplayColor[32] = Color.FromArgb(255,64,0,0);
			DisplayColor[33] = Color.FromArgb(255,128,64,0);
			DisplayColor[34] = Color.FromArgb(255,0,64,0);
			DisplayColor[35] = Color.FromArgb(255,0,64,64);
			DisplayColor[36] = Color.FromArgb(255,0,0,128);
			DisplayColor[37] = Color.FromArgb(255,0,0,64);
			DisplayColor[38] = Color.FromArgb(255,64,0,64);
			DisplayColor[39] = Color.FromArgb(255,64,0,128);
			DisplayColor[40] = Color.FromArgb(255,255,128,128);
			DisplayColor[41] = Color.FromArgb(255,128,128,0);
			DisplayColor[42] = Color.FromArgb(255,128,128,64);
			DisplayColor[43] = Color.FromArgb(255,128,128,128);
			DisplayColor[44] = Color.FromArgb(255,64,128,128);
			DisplayColor[45] = Color.FromArgb(255,192,192,192);
			DisplayColor[46] = Color.FromArgb(255,64,0,64);
			DisplayColor[47] = Color.FromArgb(255,255,255,255);
			DisplayColor[48] = Color.FromArgb(255,255,255,255);
			DisplayColor[49] = Color.FromArgb(255,255,255,255);
		}
		#endregion
		
		#region センターライン表示設定
		private bool _centerLineVisible;
		public bool CenterLineVisible {
			get { return _centerLineVisible; }
			set { _centerLineVisible = value; }
		}
		#endregion
		
		#region 8x8領域ライン表示設定
		private bool _eightLineVisible;
		public bool EightLineVisible {
			get { return _eightLineVisible; }
			set { _eightLineVisible = value; }
		}
		#endregion
		
		#region 8x8領域ライン表示設定
		private Color _centerLineColor;
		public Color CenterLineColor {
			get { return _centerLineColor; }
			set { _centerLineColor = value; }
		}
		#endregion
		
		#region 8x8領域ライン表示設定
		private Color _eightLineColor;
		public Color EightLineColor {
			get { return _eightLineColor; }
			set { _eightLineColor = value; }
		}
		#endregion
		
		#region 最近使ったファイル表示数
		private int _recentlyFileNum;		
		public int RecentlyFileNum {
			get { return _recentlyFileNum; }
			set { _recentlyFileNum = value; }
		}
		#endregion
		
		#region ウィンドウリスト表示数
		private int _windowListNum;		
		public int WindowListNum {
			get { return _windowListNum; }
			set { _windowListNum = value; }
		}
		#endregion
		
		#region 閾値配列
		private double [,] _threshold = new double[2,5]; //閾値配列：類似度(0)or距離値(1), 境界区分
		public double[,] Threshold {
			get { return _threshold; }
			set { _threshold = value; }
		}
		#endregion
		
		#region コメント
		private string [] _comment = new string[6];		
		public string[] Comment {
			get { return _comment; }
			set { _comment = value; }
		}
		#endregion
		
		#region コメント表示色
		private Color [] _commColor = new Color[6];		
		public Color[] CommColor {
			get { return _commColor; }
			set { _commColor = value; }
		}
		#endregion
		
		#region コメント太字
		private bool [] _commBold = new bool[6];		
		public bool[] CommBold {
			get { return _commBold; }
			set { _commBold = value; }
		}		
		#endregion
		
		#region 大きさ正規化
		private bool _normalize;		
		public bool Normalize {
			get { return _normalize; }
			set { _normalize = value; }
		}
		#endregion
		
		#region ノイズ除去
		private bool _noize;		
		public bool Noize {
			get { return _noize; }
			set { _noize = value; }
		}
		#endregion
		
		#region 本人照合方法
		private int _honninCheckUp;
		public int HonninCheckUp {
			get { return _honninCheckUp; }
			set { _honninCheckUp = value; }
		}
		#endregion
		
		#region 他人棄却方法
		private int _taninCheckup;
		public int TaninCheckup {
			get { return _taninCheckup; }
			set { _taninCheckup = value; }
		}
		#endregion
		
		#region 加重方向指数ヒストグラム特徴
		private bool _kajyu;		
		public bool Kajyu {
			get { return _kajyu; }
			set { _kajyu = value; }
		}
		#endregion
		
		#region 背景伝搬法
		private bool _haikei;		
		public bool Haikei {
			get { return _haikei; }
			set { _haikei = value; }
		}
		#endregion
		
		#region 個別文字の投入位置(左端)
		private bool _leftIn;
		public bool LeftIn {
			get { return _leftIn; }
			set { _leftIn = value; }
		}
		#endregion
		
		#region 個別文字の投入位置(右端)
		private bool _rightIn;
		public bool RightIn {
			get { return _rightIn; }
			set { _rightIn = value; }
		}
		#endregion
		
		#region 表示色
		private Color [] _displayColor = new Color[SetupClass.ColorNum];
		public Color [] DisplayColor {
			get { return _displayColor; }
			set { _displayColor = value; }
		}
		
		#region Colorの表示名からColor構造体を取得(デフォルト青)
		public Color GetColorFromName(string ColorName)
		{
			int iRet;
			Color c;
			
			iRet = -1;
			for(int i=0; i<_displayColor.Length; i++){
				if(_displayColor[i].Name == ColorName){
					iRet = i;
				}
			}
			
			if(iRet == -1){
				c = Color.Blue;
			}else{
				c = DisplayColor[iRet];
			}
			return(c);
		}
		#endregion
		
		#region 表示色名のチェック
		public string CheckColorName(string ColorName)
		{
			int iRet;
			string c;
			
			iRet = -1;
			for(int i=0; i<_displayColor.Length; i++){
				if(_displayColor[i].Name == ColorName){
					iRet = i;
				}
			}
			
			if(iRet == -1){
				c = "ff0000ff";
			}else{
				c = ColorName;
			}
			return(c);
		}
		#endregion
		
		#region 色番号を返す
		public int GetColorNo(string ColorName)
		{
			int iRet;
			
			iRet = 0;
			for(int i=0; i<_displayColor.Length; i++){
				if(_displayColor[i].Name == ColorName){
					iRet = i;
				}
			}
			
			return(iRet);
		}
		#endregion
		#endregion
		
		#region 個別文字正規化
		private bool _charaNormalize;		
		public bool CharaNormalize {
			get { return _charaNormalize; }
			set { _charaNormalize = value; }
		}
		#endregion
		
		#region 個別文字R値
		private double _charaR;		
		public double CharaR {
			get { return _charaR; }
			set { _charaR = value; }
		}
		#endregion
		
		#region 文字列正規化
		private bool _stringNormalize;		
		public bool StringNormalize {
			get { return _stringNormalize; }
			set { _stringNormalize = value; }
		}
		#endregion
		
		#region 文字列R値
		private double _stringR;		
		public double StringR {
			get { return _stringR; }
			set { _stringR = value; }
		}
		#endregion
		
		#region データベースアドレス
		private string _strDBDir;		
		public string StrDBDir {
			get { return _strDBDir; }
			set { _strDBDir = value; }
		}
		#endregion
		
		#region 標準書体アドレス
		private string _strStandardDir;		
		public string StrStandardDir {
			get { return _strStandardDir; }
			set { _strStandardDir = value; }
		}
		#endregion
		
		#region 筆順アドレス
		private string _strStrokeDir;		
		public string StrStrokeDir {
			get { return _strStrokeDir; }
			set { _strStrokeDir = value; }
		}
		#endregion
		
		#region 自動アップデート
		private bool _bAutoUpdate;
		public bool BAutoUpdate {
			get { return _bAutoUpdate; }
			set { _bAutoUpdate = value; }
		}
		#endregion
		
		#region 強制更新
		private bool _bForceUpdate;
		public bool BForceUpdate {
			get { return _bForceUpdate; }
			set { _bForceUpdate = value; }
		}
		#endregion
		
		#region ウィンドウ位置とサイズ
		//2021.08.30 D.Honjyou ウィンドウ位置とサイズを保存
		private Rectangle _rWindowBounds;
		public Rectangle RWindowBounds {
			get { return _rWindowBounds; }
			set { _rWindowBounds = value; }
		}
		#endregion
	}
}
