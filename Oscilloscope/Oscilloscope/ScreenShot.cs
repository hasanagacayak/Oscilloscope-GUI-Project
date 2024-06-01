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
    public partial class ScreenShot : Form
    {
        public const string oscVisaUSB = "USB0::0x0AAD::0x01D6::102822::INSTR"; //Usb ile bilgisayara bağlanan oscilloscope'un konumudur.
        IIviScope scope;
        RTA4004 RTA4004_scope = new RTA4004(oscVisaUSB); //Oscilloscope'a usb konumu belirtilerek bilgisayar ile bağlantısı sağlanır.
        public ScreenShot()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
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
            RTA4004_scope.screenshot("ON", comboBox1.Text); //Form'dan alınan bilgilerin oscilloscope'a gönderilmesi sağlanır.
            pictureBox1.ImageLocation= (@"D:\staj\Hasan Ağaçayak\Oscilloscope\Oscilloscope\ScreenShot1\uptodate.png");
            //Kullanıcı apply tuşuna bastığında alınan ekran görüntüsü anlık olarak pictureBox1'de gösterilir.
        }
        private void ScreenShot_Load(object sender, EventArgs e)
        {

        }
    }
}
