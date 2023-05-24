﻿namespace ProjetoFinalM2
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMap));
            mapa = new GMap.NET.WindowsForms.GMapControl();
            labelTestCoords = new Label();
            toolTip1 = new ToolTip(components);
            buttonPesquisarTransito = new Button();
            panelCoordSaves = new Panel();
            btnSaveCoord = new Button();
            labelMostrarLatitude = new Label();
            labelmostrarLongitude = new Label();
            labelLatitude = new Label();
            labelLongitude = new Label();
            labelSaveFile = new Label();
            labelSaveFileName = new Label();
            panel1 = new Panel();
            labelSelectedSeconds = new Label();
            labelSecsEnd = new Label();
            labelSecsMid = new Label();
            labelSecsStart = new Label();
            uiNVeiculosTransito = new NumericUpDown();
            labelNVehicles = new Label();
            labelTimeLine = new Label();
            trackBarTime = new TrackBar();
            dateTimePickerTime = new DateTimePicker();
            labelStartDate = new Label();
            dateTimePickerDate = new DateTimePicker();
            labelTrafficStateText = new Label();
            labelTrafficState = new Label();
            panel2 = new Panel();
            buttonRemoveOverlays = new Button();
            labelCurrentFileName = new Label();
            labelCurrentFile = new Label();
            btnCarregarFicheiro = new Button();
            btnCarregarMapa = new Button();
            panelCoordSaves.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)uiNVeiculosTransito).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarTime).BeginInit();
            panel2.SuspendLayout();
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
            mapa.Location = new Point(12, 176);
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
            mapa.Size = new Size(956, 635);
            mapa.TabIndex = 1;
            mapa.Zoom = 0D;
            mapa.MouseClick += Mapa_MouseClick;
            // 
            // labelTestCoords
            // 
            labelTestCoords.AutoSize = true;
            labelTestCoords.Location = new Point(495, 37);
            labelTestCoords.Name = "labelTestCoords";
            labelTestCoords.Size = new Size(0, 15);
            labelTestCoords.TabIndex = 10;
            // 
            // buttonPesquisarTransito
            // 
            buttonPesquisarTransito.AccessibleDescription = "Consultar Transito";
            buttonPesquisarTransito.BackColor = Color.AliceBlue;
            buttonPesquisarTransito.BackgroundImage = (Image)resources.GetObject("buttonPesquisarTransito.BackgroundImage");
            buttonPesquisarTransito.BackgroundImageLayout = ImageLayout.Stretch;
            buttonPesquisarTransito.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonPesquisarTransito.ForeColor = SystemColors.ButtonFace;
            buttonPesquisarTransito.Location = new Point(268, 92);
            buttonPesquisarTransito.Name = "buttonPesquisarTransito";
            buttonPesquisarTransito.Size = new Size(45, 45);
            buttonPesquisarTransito.TabIndex = 39;
            toolTip1.SetToolTip(buttonPesquisarTransito, "ConsultarTransito");
            buttonPesquisarTransito.UseVisualStyleBackColor = false;
            buttonPesquisarTransito.Click += buttonPesquisarTransito_Click;
            // 
            // panelCoordSaves
            // 
            panelCoordSaves.BackColor = Color.White;
            panelCoordSaves.BorderStyle = BorderStyle.FixedSingle;
            panelCoordSaves.Controls.Add(btnSaveCoord);
            panelCoordSaves.Controls.Add(labelMostrarLatitude);
            panelCoordSaves.Controls.Add(labelmostrarLongitude);
            panelCoordSaves.Controls.Add(labelLatitude);
            panelCoordSaves.Controls.Add(labelLongitude);
            panelCoordSaves.Controls.Add(labelSaveFile);
            panelCoordSaves.Controls.Add(labelSaveFileName);
            panelCoordSaves.Location = new Point(12, 12);
            panelCoordSaves.Margin = new Padding(3, 3, 30, 3);
            panelCoordSaves.Name = "panelCoordSaves";
            panelCoordSaves.Size = new Size(196, 146);
            panelCoordSaves.TabIndex = 39;
            // 
            // btnSaveCoord
            // 
            btnSaveCoord.BackgroundImageLayout = ImageLayout.Stretch;
            btnSaveCoord.Location = new Point(43, 81);
            btnSaveCoord.Name = "btnSaveCoord";
            btnSaveCoord.Size = new Size(106, 23);
            btnSaveCoord.TabIndex = 20;
            btnSaveCoord.Text = "Guardar Coord";
            btnSaveCoord.UseVisualStyleBackColor = true;
            btnSaveCoord.Click += btnSaveCoord_Click;
            // 
            // labelMostrarLatitude
            // 
            labelMostrarLatitude.AutoSize = true;
            labelMostrarLatitude.BackColor = Color.Transparent;
            labelMostrarLatitude.Location = new Point(6, 6);
            labelMostrarLatitude.Margin = new Padding(6, 6, 3, 0);
            labelMostrarLatitude.Name = "labelMostrarLatitude";
            labelMostrarLatitude.Size = new Size(50, 15);
            labelMostrarLatitude.TabIndex = 16;
            labelMostrarLatitude.Text = "Latitude";
            // 
            // labelmostrarLongitude
            // 
            labelmostrarLongitude.AutoSize = true;
            labelmostrarLongitude.BackColor = Color.Transparent;
            labelmostrarLongitude.Location = new Point(6, 27);
            labelmostrarLongitude.Margin = new Padding(6, 6, 3, 0);
            labelmostrarLongitude.Name = "labelmostrarLongitude";
            labelmostrarLongitude.Size = new Size(61, 15);
            labelmostrarLongitude.TabIndex = 17;
            labelmostrarLongitude.Text = "Longitude";
            // 
            // labelLatitude
            // 
            labelLatitude.AutoSize = true;
            labelLatitude.BackColor = Color.Transparent;
            labelLatitude.Location = new Point(73, 6);
            labelLatitude.Name = "labelLatitude";
            labelLatitude.Size = new Size(30, 15);
            labelLatitude.TabIndex = 18;
            labelLatitude.Text = "xxxº";
            labelLatitude.Click += LabelLatitude_Click;
            // 
            // labelLongitude
            // 
            labelLongitude.AutoSize = true;
            labelLongitude.BackColor = Color.Transparent;
            labelLongitude.Location = new Point(73, 27);
            labelLongitude.Margin = new Padding(3, 6, 3, 0);
            labelLongitude.Name = "labelLongitude";
            labelLongitude.Size = new Size(30, 15);
            labelLongitude.TabIndex = 19;
            labelLongitude.Text = "xxxº";
            labelLongitude.Click += LabelLongitude_Click;
            // 
            // labelSaveFile
            // 
            labelSaveFile.AutoSize = true;
            labelSaveFile.BackColor = Color.Transparent;
            labelSaveFile.Location = new Point(6, 107);
            labelSaveFile.Name = "labelSaveFile";
            labelSaveFile.Size = new Size(52, 15);
            labelSaveFile.TabIndex = 21;
            labelSaveFile.Text = "Ficheiro:";
            // 
            // labelSaveFileName
            // 
            labelSaveFileName.AutoSize = true;
            labelSaveFileName.BackColor = Color.Transparent;
            labelSaveFileName.Location = new Point(64, 107);
            labelSaveFileName.Name = "labelSaveFileName";
            labelSaveFileName.Size = new Size(54, 15);
            labelSaveFileName.TabIndex = 22;
            labelSaveFileName.Text = "Nenhum";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(labelSelectedSeconds);
            panel1.Controls.Add(labelSecsEnd);
            panel1.Controls.Add(labelSecsMid);
            panel1.Controls.Add(labelSecsStart);
            panel1.Controls.Add(uiNVeiculosTransito);
            panel1.Controls.Add(labelNVehicles);
            panel1.Controls.Add(labelTimeLine);
            panel1.Controls.Add(trackBarTime);
            panel1.Controls.Add(dateTimePickerTime);
            panel1.Controls.Add(labelStartDate);
            panel1.Controls.Add(dateTimePickerDate);
            panel1.Controls.Add(buttonPesquisarTransito);
            panel1.Controls.Add(labelTrafficStateText);
            panel1.Controls.Add(labelTrafficState);
            panel1.Location = new Point(267, 12);
            panel1.Margin = new Padding(3, 3, 30, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(337, 146);
            panel1.TabIndex = 40;
            // 
            // labelSelectedSeconds
            // 
            labelSelectedSeconds.BackColor = SystemColors.ControlLightLight;
            labelSelectedSeconds.Location = new Point(297, 41);
            labelSelectedSeconds.Name = "labelSelectedSeconds";
            labelSelectedSeconds.Size = new Size(29, 24);
            labelSelectedSeconds.TabIndex = 50;
            labelSelectedSeconds.Text = "0";
            labelSelectedSeconds.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelSecsEnd
            // 
            labelSecsEnd.AutoSize = true;
            labelSecsEnd.BackColor = SystemColors.ControlLightLight;
            labelSecsEnd.Location = new Point(284, 69);
            labelSecsEnd.Name = "labelSecsEnd";
            labelSecsEnd.Size = new Size(19, 15);
            labelSecsEnd.TabIndex = 47;
            labelSecsEnd.Text = "59";
            // 
            // labelSecsMid
            // 
            labelSecsMid.AutoSize = true;
            labelSecsMid.BackColor = SystemColors.ControlLightLight;
            labelSecsMid.Location = new Point(198, 69);
            labelSecsMid.Name = "labelSecsMid";
            labelSecsMid.Size = new Size(19, 15);
            labelSecsMid.TabIndex = 46;
            labelSecsMid.Text = "30";
            // 
            // labelSecsStart
            // 
            labelSecsStart.AutoSize = true;
            labelSecsStart.BackColor = SystemColors.ControlLightLight;
            labelSecsStart.Location = new Point(114, 69);
            labelSecsStart.Name = "labelSecsStart";
            labelSecsStart.Size = new Size(13, 15);
            labelSecsStart.TabIndex = 45;
            labelSecsStart.Text = "0";
            // 
            // uiNVeiculosTransito
            // 
            uiNVeiculosTransito.Location = new Point(106, 90);
            uiNVeiculosTransito.Name = "uiNVeiculosTransito";
            uiNVeiculosTransito.Size = new Size(120, 23);
            uiNVeiculosTransito.TabIndex = 44;
            // 
            // labelNVehicles
            // 
            labelNVehicles.BackColor = SystemColors.ControlLightLight;
            labelNVehicles.Location = new Point(25, 88);
            labelNVehicles.Name = "labelNVehicles";
            labelNVehicles.Size = new Size(68, 23);
            labelNVehicles.TabIndex = 43;
            labelNVehicles.Text = "Nº Veiculos";
            labelNVehicles.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTimeLine
            // 
            labelTimeLine.BackColor = SystemColors.ControlLightLight;
            labelTimeLine.Location = new Point(5, 42);
            labelTimeLine.Name = "labelTimeLine";
            labelTimeLine.Size = new Size(88, 23);
            labelTimeLine.TabIndex = 42;
            labelTimeLine.Text = "Linha Temporal";
            labelTimeLine.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // trackBarTime
            // 
            trackBarTime.BackColor = SystemColors.ControlLightLight;
            trackBarTime.Location = new Point(106, 41);
            trackBarTime.Maximum = 59;
            trackBarTime.Name = "trackBarTime";
            trackBarTime.Size = new Size(200, 45);
            trackBarTime.TabIndex = 41;
            trackBarTime.TickFrequency = 30;
            trackBarTime.ValueChanged += trackBarTime_ValueChanged;
            // 
            // dateTimePickerTime
            // 
            dateTimePickerTime.CustomFormat = "HH:mm";
            dateTimePickerTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerTime.Location = new Point(233, 7);
            dateTimePickerTime.Name = "dateTimePickerTime";
            dateTimePickerTime.ShowUpDown = true;
            dateTimePickerTime.Size = new Size(74, 23);
            dateTimePickerTime.TabIndex = 40;
            // 
            // labelStartDate
            // 
            labelStartDate.BackColor = SystemColors.ControlLightLight;
            labelStartDate.Location = new Point(14, 7);
            labelStartDate.Name = "labelStartDate";
            labelStartDate.Size = new Size(79, 23);
            labelStartDate.TabIndex = 38;
            labelStartDate.Text = "Data de Início";
            labelStartDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dateTimePickerDate
            // 
            dateTimePickerDate.Location = new Point(107, 7);
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Size = new Size(120, 23);
            dateTimePickerDate.TabIndex = 37;
            // 
            // labelTrafficStateText
            // 
            labelTrafficStateText.BackColor = SystemColors.ControlLightLight;
            labelTrafficStateText.Location = new Point(5, 115);
            labelTrafficStateText.Name = "labelTrafficStateText";
            labelTrafficStateText.Size = new Size(103, 23);
            labelTrafficStateText.TabIndex = 49;
            labelTrafficStateText.Text = "Estado do Trânsito";
            labelTrafficStateText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTrafficState
            // 
            labelTrafficState.AutoSize = true;
            labelTrafficState.BackColor = SystemColors.ControlLightLight;
            labelTrafficState.Location = new Point(114, 119);
            labelTrafficState.Name = "labelTrafficState";
            labelTrafficState.Size = new Size(17, 15);
            labelTrafficState.TabIndex = 48;
            labelTrafficState.Text = "--";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(buttonRemoveOverlays);
            panel2.Controls.Add(labelCurrentFileName);
            panel2.Controls.Add(labelCurrentFile);
            panel2.Controls.Add(btnCarregarFicheiro);
            panel2.Controls.Add(btnCarregarMapa);
            panel2.Location = new Point(663, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(304, 146);
            panel2.TabIndex = 41;
            // 
            // buttonRemoveOverlays
            // 
            buttonRemoveOverlays.BackColor = Color.Red;
            buttonRemoveOverlays.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonRemoveOverlays.ForeColor = SystemColors.ButtonFace;
            buttonRemoveOverlays.Location = new Point(2, 89);
            buttonRemoveOverlays.Name = "buttonRemoveOverlays";
            buttonRemoveOverlays.Size = new Size(147, 57);
            buttonRemoveOverlays.TabIndex = 22;
            buttonRemoveOverlays.Text = "Remover Overlays";
            buttonRemoveOverlays.UseVisualStyleBackColor = false;
            buttonRemoveOverlays.Click += buttonRemoveOverlays_Click;
            // 
            // labelCurrentFileName
            // 
            labelCurrentFileName.AutoSize = true;
            labelCurrentFileName.Location = new Point(71, 65);
            labelCurrentFileName.Name = "labelCurrentFileName";
            labelCurrentFileName.Size = new Size(54, 15);
            labelCurrentFileName.TabIndex = 21;
            labelCurrentFileName.Text = "Nenhum";
            // 
            // labelCurrentFile
            // 
            labelCurrentFile.AutoSize = true;
            labelCurrentFile.Location = new Point(13, 64);
            labelCurrentFile.Name = "labelCurrentFile";
            labelCurrentFile.Size = new Size(52, 15);
            labelCurrentFile.TabIndex = 20;
            labelCurrentFile.Text = "Ficheiro:";
            // 
            // btnCarregarFicheiro
            // 
            btnCarregarFicheiro.BackColor = Color.FromArgb(128, 255, 255);
            btnCarregarFicheiro.Location = new Point(2, 0);
            btnCarregarFicheiro.Name = "btnCarregarFicheiro";
            btnCarregarFicheiro.Size = new Size(147, 56);
            btnCarregarFicheiro.TabIndex = 19;
            btnCarregarFicheiro.Text = "Carregar Ficheiro CSV";
            btnCarregarFicheiro.UseVisualStyleBackColor = false;
            btnCarregarFicheiro.Click += BtnCarregarFicheiro_Click;
            // 
            // btnCarregarMapa
            // 
            btnCarregarMapa.BackColor = Color.FromArgb(128, 255, 128);
            btnCarregarMapa.Location = new Point(155, 0);
            btnCarregarMapa.Name = "btnCarregarMapa";
            btnCarregarMapa.Size = new Size(147, 56);
            btnCarregarMapa.TabIndex = 18;
            btnCarregarMapa.Text = "Carregar Mapa";
            btnCarregarMapa.UseVisualStyleBackColor = false;
            btnCarregarMapa.Click += BtnCarregarMapa_Click;
            // 
            // FormMap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(978, 823);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panelCoordSaves);
            Controls.Add(labelTestCoords);
            Controls.Add(mapa);
            Name = "FormMap";
            Text = "Projeto Informático M2";
            Shown += FormMap_Shown;
            KeyDown += Form1_KeyDown;
            panelCoordSaves.ResumeLayout(false);
            panelCoordSaves.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)uiNVeiculosTransito).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarTime).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl mapa;
        private Label labelTestCoords;
        private ToolTip toolTip1;
        private Panel panelCoordSaves;
        private Button btnSaveCoord;
        private Label labelMostrarLatitude;
        private Label labelmostrarLongitude;
        private Label labelLatitude;
        private Label labelLongitude;
        private Label labelSaveFile;
        private Label labelSaveFileName;
        private Panel panel1;
        private Label labelSelectedSeconds;
        private Label labelSecsEnd;
        private Label labelSecsMid;
        private Label labelSecsStart;
        private NumericUpDown uiNVeiculosTransito;
        private Label labelNVehicles;
        private Label labelTimeLine;
        private TrackBar trackBarTime;
        private DateTimePicker dateTimePickerTime;
        private Label labelStartDate;
        private DateTimePicker dateTimePickerDate;
        private Button buttonPesquisarTransito;
        private Label labelTrafficStateText;
        private Label labelTrafficState;
        private Panel panel2;
        private Button buttonRemoveOverlays;
        private Label labelCurrentFileName;
        private Label labelCurrentFile;
        private Button btnCarregarFicheiro;
        private Button btnCarregarMapa;
    }
}