using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        const double zoom = 1.25;
        bool flag = false;
        System.Drawing.Point sel;
       
        public Form1()
        {
            InitializeComponent();
            map1.MouseWheel += map1_MouseWheel;
            map1.KeyDown += Map1_KeyDown;
            this.ResizeRedraw = true;
        }

        private void Map1_KeyDown(object sender, KeyEventArgs e)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;
            //e.KeyCode
            //if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            // {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    {
                        map1.Center.Y = map1.Center.Y + 1;
                        map1.Refresh();
                        break;
                    }


                case Keys.Up:
                    {
                        map1.Center.Y = map1.Center.Y - 1;
                        map1.Refresh();
                        break;
                    }

                case Keys.Left:
                    {
                        map1.Center.X = map1.Center.X + 1;
                        map1.Refresh();
                        break;
                    }

                case Keys.Right:
                    {
                        map1.Center.X = map1.Center.X - 1;
                        map1.Refresh();
                        break;
                    }

                case Keys.OemMinus:
                    {
                        map1.scale = map1.scale / zoom;
                        map1.Refresh();
                        break;
                    }

                case Keys.Oemplus:
                    {
                        map1.scale = map1.scale * zoom;
                        map1.Refresh();
                        break;
                    }

                case Keys.Add:
                    {
                        map1.scale = map1.scale * zoom;
                        map1.Refresh();
                        break;
                    }
                case Keys.Subtract:
                    {
                        map1.scale = map1.scale / zoom;
                        map1.Refresh();
                        break;
                    }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            map1.Refresh();
        }





        private void map1_Paint(object sender, PaintEventArgs e)
        {
            map1.Draw(sender, e);
        }




        private void map1_MouseClick(object sender, MouseEventArgs e)
        {
          //  sel = new System.Drawing.Point(e.Location.X, e.Location.Y);
          //  label1.Text = map1.ScreenToMap(sel).X.ToString();
           // label2.Text = map1.ScreenToMap(sel).Y.ToString();
        }

        private void map1_MouseDown(object sender, MouseEventArgs e) // клик по карте
        {
            sel = new System.Drawing.Point(e.Location.X, e.Location.Y);
            if (check_zoom.Checked == true) //лупа 
            {
               // System.Drawing.Point sel = new System.Drawing.Point(e.Location.X, e.Location.Y);
                map1.Center.X = map1.ScreenToMap(sel).X;
                map1.Center.Y = map1.ScreenToMap(sel).Y;
                map1.Cursor = Cursors.Cross;

                if (zoom_minus.Checked != true) //лупа 
                {
                    map1.scale = map1.scale * zoom;
                }


                if (zoom_plus.Checked != true) //лупа 
                {
                    map1.scale = map1.scale / zoom;

                }
                flag = true;
            }


            if (check_move.Checked == true) //перемещнение 
            {
                sel = e.Location;
                flag = true;
            }

            if (select_check.Checked == true)
            {
                for (int i = 0; i < map1.layers.Count(); i++)
                {
                    for (int j = 0; j < map1.GetLayer(i).Count(); j++)
                    {
                        map1.GetLayer(i).GetObject(j).IsSelect = false;
                    }
                }

                map1.FindObject(map1.ScreenToMap(sel), 4);
               flag = true;
              
            }


        }



        private void map1_MouseUp(object sender, MouseEventArgs e) //отпускать карту
        {
            if (check_zoom.Checked == true) //лупа 
            {
                map1.Refresh();
                flag = false;
            }

            if (check_move.Checked == true) //перемещнение 
            {
                map1.Refresh();
                flag = false;
            }

            if (select_check.Checked == true) // выделение 
            {
                map1.Refresh();
                flag = false;
            }

            if (zoom_minus.Checked == true) //лупа 
            {
                map1.Refresh();
                flag = false;
            }

            if (zoom_plus.Checked == true) //лупа 
            {
                map1.Refresh();
                flag = false;
            }

        }

        private void check_zoom_CheckedChanged(object sender, EventArgs e)
        {
            if (check_zoom.Checked == true)
            {                
                zoom_minus.Visible = true;
                zoom_plus.Visible = true;

                check_move.Checked = false;
                select_check.Checked = false;
            }

        }

        private void map1_MouseMove(object sender, MouseEventArgs e)
        {
            if (check_move.Checked == true && flag == true)  //перемещене 
            {
                double dy = e.Location.Y - sel.Y;
                double dx = e.Location.X - sel.X;

                double dym = dy / map1.scale;
                double dxm = dx / map1.scale;

                map1.Center.Y = map1.Center.Y + dym;
                map1.Center.X = map1.Center.X - dxm;

                sel = e.Location;
                map1.Refresh();
            }
        }


        private void map1_MouseWheel(object sender, MouseEventArgs e)
        {

            if (e.Delta < 0)
            {
                map1.scale = map1.scale / zoom;
                // map1.Cursor = Cursors.Cross;
                map1.Refresh();
            }
            if (e.Delta > 0)
            {
                map1.scale = map1.scale * zoom;
                // map1.Cursor = Cursors.Cross;
                map1.Refresh();
            }

        }

        private void check_move_CheckedChanged(object sender, EventArgs e)
        {
            if (check_move.Checked == true)
            {
                select_check.Checked = false;

                zoom_minus.Visible = false;
                zoom_plus.Visible = false;
                map1.Cursor = Cursors.Hand;
                check_zoom.Checked = false;
            }
           
        }

        private void LayerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void zoom_plus_CheckedChanged(object sender, EventArgs e)
        {
            if (zoom_plus.Checked == true)
            {
                zoom_minus.Checked = false;
                flag = true;
                if (check_zoom.Checked == true) //лупа 
                {
                    map1.scale = map1.scale * zoom;
                    map1.Cursor = Cursors.Cross;
                }
            }
           
        }



        private void zoom_minus_CheckedChanged(object sender, EventArgs e)
        {
            if (zoom_minus.Checked == true)
            {
                zoom_plus.Checked = false;
                flag = true;
                if (check_zoom.Checked == true) //лупа 
                {
                    map1.scale = map1.scale / zoom;
                    map1.Cursor = Cursors.Cross;

                }
            }
            
        }

        private void select_check_CheckedChanged(object sender, EventArgs e)
        {
            if (select_check.Checked == true)
            {
                check_move.Checked = false;
                check_zoom.Checked = false;

                zoom_minus.Checked = false;
                zoom_minus.Visible = false;

                zoom_plus.Visible = false;
                zoom_plus.Checked = false;
            }
            
        }

        private void Down_layer_Click(object sender, EventArgs e)
        {
            if (LayerListBox.Items != null)
            {

                var itm = LayerListBox.SelectedItem;
                var indx = LayerListBox.SelectedIndex;
                int tmpindx;

                var s = LayerListBox.CheckedItems;


                if (indx < LayerListBox.Items.Count - 1 & itm != null)
                {
                    tmpindx = indx + 1;

                    var dd = map1.GetLayer(indx);
                    var ss = map1.GetLayer(tmpindx);
                    map1.layers[indx] = map1.layers[tmpindx];
                    map1.layers[tmpindx] = dd;

                    var tmpItem = LayerListBox.Items[tmpindx];

                    LayerListBox.Items.RemoveAt(indx);
                    LayerListBox.Items.Insert(indx, tmpItem);
                    LayerListBox.Items.RemoveAt(tmpindx);
                    LayerListBox.Items.Insert(tmpindx, itm);

                    LayerListBox.SetItemChecked(indx, true);

                    LayerListBox.SetItemChecked(tmpindx, true);

                    map1.Refresh();
                }
            }


        }

        private void LayerListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (LayerListBox != null)
            {
                if (e.CurrentValue == CheckState.Checked)
                {
                    var q = LayerListBox.Items[e.Index];
                    var ww = map1.GetLayer(e.Index);
                    ww.IsVisible = false;
                    map1.Refresh();
                }

                if (e.CurrentValue == CheckState.Unchecked)
                {
                    var q = LayerListBox.Items[e.Index];
                    var ww = map1.GetLayer(e.Index);
                    ww.IsVisible = true;
                    map1.Refresh();
                }


            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();

            double xMax = 0, xMin = 0, yMax = 0, yMin = 0;

            OFD.Filter = "MIF файлы (*.mif)|*.mif|TXT файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (OFD.ShowDialog() == DialogResult.OK)
            {                     
                string nam = OFD.FileName;
                var filenam = OFD.SafeFileName;

                string fileExtension = Path.GetExtension(nam);

                if (fileExtension != ".txt" && fileExtension != ".mif" && fileExtension != ".fand")
                {
                    MessageBox.Show("Программа не может открывать файлы с таким форматом!");
                    return;
                }
                
                StreamReader fs = new StreamReader(@nam);


                for (int i1 = 0; i1 < map1.layers.Count; i1++)
                {
                    if (map1.layers[i1].Name == Path.GetFileNameWithoutExtension(filenam))
                    {
                        MessageBox.Show("Слой с таким именем уже существует!");
                        return;
                    }

                    //if (map1.layers[i1].Xmax > xMax)
                    //{
                    //    xMax = map1.layers[i1].Xmax ;
                    //}
                    //if (map1.layers[i1].Ymax > yMax)
                    //{
                    //    yMax = map1.layers[i1].Ymax  ;
                    //}

                    //if (map1.layers[i1].Xmin < xMin)
                    //{
                    //    xMin = map1.layers[i1].Xmin ;
                    //}
                    //if (map1.layers[i1].Ymin < yMin)
                    //{
                    //    yMin =  map1.layers[i1].Ymin ;
                    //}
                }

                Layer l = new Layer(Path.GetFileNameWithoutExtension(filenam));
                map1.AddLayer(l);
                var asd = LayerListBox.Items.Add(l.Name);
                int www = LayerListBox.Items.IndexOf(l.Name);

                LayerListBox.SetItemChecked(LayerListBox.Items.IndexOf(l.Name), true);



                List<string> DataStrings = new List<string>();
                string ReadedLine = "";
                bool toRead = false;

                bool firstopen = true;

                while ((ReadedLine = fs.ReadLine()) != null)
                {
                    ReadedLine = ReadedLine.ToUpper();
                    if ((toRead == true) && (ReadedLine != ""))
                        DataStrings.Add(ReadedLine);
                    if (ReadedLine.Trim(' ') == "DATA") toRead = true;
                }

                List<string> SeparatePartsOfString = new List<string>();
                char[] SeparateSymbols = new char[] { ' ', ',', '(', ')' };
                for (int i = 0; i < DataStrings.Count; i++)
                {
                    SeparatePartsOfString = (DataStrings[i].Split(SeparateSymbols)).ToList();
                    ClearEmptyStrings(SeparatePartsOfString);
                    if (SeparatePartsOfString.Count > 0)
                    {
                        switch (SeparatePartsOfString[0])
                        {
                            case "POINT":
                                double x = double.Parse(SeparatePartsOfString[1].Replace('.', ','));  
                                double y = double.Parse(SeparatePartsOfString[2].Replace('.', ','));


                                if (firstopen == true)
                                {
                                    l.Xmax = x;
                                    xMax = x;
                                    l.Xmin = x;
                                    xMin =x   ;
                                    l.Ymax = y;
                                    yMax = y;
                                    l.Ymin = y;
                                    yMin = y;
                                    firstopen = false;
                                }
                                else
                                {
                                    if (x > l.Xmax)
                                    {
                                        l.Xmax = x;
                                        xMax = x;
                                    }
                                    if (y > l.Ymax)
                                    {
                                        l.Ymax = y;
                                        yMax = y;
                                    }

                                    if (x < l.Xmin)
                                    {
                                        l.Xmin = x;
                                        xMin = x;
                                    }
                                    if (y < l.Ymin)
                                    {
                                        l.Ymin = y;
                                        yMin = y;
                                    }
                                }                               

                                Point point = new Point(x, y);
                                if (DataStrings.Count > i + 1)
                                {
                                    SeparatePartsOfString = (DataStrings[i + 1].Split(SeparateSymbols)).ToList();
                                    ClearEmptyStrings(SeparatePartsOfString);
                                    if (SeparatePartsOfString[0] == "SYMBOL")
                                    {

                                        point.symbol = byte.Parse(SeparatePartsOfString[1]);
                                        int intColor = int.Parse(SeparatePartsOfString[2]);
                                        point.brush.Color = Color.FromArgb((intColor & 0xFF0000) / 65536, (intColor & 0xFF00) / 256, (intColor & 0xFF));
                                        //point.Style.Size = int.Parse(SeparatePartsOfString[3]);
                                        i++;
                                    }
                                }
                                l.AddObject(point);
                                
                                break;

                            case "LINE":
                                double x1 = double.Parse(SeparatePartsOfString[1].Replace('.', ','));
                                double y1 = double.Parse(SeparatePartsOfString[2].Replace('.', ','));
                                double x2 = double.Parse(SeparatePartsOfString[3].Replace('.', ','));
                                double y2 = double.Parse(SeparatePartsOfString[4].Replace('.', ','));

                                if (firstopen == true)
                                {
                                    if (x1>x2)
                                    {
                                        l.Xmax = x1;
                                        xMax = x1;
                                        l.Xmin = x2;
                                        xMin = x2;
                                    }
                                    else
                                    {
                                        l.Xmin = x1;
                                        xMin = x1 ;
                                        l.Xmax = x2;
                                        xMax = x2 ;                                       
                                    }

                                    if (y1 > y2)
                                    {
                                        l.Ymax = y1;
                                        yMax= y1  ;
                                        l.Ymin = y2;
                                        yMin= y2  ;
                                    }
                                    else
                                    {
                                        l.Ymax = y2;
                                        yMax= y2  ;
                                        l.Ymin = y1;
                                        yMin= y1  ;
                                    }                                                                     
                                    firstopen = false;
                                }
                                else
                                {
                                    if (x1 > l.Xmax)
                                    {
                                        l.Xmax = x1;
                                        xMax= x1  ;
                                    }
                                    if (y1 > l.Ymax)
                                    {
                                        l.Ymax = y1;
                                        yMax = y1  ;
                                    }

                                    if (x1 < l.Xmin)
                                    {
                                        l.Xmin = x1;
                                        xMin= x1  ;
                                    }
                                    if (y1 < l.Ymin)
                                    {
                                        l.Ymin = y1;
                                        yMin= y1  ;
                                    }

                                    if (x2 > l.Xmax)
                                    {
                                        l.Xmax = x2;
                                        xMax=x2  ;
                                    }
                                    if (y2 > l.Ymax)
                                    {
                                        l.Ymax = y2;
                                        yMax= y2 ;
                                    }

                                    if (x2 < l.Xmin)
                                    {
                                        l.Xmin = x2;
                                        xMin= x2 ; 
                                    }
                                    if (y2 < l.Ymin)
                                    {
                                        l.Ymin = y2;
                                        yMin=y2 ;
                                    }
                                }
                                Line line = new Line(x1, y1, x2, y2);
                                if (DataStrings.Count > i + 1)
                                {
                                    SeparatePartsOfString = (DataStrings[i + 1].Split(SeparateSymbols)).ToList();
                                    ClearEmptyStrings(SeparatePartsOfString);
                                    if (SeparatePartsOfString[0] == "PEN")
                                    {
                                        line.pen.Width = int.Parse(SeparatePartsOfString[1]);
                                       // line.pen.PenType = int.Parse(SeparatePartsOfString[2]);
                                        int intColor = int.Parse(SeparatePartsOfString[3]);
                                        //  line.pen.Color = Color.FromArgb((intColor & 0xFF0000) / 65536, (intColor & 0xFF00) / 256, (intColor & 0xFF));
                                        line.pen = new Pen(Color.FromArgb((intColor & 0xFF0000) / 65536, (intColor & 0xFF00) / 256, (intColor & 0xFF)));

                                        var b = line.pen.Color.B;
                                        var r = line.pen.Color.R;
                                        var g = line.pen.Color.G;
                                        var c = Color.FromArgb(255 - r, 255 - g, 255 - b);
                                        line.invers = new Pen(c);

                                        i++;
                                    }
                                }
                                l.AddObject(line);
                                break;

                            case "PLINE":
                                i++;
                                double nodeX, nodeY;
                                string nodes = DataStrings[i].Trim(' ');
                                int nodesCount = int.Parse(nodes);
                                PolyLine polyline = new PolyLine();
                                for (int j = 0; j < nodesCount; j++)
                                {
                                    i++;
                                    SeparatePartsOfString = (DataStrings[i].Split(SeparateSymbols)).ToList();
                                    ClearEmptyStrings(SeparatePartsOfString);
                                    nodeX = double.Parse(SeparatePartsOfString[0].Replace('.', ','));
                                    nodeY = double.Parse(SeparatePartsOfString[1].Replace('.', ','));


                                    if (firstopen == true)
                                    {
                                        l.Xmax = nodeX;
                                        xMax = nodeX ;
                                        l.Xmin = nodeX;
                                        xMin = nodeX  ;
                                        l.Ymax = nodeY;
                                        yMax = nodeY  ;
                                        l.Ymin = nodeY;
                                        yMin= nodeY  ;
                                        firstopen = false;
                                    }
                                    else
                                    {
                                        if (nodeX > l.Xmax)
                                        {
                                            l.Xmax = nodeX;
                                            yMax = nodeX ;
                                        }
                                        if (nodeY > l.Ymax)
                                        {
                                            l.Ymax = nodeY;
                                            yMax = nodeY  ;
                                        }

                                        if (nodeX < l.Xmin)
                                        {
                                            l.Xmin = nodeX;
                                            xMin = nodeX  ;
                                        }
                                        if (nodeY < l.Ymin)
                                        {
                                            l.Ymin = nodeY;
                                            yMin =  nodeY  ;
                                        }
                                    }

                                    polyline.AddNodes(nodeX, nodeY);
                                    if ((DataStrings.Count > i + 1) && (j == nodesCount - 1))
                                    {
                                        SeparatePartsOfString = (DataStrings[i + 1].Split(SeparateSymbols)).ToList();
                                        ClearEmptyStrings(SeparatePartsOfString);
                                        if (SeparatePartsOfString[0] == "PEN")
                                        {
                                            polyline.pen.Width = int.Parse(SeparatePartsOfString[1]);
                                          //  polyline.PenType = int.Parse(SeparatePartsOfString[2]);
                                            int intColor = int.Parse(SeparatePartsOfString[3]);
                                            // polyline.pen.Color = Color.FromArgb((intColor & 0xFF0000) / 65536, (intColor & 0xFF00) / 256, (intColor & 0xFF));
                                            polyline.pen = new Pen(Color.FromArgb((intColor & 0xFF0000) / 65536, (intColor & 0xFF00) / 256, (intColor & 0xFF)));

                                            var b = polyline.pen.Color.B;
                                            var r = polyline.pen.Color.R;
                                            var g = polyline.pen.Color.G;
                                            var c = Color.FromArgb(255 - r, 255 - g, 255 - b);
                                            polyline.invers = new Pen(c);
                                            i++;
                                        }
                                    }
                                }
                                l.AddObject(polyline);
                                break;

                            case "REGION":
                                i++;
                                string polygonNodes = DataStrings[i].Trim(' ');
                                int count = int.Parse(polygonNodes);
                                PolyGon polygon = new PolyGon();
                                for (int k = 0; k < count; k++)
                                {
                                    i++;
                                    SeparatePartsOfString = (DataStrings[i].Split(SeparateSymbols)).ToList();
                                    ClearEmptyStrings(SeparatePartsOfString);
                                    x = double.Parse(SeparatePartsOfString[0].Replace('.', ','));
                                    y = double.Parse(SeparatePartsOfString[1].Replace('.', ','));

                                    if (firstopen == true)
                                    {
                                        l.Xmax = x;
                                        xMax = x  ;
                                        l.Xmin = x;
                                        xMin = x  ;
                                        l.Ymax = y;
                                        yMax = y  ;
                                        l.Ymin = y;
                                        yMin = y  ;
                                        firstopen = false;
                                    }
                                    else
                                    {
                                        if (x > l.Xmax)
                                        {
                                            l.Xmax = x;
                                            xMax= x  ;
                                        }
                                        if (y > l.Ymax)
                                        {
                                            l.Ymax = y;
                                            yMax =y  ;
                                        }

                                        if (x < l.Xmin)
                                        {
                                            l.Xmin = x;
                                            xMin =x  ;
                                        }
                                        if (y < l.Ymin)
                                        {
                                            l.Ymin = y;
                                            yMin= y  ;
                                        }
                                    }

                                    polygon.AddNodes(new GeoPoint(x, y));
                                    if ((DataStrings.Count > i + 1) && (k == count - 1))
                                    {
                                        SeparatePartsOfString = (DataStrings[i + 1].Split(SeparateSymbols)).ToList();
                                        ClearEmptyStrings(SeparatePartsOfString);
                                        if (SeparatePartsOfString[0] == "PEN")
                                        {
                                            polygon.pen.Width = int.Parse(SeparatePartsOfString[1]);
                                            //polygon.pen.PenType = int.Parse(SeparatePartsOfString[2]);
                                            int intColor = int.Parse(SeparatePartsOfString[3]);
                                            //  polygon.pen.Color = Color.FromArgb((intColor & 0xFF0000) / 65536, (intColor & 0xFF00) / 256, (intColor & 0xFF));
                                            polygon.pen = new Pen(Color.FromArgb((intColor & 0xFF0000) / 65536, (intColor & 0xFF00) / 256, (intColor & 0xFF)));

                                            //var b = polygon.pen.Color.B;
                                            //var r = polygon.pen.Color.R;
                                            //var g = polygon.pen.Color.G;
                                            //var c = Color.FromArgb(255 - r, 255 - g, 255 - b);
                                            //polygon.invers = new Pen(c);

                                            i++;
                                            if (DataStrings.Count > i + 1)
                                            {
                                                SeparatePartsOfString = (DataStrings[i + 1].Split(SeparateSymbols)).ToList();
                                                ClearEmptyStrings(SeparatePartsOfString);
                                                if (SeparatePartsOfString.Count > 0)
                                                {
                                                    if (SeparatePartsOfString[0] == "BRUSH")
                                                    {
                                                        intColor = int.Parse(SeparatePartsOfString[2]);
                                                        //polygon.brush.Color = Color.FromArgb((intColor & 0xFF0000) / 65536, (intColor & 0xFF00) / 256, (intColor & 0xFF));
                                                        polygon.brush = new SolidBrush(Color.FromArgb((intColor & 0xFF0000) / 65536, (intColor & 0xFF00) / 256, (intColor & 0xFF)));

                                                        var b = polygon.brush.Color.B;
                                                        var r = polygon.brush.Color.R;
                                                        var g = polygon.brush.Color.G;
                                                        var c = Color.FromArgb(255 - r, 255 - g, 255 - b);
                                                        polygon.brushinverse = new SolidBrush(c);

                                                        i++;
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                l.AddObject(polygon);
                                break;
                            default:                               
                                break;


                        } //end switc
                    } // end if 
                }//end for


                for (int i1 = 0; i1 < map1.layers.Count; i1++)
                {
                    //if (map1.layers[i1].Name == Path.GetFileNameWithoutExtension(filenam))
                    //{
                    //    MessageBox.Show("Слой с таким именем уже существует!");
                    //    return;
                    //}

                    if (map1.layers[i1].Xmax > xMax)
                    {
                        xMax = map1.layers[i1].Xmax;
                    }
                    if (map1.layers[i1].Ymax > yMax)
                    {
                        yMax = map1.layers[i1].Ymax;
                    }

                    if (map1.layers[i1].Xmin < xMin)
                    {
                        xMin = map1.layers[i1].Xmin;
                    }
                    if (map1.layers[i1].Ymin < yMin)
                    {
                        yMin = map1.layers[i1].Ymin;
                    }
                }

                map1.Center.X = (xMax + xMin) / 2;
                map1.Center.Y = (yMax + yMin) / 2;

                var h = map1.Size.Height / (yMax - yMin);
                var w = map1.Size.Width / (xMax - yMin);

                //map1.Center.X = (l.Xmax + l.Xmin) / 2;
                //map1.Center.Y = (l.Ymax + l.Ymin) / 2;

                //var h = map1.Size.Height / (l.Xmax - l.Xmin);
                //var w = map1.Size.Width / (l.Ymax - l.Ymin);
                if (h < w)
                {
                    map1.scale = h;
                }
                else
                {
                    map1.scale = w;
                }

                map1.Refresh();


            }



        }               



        public void ClearEmptyStrings(List<string> list)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i] == "")
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {                    
            List<Point> lpn = new List<Point>();

            int sum = 0;
            for (int i = 0; i < map1.layers.Count(); i++)
            {
                for (int j = 0; j < map1.GetLayer(i).Count(); j++)
                {
                    if (map1.GetLayer(i).GetObject(j).Type_1.ToString() == "Point")
                    {
                        var poin = map1.GetLayer(i).GetObject(j) as Point;
                        lpn.Add(poin);
                    }
                }
            }

            for (int i = 0; i < map1.layers.Count(); i++)
            {
                for (int j = 0; j < map1.GetLayer(i).Count(); j++)
                {
                    if (map1.GetLayer(i).GetObject(j).Type_1.ToString() == "Polygon")
                    {
                        var pol = map1.GetLayer(i).GetObject(j) as PolyGon;

                        if (pol.IsSelect == true) //выделен ли полигон
                        {
                           for (int k = 0; k < lpn.Count(); k++)
                            {
                                if (pol.Individual(lpn[k]) == true)
                                {
                                    sum = sum + 1;
                                }
                            }

                         
                        }
                    }
                }
            }

            map1.Refresh();
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Up_layer_Click(object sender, EventArgs e)
        {
            if (LayerListBox.Items != null)
            {
                var itm = LayerListBox.SelectedItem;
                var indx = LayerListBox.SelectedIndex;

                int tmpindx;

                if (indx > 0 & itm != null)
                {
                    tmpindx = indx - 1;

                    var dd = map1.GetLayer(indx);
                    var ss = map1.GetLayer(tmpindx);
                    map1.layers[indx] = map1.layers[tmpindx];
                    map1.layers[tmpindx] = dd;

                    var tmpItem = LayerListBox.Items[tmpindx];

                    LayerListBox.Items.RemoveAt(indx);
                    LayerListBox.Items.Insert(indx, tmpItem);
                    LayerListBox.Items.RemoveAt(tmpindx);
                    LayerListBox.Items.Insert(tmpindx, itm);

                    LayerListBox.SetItemChecked(indx, true);

                    LayerListBox.SetItemChecked(tmpindx, true);

                    map1.Refresh();
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (LayerListBox.Items != null && LayerListBox.SelectedIndex >= 0)
            {           
                    var indx = LayerListBox.SelectedIndex;
                    LayerListBox.Items.RemoveAt(indx);
                    map1.DeleteLayer(map1.GetLayer(indx));
                    map1.Refresh();      
            }
        }

        private void map1_AutoSizeChanged(object sender, EventArgs e)
        {
            map1.Refresh();
        }

        private void map1_SizeChanged(object sender, EventArgs e)
        {
            map1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Layer l = new Layer("Line");
            Layer p = new Layer("Polygon");
            Layer pn = new Layer("Point");

            map1.AddLayer(l);
            map1.AddLayer(p);
            map1.AddLayer(pn);

            LayerListBox.Items.Add(l.Name);
            LayerListBox.Items.IndexOf(l.Name);

            LayerListBox.SetItemChecked(LayerListBox.Items.IndexOf(l.Name), true);

            LayerListBox.Items.Add(p.Name);
            LayerListBox.Items.IndexOf(p.Name);
            LayerListBox.SetItemChecked(LayerListBox.Items.IndexOf(p.Name), true);

            LayerListBox.Items.Add(pn.Name);
            LayerListBox.Items.IndexOf(pn.Name);
            LayerListBox.SetItemChecked(LayerListBox.Items.IndexOf(pn.Name), true);

            GeoPoint gp1 = new GeoPoint(0, 0);
            GeoPoint gp2 = new GeoPoint(100, 100);


            Point p1 = new Point(0, 0);
            Point p2 = new Point(100, 100);

            Point p3 = new Point(21, 21);
            Point p4 = new Point(50, 50);

            Point p5 = new Point(79, 79);

            p1.symbol = 64;
            p2.symbol = 64;
            p3.symbol = 64;
            p4.symbol = 64;
            p5.symbol = 64;
            

            Line ln = new Line(gp1, gp2);


           

            PolyGon pg = new PolyGon();
            pg.AddNodes(new GeoPoint(20, 20));
            pg.AddNodes(new GeoPoint(20, 80));
            pg.AddNodes(new GeoPoint(80, 80));
            pg.AddNodes(new GeoPoint(80, 20));

            l.AddObject(ln);
            p.AddObject(pg);
            pn.AddObject(p1);
            pn.AddObject(p2);
            pn.AddObject(p3);
            pn.AddObject(p4);
            pn.AddObject(p5);
            map1.Refresh();

        }
    }
}
