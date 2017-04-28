using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class PolyGon:PolyLine
    {
        

        
        public Font font;
        public SolidBrush brush;

        public SolidBrush brushinverse;

        public int symbol;
        public char smb;

        public double SumOfSides()//площадь полигона
        {
            double res = 0;
            double x1x2 = Math.Pow((GetNode(0).X - GetNode(Count() - 1).X), 2);
            double y1y2 = Math.Pow((GetNode(0).Y - GetNode(Count() - 1).Y), 2);
            double sum = Math.Sqrt(x1x2 + y1y2);
            res = lenght() + sum;

            return res;
        }

        public PolyGon()
        {
            type = ObjectType.Polygon;
            pen = new Pen(Color.Red);
            brush = new SolidBrush(Color.Beige);

            var b = brush.Color.B;
            var r = brush.Color.R;
            var g = brush.Color.G;
            var c = Color.FromArgb(255 - r, 255 - g, 255 - b);
            invers = new Pen(c);
            brushinverse = new SolidBrush(c);
        }


        public override void Draw(PaintEventArgs e) //прорисовка линии
        {
            List<System.Drawing.PointF> ps = new List<System.Drawing.PointF>();

            if (layer == null)
            {
                return;
            }

            if (layer.map == null)
            {
                return;
            }

            for (int i = 0; i < nodes.Count(); i++)
            {
                System.Drawing.PointF p = layer.map.MapToScreen(nodes[i]);
                ps.Add(p);
            }

            if (IsSelect == true)
            {
                e.Graphics.FillPolygon(brushinverse, ps.ToArray());
                e.Graphics.DrawPolygon(invers, ps.ToArray());
            }
            else
            {
                e.Graphics.FillPolygon(brush, ps.ToArray());
                e.Graphics.DrawPolygon(pen, ps.ToArray());
            }
           
        }

        public override MapObject IsCross(GeoPoint gp, double d)
        {
            
            GeoPoint con = new GeoPoint(1000000, gp.Y); // конец линии
            int sum = 0;


            for (int i = 0; i < (nodes.Count() - 1); i++)
            {
                var t = calcul(gp, con, nodes[i], nodes[i+1]);

                if (t == true)
                {
                    sum++;
                }
            }

            var t1 = calcul(gp, con, nodes[0], nodes[nodes.Count - 1]);
            if (t1 == true)
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
            //   this.brush = new SolidBrush(Color.Gray);
              //  this.pen = new Pen(Color.Gray);
               
                return this;   // если не четное      
            }

        }


        public bool Individual(Point gp)
        {
            GeoPoint st = new GeoPoint(gp.X, gp.Y);
            GeoPoint con = new GeoPoint(1000000, gp.Y); // конец линии
            int sum = 0;


            for (int i = 0; i < (nodes.Count() - 1); i++)
            {
                var t = calcul(st, con, nodes[i], nodes[i + 1]);

                if (t == true)
                {
                    sum++;
                }
            }

            var t1 = calcul(st, con, nodes[0], nodes[nodes.Count - 1]);
            if (t1 == true)
            {
                sum++;
            }


            if (sum % 2 == 0 || sum == 0) //четное или нет 
            {
                gp.IsSelect = false;
                return false; //если четтное и если 0
            }
            else
            {
                gp.IsSelect = true;
                return true;   // если не четное      
            }

        }
    }
}
