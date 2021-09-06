/*
 * SharpDevelopによって生成
 * ユーザ: 02322
 * 日付: 2013/11/02
 * 時刻: 16:10
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.Drawing;
namespace CharacomImagerPro
{
	/// <summary>
	/// Description of CharaImageFormProperties.
	/// </summary>
	public class CharaImageFormProperties
	{
		LocationSize _form = new LocationSize(0, 0, 673, 425);
		LocationSize _panel1 = new LocationSize(0, 35, 320, 320);
		LocationSize _groupBox1 = new LocationSize(326, 34, 335, 71);
		LocationSize _label1 = new LocationSize(17, 25, 50, 15);
		LocationSize _label2 = new LocationSize(17, 48, 50, 15);
		LocationSize _label3 = new LocationSize(179,25, 50, 15);
		LocationSize _label4 = new LocationSize(179,48, 50, 15);
		LocationSize _txtHeight = new LocationSize(51, 22, 110, 19);
		LocationSize _txtWidth = new LocationSize(51, 45, 110, 19);
		LocationSize _txtArea = new LocationSize(213, 22, 110, 19);
		LocationSize _txtGravity = new LocationSize(213, 45, 110, 19);
		LocationSize _dgvFrameData = new LocationSize(326, 107, 335, 216);
		LocationSize _btnCSV = new LocationSize(560, 329, 100, 23);
		LocationSize _cmbZoomTool = new LocationSize(0, 0, 75, 26);
		LocationSize _comboColor = new LocationSize(0, 0, 103, 26);
		
		#region プロパティGetter
		public LocationSize Form {
			get { return _form; }
		}
		public LocationSize Panel1 {
			get { return _panel1; }
		}
		public LocationSize GroupBox1 {
			get { return _groupBox1; }
		}
		public LocationSize Label1 {
			get { return _label1; }
		}
		public LocationSize Label2 {
			get { return _label2; }
		}
		public LocationSize Label3 {
			get { return _label3; }
		}
		public LocationSize Label4 {
			get { return _label4; }
		}
		public LocationSize TxtHeight {
			get { return _txtHeight; }
		}
		public LocationSize TxtWidth {
			get { return _txtWidth; }
		}
		public LocationSize TxtArea {
			get { return _txtArea; }
		}
		public LocationSize TxtGravity {
			get { return _txtGravity; }
		}
		public LocationSize DgvFrameData {
			get { return _dgvFrameData; }
		}
		public LocationSize BtnCSV {
			get { return _btnCSV; }
		}
		public LocationSize CmbZoomTool {
			get { return _cmbZoomTool; }
		}
		public LocationSize ComboColor {
			get { return _comboColor; }
		}
		#endregion
		
		public CharaImageFormProperties()
		{
			
		}
	}
	public class LocationSize
	{
		Point location;
		Size size;
		
		public LocationSize(int x, int y, int width, int height){
			location = new Point(x, y);
			size = new Size(width, height);
		}
			
		public Point Location {
			get { return location; }
			set { location = value; }
		}
		
		public Size Size {
			get { return size; }
			set { size = value; }
		}
	}
}
