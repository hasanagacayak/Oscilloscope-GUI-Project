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
    public partial class Protocol : Form
    {
        public const string oscVisaUSB = "USB0::0x0AAD::0x01D6::102822::INSTR"; //Usb ile bilgisayara bağlanan oscilloscope'un konumudur.
        IIviScope scope;
        RTA4004 RTA4004_scope = new RTA4004(oscVisaUSB); //Oscilloscope'a usb konumu belirtilerek bilgisayar ile bağlantısı sağlanır.
        public Protocol()
        {
            InitializeComponent();
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();  //Bu formdaki bulunan Back  tuşuna basıldığında Form1'e geri dönüş sağlanır.
            this.Close(); //Bu form kapatılır.
            frm1.Show(); //Form 1'in açılması sağlanır.
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RTA4004_scope.Protocol(comboBox1.Text, comboBox2.Text, 
            comboBox3.Text, comboBox4.Text, comboBox5.Text, comboBox6.Text);
            //Protocol formunda kullanıcının girdiği değerleri Oscilloscope'a akatramak için kullanılır.
        }
        private void Protocol_Load(object sender, EventArgs e)
        {

        }
    }
}
