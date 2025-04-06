using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestPressure
{
    public partial class Form1 : Form
    {
        private const int WM_POINTERDOWN = 0x0246;
        private const int WM_POINTERUPDATE = 0x0245;
        private const int WM_POINTERUP = 0x0247;

        [DllImport("user32.dll")]
        private static extern bool GetPointerPenInfo(int pointerId, out POINTER_PEN_INFO penInfo);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_POINTERDOWN || m.Msg == WM_POINTERUPDATE)
            {
                int pointerId = m.WParam.ToInt32();

                if (GetPointerPenInfo(pointerId, out POINTER_PEN_INFO penInfo))
                {
                    int pressure = penInfo.pressure; // Get the pen pressure
                    Console.WriteLine($"Pen Pressure: {pressure}");
                }
            }

            base.WndProc(ref m); // Pass message to base class
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINTER_PEN_INFO
        {
            public int pointerId;
            public int penFlags;
            public int penMask;
            public int pressure;
            public int rotation;
            public int tiltX;
            public int tiltY;
        }
    public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
