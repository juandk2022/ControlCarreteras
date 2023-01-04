using System.Windows.Forms;
using Rage;
using LSPD_First_Response.Mod.API;
using LSPD_First_Response.Mod.Callouts;
using System.Drawing;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;

namespace ControlCarreteras
{
    public class Utiles2
    {
        public Vector3 _Location1;
        public Vector3 _Location2;
        public Vector3 _Location3;
        public Vector3 _Location4;
        public Vector3 _Location5;
        public Vector3 _Location6;
        public Vector3 _Location7;
        public Vector3 _Location8;
        public Vector3 _Location9;
        public Vector3 _Location10;
        public Vector3 _Location11;
        public Vector3 _Location12;
        public Vector3 _Location13;
        public Vector3 _Location14;
        public Vector3 _Location15;
        public Vector3 _Location16;
        public Vector3 _Location17;
        public Vector3 _Location18;
        public Vector3 _Location19;
        public Vector3 _Location20;
        public Vector3 _Location21;
        public Vector3 _Location22;
        public Vector3 _Location23;
        public Vector3 _Location24;
        public Vector3 _Location25;
        public Vector3 _Location26;
        public Vector3 _Location27;
        public Vector3 _Location28;
        public Vector3 _Location29;
        public Vector3 _Location30;
        public Vector3 _SpawnPoint;
        public void Seleccion_Scenario()
        {
            _Location1 = new Vector3(-3006.40942f, 123.192924f, 14.841548f);
            _Location2 = new Vector3(-3026.24585f, 1719.333f, 36.7322464f);
            _Location3 = new Vector3(-2661.93579f, 2281.90845f, 22.1832218f);
            _Location4 = new Vector3(-2642.42944f, 2690.99585f, 16.6941719f);
            _Location5 = new Vector3(-791.103455f, 5472.54639f, 34.09692f);

            _Location6 = new Vector3(1622.69971f, 6379.573f, 28.3513336f);
            _Location7 = new Vector3(2531.106f, 5378.98828f, 44.5416565f);
            _Location8 = new Vector3(2567.608f, 5231.44775f, 44.6897964f);
            _Location9 = new Vector3(2702.20532f, 4700.7627f, 44.300766f);
            _Location10 = new Vector3(2910.03564f, 3832.84619f, 52.5486374f);

            _Location11 = new Vector3(2073.10229f, 2665.64844f, 51.6975937f);
            _Location12 = new Vector3(1755.49329f, 1979.34631f, 70.4648361f);
            _Location13 = new Vector3(1920.37073f, 1745.68958f, 67.43466f);
            _Location14 = new Vector3(2523.3584f, 678.668457f, 103.994743f);
            _Location15 = new Vector3(2523.3584f, 678.668457f, 103.994743f);
            _Location16 = new Vector3(2541.364f, 211.989212f, 106.083336f);

            _Location17 = new Vector3(2341.90259f, -409.615234f, 74.35808f);
            _Location18 = new Vector3(1769.19287f, -845.5263f, 72.72426f);
            _Location19 = new Vector3(1055.90076f, -958.761f, 30.6598034f);
            _Location20 = new Vector3(199.998077f, -486.435028f, 33.9486f);
            _Location21 = new Vector3(-802.2188f, -500.032379f, 25.1209431f);

            _Location22 = new Vector3(-1788.3761f, -597.20105f, 10.9426f);
            _Location23 = new Vector3(-2009.28479f, -458.561554f, 11.48949f);
            _Location24 = new Vector3(-944.1185f, -577.748962f, 18.3778839f);
            _Location25 = new Vector3(-416.0447f, -716.691467f, 37.1836281f);
            _Location26 = new Vector3(-416.1955f, -1192.43176f, 37.1295128f);

            _Location27 = new Vector3(-20.2251167f, -1243.97f, 37.1893234f);
            _Location28 = new Vector3(1040.236f, -1491.61792f, 28.1454f);
            _Location29 = new Vector3(1157.41736f, -1913.43335f, 34.6488152f);

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
    }
}
