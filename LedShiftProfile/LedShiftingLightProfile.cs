using System;
using System.Drawing;

namespace LedShiftProfile
{
	public class LedShiftingLightProfile
	{
		public Color Color1 { get; set; }
		public Color Color2 { get; set; }
		public Color Color3 { get; set; }
		public int BlinkDelay { get; set; }

		public LedShiftingLightProfile (String fileName)
		{
			if (System.IO.File.Exists(fileName)) {
				System.Xml.XmlDocument xmlProfile = new System.Xml.XmlDocument ();
				System.IO.StreamReader streamReader = new System.IO.StreamReader (fileName);
				xmlProfile.LoadXml(streamReader.ReadToEnd());
				streamReader.Close();

				this.loadXmlProfile (xmlProfile);
			} else {
				throw new System.IO.FileNotFoundException("File '" + fileName + "' not found");
			}
		}

		private void loadXmlProfile(System.Xml.XmlDocument xmlProfile) {
			// Load colors
			color
			for (int i = 0; i < 
		}
	}

	public class LedShiftingLightProfileLedGroup {
		public int StartIndex { get; set; }
		public int EndIndex { get; set; }
		public String DataSource { get; set; }

		public LedShiftingLightProfileLedGroup(int startIndex, int endIndex, String dataSource) {
			this.StartIndex = startIndex;
			this.EndIndex = endIndex;
			this.DataSource = dataSource;
		}
	}

	public class LedShiftingLightProfileLedFrame {
		public String Operator { get; set; }
		public int Value { get; set; }

		public LedShiftingLightProfileLedFrame(String comparisonOperator, int value) {
			this.Operator = comparisonOperator;
			this.Value = value;
		}
	}

	public class LedShiftingLightProfileLed {
		public int Index { get; set; }
		public int Color { get; set; }

		public LedShiftingLightProfileLed (int index, int color) {
			this.Index = index;
			this.Color = color;
		}
	}
}

