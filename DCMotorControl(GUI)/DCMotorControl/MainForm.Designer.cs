
namespace DCMotorControl
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_Update = new System.Windows.Forms.Button();
            this.comboBox_FrePWM = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_SetPoint = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Kd = new System.Windows.Forms.TextBox();
            this.textBox_Ki = new System.Windows.Forms.TextBox();
            this.textBox_Kp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_EncMode = new System.Windows.Forms.ComboBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_RefreshPort = new System.Windows.Forms.Button();
            this.comboBox_parity = new System.Windows.Forms.ComboBox();
            this.comboBox_stopbits = new System.Windows.Forms.ComboBox();
            this.comboBox_databits = new System.Windows.Forms.ComboBox();
            this.comboBox_baudrate = new System.Windows.Forms.ComboBox();
            this.comboBox_COM = new System.Windows.Forms.ComboBox();
            this.button_closeSerial = new System.Windows.Forms.Button();
            this.button_openSerial = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label_connectstate = new System.Windows.Forms.Label();
            this.label_motorState = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button_Start = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.button_ClearChart = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ki";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kd";
            // 
            // button_Update
            // 
            this.button_Update.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Update.Location = new System.Drawing.Point(218, 171);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(79, 34);
            this.button_Update.TabIndex = 3;
            this.button_Update.Text = "Update";
            this.button_Update.UseVisualStyleBackColor = true;
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // comboBox_FrePWM
            // 
            this.comboBox_FrePWM.FormattingEnabled = true;
            this.comboBox_FrePWM.Items.AddRange(new object[] {
            "01kHz",
            "05kHz",
            "10kHz",
            "20kHz"});
            this.comboBox_FrePWM.Location = new System.Drawing.Point(369, 84);
            this.comboBox_FrePWM.Name = "comboBox_FrePWM";
            this.comboBox_FrePWM.Size = new System.Drawing.Size(94, 21);
            this.comboBox_FrePWM.TabIndex = 4;
            this.comboBox_FrePWM.Text = "20kHz";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_SetPoint);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_Kd);
            this.groupBox1.Controls.Add(this.textBox_Ki);
            this.groupBox1.Controls.Add(this.textBox_Kp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 185);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PID";
            // 
            // textBox_SetPoint
            // 
            this.textBox_SetPoint.Location = new System.Drawing.Point(60, 151);
            this.textBox_SetPoint.MaxLength = 5;
            this.textBox_SetPoint.Name = "textBox_SetPoint";
            this.textBox_SetPoint.Size = new System.Drawing.Size(100, 29);
            this.textBox_SetPoint.TabIndex = 7;
            this.textBox_SetPoint.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Set Point";
            // 
            // textBox_Kd
            // 
            this.textBox_Kd.Location = new System.Drawing.Point(60, 94);
            this.textBox_Kd.MaxLength = 5;
            this.textBox_Kd.Name = "textBox_Kd";
            this.textBox_Kd.Size = new System.Drawing.Size(100, 29);
            this.textBox_Kd.TabIndex = 5;
            this.textBox_Kd.Text = "0";
            // 
            // textBox_Ki
            // 
            this.textBox_Ki.Location = new System.Drawing.Point(60, 61);
            this.textBox_Ki.MaxLength = 5;
            this.textBox_Ki.Name = "textBox_Ki";
            this.textBox_Ki.Size = new System.Drawing.Size(100, 29);
            this.textBox_Ki.TabIndex = 4;
            this.textBox_Ki.Text = "0";
            // 
            // textBox_Kp
            // 
            this.textBox_Kp.Location = new System.Drawing.Point(60, 28);
            this.textBox_Kp.MaxLength = 5;
            this.textBox_Kp.Name = "textBox_Kp";
            this.textBox_Kp.Size = new System.Drawing.Size(100, 29);
            this.textBox_Kp.TabIndex = 3;
            this.textBox_Kp.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(218, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "PWM Frequency";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(218, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "Encoder Mode";
            // 
            // comboBox_EncMode
            // 
            this.comboBox_EncMode.FormattingEnabled = true;
            this.comboBox_EncMode.Items.AddRange(new object[] {
            "x1",
            "x2",
            "x4"});
            this.comboBox_EncMode.Location = new System.Drawing.Point(369, 136);
            this.comboBox_EncMode.Name = "comboBox_EncMode";
            this.comboBox_EncMode.Size = new System.Drawing.Size(94, 21);
            this.comboBox_EncMode.TabIndex = 10;
            this.comboBox_EncMode.Text = "x1";
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // Chart
            // 
            this.Chart.BorderlineWidth = 2;
            chartArea1.Name = "ChartArea1";
            this.Chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Chart.Legends.Add(legend1);
            this.Chart.Location = new System.Drawing.Point(12, 245);
            this.Chart.Name = "Chart";
            this.Chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.Chart.Size = new System.Drawing.Size(813, 443);
            this.Chart.TabIndex = 11;
            this.Chart.Text = "Respone";
            title1.Name = "Velocity (rad/s)";
            this.Chart.Titles.Add(title1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_RefreshPort);
            this.groupBox2.Controls.Add(this.comboBox_parity);
            this.groupBox2.Controls.Add(this.comboBox_stopbits);
            this.groupBox2.Controls.Add(this.comboBox_databits);
            this.groupBox2.Controls.Add(this.comboBox_baudrate);
            this.groupBox2.Controls.Add(this.comboBox_COM);
            this.groupBox2.Controls.Add(this.button_closeSerial);
            this.groupBox2.Controls.Add(this.button_openSerial);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(486, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(310, 193);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Serial Port";
            // 
            // button_RefreshPort
            // 
            this.button_RefreshPort.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_RefreshPort.Location = new System.Drawing.Point(221, 24);
            this.button_RefreshPort.Name = "button_RefreshPort";
            this.button_RefreshPort.Size = new System.Drawing.Size(34, 34);
            this.button_RefreshPort.TabIndex = 20;
            this.button_RefreshPort.UseVisualStyleBackColor = true;
            this.button_RefreshPort.Click += new System.EventHandler(this.button_RefreshPort_Click);
            // 
            // comboBox_parity
            // 
            this.comboBox_parity.FormattingEnabled = true;
            this.comboBox_parity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.comboBox_parity.Location = new System.Drawing.Point(94, 156);
            this.comboBox_parity.Name = "comboBox_parity";
            this.comboBox_parity.Size = new System.Drawing.Size(121, 30);
            this.comboBox_parity.TabIndex = 19;
            this.comboBox_parity.Text = "None";
            // 
            // comboBox_stopbits
            // 
            this.comboBox_stopbits.FormattingEnabled = true;
            this.comboBox_stopbits.Items.AddRange(new object[] {
            "One",
            "Two"});
            this.comboBox_stopbits.Location = new System.Drawing.Point(94, 124);
            this.comboBox_stopbits.Name = "comboBox_stopbits";
            this.comboBox_stopbits.Size = new System.Drawing.Size(121, 30);
            this.comboBox_stopbits.TabIndex = 18;
            this.comboBox_stopbits.Text = "One";
            // 
            // comboBox_databits
            // 
            this.comboBox_databits.FormattingEnabled = true;
            this.comboBox_databits.Items.AddRange(new object[] {
            "6",
            "7",
            "8"});
            this.comboBox_databits.Location = new System.Drawing.Point(94, 91);
            this.comboBox_databits.Name = "comboBox_databits";
            this.comboBox_databits.Size = new System.Drawing.Size(121, 30);
            this.comboBox_databits.TabIndex = 17;
            this.comboBox_databits.Text = "8";
            // 
            // comboBox_baudrate
            // 
            this.comboBox_baudrate.FormattingEnabled = true;
            this.comboBox_baudrate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBox_baudrate.Location = new System.Drawing.Point(94, 58);
            this.comboBox_baudrate.Name = "comboBox_baudrate";
            this.comboBox_baudrate.Size = new System.Drawing.Size(121, 30);
            this.comboBox_baudrate.TabIndex = 16;
            this.comboBox_baudrate.Text = "115200";
            // 
            // comboBox_COM
            // 
            this.comboBox_COM.FormattingEnabled = true;
            this.comboBox_COM.Location = new System.Drawing.Point(94, 24);
            this.comboBox_COM.Name = "comboBox_COM";
            this.comboBox_COM.Size = new System.Drawing.Size(121, 30);
            this.comboBox_COM.TabIndex = 15;
            this.comboBox_COM.Text = "COM1";
            // 
            // button_closeSerial
            // 
            this.button_closeSerial.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_closeSerial.Location = new System.Drawing.Point(221, 151);
            this.button_closeSerial.Name = "button_closeSerial";
            this.button_closeSerial.Size = new System.Drawing.Size(79, 34);
            this.button_closeSerial.TabIndex = 14;
            this.button_closeSerial.Text = "Close";
            this.button_closeSerial.UseVisualStyleBackColor = true;
            this.button_closeSerial.Click += new System.EventHandler(this.button_closeSerial_Click);
            // 
            // button_openSerial
            // 
            this.button_openSerial.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_openSerial.Location = new System.Drawing.Point(221, 111);
            this.button_openSerial.Name = "button_openSerial";
            this.button_openSerial.Size = new System.Drawing.Size(79, 34);
            this.button_openSerial.TabIndex = 13;
            this.button_openSerial.Text = "Open";
            this.button_openSerial.UseVisualStyleBackColor = true;
            this.button_openSerial.Click += new System.EventHandler(this.button_openSerial_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 159);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 23);
            this.label11.TabIndex = 8;
            this.label11.Text = "Parity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "StopBits";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 23);
            this.label8.TabIndex = 1;
            this.label8.Text = "Baudrate";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 23);
            this.label9.TabIndex = 0;
            this.label9.Text = "COM";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 23);
            this.label10.TabIndex = 2;
            this.label10.Text = "DataBits";
            // 
            // label_connectstate
            // 
            this.label_connectstate.AutoSize = true;
            this.label_connectstate.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_connectstate.ForeColor = System.Drawing.Color.Red;
            this.label_connectstate.Location = new System.Drawing.Point(493, 220);
            this.label_connectstate.Name = "label_connectstate";
            this.label_connectstate.Size = new System.Drawing.Size(263, 22);
            this.label_connectstate.TabIndex = 20;
            this.label_connectstate.Text = "Serial is not connected";
            // 
            // label_motorState
            // 
            this.label_motorState.AutoSize = true;
            this.label_motorState.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_motorState.ForeColor = System.Drawing.Color.Red;
            this.label_motorState.Location = new System.Drawing.Point(218, 220);
            this.label_motorState.Name = "label_motorState";
            this.label_motorState.Size = new System.Drawing.Size(186, 22);
            this.label_motorState.TabIndex = 21;
            this.label_motorState.Text = "Motor is stopped";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DarkOrange;
            this.label14.Location = new System.Drawing.Point(216, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(262, 36);
            this.label14.TabIndex = 24;
            this.label14.Text = "L01 - Group 8";
            // 
            // button_Start
            // 
            this.button_Start.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Start.Location = new System.Drawing.Point(303, 171);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(79, 34);
            this.button_Start.TabIndex = 25;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Stop.Location = new System.Drawing.Point(388, 171);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(79, 34);
            this.button_Stop.TabIndex = 26;
            this.button_Stop.Text = "Stop";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // button_ClearChart
            // 
            this.button_ClearChart.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ClearChart.Location = new System.Drawing.Point(25, 205);
            this.button_ClearChart.Name = "button_ClearChart";
            this.button_ClearChart.Size = new System.Drawing.Size(79, 34);
            this.button_ClearChart.TabIndex = 21;
            this.button_ClearChart.Text = "Clear";
            this.button_ClearChart.UseVisualStyleBackColor = true;
            this.button_ClearChart.Click += new System.EventHandler(this.button_ClearChart_Click);
            // 
            // timer
            // 
            this.timer.Interval = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 700);
            this.Controls.Add(this.button_ClearChart);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label_motorState);
            this.Controls.Add(this.label_connectstate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Chart);
            this.Controls.Add(this.comboBox_EncMode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox_FrePWM);
            this.Controls.Add(this.button_Update);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "DC Motor Control";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_Update;
        private System.Windows.Forms.ComboBox comboBox_FrePWM;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_SetPoint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Kd;
        private System.Windows.Forms.TextBox textBox_Ki;
        private System.Windows.Forms.TextBox textBox_Kp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_EncMode;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_closeSerial;
        private System.Windows.Forms.Button button_openSerial;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox_parity;
        private System.Windows.Forms.ComboBox comboBox_stopbits;
        private System.Windows.Forms.ComboBox comboBox_databits;
        private System.Windows.Forms.ComboBox comboBox_baudrate;
        private System.Windows.Forms.ComboBox comboBox_COM;
        private System.Windows.Forms.Label label_connectstate;
        private System.Windows.Forms.Label label_motorState;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.Button button_RefreshPort;
        private System.Windows.Forms.Button button_ClearChart;
        private System.Windows.Forms.Timer timer;
    }
}

