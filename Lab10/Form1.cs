using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;




namespace Lab10
{
    public partial class Form1 : Form
    {//Сетка \\\\\\\\\\\\\\\\\
        ColorComboBox CB;
        Graphics gr1;
        int CenterX = 0, CenterY = 0;
        Pen p,p3;
        Random rnd;
        Point [] point=new Point[4];
        string[] combBox_name = { "Cплошная", "Штрихи", "Точками" };
        int oldnum1 = 0;
        int oldnum2 = 0;
        bool randOld = false;
        bool randNew = false;
        int oldComb = 0;
        int newComb = 0;
        int oldCol=0;
        int newCol = 0;
        float x1, y1;
        bool focus = true;
        // \\\\\\\\\\\\\\\\\\\\\\\

        // Узор \\\\\\\\\\\\\\\\\\\\\\\
        GraphicsPath gr2;
        Graphics g;
        Brush br;
        Pen p2;
        Color cl;
        float x0, y0;
        int CenterX2 = 0, CenterY2 = 0;
        float size = 0;
        float szshare2 = 0;
        int numNew3 = 0;
        int numNew4 = 0;
        int numNew5 = 0;
        bool focus2 = true;
        // \\\\\\\\\\\\\\\\\\\\\\\

        //Шарик \\\\\\\\\\\\\\\\\\\\\\\
        Graphics gr3;
        int CenterX3 = 0, CenterY3 = 0;
        double fl = 0.0;
        int rb, rm;
        double x, y;
        // \\\\\\\\\\\\\\\\\\\\\\\
        bool sz = false;
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            // \\\\\\\\\\\\\\\\\\\\\\\
            CB = new ColorComboBox();
            CB.Location = new Point(10, 80);
            CB.SelectedIndex = 34;
            CB.Parent = groupBox1;
            
            CenterX = pictureBox1.Size.Width / 2;
            CenterY = pictureBox1.Size.Height / 2;
            p = new Pen(Color.Black);
           
            rnd = new Random();
            for(int i = 0; i < 4; i++) { point[i] = new Point(0, 0); }
            comboBox1.Items.AddRange(combBox_name);
           
            comboBox1.SelectedIndex = 0;
           
            // \\\\\\\\\\\\\\\\\\\\\\\
            g = Graphics.FromHwnd(pictureBox1.Handle);
            p2 = new Pen(Color.Black);

            size = (int)numericUpDown1.Value;
            szshare2 = size / ((int)numericUpDown3.Value);
            CenterX = pictureBox1.Size.Width / 2;
            CenterY = pictureBox1.Size.Height / 2;
            x0 = CenterX - size / 2; y0 = CenterY - size / 2;
            // \\\\\\\\\\\\\\\\\\\\\\\
            numNew3 = 0;
            numNew4 = 0;
            numNew5 = 0;
            p3 = new Pen(Color.Black);

        }



        // \\\\\\\\\\\\\\\\\\\\\\\
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (comboBox1.SelectedIndex) 
            {
                case (0):
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                   
                    break;
                case (1):
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                  
                    break;
                case (2):
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                   
                    break;
            }
            newComb = 1;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {if (checkBox1.Checked)
                timer1.Enabled = true;
            else timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (newCol != CB.SelectedIndex) { newCol = CB.SelectedIndex; }
            if ((int)numericUpDown1.Value != oldnum1 || (int)numericUpDown2.Value != oldnum2 || randNew!=randOld || newComb!= oldComb || newCol!=oldCol ||sz!=false||focus!=false)
            {
                gr1 = Graphics.FromHwnd(pictureBox1.Handle);
                sz = false;

                CenterX = tabPage1.Size.Width / 2 - 100;
                CenterY = tabPage1.Size.Height / 2;
                float size = (int)numericUpDown1.Value;
                numericUpDown2.Maximum = (int)numericUpDown1.Value / 2;
                float szshare = 0;
                if ((int)numericUpDown2.Value != 0)
                {
                    szshare = size / ((int)numericUpDown2.Value);
                }
                x1 = CenterX - size / 2; y1 = CenterY - size / 2;
                focus = false;
                randOld = false;
                randNew = false;
                
                oldCol = newCol;
                oldComb = newComb;
                rec( gr1, szshare, p, size, x1, y1);
                oldnum1 = (int)numericUpDown1.Value;
                oldnum2 = (int)numericUpDown2.Value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            gr1 = Graphics.FromHwnd(pictureBox1.Handle);

            oldnum1 = (int)numericUpDown1.Value;
            oldnum2 = (int)numericUpDown2.Value;
            CenterX = pictureBox1.Size.Width / 2 ;
            CenterY = pictureBox1.Size.Height / 2;
            float size = (int)numericUpDown1.Value;
            numericUpDown2.Maximum = (int)numericUpDown1.Value / 2;
            float szshare=0;
            if ((int)numericUpDown2.Value!=0) 
            {
                szshare = size / ((int)numericUpDown2.Value);
            }
            x1 = CenterX - size / 2; y1 = CenterY - size / 2;
           
            rec(gr1,szshare,p,size,x1,y1); 
            }

        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            randNew = true;
        }

       

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            randNew = true;
        }

        

        private void Form1_Resize(object sender, EventArgs e)
        {
            numericUpDown6.Maximum = pictureBox3.Height/2;
            sz = true;

        }

        

        void rec( Graphics gr1, float szshare, Pen p, float size,float x1,float y1)
        {
            gr1.Clear(Color.White);
            if (radioButton1.Checked)
            {
                    p.Color = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                    gr1.DrawLine(p, x1,y1,x1+size,y1 );
                    p.Color = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                    gr1.DrawLine(p, x1 + size, y1, x1 + size, y1+size);
                    p.Color = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                    gr1.DrawLine(p, x1 + size, y1 + size, x1,y1+size);
                    p.Color = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                    gr1.DrawLine(p, x1, y1 + size, x1, y1);
                    if ((int)numericUpDown2.Value != 0)
                    {
                    p.Color = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                    gr1.DrawLine(p, x1, y1, x1 + size, y1 + size);
                    p.Color = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                    gr1.DrawLine(p, x1 + size, y1, x1, y1 + size);
                }
                    else { return; }
                    for (int i = 1; i < (int)numericUpDown2.Value; i++)
                    {
                        p.Color = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                    gr1.DrawLine(p, x1 + i * szshare, y1, x1 + size, (y1 + size) - i * szshare);
                    p.Color = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                    gr1.DrawLine(p, x1, y1 + i * szshare, (x1 + size) - i * szshare, (y1 + size));
                    p.Color = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                    gr1.DrawLine(p, x1 + i * szshare, y1, x1, y1 + i * szshare);
                    p.Color = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                    gr1.DrawLine(p, (x1 + size) - i * szshare, (y1 + size), (x1 + size), (y1 + size) - i * szshare);
                }

            }
            else 
            {
                p.Color = Color.FromName(CB.SelectedItem.ToString());
                gr1.DrawLine(p, x1, y1, x1 + size, y1);
                gr1.DrawLine(p, x1 + size, y1, x1 + size, y1 + size);
                gr1.DrawLine(p, x1 + size, y1 + size, x1, y1 + size);
                gr1.DrawLine(p, x1, y1 + size, x1, y1);
                if ((int)numericUpDown2.Value != 0)
                {
                    gr1.DrawLine(p, x1,y1,x1+size, y1+size);
                    gr1.DrawLine(p, x1+size,y1,x1,y1+size);
                }
                else { return; }
                for (int i = 1; i < (int)numericUpDown2.Value; i++)
                {
                    gr1.DrawLine(p,x1 + i * szshare, y1, x1+size, (y1+size)- i * szshare);
                    gr1.DrawLine(p, x1, y1 + i * szshare, (x1 + size) - i * szshare, (y1 + size));
                    gr1.DrawLine(p, x1 + i * szshare, y1, x1, y1 + i * szshare);
                    gr1.DrawLine(p, (x1 + size) - i * szshare, (y1 + size), (x1 + size), (y1 + size) - i * szshare);
                }
            }
            
            
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            sz = true;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            focus2 = true;
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            focus = true;
        }

        // \\\\\\\\\\\\\\\\\\\\\\\
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (numericUpDown3.Value!= numNew3|| numericUpDown4.Value != numNew4|| numericUpDown5.Value != numNew5||sz!=false||focus2!=false) {
                numNew3 = (int)numericUpDown3.Value;
                numNew4 = (int)numericUpDown4.Value;
                numNew5 = (int)numericUpDown5.Value;
                cl = new Color();
                g = Graphics.FromHwnd(pictureBox2.Handle);
                gr2 = new GraphicsPath();
                g.Clear(Color.White);
                gr2.StartFigure();
                focus2 = false;
                size = (float)numericUpDown3.Value;
                szshare2 = size / ((int)numericUpDown5.Value);
                CenterX2 = pictureBox2.Size.Width / 2;
                CenterY2 = pictureBox2.Size.Height / 2;
                x0 = CenterX2 - size / 2; y0 = CenterY2 - size / 2;
                sz = false;
                br = new SolidBrush(Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));
                for (int j = 0; j < numericUpDown4.Value; j++)
                {

                    if (szshare2 < 0.05)
                    {
                        MessageBox.Show("Рисонок законцен!");
                        break;
                    }

                    gr2.AddLine(x0, y0, x0 + size, y0);
                    gr2.AddLine(x0 + size, y0, x0 + size, y0 + size);
                    gr2.AddLine(x0 + size, y0 + size, x0, y0 + size);
                    gr2.AddLine(x0, y0 + size, x0, y0);
                    br = new SolidBrush(Color.FromArgb(99, rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));
                    gr2.CloseFigure();
                    g.FillPath(br, gr2);
                    gr2.Reset();

                    for (int i = 0; i < numericUpDown5.Value; i++)
                    {

                        gr2.AddArc(x0 + i * szshare2, y0 - (szshare2 / 2), szshare2, szshare2, 0, 180);
                        cl = Color.FromArgb(99, rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                        br = new SolidBrush(cl);
                        gr2.CloseFigure();
                        g.FillPath(br, gr2);
                        gr2.Reset();

                        gr2.AddArc(x0 - (szshare2 / 2), y0 + i * szshare2, szshare2, szshare2, 270, 180);
                        cl = Color.FromArgb(99, rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                        br = new SolidBrush(cl);
                        gr2.CloseFigure();
                        g.FillPath(br, gr2);
                        gr2.Reset();

                        gr2.AddArc(x0 + size - (szshare2 / 2), y0 + i * szshare2, szshare2, szshare2, 90, 180);
                        cl = Color.FromArgb(99, rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                        br = new SolidBrush(cl);
                        gr2.CloseFigure();
                        g.FillPath(br, gr2);
                        gr2.Reset();

                        gr2.AddArc(x0 + i * szshare2, y0 + size - (szshare2 / 2), szshare2, szshare2, 180, 180);
                        cl = Color.FromArgb(99, rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                        br = new SolidBrush(cl);
                        gr2.CloseFigure();
                        g.FillPath(br, gr2);
                        gr2.Reset();

                        g.DrawArc(p2, x0 + i * szshare2, y0 - (szshare2 / 2), szshare2, szshare2, 0, 180);

                        g.DrawArc(p2, x0 - (szshare2 / 2), y0 + i * szshare2, szshare2, szshare2, 270, 180);

                        g.DrawArc(p2, x0 + size - (szshare2 / 2), y0 + i * szshare2, szshare2, szshare2, 90, 180);

                        g.DrawArc(p2, x0 + i * szshare2, y0 + size - (szshare2 / 2), szshare2, szshare2, 180, 180);

                    }

                    g.DrawLine(p2, x0, y0, x0 + size, y0);
                    g.DrawLine(p2, x0 + size, y0, x0 + size, y0 + size);
                    g.DrawLine(p2, x0 + size, y0 + size, x0, y0 + size);
                    g.DrawLine(p2, x0, y0 + size, x0, y0);

                    x0 += szshare2 / 2; y0 += szshare2 / 2;

                    size -= szshare2;
                    szshare2 = size / ((int)numericUpDown5.Value);


                }
                size = (float)numericUpDown3.Value;
                szshare2 = size / ((int)numericUpDown5.Value);
                CenterX = pictureBox1.Size.Width / 2;
                CenterY = pictureBox1.Size.Height / 2;
                x0 = CenterX - size / 2; y0 = CenterY - size / 2; }
        }

        // \\\\\\\\\\\\\\\\\\\\\\\

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            int val = (int)numericUpDown7.Value;
            numericUpDown7.Maximum = numericUpDown6.Value / 2 - 1;
            if (val > numericUpDown7.Maximum) { numericUpDown7.Value = numericUpDown7.Maximum; }
            else numericUpDown7.Value = val;


        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            gr3 = Graphics.FromHwnd(pictureBox3.Handle);
            gr3.Clear(Color.White);
            p3.Color = Color.Black;
            rm = (int)numericUpDown7.Value;
            rb = (int)numericUpDown6.Value;
            CenterX3 = pictureBox3.Size.Width / 2 ;
            CenterY3 = pictureBox3.Size.Height / 2;
            double xx = Math.Sin(fl);
            double yy = Math.Cos(fl);
            x = CenterX3 + xx * (rb - rm);
            y = CenterY3 - yy * (rb - rm);



            gr3.DrawEllipse(p3, CenterX3 - rb, CenterY3 - rb, 2 * rb, 2 * rb);
            gr3.DrawEllipse(p3, (int)x - rm, (int)y - rm, 2 * rm, 2 * rm);
            fl += trackBar1.Value * Math.PI / 180;
        }
        // \\\\\\\\\\\\\\\\\\\\\\\
    }
}
