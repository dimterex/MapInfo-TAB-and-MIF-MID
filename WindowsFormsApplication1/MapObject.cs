using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace WindowsFormsApplication1
{

    public enum ObjectType { Point, Line, Polyline, Polygon, Text } //типы различные


   public class MapObject
    {
        public bool IsVisible = true; //видимость на карте

        public bool IsSelect = false; //выделенность на карте

        public virtual void Draw(PaintEventArgs e)
        {

        }

        public Point pnt;        
       

        
        protected ObjectType type;

        public Layer layer; // к какому слою принадлежит
        

       // один из двух ниже описанных
        public ObjectType Type () //возвращение типа    МЕТОД
        {
            return type;
        }

        public ObjectType Type_1 // возвращение типа СВОЙСТВО   
        {
            get { return type; }
        }
        

        public virtual MapObject IsCross(GeoPoint gp, double d)
        //метод луча точка полигон текст
        //векторное произведение линии полилинии  вынести в мапобъекты как одну функцию bool result
        {
            return this;
        }

        public bool calcul(GeoPoint a1, GeoPoint a2, GeoPoint b1, GeoPoint b2)
        {
            double v1 = (b2.X - b1.X) * (a1.Y - b1.Y) - (a1.X - b1.X) * (b2.Y - b1.Y); // 
            double v2 = (b2.X - b1.X) * (a2.Y - b1.Y) - (a2.X - b1.X) * (b2.Y - b1.Y); //
            double v3 = (a2.X - a1.X) * (b1.Y - a1.Y) - (b1.X - a1.X) * (a2.Y - a1.Y);// 
            double v4 = (a2.X - a1.X) * (b2.Y - a1.Y) - (b2.X - a1.X) * (a2.Y - a1.Y); // 

            if ((v1 * v2 < 0) && (v3 * v4 < 0))
            {
                return true;
            }
           
            return false;
        }

    }
}
