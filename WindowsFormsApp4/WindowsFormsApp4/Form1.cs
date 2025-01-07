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

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {

        SerialPort serialPort;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("COM5");
            comboBox1.SelectedItem = "COM5";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // ComboBox'tan seçilen portu al
                string selectedPort = comboBox1.SelectedItem.ToString();

                // Seri port ayarlarını yap
                serialPort = new SerialPort
                {
                    PortName = selectedPort,
                    BaudRate = 9600,
                    DataBits = 8,
                    Parity = Parity.None,
                    StopBits = StopBits.One
                };

                serialPort.DataReceived += SerialPort_DataReceived; // Veri geldiğinde tetiklenir
                serialPort.Open(); // Portu aç
                MessageBox.Show($"Bağlantı {selectedPort} portuna başarıyla yapıldı!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bağlantı hatası: {ex.Message}");
            }
        }
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // Gelen veriyi oku
                string data = serialPort.ReadExisting();

                // TextBox'ta göstermek için UI thread'e aktar
                Invoke((MethodInvoker)delegate
                {
                    textBox1.AppendText(data); // Veriyi TextBox'a ekle
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri okuma hatası: {ex.Message}");
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Uygulama kapanırken portu kapat
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }
    }
}
