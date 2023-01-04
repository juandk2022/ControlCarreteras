using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;


namespace ControlCarreteras.Callouts
{
    internal class speecher
    {
        SpeechSynthesizer sp = new SpeechSynthesizer();
        string estado_ubicacion = "";
        string estado_situacion = "";
        string estados = "";

        public void info_callout(String texto) {
            if (texto != "") {
                sp.SpeakAsync(texto);
            }
        }


        public void info_callout_aviso(String Indicativo, String descripcion, String localizacion, String pk, int ubicacion_vehiculos, int situacion)
        {
            if (Indicativo == null) { Indicativo = "100"; }
            if (descripcion == null) { descripcion = ""; }
            if (localizacion == null) { localizacion = ""; }
            if (pk == null) { pk = ""; }
            if (ubicacion_vehiculos == null) { ubicacion_vehiculos= 1; }
            if (situacion == null) { situacion = 1; }

            switch (ubicacion_vehiculos) {
                case 1:
                    estado_ubicacion = "SE DESCONOCE EL ESTADO DE UBICACION DE LOS VEHICULOS";
                    break;
                case 2:
                    estado_ubicacion = "LOS VEHICULOS SE ENCUENTRAN APARTADOS EN UN LUGAR SEGURO";
                    break;
                case 3:
                    estado_ubicacion = "LOS VEHICULOS SE ENCUENTRAN EN UNA ZONA DE ALTO RIESGO";
                    break;
                default:
                    estado_ubicacion = "";
                    break;
            }

            switch (situacion)
            {
                case 1:
                    estado_situacion = "SE DESCONOCE EL ESTADO DE LAS PERSONAS IMPLICADAS";
                    break;
                case 2:
                    estado_situacion = "SE SOLICITA ASISTENCIA MEDICA PARA ATENDER A LOS IMPLICADOS";
                    break;
                case 3:
                    estado_situacion = "SE SOLICITA BOMBEROS PARA ATENDER A LOS IMPLICADOS";
                    break;
                default:
                    estado_situacion = "";
                    break;
            }

            if (estado_situacion == "" && estado_ubicacion == "") { estados = "EL REQUIRIENTE NO HA ESPECIFICADO MAS INFORMACION";}
            if (estado_situacion == "" || estado_ubicacion == "") { estados = "SEGUN INDICA EL REQUIRIENTE ,"+ estado_ubicacion + ", "+ estado_situacion + " "; }

            sp.SpeakAsync("DE COTA PARA "+Indicativo+", INFORMAN DEL SIGUIENTE INCIDENTE, "+descripcion+", EN "+localizacion+", PK "+pk+", "+ estados + "");


        }
    }
}
