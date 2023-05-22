namespace ProjetoFinalM2
{
    partial class FormMap
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mapa = new GMap.NET.WindowsForms.GMapControl();
            btnCarregarMapa = new Button();
            labelMostrarLatitude = new Label();
            labelmostrarLongitude = new Label();
            btnCarregarFicheiro = new Button();
            labelLatitude = new Label();
            labelLongitude = new Label();
            labelTestCoords = new Label();
            btnSaveCoord = new Button();
            labelCurrentFile = new Label();
            labelCurrentFileName = new Label();
            labelSaveFile = new Label();
            labelSaveFileName = new Label();
            buttonRemoveOverlays = new Button();
            dateTimePickerDate = new DateTimePicker();
            label1 = new Label();
            buttonPesquisarTransito = new Button();
            dateTimePickerTime = new DateTimePicker();
            trackBarTime = new TrackBar();
            label4 = new Label();
            label5 = new Label();
            nVeiculosTransito = new NumericUpDown();
            labelSecsStart = new Label();
            labelSecsMid = new Label();
            labelSecsEnd = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBarTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nVeiculosTransito).BeginInit();
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
            mapa.Location = new Point(12, 156);
            mapa.MarkersEnabled = true;
            mapa.MaxZoom = 24;
            mapa.MinZoom = 0;
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
            mapa.Size = new Size(1092, 635);
            mapa.TabIndex = 1;
            mapa.Zoom = 0D;
            mapa.MouseClick += Mapa_MouseClick;
            // 
            // btnCarregarMapa
            // 
            btnCarregarMapa.BackColor = Color.FromArgb(128, 255, 128);
            btnCarregarMapa.Location = new Point(930, 9);
            btnCarregarMapa.Name = "btnCarregarMapa";
            btnCarregarMapa.Size = new Size(147, 56);
            btnCarregarMapa.TabIndex = 2;
            btnCarregarMapa.Text = "Carregar Mapa";
            btnCarregarMapa.UseVisualStyleBackColor = false;
            btnCarregarMapa.Click += BtnCarregarMapa_Click;
            // 
            // labelMostrarLatitude
            // 
            labelMostrarLatitude.AutoSize = true;
            labelMostrarLatitude.Location = new Point(20, 24);
            labelMostrarLatitude.Name = "labelMostrarLatitude";
            labelMostrarLatitude.Size = new Size(50, 15);
            labelMostrarLatitude.TabIndex = 3;
            labelMostrarLatitude.Text = "Latitude";
            // 
            // labelmostrarLongitude
            // 
            labelmostrarLongitude.AutoSize = true;
            labelmostrarLongitude.Location = new Point(20, 59);
            labelmostrarLongitude.Name = "labelmostrarLongitude";
            labelmostrarLongitude.Size = new Size(61, 15);
            labelmostrarLongitude.TabIndex = 4;
            labelmostrarLongitude.Text = "Longitude";
            // 
            // btnCarregarFicheiro
            // 
            btnCarregarFicheiro.BackColor = Color.FromArgb(128, 255, 255);
            btnCarregarFicheiro.Location = new Point(777, 9);
            btnCarregarFicheiro.Name = "btnCarregarFicheiro";
            btnCarregarFicheiro.Size = new Size(147, 56);
            btnCarregarFicheiro.TabIndex = 7;
            btnCarregarFicheiro.Text = "Carregar Ficheiro CSV";
            btnCarregarFicheiro.UseVisualStyleBackColor = false;
            btnCarregarFicheiro.Click += BtnCarregarFicheiro_Click;
            // 
            // labelLatitude
            // 
            labelLatitude.AutoSize = true;
            labelLatitude.Location = new Point(92, 24);
            labelLatitude.Name = "labelLatitude";
            labelLatitude.Size = new Size(30, 15);
            labelLatitude.TabIndex = 8;
            labelLatitude.Text = "xxxº";
            labelLatitude.Click += LabelLatitude_Click;
            // 
            // labelLongitude
            // 
            labelLongitude.AutoSize = true;
            labelLongitude.Location = new Point(92, 59);
            labelLongitude.Name = "labelLongitude";
            labelLongitude.Size = new Size(30, 15);
            labelLongitude.TabIndex = 9;
            labelLongitude.Text = "xxxº";
            labelLongitude.Click += LabelLongitude_Click;
            // 
            // labelTestCoords
            // 
            labelTestCoords.AutoSize = true;
            labelTestCoords.Location = new Point(495, 37);
            labelTestCoords.Name = "labelTestCoords";
            labelTestCoords.Size = new Size(0, 15);
            labelTestCoords.TabIndex = 10;
            // 
            // btnSaveCoord
            // 
            btnSaveCoord.BackgroundImageLayout = ImageLayout.Stretch;
            btnSaveCoord.Location = new Point(20, 83);
            btnSaveCoord.Name = "btnSaveCoord";
            btnSaveCoord.Size = new Size(102, 23);
            btnSaveCoord.TabIndex = 11;
            btnSaveCoord.Text = "Guardar Coord";
            btnSaveCoord.UseVisualStyleBackColor = true;
            btnSaveCoord.Click += btnSaveCoord_Click;
            // 
            // labelCurrentFile
            // 
            labelCurrentFile.AutoSize = true;
            labelCurrentFile.Location = new Point(786, 72);
            labelCurrentFile.Name = "labelCurrentFile";
            labelCurrentFile.Size = new Size(52, 15);
            labelCurrentFile.TabIndex = 12;
            labelCurrentFile.Text = "Ficheiro:";
            // 
            // labelCurrentFileName
            // 
            labelCurrentFileName.AutoSize = true;
            labelCurrentFileName.Location = new Point(844, 72);
            labelCurrentFileName.Name = "labelCurrentFileName";
            labelCurrentFileName.Size = new Size(54, 15);
            labelCurrentFileName.TabIndex = 13;
            labelCurrentFileName.Text = "Nenhum";
            // 
            // labelSaveFile
            // 
            labelSaveFile.AutoSize = true;
            labelSaveFile.Location = new Point(130, 86);
            labelSaveFile.Name = "labelSaveFile";
            labelSaveFile.Size = new Size(52, 15);
            labelSaveFile.TabIndex = 14;
            labelSaveFile.Text = "Ficheiro:";
            // 
            // labelSaveFileName
            // 
            labelSaveFileName.AutoSize = true;
            labelSaveFileName.Location = new Point(183, 86);
            labelSaveFileName.Name = "labelSaveFileName";
            labelSaveFileName.Size = new Size(54, 15);
            labelSaveFileName.TabIndex = 15;
            labelSaveFileName.Text = "Nenhum";
            // 
            // buttonRemoveOverlays
            // 
            buttonRemoveOverlays.BackColor = Color.Red;
            buttonRemoveOverlays.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonRemoveOverlays.ForeColor = SystemColors.ButtonFace;
            buttonRemoveOverlays.Location = new Point(930, 93);
            buttonRemoveOverlays.Name = "buttonRemoveOverlays";
            buttonRemoveOverlays.Size = new Size(147, 57);
            buttonRemoveOverlays.TabIndex = 17;
            buttonRemoveOverlays.Text = "Remover Overlays";
            buttonRemoveOverlays.UseVisualStyleBackColor = false;
            buttonRemoveOverlays.Click += buttonRemoveOverlays_Click;
            // 
            // dateTimePickerDate
            // 
            dateTimePickerDate.Location = new Point(375, 24);
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Size = new Size(120, 23);
            dateTimePickerDate.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(290, 30);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 20;
            label1.Text = "Data de Início";
            // 
            // buttonPesquisarTransito
            // 
            buttonPesquisarTransito.BackColor = Color.CornflowerBlue;
            buttonPesquisarTransito.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonPesquisarTransito.ForeColor = SystemColors.ButtonFace;
            buttonPesquisarTransito.Location = new Point(777, 93);
            buttonPesquisarTransito.Name = "buttonPesquisarTransito";
            buttonPesquisarTransito.Size = new Size(147, 57);
            buttonPesquisarTransito.TabIndex = 24;
            buttonPesquisarTransito.Text = "ConsultarTransito";
            buttonPesquisarTransito.UseVisualStyleBackColor = false;
            buttonPesquisarTransito.Click += buttonPesquisarTransito_Click;
            // 
            // dateTimePickerTime
            // 
            dateTimePickerTime.CustomFormat = "HH:mm";
            dateTimePickerTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerTime.Location = new Point(501, 24);
            dateTimePickerTime.Name = "dateTimePickerTime";
            dateTimePickerTime.ShowUpDown = true;
            dateTimePickerTime.Size = new Size(74, 23);
            dateTimePickerTime.TabIndex = 25;
            // 
            // trackBarTime
            // 
            trackBarTime.Location = new Point(375, 53);
            trackBarTime.Maximum = 59;
            trackBarTime.Name = "trackBarTime";
            trackBarTime.Size = new Size(200, 45);
            trackBarTime.TabIndex = 27;
            trackBarTime.TickFrequency = 30;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(281, 59);
            label4.Name = "label4";
            label4.Size = new Size(88, 15);
            label4.TabIndex = 28;
            label4.Text = "Linha Temporal";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(290, 98);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 29;
            label5.Text = "N Veiculos";
            // 
            // nVeiculosTransito
            // 
            nVeiculosTransito.Location = new Point(375, 98);
            nVeiculosTransito.Name = "nVeiculosTransito";
            nVeiculosTransito.Size = new Size(120, 23);
            nVeiculosTransito.TabIndex = 30;
            // 
            // labelSecsStart
            // 
            labelSecsStart.AutoSize = true;
            labelSecsStart.Location = new Point(382, 80);
            labelSecsStart.Name = "labelSecsStart";
            labelSecsStart.Size = new Size(13, 15);
            labelSecsStart.TabIndex = 31;
            labelSecsStart.Text = "0";
            // 
            // labelSecsMid
            // 
            labelSecsMid.AutoSize = true;
            labelSecsMid.Location = new Point(465, 80);
            labelSecsMid.Name = "labelSecsMid";
            labelSecsMid.Size = new Size(19, 15);
            labelSecsMid.TabIndex = 32;
            labelSecsMid.Text = "30";
            // 
            // labelSecsEnd
            // 
            labelSecsEnd.AutoSize = true;
            labelSecsEnd.Location = new Point(552, 80);
            labelSecsEnd.Name = "labelSecsEnd";
            labelSecsEnd.Size = new Size(19, 15);
            labelSecsEnd.TabIndex = 33;
            labelSecsEnd.Text = "59";
            // 
            // FormMap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1116, 803);
            Controls.Add(labelSecsEnd);
            Controls.Add(labelSecsMid);
            Controls.Add(labelSecsStart);
            Controls.Add(nVeiculosTransito);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(trackBarTime);
            Controls.Add(dateTimePickerTime);
            Controls.Add(buttonPesquisarTransito);
            Controls.Add(label1);
            Controls.Add(dateTimePickerDate);
            Controls.Add(buttonRemoveOverlays);
            Controls.Add(labelSaveFileName);
            Controls.Add(labelSaveFile);
            Controls.Add(labelCurrentFileName);
            Controls.Add(labelCurrentFile);
            Controls.Add(btnSaveCoord);
            Controls.Add(labelTestCoords);
            Controls.Add(labelLongitude);
            Controls.Add(labelLatitude);
            Controls.Add(btnCarregarFicheiro);
            Controls.Add(labelmostrarLongitude);
            Controls.Add(labelMostrarLatitude);
            Controls.Add(btnCarregarMapa);
            Controls.Add(mapa);
            Name = "FormMap";
            Text = "Projeto Informático M2";
            Shown += FormMap_Shown;
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)trackBarTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)nVeiculosTransito).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl mapa;
        private Button btnCarregarMapa;
        private Label labelMostrarLatitude;
        private Label labelmostrarLongitude;
        private Button btnCarregarFicheiro;
        private Label labelLatitude;
        private Label labelLongitude;
        private Label labelTestCoords;
        private Button btnSaveCoord;
        private Label labelCurrentFile;
        private Label labelCurrentFileName;
        private Label labelSaveFile;
        private Label labelSaveFileName;
        private Button buttonRemoveOverlays;
        private DateTimePicker dateTimePickerDate;
        private Label label1;
        private Button buttonPesquisarTransito;
        private DateTimePicker dateTimePickerTime;
        private TrackBar trackBarTime;
        private Label label4;
        private Label label5;
        private NumericUpDown nVeiculosTransito;
        private Label labelSecsStart;
        private Label labelSecsMid;
        private Label labelSecsEnd;
    }
}