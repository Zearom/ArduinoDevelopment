using System;

namespace LedShiftProfile
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			LedShiftingLightProfile profile = new LedShiftingLightProfile ("/Users/Zearom/Documents/Development/dotNet/LedShiftProfile/LedShiftProfile/ShiftingLightProfile.xml");
			Console.WriteLine ("Hello World!");
			Console.ReadLine ();
		}
	}
}
