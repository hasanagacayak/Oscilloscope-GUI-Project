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
    public partial class Ch4 : Form
    {
        public const string oscVisaUSB = "USB0::0x0AAD::0x01D6::102822::INSTR"; //Usb ile bilgisayara bağlanan oscilloscope'un konumudur.
        public int counter = 0;
        IIviScope scope;
        RTA4004 RTA4004_scope = new RTA4004(oscVisaUSB); //Oscilloscope'a usb konumu belirtilerek bilgisayar ile bağlantısı sağlanır.
        public Ch4()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
           Form1 frm1 = new Form1();  //Bu formdaki bulunan Back  tuşuna basıldığında Form1'e geri dönüş sağlanır.
            this.Close(); //Bu form kapatılır.
            frm1.Show(); //Form 1'in açılması sağlanır.
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RTA4004_scope.VerticalSettings(4, comboBox1.Text, textBox7.Text, textBox1.Text, textBox3.Text, comboBox5.Text, comboBox6.Text, comboBox7.Text,
            textBox4.Text, textBox5.Text, comboBox10.Text, textBox6.Text, comboBox11.Text); //Ch4 formunda kullanıcının girdiği değerleri Oscilloscope'a akatarmak için kullanılır.
        }
        private void Ch4_Load(object sender, EventArgs e)
        {

        }
    }
}
