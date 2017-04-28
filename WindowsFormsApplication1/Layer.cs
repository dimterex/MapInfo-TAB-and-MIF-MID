using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Layer
    {
        public double Xmin, Xmax, Ymin, Ymax;

        private List<MapObject> objects = new List<MapObject>(); //Список объектов на слое

        public bool IsVisible; //видимость слоя

        public int Order; //порядковый номер слоя

        public Map map; // к какой карте принадлежит

        public string Name;

        public string filename;

     

        public Layer(string str) //
        {
            Name = str;
            IsVisible = true;
        }

        public void AddObject(MapObject m) //добавить объект 
        {
            m.layer = this;
            objects.Add(m);
        }

        public int Count() //количество объектов 
        {
            return objects.Count;
        }

        public MapObject GetObject(int index) //вернуть объект по индексу
        {
            
            return objects[index];
        }

        public void Draw(PaintEventArgs e)
        {
            for (int i = 0; i < objects.Count(); i++)
            {
                if (objects[i].IsVisible == true) // == true
                {
                    objects[i].Draw(e);
                }
            }
        }

        public MapObject FindObject(GeoPoint gp, double d)  //поиск объекта на карте 'd=2/scale'
        {
            MapObject m;

            for (int i = 0; i < objects.Count(); i++)
            {                
                    m = objects[i].IsCross(gp, d);

                    if (m != null)
                    {
                        return m;
                    }                
            }
            return null;
        }

      

    }
}
