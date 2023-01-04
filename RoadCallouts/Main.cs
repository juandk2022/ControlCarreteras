using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rage;
using Rage.Native;
using LSPD_First_Response.Mod.API;
using LSPD_First_Response.Mod.Callouts;
using LSPD_First_Response.Engine.Scripting.Entities;
using ControlCarreteras.Callouts;
using System.Reflection;

namespace ControlCarreteras
{
    public class Main : Plugin
    {
        public static bool IsLSPDFRPlusRunning = false;

        public override void Finally()
        {
            Game.DisplayHelp("Roads Callouts Se cargo de forma exitosa.");
        }
        public override void Initialize()
        {
            Functions.OnOnDutyStateChanged += Functions_OnOnDutyStateChanged;
            Game.LogTrivial("Roads Callouts Se cargo!");
            Settings.LoadSettings();
        }

        static void Functions_OnOnDutyStateChanged(bool onDuty)
        {
            if (onDuty)
                GameFiber.StartNew(delegate
                {
                    RegisterCallouts();
                    Game.Console.Print();
                    Game.Console.Print("=============================================== ROAD CALLOUTS BY JUANPOLICE ================================================");
                    Game.Console.Print("===============================================  using UnitedCallouts base  ================================================");
                    Game.Console.Print();
                    Game.Console.Print("[LOG]: TODO SE CARGO BIEN.");
                    Game.Console.Print();
                    Game.Console.Print("=============================================== ROAD CALLOUTS BY JUANPOLICE ================================================");
                    Game.Console.Print("===============================================  using UnitedCallouts base  ================================================");
                    Game.Console.Print();
                    Game.DisplayNotification(
                        "web_lossantospolicedept",
                        "web_lossantospolicedept",
                        "LLAMADAS DE CARRETERAS",
                        "~y~v beta ~o~by sEbi3 & JUANPOLICE", "~b~SE CARGO DE FORMA CORRECTO!");

                    GameFiber.Wait(300);
                    Game.DisplayNotification("SUPPORT THE WORK OF sEbi3, DOWNLOADING ITS CALL PACK, UNITED CALLOUTS");
                  
                });
        }

        private static void RegisterCallouts() //Register all your callouts here
        {
          
            if (Settings.Electric_Scooter) { Functions.RegisterCallout(typeof(Electric_Scooter)); Game.LogTrivial("Electric_Scooter loaded"); }
            if (Settings.RoadAccident) { Functions.RegisterCallout(typeof(RoadAccident)); Game.LogTrivial("Roadcallout loaded"); }
            if (Settings.Conduccion_Temeraria) { Functions.RegisterCallout(typeof(Conduccion_Temeraria)); Game.LogTrivial("Conduccion_Temeraria loaded"); }
        }
    }
}
