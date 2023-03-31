namespace ProjetoFinalM2 {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            mapa = new GMap.NET.WindowsForms.GMapControl();
            button1 = new Button();
            labelLatitude = new Label();
            labelLongitude = new Label();
            textBoxLatitude = new TextBox();
            textBoxLongitude = new TextBox();
            SuspendLayout();
            // 
            // mapa
            // 
            mapa.Bearing = 0F;
            mapa.CanDragMap = true;
            mapa.EmptyTileColor = Color.Navy;
            mapa.GrayScaleMode = false;
            mapa.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            mapa.LevelsKeepInMemory = 5;
            mapa.Location = new Point(12, 112);
            mapa.MarkersEnabled = true;
            mapa.MaxZoom = 2;
            mapa.MinZoom = 2;
            mapa.MouseWheelZoomEnabled = true;
            mapa.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            mapa.Name = "mapa";
            mapa.NegativeMode = false;
            mapa.PolygonsEnabled = true;
            mapa.RetryLoadTile = 0;
            mapa.RoutesEnabled = true;
            mapa.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            mapa.SelectedAreaFillColor = Color.FromArgb(33, 65, 105, 225);
            mapa.ShowTileGridLines = false;
            mapa.Size = new Size(776, 326);
            mapa.TabIndex = 1;
            mapa.Zoom = 0D;
            // 
            // button1
            // 
            button1.Location = new Point(609, 28);
            button1.Name = "button1";
            button1.Size = new Size(147, 56);
            button1.TabIndex = 2;
            button1.Text = "Carregar Mapa";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // labelLatitude
            // 
            labelLatitude.AutoSize = true;
            labelLatitude.Location = new Point(20, 24);
            labelLatitude.Name = "labelLatitude";
            labelLatitude.Size = new Size(50, 15);
            labelLatitude.TabIndex = 3;
            labelLatitude.Text = "Latitude";
            // 
            // labelLongitude
            // 
            labelLongitude.AutoSize = true;
            labelLongitude.Location = new Point(20, 59);
            labelLongitude.Name = "labelLongitude";
            labelLongitude.Size = new Size(61, 15);
            labelLongitude.TabIndex = 4;
            labelLongitude.Text = "Longitude";
            // 
            // textBoxLatitude
            // 
            textBoxLatitude.Location = new Point(97, 25);
            textBoxLatitude.Name = "textBoxLatitude";
            textBoxLatitude.Size = new Size(100, 23);
            textBoxLatitude.TabIndex = 5;
            // 
            // textBoxLongitude
            // 
            textBoxLongitude.Location = new Point(97, 61);
            textBoxLongitude.Name = "textBoxLongitude";
            textBoxLongitude.Size = new Size(100, 23);
            textBoxLongitude.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxLongitude);
            Controls.Add(textBoxLatitude);
            Controls.Add(labelLongitude);
            Controls.Add(labelLatitude);
            Controls.Add(button1);
            Controls.Add(mapa);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl mapa;
        private Button button1;
        private Label labelLatitude;
        private Label labelLongitude;
        private TextBox textBoxLatitude;
        private TextBox textBoxLongitude;
    }
}