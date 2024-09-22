using ManufactureManage.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManufactureManage
{
    public partial class MonitorForm2 : Form
    {
        public MonitorForm2()
        {
            InitializeComponent();
            //this.MouseWheel += new MouseEventHandler(pictureBox1_MouseWheel);
            //Bitmap bitmap = new Bitmap(@"E:\04 工具大全\03 UI\neibu包装线 (4).png");
            //this.pictureBox1.Image = bitmap;

            x = this.Width;
            y = this.Height;
            SetTag(this);
        }

        #region 控件大小随窗体大小等比例缩放
        private float x;//定义当前窗体的宽度
        private float y;//定义当前窗体的高度
        private void SetTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    SetTag(con);
                }
            }
        }
        private void SetControls(float newx, float newy, Control cons)
        {
            //遍历窗体中的控件，重新设置控件的值
            foreach (Control con in cons.Controls)
            {
                //获取控件的Tag属性值，并分割后存储字符串数组
                if (con.Tag != null)
                {
                    string[] mytag = con.Tag.ToString().Split(new char[] { ';' });
                    //根据窗体缩放的比例确定控件的值
                    con.Width = Convert.ToInt32(System.Convert.ToSingle(mytag[0]) * newx);//宽度
                    con.Height = Convert.ToInt32(System.Convert.ToSingle(mytag[1]) * newy);//高度
                    con.Left = Convert.ToInt32(System.Convert.ToSingle(mytag[2]) * newx);//左边距
                    con.Top = Convert.ToInt32(System.Convert.ToSingle(mytag[3]) * newy);//顶边距
                    Single currentSize = System.Convert.ToSingle(mytag[4]) * newy;//字体大小
                    con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                    if (con.Controls.Count > 0)
                    {
                        SetControls(newx, newy, con);
                    }
                }
            }
        }
        private void MonitorForm2_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / x;
            float newy = (this.Height) / y;
            SetControls(newx, newy, this);
        }
        #endregion


        private bool _isCanDealPicture = false;//鼠标在panel或pictureBox上面都可以处理图片
        private bool _moveFlag = false;//当鼠标在pictureBox上面左键按下时，可拖动图片移动
        private int _xPos, _yPos;//保存初次点击pictureBox时的位置信息

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            //if (e.Delta != 0)
            //{
            //    if (e.Delta > 0)
            //    {
            //        g.Clear(Color.Black);
            //        System.Drawing.Drawing2D.Matrix myMatrix = new System.Drawing.Drawing2D.Matrix();
            //        myMatrix.Scale(2, 2);
            //        myMatrix.Translate(-0.5f * centerP.X, -0.5f * centerP.Y);
            //        gp.Transform(myMatrix);
            //        g.FillPath(new SolidBrush(Color.Red), gp);
            //    }
            //    else
            //    {
            //        System.Drawing.Drawing2D.Matrix myMatrix = new System.Drawing.Drawing2D.Matrix();
            //        myMatrix.Scale(0.5f, 0.5f);
            //        myMatrix.Translate(centerP.X, centerP.Y);
            //        gp.Transform(myMatrix);
            //        g.Clear(Color.Black);
            //        g.FillPath(new SolidBrush(Color.Red), gp);
            //    }
            //}


            //if (_isCanDealPicture)
            //{
            //    double step = 1.2;
            //    if (e.Delta > 0)
            //    {
            //        if (pictureBox1.Height >= Screen.PrimaryScreen.Bounds.Height * 12)
            //            return;

            //        pictureBox1.Height = (int)(pictureBox1.Height * step);
            //        pictureBox1.Width = (int)(pictureBox1.Width * step);
            //        int px = Cursor.Position.X - pictureBox1.Location.X;
            //        int py = Cursor.Position.Y - pictureBox1.Location.Y;
            //        int px_add = (int)(px * (step - 1.0));
            //        int py_add = (int)(py * (step - 1.0));
            //        pictureBox1.Location = new Point(pictureBox1.Location.X - px_add, pictureBox1.Location.Y - py_add);
            //        Application.DoEvents();
            //    }
            //    else
            //    {
            //        if (pictureBox1.Width <= panel1.Width / 10)
            //            return;

            //        pictureBox1.Height = (int)(pictureBox1.Height / step);
            //        pictureBox1.Width = (int)(pictureBox1.Width / step);
            //        int px = Cursor.Position.X - pictureBox1.Location.X;
            //        int py = Cursor.Position.Y - pictureBox1.Location.Y;
            //        int px_add = (int)(px * (1.0 - 1.0 / step));
            //        int py_add = (int)(py * (1.0 - 1.0 / step));
            //        pictureBox1.Location = new Point(pictureBox1.Location.X + px_add, pictureBox1.Location.Y + py_add);
            //        Application.DoEvents();
            //    }
            //}
        }

        private void MonitorForm2_Load(object sender, EventArgs e)
        {

        }

        private void GetImagePixLocation(Size pictureBoxSize, Size imageSize, Point pictureBoxPoint, out Point imagePoint)
        {
            imagePoint = new Point(0, 0);
            double scale;
            int detalInHeight = 0;
            int detalInWidth = 0;
            if (Convert.ToDouble(pictureBoxSize.Width) / pictureBoxSize.Height > Convert.ToDouble(imageSize.Width) / imageSize.Height)
            {
                scale = 1.0 * imageSize.Height / pictureBoxSize.Height;
                detalInWidth = Convert.ToInt32((pictureBoxSize.Width * scale - imageSize.Width) / 2.0);
            }
            else
            {
                scale = 1.0 * imageSize.Width / pictureBoxSize.Width;
                detalInHeight = Convert.ToInt32((pictureBoxSize.Height * scale - imageSize.Height) / 2.0);
            }
            imagePoint.X = Convert.ToInt32(pictureBoxPoint.X * scale - detalInWidth);
            imagePoint.Y = Convert.ToInt32(pictureBoxPoint.Y * scale - detalInHeight);
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            _isCanDealPicture = true;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            _isCanDealPicture = true;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            _isCanDealPicture = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _moveFlag = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _moveFlag)
            {
                pictureBox1.Left += Convert.ToInt16(e.X - _xPos);
                pictureBox1.Top += Convert.ToInt16(e.Y - _yPos);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _moveFlag = true;
                _xPos = e.X;
                _yPos = e.Y;
            }
        }



        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            _isCanDealPicture = true;
        }
    }
}
