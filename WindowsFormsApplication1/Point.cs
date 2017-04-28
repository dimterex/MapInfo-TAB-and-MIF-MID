using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Point : MapObject
    {
        private GeoPoint coord = new GeoPoint();

        public Font font;
        public SolidBrush brush;
        public SolidBrush invers;
        public int symbol;
        public char smb;

       
        
        public double  X
        {
            set { coord.X = value; }
            get { return coord.X; }
        }
        public double Y
        {
            set { coord.Y = value; }
            get { return coord.Y; }
        }
        
        private SizeF ms;

        public Point()
        {
            X = 0;
            Y = 0;
            type = ObjectType.Point;

            font = new Font("MapSymbols", 14);
            brush = new SolidBrush(Color.Red);

         //   smb = Convert.ToChar(symbol);

            var b = brush.Color.B;
            var r = brush.Color.R;
            var g = brush.Color.G;
            var c = Color.FromArgb(255 - r, 255 - g, 255 - b);
            invers = new SolidBrush(c);
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
            type = ObjectType.Point;

            font = new Font("MapSymbols", 14);
            brush = new SolidBrush(Color.Red);
           // smb = Convert.ToChar(symbol);

            var b = brush.Color.B;
            var r = brush.Color.R;
            var g = brush.Color.G;
            var c = Color.FromArgb(255 - r, 255 - g, 255 - b);
            invers = new SolidBrush(c);
        }
        

        public override void Draw(PaintEventArgs e) //прорисовка точки
        {
            if(layer == null)
            {
                return;
            }

            if (layer.map == null)
            {
                return;

            }
            Graphics context = Graphics.FromHwnd(layer.map.Handle);
            ms = context.MeasureString(Convert.ToChar(symbol).ToString(), font);//smb.ToString()
            GeoPoint move = new GeoPoint(coord.X - ms.Width / 2, coord.Y + ms.Height / 2);
            System.Drawing.Point P = layer.map.MapToScreen(move);

            if (IsSelect == true)
            {
                e.Graphics.DrawString(Convert.ToChar(symbol).ToString(), font, invers, (float)P.X, (float)P.Y); //smb.ToString()
            }
            else
            {
                e.Graphics.DrawString(Convert.ToChar(symbol).ToString(), font, brush, (float)P.X, (float)P.Y); //smb.ToString()
            }
            

        }

        public override MapObject IsCross(GeoPoint gp, double d)
        //метод луча точка полигон текст 
        {
            //вычислить координаты
            GeoPoint sumb1 = new GeoPoint(coord.X - ms.Width / 2, coord.Y + ms.Height / 2);
            GeoPoint sumb2 = new GeoPoint(coord.X - ms.Width / 2, coord.Y - ms.Height / 2);
            GeoPoint sumb3 = new GeoPoint(coord.X + ms.Width / 2, coord.Y + ms.Height / 2);
            GeoPoint sumb4 = new GeoPoint(coord.X + ms.Width / 2, coord.Y - ms.Height / 2);

            GeoPoint con = new GeoPoint(1000000, gp.Y); // конец линии
            int sum = 0;
            

            var t = calcul(gp, con, sumb1, sumb2);
            var t1 = calcul(gp, con, sumb2, sumb3);
            var t2 = calcul(gp, con, sumb3, sumb4);
            var t3 = calcul(gp, con, sumb4, sumb1);

            if (t == true)
            {
                sum++;
            }
            if (t1 == true)
            {
                sum++;
            }
            if (t2 == true)
            {
                sum++;
            }
            if (t3 == true)
            {
                sum++;
            }


            if (sum % 2 == 0 || sum == 0) //четное или нет 
            {
                this.IsSelect = false;
                return null; //если четтное и если 0
            }
            else
            {
                this.IsSelect = true;
             
                return this;   // если не четное      
            }      

        }

       


    }
}
