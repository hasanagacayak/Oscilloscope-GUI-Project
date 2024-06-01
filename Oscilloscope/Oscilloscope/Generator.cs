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
    public partial class Generator : Form
    {
        public const string oscVisaUSB = "USB0::0x0AAD::0x01D6::102822::INSTR"; //Usb ile bilgisayara bağlanan oscilloscope'un konumudur.

        IIviScope scope;
        RTA4004 RTA4004_scope = new RTA4004(oscVisaUSB); //Oscilloscope'a usb konumu belirtilerek bilgisayar ile bağlantısı sağlanır.
        public Generator()
        {
            InitializeComponent();
        }
        private void Generator_Load(object sender, EventArgs e)
        {

        }
        private void label7_Click(object sender, EventArgs e)
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
            
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            RTA4004_scope.Generator(comboBox1.Text, comboBox2.Text, textBox1.Text,
            textBox2.Text, textBox3.Text, textBox4.Text);
            //Generator formunda kullanıcının girdiği değerleri Oscilloscope'a akatramak için kullanılır.
        }
    }
}
