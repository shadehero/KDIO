using System;
using System.Runtime.InteropServices;

namespace KDIO.Core
{
	public class Environment
	{
		[DllImport("user32.dll", SetLastError = true)]
		static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

		// Flagi Stanu Klawisza
		const int KEY_DOWN = 0x0001;
		const int KEY_UP = 0x0002;

		// Flagi Klawiszy
		const int VK_CAPS = 0x14;
		const int VK_NUMLOCK = 0x90;
		const int VK_SCROLL = 0x91;

		// =======================================================================

		// Porty
		public enum IO_Ports
		{
			CAPS,
			NUMLOCK,
			SCROLL
		}

		// Stany Portow
		static bool CAPS_STATE = false;
		static bool NUM_STATE = false;
		static bool SCROLL_STATE = false;

		// =======================================================================

		static void ResetPorts()
		{
			SetPort(IO_Ports.CAPS, false);
			SetPort(IO_Ports.NUMLOCK, false);
			SetPort(IO_Ports.SCROLL, false);
		}

		static bool GetPort(IO_Ports port)
		{
			switch (port)
			{
				case IO_Ports.CAPS: return CAPS_STATE;
				case IO_Ports.NUMLOCK: return NUM_STATE;
				case IO_Ports.SCROLL: return SCROLL_STATE;
				default: return false;
			}
		}

		public static void SetPort(IO_Ports port, bool state)
		{
			// CAPS
			if (port == IO_Ports.CAPS)
			{
				if (CAPS_STATE)
				{
					if (state == false)
					{
						CAPS_STATE = false;
						PressKey(port);
					}
				}
				else
				{
					if (state)
					{
						CAPS_STATE = true;
						PressKey(port);
					}
				}
			}

			// NUM
			if (port == IO_Ports.NUMLOCK)
			{
				if (NUM_STATE)
				{
					if (state == false)
					{
						NUM_STATE = false;
						PressKey(port);
					}
				}
				else
				{
					if (state)
					{
						NUM_STATE = true;
						PressKey(port);
					}
				}
			}

			// SCROLL
			if (port == IO_Ports.SCROLL)
			{
				if (SCROLL_STATE)
				{
					if (state == false)
					{
						SCROLL_STATE = false;
						PressKey(port);
					}
				}
				else
				{
					if (state)
					{
						SCROLL_STATE = true;
						PressKey(port);
					}
				}
			}
		}

		// =======================================================================

		public static void PortCombo(bool n1, bool n2, bool n3)
		{
			SetPort(IO_Ports.NUMLOCK, n1);
			SetPort(IO_Ports.CAPS, n2);
			SetPort(IO_Ports.SCROLL, n3);
		}

		public static void PortCombo(int combo)
		{
			/*
			 * 0: 000
			 * 1: 001
			 * 2: 010
			 * 3: 011
			 * 4: 100
			 * 5: 101
			 * 6: 110
			 * 7: 111
			*/

			switch (combo)
			{
				case 0:
					SetPort(IO_Ports.NUMLOCK, false);
					SetPort(IO_Ports.CAPS, false);
					SetPort(IO_Ports.SCROLL, false);
					break;
				case 1:
					SetPort(IO_Ports.NUMLOCK, false);
					SetPort(IO_Ports.CAPS, false);
					SetPort(IO_Ports.SCROLL, true);
					break;
				case 2:
					SetPort(IO_Ports.NUMLOCK, false);
					SetPort(IO_Ports.CAPS, true);
					SetPort(IO_Ports.SCROLL, false);
					break;
				case 3:
					SetPort(IO_Ports.NUMLOCK, false);
					SetPort(IO_Ports.CAPS, true);
					SetPort(IO_Ports.SCROLL, true);
					break;
				case 4:
					SetPort(IO_Ports.NUMLOCK, true);
					SetPort(IO_Ports.CAPS, false);
					SetPort(IO_Ports.SCROLL, false);
					break;
				case 5:
					SetPort(IO_Ports.NUMLOCK, true);
					SetPort(IO_Ports.CAPS, false);
					SetPort(IO_Ports.SCROLL, true);
					break;
				case 6:
					SetPort(IO_Ports.NUMLOCK, true);
					SetPort(IO_Ports.CAPS, true);
					SetPort(IO_Ports.SCROLL, false);
					break;
				case 7:
					SetPort(IO_Ports.NUMLOCK, true);
					SetPort(IO_Ports.CAPS, true);
					SetPort(IO_Ports.SCROLL, true);
					break;
			}
		}

		// =======================================================================

		static void PressKey(IO_Ports port)
		{
			switch (port)
			{
				case IO_Ports.CAPS:
					keybd_event(VK_CAPS, 0, KEY_DOWN, 0);
					keybd_event(VK_CAPS, 0, KEY_UP, 0);
					break;
				case IO_Ports.NUMLOCK:
					keybd_event(VK_NUMLOCK, 0, KEY_DOWN, 0);
					keybd_event(VK_NUMLOCK, 0, KEY_UP, 0);
					break;
				case IO_Ports.SCROLL:
					keybd_event(VK_SCROLL, 0, KEY_DOWN, 0);
					keybd_event(VK_SCROLL, 0, KEY_UP, 0);
					break;
			}
		}

		// =======================================================================

	}
}
