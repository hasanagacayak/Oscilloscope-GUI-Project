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
    public partial class QuickMeasure : Form
    {
        public const string oscVisaUSB = "USB0::0x0AAD::0x01D6::102822::INSTR"; //Usb ile bilgisayara bağlanan oscilloscope'un konumudur.
        IIviScope scope;
        RTA4004 RTA4004_scope = new RTA4004(oscVisaUSB); //Oscilloscope'a usb konumu belirtilerek bilgisayar ile bağlantısı sağlanır.
        public QuickMeasure()
        {
            InitializeComponent();
        }
        private void QuickMeasure_Load(object sender, EventArgs e)
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
            //Quick Measure formuna kullanılacak değişkenler aşağıda tanıtılmıştır.
            double Vpp;
            double VpPos;
            double VpNeg;
            double RMS;
            double MeanCyc;
            double Period;
            double Freq;
            double RTIM;
            double FTIM;
            RTA4004_scope.Quick_Measurement(out Vpp, out VpPos, out VpNeg, out RMS,
            out MeanCyc, out Period, out Freq, out RTIM, out FTIM); //Quick Measure formunda kullanıcının girdiği değerleri Oscilloscope'a akatramak için kullanılır.
            //Oscilloscope'dan alınan hesaplama sonuçlarını form kısmındaki ilgili textboxlara yazma işlemleri aşağıdaki şekilde yaptırılır.
            textBox1.Text = Vpp.ToString();
            textBox2.Text = VpPos.ToString();
            textBox3.Text = VpNeg.ToString();
            textBox4.Text = RMS.ToString();
            textBox5.Text = MeanCyc.ToString();
            textBox6.Text = Period.ToString();
            textBox7.Text = Freq.ToString();
            textBox8.Text = RTIM.ToString();
            textBox9.Text = FTIM.ToString();
        }
    }
}
