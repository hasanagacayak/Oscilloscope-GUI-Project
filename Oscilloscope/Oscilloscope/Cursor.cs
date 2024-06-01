using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ivi.Scope;
namespace Oscilloscope
{
    public partial class Cursor : Form
    {
        public const string oscVisaUSB = "USB0::0x0AAD::0x01D6::102822::INSTR"; //Usb ile bilgisayara bağlanan oscilloscope'un konumudur.
        IIviScope scope;
        RTA4004 RTA4004_scope = new RTA4004(oscVisaUSB); //Oscilloscope'a usb konumu belirtilerek bilgisayar ile bağlantısı sağlanır.
        public Cursor()
        {
            InitializeComponent();
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1(); //Bu formdaki bulunan Back  tuşuna basıldığında Form1'e geri dönüş sağlanır.
            this.Close(); //Bu form kapatılır.
            frm1.Show(); //Form 1'in açılması sağlanır.
        }
        private void button1_Click(object sender, EventArgs e)
        {  //Cursor'da formunda kullanılacak değişkenler aşağıda tanıtılır.
            double X_delta_t;
            double inverse_time;
            double Y_delta_t;
            double Y_delta_slope;
            RTA4004_scope.CursorMeasurement(comboBox1.Text, comboBox2.Text, comboBox3.Text, comboBox4.Text, comboBox5.Text,
            textBox7.Text, textBox8.Text, textBox13.Text, textBox14.Text, out X_delta_t, out inverse_time, out Y_delta_t, out Y_delta_slope); 
            //Cursor formunda kullanıcının girdiği değerleri Oscilloscope'a akatramak için kullanılır.
            //Oscilloscope'dan alınan hesaplama sonuçlarını form kısmındaki ilgili textboxlara yazma işlemleri aşağıdaki şekilde yaptırılır.
            textBox9.Text = X_delta_t.ToString();
            textBox10.Text = inverse_time.ToString();
            textBox11.Text = Y_delta_t.ToString();
            textBox12.Text = Y_delta_slope.ToString();
        }
        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void Cursor_Load(object sender, EventArgs e)
        {

        }
    }
}
