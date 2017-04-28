using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class PolyLine : MapObject
    {
        protected List<GeoPoint> nodes = new List<GeoPoint>();
        public Pen pen;
        public Pen invers;
       
        
        public void AddNodes(double x, double y) //добавить точку по координатам в список
        {
            nodes.Add(new GeoPoint(x, y));
        }
        public void AddNodes(GeoPoint P)//добавить точку в список
        {
            nodes.Add(P);
        }
        
        public void DeleteNodes(int i) //удалить по индексу из списка
        {
           
            nodes.RemoveAt(i);
        }

        public void InsertNodes(int i, double x, double y) //добавить точку по координатам в  список в нужную позицию
        {
            nodes.Insert(i, new GeoPoint(x, y));
        }
        public void InsertNodes(int i, GeoPoint P) //добавить точку в  список в нужную позицию
        {
            nodes.Insert(i, P);
        }
        public void Clear() //очистить
        {
            nodes.Clear();
        }
        public int Count() //размерз
        {
            return nodes.Count();
            
        }
        public GeoPoint GetNode(int i) //выбрать один из элементов
        {
            return nodes[i];
        }

        public double lenght() //размерз
        {
            double res = 0;

            for(int i = 0; i < nodes.Count -1 ; i++)
            {
                double x1x2 = Math.Pow((GetNode(i).X - GetNode(i+1).X), 2);
                double y1y2 = Math.Pow((GetNode(i).Y - GetNode(i + 1).Y), 2); 
                 res += Math.Sqrt(x1x2 + y1y2);
            }
                      
            return res;          
         
        }


        public PolyLine()
        {
            type = ObjectType.Polyline;
            pen = new Pen(Color.Green);

            var b = pen.Color.B;
            var r = pen.Color.R;
            var g = pen.Color.G;
            var c = Color.FromArgb(255 - r, 255 - g, 255 - b);
            invers = new Pen(c);
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
            List<System.Drawing.Point> ps = new List<System.Drawing.Point>();
            
            for (int i = 0; i < nodes.Count; i++)
            {
                System.Drawing.Point p = layer.map.MapToScreen(nodes[i]);
                ps.Add(p);             
            }
            if (IsSelect == true)
            {
                e.Graphics.DrawLines(invers, ps.ToArray());
            }
            else
            {
                e.Graphics.DrawLines(pen, ps.ToArray());
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

            for (int i = 0; i < (nodes.Count() - 1); i++)
            {            

                var t = calcul(nodes[i], nodes[i + 1], sumb1, sumb2);
                var t1 = calcul(nodes[i], nodes[i + 1], sumb2, sumb3);
                var t2 = calcul(nodes[i], nodes[i + 1], sumb3, sumb4);
                var t3 = calcul(nodes[i], nodes[i + 1], sumb4, sumb1);

                if (t == true)
                {
                    this.IsSelect = true;
               //     this.pen = new Pen(Color.Black);
                    //  this.brush = new SolidBrush(Color.Black);
                    return this;   // если не четное   
                }
                if (t1 == true)
                {
                    this.IsSelect = true;
                 //   this.pen = new Pen(Color.Black);
                    //  this.brush = new SolidBrush(Color.Black);
                    return this;   // если не четное   
                }
                if (t2 == true)
                {
                    this.IsSelect = true;
                 //   this.pen = new Pen(Color.Black);
                    //  this.brush = new SolidBrush(Color.Black);
                    return this;   // если не четное   
                }
                if (t3 == true)
                {
                    this.IsSelect = true;
                  //  this.pen = new Pen(Color.Black);
                    //  this.brush = new SolidBrush(Color.Black);
                    return this;   // если не четное   
                }
            }
            this.IsSelect = false;


            return null;


        }

    }
}
