namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LayerListBox = new System.Windows.Forms.CheckedListBox();
            this.check_zoom = new System.Windows.Forms.CheckBox();
            this.check_move = new System.Windows.Forms.CheckBox();
            this.zoom_minus = new System.Windows.Forms.CheckBox();
            this.zoom_plus = new System.Windows.Forms.CheckBox();
            this.select_check = new System.Windows.Forms.CheckBox();
            this.Down_layer = new System.Windows.Forms.Button();
            this.Up_layer = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.map1 = new WindowsFormsApplication1.Map();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(771, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            this.файлToolStripMenuItem.Click += new System.EventHandler(this.файлToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // LayerListBox
            // 
            this.LayerListBox.FormattingEnabled = true;
            this.LayerListBox.Location = new System.Drawing.Point(12, 27);
            this.LayerListBox.Name = "LayerListBox";
            this.LayerListBox.Size = new System.Drawing.Size(152, 139);
            this.LayerListBox.TabIndex = 5;
            this.LayerListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.LayerListBox_ItemCheck);
            this.LayerListBox.SelectedIndexChanged += new System.EventHandler(this.LayerListBox_SelectedIndexChanged);
            // 
            // check_zoom
            // 
            this.check_zoom.Appearance = System.Windows.Forms.Appearance.Button;
            this.check_zoom.Location = new System.Drawing.Point(12, 204);
            this.check_zoom.Name = "check_zoom";
            this.check_zoom.Size = new System.Drawing.Size(87, 23);
            this.check_zoom.TabIndex = 6;
            this.check_zoom.Text = "Увеличитель";
            this.check_zoom.UseVisualStyleBackColor = true;
            this.check_zoom.CheckedChanged += new System.EventHandler(this.check_zoom_CheckedChanged);
            // 
            // check_move
            // 
            this.check_move.Appearance = System.Windows.Forms.Appearance.Button;
            this.check_move.Location = new System.Drawing.Point(12, 233);
            this.check_move.Name = "check_move";
            this.check_move.Size = new System.Drawing.Size(87, 23);
            this.check_move.TabIndex = 7;
            this.check_move.Text = "Переместить";
            this.check_move.UseVisualStyleBackColor = true;
            this.check_move.CheckedChanged += new System.EventHandler(this.check_move_CheckedChanged);
            // 
            // zoom_minus
            // 
            this.zoom_minus.Appearance = System.Windows.Forms.Appearance.Button;
            this.zoom_minus.Location = new System.Drawing.Point(105, 233);
            this.zoom_minus.Name = "zoom_minus";
            this.zoom_minus.Size = new System.Drawing.Size(59, 23);
            this.zoom_minus.TabIndex = 14;
            this.zoom_minus.Text = "-";
            this.zoom_minus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.zoom_minus.UseVisualStyleBackColor = true;
            this.zoom_minus.Visible = false;
            this.zoom_minus.CheckedChanged += new System.EventHandler(this.zoom_minus_CheckedChanged);
            // 
            // zoom_plus
            // 
            this.zoom_plus.Appearance = System.Windows.Forms.Appearance.Button;
            this.zoom_plus.Location = new System.Drawing.Point(105, 204);
            this.zoom_plus.Name = "zoom_plus";
            this.zoom_plus.Size = new System.Drawing.Size(59, 23);
            this.zoom_plus.TabIndex = 13;
            this.zoom_plus.Text = "+";
            this.zoom_plus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.zoom_plus.UseVisualStyleBackColor = true;
            this.zoom_plus.Visible = false;
            this.zoom_plus.CheckedChanged += new System.EventHandler(this.zoom_plus_CheckedChanged);
            // 
            // select_check
            // 
            this.select_check.Appearance = System.Windows.Forms.Appearance.Button;
            this.select_check.Location = new System.Drawing.Point(12, 262);
            this.select_check.Name = "select_check";
            this.select_check.Size = new System.Drawing.Size(87, 23);
            this.select_check.TabIndex = 15;
            this.select_check.Text = "Выделить";
            this.select_check.UseVisualStyleBackColor = true;
            this.select_check.CheckedChanged += new System.EventHandler(this.select_check_CheckedChanged);
            // 
            // Down_layer
            // 
            this.Down_layer.Location = new System.Drawing.Point(12, 172);
            this.Down_layer.Name = "Down_layer";
            this.Down_layer.Size = new System.Drawing.Size(43, 23);
            this.Down_layer.TabIndex = 16;
            this.Down_layer.Text = "Down";
            this.Down_layer.UseVisualStyleBackColor = true;
            this.Down_layer.Click += new System.EventHandler(this.Down_layer_Click);
            // 
            // Up_layer
            // 
            this.Up_layer.Location = new System.Drawing.Point(61, 172);
            this.Up_layer.Name = "Up_layer";
            this.Up_layer.Size = new System.Drawing.Size(43, 23);
            this.Up_layer.TabIndex = 17;
            this.Up_layer.Text = "Up";
            this.Up_layer.UseVisualStyleBackColor = true;
            this.Up_layer.Click += new System.EventHandler(this.Up_layer_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Индивид";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(110, 172);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(54, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "Del";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // map1
            // 
            this.map1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.map1.AutoScroll = true;
            this.map1.BackColor = System.Drawing.SystemColors.Control;
            this.map1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.map1.Location = new System.Drawing.Point(170, 27);
            this.map1.Name = "map1";
            this.map1.Size = new System.Drawing.Size(589, 372);
            this.map1.TabIndex = 3;
            this.map1.AutoSizeChanged += new System.EventHandler(this.map1_AutoSizeChanged);
            this.map1.SizeChanged += new System.EventHandler(this.map1_SizeChanged);
            this.map1.Paint += new System.Windows.Forms.PaintEventHandler(this.map1_Paint);
            this.map1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.map1_MouseClick);
            this.map1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.map1_MouseDown);
            this.map1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.map1_MouseMove);
            this.map1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.map1_MouseUp);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 347);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 23);
            this.button3.TabIndex = 20;
            this.button3.Text = "рисовать";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 411);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Up_layer);
            this.Controls.Add(this.Down_layer);
            this.Controls.Add(this.select_check);
            this.Controls.Add(this.zoom_minus);
            this.Controls.Add(this.zoom_plus);
            this.Controls.Add(this.check_move);
            this.Controls.Add(this.check_zoom);
            this.Controls.Add(this.LayerListBox);
            this.Controls.Add(this.map1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Mini Gis ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Map map1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox LayerListBox;
        private System.Windows.Forms.CheckBox check_zoom;
        private System.Windows.Forms.CheckBox check_move;
        private System.Windows.Forms.CheckBox zoom_minus;
        private System.Windows.Forms.CheckBox zoom_plus;
        private System.Windows.Forms.CheckBox select_check;
        private System.Windows.Forms.Button Down_layer;
        private System.Windows.Forms.Button Up_layer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

