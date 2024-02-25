using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrownEditor.editor
{
    public partial class wild : Form
    {
        public static int WildPointerTableOffset = 0xCEEB;
        public static int WildEncounterBank = 0x03;
        public static int totalMaps = 247; //Start at map 0

        private List<ComboBox> LandComboBoxes = new List<ComboBox>();
        private List<NumericUpDown> LandLevels = new List<NumericUpDown>();
        private List<ComboBox> SurfComboBoxes = new List<ComboBox>();
        private List<NumericUpDown> SurfLevels = new List<NumericUpDown>();

        private byte[] WildEncounterBuffer;
        public wild()
        {
            InitializeComponent();

            //Make a copy of the whole ROM, we'll be editing that copy
            WildEncounterBuffer = MainForm.filebuffer.ToArray();

            //Build lists (probably the list can be hardcoded....)
            LandComboBoxes.Add(landBox0);
            LandComboBoxes.Add(landBox1);
            LandComboBoxes.Add(landBox2);
            LandComboBoxes.Add(landBox3);
            LandComboBoxes.Add(landBox4);
            LandComboBoxes.Add(landBox5);
            LandComboBoxes.Add(landBox6);
            LandComboBoxes.Add(landBox7);
            LandComboBoxes.Add(landBox8);
            LandComboBoxes.Add(landBox9);
            LandLevels.Add(landLvl0);
            LandLevels.Add(landLvl1);
            LandLevels.Add(landLvl2);
            LandLevels.Add(landLvl3);
            LandLevels.Add(landLvl4);
            LandLevels.Add(landLvl5);
            LandLevels.Add(landLvl6);
            LandLevels.Add(landLvl7);
            LandLevels.Add(landLvl8);
            LandLevels.Add(landLvl9);

            SurfComboBoxes.Add(surfBox0);
            SurfComboBoxes.Add(surfBox1);
            SurfComboBoxes.Add(surfBox2);
            SurfComboBoxes.Add(surfBox3);
            SurfComboBoxes.Add(surfBox4);
            SurfComboBoxes.Add(surfBox5);
            SurfComboBoxes.Add(surfBox6);
            SurfComboBoxes.Add(surfBox7);
            SurfComboBoxes.Add(surfBox8);
            SurfComboBoxes.Add(surfBox9);
            SurfLevels.Add(surfLvl0);
            SurfLevels.Add(surfLvl1);
            SurfLevels.Add(surfLvl2);
            SurfLevels.Add(surfLvl3);
            SurfLevels.Add(surfLvl4);
            SurfLevels.Add(surfLvl5);
            SurfLevels.Add(surfLvl6);
            SurfLevels.Add(surfLvl7);
            SurfLevels.Add(surfLvl8);
            SurfLevels.Add(surfLvl9);

            //Populate fields
            mapBox.Items.AddRange(BrownEditor.editor.evomoves.brownMaps);
            int i = 0;
            for (i=0;i<10;i++)
            {
                LandComboBoxes[i].Items.AddRange(brownWildSpecies);
                SurfComboBoxes[i].Items.AddRange(brownWildSpecies);
            }

            //Load Map 0 encounters
            mapBox.SelectedIndex = 0;
        }

        private void findMapwithEncounters(bool nextmap)
        {
            int curMap = mapBox.SelectedIndex;
            bool mapFound = false;

            //Let's loop through all maps until map index 0
            while (true)
            {
                if (nextmap)
                {
                    curMap++;
                }
                else
                {
                    curMap--;
                }
                //If no maps are found (or we are at map -1) break and do nothing  
                if (curMap < 0)
                {
                    MessageBox.Show("No previous maps with encounters found");
                    break;
                }
                if (curMap > totalMaps)
                {
                    MessageBox.Show("No next maps with encounters found");
                    break;
                }

                //Get pointer for the map to check
                UInt16 u16pointer = BitConverter.ToUInt16(WildEncounterBuffer, WildPointerTableOffset + (2 * curMap));
                int encounterPointer = MainForm.ThreeByteToTwoByte(WildEncounterBank, u16pointer);
                //Process the data
                //Check first byte for land encounters
                if (WildEncounterBuffer[encounterPointer] == 0)//No land encounters
                {
                    if (WildEncounterBuffer[encounterPointer+1] != 0)//No land but surf encounters
                    {
                        mapFound = true;
                        break;
                    }
                }
                else //Map has land encounters
                {
                    mapFound = true;
                    break;
                }
            }
            //If we found a map with encounters load it
            if (mapFound)
            {
                mapBox.SelectedIndex = curMap;
            }

            return;
        }
        private void loadEncounters(int map)
        {
            int curByte = 0;
            //Get encounter table for this map
            UInt16 u16pointer = BitConverter.ToUInt16(WildEncounterBuffer, WildPointerTableOffset + (2 * map));

            int encounterPointer = MainForm.ThreeByteToTwoByte(WildEncounterBank, u16pointer);

            //Process Data
            //Land encounters
            if (WildEncounterBuffer[encounterPointer + curByte] == 0)//No land encounters
            {
                //Disable land encounters
                landGroupBox.Enabled = false;
                curByte++;
            }
            else //There are land encounters
            {
                landGroupBox.Enabled = true;
                //Encounter rate
                landEncRate.Value = WildEncounterBuffer[encounterPointer + curByte];
                curByte++;
                //Encounters
                int i = 0;
                for (i=0; i<10; i++)
                {
                    //Level
                    if (WildEncounterBuffer[encounterPointer + curByte] < 1 || WildEncounterBuffer[encounterPointer + curByte] > 100)
                    {
                        MessageBox.Show("Land Slot #" + i.ToString() + " contains invalid level: " + WildEncounterBuffer[encounterPointer + curByte].ToString()+
                                        "\n\nSetting value to 5");
                        LandLevels[i].Value = 5;
                    }
                    else
                    {
                        LandLevels[i].Value = WildEncounterBuffer[encounterPointer + curByte];
                    }
                    curByte++;

                    //Species
                    if (WildEncounterBuffer[encounterPointer + curByte] > 199)
                    {
                        MessageBox.Show("Land Slot #" + i.ToString() + " contains invalid species: " + WildEncounterBuffer[encounterPointer + curByte].ToString() +
                                        "\n\nWild Species can't be >199. Setting value to 1 (Rhydon)");
                        LandComboBoxes[i].SelectedIndex = 0;//Rhydon is index 1, but on the list it's index 0
                    }
                    else
                    {
                        LandComboBoxes[i].SelectedIndex = WildEncounterBuffer[encounterPointer + curByte]-1;//Deduct 1 since the list starts with rhydon, which is species 1
                    }
                    curByte++;
                }
            }

            //Surf encounters
            if (WildEncounterBuffer[encounterPointer + curByte] == 0)//No surf encounters
            {
                //Disable surf encounters
                surfGroupBox.Enabled = false;
                curByte++;
            }
            else //There are surf encounters
            {
                surfGroupBox.Enabled = true;
                //Encounter rate
                surfEncRate.Value = WildEncounterBuffer[encounterPointer + curByte];
                curByte++;
                //Encounters
                int i = 0;
                for (i = 0; i < 10; i++)
                {
                    //Level
                    if (WildEncounterBuffer[encounterPointer + curByte] < 1 || WildEncounterBuffer[encounterPointer + curByte] > 100)
                    {
                        MessageBox.Show("Surf Slot #" + i.ToString() + " contains invalid level: " + WildEncounterBuffer[encounterPointer + curByte].ToString() +
                                        "\n\nSetting value to 5");
                        SurfLevels[i].Value = 5;
                    }
                    else
                    {
                        SurfLevels[i].Value = WildEncounterBuffer[encounterPointer + curByte];
                    }
                    curByte++;

                    //Species
                    if (WildEncounterBuffer[encounterPointer + curByte] > 199)
                    {
                        MessageBox.Show("Surf Slot #" + i.ToString() + " contains invalid species: " + WildEncounterBuffer[encounterPointer + curByte].ToString() +
                                        "\n\nWild Species can't be >199. Setting value to 1 (Rhydon)");
                        SurfComboBoxes[i].SelectedIndex = 0;//Rhydon is index 1, but on the list it's index 0
                    }
                    else
                    {
                        SurfComboBoxes[i].SelectedIndex = WildEncounterBuffer[encounterPointer + curByte] - 1;//Deduct 1 since the list starts with rhydon, which is species 1
                    }
                    curByte++;
                }
            }
            if (landGroupBox.Enabled == false && surfGroupBox.Enabled == false)
            {
                saveBut.Enabled = false;
            }
            else
            {
                saveBut.Enabled = true;
            }

            return;

        }

        private void exitBut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string[] brownWildSpecies =
{
            "Rhydon",
            "Kangaskhan",
            "NidoranM",
            "Clefairy",
            "Spearow",
            "Voltorb",
            "Nidoking",
            "Slowbro",
            "Ivysaur",
            "Exeggutor",
            "Lickitung",
            "Exeggcute",
            "Grimer",
            "Gengar",
            "NidoranF",
            "Nidoqueen",
            "Cubone",
            "Rhyhorn",
            "Lapras",
            "Arcanine",
            "Mew",
            "Gyarados",
            "Shellder",
            "Tentacool",
            "Gastly",
            "Scyther",
            "Staryu",
            "Blastoise",
            "Pinsir",
            "Tangela",
            "Chikorita",
            "Bayleef",
            "Growlithe",
            "Onix",
            "Fearow",
            "Pidgey",
            "Slowpoke",
            "Kadabra",
            "Graveler",
            "Chansey",
            "Machoke",
            "Mr. Mime",
            "Hitmonlee",
            "Hitmonchan",
            "Arbok",
            "Parasect",
            "Psyduck",
            "Drowzee",
            "Golem",
            "Cranidos",
            "Magmar",
            "Pupitar",
            "Electabuzz",
            "Magneton",
            "Koffing",
            "Cyndaquil",
            "Mankey",
            "Seel",
            "Diglett",
            "Tauros",
            "Quilava",
            "Typhlosion",
            "Totodile",
            "Farfetch'd",
            "Venonat",
            "Dragonite",
            "Croconaw",
            "Feraligatr",
            "Houndour",
            "Doduo",
            "Poliwag",
            "Jynx",
            "Moltres",
            "Articuno",
            "Zapdos",
            "Ditto",
            "Meowth",
            "Krabby",
            "Houndoom",
            "Heracross",
            "Yanma",
            "Vulpix",
            "Ninetales",
            "Pikachu",
            "Raichu",
            "Rampardos",
            "Sneasel",
            "Dratini",
            "Dragonair",
            "Kabuto",
            "Kabutops",
            "Horsea",
            "Seadra",
            "Spinarak",
            "Ariados",
            "Sandshrew",
            "Sandslash",
            "Omanyte",
            "Omastar",
            "Jigglypuff",
            "Wigglytuff",
            "Eevee (Espeon)",
            "Flareon",
            "Jolteon",
            "Vaporeon",
            "Machop",
            "Zubat",
            "Ekans",
            "Paras",
            "Poliwhirl",
            "Poliwrath",
            "Weedle",
            "Kakuna",
            "Beedrill",
            "Raikou",
            "Dodrio",
            "Primeape",
            "Dugtrio",
            "Venomoth",
            "Dewgong",
            "Chinchou",
            "Lanturn",
            "Caterpie",
            "Metapod",
            "Butterfree",
            "Machamp",
            "Swinub",
            "Golduck",
            "Hypno",
            "Golbat",
            "Mewtwo",
            "Snorlax",
            "Magikarp",
            "Piloswine",
            "Tyrogue (Hitmonchan)",
            "Muk",
            "Suicune",
            "Kingler",
            "Cloyster",
            "Tyrogue (Hitmonlee)",
            "Electrode",
            "Clefable",
            "Weezing",
            "Persian",
            "Marowak",
            "Tyrogue (Hitmontop)/Noibat",
            "Haunter",
            "Abra",
            "Alakazam",
            "Pidgeotto",
            "Pidgeot",
            "Starmie",
            "Bulbasaur",
            "Venusaur",
            "Tentacruel",
            "Natu",
            "Goldeen",
            "Seaking",
            "Xatu",
            "Mareep",
            "Flaaffy",
            "Entei",
            "Ponyta",
            "Rapidash",
            "Rattata",
            "Raticate",
            "Nidorino",
            "Nidorina",
            "Geodude",
            "Porygon",
            "Aerodactyl",
            "Gligar",
            "Magnemite",
            "Marill",
            "Azumarill",
            "Charmander",
            "Squirtle",
            "Charmeleon",
            "Wartortle",
            "Charizard",
            "Murkrow",
            "Ghost (MissingNo.)",
            "Misdreavus",
            "Larvitar",
            "Oddish",
            "Gloom",
            "Vileplume",
            "Bellsprout",
            "Weepinbell",
            "Victreebel",
            "Phanpy",
            "Donphan",
            "Togepi",
            "Togetic",
            "Wooper",
            "Quagsire",
            "Espeon",
            "Umbreon",
            "Eevee (Umbreon)",
        };

        private void mapBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadEncounters(mapBox.SelectedIndex);
        }

        private void prevMapBut_Click(object sender, EventArgs e)
        {
            findMapwithEncounters(false);
        }

        private void nextMapBut_Click(object sender, EventArgs e)
        {
            findMapwithEncounters(true);
        }

        private void saveBut_Click(object sender, EventArgs e)
        {
            int curByte = 0;
            int map = mapBox.SelectedIndex;
            //Get encounter table pointer for this map
            UInt16 u16pointer = BitConverter.ToUInt16(WildEncounterBuffer, WildPointerTableOffset + (2 * map));

            int encounterPointer = MainForm.ThreeByteToTwoByte(WildEncounterBank, u16pointer);

            //Start storing data
            //Land encounters
            if (landGroupBox.Enabled)
            {
                //Encounter rate
                WildEncounterBuffer[encounterPointer + curByte] = (byte) landEncRate.Value;
                curByte++;
                //Encounter table
                int i = 0;
                for (i=0;i<10;i++)
                {
                    //Level
                    WildEncounterBuffer[encounterPointer + curByte] = (byte)(LandLevels[i].Value);//Need to add +1 due to the box list starting with rhydon
                    curByte++;
                    //Species
                    WildEncounterBuffer[encounterPointer + curByte] = (byte) (LandComboBoxes[i].SelectedIndex+1);//Need to add +1 due to the box list starting with rhydon
                    curByte++;
                }
            }
            else //No land encounters
            {
                WildEncounterBuffer[encounterPointer + curByte] = 0x00;
                curByte++;
            }

            //Surf encounters
            if (surfGroupBox.Enabled)
            {
                //Encounter rate
                WildEncounterBuffer[encounterPointer + curByte] = (byte)surfEncRate.Value;
                curByte++;
                //Encounter table
                int i = 0;
                for (i = 0; i < 10; i++)
                {
                    //Level
                    WildEncounterBuffer[encounterPointer + curByte] = (byte)(SurfLevels[i].Value);//Need to add +1 due to the box list starting with rhydon
                    curByte++;
                    //Species
                    WildEncounterBuffer[encounterPointer + curByte] = (byte)(SurfComboBoxes[i].SelectedIndex + 1);//Need to add +1 due to the box list starting with rhydon
                    curByte++;
                }
            }
            else //No surf encounters
            {
                WildEncounterBuffer[encounterPointer + curByte] = 0x00;
                curByte++;
            }

            MessageBox.Show("Encounter tables saved.");
        }

        private void saveExitBut_Click(object sender, EventArgs e)
        {
            //Copy full edited rom with the changes to main buffer
            Buffer.BlockCopy(WildEncounterBuffer, 0, BrownEditor.MainForm.filebuffer, 0, BrownEditor.MainForm.filebuffer.Length);
            this.Close();
        }
    }
}
