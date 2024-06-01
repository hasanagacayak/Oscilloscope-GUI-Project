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
    public partial class Horizontal : Form
    {
        public const string oscVisaUSB = "USB0::0x0AAD::0x01D6::102822::INSTR"; //Usb ile bilgisayara bağlanan oscilloscope'un konumudur.
        public int counter = 0;
        IIviScope scope;
        RTA4004 RTA4004_scope = new RTA4004(oscVisaUSB); //Oscilloscope'a usb konumu belirtilerek bilgisayar ile bağlantısı sağlanır.
        public Horizontal()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RTA4004_scope.HorizontalSettings(comboBox1.Text, textBox1.Text,
            textBox2.Text); //APPLY tuşuna basıldığında, kullanıcının girdiği Refference Point, Time Scale ve Horizantal Position girdileri oscilloscope'a gönderilir.
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1(); //Horizantal formunda bulunan Back  tuşuna basıldığında Form1'e geri dönüş sağlanır.
            frm1.Show();//Form 1'in açılması sağlanır.
            this.Hide(); //Horizantal formu kapatılır.
        }
        private void label5_Click(object sender, EventArgs e)
        {
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Refference Point kısmında belirtilen seçenekler seçildiğinde bu seçeneklerin ne anlama geldiklerini seçimden sonra label kısmına yazdırarak kullanıcıya  bilgi verilir.
            if (comboBox1.Text == "8.33")
            {
                label5.Text = "Left Position";
            }
            if (comboBox1.Text == "50")
            {
                label5.Text = "Mid Position";
            }
            if (comboBox1.Text == "91.67")
            {
                label5.Text = "Right Position";
            }
        }
        private void Horizantal_Load(object sender, EventArgs e)
        {

        }
    }
}
