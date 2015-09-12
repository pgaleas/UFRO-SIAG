using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class BarcodeDataObject
    {
        public string ReaderSerial { get; set; }
        public string BarType { get; set; }
        public string BarData { get; set; }
        public string Rut { get; set; }
        public string StudentName { get; set; }
        public string ResponseFormId { get; set; }


        public BarcodeDataObject()
        {
            ReaderSerial = "";
            BarType = "";
            BarData = "";
            Rut = "";
            StudentName = "";
            ResponseFormId = "";
        }

    }

}
