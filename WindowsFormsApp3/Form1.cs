using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {

        public enum EPaintTools
        {
            DrawLine,
            DrawRectangle,
        }
        public static EPaintTools shape;

        public Point p;
        public static int DefWidth = 3;
        public int width = DefWidth;

        //public List<Rectangle> listRect = new List<Rectangle>();
        //public List<Rectangle> tempRect = new List<Rectangle>();
        //public List<PaintTools> listTool = new List<PaintTools>();
        //public List<PaintTools> tempTool = new List<PaintTools>();

        Pen mypen = new Pen(Color.Black, DefWidth);

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            p.X = e.X;                  
            p.Y = e.Y;                  
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //float w = Math.Abs(p.X - e.X);
            //float h = Math.Abs(p.Y - e.Y);
            //Graphics g = pictureBox1.CreateGraphics();
            //pictureBox1.Refresh();
            //if (e.Button == MouseButtons.Left && shape == EPaintTools.DrawLine)
            //{
            //    g.DrawLine(mypen, p.X, p.Y, e.X, e.Y);          
            //    p.X = e.X;                                     
            //    p.Y = e.Y;                                     
            //    g.Dispose();                                   
            //}
            //else if (e.Button == MouseButtons.Left && shape == EPaintTools.DrawRectangle)
            //{

            //    g.DrawRectangle(mypen, Math.Min(p.X, e.X), Math.Min(p.Y, e.Y), w, h);
                
            //    //if (e.X > p.X)
            //    //{
            //    //    if (e.Y > p.Y) g.DrawRectangle(mypen, p.X, p.Y, w, h);
            //    //    else g.DrawRectangle(mypen, p.X, e.Y, w, h);
            //    //}
            //    //else
            //    //{
            //    //    if (e.Y > p.Y) g.DrawRectangle(mypen, e.X, p.Y, w, h);
            //    //    else g.DrawRectangle(mypen, e.X, e.Y, w, h);
            //    //}
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void red_Click(object sender, EventArgs e)
        {
            shape = EPaintTools.DrawLine;
        }

        private void green_Click(object sender, EventArgs e)
        {
            shape = EPaintTools.DrawRectangle;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                mypen = new Pen(dlg.Color, width);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                width = Convert.ToInt32("0");
                mypen.Width = width;
            }
            else
            {
                width = Convert.ToInt32(textBox1.Text);
                mypen.Width = width;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            float w = Math.Abs(p.X - e.X);
            float h = Math.Abs(p.Y - e.Y);
            Graphics g = pictureBox1.CreateGraphics();
            //pictureBox1.Refresh();
            if (e.Button == MouseButtons.Left && shape == EPaintTools.DrawLine)
            {
                g.DrawLine(mypen, p.X, p.Y, e.X, e.Y);
                p.X = e.X;
                p.Y = e.Y;
                g.Dispose();
            }
            else if (e.Button == MouseButtons.Left && shape == EPaintTools.DrawRectangle)
            {

                g.DrawRectangle(mypen, Math.Min(p.X, e.X), Math.Min(p.Y, e.Y), w, h);

                //if (e.X > p.X)
                //{
                //    if (e.Y > p.Y) g.DrawRectangle(mypen, p.X, p.Y, w, h);
                //    else g.DrawRectangle(mypen, p.X, e.Y, w, h);
                //}
                //else
                //{
                //    if (e.Y > p.Y) g.DrawRectangle(mypen, e.X, p.Y, w, h);
                //    else g.DrawRectangle(mypen, e.X, e.Y, w, h);
                //}
            }
        }
    }
}
