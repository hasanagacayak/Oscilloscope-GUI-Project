using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Only using the general Ivi Assemblies, no manufacturer-specific reference is used.
// This allows for the code to be interchangeable.
using Ivi.Driver;
using Ivi.Scope;
using Ivi.Visa.Interop;
using System.Runtime.InteropServices;
namespace Oscilloscope
{
    public class ScopeDriver
    {
        private ResourceManagerClass rm;
        private FormattedIO488Class inst;
        public static string message;
        public ScopeDriver(string visaSrcName)
        {
            rm = new ResourceManagerClass();
            inst = new FormattedIO488Class();
            inst.IO = (IMessage)rm.Open(visaSrcName, AccessMode.NO_LOCK, 0, string.Empty);
            inst.WriteString("*IDN?", true);  //Oscilloscope'un kimliği kontrol edilir. 
            message = inst.ReadString(); //Oscciloscope'un kimliği message değişkenine okutulur.
        }
        public void DoCommand(string command) // Bu fonksiyon içerisine yazılan komutların, oscilloscope'ta uygulanması sağlanır.
        {
            inst.WriteString(command, true); // String şekilde Command yerine yazılan komutlar osliloskopa yaptırılır.
        }
        public double DoQueryNumber(string query, int delay)
        {
            double result;
            DoCommand(query);
            System.Threading.Thread.Sleep(delay); // Okumadan önceki bekleme süresi ayarlanır.
            result = (double)inst.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
            return result; //Sonuçların yazıldığı array foknsiyonun çağrıldığı yere döndürülür.
        }
        public string DoQueryString(string query, int delay)
        {
            string message = string.Empty;
            try
            {
                DoCommand(query);
                System.Threading.Thread.Sleep(delay); // Okumadan önceki bekleme süresi ayarlanır.
                message = inst.ReadString(); //Oscilloscope'da hesaplanan değerler message değişkenine kopyalanır.
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                string msg = String.Format("{0} {1}", e.Message, "0x" + Convert.ToString(e.ErrorCode, 16));
                System.Diagnostics.Debug.WriteLine(msg);
            }
            return message;
        }
        public void opc()
        {
            DoCommand("*OPC"); //İşlemin bitirldiği oscilloscope'a bildirilir.
        }
        public byte[] DoQueryIEEEBlock(string query, int delay)
        {
            byte[] resultsArray = null; //byte'lardan oluşan bir array tanımlanır.
            DoCommand(query);
            // Sounçlar array'e yazılır. 
            System.Threading.Thread.Sleep(delay); // Okumadan önceki bekleme süresi ayarlanır.
            resultsArray = (byte[])inst.ReadIEEEBlock(IEEEBinaryType.BinaryType_UI1);
            return resultsArray; //Sonuçların yazıldığı array foknsiyonun çağrıldığı yere döndürülür.
        }
    }
}