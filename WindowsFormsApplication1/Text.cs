﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
  public  class Text : MapObject
    {

        private GeoPoint coord;

        private  string text;

        public Font font;
        public SolidBrush brush;
        public SolidBrush invers;
        private SizeF ms;


        public Text(GeoPoint coord, string text)
        {
            this.coord = coord;
            this.text = text;

            type = ObjectType.Text;

            font = new Font("TimesNewRoman", 14);
            brush = new SolidBrush(Color.Red);

            var b = brush.Color.B;
            var r = brush.Color.R;
            var g = brush.Color.G;
            var c = Color.FromArgb(255 - r, 255 - g, 255 - b);
            invers = new SolidBrush(c);
        }

        public string Txt
        {
            set { text = value; }
            get { return text; }
        }


        public override void Draw(PaintEventArgs e) //прорисовка точки
        {
            if (layer == null)
            {
                return;
            }

            if (layer.map == null)
            {
                return;

            }

            Graphics context = Graphics.FromHwnd(layer.map.Handle);
            context.MeasureString(text, font);

            System.Drawing.Point P = layer.map.MapToScreen(coord);

            if (IsSelect == true)
            {
                e.Graphics.DrawString(text, font, invers, (float)P.X / 2, (float)P.Y / 2);
            }
            else
            {
                e.Graphics.DrawString(text, font, brush, (float)P.X / 2, (float)P.Y / 2);
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
                return null; //если четтное и если 0
            }
            else
            {
                this.IsSelect = true;
                this.brush = new SolidBrush(Color.Black);
                return this;   // если не четное      
            }

        }


    }
                

    }

