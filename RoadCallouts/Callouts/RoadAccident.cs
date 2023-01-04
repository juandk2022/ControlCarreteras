using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using Rage.Native;
using LSPD_First_Response;
using LSPD_First_Response.Mod.API;
using LSPD_First_Response.Mod.Callouts;
using System.Drawing;
using LSPD_First_Response.Engine;
using System.Windows.Forms;
using static ControlCarreteras.Utiles;


namespace ControlCarreteras.Callouts
{
	[CalloutInfo("RoadAccident JP", CalloutProbability.VeryHigh)]
	public class RoadAccident : Callout
	{
		//POSITIONS
		private Vector3 _SpawnPoint; private Vector3 Location; private Vector3 Location2;
		private Vector3 Location3; private Vector3 carlocation1; private Vector3 carlocation2;
		private static Vector3 CheckPointPosition;

		//RANDOM SECUENCES
		private Random escenarioP2; private Random alcohol1; private Random drogas1;
		private Random alcohol2; private Random drogas2; private int num1;
		private Random rnd1; private Random escenarioP1; private Random dam;
		public int damage; private Random dag;

		//PEDS AND VEHICLES
		private Ped P1; private Ped P2; private Vehicle VEH1; private Vehicle VEH2; private Blip _blip;

		//OBJECTS
		private bool ejecute1; private bool ejecute2; private bool p1alcohol; private bool p2alcohol;
		private bool p1drogas; private bool p2drogas; private bool face1; private bool face2;
		private static int CheckPoint; private string audioradio; private int seleccionScenarioP1;
		private int seleccionScenarioP2; private int setAlcohol1;
		private int setDrogas1; private int setAlcohol2; private int setDrogas2; public int deform; private float car1head;
		private float car2head; private float ped1head; private float ped2head;
		private int conversacion = 1; private int conversacion2 = 1; private int CallDificultadP1 = 0;
		private int CallDificultadP2 = 0;

		private string ubicacion = "";
		private string pk = "";
		private int estatus = 1;

		//UTILS
		AnimationSet drunkAnimsetP1 = new AnimationSet("move_m@drunk@verydrunk"); AnimationSet drunkAnimsetP2 = new AnimationSet("move_m@drunk@verydrunk");
		Utiles Utiles = new Utiles(); conversaciones conversaciones = new conversaciones();
		speecher speecher = new speecher();
		
		public void Dificultad_Scenario() {

			escenarioP1 = new Random(); escenarioP2 = new Random();
			seleccionScenarioP1 = escenarioP1.Next(0, 100);seleccionScenarioP2 = escenarioP2.Next(0, 100);
			if (seleccionScenarioP1 > Settings.dificultad)
				CallDificultadP1 = 1;
			else
				CallDificultadP1 = 2;

			
			if (seleccionScenarioP2 > Settings.dificultad)
				CallDificultadP2 = 1;
			else
				CallDificultadP2 = 2;
		}

		public void Seleccion_Scenario(){
			rnd1 = new Random(); num1 = rnd1.Next(1, 17);
			if (num1 == 1)
			{
				Location = new Vector3(1760.28f, 1882.119f, 74.03759f); _SpawnPoint = Location;
				Location2 = new Vector3(1760.28f, 1850.119f, 74.03759f); ped1head = 162.7903f;
				Location3 = new Vector3(1760.141f, 1847.142f, 74.96257f); ped2head = 328.1941f;

				carlocation1 = new Vector3(1759.211f, 1874.116f, 74.34618f); car1head = 176.9846f;
				carlocation2 = new Vector3(1757.72f, 1862.977f, 74.85532f); car2head = 205.943f;
				audioradio = "ACCIDENTE_01";
				audioradio = "CITIZENS_REPORT_01 CRIME_MOTOR_VEHICLE_ACCIDENT_01 OP_ON_A AREA_LOS_SANTOS_FREEWAY_01";
				ubicacion = "E1";
				pk = "2 900, SENTIDO CRECIENTE";
				estatus = new Random().Next(0,3);
	}
			if (num1 == 2)
			{
				Location = new Vector3(2383.522f, 2855.804f, 40.36319f); _SpawnPoint = Location;
				Location2 = new Vector3(2389.45f, 2859.037f, 40.33812f); ped1head = 124.1741f;
				Location3 = new Vector3(2388.042f, 2858.003f, 40.34653f); ped2head = 305.2953f;

				carlocation1 = new Vector3(2385.476f, 2858.798f, 39.87129f); car1head = 301.4066f;
				carlocation2 = new Vector3(2390.157f, 2861.787f, 39.85493f); car2head = 306.6909f;
				audioradio = "ACCIDENTE_02";
				audioradio = "CITIZENS_REPORT_01 CRIME_MOTOR_VEHICLE_ACCIDENT_01 OP_ON_A AREA_LOS_SANTOS_FREEWAY_01";

				ubicacion = "E1";
				pk = "0 500, SENTIDO CRECIENTE";
				
			}
			if (num1 == 3)
			{
				Location = new Vector3(2717.805f, 3314.61f, 55.94178f); _SpawnPoint = Location;
				Location2 = new Vector3(2706.993f, 3306.549f, 55.79161f); ped1head = 51.37082f;
				Location3 = new Vector3(2705.928f, 3307.735f, 55.78947f); ped2head = 235.2913f;

				carlocation1 = new Vector3(2713.777f, 3314.047f, 55.50777f); car1head = 128.7956f;
				carlocation2 = new Vector3(2709.493f, 3310.35f, 55.43824f); car2head = 130.2212f;
				audioradio = "ACCIDENTE_03";
				audioradio = "CITIZENS_REPORT_01 CRIME_MOTOR_VEHICLE_ACCIDENT_01 OP_ON_A AREA_LOS_SANTOS_FREEWAY_01";

				ubicacion = "R1";
				pk = "13 800, SENTIDO CRECIENTE";
				
			}
			if (num1 == 4)
			{
				Location = new Vector3(1924.854f, 2458.748f, 54.60234f); _SpawnPoint = Location;
				carlocation1 = new Vector3(1929.538f, 2466.656f, 54.22318f); car1head = 332.933f;
				carlocation2 = new Vector3(1932.763f, 2471.924f, 54.22209f); car2head = 304.2597f;

				Location2 = new Vector3(1928.224f, 2469.453f, 54.66175f); ped1head = 309.3146f;
				Location3 = new Vector3(1929.41f, 2470.644f, 54.65308f); ped2head = 123.7088f;
				audioradio = "ACCIDENTE_04";
				audioradio = "CITIZENS_REPORT_01 CRIME_MOTOR_VEHICLE_ACCIDENT_01 OP_ON_A AREA_LOS_SANTOS_FREEWAY_01";

				ubicacion = "INTERSECCION E1 Y R1";
				pk = "5";
				
			}
			if (num1 == 5)
			{
				Location = new Vector3(2564.145f, 3045.174f, 44.07037f); _SpawnPoint = Location;
				carlocation1 = new Vector3(2573.751f, 3050.137f, 44.10436f); car1head = 314.4357f;
				carlocation2 = new Vector3(2577.435f, 3056.861f, 44.49092f); car2head = 357.3913f;

				Location2 = new Vector3(2575.565f, 3055.717f, 44.8128f); ped1head = 157.4566f;
				Location3 = new Vector3(2575.183f, 3054.292f, 44.74279f); ped2head = 356.8515f;
				audioradio = "ACCIDENTE_05";
				audioradio = "CITIZENS_REPORT_01 CRIME_MOTOR_VEHICLE_ACCIDENT_01 OP_ON_A AREA_LOS_SANTOS_FREEWAY_01";

				ubicacion = "R1";
				pk = "14, SENTIDO DECRECENTE";
				
			}
			if (num1 == 6)
			{
				Location = new Vector3(2760.368f, 3419.901f, 56.18567f); _SpawnPoint = Location;
				carlocation1 = new Vector3(2759.778f, 3419.77f, 55.75024f); car1head = 93.97344f;
				carlocation2 = new Vector3(2754.666f, 3420.816f, 55.81033f); car2head = 83.82708f;

				Location2 = new Vector3(2758.348f, 3422.552f, 56.37686f); ped1head = 84.47137f;
				Location3 = new Vector3(2756.84f, 3422.542f, 56.40329f); ped2head = 263.4367f;
				audioradio = "ACCIDENTE_06";
				audioradio = "CITIZENS_REPORT_01 CRIME_MOTOR_VEHICLE_ACCIDENT_01 OP_ON_A AREA_LOS_SANTOS_FREEWAY_01";

				ubicacion = "R1";
				pk = "13 500, SENTIDO DECRECIENTE";
				
			}
			if (num1 == 7)
			{
				Location = new Vector3(2951.514f, 3941.363f, 51.90493f); _SpawnPoint = Location;
				carlocation1 = new Vector3(2950.289f, 3946.175f, 51.35051f); car1head = 2.798047f;
				carlocation2 = new Vector3(2950.922f, 3950.966f, 51.32772f); car2head = 3.765229f;

				Location2 = new Vector3(2953.7f, 3949.464f, 51.85752f); ped1head = 178.513f;
				Location3 = new Vector3(2953.845f, 3949.606f, 51.86708f); ped2head = 3.675814f;
				audioradio = "ACCIDENTE_07";
				audioradio = "CITIZENS_REPORT_01 CRIME_MOTOR_VEHICLE_ACCIDENT_01 OP_ON_A AREA_LOS_SANTOS_FREEWAY_01";

				ubicacion = "R1";
				pk = "1 700";
				
			}
			if (num1 == 8)
			{
				Location = new Vector3(2712.368f, 4393.164f, 47.57608f); _SpawnPoint = Location;
				carlocation1 = new Vector3(2708.79f, 4389.985f, 46.92082f); car1head = 115.9616f;
				carlocation2 = new Vector3(2704.7264f, 4387.509f, 46.67908f); car2head = 124.7264f;

				Location2 = new Vector3(2708.281f, 4392.546f, 47.4682f); ped1head = 110.0908f;
				Location3 = new Vector3(2706.711f, 4391.447f, 47.41133f); ped2head = 302.7985f;
				audioradio = "ACCIDENTE_08";
				audioradio = "CITIZENS_REPORT_01 CRIME_MOTOR_VEHICLE_ACCIDENT_01 OP_ON_A AREA_LOS_SANTOS_FREEWAY_01";

				ubicacion = "E8";
				pk = "0 300";
				
			}
			if (num1 == 9)
			{
				Location = new Vector3(2717.304f, 4728.632f, 44.28658f); _SpawnPoint = Location;
				carlocation1 = new Vector3(2716.837f, 4736.767f, 43.90979f); car1head = 6.533547f;
				carlocation2 = new Vector3(2715.572f, 4741.736f, 43.90844f); car2head = 40.34846f;

				Location2 = new Vector3(2713.939f, 4738.064f, 44.30901f); ped1head = 186.5116f;
				Location3 = new Vector3(2714.074f, 4736.313f, 44.30376f); ped2head = 11.02895f;
				audioradio = "ACCIDENTE_09";
				audioradio = "CITIZENS_REPORT_01 CRIME_MOTOR_VEHICLE_ACCIDENT_01 OP_ON_A AREA_LOS_SANTOS_FREEWAY_01";

				ubicacion = "E8";
				pk = "2 500, SENTIDO CRECIENTE";
				
			}
			if (num1 == 10)
			{
				Location = new Vector3(2603.035f, 5300.138f, 44.66172f); _SpawnPoint = Location;
				carlocation1 = new Vector3(2600.31f, 5302.935f, 44.18116f); car1head = 29.27707f;
				carlocation2 = new Vector3(2598.595f, 5307.539f, 44.15871f); car2head = 18.63579f;

				Location2 = new Vector3(2600.562f, 5307.621f, 44.65058f); ped1head = 198.0929f;
				Location3 = new Vector3(2601.289f, 5306.233f, 44.6632f); ped2head = 25.67931f;
				audioradio = "ACCIDENTE_10";
				audioradio = "CITIZENS_REPORT_01 CRIME_MOTOR_VEHICLE_ACCIDENT_01 OP_ON_A AREA_LOS_SANTOS_FREEWAY_01";

				ubicacion = "E8";
				pk = "2 500, SENTIDO CRECIENTE";
				
			}
			if (num1 == 11)
			{
				Location = new Vector3(-741.6118f, -1819.393f, 27.52927f); _SpawnPoint = Location;
				carlocation1 = new Vector3(-742.856f, -1815.758f, 27.26244f); car1head = 33.21858f;
				carlocation2 = new Vector3(-746.8841f, -1812.683f, 27.3811f); car2head = 79.74023f;

				Location2 = new Vector3(-746.9338f, -1815.598f, 27.63414f); ped1head = 220.1994f;
				Location3 = new Vector3(-745.7457f, -1816.789f, 27.58076f); ped2head = 44.4084f;
				audioradio = "ACCIDENTE_11";
				audioradio = "CITIZENS_REPORT_01 CRIME_MOTOR_VEHICLE_ACCIDENT_01 OP_ON_A AREA_LOS_SANTOS_FREEWAY_01";

				ubicacion = "E9";
				pk = "2 500, SENTIDO CRECIENTE";
				
			}
			if (num1 == 12)
			{
				Location = new Vector3(237.8268f, -2725.717f, 17.78662f); _SpawnPoint = Location;
				carlocation1 = new Vector3(237.3698f, -2726.305f, 17.33535f); car1head = 152.3017f;
				carlocation2 = new Vector3(234.2604f, -2731.302f, 17.08628f); car2head = 144.5211f;

				Location2 = new Vector3(234.6719f, -2725.985f, 17.8932f); ped1head = 146.5124f;
				Location3 = new Vector3(233.691f, -2727.766f, 17.82101f); ped2head = 340.4436f;
				audioradio = "ACCIDENTE_12";
				audioradio = "CITIZENS_REPORT_01 CRIME_MOTOR_VEHICLE_ACCIDENT_01 OP_ON_A AREA_LOS_SANTOS_FREEWAY_01";

				ubicacion = "E5";
				pk = "2 900, SENTIDO CRECIENTE";
				
			}
			if (num1 == 13)
			{
				Location = new Vector3(1274.113f, -2130.79f, 47.07907f); _SpawnPoint = Location;
				carlocation1 = new Vector3(1272.803f, -2129.316f, 46.57247f); car1head = 23.55229f;
				carlocation2 = new Vector3(1271.058f, -2124.394f, 46.35781f); car2head = 21.59409f;

				Location2 = new Vector3(1269.637f, -2127.445f, 47.03806f); ped1head = 202.4217f;
				Location3 = new Vector3(1270.065f, -2129.161f, 47.11293f); ped2head = 20.57445f;
				audioradio = "ACCIDENTE_13";
				audioradio = "CITIZENS_REPORT_01 CRIME_MOTOR_VEHICLE_ACCIDENT_01 OP_ON_A AREA_LOS_SANTOS_FREEWAY_01";

				ubicacion = "E5";
				pk = "3 900, SENTIDO CRECIENTE";
				
			}
			if (num1 == 14)
			{
				Location = new Vector3(1904.182f, 3612.319f, 34.12133f); _SpawnPoint = Location;
				carlocation1 = new Vector3(1877.376f, 3603.735f, 33.94784f); car1head = 297.2523f;
				carlocation2 = new Vector3(1887.39f, 3608.35f, 33.84007f); car2head = 294.3773f;

				Location2 = new Vector3(1896.92f, 3607.986f, 34.19093f); ped1head = 226.6558f;
				Location3 = new Vector3(1899.914f, 3609.1f, 34.17053f); ped2head = 181.071f;
				audioradio = "CITIZENS_REPORT_01 CRIME_MOTOR_VEHICLE_ACCIDENT_01 OP_ON_A AREA_LOS_SANTOS_FREEWAY_01";

				ubicacion = "A1";
				pk = "16 900, SENTIDO CRECIENTE";
				
			}
			if (num1 == 15)
			{
				Location = new Vector3(1361.854f, 3593.646f, 34.91549f); _SpawnPoint = Location;
				carlocation1 = new Vector3(1349.914f, 3585.67f, 34.53592f); car1head = 17.53415f;
				carlocation2 = new Vector3(1346.883f, 3593.691f, 34.48555f); car2head = 17.7734f;

				Location2 = new Vector3(1353.345f, 3601.064f, 34.86912f); ped1head = 96.3914f;
				Location3 = new Vector3(1351.711f, 3605.623f, 34.71163f); ped2head = 156.2174f;
				audioradio = "CITIZENS_REPORT_01 CRIME_MOTOR_VEHICLE_ACCIDENT_01 OP_ON_A AREA_LOS_SANTOS_FREEWAY_01";

				ubicacion = "A6";
				pk = "21 900, SENTIDO DECRECIENTE";
			}
			if (num1 == 16)
			{
				Location = new Vector3(3.614302f, 2800.757f, 57.74994f); _SpawnPoint = Location;
				carlocation1 = new Vector3(3.143644f, 2794.057f, 57.66132f); car1head = 59.70987f;
				carlocation2 = new Vector3(-7.088728f, 2799.51f, 57.29664f); car2head = 62.82599f;

				Location2 = new Vector3(0.4969144f, 2797.78f, 57.81258f); ped1head = 145.4205f;
				Location3 = new Vector3(-5.996611f, 2801.888f, 57.54457f); ped2head = 147.8676f;
				audioradio = "CITIZENS_REPORT_01 CRIME_MOTOR_VEHICLE_ACCIDENT_01 OP_ON_A AREA_LOS_SANTOS_FREEWAY_01";

				ubicacion = "A2";
				pk = "12 900, SENTIDO CRECIENTE";
			}
			if (num1 == 17)
			{
				Location = new Vector3(-1512.081f, 2137.803f, 55.99016f); _SpawnPoint = Location;
				carlocation1 = new Vector3(-1515.391f, 2129.609f, 55.83464f); car1head = 160.7579f;
				carlocation2 = new Vector3(-1507.901f, 2140.765f, 55.71144f); car2head = 138.6135f;

				Location2 = new Vector3(-1515.13f, 2138.44f, 56.15118f); ped1head = 188.3834f;
				Location3 = new Vector3(-1509.678f, 2144.323f, 56.20976f); ped2head = 208.731f;
				audioradio = "CITIZENS_REPORT_01 CRIME_MOTOR_VEHICLE_ACCIDENT_01 OP_ON_A AREA_LOS_SANTOS_FREEWAY_01";

				ubicacion = "E1";
				pk = "2 900";
			}
		}
		
		public void Ped_Generator() {
			P1 = new Ped(Utiles.PedModels1[new Random().Next((int)Utiles.PedModels1.Length)], Location2, ped1head);
			P2 = new Ped(Utiles.PedModels2[new Random().Next((int)Utiles.PedModels1.Length)], Location3, ped2head);
		}

		public void Veh_Generator() {
			Random rndVEH1 = new Random();
			int caseSwitchVEH1 = rndVEH1.Next(1, 10);
			Random rndVEH2 = new Random();
			int caseSwitchVEH2 = rndVEH2.Next(11, 20);

			switch (caseSwitchVEH1)
			{
				case 1:
					VEH1 = new Vehicle(Utiles.VehModels1[new Random().Next((int)Utiles.VehModels1.Length)], carlocation1, car1head);
					break;
				case 2:
					VEH1 = new Vehicle(Utiles.modelomotos[new Random().Next((int)Utiles.modelomotos.Length)], carlocation1, car1head);
					break;
				case 3:
					VEH1 = new Vehicle(Utiles.VehModels1[new Random().Next((int)Utiles.VehModels1.Length)], carlocation1, car1head);
					break;
				case 4:
					VEH1 = new Vehicle(Utiles.modelomotos[new Random().Next((int)Utiles.modelomotos.Length)], carlocation1, car1head);
					break;
				case 5:
					VEH1 = new Vehicle(Utiles.VehModels1[new Random().Next((int)Utiles.VehModels1.Length)], carlocation1, car1head);
					break;
				case 6:
					VEH1 = new Vehicle(Utiles.modelomotos[new Random().Next((int)Utiles.modelomotos.Length)], carlocation1, car1head);
					break;
				case 7:
					VEH1 = new Vehicle(Utiles.VehModels1[new Random().Next((int)Utiles.VehModels1.Length)], carlocation1, car1head);
					break;
				case 8:
					VEH1 = new Vehicle(Utiles.modelomotos[new Random().Next((int)Utiles.modelomotos.Length)], carlocation1, car1head);
					break;
				case 9:
					VEH1 = new Vehicle(Utiles.modelocamion[new Random().Next((int)Utiles.modelocamion.Length)], carlocation1, car1head);
					break;
				case 10:
					VEH1 = new Vehicle(Utiles.modelotractor[new Random().Next((int)Utiles.modelotractor.Length)], carlocation1, car1head);
					break;
				default:

					break;
			}
			switch (caseSwitchVEH2)
			{
				case 11:
					VEH2 = new Vehicle(Utiles.VehModels2[new Random().Next((int)Utiles.VehModels2.Length)], carlocation2, car2head);
					break;
				case 12:
					VEH2 = new Vehicle(Utiles.modelomotos2[new Random().Next((int)Utiles.modelomotos2.Length)], carlocation2, car2head);
					break;
				case 13:
					VEH2 = new Vehicle(Utiles.VehModels2[new Random().Next((int)Utiles.VehModels2.Length)], carlocation2, car2head);
					break;
				case 14:
					VEH2 = new Vehicle(Utiles.modelomotos2[new Random().Next((int)Utiles.modelomotos2.Length)], carlocation2, car2head);
					break;
				case 15:
					VEH2 = new Vehicle(Utiles.VehModels2[new Random().Next((int)Utiles.VehModels2.Length)], carlocation2, car2head);
					break;
				case 16:
					VEH2 = new Vehicle(Utiles.modelomotos2[new Random().Next((int)Utiles.modelomotos2.Length)], carlocation2, car2head);
					break;
				case 17:
					VEH2 = new Vehicle(Utiles.VehModels2[new Random().Next((int)Utiles.VehModels2.Length)], carlocation2, car2head);
					break;
				case 18:
					VEH2 = new Vehicle(Utiles.modelomotos2[new Random().Next((int)Utiles.modelomotos2.Length)], carlocation2, car2head);
					break;
				case 19:
					VEH2 = new Vehicle(Utiles.modelocamion2[new Random().Next((int)Utiles.modelocamion2.Length)], carlocation2, car2head);
					break;
				case 20:
					VEH2 = new Vehicle(Utiles.modelotractor[new Random().Next((int)Utiles.modelotractor.Length)], carlocation2, car2head);
					break;
				default:

					break;
			}
			LSPD_First_Response.Mod.API.Functions.SetVehicleOwnerName(VEH1, LSPD_First_Response.Mod.API.Functions.GetPersonaForPed(P1).FullName);
			LSPD_First_Response.Mod.API.Functions.SetVehicleOwnerName(VEH2, LSPD_First_Response.Mod.API.Functions.GetPersonaForPed(P2).FullName);

		}

		public void Veh_Settings() {
			//VEHICLE SETTINGS
			VEH1.IsEngineOn = true; VEH2.IsEngineOn = true;
			VEH1.IsPersistent = true; VEH1.MakePersistent(); VEH2.IsPersistent = true; VEH2.MakePersistent();
			P1.IsPersistent = true; P1.BlockPermanentEvents = true; P2.IsPersistent = true; P2.BlockPermanentEvents = true;
			//VEH1.Deform(new Vector3();
			VEH1.Deform(Utiles.DamageCar(VEH1), 5, 100);
			VEH2.Deform(Utiles.DamageCar(VEH2), 5, 100);

			VEH1.IndicatorLightsStatus = VehicleIndicatorLightsStatus.Both;
			VEH2.IndicatorLightsStatus = VehicleIndicatorLightsStatus.Both;
			if (Settings.dificultad > 80)
			{
				VEH1.EngineHealth = MathHelper.GetRandomSingle(0.0f, 390.0f);
				VEH2.EngineHealth = MathHelper.GetRandomSingle(0.0f, 390.0f);
			}
			dam = new Random();
			damage = dam.Next(20, 100);

			dag = new Random();
			deform = dag.Next(40, 80);
			float deformacion = (float)deform;
		}

		public void alcohol_Drugs() {
			alcohol1 = new Random();
			setAlcohol1 = alcohol1.Next(0, 100);

			alcohol2 = new Random();
			setAlcohol2 = alcohol2.Next(0, 100);

			drogas1 = new Random();
			setDrogas1 = drogas1.Next(0, 100);

			drogas2 = new Random();
			setDrogas2 = drogas2.Next(0, 100);

			if (setAlcohol1 > Settings.dificultad)
			{
				StopThePed.API.Functions.setPedAlcoholOverLimit(P1, true);
				drunkAnimsetP1.LoadAndWait();
				P1.MovementAnimationSet = drunkAnimsetP1;
				Rage.Native.NativeFunction.Natives.SET_PED_IS_DRUNK(P1, true);
				p1alcohol = true;
			}
			if (setAlcohol2 > Settings.dificultad)
			{
				StopThePed.API.Functions.setPedAlcoholOverLimit(P2, true);
				drunkAnimsetP2.LoadAndWait();
				P2.MovementAnimationSet = drunkAnimsetP2;
				Rage.Native.NativeFunction.Natives.SET_PED_IS_DRUNK(P2, true);
				p2alcohol = true;
			}

			if (setDrogas1 > Settings.dificultad)
			{
				StopThePed.API.Functions.setPedUnderDrugsInfluence(P1, true);
				drunkAnimsetP1.LoadAndWait();
				P1.MovementAnimationSet = drunkAnimsetP1;
				Rage.Native.NativeFunction.Natives.SET_PED_IS_DRUNK(P1, true);
				p1drogas = true;
			}

			if (setDrogas2 > Settings.dificultad)
			{
				StopThePed.API.Functions.setPedUnderDrugsInfluence(P2, true);
				drunkAnimsetP2.LoadAndWait();
				P2.MovementAnimationSet = drunkAnimsetP2;
				Rage.Native.NativeFunction.Natives.SET_PED_IS_DRUNK(P2, true);
				p2drogas = true;
			}
		}

		
		public override bool OnBeforeCalloutDisplayed()
		{
			//Dificultad de escenario
			Dificultad_Scenario();
			Seleccion_Scenario();

			ShowCalloutAreaBlipBeforeAccepting(_SpawnPoint, 20f);
			CalloutMessage = "~b~COTA:~s~ TENEMOS UN ALPHA CHARLIE"; //ALPHA CHARLIE-->CAR ACCIDENT.
			CalloutPosition = _SpawnPoint;


			Functions.PlayScannerAudioUsingPosition("CITIZENS_REPORT_01", _SpawnPoint);
			return base.OnBeforeCalloutDisplayed();
		}

		public override bool OnCalloutAccepted()
		{
			p1alcohol = false; p2alcohol = false; p1drogas = false; p2drogas = false; ejecute1 = true; ejecute2 = true;
			Ped_Generator();
			Veh_Generator();
			Veh_Settings();
			alcohol_Drugs();
			
			Game.LogTrivial("JUANPOLICE Log: ALPHA CHARLIE Llamada aceptada.");
			Game.DisplayNotification("web_lossantospolicedept", "web_lossantospolicedept", "~w~CONTROLCARRETERAS", "~y~Tenemos un accidente de trafico", "~b~Dispatch:~w~ Alguien llamo al 112, Porque se ha producido un ~g~Accidente~w~ Porfavor~o~Agente~w~. Acuda al accidente y controle la situacion");
			speecher.info_callout_aviso(Settings.indicativo,"ALFA CHARLY", ubicacion, pk, new Random().Next(0,3), new Random().Next(0, 3));



			//BLIP
			_blip = VEH1.AttachBlip();
			_blip.Color = Color.LightBlue;
			_blip.EnableRoute(Color.Yellow);
			return base.OnCalloutAccepted();
		}


		public override void OnCalloutNotAccepted()
		{

			if (P1.Exists()) P1.Delete();
			if (P2.Exists()) P2.Delete();
			if (VEH1.Exists()) VEH1.Delete();
			if (VEH2.Exists()) VEH2.Delete();
			if (_blip.Exists()) _blip.Delete();
			base.OnCalloutNotAccepted();
		}

		private bool notifica_investigacion = true;
		private bool notifica_investigacion_p1 = true;
		private bool notifica_investigacion_p2 = true;

		public override void Process()
		{

			GameFiber.StartNew(delegate
			{
				if (_SpawnPoint.DistanceTo(Game.LocalPlayer.Character) < 25f)
				{

					if (notifica_investigacion) {
						Game.DisplayNotification("web_lossantospolicedept", "web_lossantospolicedept", "~y~On Scene",
							"~r~Car Accident", "Investiga el escenario del accidente.");
						notifica_investigacion = false;
					} 
					if (P1.DistanceTo(Game.LocalPlayer.Character) < 1.5f && Game.IsKeyDown(Settings.Dialog))
					{
						if (p1alcohol == true || p1drogas == true && notifica_investigacion_p1)
						{
							Game.DisplayNotification("INSTINTO: NOTAS QUE LA PERSONA PUEDA ESTAR BAJO LOS EFECTOS");
							notifica_investigacion_p1 = false;
						}


						switch (conversacion)
						{
							case 1:
								try { Rage.Native.NativeFunction.Natives.TASK_TURN_PED_TO_FACE_ENTITY(P1, Game.LocalPlayer.Character, -1); } catch { Game.DisplayNotification("INFORMACION: NO HA PODIDO MIRAR A LA PERSONA"); }
								Game.DisplaySubtitle(conversaciones.CHARLA_OFICIAL_1[new Random().Next((int)conversaciones.CHARLA_OFICIAL_1.Length)]);
								conversacion++;
								break;

							case 2:
								try { Rage.Native.NativeFunction.Natives.TASK_TURN_PED_TO_FACE_ENTITY(P1, Game.LocalPlayer.Character, -1); } catch { Game.DisplayNotification("INFORMACION: NO HA PODIDO MIRAR A LA PERSONA"); }
								if (CallDificultadP1 == 1)
									Game.DisplaySubtitle(conversaciones.CHARLA_P1_1_POSITIVE[new Random().Next((int)conversaciones.CHARLA_P1_1_POSITIVE.Length)]);
								else Game.DisplaySubtitle(conversaciones.CHARLA_P1_1_NEGATIVO[new Random().Next((int)conversaciones.CHARLA_P1_1_NEGATIVO.Length)]);
								conversacion++;
								break;

							case 3:
								try { Rage.Native.NativeFunction.Natives.TASK_TURN_PED_TO_FACE_ENTITY(P1, Game.LocalPlayer.Character, -1); } catch { Game.DisplayNotification("INFORMACION: NO HA PODIDO MIRAR A LA PERSONA"); }
								if (CallDificultadP1 == 1)
									Game.DisplaySubtitle(conversaciones.CHARLA_P1_2_POSITIVE[new Random().Next((int)conversaciones.CHARLA_P1_2_POSITIVE.Length)]);
								else Game.DisplaySubtitle(conversaciones.CHARLA_P1_2_NEGATIVO[new Random().Next((int)conversaciones.CHARLA_P1_2_NEGATIVO.Length)]);

								conversacion++;
								break;
							case 4:
								try { Rage.Native.NativeFunction.Natives.TASK_TURN_PED_TO_FACE_ENTITY(P1, Game.LocalPlayer.Character, -1); } catch { Game.DisplayNotification("INFORMACION: NO HA PODIDO MIRAR A LA PERSONA"); }
								if (CallDificultadP1 == 1)
									Game.DisplaySubtitle(conversaciones.CHARLA_OFICIAL_2_POSITIVE[new Random().Next((int)conversaciones.CHARLA_OFICIAL_2_POSITIVE.Length)]);
								else Game.DisplaySubtitle(conversaciones.CHARLA_OFICIAL_2_NEGATIVO[new Random().Next((int)conversaciones.CHARLA_OFICIAL_2_NEGATIVO.Length)]);

								conversacion++;
								break;
							case 5:
								Game.DisplaySubtitle("~y~EN FUNCION A LOS DATOS RECIBIDOS, DEBERAS TOMAR DECISIONES~w~", 5000);
								conversacion++;
								break;
							default:
								break;

						}

					}

					if (P2.DistanceTo(Game.LocalPlayer.Character) < 1.5f && Game.IsKeyDown(Settings.Dialog))
					{
						if (p2alcohol == true || p2drogas == true && notifica_investigacion_p2)
						{
							Game.DisplayNotification("INSTINTO: NOTAS QUE LA PERSONA PUEDA ESTAR BAJO LOS EFECTOS");
							notifica_investigacion_p2 = false;
						}
						switch (conversacion2)
						{
							case 1:
								try { Rage.Native.NativeFunction.Natives.TASK_TURN_PED_TO_FACE_ENTITY(P2, Game.LocalPlayer.Character, -1); } catch { Game.DisplayNotification("INFORMACION: NO HA PODIDO MIRAR A LA PERSONA"); }
								Game.DisplaySubtitle(conversaciones.CHARLA_OFICIAL_1[new Random().Next((int)conversaciones.CHARLA_OFICIAL_1.Length)]);
								conversacion2++;
								break;

							case 2:
								try { Rage.Native.NativeFunction.Natives.TASK_TURN_PED_TO_FACE_ENTITY(P2, Game.LocalPlayer.Character, -1); } catch { Game.DisplayNotification("INFORMACION: NO HA PODIDO MIRAR A LA PERSONA"); }
								if (CallDificultadP2 == 1)
									Game.DisplaySubtitle(conversaciones.CHARLA_P2_1_POSITIVE[new Random().Next((int)conversaciones.CHARLA_P2_1_POSITIVE.Length)]); //, 5000
								else Game.DisplaySubtitle(conversaciones.CHARLA_P2_1_NEGATIVO[new Random().Next((int)conversaciones.CHARLA_P2_1_NEGATIVO.Length)]);
								conversacion2++;

								break;

							case 3:
								try { Rage.Native.NativeFunction.Natives.TASK_TURN_PED_TO_FACE_ENTITY(P2, Game.LocalPlayer.Character, -1); } catch { Game.DisplayNotification("INFORMACION: NO HA PODIDO MIRAR A LA PERSONA"); }
								if (CallDificultadP2 == 1)
									Game.DisplaySubtitle(conversaciones.CHARLA_P2_2_POSITIVE[new Random().Next((int)conversaciones.CHARLA_P2_2_POSITIVE.Length)]);
								else Game.DisplaySubtitle(conversaciones.CHARLA_P2_2_NEGATIVO[new Random().Next((int)conversaciones.CHARLA_P2_2_NEGATIVO.Length)]);

								conversacion2++;
								break;
							case 4:
								try { Rage.Native.NativeFunction.Natives.TASK_TURN_PED_TO_FACE_ENTITY(P2, Game.LocalPlayer.Character, -1); } catch { Game.DisplayNotification("INFORMACION: NO HA PODIDO MIRAR A LA PERSONA"); }
								if (CallDificultadP2 == 1)
									Game.DisplaySubtitle(conversaciones.CHARLA_OFICIAL_2_POSITIVE[new Random().Next((int)conversaciones.CHARLA_OFICIAL_2_POSITIVE.Length)]);
								else Game.DisplaySubtitle(conversaciones.CHARLA_OFICIAL_2_NEGATIVO[new Random().Next((int)conversaciones.CHARLA_OFICIAL_2_NEGATIVO.Length)]);

								conversacion2++;
								break;
							case 5:
								Game.DisplaySubtitle("~y~EN FUNCION A LOS DATOS RECIBIDOS, DEBERAS TOMAR DECISIONES~w~", 5000);
								conversacion2++;
								break;
							default:
								break;
						}

					}
				}
				if (Game.IsKeyDown(Settings.EndCall)) End();
				if (Game.LocalPlayer.Character.IsDead) End();
			}, "RoadAccident[JP]");

			base.Process();
		}

		public override void End()
		{
			VehicleDrivingFlags driveFlagsveh1 = VehicleDrivingFlags.Normal;
			VehicleDrivingFlags driveFlagsveh2 = VehicleDrivingFlags.Normal;
			if (VEH1.DistanceTo(Game.LocalPlayer.Character) < 50f || VEH2.DistanceTo(Game.LocalPlayer.Character) < 50f || P1.DistanceTo(Game.LocalPlayer.Character) < 50f || P2.DistanceTo(Game.LocalPlayer.Character) < 50f) {
				if (P1.Exists() && VEH1.Exists() && P2.Exists() && VEH2.Exists())
				{
					Rage.Native.NativeFunction.Natives.TASK_ENTER_VEHICLE(P1, VEH1, -1f, 0f, 1.0f, 1f, 0f);
					P1.Tasks.CruiseWithVehicle(VEH1, 50.0f, driveFlagsveh1);
					P1.Dismiss();
					Rage.Native.NativeFunction.Natives.TASK_ENTER_VEHICLE(P2, VEH2, -1f, -1f, 1.0f, 1f, 0f);
					P2.Tasks.CruiseWithVehicle(VEH2, 50.0f, driveFlagsveh2);
					P2.Dismiss();
				}
				else if (P1.Exists() && VEH1.Exists())
				{
					Rage.Native.NativeFunction.Natives.TASK_ENTER_VEHICLE(P1, VEH1, -1f, 0f, 1.0f, 1f, 0f);
					P1.Tasks.CruiseWithVehicle(VEH1, 50.0f, driveFlagsveh1);
					P1.Dismiss();

				}
				else if (P2.Exists() && VEH2.Exists())
				{
					Rage.Native.NativeFunction.Natives.TASK_ENTER_VEHICLE(P2, VEH2, -1f, -1f, 1.0f, 1f, 0f);
					P2.Tasks.CruiseWithVehicle(VEH2, 50.0f, driveFlagsveh2);
					P2.Dismiss();
				}
				else if (P1.Exists() && !VEH1.Exists())
				{
					P1.Dismiss();
				}
				else if (P2.Exists() && !VEH2.Exists())
				{
					P1.Dismiss();
				}
				else if (VEH1.Exists() && !P1.Exists())
				{
					VEH1.Delete();
				}
				else if (VEH2.Exists() && !P2.Exists())
				{
					VEH2.Delete();
				}
			} else {
				if (P1) P1.Delete();
				if (P2) P2.Delete();
				if (VEH1) VEH1.Delete();
				if (VEH2) VEH2.Delete();
				if (_blip) _blip.Delete();
			}


			if (P1) P1.Dismiss();
			if (P2) P2.Dismiss();
			if (VEH1) VEH1.Dismiss();
			if (VEH2) VEH2.Dismiss();
			if (_blip) _blip.Delete();

			Game.DisplayNotification("web_lossantospolicedept", "web_lossantospolicedept", "~w~UnitedCallouts", "~y~WelfareCheck", "~b~You: ~w~Dispatch we're code 4. Show me ~g~10-8.");
			Functions.PlayScannerAudio("ATTENTION_THIS_IS_DISPATCH_HIGH WE_ARE_CODE FOUR NO_FURTHER_UNITS_REQUIRED");
			base.End();
		}

	}
}

