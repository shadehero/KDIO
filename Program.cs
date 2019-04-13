using System;
using KDIO.Core;

namespace KDIO
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.Title = " [ KDIO ] by ShadeHero";

			Core.Environment.PortCombo(3);

			Console.ReadKey();
		}
	}
}
