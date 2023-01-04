using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using LSPD_First_Response.Mod.API;
using LSPD_First_Response.Mod.Callouts;

namespace ControlCarreteras.Callouts
{
    [CalloutInfo("ActividadParanormal", CalloutProbability.VeryLow)]
    public class ActividadParanormal : Callout
    {
        Utiles Utiles = new Utiles();
        Random random = new Random();
        private Vector3 _SpawnPoint;
        private Vector3 _Location1;
        private Vector3 _Location2;
        private String audioradio = "ente";
        private Blip _Blip;

        public void Seleccion_Scenario()
        {
            _Location1 = new Vector3(-1524.05f, -421.89f, 35.05f);
            _Location2 = new Vector3(-1545.86f, -399.08f, 41.59f);

            Random random = new Random();
            List<string> list = new List<string>
            {
                "Location1",
                "Location2"
            };
            int num = random.Next(1, 3);
            if (list[num] == "Location1")
            {
                _SpawnPoint = _Location1;
            }
            if (list[num] == "Location2")
            {
                _SpawnPoint = _Location2;
            }
        }
        public override bool OnBeforeCalloutDisplayed()
        {
            Seleccion_Scenario();
            ShowCalloutAreaBlipBeforeAccepting(_SpawnPoint, 100f);

            CalloutMessage = "~b~COTA:~s~ INFORMAN DE ACTIVIDAD ANORMAL EN EL PUNTO INDICADO";
            CalloutPosition = _SpawnPoint;

            Functions.PlayScannerAudioUsingPosition(audioradio, _SpawnPoint);
            return base.OnBeforeCalloutDisplayed();
        }

    }
}
