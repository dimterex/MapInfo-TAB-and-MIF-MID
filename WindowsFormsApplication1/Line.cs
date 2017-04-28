using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Line : MapObject
    {
        public GeoPoint BegLine; 
        public GeoPoint EndLine;

        public Pen pen;
        public Pen invers;
       
        //public Font font;
        //public SolidBrush brush;
        //public int symbol;
        //public char smb;


        public Line(GeoPoint bl, GeoPoint el)
        {
            BegLine = bl;
            EndLine = el;

            type = ObjectType.Line;

            pen = new Pen(Color.Blue);
           
            var b = pen.Color.B;
            var r = pen.Color.R;
            var g = pen.Color.G;
            var c = Color.FromArgb(255 - r, 255 - g, 255 - b);
            invers = new Pen(c);
        }

        public Line(double BLx, double BLy, double ELx, double ELy)
        {

            BegLine = new GeoPoint(BLx, BLy);
            EndLine = new GeoPoint(ELx, ELy);
            type = ObjectType.Line;
            pen = new Pen(Color.Blue);

            var b = pen.Color.B;
            var r = pen.Color.R;
            var g = pen.Color.G;
            var c = Color.FromArgb(255 - r, 255 - g, 255 - b);
            invers = new Pen(c);

        }

        public double lenght ()
        {
            double x1x2 = Math.Pow((BegLine.X - EndLine.X), 2);// * (BegLine.X - EndLine.X);
            double y1y2 = Math.Pow((BegLine.Y - EndLine.Y), 2); // (BegLine.Y - EndLine.Y) * (BegLine.Y - EndLine.Y);

            double res = Math.Sqrt(x1x2 + y1y2);
            return res;
        }

        public override void Draw(PaintEventArgs e) //прорисовка линии
        {
            if (layer == null)
            {
                return;
            }

            if (layer.map == null)
            {
                return;

            }
            
            System.Drawing.Point bl = layer.map.MapToScreen(BegLine);
            System.Drawing.Point el = layer.map.MapToScreen(EndLine);

            //e.Graphics.DrawLine(smb.ToString(), font, brush, (float)P.X, (float)P.Y);

            if (IsSelect == true)
            {
                e.Graphics.DrawLine(invers, bl, el);
            }
            else
            {
                e.Graphics.DrawLine(pen, bl, el);
            }
        }


        public override MapObject IsCross(GeoPoint gp, double d)
        //метод луча точка полигон текст 
        {
            //вычислить координаты
            GeoPoint sumb1 = new GeoPoint(gp.X - d, gp.Y - d);
            GeoPoint sumb2 = new GeoPoint(gp.X + d, gp.Y - d);
            GeoPoint sumb3 = new GeoPoint(gp.X - d, gp.Y + d);
            GeoPoint sumb4 = new GeoPoint(gp.X + d, gp.Y + d);

                        
            var t = calcul(BegLine, EndLine, sumb1, sumb2);
            var t1 = calcul(BegLine, EndLine, sumb2, sumb3);
            var t2 = calcul(BegLine, EndLine, sumb3, sumb4);
            var t3 = calcul(BegLine, EndLine, sumb4, sumb1);

            if (t == true)
            {
                this.IsSelect = true;
                
                //  this.brush = new SolidBrush(Color.Black);
                return this;   // если не четное   
            }
            if (t1 == true)
            {
                this.IsSelect = true;
               
                //  this.brush = new SolidBrush(Color.Black);
                return this;   // если не четное   
            }
            if (t2 == true)
            {
                this.IsSelect = true;
                
                //  this.brush = new SolidBrush(Color.Black);
                return this;   // если не четное   
            }
            if (t3 == true)
            {
                this.IsSelect = true;
               
                //  this.brush = new SolidBrush(Color.Black);
                return this;   // если не четное   
            }
            this.IsSelect = false;

            return null;
            

        }

    }

   
}
