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
    public partial class Trigger : Form
    {
        public const string oscVisaUSB = "USB0::0x0AAD::0x01D6::102822::INSTR"; //Usb ile bilgisayara bağlanan oscilloscope'un konumudur.
        RTA4004 RTA4004_scope = new RTA4004(oscVisaUSB); //Oscilloscope'a usb konumu belirtilerek bilgisayar ile bağlantısı sağlanır.
        public Trigger()
        {
            InitializeComponent();
        }
        private void Trigger_Load(object sender, EventArgs e)
        {
            textBox2.Hide(); 
            //HF Reject ve Niose Reject ayarlarının ON/OFF şeklinde radio buttonlarda seçilerek oscilloscope'a aktarılırken kullanılan textbox'lar kullanıcıya gözükmemesi için gizlenir. 
            textBox3.Hide(); 
            //HF Reject ve Niose Reject ayarlarının ON/OFF şeklinde radio buttonlarda seçilerek oscilloscope'a aktarılırken kullanılan textbox'lar kullanıcıya gözükmemesi için gizlenir. 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RTA4004_scope.SetEdgeTrigger(comboBox1.Text, comboBox2.Text, comboBox3.Text, textBox1.Text, comboBox4.Text, " EDGE", comboBox5.Text, 
            textBox2.Text, textBox3.Text); //Trigger formunda kullanıcının girdiği değerleri Oscilloscope'a akatramak için kullanılır.
        }
        public void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Text = "ON"; //Noise reject'in kullanıcı tarafından ON seçilmesinin ardından, bu seçim textBox3'e aktarılarak seçimin oscilloscope'a gönderilmesi sağlanır.
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();  //Trigger formunda bulunan Back  tuşuna basıldığında Form1'e geri dönüş sağlanır.
            this.Close(); //Trigger formu kapatılır.
            frm1.Show(); //Form 1'in açılması sağlanır.
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "ON";  //HF Reject'in kullanıcı tarafından ON seçilmesinin ardından, bu seçim textBox3'e aktarılarak seçimin oscilloscope'a gönderilmesi sağlanır.
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "OFF"; //Noise reject'in kullanıcı tarafından OFF seçilmesinin ardından, bu seçim textBox3'e aktarılarak seçimin oscilloscope'a gönderilmesi sağlanır.
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Text = "OFF"; //HF Reject'in kullanıcı tarafından OFF seçilmesinin ardından, bu seçim textBox3'e aktarılarak seçimin oscilloscope'a gönderilmesi sağlanır.
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
