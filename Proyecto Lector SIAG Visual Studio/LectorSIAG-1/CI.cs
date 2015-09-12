using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web;
using System.Collections.Specialized;

namespace WindowsFormsApplication1
{
    class CI_Code
    {
        public string BarcodeString { get; set; }
        public string BarcodeType { get; set; }
        public string Rut { get; set; }
        public string Name { get; set; }
        public bool RutError = false;

        public CI_Code(string barcodeString, string barcodeType)
        {
            BarcodeString = barcodeString;
            BarcodeType = barcodeType;
            parseRut();
        }

        /** Parse the rut string (generic) */
        private bool parseRut()
        {
            //Si el string corresponde al carnet antiguo
            if (BarcodeType == "17")
            {
                //Si el rut es de 8 digitos (18.356.421)
                if (parseRut8() == true)
                    return true;
                //Si el rut es de 7 digitos (8.356.421)
                else if (parseRut7() == true)
                    return true;
                else
                {
                    RutError = true;
                    return false;
                }
            }
                //Si el string corresponde al carnet nuevo
            else if (BarcodeType == "0")
            {
                //Si el codigo leido es de un QR de un carnet nuevo
                if (parseRutQR() == true)
                    return true;
                else
                {
                    RutError = true;
                    return false;
                }
            }
            else
            {
                RutError = true;
                return false;
            }


        }

        //Obtiene el rut a traves del QR
        private bool parseRutQR()
        {
            //Obtiene el rut
            string rutTemp = getRutFromURL(BarcodeString);

            //Separa el rut en dos elementos, dividiendolos en el guión
            string[] rutArray = rutTemp.Split('-');
            //Copia el rut antes del guión
            string rut = rutArray[0];
            //Copia el digito verificados
            string verificationcode = rutArray[1];
            //Revisa si el rut y digito corresponden
            if (rutIsOk(rut, verificationcode))
            {
                //Junta el rut y el digito en un solo String
                Rut = rutTemp.Replace("-", "");
                Name = "";
                return true;
            }
            else
                return false;
        }



        //Busca el rut a traves de un QR escaneado, en el URL que entrega

        private string getRutFromURL(string url)
        {
            Uri tmp = new Uri(url);
            //Copia la consulta que hace el url en la variable Parms
            NameValueCollection Parms = HttpUtility.ParseQueryString(tmp.Query);
            //Busca el campo RUN, y retorna el valor de ese campo
            foreach (string x in Parms.AllKeys) if (x == "RUN") return Parms[x];
            return "";
        }


        /** Parse the Rut string with 8 characters */
        private bool parseRut8()
        {
            //Divide el string según null char
            string[] trunkedBarcode = BarcodeString.Split('\0');
            //Divide el string generado según espacios
            string[] personData = trunkedBarcode[0].Split(' ');

            string rut_requestnr, name;
            //Si la data tiene datos, copia el rut ubicado en [0]
            if (personData.Length > 0) rut_requestnr = personData[0].Trim();
            else return false;
            //Si contiene mas de un dato, copia el apellido ubicado en [1]
            if (personData.Length > 1) name = personData[1].Trim();
            else name = "";

            //Si el rut contiene 9 digitos incluido el digito verificador
            if (rut_requestnr.Length >= 9)
            {
                //Copia el rut con digito verificador
                string rut_with_verification = rut_requestnr.Substring(0, 9);
                //Copia el rut sin digito verificador
                string rut = rut_with_verification.Substring(0, 8);
                //Copia el digito verificador
                string verificationcode = rut_with_verification.Substring(8, 1);
                //Si el rut es correcto
                if (rutIsOk(rut, verificationcode))
                {
                    //Copia el rut con digito verificador y el nombre
                    Rut = rut_with_verification;
                    Name = name;
                    return true;
                }
                else
                    return false;

            }
            else
            {
                return false;
            }

        }

        /** Parse the Rut string with 7 characters */
        private bool parseRut7()
        {
            //Divide el string según null char
            string[] trunkedBarcode = BarcodeString.Split('\0');
            //Divide el string generado según espacios
            string[] personData = trunkedBarcode[0].Split(' ');

            string rut_requestnr, name;
            //Si la data tiene datos, copia el rut ubicado en [0]
            if (personData.Length > 0)
            {
                rut_requestnr = personData[0].Trim();
            }
            else return false;
            //Si la data tiene mas de 1 dato, copia el apellido ubicado en [1]
            if (personData.Length > 1)
            {
                name = personData[1].Trim();
            }
            else name = "";
            //Si el rut contiene 8 digitos incluido el digito verificador
            if (rut_requestnr.Length >= 8)
            {
                //Copia el rut con digito verificador
                string rut_with_verification = rut_requestnr.Substring(0, 8);
                //Copia el rut sin digito verificador
                string rut = rut_with_verification.Substring(0, 7);
                //Copia el digito verificador
                string verificationcode = rut_with_verification.Substring(7, 1);
                //Revisa si el rut esta bien
                if (rutIsOk(rut, verificationcode))
                {
                    //Copia el rut y el apellido
                    Rut = rut_with_verification;
                    Name = name;
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return false;
            }


        }

        /** Check string the Rut with its correspnding verification character
         reference : http://users.dcc.uchile.cl/~mortega/microcodigos/validarrut/algoritmo.html
         */
        private bool rutIsOk(string rut, string verificationcode)
        {

            int suma = 0;
            int j = 0;
            int[] multVector = { 2, 3, 4, 5, 6, 7, 2, 3, 4, 5, 6, 7 };
            int result;
            char[] rutArray = rut.ToCharArray();



            for (int i = rut.Length - 1; i >= 0; i--)
            {

                if (!int.TryParse(rutArray[i].ToString(), out result)) return false;

                int dRut = Convert.ToInt16(rutArray[i].ToString());
                int dVector = multVector[j];
                suma += dRut * dVector;
                j++;
            }

            int calculated_verificationcode = 11 - (suma % 11);

            if (calculated_verificationcode == 10)
                if (verificationcode.ToUpper() == "K") return true;
                else return false;
            else if (calculated_verificationcode == 11 && Convert.ToInt32(verificationcode) == 0) return true;
            else if (calculated_verificationcode == Convert.ToInt32(verificationcode)) return true;
            else return false;

        }

    }

}
