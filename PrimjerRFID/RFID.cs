using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace PrimjerRFID
{
    public class RFID
    {
        private static Baza konekcija=new Baza(); 

        public RFID()
        {
            SerialPort mySerialPort = new SerialPort("COM3");

            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;

            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            
            mySerialPort.Open();

        }

        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;

            string brojKartice = sp.ReadLine(); // sp.ReadExisting();

            Dogadjaj dogadjaj = new Dogadjaj();

            if (!string.IsNullOrEmpty(brojKartice)) {
                DateTime datumVrijeme = DateTime.Now;
                dogadjaj.DatumVrijemeDogadjaja = datumVrijeme;
                var UposlenikId=GetUposlenikIdByBrojKartice(brojKartice);

                if (UposlenikId > 0)
                {
                    dogadjaj.UposlenikId = UposlenikId;
                    konekcija.Dogadjaji.Add(dogadjaj);
                    konekcija.SaveChanges();
                }
            }
           

        }

        private static int GetUposlenikIdByBrojKartice (string brojKartice){

            var ocisceniBrojKartice = Regex.Replace(brojKartice, "[^0-9a-zA-Z]+", "");

            var uposlenik = konekcija.Uposlenici.Where(u => u.Kartica == ocisceniBrojKartice).FirstOrDefault();

            if (uposlenik != null)
            {
                return uposlenik.Id;
            }
            else return 0;
        }
    }
}
