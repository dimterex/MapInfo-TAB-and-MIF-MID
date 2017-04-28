using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Map : UserControl
    {
        public List<Layer> layers = new List<Layer>();

        public GeoPoint Center = new GeoPoint(0,0);
        public double scale = 1;

        public System.Drawing.Point MapToScreen(GeoPoint p) // преобразование в пиксели
        {
            int Xs = (int) Math.Round((p.X - Center.X) * scale + (Width / 2));
            int Ys = (int)Math.Round((Height / 2) - (p.Y - Center.Y) * scale);

            return new System.Drawing.Point(Xs, Ys);
        }

      
        public GeoPoint ScreenToMap(System.Drawing.Point p) //преобразование из пикселей
        {
            double X = ((p.X - (Width / 2)) / scale) + Center.X;
            double Y = (((Height / 2) - p.Y ) / scale) + Center.Y;

            return new GeoPoint(X,Y);
        }





        public void AddLayer(Layer l) //добавить слой 
        {
            l.map = this;
            layers.Add(l);
        }


        public void DeleteLayer(Layer l) //удалить слой 
        {
            layers.Remove(l);
        }

        public Layer GetLayer(int index) //поиск слоя 
        {
            return layers[index];
        }

        

        public void Draw(object sender, PaintEventArgs e)
        {
            for(int i = 0; i < layers.Count(); i++)
            {
                if(layers[i].IsVisible) // == true
                {
                    layers[i].Draw(e);
                }
            }
        }



        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Map
            // 
            this.Name = "Map";
            this.Size = new System.Drawing.Size(429, 264);
            this.ResumeLayout(false);
           // this.Paint += new System.Windows.Forms.PaintEventHandler(this.Draw);
            this.Paint += Map_Paint;
            // this.MouseWheel += new MouseEventHandler(this.Wheel);
           

        }

       

        private void Map_Paint(object sender, PaintEventArgs e)
        {
            Draw(sender, e);
        }


        public MapObject FindObject(GeoPoint gp, double d)  //поиск объекта на карте 'd=2/scale'
        {
            MapObject m;

            for(int i = layers.Count - 1; i >= 0; i--)
            {
                if(layers[i].IsVisible == true)
                {
                    m = layers[i].FindObject(gp, d);

                    if (m != null)
                    {
                        return m;
                    }
                }                
            }

            return null;
           
        }

    }
}
