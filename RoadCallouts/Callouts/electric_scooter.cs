using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using LSPD_First_Response;
using LSPD_First_Response.Mod.API;
using LSPD_First_Response.Mod.Callouts;
using System.Drawing;

namespace ControlCarreteras.Callouts
{
    [CalloutInfo("SCOOTER ON ROAD", CalloutProbability.Medium)]
    public class Electric_Scooter : Callout
    {
        Utiles Utiles = new Utiles();
        private Random escenario;
        private int seleccionScenario;
        private string audioradio;
        private Ped ped1;
        private Vehicle scooterV;
        private Vector3 _SpawnPoint;
        private Vector3 Location;
        private Blip _Blip;
        private Random rnd1;
        private int num1;
        private Vector3 _Location1;
        private Vector3 _Location2;
        private Vector3 _Location3;
        private Vector3 _Location4;
        private Vector3 _Location5;
        private Vector3 _Location6;
        private Vector3 _Location7;
        private Vector3 _Location8;
        private Vector3 _Location9;
        private Vector3 _Location10;
        private Vector3 _Location11;
        private Vector3 _Location12;
        private Vector3 _Location13;
        private Vector3 _Location14;
        private Vector3 _Location15;
        private Vector3 _Location16;
        private Vector3 _Location17;
        private Vector3 _Location18;
        private Vector3 _Location19;
        private Vector3 _Location20;
        private Vector3 _Location21;
        private Vector3 _Location22;
        private Vector3 _Location23;
        private Vector3 _Location24;
        private Vector3 _Location25;
        private Vector3 _Location26;
        private Vector3 _Location27;
        private Vector3 _Location28;
        private Vector3 _Location29;
        private Vector3 _Location30;
        int CallDificultadP1;

        public void Seleccion_Scenario() {
            _Location1 = new Vector3(-1524.05f, -421.89f, 35.05f);
            _Location2 = new Vector3(-1545.86f, -399.08f, 41.59f);
            _Location3 = new Vector3(-1576.22f, -1018.98f, 12.63f);
            _Location4 = new Vector3(-1533.24f, -996.0f, 12.62f);
            _Location5 = new Vector3(-1656.0f, -875.04f, 8.54f);
            _Location6 = new Vector3(-1597.96f, -922.82f, 8.57f);
            _Location7 = new Vector3(-1158.08f, -1746.83f, 3.64f);
            _Location8 = new Vector3(-981.02f, -1477.39f, 4.62f);
            _Location9 = new Vector3(-814.2f, -1311.96f, 4.61f);
            _Location10 = new Vector3(-696.85f, -1104.73f, 14.13f);
            _Location11 = new Vector3(-918.37f, -167.66f, 41.48f);
            _Location12 = new Vector3(-314.82f, -697.72f, 32.64f);
            _Location13 = new Vector3(104.91f, -1400.37f, 28.87f);
            _Location15 = new Vector3(438.72f, -1479.69f, 28.91f);
            _Location16 = new Vector3(712.04f, -980.38f, 23.73f);
            _Location17 = new Vector3(-165.12f, -1192.85f, 36.92f);
            _Location18 = new Vector3(-395.78f, -955.54f, 37.22f);
            _Location19 = new Vector3(-419.26f, -748.6f, 37.08f);
            _Location20 = new Vector3(-154.8f, -532.45f, 28.83f);
            _Location21 = new Vector3(20.39f, -491.75f, 34.08f);
            _Location22 = new Vector3(679.49f, -155.62f, 49.31f);
            _Location23 = new Vector3(419.1f, -557.07f, 28.75f);
            _Location24 = new Vector3(992.14f, 259.94f, 81.08f);
            _Location25 = new Vector3(1309.84f, 598.86f, 80.06f);
            _Location26 = new Vector3(1003.83f, -852.09f, 32.04f);
            _Location27 = new Vector3(615.5f, -2500.8f, 16.97f);
            _Location28 = new Vector3(-750.2f, -2158.7f, 14.35f);
            _Location29 = new Vector3(-612.95f, -1733.07f, 37.43f);
            _Location30 = new Vector3(-1134.74f, -639.98f, 12.03f);

            Random random = new Random();
            List<string> list = new List<string>
            {
                "Location1",
                "Location2",
                "Location3",
                "Location4",
                "Location5",
                "Location6",
                "Location7",
                "Location8",
                "Location9",
                "Location10",
                "Location11",
                "Location12",
                "Location13",
                "Location14",
                "Location15",
                "Location16",
                "Location17",
                "Location18",
                "Location19",
                "Location20",
                "Location21",
                "Location22",
                "Location23",
                "Location24",
                "Location25",
                "Location26",
                "Location27",
                "Location28",
                "Location29",
                "Location30"
            };

            int num = random.Next(1, 30);
            if (list[num] == "Location1")
            {
                _SpawnPoint = _Location1;
            }
            if (list[num] == "Location2")
            {
                _SpawnPoint = _Location2;
            }
            if (list[num] == "Location3")
            {
                _SpawnPoint = _Location3;
            }
            if (list[num] == "Location4")
            {
                _SpawnPoint = _Location4;
            }
            if (list[num] == "Location5")
            {
                _SpawnPoint = _Location5;
            }
            if (list[num] == "Location6")
            {
                _SpawnPoint = _Location6;
            }
            if (list[num] == "Location7")
            {
                _SpawnPoint = _Location7;
            }
            if (list[num] == "Location8")
            {
                _SpawnPoint = _Location8;
            }
            if (list[num] == "Location9")
            {
                _SpawnPoint = _Location9;
            }
            if (list[num] == "Location10")
            {
                _SpawnPoint = _Location10;
            }
            if (list[num] == "Location11")
            {
                _SpawnPoint = _Location11;
            }
            if (list[num] == "Location12")
            {
                _SpawnPoint = _Location12;
            }
            if (list[num] == "Location13")
            {
                _SpawnPoint = _Location13;
            }
            if (list[num] == "Location14")
            {
                _SpawnPoint = _Location14;
            }
            if (list[num] == "Location15")
            {
                _SpawnPoint = _Location15;
            }
            if (list[num] == "Location16")
            {
                _SpawnPoint = _Location16;
            }
            if (list[num] == "Location17")
            {
                _SpawnPoint = _Location17;
            }
            if (list[num] == "Location18")
            {
                _SpawnPoint = _Location18;
            }
            if (list[num] == "Location19")
            {
                _SpawnPoint = _Location19;
            }
            if (list[num] == "Location20")
            {
                _SpawnPoint = _Location20;
            }
            if (list[num] == "Location21")
            {
                _SpawnPoint = _Location21;
            }
            if (list[num] == "Location22")
            {
                _SpawnPoint = _Location22;
            }
            if (list[num] == "Location23")
            {
                _SpawnPoint = _Location23;
            }
            if (list[num] == "Location24")
            {
                _SpawnPoint = _Location24;
            }
            if (list[num] == "Location25")
            {
                _SpawnPoint = _Location25;
            }
            if (list[num] == "Location26")
            {
                _SpawnPoint = _Location26;
            }
            if (list[num] == "Location27")
            {
                _SpawnPoint = _Location27;
            }
            if (list[num] == "Location28")
            {
                _SpawnPoint = _Location28;
            }
            if (list[num] == "Location29")
            {
                _SpawnPoint = _Location29;
            }
            if (list[num] == "Location30")
            {
                _SpawnPoint = _Location30;
            }


        }

        public void monta_veh() {
            escenario = new Random();
            seleccionScenario = escenario.Next(0, 2);

            if (Settings.scooterinstall)
            {
                if (seleccionScenario == 0)
                {
                    scooterV = new Vehicle(Utiles.scooterList[new Random().Next((int)Utiles.scooterList.Length)], _SpawnPoint, 0f);
                    audioradio = "SCOOTER";
                }
                if (seleccionScenario == 1)
                {
                    scooterV = new Vehicle(Utiles.VMP[new Random().Next((int)Utiles.VMP.Length)], _SpawnPoint, 0f);
                    audioradio = "VMP";
                }
            }
            else
            {
                scooterV = new Vehicle(Utiles.scooterList[new Random().Next((int)Utiles.scooterList.Length)], _SpawnPoint, 0f);
                audioradio = "SCOOTER";
            }

        }

        public void Dificultad_Scenario()
        {
            int seleccionScenarioP1;
            seleccionScenarioP1 = new Random().Next(0, 100);

            if (seleccionScenarioP1 > Settings.dificultad)
                CallDificultadP1 = 1;
            else
                CallDificultadP1 = 2;
        }
        public override bool OnBeforeCalloutDisplayed()
        {
            Seleccion_Scenario();
            Dificultad_Scenario();
            monta_veh();
            ShowCalloutAreaBlipBeforeAccepting(_SpawnPoint, 100f);

            CalloutMessage = "~b~COTA:~s~ PATINETE/CICLOMOTOR/BICICLETA CIRCULANDO EN LA AUTOPISTA";
            CalloutPosition = _SpawnPoint;

            Functions.PlayScannerAudioUsingPosition(audioradio, _SpawnPoint);
            return base.OnBeforeCalloutDisplayed();
        }

        public override bool OnCalloutAccepted()
        {
            Game.LogTrivial("JUANPOLICE Log: LLAMADA ACEPTADA.");
            Game.DisplayNotification("web_lossantospolicedept", "web_lossantospolicedept", "~w~RoadCallouts", "~y~SCOOTER EN LA CARRETERA", "~b~COTA:~w~ Alguien ha llamado a la central Porque han visto una ~g~Scooter~w~ en la ~o~AUTOPISTA");

            ped1 = new Ped(Utiles.scooterpedList[new Random().Next((int)Utiles.scooterpedList.Length)], _SpawnPoint, 0f);
            LSPD_First_Response.Mod.API.Functions.SetVehicleOwnerName(scooterV, LSPD_First_Response.Mod.API.Functions.GetPersonaForPed(ped1).FullName);
            ped1.WarpIntoVehicle(scooterV, -1);

            _Blip = scooterV.AttachBlip();
            _Blip.Color = Color.LightBlue;
            _Blip.EnableRoute(Color.Yellow);

            int random;
            float speeder;
            float newSpeed;
            random = new Random().Next(0, 15);
            speeder = (float)random;
            newSpeed = speeder;

            ped1.Tasks.CruiseWithVehicle(scooterV, newSpeed, VehicleDrivingFlags.DriveAroundVehicles);
            //ped1.Tasks.CruiseWithVehicle(newSpeed, VehicleDrivingFlags.Normal);
            return base.OnCalloutAccepted();
        }

        public override void OnCalloutNotAccepted()
        {
            if (ped1.Exists()) ped1.Delete();
            if (scooterV.Exists()) scooterV.Delete();
            if (_Blip.Exists()) _Blip.Delete();
            base.OnCalloutNotAccepted();
        }

        private bool notifica_investigacion = true;
        private bool notifica_investigacion_p1 = true;
        private bool notifica_investigacion_p2 = true;
        private int conversacion = 1;
        public override void Process()
        {
            GameFiber.StartNew(delegate
            {
                if (ped1.DistanceTo(Game.LocalPlayer.Character) < 20f)
                {
                    if (notifica_investigacion)
                    {
                        Game.DisplayNotification("Deten al Vehiculo y habla con el conductor~w~.");
                        GameFiber.Wait(600);
                        notifica_investigacion = false;
                    }

                    if (Functions.IsPlayerPerformingPullover())
                    {

                        if (ped1.DistanceTo(Game.LocalPlayer.Character) < 5f && notifica_investigacion_p1) {
                            Game.DisplayHelp("PARA HABLAR CON EL CONDUCTOR ACERCATE AL CONDUCTOR Y USA LA TECLA: ~y~" + Settings.Dialog + "", 7000);
                            notifica_investigacion_p1 = false;
                        }
                        if (ped1.DistanceTo(Game.LocalPlayer.Character) < 2f && Game.IsKeyDown(Settings.Dialog))
                        {
                            switch (conversacion)
                            {
                                case 1:
                                    Game.DisplaySubtitle(conversaciones_parada.CHARLA_OFICIAL_INTRO[new Random().Next((int)conversaciones_parada.CHARLA_OFICIAL_INTRO.Length)]);
                                    conversacion++;
                                    break;
                                case 2:
                                    Game.DisplaySubtitle(conversaciones_parada.patinete.MOTIVO_PATINETE_CICLO[new Random().Next((int)conversaciones_parada.patinete.MOTIVO_PATINETE_CICLO.Length)]);
                                    conversacion++;
                                    break;
                                case 3:
                                    if (CallDificultadP1 == 1)
                                        Game.DisplaySubtitle(conversaciones_parada.CHARLA_PED_INTRO_POSITIVE[new Random().Next((int)conversaciones_parada.CHARLA_PED_INTRO_POSITIVE.Length)]);
                                    else
                                        Game.DisplaySubtitle(conversaciones_parada.CHARLA_PED_INTRO_NEGATIVO[new Random().Next((int)conversaciones_parada.CHARLA_PED_INTRO_NEGATIVO.Length)]);
                                    conversacion++;
                                    break;
                                case 4:
                                    if (CallDificultadP1 == 1)
                                        Game.DisplaySubtitle(conversaciones_parada.CHARLA_PED_INFRACICON_POSITIVE[new Random().Next((int)conversaciones_parada.CHARLA_PED_INFRACICON_POSITIVE.Length)]);
                                    else
                                        Game.DisplaySubtitle(conversaciones_parada.CHARLA_PED_INFRACICON_NEGATIVO[new Random().Next((int)conversaciones_parada.CHARLA_PED_INFRACICON_NEGATIVO.Length)]);
                                    conversacion++;
                                    break;
                                case 5:
                                    if (CallDificultadP1 == 1)
                                        Game.DisplaySubtitle(conversaciones_parada.CHARLA_OFICIAL_OUT_POSITIVE[new Random().Next((int)conversaciones_parada.CHARLA_OFICIAL_OUT_POSITIVE.Length)]);
                                    else
                                        Game.DisplaySubtitle(conversaciones_parada.CHARLA_OFICIAL_OUT_NEGATIVO[new Random().Next((int)conversaciones_parada.CHARLA_OFICIAL_OUT_NEGATIVO.Length)]);
                                    conversacion++;
                                    break;
                                case 6:
                                    Game.DisplaySubtitle("~y~EN FUNCION A LOS DATOS RECIBIDOS, DEBERAS TOMAR DECISIONES PROPIAS. SE RECOMIENDA USAR ~y~STOP THE PED~w~", 5000);
                                    conversacion++;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }

                if (Game.LocalPlayer.Character.IsDead) End();
                if (Game.IsKeyDown(Settings.EndCall)) End();
                if (ped1.IsDead) End();
            }, "Electric_Scooter [RoadCallouts]");
            base.Process();
        }
        public override void End()
        {
            if (_Blip.Exists()) _Blip.Delete();
            Game.DisplayNotification("web_lossantospolicedept", "web_lossantospolicedept", "~w~RoadCallouts", "~y~SCOOTER EN LA CARRETERA", "SITUACION CONTROLADA");
            Functions.PlayScannerAudio("ATTENTION_THIS_IS_DISPATCH WE_ARE_CODE FOUR NO_FURTHER_UNITS_REQUIRED");
            base.End();
        }
    }
}
