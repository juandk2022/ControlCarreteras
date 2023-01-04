using System.Windows.Forms;
using Rage;
using LSPD_First_Response.Mod.API;
using LSPD_First_Response.Mod.Callouts;
using System.Drawing;
using System.Security.Cryptography;
using System;

namespace ControlCarreteras
{
    public class Utiles
    {
		private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

		public static string[] CalloutVehModels1 = {
			"Blista",
			"Jackal",
			"Oracle",
			"Asea",
			"Emperor",
			"Fugitive",
			"Ingot",
			"Premier",
			"Primo",
			"Stanier",
			"Stratum",
			"Asterope",
			"Baller",
			"Bison",
			"Cavalcade2",
			"Exemplar",
			"F620",
			"Felon",
			"FQ2",
			"Gresley",
			"Habanero",
			"Intruder",
			"Landstalker",
			"Mesa",
			"Minivan",
			"Patriot",
			"Radi",
			"Regina",
			"schafter2",
			"Seminole",
			"Sentinel",
			"Serrano",
			"Speedo",
			"Surge",
			"Tailgater",
			"Washington",
			"Zion"
		};
		public static string[] VehModels1 = {
			"Blista",
			"Jackal",
			"Oracle",
			"Asea",
			"Emperor",
			"Fugitive",
			"Ingot",
			"Premier",
			"Primo",
			"Stanier",
			"Stratum",
			"Asterope",
			"Baller",
			"Bison",
			"Cavalcade2",
			"Exemplar",
			"F620"
			
		};
		public static string[] VehModels2 = {
			"Felon",
			"FQ2",
			"Gresley",
			"Habanero",
			"Intruder",
			"Landstalker",
			"Mesa",
			"Minivan",
			"Patriot",
			"Radi",
			"Regina",
			"schafter2",
			"Seminole",
			"Sentinel",
			"Serrano",
			"Speedo",
			"Surge",
			"Tailgater",
			"Washington",
			"Zion"
		};

		public static string[] PedModels1 =  {
			"A_M_Y_SouCent_01",
			"A_M_Y_StWhi_01",
			"A_M_Y_StBla_01",
			"A_M_Y_Downtown_01",
			"A_M_Y_BevHills_01",
			"G_M_Y_MexGang_01",
			"G_M_Y_MexGoon_01",
			"G_M_Y_StrPunk_01",
			"A_M_M_BevHills_01",
			"A_M_M_GenFat_01",
			"A_M_M_Business_01",
			"A_M_M_Golfer_01",
			"A_M_M_Skater_01",
			"A_M_M_Salton_01",
			"A_M_M_Tourist_01"

		};

		public static string[] PedModels2 =  {
			"A_M_Y_SouCent_01",
			"A_M_Y_StWhi_01",
			"A_M_Y_StBla_01",
			"A_M_Y_Downtown_01",
			"A_M_Y_BevHills_01",
			"G_M_Y_MexGang_01",
			"G_M_Y_MexGoon_01",
			"G_M_Y_StrPunk_01",
			"A_M_M_BevHills_01",
			"A_M_M_GenFat_01",
			"A_M_M_Business_01",
			"A_M_M_Golfer_01",
			"A_M_M_Skater_01",
			"A_M_M_Salton_01",
			"A_M_M_Tourist_01"

		};

		public static string[] scooterList = {
			"faggio",
			"faggio2",
			"faggio3"
		};

		public static string[] VMP = {
			"serv_electricscooter"
		};


		public static string[] scooterpedList = {
			"A_F_Y_Hippie_01",
			"A_M_Y_Skater_01",
			"A_M_M_FatLatin_01",
			"A_M_M_EastSA_01",
			"A_M_Y_Latino_01",
			"G_M_Y_FamDNF_01",
			"G_M_Y_FamCA_01", 
			"G_M_Y_BallaSout_01",
			"G_M_Y_BallaOrig_01",
			"G_M_Y_BallaEast_01",
			"G_M_Y_StrPunk_02",
			"S_M_Y_Dealer_01",
			"A_M_M_RurMeth_01",
			"A_M_Y_MethHead_01", 
			"A_M_M_Skidrow_01", 
			"S_M_Y_Dealer_01",
			"a_m_y_mexthug_01",
			"G_M_Y_MexGoon_03",
			"G_M_Y_MexGoon_02",
			"G_M_Y_MexGoon_01", 
			"G_M_Y_SalvaGoon_01",
			"G_M_Y_SalvaGoon_02",
			"G_M_Y_SalvaGoon_03",
			"G_M_Y_Korean_01",
			"G_M_Y_Korean_02",
			"G_M_Y_StrPunk_01" 
		};


		public string[] modelomotos = new string[] {   
			"DOUBLE",
			"ENDURO",
			"ESSKEY",
			"LECTRO",
			"MANCHEZ",
			"NEMESIS",
			"NIGHTBLADE",
			"faggio3" 
		};

		public string[] modelomotos2 = new string[] {
			"faggio",
			"faggio2",
			"akuma",
			"AVARUS",
			"BAGGER",
			"BATI"
		};


		public string[] modelotractor = new string[] {
			"TRACTOR",
			"TRACTOR2"
		};
		public string[] modelocamion = new string[] {
			"BISON",
			"BOBCATXL",
			"BURRITO",
			"CAMPER",
			"SPEEDO2",
			"JOURNEY",
			"DOUBLE",
			"ENDURO"

		};

		public string[] modelocamion2 = new string[] {
			"MINIVAN",
			"PARADISE",
			"PONY",
			"RUMPO",
			"SPEEDO",
			"SURFER",
			"TACO",
			"YOUGA",
			"MULE",
			"MULE2"
		};

		public static Random rnd = new Random(MathHelper.GetRandomInteger(100, 100000));

		private string[] carList = { "speedo", "speedo2", "stanier", "stinger", "stingergt", "stratum", "stretch", "taco", "tornado", "tornado2", "tornado3", "tornado4", "tourbus", "vader", "voodoo2", "dune5", "youga", "taxi", "tailgater", "sentinel2", "sentinel", "sandking2", "sandking", "ruffian", "rumpo", "rumpo2", "oracle2", "oracle", "ninef2", "ninef", "minivan", "gburrito", "emperor2", "emperor" };

		public static readonly string CalloutVersion = "1.0";


		public static Vector3 DamageCar(Vehicle vehicle)
		{
			var model = vehicle.Model;
			var randomInt1 = 0f;
			var randomInt2 = 0f;
			var randomInt3 = 0f;

			model.GetDimensions(out var vector3_1, out var vector3_2);

			var num = new Random().Next(10, 45);
			for (var index = 0; index < num; ++index)
			{
				randomInt1 = MathHelper.GetRandomSingle(vector3_1.X, vector3_2.X);
				randomInt2 = MathHelper.GetRandomSingle(vector3_1.Y, vector3_2.Y);
				randomInt3 = MathHelper.GetRandomSingle(vector3_1.Z, vector3_2.Z);
				//crashedVehicle.Deform(new Vector3(randomInt1, randomInt2, randomInt3), 5, 100);
			}

			return new Vector3(randomInt1, randomInt2, randomInt3);
		}

		public static void debuger() { 
		
		}

	}
}
