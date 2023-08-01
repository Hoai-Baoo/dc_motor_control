using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;


namespace DCMotorControl
{
    public partial class MainForm : Form
    {
        string dataframe;
        int startstopState;
        double time;
        double setpoint;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string[] portNames = SerialPort.GetPortNames();
            comboBox_COM.Items.AddRange(portNames);

            dataframe = "";
            startstopState = 0;
            time = 0;

            button_closeSerial.Enabled = false;
            button_Start.Enabled = false;
            button_Stop.Enabled = false;
            button_Update.Enabled = false;
            button_RefreshPort.Text = char.ConvertFromUtf32(0x000021BB);

            Chart.Titles.Add("Velocity Graph");

            var chartArea = Chart.ChartAreas[0];
            chartArea.AxisX.LabelStyle.Format = "";
            chartArea.AxisY.LabelStyle.Format = "";
            chartArea.AxisX.LabelStyle.IsEndLabelVisible = true;
            chartArea.AxisY.LabelStyle.IsEndLabelVisible = true;

            chartArea.AxisY.Minimum = -130;
            chartArea.AxisY.Maximum = 130;

            chartArea.AxisX.Interval = 5;
            chartArea.AxisY.Interval = 10;

            chartArea.AxisX.Title = "Time (s)";
            chartArea.AxisY.Title = "Velocity (rpm)";

            Chart.Series.Add("Setpoint");
            Chart.Series["Setpoint"].ChartType = SeriesChartType.Line;
            Chart.Series["Setpoint"].Color = Color.Red;
            Chart.Series["Setpoint"].BorderWidth = 2;
            Chart.Series["Setpoint"].IsVisibleInLegend = true;
            Chart.Series.Add("Velocity");
            Chart.Series["Velocity"].ChartType = SeriesChartType.Line;
            Chart.Series["Velocity"].Color = Color.Blue;
            Chart.Series["Velocity"].BorderWidth = 2;
            Chart.Series["Velocity"].IsVisibleInLegend = true;
        }

        private string changeFormat(string value)
        {
            char[] charResult = { '0', '0', '0', '0', '0' };
            int index = 0;
            int len = value.Length;
            while (index < 5)
            {
                if (index < len)
                {
                    charResult[4 - index] = value[(len - 1) - index];
                    if (value[len - 1 - index] == '-')
                    {
                        charResult[4 - index] = '0';
                        charResult[0] = '-';
                    }
                }    
                index++;
            }
            string result = new string(charResult);
            return result;
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                dataframe = "";
                dataframe += Convert.ToString(startstopState);
                dataframe += changeFormat(textBox_SetPoint.Text);
                dataframe += changeFormat(textBox_Kp.Text);
                dataframe += changeFormat(textBox_Ki.Text);
                dataframe += changeFormat(textBox_Kd.Text);
                dataframe += comboBox_FrePWM.Text.Split('k')[0];
                dataframe += comboBox_EncMode.Text[1];

                setpoint = Convert.ToDouble(textBox_SetPoint.Text);

                serialPort.Write(dataframe);
            }
        }

        private void button_openSerial_Click(object sender, EventArgs e)
        {
            try
            {
                setpoint = Convert.ToDouble(textBox_SetPoint.Text);
                serialPort.PortName = comboBox_COM.Text;
                serialPort.BaudRate = Convert.ToInt32(comboBox_baudrate.Text);
                serialPort.DataBits = Convert.ToInt32(comboBox_databits.Text);
                serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), comboBox_stopbits.Text);
                serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), comboBox_parity.Text);

                serialPort.Open();
                label_connectstate.Text = "Serial is connected to " + comboBox_COM.Text;
                label_connectstate.ForeColor = Color.Green;

                button_closeSerial.Enabled = true;
                button_Start.Enabled = true;
                button_Stop.Enabled = true;
                button_Update.Enabled = true;

                comboBox_COM.Enabled = false;
                comboBox_baudrate.Enabled = false;
                comboBox_databits.Enabled = false;
                comboBox_parity.Enabled = false;
                comboBox_stopbits.Enabled = false;

             
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_closeSerial_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Close");
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                    label_connectstate.Text = "Serial disconnected";
                    label_connectstate.ForeColor = Color.Red;

                    Console.WriteLine("Closed Succesful");

                    button_closeSerial.Enabled = false;
                    button_Start.Enabled = false;
                    button_Stop.Enabled = false;
                    button_Update.Enabled = false;
                    textBox_SetPoint.Enabled = true;

                    comboBox_COM.Enabled = true;
                    comboBox_baudrate.Enabled = true;
                    comboBox_databits.Enabled = true;
                    comboBox_parity.Enabled = true;
                    comboBox_stopbits.Enabled = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string receiveData;
            receiveData = serialPort.ReadLine();
            this.BeginInvoke(new SetDeleg(UpdateData), new object[] { receiveData });
        }
        private delegate void SetDeleg(string text);

        private void UpdateData(string receiveData)
        {
            time = Math.Round(time + 0.005,3);

            string displayVelocity = receiveData;
            //if (setpoint < 0)
            //    displayVelocity = "-" + receiveData;
            try
            {
                Chart.Series["Setpoint"].Points.AddXY(time, setpoint.ToString());
                PlotChart(time, displayVelocity);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            startstopState = 1;
            label_motorState.Text = "Motor is running";
            label_motorState.ForeColor = Color.Green;

            dataframe = "";
            dataframe += Convert.ToString(startstopState);
            dataframe += changeFormat(textBox_SetPoint.Text);
            dataframe += changeFormat(textBox_Kp.Text);
            dataframe += changeFormat(textBox_Ki.Text);
            dataframe += changeFormat(textBox_Kd.Text);
            dataframe += comboBox_FrePWM.Text.Split('k')[0];
            dataframe += comboBox_EncMode.Text[1];
            setpoint = Convert.ToDouble(textBox_SetPoint.Text);

            serialPort.Write(dataframe);
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            startstopState = 0;
            label_motorState.Text = "Motor is stopping";
            label_motorState.ForeColor = Color.Red;

            dataframe = "";
            dataframe += Convert.ToString(startstopState);
            dataframe += changeFormat(textBox_SetPoint.Text);
            dataframe += changeFormat(textBox_Kp.Text);
            dataframe += changeFormat(textBox_Ki.Text);
            dataframe += changeFormat(textBox_Kd.Text);
            dataframe += comboBox_FrePWM.Text.Split('k')[0];
            dataframe += comboBox_EncMode.Text[1];
            setpoint = Convert.ToDouble(textBox_SetPoint.Text);

            serialPort.Write(dataframe);
        }

        private void button_RefreshPort_Click(object sender, EventArgs e)
        {
            comboBox_COM.Items.Clear();
            string[] portNames = SerialPort.GetPortNames();
            comboBox_COM.Items.AddRange(portNames);
        }


        private void PlotChart(double dataX, string dataY)
        {
            Chart.Series["Velocity"].Points.AddXY(dataX, dataY);

            var chartArea = Chart.ChartAreas[0];
            if (dataX > chartArea.AxisX.Maximum)
            {
                chartArea.AxisX.Maximum = dataX;
                if (dataX / chartArea.AxisX.Interval == 10)
                    chartArea.AxisX.Interval = dataX / 5;
            }
            if (Convert.ToDouble(dataY) > chartArea.AxisY.Maximum)
            {
                chartArea.AxisY.Maximum += 20;
            }
        }

        private void button_ClearChart_Click(object sender, EventArgs e)
        {
            time = 0; //reset time
            foreach (var series in Chart.Series)
            {
                series.Points.Clear();
            }
        }
    }
}
