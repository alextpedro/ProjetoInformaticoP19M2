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
            buttonCarregarTransito = new Button();
            buttonRemoveOverlays = new Button();
            dateTimePickerInicio = new DateTimePicker();
            dateTimePickerFim = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxRua = new TextBox();
            buttonTransito = new Button();
            dateTimePickerStartTime = new DateTimePicker();
            dateTimePickerEndTime = new DateTimePicker();
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
            mapa.Location = new Point(12, 149);
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
            mapa.Size = new Size(1092, 510);
            mapa.TabIndex = 1;
            mapa.Zoom = 0D;
            mapa.MouseClick += Mapa_MouseClick;
            mapa.MouseHover += Mapa_MouseHover;
            // 
            // btnCarregarMapa
            // 
            btnCarregarMapa.BackColor = Color.FromArgb(128, 255, 128);
            btnCarregarMapa.Location = new Point(755, 24);
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
            btnCarregarFicheiro.Location = new Point(593, 24);
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
            labelCurrentFile.Location = new Point(594, 84);
            labelCurrentFile.Name = "labelCurrentFile";
            labelCurrentFile.Size = new Size(52, 15);
            labelCurrentFile.TabIndex = 12;
            labelCurrentFile.Text = "Ficheiro:";
            // 
            // labelCurrentFileName
            // 
            labelCurrentFileName.AutoSize = true;
            labelCurrentFileName.Location = new Point(647, 84);
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
            // buttonCarregarTransito
            // 
            buttonCarregarTransito.BackColor = Color.FromArgb(255, 224, 192);
            buttonCarregarTransito.Location = new Point(917, 24);
            buttonCarregarTransito.Name = "buttonCarregarTransito";
            buttonCarregarTransito.Size = new Size(147, 56);
            buttonCarregarTransito.TabIndex = 16;
            buttonCarregarTransito.Text = "Medir Trânsito";
            buttonCarregarTransito.UseVisualStyleBackColor = false;
            buttonCarregarTransito.Click += buttonCarregarTransito_Click;
            // 
            // buttonRemoveOverlays
            // 
            buttonRemoveOverlays.BackColor = Color.Red;
            buttonRemoveOverlays.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonRemoveOverlays.ForeColor = SystemColors.ButtonFace;
            buttonRemoveOverlays.Location = new Point(917, 86);
            buttonRemoveOverlays.Name = "buttonRemoveOverlays";
            buttonRemoveOverlays.Size = new Size(147, 22);
            buttonRemoveOverlays.TabIndex = 17;
            buttonRemoveOverlays.Text = "Remover Overlays";
            buttonRemoveOverlays.UseVisualStyleBackColor = false;
            buttonRemoveOverlays.Click += buttonRemoveOverlays_Click;
            // 
            // dateTimePickerInicio
            // 
            dateTimePickerInicio.Location = new Point(375, 24);
            dateTimePickerInicio.Name = "dateTimePickerInicio";
            dateTimePickerInicio.Size = new Size(120, 23);
            dateTimePickerInicio.TabIndex = 18;
            // 
            // dateTimePickerFim
            // 
            dateTimePickerFim.Location = new Point(375, 55);
            dateTimePickerFim.Name = "dateTimePickerFim";
            dateTimePickerFim.Size = new Size(120, 23);
            dateTimePickerFim.TabIndex = 19;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(290, 59);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 21;
            label2.Text = "Data de Fim";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(318, 86);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 22;
            label3.Text = "Rua";
            // 
            // textBoxRua
            // 
            textBoxRua.Location = new Point(375, 83);
            textBoxRua.Name = "textBoxRua";
            textBoxRua.Size = new Size(200, 23);
            textBoxRua.TabIndex = 23;
            // 
            // buttonTransito
            // 
            buttonTransito.BackColor = Color.CornflowerBlue;
            buttonTransito.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonTransito.ForeColor = SystemColors.ButtonFace;
            buttonTransito.Location = new Point(375, 112);
            buttonTransito.Name = "buttonTransito";
            buttonTransito.Size = new Size(200, 31);
            buttonTransito.TabIndex = 24;
            buttonTransito.Text = "ConsultarTransito";
            buttonTransito.UseVisualStyleBackColor = false;
            buttonTransito.Click += buttonTransito_Click;
            // 
            // dateTimePickerStartTime
            // 
            dateTimePickerStartTime.Format = DateTimePickerFormat.Time;
            dateTimePickerStartTime.Location = new Point(501, 24);
            dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            dateTimePickerStartTime.Size = new Size(74, 23);
            dateTimePickerStartTime.TabIndex = 25;
            // 
            // dateTimePickerEndTime
            // 
            dateTimePickerEndTime.Format = DateTimePickerFormat.Time;
            dateTimePickerEndTime.Location = new Point(501, 55);
            dateTimePickerEndTime.Name = "dateTimePickerEndTime";
            dateTimePickerEndTime.Size = new Size(74, 23);
            dateTimePickerEndTime.TabIndex = 26;
            // 
            // FormMap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1116, 671);
            Controls.Add(dateTimePickerEndTime);
            Controls.Add(dateTimePickerStartTime);
            Controls.Add(buttonTransito);
            Controls.Add(textBoxRua);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePickerFim);
            Controls.Add(dateTimePickerInicio);
            Controls.Add(buttonRemoveOverlays);
            Controls.Add(buttonCarregarTransito);
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
        private Button buttonCarregarTransito;
        private Button buttonRemoveOverlays;
        private DateTimePicker dateTimePickerInicio;
        private DateTimePicker dateTimePickerFim;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxRua;
        private Button buttonTransito;
        private DateTimePicker dateTimePickerStartTime;
        private DateTimePicker dateTimePickerEndTime;
    }
}