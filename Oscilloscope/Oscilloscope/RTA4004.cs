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
namespace Oscilloscope
{
    public class RTA4004
    {
        public ScopeDriver RTA4004_scope;
        public bool Connected = false;
        private FormattedIO488Class inst;
        public RTA4004(string visaSrcName, bool reset = true)
        {
            RTA4004_scope = new ScopeDriver(visaSrcName);
            Connected = true;
        }
        public void Run() // Oscilloscope'a gönderilen Run komutunu oscilloscope tarafından uygulanması sağlanır.
        {
            RTA4004_scope.DoCommand("RUN");
        }
        public void Stop() // Oscilloscope'a gönderilen Stop komutunu oscilloscope tarafından uygulanması sağlanır.
        {
            RTA4004_scope.DoCommand("STOP");
        }
        public void Single() //Oscilloscope'a gönderilen Single komutunun oscilloscope tarafından uygulanması sağlanır.
        {
            RTA4004_scope.DoCommand("SINGle");
        }
        public void TriggerModeAuto() //Oscilloscope'a gönderilen TriggerMode komutunun oscilloscope tarafından uygulanarak AUTO şekline geçmesi sağlanır.
        {
            RTA4004_scope.DoCommand("TRIGger:A:MODE" + " AUTO");
        }
        public void TriggerModeNormal() //Oscilloscope'a gönderilen TriggerMode komutunun oscilloscope tarafından uygulanarak NORMAL şekline geçmesi sağlanır.
        {
            RTA4004_scope.DoCommand("TRIGger:A:MODE" + " NORMal");
        }
        public void ForceTrigger() //Oscilloscope'a gönderilen ForceTrigger komutunun oscilloscope tarafından uygulanması sağlanır.
        {
            RTA4004_scope.DoCommand("*TRG");
        }
        public void TriggerSourceCH1() //Oscilloscope'a gönderilen TriggerSource komutunun oscilloscope tarafından kaynağın CH1'e ayarlanması sağlanır.
        {
            RTA4004_scope.DoCommand("TRIGger:A:SOURce" + " CH1");
        }
        public void TriggerSourceCH2()  //Oscilloscope'a gönderilen TriggerSource komutunun oscilloscope tarafından kaynağın CH2'e ayarlanması sağlanır.
        {
            RTA4004_scope.DoCommand("TRIGger:A:SOURce" + " CH2");
        }
        public void TriggerModeSourceCH3()  //Oscilloscope'a gönderilen TriggerSource komutunun oscilloscope tarafından kaynağın CH3'e ayarlanması sağlanır.
        {
            RTA4004_scope.DoCommand("TRIGger:A:SOURce" + " CH3");
        }
        public void TriggerModeSourceCH4()  //Oscilloscope'a gönderilen TriggerSource komutunun oscilloscope tarafından kaynağın CH4'e ayarlanması sağlanır.
        {
            RTA4004_scope.DoCommand("TRIGger:A:SOURce" + " CH4");
        }
        public void Autoscale() //Oscilloscope'a gönderilen Autoscale komutunun oscilloscope tarafından AotuSet şeklinde ayarlanması sağlanır.
        {
            RTA4004_scope.DoCommand("AUToscale");
        }
        public void clearscreen() //Oscilloscope'a gönderilen ClearScreen komutunun oscilloscope tarafından ClearScreen şeklinde ayarlanması sağlanır.
        {
            RTA4004_scope.DoCommand("DISPlay:CLEar:SCReen");
        }
        public void Reset(int delay) //Oscilloscope'a gönderilen Reset komutunun oscilloscope tarafından Preset şeklinde ayarlanması sağlanır.
        {
            RTA4004_scope.DoCommand("*RST");
            System.Threading.Thread.Sleep(delay);
        }
        public void SetEdgeTrigger(string source, string slope, string channelnumber, string level, 
        string Hysteresis, string type, string Coupling, string HFReject, string NoiseReject)
        {
            //Trigger formundaki girdilerin oscilloscope'a gönderilmesini sağlayan kodlar aşağıda uygulanmaktadır.
            RTA4004_scope.DoCommand("TRIGger:A:SOURce " + source); // Trigger Source'a kullanıcının girdiği değer oscilloscope'da ayarlanır. 
            RTA4004_scope.DoCommand("TRIGger:A:EDGE:SLOPe " + slope); // Slope'a kullanıcının  seçimi scilloscope'da ayarlarnır. 
            RTA4004_scope.DoCommand("TRIGger:A:LEVel" + channelnumber + ":VALue " + level); // Trigger Threshold'a voltajı kullanıcının girdiği değer oscilloscope'da ayarlanır.
            RTA4004_scope.DoCommand("TRIGger:A:TYPE " + type); // Trigger Type'a kullanıcının seçimi oscilloscope'da ayarlanır..
            RTA4004_scope.DoCommand("TRIGger:A:HYSTeresis " + Hysteresis); // Hysteresis'e aralığı kullanıcının seçimine göre oscilloscope'da ayarlarnır.
            RTA4004_scope.DoCommand("TRIGger:A:EDGE:COUPling " + Coupling); // Coupling'deki kullanıcının seçimine göre oscilloscope ayarlanır.
            RTA4004_scope.DoCommand("TRIGger:A:EDGE:FILTer:HFReject " + HFReject); //HF Reject'e seçeneği açık veya kapalı olarak kullanıcının seçimine göre oscilloscope üzerinde ayarlarnır
            RTA4004_scope.DoCommand("TRIGger:A:EDGE:FILTer:NREJect " + NoiseReject); //Noise Reject'e seçeneği açık veya kapalı olarak kullanıcının seçimine göre oscilloscope üzerinde ayarlarnır.
        }
        public void Zoom(string zoom_state, string zoomscale, string position)
        {
            //Zoom formundaki girdilerin oscilloscope'a gönderilmesini sağlayan kodlar aşağıda uygulanmaktadır.
            RTA4004_scope.DoCommand("TIMebase:ZOOM:STATe " + zoom_state); //Zoom State'e kullanıcının girdiği değere göre oscilloscope ayarlanır.
            RTA4004_scope.DoCommand("TIMebase:ZOOM:SCALe " + zoomscale);//Zoom Scale'a kullanıcının girdiği değere göre oscilloscope ayarlanır.
            RTA4004_scope.DoCommand("TIMebase:ZOOM:POSition " + position); //Zoom Position'a kullanıcının girdiği değere göre oscilloscope ayarlanır.
        }
        public void HorizontalSettings(string reference_point, string time_scale, string position)
        {//Horizantal formundaki girdilerin oscilloscope'a gönderilmesini sağlayan kodlar aşağıda uygulanmaktadır.
            RTA4004_scope.DoCommand("TIMebase:REFerence " + reference_point); // Horizontal Reference Point'e girilen değere göre oscilloscpe ayarlanır. 
            RTA4004_scope.DoCommand("TIMebase:SCALe " + time_scale); // Horizontal Time Scale'a girilen değere göre oscilloscope ayarlanır.
            RTA4004_scope.DoCommand("TIMebase:POSition " + position); // Horizontal Position'a girilen değere göre oscilloscope ayarlanır.
        }
        public void AcquisitionSetting(string RecordLength, string channel, string acquireMode, string decimationMode, 
        string Nx_Single, string automatic, string MinRollTime, string interpolation_type, string AutoRecord)
        {
            //Acquisition formundaki girdilerin oscilloscope'a gönderilmesini sağlayan kodlar aşağıda uygulanmaktadır.
            RTA4004_scope.DoCommand("ACQuire:POINts:VALue " + RecordLength); // Acquisition Point Value'ya girilen değere göre oscilloscope ayarlanır.
            RTA4004_scope.DoCommand("CHANnel" + channel + ":ARIThmetics " + acquireMode); //Acquisition Channel'a girilen değere göre oscilloscope ayarlanır.
            RTA4004_scope.DoCommand("CHANnel" + channel + ":TYPE " + decimationMode); //Acquisition Channel'a girilen değere göre oscilloscope ayarlanır.
            RTA4004_scope.DoCommand("ACQuire:NSINgle:COUNt " + Nx_Single); ///Acquisition Channel'a girilen değere göre oscilloscope ayarlanır.
            RTA4004_scope.DoCommand(" TIMebase:ROLL:AUTomatic " + automatic); //Auto Roll tuşunu kullanıcının seçimine göre oscilloscope'a göndererek ON/OFF konumuna ayarlanmas sağlanır
            RTA4004_scope.DoCommand("TIMebase:ROLL:MTIMe " + MinRollTime);// Start Roll Time tuşuna girilen değere göre oscilloscope ayarlanır.
            RTA4004_scope.DoCommand("ACQuire:INTerpolate " + interpolation_type);//Interpolation'da seçilen seçeneğe göre oscilloscope ayarlanır.
            RTA4004_scope.DoCommand("ACQuire:POINts:AUTomatic " + AutoRecord); //Auto record özelliğini açıp kapatmak için kullanılır.
        }
        public void VerticalSettings(int channel, string channelstate, string vertical_scale, string position, 
        string offset_value, string Coupling, string BandwidthLimit, string polarity, string Skew, string ZeroOffset, string color, string Threshold, string ThresholdHysteresis)
        {   //Channel formlarındaki girdileri oscilloscope'a gönderilmesini sağlayan kodlar aşağıda uygulanmaktadır.
           
            RTA4004_scope.DoCommand("CHANnel" + channel.ToString() + ":SCALe " + vertical_scale); // Vertical Scale için girilen değere göre oscilloscope ayarlanır.
            RTA4004_scope.DoCommand("CHANnel" + channel.ToString() + ":STATe " + channelstate); // Channel State'i için ON/OFF seçimine göre oscilloscope ayarlalanır. 
            RTA4004_scope.DoCommand("CHANnel" + channel.ToString() + ":POSition " + position); // Vertical Position için girilen değere göre oscilloscope ayarlanır.
            RTA4004_scope.DoCommand("CHANnel" + channel.ToString() + ":OFFSet " + offset_value); // Vertical Offset için girilen değere göre oscilloscope ayarlanır.
            RTA4004_scope.DoCommand("CHANnel" + channel.ToString() + ":COUPling " + Coupling); //// Coupling için seçilen seçeneğe göre oscilloscope ayarlanır.
            RTA4004_scope.DoCommand("CHANnel" + channel.ToString() + ":BANDwidth " + BandwidthLimit); //Vertical Bandwidth için girilen değere göre oscilloscope ayarlanır.
            RTA4004_scope.DoCommand("CHANnel" + channel.ToString() + ":POLarity " + polarity); // Vertical Polarity için girilen değere göre oscilloscope ayarlanır. 
            RTA4004_scope.DoCommand("CHANnel" + channel.ToString() + ":SKEW " + Skew); // Delay için girilen değere göre oscilloscope ayarlanır.
            RTA4004_scope.DoCommand("CHANnel" + channel.ToString() + ":ZOFFset:VALue " + ZeroOffset); //Zero Offset için girilen değere göre oscilloscope ayarlanır.
            RTA4004_scope.DoCommand("CHANnel" + channel.ToString() + ":WCOLor " + color);  // Dalgaboyu ölçeklendirme rengi için seçilen seçeneğe göre oscilloscope ayarlanır.
            RTA4004_scope.DoCommand("CHANnel" + channel.ToString() + ":THReshold " + Threshold); // Threshold değeri için girilen değere göre oscilloscope ayarlanır.
            RTA4004_scope.DoCommand("CHANnel" + channel.ToString() + ":THReshold:HYSTeresis " + ThresholdHysteresis); // Hysteresis için girilen değere göre oscilloscope ayarlanır. 
        }
        public void VerticalSettings1(int channel, string channelstate)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel.ToString() + ":STATe " + channelstate); // Channel State'i için ON/OFF seçimine göre oscilloscope ayarlalanır. 
        }
        public void VerticalSettings2(int channel, string channelstate)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel.ToString() + ":STATe " + channelstate); // Channel State'i için ON/OFF seçimine göre oscilloscope ayarlalanır. 
        }
        public void VerticalSettings3(int channel, string channelstate)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel.ToString() + ":STATe " + channelstate); // Channel State'i için ON/OFF seçimine göre oscilloscope ayarlalanır. 
        }
        public void VerticalSettings4(int channel, string channelstate)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel.ToString() + ":STATe " + channelstate); // Channel State'i için ON/OFF seçimine göre oscilloscope ayarlalanır. 
        }
        public void Display(string grid, string intensity)
        { //Brightness formundaki girdileri oscilloscope'a gönderilmesini sağlayan kodlar aşağıda uygulanmaktadır.
            RTA4004_scope.DoCommand("DISPlay:INTensity:GRID " + grid); //// Grid için girilen değere göre oscilloscope ayarlanır.
            RTA4004_scope.DoCommand("DISPlay:INTensity:WAVeform " + intensity); // Waveform için girilen değere göre oscilloscope ayarlanır.
        }
        public void CursorMeasurement(string state, string type, string source, string secondsourcestate, string secondsource, 
        string X1Position, string X2Position, string Y1Position, string Y2Position, out double X_delta_t, out double inverse_time, out double Y_delta_t, out double Y_delta_slope)
        {
            //Cursor formundaki girdileri oscilloscope'a gönderilmesini sağlayan kodlar aşağıda uygulanmaktadır.
            RTA4004_scope.DoCommand("CURSor1:STATe " + state); // State için ON/OFF seçimine göre oscilloscope ayarlanır. 
            RTA4004_scope.DoCommand("CURSor1:FUNCtion " + type); // Type için Vertical/Horizontal/Vertical&Horizantal/V-Marker seçimlerine göre oscilloscope ayarlanır. 
            RTA4004_scope.DoCommand("CURSor1:SOURce " + source); // Source için CH? seçimine göre oscilloscope ayarlanır. 
            RTA4004_scope.DoCommand("CURSor1:USSOURce " + secondsourcestate); // İkinci Channel State'i için ON/OFF seçimine göre oscilloscope ayarlalanır. 
            RTA4004_scope.DoCommand("CURSor1:SSOURce " + secondsource); // İkinci Source için CH? seçimine göre oscilloscope ayarlanır. 
            RTA4004_scope.DoCommand("CURSor1:X1Position " + X1Position); //Birinci kaynağın X pozisyon seçimine göre oscilloscope ayarlanır.
            RTA4004_scope.DoCommand("CURSor1:X2Position " + X2Position); //İkinci kaynağın X pozisyon seçimine göre oscilloscope ayarlanır.
            RTA4004_scope.DoCommand("CURSor1:Y1Position " + Y1Position); //Birinci kaynağın Y pozisyon seçimine göre oscilloscope ayarlanır.
            RTA4004_scope.DoCommand("CURSor1:Y2Position " + Y2Position); //İkinci kaynağın Y pozisyon seçimine göre oscilloscope ayarlanır.
            //Kullanıcının girdiği verilerin sonuçlarını oscilloscope'dan alarak aşağıdaki değişkenlere aktarılır..
            X_delta_t = RTA4004_scope.DoQueryNumber("CURSor1:XDELta:VALue?", 2000);
            inverse_time = RTA4004_scope.DoQueryNumber("CURSor1:XDELta:INVerse?", 2000);
            Y_delta_t = RTA4004_scope.DoQueryNumber("CURSor1:YDELta:VALue?", 2000);
            Y_delta_slope = RTA4004_scope.DoQueryNumber("CURSor1:YDELta:SLOPe?", 2000);
        }
        public void measurement(string measure_place, string measure_type, string measure_state, string source, out double result)
        {
            RTA4004_scope.DoCommand("MEASurement" + measure_place + ":ENABle " + measure_state); // Ölçme özelliği aktive ve deaktive  edilerek seçilen bilgi oscilloscope'a gönderilir.
            RTA4004_scope.DoCommand("MEASurement" + measure_place + ":MAIN " + measure_type); // Ölçüm tipi  kullanıcı tarafından seçilerek oscilloscope'a gönderilir.
            RTA4004_scope.DoCommand("MEASurement" + measure_place + ":SOURce " + source);  // Ölçüm Kaynağı seçilerek oscilloscope'a gönderilir.
            result = RTA4004_scope.DoQueryNumber("MEASurement" + measure_place + ":RESult:ACTual?" + measure_type, 2000); 
            //Oscilloscope'da hesaplanan değerleri formdaki değişkenlere aktarılması sağlanır.
        }
        //Oscilloscope'da hesaplanan değerlerin değişkenilere yeniden aktarılması için out double şeklinde değişkenler tanımlanarak, ilgili işlemler aşağıdaki şekilde yapılır.
        public void Quick_Measurement(out double Vpp, out double VpPos, out double VpNeg, out double RMS, out double MeanCyc, 
        out double Period, out double Freq, out double RTIM, out double FTIM)
        {
            const int conversion = 1000000; // Dönüştürme değeri bu şekilde tanımlanmıştır.
            string result; //Sonuç değişkeni tanımlanır.
            RTA4004_scope.DoCommand("MEASurement:AON"); // Quick Measurement özelliği aktif edilir..
            result = RTA4004_scope.DoQueryString("MEASurement:ARESult?", 3000); // Quick Measurement değerleri string şekilde result değişkenine ',' işareti ile ayrılarak yazdırılır..
            double[] split = result.Split(',').Select(double.Parse).ToArray(); 
            // Sonuçların yazıldığı result değişkenindeki değerler ',' işaretinden sonra ayrılarak split aray'inin indexlerine yazdırılır.
            //Split arayindeki  indexler sırayla sonuç değişkenlerine yazdırılır.
            Vpp = split[0] / conversion;
            VpPos = split[1] / conversion;
            VpNeg = split[2] / conversion;
            RMS = split[3] / conversion;
            MeanCyc = split[4] / conversion;
            Period = split[5] / conversion;
            Freq = split[6] / conversion;
            RTIM = split[7] / conversion;
            FTIM = split[8] / conversion;
        }
        public void Generator(string outputEnable, string function, string amplitude, string offset, string freq, string noise)
        {
            //Generator formundaki girdileri oscilloscope'a gönderilmesini sağlayan kodlar aşağıda uygulanmaktadır.
            RTA4004_scope.DoCommand("WGEN:OUTP " + outputEnable); // Output etkinleştirilir.
            RTA4004_scope.DoCommand("WGENerator:FUNCtion " + function); // Oluşturulacak generator fonksiyonu seçilir.
            RTA4004_scope.DoCommand("WGENerator:VOLTage " + amplitude); //Seçilen generatot fonksiyona göre amplitude tanımlanır.
            RTA4004_scope.DoCommand("WGENerator:VOLTage:OFFSet " + offset); //Seçilen fonksiyona göre DC offset ayarlanır.
            RTA4004_scope.DoCommand("WGENerator:FREQuency " + freq); // Frekans tanımlanır.
            RTA4004_scope.DoCommand("WGENerator:NOISe:RELative " + noise); //Noise tanımlanır.
        }
        public void Protocol(string bus, string bustype, string decode, string format, string bitssignalstate, string labelstate)
        {
            //Protocol formundaki girdileri oscilloscope'a gönderilmesini sağlayan kodlar aşağıda uygulanmaktadır.
            RTA4004_scope.DoCommand("BUS" + bus); //Bus sayısı seçilir.
            RTA4004_scope.DoCommand("BUS" + bus + ":TYPE " + bustype); //Bus sayısına göre bus türü seçilir.
            RTA4004_scope.DoCommand("BUS" + bus + ":STATe " + decode); //Bus sayısına göre decode açılıp/kapatılır.
            RTA4004_scope.DoCommand("BUS" + bus + ":FORMat " + format); //Bus sayısına göre format ayarlanır.
            RTA4004_scope.DoCommand("BUS" + bus + ":DSIGnals " + bitssignalstate); //Bus sayısına göre display setup türü ayarlanır.
            RTA4004_scope.DoCommand("BUS" + bus + ":LABel:STATe " + labelstate); //Bus sayısına göre label state ayarlanır.
        }
        public void fft(string source, string type, string vertical, string spectogram, string auto, string peaklist, string marker, string average, string spectrum, string max, string min)
        {
            //FFT formundaki girdileri oscilloscope'a gönderilmesini sağlayan kodlar aşağıda uygulanmaktadır.
            RTA4004_scope.DoCommand("SPECtrum:SOURce " + source); //Kaynak ayarlanır.
            RTA4004_scope.DoCommand("SPECtrum:FREQuency:WINDow:TYPE " + type); //FFT türü ayarlanır.
            RTA4004_scope.DoCommand("SPECtrum:FREQuency:MAGNitude:SCALe " + vertical); //Vertical scale birimi seçilir.
            RTA4004_scope.DoCommand("SPECtrum:DIAGram:SPECtrogram:ENABle " + spectogram); // Spectogram açılıp/kapatılır.
            RTA4004_scope.DoCommand("SPECtrum:FREQuency:BANDwidth:RESolution:AUTO " + auto); //Otomatik RBW açılıp/kapatılır.
            RTA4004_scope.DoCommand("SPECtrum:MARKer:ENABle " + peaklist); //Peaklist açılıp/kapatılır.
            RTA4004_scope.DoCommand("SPECtrum:MARKer:SOURce " + marker); //Peaklist açıldığında, marker özellikleri ayarlanır.
            RTA4004_scope.DoCommand("SPECtrum:WAVeform:AVERage:ENABle " + average); //Average açılıp/kapatılır.
            RTA4004_scope.DoCommand("SPECtrum:WAVeform:MAXimum:ENABle " + spectrum); //Spectrum açılıp/kapatılır.
            RTA4004_scope.DoCommand("SPECtrum:WAVeform:MINimum:ENABle " + max); //Max açılıp/kapatılır.
            RTA4004_scope.DoCommand("SPECtrum:WAVeform:SPECtrum:ENABle " + min); //Minimum açılıp/kapatılır.
        }
        //Horizontal Scale tuşu döndürüldüğünde oscilloscope'un ayarlanması sağlanan kodlar aşağıda verilmiştir.
        //Horizontal Scale Region'a aşağıdadır.
        #region
        public void angle1()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.0001"); 
        }
        public void angle2()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.00005");
        }
        public void angle3()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.00002");
        }
        public void angle4()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.00001");
        }
        public void angle5()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.000005");
        }
        public void angle6()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.000002");
        }
        public void angle7()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.000001");
        }
        public void angle8()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.0000005");
        }
        public void angle9()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.0000002");
        }
        public void angle10()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.00000008");
        }
        public void angle12()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.00000002");
        }
        public void angle13()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.00000001");
        }
        public void angle14()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.000000005");
        }
        public void angle15()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.000000002");
        }
        public void angle16()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.000000001");
        }
        public void angle17()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.0000000005");
        }
        public void angle18()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 500");
        }
        public void angle19()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 200");
        }
        public void angle20()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 100");
        }
        public void angle21()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 50");
        }
        public void angle22()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 20");
        }
        public void angle23()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 10");
        }
        public void angle24()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 5");
        }
        public void angle25()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 2");
        }
        public void angle26()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 1");
        }

        public void angle27()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.5");
        }
        public void angle28()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.2");
        }
        public void angle29()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.1");
        }
        public void angle30()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.05");
        }
        public void angle31()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.02");
        }
        public void angle32()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.01");
        }
        public void angle33()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.005");
        }
        public void angle34()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.002");
        }
        public void angle35()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.001");
        }
        public void angle36()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.0005");
        }
        public void angle37()
        {
            RTA4004_scope.DoCommand("TIMebase:SCALe 0.0002");
        }
        #endregion

        //Vertical Position tuşu döndürüldüğünde oscilloscope'un ayarlanması sağlanan kodlar aşağıda verilmiştir.
        //Vertical Position Region'ı aşağıdadır.
        #region
        public void verticalposition1(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":POSition 0");
        }
        public void verticalposition2(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":POSition 0.5");
        }
        public void verticalposition3(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":POSition 1");
        }
        public void verticalposition4(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":POSition 1.5");
        }
        public void verticalposition5(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":POSition 2");
        }
        public void verticalposition6(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":POSition 2.5");
        }
        public void verticalposition7(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":POSition 3");
        }
        public void verticalposition8(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":POSition 3.5");
        }
        public void verticalposition9(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":POSition 4");
        }
        public void verticalposition10(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":POSition 4.5");
        }
        public void verticalposition11(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":POSition 5");
        }
        public void verticalposition12(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":POSition -5");
        }
        public void verticalposition13(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":POSition -4");
        }
        public void verticalposition14(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":POSition -3.5");
        }
        public void verticalposition15(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":POSition -3");
        }
        public void verticalposition16(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":POSition -2.5");
        }
        public void verticalposition17(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":POSition -2");
        }
        public void verticalposition18(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":POSition -1.5");
        }
        public void verticalposition19(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":POSition -1");
        }
        public void verticalposition20(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":POSition -0.5");
        }
        #endregion

        //Vertical Scale tuşu döndürüldüğünde oscilloscope'un ayarlanması sağlanan kodlar aşağıda verilmiştir.
        //Vertical Scale Region'ı aşağıdadır.
        #region
        public void verticalscale1(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":SCALe 10");
        }
        public void verticalscale2(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":SCALe 5");
        }
        public void verticalscale3(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":SCALe 2");
        }
        public void verticalscale4(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":SCALe 1");
        }
        public void verticalscale5(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":SCALe 0.5");
        }
        public void verticalscale6(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":SCALe 0.2");
        }
        public void verticalscale7(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":SCALe 0.1");
        }
        public void verticalscale8(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":SCALe 0.05");
        }
        public void verticalscale9(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":SCALe 0.02");
        }
        public void verticalscale10(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":SCALe 0.01");
        }
        public void verticalscale11(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":SCALe 0.005");
        }
        public void verticalscale12(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":SCALe 0.002");
        }
        public void verticalscale13(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":SCALe 0.001");
        }
        public void verticalscale14(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":SCALe 0.00075");
        }
        public void verticalscale15(string channel)
        {
            RTA4004_scope.DoCommand("CHANnel" + channel + ":SCALe 0.0005");
        }
        #endregion

        //Waveform tuşu döndürüldüğünde oscilloscope'un ayarlanması sağlanan kodlar aşağıda verilmiştir.
        //Waveform Region'ı aşağıdadır.
        #region
        public void waveform1()
        {
            RTA4004_scope.DoCommand("DISPlay:INTensity:WAVeform 0"); // Waveform için girilen değere göre oscilloscope ayarlanır.
        }
        public void waveform2()
        {
            RTA4004_scope.DoCommand("DISPlay:INTensity:WAVeform 10"); // Waveform için girilen değere göre oscilloscope ayarlanır.
        }
        public void waveform3()
        {
            RTA4004_scope.DoCommand("DISPlay:INTensity:WAVeform 20"); // Waveform için girilen değere göre oscilloscope ayarlanır.
        }
        public void waveform4()
        {
            RTA4004_scope.DoCommand("DISPlay:INTensity:WAVeform 30"); // Waveform için girilen değere göre oscilloscope ayarlanır.
        }
        public void waveform5()
        {
            RTA4004_scope.DoCommand("DISPlay:INTensity:WAVeform 40"); // Waveform için girilen değere göre oscilloscope ayarlanır.
        }
        public void waveform6()
        {
            RTA4004_scope.DoCommand("DISPlay:INTensity:WAVeform 50"); // Waveform için girilen değere göre oscilloscope ayarlanır.
        }
        public void waveform7()
        {
            RTA4004_scope.DoCommand("DISPlay:INTensity:WAVeform 70"); // Waveform için girilen değere göre oscilloscope ayarlanır.
        }
        public void waveform8()
        {
            RTA4004_scope.DoCommand("DISPlay:INTensity:WAVeform 80"); // Waveform için girilen değere göre oscilloscope ayarlanır.
        }
        public void waveform9()
        {
            RTA4004_scope.DoCommand("DISPlay:INTensity:WAVeform 90"); // Waveform için girilen değere göre oscilloscope ayarlanır.
        }
        public void waveform10()
        {
            RTA4004_scope.DoCommand("DISPlay:INTensity:WAVeform 100"); // Waveform için girilen değere göre oscilloscope ayarlanır.
        }
        #endregion

        public void screenshot(string state, string color)
        {
            byte[] ResultsArray;  // Sonuçların tutulacağı array tanıtılır.
            int nLength;   //Oscilloscope'dan gelen byte numarasını tutan değişken tanıtılır.
            FileStream fStream; //Dosyaları kaydedebilmek için tanıtılan değişkendir.
            FileStream fileStream; //Dosyaları kaydedebilmek için tanıtılan değişkendir.
            DateTime tarih = DateTime.Now;  //Sistemin o andaki tarih, saat bilgilerini alarak tarih değişkenine atılır.
            string tarih1 = tarih.ToString("hh.mm.ss dd/MM/yyyy"); 
            //Tarih değişkeninde tutulan zaman ve tarih bilgilerini string'e dönüştürülerek tarih1 değişkenine atılır.
            //Bunun nedeni screenshot dosyaları oluşturulurken kullanıcının aldığı zamanı,tarihi string şekilde yazmaktır.
            string pathfile = string.Format(@"D:\staj\Hasan Ağaçayak\Oscilloscope\Oscilloscope\ScreenShot1\uptodate.png"); 
            //Screenshot Formunda anlık olarak ekran görüntüsü aldığımız dosyayı attığımız konumdur.
            string pathfile2= string.Format(@"D:\staj\Hasan Ağaçayak\Oscilloscope\Oscilloscope\ScreenShot2\{0}.png", tarih1);
            //Form1'de önceden alınan screenshotların kayıtlı olduğu dosyaya erişerek onları açmak için kullanılan konumdur. 
            RTA4004_scope.DoCommand("HCOPy:IMMediate"+ state); //Oscilloscope'a screenshot komutunu açar.
            RTA4004_scope.DoCommand("HCOPy:COLor:SCHeme " + color); //Screenshot'ın rengini belirleyerek bu şekilde screeshot alınması sağlanır.
            RTA4004_scope.opc(); //Komutların bittiği oscilloscope'a iletilir.
            ResultsArray = RTA4004_scope.DoQueryIEEEBlock("HCOPy:DATA?", 2500); //Screenshot verilerini tutacak array oluşturulur.
            nLength = ResultsArray.Length; //Screenshot'ın pixellerini tutan ResultsArray'in uzunluğunu alarak nLength değişkenine atılır.
            fStream = File.Open(pathfile, FileMode.Create); 
            //Screenshot kaydediliği konumu alarak, bu konuma oscilloscope'dan alınan screenshot verilerini alarak fStream değişkenine atanır.
            fileStream = File.Open(pathfile2, FileMode.Create);
            //Screenshot kaydediliği konumu alarak, bu konuma oscilloscope'dan alınan screenshot verilerini alarak fStream değişkenine atanır.
            //Verileri string olarak  png dosyasına olarak aşağıdaki şekilde yazılır
            fStream.Write(ResultsArray, 0, nLength);
            fStream.Close();
            fileStream.Write(ResultsArray, 0, nLength);
            fileStream.Close();
        }
    }
}