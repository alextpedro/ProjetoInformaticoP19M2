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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMap));
            mapa = new GMap.NET.WindowsForms.GMapControl();
            labelTestCoords = new Label();
            toolTip1 = new ToolTip(components);
            buttonPesquisarTransito = new Button();
            btnFilterPointsOnRoute = new Button();
            panelCoordSaves = new Panel();
            btnSaveCoord = new Button();
            labelMostrarLatitude = new Label();
            labelmostrarLongitude = new Label();
            labelLatitude = new Label();
            labelLongitude = new Label();
            labelSaveFile = new Label();
            labelSaveFileName = new Label();
            panel1 = new Panel();
            labelSentidoCart = new Label();
            labelStreet = new Label();
            labelStreetName = new Label();
            label1 = new Label();
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
            labelRouteLength = new Label();
            label2 = new Label();
            BtnGetStreet = new Button();
            btnRotaTransito = new Button();
            buttonRemoveOverlays = new Button();
            labelCurrentFileName = new Label();
            labelCurrentFile = new Label();
            btnCarregarFicheiro = new Button();
            btnCarregarMapa = new Button();
            panel3 = new Panel();
            buttonGoToStreet = new Button();
            textBoxStreetToGoTo = new TextBox();
            panelCoordSaves.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)uiNVeiculosTransito).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarTime).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
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
            mapa.Location = new Point(12, 231);
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
            mapa.Size = new Size(956, 580);
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
            buttonPesquisarTransito.Location = new Point(281, 153);
            buttonPesquisarTransito.Name = "buttonPesquisarTransito";
            buttonPesquisarTransito.Size = new Size(45, 45);
            buttonPesquisarTransito.TabIndex = 39;
            toolTip1.SetToolTip(buttonPesquisarTransito, "ConsultarTransito");
            buttonPesquisarTransito.UseVisualStyleBackColor = false;
            buttonPesquisarTransito.Click += ButtonPesquisarTransito_Click;
            // 
            // btnFilterPointsOnRoute
            // 
            btnFilterPointsOnRoute.AccessibleDescription = "Consultar Transito";
            btnFilterPointsOnRoute.BackColor = Color.DarkOrange;
            btnFilterPointsOnRoute.BackgroundImageLayout = ImageLayout.Stretch;
            btnFilterPointsOnRoute.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnFilterPointsOnRoute.ForeColor = Color.Black;
            btnFilterPointsOnRoute.Location = new Point(155, 152);
            btnFilterPointsOnRoute.Name = "btnFilterPointsOnRoute";
            btnFilterPointsOnRoute.Size = new Size(146, 36);
            btnFilterPointsOnRoute.TabIndex = 57;
            btnFilterPointsOnRoute.Text = "Filtrar Rua";
            toolTip1.SetToolTip(btnFilterPointsOnRoute, "ConsultarTransito");
            btnFilterPointsOnRoute.UseVisualStyleBackColor = false;
            btnFilterPointsOnRoute.Click += BtnFilterPointsOnRoute_Click;
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
            btnSaveCoord.Location = new Point(36, 61);
            btnSaveCoord.Name = "btnSaveCoord";
            btnSaveCoord.Size = new Size(106, 23);
            btnSaveCoord.TabIndex = 20;
            btnSaveCoord.Text = "Guardar Coord";
            btnSaveCoord.UseVisualStyleBackColor = true;
            btnSaveCoord.Click += BtnSaveCoord_Click;
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
            panel1.Controls.Add(labelSentidoCart);
            panel1.Controls.Add(labelStreet);
            panel1.Controls.Add(labelStreetName);
            panel1.Controls.Add(label1);
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
            panel1.Size = new Size(337, 212);
            panel1.TabIndex = 40;
            // 
            // labelSentidoCart
            // 
            labelSentidoCart.AutoSize = true;
            labelSentidoCart.BackColor = Color.Transparent;
            labelSentidoCart.Location = new Point(106, 186);
            labelSentidoCart.Margin = new Padding(3, 6, 3, 0);
            labelSentidoCart.Name = "labelSentidoCart";
            labelSentidoCart.Size = new Size(25, 15);
            labelSentidoCart.TabIndex = 54;
            labelSentidoCart.Text = "xxx";
            // 
            // labelStreet
            // 
            labelStreet.AutoSize = true;
            labelStreet.BackColor = Color.Transparent;
            labelStreet.Location = new Point(106, 165);
            labelStreet.Margin = new Padding(3, 6, 3, 0);
            labelStreet.Name = "labelStreet";
            labelStreet.Size = new Size(25, 15);
            labelStreet.TabIndex = 53;
            labelStreet.Text = "xxx";
            // 
            // labelStreetName
            // 
            labelStreetName.AutoSize = true;
            labelStreetName.BackColor = Color.Transparent;
            labelStreetName.Location = new Point(107, 142);
            labelStreetName.Margin = new Padding(3, 6, 3, 0);
            labelStreetName.Name = "labelStreetName";
            labelStreetName.Size = new Size(0, 15);
            labelStreetName.TabIndex = 52;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ControlLightLight;
            label1.Location = new Point(14, 165);
            label1.Name = "label1";
            label1.Size = new Size(103, 23);
            label1.TabIndex = 51;
            label1.Text = "Rua";
            label1.TextAlign = ContentAlignment.MiddleCenter;
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
            uiNVeiculosTransito.Location = new Point(132, 105);
            uiNVeiculosTransito.Name = "uiNVeiculosTransito";
            uiNVeiculosTransito.Size = new Size(120, 23);
            uiNVeiculosTransito.TabIndex = 44;
            // 
            // labelNVehicles
            // 
            labelNVehicles.BackColor = SystemColors.ControlLightLight;
            labelNVehicles.Location = new Point(63, 103);
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
            trackBarTime.Location = new Point(99, 41);
            trackBarTime.Maximum = 59;
            trackBarTime.Name = "trackBarTime";
            trackBarTime.Size = new Size(227, 45);
            trackBarTime.TabIndex = 41;
            trackBarTime.TickFrequency = 30;
            trackBarTime.ValueChanged += TrackBarTime_ValueChanged;
            // 
            // dateTimePickerTime
            // 
            dateTimePickerTime.CustomFormat = "HH:mm";
            dateTimePickerTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerTime.Location = new Point(258, 6);
            dateTimePickerTime.Name = "dateTimePickerTime";
            dateTimePickerTime.ShowUpDown = true;
            dateTimePickerTime.Size = new Size(74, 23);
            dateTimePickerTime.TabIndex = 40;
            // 
            // labelStartDate
            // 
            labelStartDate.BackColor = SystemColors.ControlLightLight;
            labelStartDate.Location = new Point(5, 9);
            labelStartDate.Name = "labelStartDate";
            labelStartDate.Size = new Size(79, 23);
            labelStartDate.TabIndex = 38;
            labelStartDate.Text = "Data de Início";
            labelStartDate.TextAlign = ContentAlignment.MiddleCenter;
            labelStartDate.Click += labelStartDate_Click;
            // 
            // dateTimePickerDate
            // 
            dateTimePickerDate.Location = new Point(96, 7);
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Size = new Size(156, 23);
            dateTimePickerDate.TabIndex = 37;
            // 
            // labelTrafficStateText
            // 
            labelTrafficStateText.BackColor = SystemColors.ControlLightLight;
            labelTrafficStateText.Location = new Point(5, 142);
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
            labelTrafficState.Location = new Point(114, 146);
            labelTrafficState.Name = "labelTrafficState";
            labelTrafficState.Size = new Size(17, 15);
            labelTrafficState.TabIndex = 48;
            labelTrafficState.Text = "--";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnFilterPointsOnRoute);
            panel2.Controls.Add(labelRouteLength);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(BtnGetStreet);
            panel2.Controls.Add(btnRotaTransito);
            panel2.Controls.Add(buttonRemoveOverlays);
            panel2.Controls.Add(labelCurrentFileName);
            panel2.Controls.Add(labelCurrentFile);
            panel2.Controls.Add(btnCarregarFicheiro);
            panel2.Controls.Add(btnCarregarMapa);
            panel2.Location = new Point(663, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(304, 213);
            panel2.TabIndex = 41;
            // 
            // labelRouteLength
            // 
            labelRouteLength.AutoSize = true;
            labelRouteLength.BackColor = Color.Transparent;
            labelRouteLength.Location = new Point(118, 197);
            labelRouteLength.Margin = new Padding(3, 6, 3, 0);
            labelRouteLength.Name = "labelRouteLength";
            labelRouteLength.Size = new Size(25, 15);
            labelRouteLength.TabIndex = 56;
            labelRouteLength.Text = "xxx";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(3, 197);
            label2.Margin = new Padding(3, 6, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(109, 15);
            label2.TabIndex = 55;
            label2.Text = "Comprimento Rota";
            // 
            // BtnGetStreet
            // 
            BtnGetStreet.BackColor = Color.Bisque;
            BtnGetStreet.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            BtnGetStreet.ForeColor = SystemColors.ActiveCaptionText;
            BtnGetStreet.Location = new Point(2, 153);
            BtnGetStreet.Name = "BtnGetStreet";
            BtnGetStreet.Size = new Size(147, 35);
            BtnGetStreet.TabIndex = 24;
            BtnGetStreet.Text = "Obter Rua";
            BtnGetStreet.UseVisualStyleBackColor = false;
            BtnGetStreet.Click += BtnGetStreet_Click;
            // 
            // btnRotaTransito
            // 
            btnRotaTransito.BackColor = Color.PaleGreen;
            btnRotaTransito.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnRotaTransito.ForeColor = SystemColors.ActiveCaptionText;
            btnRotaTransito.Location = new Point(154, 89);
            btnRotaTransito.Name = "btnRotaTransito";
            btnRotaTransito.Size = new Size(147, 57);
            btnRotaTransito.TabIndex = 23;
            btnRotaTransito.Text = "Fazer Polígono";
            btnRotaTransito.UseVisualStyleBackColor = false;
            btnRotaTransito.Click += BtnDrawPolygon_Click;
            // 
            // buttonRemoveOverlays
            // 
            buttonRemoveOverlays.BackColor = Color.Red;
            buttonRemoveOverlays.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonRemoveOverlays.ForeColor = SystemColors.ActiveCaptionText;
            buttonRemoveOverlays.Location = new Point(2, 89);
            buttonRemoveOverlays.Name = "buttonRemoveOverlays";
            buttonRemoveOverlays.Size = new Size(147, 57);
            buttonRemoveOverlays.TabIndex = 22;
            buttonRemoveOverlays.Text = "Remover Overlays";
            buttonRemoveOverlays.UseVisualStyleBackColor = false;
            buttonRemoveOverlays.Click += ButtonRemoveOverlays_Click;
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
            btnCarregarMapa.BackColor = Color.DeepSkyBlue;
            btnCarregarMapa.Location = new Point(155, 0);
            btnCarregarMapa.Name = "btnCarregarMapa";
            btnCarregarMapa.Size = new Size(147, 56);
            btnCarregarMapa.TabIndex = 18;
            btnCarregarMapa.Text = "Carregar Mapa";
            btnCarregarMapa.UseVisualStyleBackColor = false;
            btnCarregarMapa.Click += BtnCarregarMapa_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(buttonGoToStreet);
            panel3.Controls.Add(textBoxStreetToGoTo);
            panel3.Location = new Point(12, 171);
            panel3.Name = "panel3";
            panel3.Size = new Size(196, 54);
            panel3.TabIndex = 42;
            // 
            // buttonGoToStreet
            // 
            buttonGoToStreet.Location = new Point(54, 30);
            buttonGoToStreet.Name = "buttonGoToStreet";
            buttonGoToStreet.Size = new Size(75, 23);
            buttonGoToStreet.TabIndex = 1;
            buttonGoToStreet.Text = "Ir";
            buttonGoToStreet.UseVisualStyleBackColor = true;
            buttonGoToStreet.Click += BtnGoToStreet_Click;
            // 
            // textBoxStreetToGoTo
            // 
            textBoxStreetToGoTo.Location = new Point(6, 6);
            textBoxStreetToGoTo.Margin = new Padding(6);
            textBoxStreetToGoTo.Name = "textBoxStreetToGoTo";
            textBoxStreetToGoTo.Size = new Size(182, 23);
            textBoxStreetToGoTo.TabIndex = 0;
            // 
            // FormMap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(978, 823);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panelCoordSaves);
            Controls.Add(labelTestCoords);
            Controls.Add(mapa);
            Name = "FormMap";
            Text = "Projeto Informático M2";
            Shown += FormMap_Shown;
            panelCoordSaves.ResumeLayout(false);
            panelCoordSaves.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)uiNVeiculosTransito).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarTime).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
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
        private Label label1;
        private Button btnRotaTransito;
        private Button BtnGetStreet;
        private Label labelStreetName;
        private Label labelStreet;
        private Label labelSentidoCart;
        private Label label2;
        private Label labelRouteLength;
        private Button btnFilterPointsOnRoute;
        private Panel panel3;
        private Button buttonGoToStreet;
        private TextBox textBoxStreetToGoTo;
    }
}