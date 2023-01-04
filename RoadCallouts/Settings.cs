using System.Windows.Forms;
using Rage;

namespace ControlCarreteras
{
    internal static class Settings
    {
       
        internal static bool Electric_Scooter = true;
        internal static bool emergency_call = true;
        internal static bool language_esp = true;
        internal static bool scooterinstall = true;
        internal static bool RoadAccident = true;
        internal static bool Persecucion = true;
        internal static bool Conduccion_Temeraria = true;
        internal static bool Bajo_Influencia = true;
        internal static Keys EndCall = Keys.End;
        internal static Keys Dialog = Keys.Y;
        internal static int dificultad = 80;
        internal static Keys menuUI = Keys.F6;
        internal static string indicativo = "100";

        internal static string[] CHARLA_OFICIAL_1;

        //internal static int indicativo = 20;


        internal static void LoadSettings()
        {
            Game.LogTrivial("Loading Config file from RoadCallouts by juanpolice");
            var path = "Plugins/LSPDFR/ControlCarreteras.ini";
            var ini = new InitializationFile(path);
            ini.Create();

            language_esp = ini.ReadBoolean("Settings", "language_esp", true);

            Electric_Scooter = ini.ReadBoolean("Settings", "Electric_Scooter", true);
            RoadAccident = ini.ReadBoolean("Settings", "RoadAccident", true);
            Persecucion = ini.ReadBoolean("Settings", "Persecucion", true);
            Conduccion_Temeraria = ini.ReadBoolean("Settings", "Conduccion_Temeraria", true);
            Bajo_Influencia = ini.ReadBoolean("Settings", "Bajo_Influencia", true);

            dificultad = ini.ReadInt32("Settings", "dificultad", 80);
            indicativo = ini.ReadString("Settings", "indivativo", "100");


            EndCall = ini.ReadEnum("Keys", "EndCall", Keys.End);
            Dialog = ini.ReadEnum("Keys", "Dialog", Keys.Y);
            menuUI = ini.ReadEnum("Keys", "menuUI", Keys.F6);

            scooterinstall = ini.ReadBoolean("Settings", "scooterinstall", true);

            //CHARLA_OFICIAL_1 = ini.ReadString("Settings", "CHARLA_OFICIAL_1", "", "");



            //indicativo = ini.ReadInt32("Settings", "indicativo", 80);





        }



        public static readonly string CalloutVersion = "1.0";
    }
}
