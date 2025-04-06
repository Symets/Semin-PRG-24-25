using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Malování
{
    public enum ToolType //lifehack od mamky <3
    {
        Pencil,
        Brush,
        Marker,
        Eraser,
        Spray
    }
    public partial class Form1 : Form
    {
        private Pen currentPen;
        private ToolType currentTool;
        private bool isDrawing = false;
        private Point startPoint;
        int r, g, b;
        public Form1()
        {
            InitializeComponent();
            currentPen = new Pen(Color.Black, 1);
            currentTool = ToolType.Pencil;
            trackBarOpacity.Value = 255;
        }

        //barvišky 
        private void buttonRed_Click(object sender, EventArgs e)
        {
            r = 255;
            g = 0;
            b = 0;
            currentPen.Color = Color.FromArgb(trackBarOpacity.Value, r, g, b);
            ChangeInfoText();
        }
        private void buttonBlue_Click(object sender, EventArgs e)
        {
            r = 0;
            g = 0;
            b = 192;
            currentPen.Color = Color.FromArgb(trackBarOpacity.Value, r, g, b);
            ChangeInfoText();
        }
        private void buttonYellow_Click(object sender, EventArgs e)
        {
            r = 255;
            g = 255;
            b = 0;
            currentPen.Color = Color.FromArgb(trackBarOpacity.Value, r, g, b);
            ChangeInfoText();
        }
        private void buttonGreen_Click(object sender, EventArgs e)
        {
            r = 0;
            g = 128;
            b = 0;
            currentPen.Color = Color.FromArgb(trackBarOpacity.Value, r, g, b);
            ChangeInfoText();
        }
        private void buttonOrange_Click(object sender, EventArgs e)
        {
            r = 255;
            g = 128;
            b = 0;
            currentPen.Color = Color.FromArgb(trackBarOpacity.Value, r, g, b);
            ChangeInfoText();
        }
        private void buttonBlack_Click(object sender, EventArgs e)
        {
            r = 0;
            g = 0;
            b = 0;
            currentPen.Color = Color.FromArgb(trackBarOpacity.Value, r, g, b);
            ChangeInfoText();
        }
        private void buttonBrown_Click(object sender, EventArgs e)
        {
            r = 128;
            g = 64;
            b = 0;
            currentPen.Color = Color.FromArgb(trackBarOpacity.Value, r, g, b);
            ChangeInfoText();
        }
        private void buttonWhite_Click(object sender, EventArgs e)
        {
            r = 255;
            g = 255;
            b = 255;
            currentPen.Color = Color.FromArgb(trackBarOpacity.Value, r, g, b);
            ChangeInfoText();
        }

        //costumazations
        private void trackBarSize_Scroll(object sender, EventArgs e)
        {
            currentPen.Width = trackBarSize.Value;
            ChangeInfoText();
        }
        private void trackBarOpacity_Scroll(object sender, EventArgs e)
        {
            currentPen.Color = Color.FromArgb(trackBarOpacity.Value, r, g, b);
            ChangeInfoText();
        }

        //samotné malovánie
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            startPoint = e.Location;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                using (Graphics gr = pictureBox1.CreateGraphics())
                {
                    switch (currentTool)
                    {
                        case ToolType.Pencil:
                            gr.DrawLine(currentPen, startPoint, e.Location);
                            startPoint = e.Location;
                            break;

                        case ToolType.Brush:
                            Random rndBrush = new Random();
                            int currentOpacity = trackBarOpacity.Value + rndBrush.Next(-40, 40);
                            if (currentOpacity > 255)
                            {
                                currentOpacity = 255;
                            }
                            if (currentOpacity < 0)
                            {
                                currentOpacity = 0;
                            }
                            currentPen.Color = Color.FromArgb(currentOpacity, r, g, b);
                            gr.DrawLine(currentPen, startPoint, e.Location);
                            startPoint = e.Location;
                            break;
                        case ToolType.Spray:
                            Random rndSpray = new Random();
                            for (int i = 0; i < 50; i++)
                            {
                                int x = e.X + rndSpray.Next(-10 * trackBarSize.Value, 10 * trackBarSize.Value);
                                int y = e.Y + rndSpray.Next(-10 * trackBarSize.Value, 10 * trackBarSize.Value);
                                gr.FillEllipse(new SolidBrush(currentPen.Color), x, y, 2, 2);
                            }
                            break;
                        case ToolType.Marker:
                            currentPen.Width = trackBarSize.Value + 10;
                            gr.DrawLine(currentPen, startPoint, e.Location);
                            startPoint = e.Location;
                            currentPen.Width = trackBarSize.Value;
                            break;
                        case ToolType.Eraser:
                            gr.DrawLine(currentPen, startPoint, e.Location);
                            startPoint = e.Location;
                            break;

                    }
                }
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        //štětečky
        private void buttonPencil_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Pencil;
            currentPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            currentPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            ChangeInfoText();
        }
        private void buttonBrush_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Brush;
            currentPen.EndCap = System.Drawing.Drawing2D.LineCap.Triangle;
            currentPen.StartCap = System.Drawing.Drawing2D.LineCap.Triangle;
            ChangeInfoText();
        }

        private void buttonMarker_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Marker;
            currentPen.EndCap = System.Drawing.Drawing2D.LineCap.Square;
            currentPen.StartCap = System.Drawing.Drawing2D.LineCap.Square;
            ChangeInfoText();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void buttonEraser_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Eraser;
            currentPen.EndCap = System.Drawing.Drawing2D.LineCap.Square;
            currentPen.StartCap = System.Drawing.Drawing2D.LineCap.Square;
            currentPen.Color = Color.White;
            ChangeInfoText();
        }

        private void buttonSpray_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Spray;
            ChangeInfoText();
        }

        private void ChangeInfoText() 
        {
            textBoxInfo.Text =  currentTool.ToString() + ", size:" + currentPen.Width.ToString() + ", Opacity:" + trackBarOpacity.Value;
            textBoxColor.BackColor = Color.FromArgb(r, g, b);
        }

        //gg missclicky, na který se bojim šáhnout cuz jsem takový expert, že by to vybuchlo or sm
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
        private void textBoxInfo_TextChanged(object sender, EventArgs e) { }

    }   
}

