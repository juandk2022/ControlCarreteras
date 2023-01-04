using System;
using Rage;
using LSPD_First_Response.Mod.API;
using LSPD_First_Response.Mod.Callouts;
using System.Drawing;


namespace ControlCarreteras.Callouts
{
    [CalloutInfo("Conduccion_Temeraria", CalloutProbability.Medium)]
    public class Conduccion_Temeraria : Callout
    {
        private Random escenario;
        private int seleccionScenario;
        private string audioradio;
        private Ped ped1;
        private Vehicle vehicle;
        private Blip _Blip;
        private string calloutAudio;
        speecher speecher = new speecher();

        int CallDificultadP1;
        Utiles Utiles = new Utiles();
        Utiles2 utiles2 = new Utiles2();

        public override bool OnBeforeCalloutDisplayed()
        {
            utiles2.Seleccion_Scenario();
            Dificultad_Scenario();
            seleccion_vehiculo(GetUtiles());
            ShowCalloutAreaBlipBeforeAccepting(utiles2._SpawnPoint, 100f);

            calloutAudio = "DE COTA PARA" + Settings.indicativo +", DIRIJASE AL LUGAR INDICADO, NOS INFORMAN DE UNA POSIBLE CONDUCCION TEMERARIA.";
            CalloutMessage = "~b~COTA:~s~ VEHICULO CIRCULANDO DE FORMA TEMERARIA";
            CalloutPosition = utiles2._SpawnPoint;

            Functions.PlayScannerAudioUsingPosition(audioradio, utiles2._SpawnPoint);
            return base.OnBeforeCalloutDisplayed();
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

        public Utiles GetUtiles()
        {
            return Utiles;
        }

        public void seleccion_vehiculo(Utiles utiles)
        {
            escenario = new Random();
            seleccionScenario = escenario.Next(0, 2);
            Random rndVEH1 = new Random();
            int caseSwitchVEH1 = rndVEH1.Next(1, 10);
            Random rndVEH2 = new Random();
            int caseSwitchVEH2 = rndVEH2.Next(11, 20);
            switch (caseSwitchVEH1)
            {
                case 1:
                    vehicle = new Vehicle(Utiles.VehModels1[new Random().Next((int)Utiles.VehModels1.Length)], utiles2._SpawnPoint, 0f);
                    break;
                case 2:
                    vehicle = new Vehicle(utiles.modelomotos[new Random().Next((int)Utiles.modelomotos.Length)], utiles2._SpawnPoint, 0f);
                    break;
                case 3:
                    vehicle = new Vehicle(Utiles.VehModels1[new Random().Next((int)Utiles.VehModels1.Length)], utiles2._SpawnPoint, 0f);
                    break;
                case 4:
                    vehicle = new Vehicle(Utiles.modelomotos[new Random().Next((int)Utiles.modelomotos.Length)], utiles2._SpawnPoint, 0f);
                    break;
                case 5:
                    vehicle = new Vehicle(Utiles.VehModels1[new Random().Next((int)Utiles.VehModels1.Length)], utiles2._SpawnPoint, 0f);
                    break;
                case 6:
                    vehicle = new Vehicle(Utiles.modelomotos[new Random().Next((int)Utiles.modelomotos.Length)], utiles2._SpawnPoint, 0f);
                    break;
                case 7:
                    vehicle = new Vehicle(Utiles.VehModels1[new Random().Next((int)Utiles.VehModels1.Length)], utiles2._SpawnPoint, 0f);
                    break;
                case 8:
                    vehicle = new Vehicle(Utiles.modelomotos[new Random().Next((int)Utiles.modelomotos.Length)], utiles2._SpawnPoint, 0f);
                    break;
                case 9:
                    vehicle = new Vehicle(Utiles.modelocamion[new Random().Next((int)Utiles.modelocamion.Length)], utiles2._SpawnPoint, 0f);
                    break;
                case 10:
                    vehicle = new Vehicle(Utiles.modelotractor[new Random().Next((int)Utiles.modelotractor.Length)], utiles2._SpawnPoint, 0f);
                    break;
                default:

                    break;
            }
           
            audioradio = "REPORT_RESPONSE_COPY_01";
        }

        public override bool OnCalloutAccepted()
        {
            Game.LogTrivial("JUANPOLICE Log: LLAMADA ACEPTADA.");
            Game.DisplayNotification("web_lossantospolicedept", "web_lossantospolicedept", "~w~RoadCallouts", "~y~CONDUCCION TEMERARIA", "~b~COTA:~w~ Informan desde central, un vehiculo que circula de manera temeraria en la ~o~AUTOPISTA");
            speecher.info_callout(calloutAudio);
            ped1 = new Ped(Utiles.PedModels1[new Random().Next((int)Utiles.PedModels1.Length)], utiles2._SpawnPoint, 0);
            ped1.MakePersistent();
           


            LSPD_First_Response.Mod.API.Functions.SetVehicleOwnerName(vehicle, LSPD_First_Response.Mod.API.Functions.GetPersonaForPed(ped1).FullName);
            ped1.WarpIntoVehicle(vehicle, -1);

            _Blip = vehicle.AttachBlip();
            _Blip.Color = Color.LightBlue;
            _Blip.EnableRoute(Color.Yellow);

            int random;
            float speeder;
            float newSpeed;
            random = new Random().Next(0, 15);
            speeder = (float)random;
            newSpeed = speeder;

            ped1.Tasks.CruiseWithVehicle(vehicle, newSpeed, VehicleDrivingFlags.DriveAroundVehicles);            
            return base.OnCalloutAccepted();
        }

        public override void OnCalloutNotAccepted()
        {
            if (ped1.Exists()) ped1.Delete();
            if (vehicle.Exists()) vehicle.Delete();
            if (_Blip.Exists()) _Blip.Delete();
            base.OnCalloutNotAccepted();
        }

        private bool notifica_investigacion = true;
        private bool notifica_investigacion_p1 = true;
        private int conversacion = 1;
       

        public override void Process()
        {
            
            GameFiber.StartNew(delegate
            {
                if (ped1.DistanceTo(Game.LocalPlayer.Character) < 100f)
                {
                    if (notifica_investigacion)
                    {
                        Game.DisplayNotification("Deten al Vehiculo y averigua el motivo de la conduccion temeraria~w~.");
                        GameFiber.Wait(600);
                        notifica_investigacion = false;
                    }
                }

                if (Game.LocalPlayer.Character.IsDead) End();
                if (Game.IsKeyDown(Settings.EndCall)) End();
                if (ped1.IsDead) End();
                if (ped1 && Functions.IsPedArrested(ped1)) End();
            }, "Conduccion_Temeraria [RoadCallouts]");
            base.Process();
        }
        public override void End()
        {
            
            if (ped1.Exists()) ped1.Dismiss();
            if (vehicle.Exists()) vehicle.Dismiss();
            if (_Blip.Exists()) _Blip.Delete();

            Game.DisplayNotification("web_lossantospolicedept", "web_lossantospolicedept", "~w~RoadCallouts", "~y~CONDUCCION TEMERARIA", "SITUACION CONTROLADA");
            Functions.PlayScannerAudio("ATTENTION_THIS_IS_DISPATCH WE_ARE_CODE FOUR NO_FURTHER_UNITS_REQUIRED");
            base.End();
        }
    }
}
