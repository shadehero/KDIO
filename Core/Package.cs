using System;
namespace KDIO
{
	public struct Package
	{
		byte[] _Data;
		public Package(byte[] data)
		{
			_Data = data;
		}
	}
}
