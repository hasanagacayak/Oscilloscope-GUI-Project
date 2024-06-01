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
using System.Threading;
namespace Oscilloscope
{
    public partial class Acquisition : Form
    {
        public const string oscVisaUSB = "USB0::0x0AAD::0x01D6::102822::INSTR"; //Usb ile bilgisayara bağlanan oscilloscope'un konumudur.
        public int counter = 0;
        IIviScope scope;
        RTA4004 RTA4004_scope = new RTA4004(oscVisaUSB);  //Oscilloscope'a usb konumu belirtilerek bilgisayar ile bağlantısı sağlanır.
        public Acquisition()
        {
            InitializeComponent();
        }
        private void Acquisition_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RTA4004_scope.AcquisitionSetting(comboBox1.Text, comboBox2.Text, comboBox3.Text, comboBox6.Text, textBox2.Text, comboBox4.Text, textBox3.Text, comboBox5.Text, "OFF");
            //Acquisition Form'unda kullanıcıdan alınan bilgiler oscilloscope'a aktarılması sağlanır. 
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();  //Acquisition formunda bulunan Back  tuşuna basıldığında Form1'e geri dönüş sağlanır.
            this.Close(); //Acquisition formu kapatılır.
            frm1.Show(); //Form 1'in açılması sağlanır.
        }
    }
}
