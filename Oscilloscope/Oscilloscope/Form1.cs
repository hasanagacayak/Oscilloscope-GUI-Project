using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ivi.Driver;
using Ivi.Scope;
using Ivi.Visa.Interop;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using RohdeSchwarz;
using System.Drawing;
using System.Threading;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using Timer = System.Windows.Forms.Timer;
namespace Oscilloscope
{
    public partial class Form1 : Form
    {
        Bitmap image, image2, image3, image4; //Çembersel düğmelerin fotoğrafları tanımlanır.
        float angle = 0; //Çembersel düğmelerin başlangıç açılaır 0 tanıtılır.
        float angle1 = 0; //Çembersel düğmelerin başlangıç açılaır 0 tanıtılır.
        float angle2 = 0; //Çembersel düğmelerin başlangıç açılaır 0 tanıtılır.
        float angle3 = 0; //Çembersel düğmelerin başlangıç açılaır 0 tanıtılır.
        public const string oscVisaUSB = "USB0::0x0AAD::0x01D6::102822::INSTR"; //Bilgisayara usb ile bağlanan oscilloscope'un konumu oscVisaUSB değişkenine tanımlanır.
        public int counter = 0;
        //CH'ler ortak formda olduğu için counter her biri için sayılıyor bu yüzden yeni counter'lar açıldı.
        public int counter1 = 0;
        public int counter2 = 0;
        public int counter3 = 0;
        public int counter4 = 0;

        IIviScope scope;
        RTA4004 RTA4004_scope = new RTA4004(oscVisaUSB); 
        // Oscilloscope cihazının konumunu eklediğimiz değişkenini RTA4004 class'ının içindeki RTA4004_scope değişkenine tanımlanır.
        public static int triggermodeNorm;
        bool on = true;
        bool toggleLight = true;
        Timer t = new Timer();
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(string visaSrcName)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Bilgisayar'daki kaynağından çekilen png'lerin konumları değişkenlere atılır.
            pictureBox2.Location = new Point(959, 104);
            image = new Bitmap(Oscilloscope.Properties.Resources.png_transparent_oscilloscope_electronics_inkscape_heathkit_showing_angle_electronics_text);

            pictureBox3.Location = new Point(196, 162);
            image2 = new Bitmap(Oscilloscope.Properties.Resources.png_transparent_oscilloscope_electronics_inkscape_heathkit_showing_angle_electronics_text);

            pictureBox4.Location = new Point(196, 36);
            image3 = new Bitmap(Oscilloscope.Properties.Resources.png_transparent_oscilloscope_electronics_inkscape_heathkit_showing_angle_electronics_text);

            pictureBox5.Location = new Point(14, 61);
            image4 = new Bitmap(Oscilloscope.Properties.Resources.png_transparent_oscilloscope_electronics_inkscape_heathkit_showing_angle_electronics_text);
        }
        public void button1_Click(object sender, EventArgs e)
        {
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            if (triggermodeNorm==1) //Trigger Mode Norm seçiliyken Force Trigger'ın çalışması içi aşağıdaki komutlar uygulanır.
            {
                RTA4004_scope.ForceTrigger(); //Force trigger komutu Çalıştırılır.
                t.Start();
                on = false;
            }
            else
            {
                label6.BackColor = SystemColors.Control;
                t.Stop(); 
                on = true;
            }
        }
        private void t_Tick(object sender, EventArgs e)
        {
            if (toggleLight)
            {
                label6.BackColor = Color.Green; //Çalıştığını belli etmek için Trig'd label'ını yeşil renk yaparız. 
                toggleLight = false;
            }
            else
            {
                label6.BackColor = SystemColors.Control;
                toggleLight = true;
            }
        } //Trig'd'nin yeşil ışık yakıp sönmesi sağlanır.
        private void label4_Click(object sender, EventArgs e)
        {
        }
        private void label5_Click(object sender, EventArgs e)
        {
        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }
        private void button4_Click(object sender, EventArgs e)
        {
            counter++; //Kullanıcı Run/Stop tuşuna bastığında counter değişkeni 1 arttırılır.
            if(counter % 2 == 0) //Counter değişkeni çift sayı ise bu cihazın stop durumunda olduğu anlaşılır ve aşağıdaki işlemler gerçekleştirilir.
            {
                button4.BackColor = Color.Green; //Kırmızı şekilde Run/Stop tuşuna basıldığında bu kısıma gelerek tuşun rengi yeşil yapılır.
                RTA4004_scope.Run(); //Tuş yeşil yapıldıktan sonra oscilloscope'a Run komutu verilir.
                button7.BackColor = SystemColors.Control;
            }
            else //Counter değişkeni tek sayı ise bu cihazın run durumunda olduğu anlaşılır ve aşağıdaki işlemler gerçekleştirilir.
            { 
                button4.BackColor = Color.Red; //Yeşil şekilde Run/Stop tuşuna basıldığında bu kısıma gelerek tuşun rengi kırmızı yapılır.
                RTA4004_scope.Stop(); //Tuş kırmızı yapıldıktan sonra oscilloscope'a Run komutu verilir.
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            counter++; //Kullanıcı Single tuşuna bastığında counter değişkeni 1 arttırılır.
            if (counter % 2 == 1)  //Counter değişkeni tek sayı ise bu single tuşunun tuşlanmadığı anlaşılır ve aşağıdaki işlemler gerçekleştirilir.
            {
                RTA4004_scope.Single(); //Oscilloscope'a Single komutunu verir.
                button7.BackColor = Color.White; //Komutu verildiğinin anlaşılması için rengini White'a dönüştürürüz.
                button4.BackColor = Color.Red; //Yeşil şekilde Run/Stop tuşuna basıldığında bu kısıma gelerek tuşun rengi kırmızı yapılır.
            }
            else  //Counter değişkeni çift sayı ise bu single tuşunun tuşlandığı anlaşılır ve aşağıdaki işlemler gerçekleştirilir.
            {
                button7.BackColor = Color.White; //Komutu verildiğinin anlaşılması için rengini White'a dönüştürürüz.
                RTA4004_scope.Single(); //Oscilloscope'a Single komutunu verir.
            }
        }
        public void button6_Click(object sender, EventArgs e)
        {
            counter++; //Kullanıcı Auto/Norm tuşuna bastığında counter değişkeni 1 arttırılır.
            if (counter % 2 == 0) 
            {
                RTA4004_scope.TriggerModeAuto(); //Oscilloscope'a Auto/Norm komutunda Trigger Mode'ta Auto seçeneğine geçilir.
                triggermodeNorm = 0;
                button6.BackColor = SystemColors.Control; //Komutu değiştirdiğimizin anlaşılması için rengini eski rengi olan Control'e dönüştürürüz.
                label6.BackColor = SystemColors.Control;
            }
            else
            {
                RTA4004_scope.TriggerModeNormal(); //Oscilloscope'a Auto/Norm komutunda Trigger Mode'ta Norm seçeneğine geçilir.
                button6.BackColor = Color.White; //Komutu verildiğinin anlaşılması için rengini White'a dönüştürürüz.
                triggermodeNorm = 1;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        { //Source tuşu 4 farklı seçenek sunduğu için if döngüsü içerisinde 4 farklı mod alınır.
            counter++; //Kullanıcı Source tuşuna bastığında counter değişkeni 1 arttırılır.
            if (counter % 4 == 0) // //Counter değişkeni 4'e tam bölünüyorsa...
            {
                button5.BackColor = Color.Yellow; //Source tuşu sarı renk yakılır.
                RTA4004_scope.TriggerSourceCH1(); //Source tuşu Ch1'e ayarlanır.
            }
            else if (counter % 4 == 1)
            {
                button5.BackColor = Color.Green;//Source tuşu yeşil renk yakılır.
                RTA4004_scope.TriggerSourceCH2();//Source tuşu Ch2'e ayarlanır.
            }
            else if (counter % 4 == 2)
            {
                button5.BackColor = Color.Orange;//Source tuşu turuncu renk yakılır.
                RTA4004_scope.TriggerModeSourceCH3();//Source tuşu Ch3'e ayarlanır.
            }
            else
            {
                button5.BackColor = Color.DeepSkyBlue;//Source tuşu mavi renk yakılır.
                RTA4004_scope.TriggerModeSourceCH4();//Source tuşu Ch4'e ayarlanır.
            }
        }
        private void button32_Click(object sender, EventArgs e)
        {
            RTA4004_scope.Autoscale(); //AutoSet tuşuna basıldığında ekranın ve ayarların yenilenmei için oscilloscope'a kod gönderilir. 
        }
        private void button29_Click(object sender, EventArgs e)
        {
            RTA4004_scope.Reset(1500); // Preset tuşuna basıldığında ekranın ve tuş ayarlarının sıfırlanması için oscilloscope'a kod gönderilir.
        }
        private void button30_Click(object sender, EventArgs e)
        {
            RTA4004_scope.clearscreen(); //Clear screen tuşuna basıldığında ekranın sıfırlanarak ekranın sıfırlanması için oscilloscope'a kod gönderilir.
        }
        private void button3_Click(object sender, EventArgs e) //Trigger tuşuna basıldığında trigger formunun açılması için aşağıdaki komutlar uygulanır.
        {
            Trigger trigger = new Trigger();  //Trigger formu tanıtılır.
            trigger.Show(); //Trigger formu ekranda açılır.
            this.Hide(); //Form1 ekranda kapatılır.
        }
        private void button18_Click(object sender, EventArgs e) //Zoom tuşuna basıldığında zoom formunun açılması için aşağıdaki komutlar uygulanır. 
        {
            Zoom zoom = new Zoom(); //Zoom formu tanıtılır.
            this.Hide(); //Form 1 ekranda gizlenir.
            zoom.Show(); //Zoom formu ekranda açılır.
        }
        private void button19_Click(object sender, EventArgs e)//Horizontal tuşuna basıldığında zoom formunun açılması için aşağıdaki komutlar uygulanır.
        {
            Horizontal horizantal = new Horizontal(); //Zoom formu tanıtılır.
            this.Hide();//Horizantal ekranda gizlenir.
            horizantal.Show();//Horizantal formu ekranda açılır.
        }
        private void button20_Click(object sender, EventArgs e)//Acquisition tuşuna basıldığında zoom formunun açılması için aşağıdaki komutlar uygulanır.
        {
            Acquisition acquisition = new Acquisition(); //Acquisition formu tanıtılır.
            acquisition.Show(); //Acquisition formu ekranda açılır.
            this.Hide();//Acquisition ekranda gizlenir.
        }
        private void button21_Click(object sender, EventArgs e)// Ch 1 tuşuna basıldığında zoom formunun açılması için aşağıdaki komutlar uygulanır.
        {
            counter1++;
            if (counter1 % 2 == 1)
            {
                button21.BackColor = Color.Yellow; //Ch1 tuşuna basıldığında tuş sarı yakılır.
                RTA4004_scope.VerticalSettings1(1,"ON");
            }
            else if (counter1 % 2 == 0)
            {
                button21.BackColor = SystemColors.Control;
                Ch1 ch1 = new Ch1(); //Ch1 formu tanıtılır.
                ch1.Show();//Ch1 formu ekranda açılır.
                this.Hide(); //Form1 formu ekranda gizlenir.
            }
        }
        private void button22_Click(object sender, EventArgs e)
        {
            counter2++;
            if (counter2 % 2 == 1)
            {
                button22.BackColor = Color.Green; //Ch2 tuşuna basıldığında tuş yeşil renkte yakılır.
                RTA4004_scope.VerticalSettings2(2, "ON");
            }
            else if (counter2 % 2 == 0)
            {
                button22.BackColor = SystemColors.Control; 
                Ch2 ch2 = new Ch2(); //Ch2 formu tanıtılır.
                ch2.Show();//Ch2 formu ekranda açılır.
                this.Hide(); //Form1 formu ekranda gizlenir.
            }
        }
        private void button23_Click(object sender, EventArgs e)
        {
            counter3++;
            if (counter3 % 2 == 1)
            {
                button23.BackColor = Color.Orange; //Ch3 tuşuna basıldığında tuş sarı renkte yakılır.
                RTA4004_scope.VerticalSettings3(3, "ON");
            }
            else if (counter3 % 2 == 0)
            {
                button23.BackColor = SystemColors.Control; 
                Ch3 ch3 = new Ch3(); //Ch3 formu tanıtılır.
                ch3.Show();//Ch3 formu ekranda açılır.
                this.Hide(); //Form1 formu ekranda gizlenir.
            }
        }
        private void button24_Click(object sender, EventArgs e)
        {
            counter4++;
            if (counter4 % 2 == 1)
            {
                button24.BackColor = Color.DeepSkyBlue; //Ch4 tuşuna basıldığında tuş mavi renkte yakılır.
                RTA4004_scope.VerticalSettings4(4, "ON");
            }
            else if (counter4 % 2 == 0)
            {
                button24.BackColor = SystemColors.Control; 
                Ch4 ch4 = new Ch4(); //Ch4 formu tanıtılır.
                ch4.Show();//Ch4 formu ekranda açılır.
                this.Hide(); //Form1 formu ekranda gizlenir.
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            RTA4004_scope.Display(" 35", " 45"); //Oscilloscope'un brightness menüsündeki Waveform ve Grid değerlerini 35 ve 45 'e ayarlayarak default değerlerine dönüştürülür.
            Brightness brightness = new Brightness(); //Brightness formunda bir değişken tanıtılır.
            brightness.Show(); //Brightness formu açılarak ekrana getirilir.
            this.Hide(); //Form1 ekrandan kapatılır.
        }
        private void button26_Click(object sender, EventArgs e)
        {
            Cursor cursor = new Cursor();//Cursor formunda bir değişken tanıtılır.
            cursor.Show(); //Cursor formu açılarak ekrana getirilir.
            this.Hide();//Form1 ekrandan kapatılır.
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Measure measure = new Measure();//Measure formunda bir değişken tanıtılır.
            measure.Show(); //Measure formu açılarak ekrana getirilir.
            this.Hide(); //Form1 ekrandan kapatılır.
        }
        private void button12_Click(object sender, EventArgs e)
        {
            QuickMeasure quickmeasure = new QuickMeasure(); //Quick Measure formunda bir değişken tanıtılır.
            quickmeasure.Show(); //Quick Measure formu açılarak ekrana getirilir.
            this.Hide(); //Form1 ekrandan kapatılır.
        }
        private void button15_Click(object sender, EventArgs e)
        {
            Protocol protocol = new Protocol(); //Protocol formunda bir değişken tanıtılır.
            protocol.Show(); //Protocol formu açılarak ekrana getirilir.
            this.Hide(); //Form1 ekrandan kapatılır.
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Generator generator = new Generator(); //Generator formunda bir değişken tanıtılır.
            generator.Show(); //Generator formu açılarak ekrana getirilir.
            this.Hide(); //Form1 ekrandan kapatılır.
        }
        private void button10_Click(object sender, EventArgs e)
        {
            FFT fft = new FFT(); //FFT formunda bir değişken tanıtılır.
            fft.Show(); //FFT formu açılarak ekrana getirilir.
            this.Hide(); //Form1 ekrandan kapatılır.
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (angle == 360) angle = 0; else angle += 10; //Kullanıcı tuşu her döndürğünde buton 10 derece döndürülerek 36 seçenekten ilgili Scale değeri atanır.
            pictureBox2.Image = imagerotate(image, angle);

            if (angle==0 || angle == 360)
            {
                RTA4004_scope.angle1();
                label8.Text = "100 us";
            }
            if (angle == 10)
            {
                RTA4004_scope.angle2();
                label8.Text = "50 us";
            }
            if (angle ==20)
            {
                RTA4004_scope.angle3();
                label8.Text = "20 us";
            }
            if (angle == 30)
            {
                RTA4004_scope.angle4();
                label8.Text = "10 us";
            }
            if (angle == 40)
            {
                RTA4004_scope.angle5();
                label8.Text = "5 us";
            }
            if (angle == 50)
            {
                RTA4004_scope.angle6();
                label8.Text = "2 us";
            }
            if (angle == 60)
            {
                RTA4004_scope.angle7();
                label8.Text = "1 us";
            }
            if (angle == 70)
            {
                RTA4004_scope.angle8();
                label8.Text = "500 ns";
            }
            if (angle == 80)
            {
                RTA4004_scope.angle9();
                label8.Text = "200 ns";
            }
            if (angle == 90)
            {
                RTA4004_scope.angle10();
                label8.Text = "80 ns";
            }
           
            if (angle == 100)
            {
                RTA4004_scope.angle12();
                label8.Text = "20 ns";
            }
            if (angle == 110)
            {
                RTA4004_scope.angle13();
                label8.Text = "10 ns";
            }
            if (angle == 120)
            {
                RTA4004_scope.angle14();
                label8.Text = "5 ns";
            }
            if (angle == 130)
            {
                RTA4004_scope.angle15();
                label8.Text = "2 ns";
            }
            if (angle == 140)
            {
                RTA4004_scope.angle16();
                label8.Text = "1 ns";
            }
            if (angle == 150)
            {
                RTA4004_scope.angle17();
                label8.Text = "500 ps";
            }
            if (angle == 160)
            {
                RTA4004_scope.angle18();
                label8.Text = "500 s";
            }
            if (angle == 170)
            {
                RTA4004_scope.angle19();
                label8.Text = "200 s";
            }
            if (angle == 180)
            {
                RTA4004_scope.angle20();
                label8.Text = "100 s";
            }
            if (angle == 190)
            {
                RTA4004_scope.angle21();
                label8.Text = "50 s";
            }
            if (angle == 200)
            {
                RTA4004_scope.angle22();
                label8.Text = "20 s";
            }
            if (angle == 210)
            {
                RTA4004_scope.angle23();
                label8.Text = "10 s";
            }
            if (angle == 220)
            {
                RTA4004_scope.angle24();
                label8.Text = "5 s";
            }
            if (angle == 230)
            {
                RTA4004_scope.angle25();
                label8.Text = "2 s";
            }
            if (angle == 240)
            {
                RTA4004_scope.angle26();
                label8.Text = "1 s";
            }
            if (angle == 250)
            {
                RTA4004_scope.angle27();
                label8.Text = "500 ms";
            }
            if (angle == 260)
            {
                RTA4004_scope.angle28();
                label8.Text = "200 ms";
            }
            if (angle == 270)
            {
                RTA4004_scope.angle29();
                label8.Text = "100 ms";
            }
            if (angle == 280)
            {
                RTA4004_scope.angle30();
                label8.Text = "50 ms";
            }
            if (angle == 290)
            {
                RTA4004_scope.angle31();
                label8.Text = "20 ms";
            }
            if (angle == 300)
            {
                RTA4004_scope.angle32();
                label8.Text = "10 ms";
            }
            if (angle == 310)
            {
                RTA4004_scope.angle33();
                label8.Text = "5 ms";
            }
            if (angle == 320)
            {
                RTA4004_scope.angle34();
                label8.Text = "2 ms";
            }
            if (angle == 330)
            {
                RTA4004_scope.angle35();
                label8.Text = "1 ms";
            }
            if (angle == 340)
            {
                RTA4004_scope.angle36();
                label8.Text = "500 us";
            }

            if (angle == 350)
            {
                RTA4004_scope.angle37();
                label8.Text = "200 us";
            }

        } 
        //Horizontal Scale tuşu döndürüldüğünde açı ayarlaması yapılarak ilgili scale değerlerine göre oscilloscope ekranı düzenlenir.
        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            
            if (angle2 == 360) angle2 = 0; else angle2 += 24; //Kullanıcı tuşu her döndürğünde buton 24 derece döndürülerek 15 seçenekten ilgili Vertical Scale değeri atanır.
            pictureBox3.Image = imagerotate(image, angle2);

            if (angle2 == 0 || angle2 == 360)
            {
                RTA4004_scope.verticalscale1(comboBox2.Text);
                label10.Text = "10 V";
            }
            if (angle2 == 24)
            {
                RTA4004_scope.verticalscale2(comboBox2.Text);
                label10.Text = "5 V";
            }
            if (angle2 == 48)
            {
                RTA4004_scope.verticalscale3(comboBox2.Text);
                label10.Text = "2 V";
            }
            if (angle2 == 72)
            {
                RTA4004_scope.verticalscale4(comboBox2.Text);
                label10.Text = "1 V";
            }
            if (angle2 == 96)
            {
                RTA4004_scope.verticalscale5(comboBox2.Text);
                label10.Text = "500 mV";
            }
            if (angle2 == 120)
            {
                RTA4004_scope.verticalscale6(comboBox2.Text);
                label10.Text = "200 mV";
            }
            if (angle2 == 144)
            {
                RTA4004_scope.verticalscale7(comboBox2.Text);
                label10.Text = "100 mV";
            }
            if (angle2 == 168)
            {
                RTA4004_scope.verticalscale8(comboBox2.Text);
                label10.Text = "50 mV";
            }
            if (angle2 == 192)
            {
                RTA4004_scope.verticalscale9(comboBox2.Text);
                label10.Text = "20 mV";
            }
            if (angle2 == 216)
            {
                RTA4004_scope.verticalscale10(comboBox2.Text);
                label10.Text = "10 mV";
            }
            if (angle2 == 240)
            {
                RTA4004_scope.verticalscale11(comboBox2.Text);
                label10.Text = "5 mV";
            }
            if (angle2 == 264)
            {
                RTA4004_scope.verticalscale12(comboBox2.Text);
                label10.Text = "2 mV";
            }
            if (angle2 == 288)
            {
                RTA4004_scope.verticalscale13(comboBox2.Text);
                label10.Text = "1 mV";
            }
            if (angle2 == 312)
            {
                RTA4004_scope.verticalscale14(comboBox2.Text);
                label10.Text = "750 uV";
            }
            if (angle2 == 336)
            {
                RTA4004_scope.verticalscale15(comboBox2.Text);
                label10.Text = "500 uV";
            }
        } 
        // Vertical Scale tuşu döndürüldüğünde açı ayarlaması yapılarak ilgili scale değerlerine göre oscilloscope ekranı düzenlenir.
        private void label16_Click(object sender, EventArgs e)
        {

        }
        private void button28_Click(object sender, EventArgs e)
        {
            ScreenShot screenshot = new ScreenShot();//Screenshot formunda bir değişken tanıtılır.
            screenshot.Show(); //Screenshot formu açılarak ekrana getirilir.
            this.Hide();//Form1 ekrandan kapatılır.
        }
        private void button11_Click(object sender, EventArgs e)
        {
            //Bilgisayarda önceden kayıtlı screenshot fotoğrafları arasından kullanıcının seçtiği dosyayı picturebox'a yazmak için kullanılan kodlar aşağıda verilmiştir.
            OpenFileDialog fil = new OpenFileDialog(); //Butona basıldığında screenshotların kayırlı olduğu dosyayı açarak kullanının istediği dosyayı seçmesi sağlanır.
            fil.ShowDialog(); //Tuşa bastıktan sonra klasörün açılması sağlanır.
            string path = fil.FileName.ToString(); //Screenshot'ların kayıtlı olduğu dosya konumu tanımlanır.
            pictureBox1.Image = Image.FromFile(path); //Seçilen screenshot'u picturebox üzerinde gösterilmesi sağlanır.
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
            if (angle3 == 360) angle3 = 0; else angle3 += 36; //Kullanıcı tuşu her döndürğünde buton 36 derece döndürülerek 10 seçenekten ilgili Vertical Scale değeri atanır.
            pictureBox5.Image = imagerotate(image, angle3);

            if (angle3 == 0 || angle3==360 )
            {
                RTA4004_scope.waveform1();
                label15.Text = "0 %";
            }
            if (angle3 == 36)
            {
                RTA4004_scope.waveform2();
                label15.Text = "10 %";
            }
            if (angle3 == 72)
            {
                RTA4004_scope.waveform3();
                label15.Text = "20 %";
            }
            if (angle3 == 108)
            {
                RTA4004_scope.waveform4();
                label15.Text = "30 %";
            }
            if (angle3 == 144)
            {
                RTA4004_scope.waveform5();
                label15.Text = "40 %";
            }
            if (angle3 == 180)
            {
                RTA4004_scope.waveform6();
                label15.Text = "50 %";
            }
            if (angle3 == 216)
            {
                RTA4004_scope.waveform7();
                label15.Text = "70 %";
            }
            if (angle3 == 252)
            {
                RTA4004_scope.waveform8();
                label15.Text = "80 %";
            }
            if (angle3 == 288)
            {
                RTA4004_scope.waveform9();
                label15.Text = "90 %";
            }
            if (angle3 == 324)
            {
                RTA4004_scope.waveform10();
                label15.Text = "100 %";
            }
        } 
        // Waveform tuşu döndürüldüğünde açı ayarlaması yapılarak ilgili scale değerlerine göre oscilloscope ekranı düzenlenir.
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
            if (angle1 == 360) angle1 = 0; else angle1 += 18; //Kullanıcı tuşu her döndürğünde buton 18 derece döndürülerek 20 seçenekten ilgili Vertical Scale değeri atanır.
            pictureBox4.Image = imagerotate(image, angle1);

            if (angle1== 0 || angle1 == 360)
            {
                RTA4004_scope.verticalposition1(comboBox1.Text);
                label11.Text = "0V";
            }
            if (angle1 == 18)
            {
                RTA4004_scope.verticalposition2(comboBox1.Text);
                label11.Text = "0.5V";
            }
            if (angle1 == 36)
            {
                RTA4004_scope.verticalposition3(comboBox1.Text);
                label11.Text = "1V";
            }
            if (angle1 == 54)
            {
                RTA4004_scope.verticalposition4(comboBox1.Text);
                label11.Text = "1.5V";
            }
            if (angle1 == 72)
            {
                RTA4004_scope.verticalposition5(comboBox1.Text);
                label11.Text = "2V";
            }
            if (angle1 == 90)
            {
                RTA4004_scope.verticalposition6(comboBox1.Text);
                label11.Text = "2.5V";
            }
            if (angle1 == 108)
            {
                RTA4004_scope.verticalposition7(comboBox1.Text);
                label11.Text = "3V";
            }
            if (angle1 == 126)
            {
                RTA4004_scope.verticalposition8(comboBox1.Text);
                label11.Text = "3.5V";
            }
            if (angle1 == 144)
            {
                RTA4004_scope.verticalposition9(comboBox1.Text);
                label11.Text = "4V";
            }
            if (angle1 == 162)
            {
                RTA4004_scope.verticalposition10(comboBox1.Text);
                label11.Text = "4.5V";
            }
            if (angle1 == 180)
            {
                RTA4004_scope.verticalposition11(comboBox1.Text);
                label11.Text = "5V";
            }
            if (angle1 == 198)
            {
                RTA4004_scope.verticalposition12(comboBox1.Text);
                label11.Text = "-5V";
            }
            if (angle1 == 216)
            {
                RTA4004_scope.verticalposition13(comboBox1.Text);
                label11.Text = "-4V";
            }
            if (angle1 == 234)
            {
                RTA4004_scope.verticalposition14(comboBox1.Text);
                label11.Text = "-3.5V";
            }
            if (angle1 == 252)
            {
                RTA4004_scope.verticalposition15(comboBox1.Text);
                label11.Text = "-3V";
            }
            if (angle1 == 270)
            {
                RTA4004_scope.verticalposition16(comboBox1.Text);
                label11.Text = "-2.5V";
            }
            if (angle1 == 288)
            {
                RTA4004_scope.verticalposition17(comboBox1.Text);
                label11.Text = "-2V";
            }
            if (angle1 == 306)
            {
                RTA4004_scope.verticalposition18(comboBox1.Text);
                label11.Text = "-1.5V";
            }
            if (angle1 == 324)
            {
                RTA4004_scope.verticalposition19(comboBox1.Text);
                label11.Text = "-1V";
            }
            if (angle1 == 342)
            {
                RTA4004_scope.verticalposition20(comboBox1.Text);
                label11.Text = "-0.5V";
            }
        } 
        // Vertical Position tuşu döndürüldüğünde açı ayarlaması yapılarak ilgili scale değerlerine göre oscilloscope ekranı düzenlenir.
        private Bitmap imagerotate(Bitmap eskiresim, float angle) //Kullanıcı üzerine tıkladığında dairesel butonların döndürülmesini sağlayan kodalar aşağıda verilmiştir.
        {
            Bitmap yeniResim = new Bitmap(eskiresim.Width, eskiresim.Height); //Resmin boyutu yeniResim değişkenine atanır.
            using (Graphics g = Graphics.FromImage(yeniResim)) //Resmin üzerinde ayar yapabilmek için Graphics eventi çağrılır.
            {
                g.TranslateTransform(eskiresim.Width / 2, eskiresim.Height / 2); //Resmin orta noktası bulunur.
                g.RotateTransform(angle); //Resmin o anki açısı berlirlenir.
                g.TranslateTransform(-eskiresim.Width / 2, -eskiresim.Height / 2); //Resmin tersinden orta nokta buluru.
                g.DrawImage(eskiresim, new Point(0, 0)); //Resm döndürme işleminin yaplacağı yere gönderilir.
            }
            return yeniResim; //Döndürülen resim fonksiyonun çağrıldığı kısma geri gönderilir.
        }
    }
}