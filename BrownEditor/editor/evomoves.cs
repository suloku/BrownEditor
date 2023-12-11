using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace BrownEditor.editor
{
    public partial class evomoves : Form
    {
        public static int EvomovesTotalEntries = 255; //On the current rom there's only room for 243 entries, 232 are currently used
        public static int TotalSpecies = 255; //This should be updated if any new species is added
        public static int EvomovesPointerTableOffset = 0x3bdf9;
        public static int EvomovesDataStartOffset = 0x380a0;
        public static int EvomovesDataSize = 0x1570;
        public static int EvomovesBank = 0xE;

        private static byte NO_EVOLUTION = 0;
        private static byte EV_LEVEL = 1;
        private static byte EV_ITEM = 2;
        private static byte EV_TRADE = 3;
        private static byte EV_GEO = 4;
        private static byte EV_ATTAK = 5;
        private static byte EV_DEFENSE = 6;
        private static byte EV_ATKEQDEF = 7;

        private static byte[] EvoMovePointerTableBuffer = new byte[EvomovesTotalEntries*2];
        private static byte[] EvoMoveDataBuffer = new byte[EvomovesDataSize];
        private static int EvoMovesFreeBytes = 0;

        SPECIESENTRY curEntry = new SPECIESENTRY();
        List<SPECIESENTRY> pokemon = new List<SPECIESENTRY>(EvomovesTotalEntries);
        
        public static MOVENAMEDATA movenamedata;

        public evomoves()
        {
            InitializeComponent();
            //Clear the buffers
            Array.Clear(EvoMovePointerTableBuffer, 0, EvoMovePointerTableBuffer.Length);
            Array.Clear(EvoMoveDataBuffer, 0, EvoMoveDataBuffer.Length);
            ReminderLabel.Text = "Reminder: any move with level 01 will be an\n" +
                                 "\"evolution move\".\n" +
                                 "Evolution moves should be on the evolved\n" +
                                 "species.";
            freespace_text.Text = "Each Evolution uses 3 bytes, except " +
                                  "Item and Geolocation evolutions,\n" +
                                  "which use 4 bytes " +
                                  "Each move uses 2 bytes.";
            movenamedata = new MOVENAMEDATA(BrownEditor.MainForm.filebuffer.Skip(BrownEditor.editor.MoveEditor.MoveNamesOffset).Take(BrownEditor.editor.MoveEditor.MoveNamesSize).ToArray());
            movenamedata.populateNameList();

            //Move name list starts at index 01
            moveLearnBox.Items.Add("No Move");
            moveLearnBox.Items.AddRange(movenamedata.moveNamesList);
            speciesBox.Items.AddRange(brownSpecies);
            speciesBox.Items.RemoveAt(0);
            int i = 0;
            for (i=0; i<EvomovesTotalEntries; i++)
            {
                pokemon.Add(new SPECIESENTRY());
            }
            LoadEvoMoveData();
            speciesBox.SelectedIndex = 0;

            EvoMovesFreeBytes = SaveEvoMoveDataToBuffer();
            freespace.Text = EvoMovesFreeBytes.ToString() + " bytes free";
        }

        //Returns total free bytes after all data is written
        private int SaveEvoMoveDataToBuffer()
        {
            //Clear the buffers
            Array.Clear(EvoMovePointerTableBuffer, 0, EvoMovePointerTableBuffer.Length);
            Array.Clear(EvoMoveDataBuffer, 0, EvoMoveDataBuffer.Length);

            int currentEvoMoveDataOffset = 0;
            int currentPointerTableOffset = 0;
            int newpointer = 0;
            UInt16 currentEvoMovePointer = 0;

            //Write the data
            int i = 0;
            for (i = 0; i < TotalSpecies; i++)
            {
                //Calculate pointer to data
                newpointer = EvomovesDataStartOffset + currentEvoMoveDataOffset;
                currentEvoMovePointer = (UInt16)MainForm.TwoByteOffset(newpointer);
                //Write pointer to table
                Buffer.BlockCopy(BitConverter.GetBytes(currentEvoMovePointer), 0, EvoMovePointerTableBuffer, currentPointerTableOffset, 2);
                //Advance table pointer
                currentPointerTableOffset += 2;

                Debug.WriteLine("Pokemon #"+i.ToString());
                //Evolution data
                int j = 0;
                Debug.WriteLine("\tEvo count:" + pokemon[i].evos.Count().ToString());
                if (pokemon[i].evos.Count() > 0)
                {
                    for (j = 0; j < pokemon[i].evos.Count(); j++)
                    {
                        Debug.WriteLine("\t\tEvo #:" + j.ToString());
                        //Evo method
                        Debug.WriteLine("\t\t\tEvomethod:" + pokemon[i].evos[j].evomethod.ToString());
                        Debug.WriteLine("\t\t\tcurrentEvoMoveDataOffset:" + currentEvoMoveDataOffset.ToString());
                        EvoMoveDataBuffer[currentEvoMoveDataOffset] = (byte)pokemon[i].evos[j].evomethod;
                        currentEvoMoveDataOffset++;

                        //Item and geolocation methods have an extra byte
                        if (pokemon[i].evos[j].evomethod == 2 || pokemon[i].evos[j].evomethod == 4)
                        {
                            EvoMoveDataBuffer[currentEvoMoveDataOffset] = (byte)pokemon[i].evos[j].evoitem_map;
                            currentEvoMoveDataOffset++;
                        }
                        //Evo level
                        EvoMoveDataBuffer[currentEvoMoveDataOffset] = (byte)pokemon[i].evos[j].evolevel;
                        currentEvoMoveDataOffset++;
                        //Evo species
                        EvoMoveDataBuffer[currentEvoMoveDataOffset] = (byte)pokemon[i].evos[j].evospecies;
                        currentEvoMoveDataOffset++;
                    }
                }
                //Finished writing evolution data, write the terminator
                EvoMoveDataBuffer[currentEvoMoveDataOffset] = 0x00;
                currentEvoMoveDataOffset++;

                //Move data
                if (pokemon[i].moves.Count() > 0)
                {
                    for (j = 0; j < pokemon[i].moves.Count(); j++)
                    {
                        //Move level
                        EvoMoveDataBuffer[currentEvoMoveDataOffset] = (byte)pokemon[i].moves[j].level;
                        currentEvoMoveDataOffset++;
                        //Move index
                        EvoMoveDataBuffer[currentEvoMoveDataOffset] = (byte)pokemon[i].moves[j].move;
                        currentEvoMoveDataOffset++;
                    }
                }
                //Finished writing move data, write the terminator
                EvoMoveDataBuffer[currentEvoMoveDataOffset] = 0x00;
                currentEvoMoveDataOffset++;
            }

            return (EvomovesDataSize - currentEvoMoveDataOffset);
        }

        private void LoadEvoMoveData()
        {
            int currentSpecies = 0;
            int currentEntry = 0;
            int dataoffset = EvomovesPointerTableOffset;
            UInt16 u16pointer = 0;
            int absolutepointer = 0;
            
            for (currentSpecies = 0; currentSpecies < EvomovesTotalEntries; currentSpecies++)
            {
                //Get the data offset
                u16pointer = BitConverter.ToUInt16(MainForm.filebuffer, dataoffset+(2*currentSpecies));
                if (u16pointer == 0) break;
                pokemon[currentSpecies].offset = u16pointer;
                absolutepointer = MainForm.ThreeByteToTwoByte(EvomovesBank, u16pointer);
                //absolutepointer now holds the pointer for the evomove data, start to read it
                currentEntry = 0;

                if (u16pointer != 0)//Don't process empty entries from pointer table
                {
                    //Evolution data
                    while (true)
                    {
                        pokemon[currentSpecies].evos.Add(new EVOLUTION());//Add entry
                        pokemon[currentSpecies].evos[currentEntry].evomethod = MainForm.filebuffer[absolutepointer];//read first byte
                        if (MainForm.filebuffer[absolutepointer] == 0x00)//Evolution entry terminator
                        {
                            pokemon[currentSpecies].evos.RemoveAt(currentEntry);//Delete this last entry
                            break;//exit evolution data read loop
                        }
                        //We have an evolution method
                        //check for 4 byte evolution method
                        if (pokemon[currentSpecies].evos[currentEntry].evomethod == EV_ITEM || pokemon[currentSpecies].evos[currentEntry].evomethod == EV_GEO)
                        {
                            //item/map for the evolution
                            absolutepointer += 1;
                            pokemon[currentSpecies].evos[currentEntry].evoitem_map = MainForm.filebuffer[absolutepointer];
                        }
                        //The following data is common
                        //minimum evo level
                        absolutepointer += 1;
                        pokemon[currentSpecies].evos[currentEntry].evolevel = MainForm.filebuffer[absolutepointer];
                        //species to evolve into
                        absolutepointer += 1;
                        pokemon[currentSpecies].evos[currentEntry].evospecies = MainForm.filebuffer[absolutepointer];

                        //advance to next byte and check next entry
                        absolutepointer += 1;
                        currentEntry += 1;
                    }
                    //At this point absolutepointer is at the learnset data
                    currentEntry = 0; //Reset
                    absolutepointer += 1;//Advance to learnset
                                         //Learnset data
                    while (true)
                    {
                        pokemon[currentSpecies].moves.Add(new LEARNSET());//Add entry
                        pokemon[currentSpecies].moves[currentEntry].level = MainForm.filebuffer[absolutepointer];//read first byte
                        if (MainForm.filebuffer[absolutepointer] == 0x00)//Learnset entry terminator
                        {
                            pokemon[currentSpecies].moves.RemoveAt(currentEntry);//Delete this last entry
                            break; //exit learnset entry read loop
                        }
                        //read move
                        absolutepointer += 1;
                        pokemon[currentSpecies].moves[currentEntry].move = MainForm.filebuffer[absolutepointer];

                        //advance to next byte and check next entry
                        absolutepointer += 1;
                        currentEntry += 1;
                    }
                }
            }
        }

        private void FillEvoMoveData(int index)
        {
            evosGrid.Rows.Clear();
            learnsetGrid.Rows.Clear();
            if (pokemon[index].offset == 0) //If pointer table has offset set as 0 assume there's no evomove data set
            {
                MessageBox.Show("Selected entry has no pointer set for evomoves (probably an empty slot)");
                evoSpeciesBox.SelectedIndex = 1;
            }
            else
            {
                if (pokemon[index].evos.Count()>0)
                {
                    evosGrid.Rows.Add(pokemon[index].evos.Count());//add rows for each evo entry

                    int i = 0;
                    for (i = 0; i < pokemon[index].evos.Count(); i++)
                    {
                        //This should never happen as an evo method 0x00 should not be read from the rom since that's the terminator...
                        if (pokemon[index].evos[i].evomethod == NO_EVOLUTION)
                        {
                            //evosGrid.Rows[i].Cells[0].Value = i.ToString();
                            //evosGrid.Rows[i].Cells[1].Value = evoMethodList[pokemon[index].evos[i].evomethod];
                            if (i == 0) evosGrid.Rows[i].Cells[0].Value = "No entries";
                            else evosGrid.Rows.RemoveAt(i);
                            break;
                        }
                        evosGrid.Rows[i].Cells[0].Value = i.ToString();
                        evosGrid.Rows[i].Cells[1].Value = evoMethodList[pokemon[index].evos[i].evomethod];
                        evosGrid.Rows[i].Cells[2].Value = pokemon[index].evos[i].evolevel.ToString();
                        evosGrid.Rows[i].Cells[3].Value = brownSpecies[pokemon[index].evos[i].evospecies];
                        if (pokemon[index].evos[i].evomethod == EV_ITEM)
                        {
                            evosGrid.Rows[i].Cells[4].Value = brownItems[pokemon[index].evos[i].evoitem_map];
                            evosGrid.Rows[i].Cells[4].Style.BackColor = Color.White;
                        }
                        else if (pokemon[index].evos[i].evomethod == EV_GEO)
                        {
                            evosGrid.Rows[i].Cells[4].Value = brownMaps[pokemon[index].evos[i].evoitem_map];
                            evosGrid.Rows[i].Cells[4].Style.BackColor = Color.White;
                        }
                        else
                        {
                            evosGrid.Rows[i].Cells[4].Value = "";
                            evosGrid.Rows[i].Cells[4].Style.BackColor = Color.LightGray;
                        }
                    }
                }
                else if (pokemon[index].evos.Count() == 0)
                {
                    evosGrid.Rows.Add(1);
                    evosGrid.Rows[0].Cells[0].Value = "No entries";
                }

                //learnset data
                if (pokemon[index].moves.Count()>0)
                {
                    learnsetGrid.Rows.Add(pokemon[index].moves.Count());//add rows for each evo entry
                    int i = 0;
                    for (i = 0; i < pokemon[index].moves.Count(); i++)
                    {
                        //This should never happen as there should be no move with level 0x00 as that is the terminator
                        if (pokemon[index].moves[i].level == 0)
                        {
                            //MessageBox.Show(i.ToString());
                            if (i == 0) learnsetGrid.Rows[i].Cells[0].Value = "No entries";
                            else learnsetGrid.Rows.RemoveAt(i);
                            break;
                        }
                        learnsetGrid.Rows[i].Cells[0].Value = i.ToString();
                        learnsetGrid.Rows[i].Cells[1].Value = pokemon[index].moves[i].level.ToString();
                        learnsetGrid.Rows[i].Cells[2].Value = movenamedata.moveNamesList[pokemon[index].moves[i].move - 1];
                    }
                }
                else
                {
                    learnsetGrid.Rows.Add(1);
                    learnsetGrid.Rows[0].Cells[0].Value = "No entries";
                }
            }
        }
        internal void buildMoveList()
        {
            moveLearnBox.Items.Add("No Move");

            //Move name list starts at index 01
            int i = 0;
            foreach (string element in movenamedata.moveNamesList)
            {
                moveLearnBox.Items.Add(movenamedata.moveNamesList[i]);
                i++;
            }
        }
        private void evoSpeciesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (evoSpeciesBox.SelectedIndex == 0)
            {
                MessageBox.Show("Evolution Species can't be 0x00, that is the data stop identifier");
                evoSpeciesBox.SelectedIndex = 1;
            }
        }
        public class EVOLUTION
        {
            public byte evomethod { get; set; }
            public byte evolevel { get; set; }
            public byte evoitem_map { get; set; }
            public byte evospecies { get; set; }
        }
        public class LEARNSET
        {
            public byte level { get; set; }
            public byte move { get; set; }
        }
        public class SPECIESENTRY
        {
            public int currentEvo { get; set; }
            public int currentMove { get; set; }
            public UInt16 offset { get; set; }
            public List<EVOLUTION> evos = new List<EVOLUTION>();
            public List<LEARNSET> moves = new List<LEARNSET>();
        }
        private string[] evoMethodList =
        {
            "NO_EVOLUTION",
            "EV_LEVEL",
            "EV_ITEM ",
            "EV_TRADE",
            "EV_GEO",
            "EV_ATK",
            "EV_DEF",
            "EV_ATKDEF"
        };
        private string[] brownSpecies =
        {
            "000 No Pokemon",
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
            "Tyrogue (Hitmontop)",
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
            "Eevee (Leafeon)",
            "Eevee (Glaceon)",
            "Tyranitar",
            "Crobat",
            "Ampharos",
            "Lugia",
            "Ho-Oh",
            "Magnezone",
            "Politoed",
            "Rhyperior",
            "Blissey",
            "Tangrowth",
            "Kingdra",
            "Porygon2",
            "Porygon-Z",
            "Honchkrow",
            "Mismagius",
            "Leafeon",
            "Glaceon",
            "Electivire",
            "Magmortar",
            "Mamoswine",
            "Yanmega",
            "Hitmontop",
            "Slowking",
            "Togekiss",
            "Steelix",
            "Gliscor",
            "Scizor",
            "Weavile",
            "Meganium",
            "Sylveon",
            "Annihilape",
            "G.Weezing",
            "Lickilicky",
            "235-?????",
            "236-?????",
            "237-?????",
            "238-?????",
            "239-?????",
            "240-?????",
            "241-?????",
            "242-?????",
            "243-?????",
            "244-?????",
            "245-?????",
            "246-?????",
            "247-?????",
            "248-?????",
            "249-?????",
            "250-?????",
            "251-?????",
            "Phancero",
            "253-?????",
            "254-?????",
            "255-?????",
            "256-?????",
        };
        private string[] brownItems =
        {
            "00GLITCH",
            "Master Ball",
            "Ultra ball",
            "Great ball",
            "Pokeball",
            "Town Map",
            "Bycicle",
            "07GLITCH",
            "Park Ball",
            "08GLITCH",
            "Moon Stone",
            "Antidote",
            "Burn Heal",
            "Ice Heal",
            "Awakening",
            "Paraliz Heal",
            "Full Restore",
            "Max potion",
            "Hyper potion",
            "Super potion",
            "Potion",
            "09GLITCH",
            "10GLITCH",
            "Red Orb",
            "Blue Orb",
            "Green Orb",
            "Dusk Stone",
            "Up-Grade",
            "Shiny Stone",
            "Escape Rope",
            "Repel",
            "Skull Fossil",
            "Fire Stone",
            "Thunder Stone",
            "Water Stone",
            "HP Up",
            "Protein",
            "Iron",
            "Carbos",
            "Calcium",
            "Rare Candy",
            "Dome Fossil",
            "Helix Fossil",
            "Mist Stone",
            "Dubious Disk",
            "Bike Voucher",
            "X Accuracy",
            "Leaf Stone",
            "Card Key",
            "Nugget",
            "PP Up",
            "Poké Doll",
            "Full Heal",
            "Revive",
            "Max Revive",
            "Guard Spec.",
            "Super Repel",
            "Max Repel",
            "Dire Hit",
            "GLITCH (COIN)",
            "Beer Keg",
            "Soda",
            "Lemonade",
            "S.S.Ticket",
            "Red Amulet",
            "X Attack",
            "X Defend",
            "X Speed",
            "X Special",
            "Coin Case",
            "Tim's Pizza",
            "ItemFInder",
            "Virus Scan",
            "Poké Flute",
            "GLITCH",
            "Exp.All",
            "Old Rod",
            "Good Rod",
            "Super Rod",
            "PP UP",
            "Ether",
            "Max Ether",
            "Elixer",
            "Max Elixer",
            "Metal Coat",
            "Magmarizer",
            "Electrizer",
            "Trade Stone",
            "Protector",
            "Razor Fang",
            "Razor Claw",
            "King's Rock",
            "Dragon Scale",
            "Pearl",
            "Big Pearl",
            "Stardust",
            "Star Piece",
            "TinyMushroom",
            "Mushroom",
            "Gold Leaf",
            "Sapphire Egg",
            "Brick Piece",
            "Rare Bone",
            "CoronetStone",
            "Ruby Egg",
            "Gold Egg",
            "Crystal Egg",
            "Emeral Egg",
            "Prism Key",
            "Silver Egg",
            "Magic Wand ",
            "1F",
            "2F",
            "3F",
            "4F",
            "5F",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "NODATA",
            "HM01",
            "HM02",
            "HM03",
            "HM04",
            "HM05",
            "TM01",
            "TM02",
            "TM03",
            "TM04",
            "TM05",
            "TM06",
            "TM07",
            "TM08",
            "TM09",
            "TM10",
            "TM11",
            "TM12",
            "TM13",
            "TM14",
            "TM15",
            "TM16",
            "TM17",
            "TM18",
            "TM19",
            "TM20",
            "TM21",
            "TM22",
            "TM23",
            "TM24",
            "TM25",
            "TM26",
            "TM27",
            "TM28",
            "TM29",
            "TM30",
            "TM31",
            "TM32",
            "TM33",
            "TM34",
            "TM35",
            "TM36",
            "TM37",
            "TM38",
            "TM39",
            "TM40",
            "TM41",
            "TM42",
            "TM43",
            "TM44",
            "TM45",
            "TM46",
            "TM47",
            "TM48",
            "TM49",
            "TM50",
            "TM51",
            "TM52",
            "TM53",
            "TM54",
            "TM55"
        };
        public static string[] brownMaps =
        {
            "0x00 Gravel Town",
            "0x01 Seashore City",
            "0x02 Jaeru City",
            "0x03 Hayward City",
            "0x04 Merson City",
            "0x05 Castro Valley",
            "0x06 Moraga Town",
            "0x07 Owsauri City",
            "0x08 Eagulou City",
            "0x09 Rijon League Entrance",
            "0x0A Botan City",
            "0x0B UNUSED (Azalea Town)",
            "0x0C Route 53",
            "0x0D Route 52",
            "0x0E Route 59",
            "0x0F Route 64",
            "0x10 Route 57",
            "0x11 Route 58",
            "0x12 Route 60",
            "0x13 Route 54",
            "0x14 Route 63",
            "0x15 Route 55",
            "0x16 Route 62",
            "0x17 Route 61",
            "0x18 Final Dungeon Underground Path",
            "0x19 Final Dungeon Outdoor Path",
            "0x1A Azalea Town",
            "0x1B Route 47-B",
            "0x1C Route 48-B",
            "0x1D Route 49",
            "0x1E Route 66",
            "0x1F Route 56",
            "0x20 UNUSED (Glitched Gravel Town)",
            "0x21 Route 67",
            "0x22 Route 65",
            "0x23 Route 51",
            "0x24 Route 50",
            "0x25 Seashore City Player's House 1F",
            "0x26 Seashore City Player's House 2F",
            "0x27 Hayward City Town Map House",
            "0x28 Tim's Lab",
            "0x29 UNUSED (PokéCenter)",
            "0x2A UNUSED (PokéMart)",
            "0x2B Moraga Town High School Academy",
            "0x2C Seashore Rival's House",
            "0x2D Eagulou City Gym",
            "0x2E Rijon Tunnel Hayward City Entrance",
            "0x2F Route 57 - Castro Forest Gate",
            "0x30 ",
            "0x31 Hayward City - Route 52 Gate",
            "0x32 Castro Valley - Castro Forest Gate (Vertical Variant A)",
            "0x33 Castro Forest",
            "0x34 Botan City Cave",
            "0x35 UNUSED (Pewter Museum 2F)",
            "0x36 Merson City Gym",
            "0x37 Moraga Town Sandshrew House",
            "0x38 Jaeru City PokéMart",
            "0x39 Jaeru City House",
            "0x3A Jaeru City PokéCenter",
            "0x3B Merson Cave 1F",
            "0x3C Merson Cave B1F",
            "0x3D Final Dungeon Underground Cave Maze 1F",
            "0x3E Botan City Move Teacher & Move Deleter",
            "0x3F Final Dungeon Underground Cave Maze 1F Cave Room",
            "0x40 UNUSED (PokéCenter)",
            "0x41 Owsauri City Gym",
            "0x42 Jaeru Bike Shop",
            "0x43 Moraga Town PokéMart",
            "0x44 Route 67 PokéCenter",
            "0x45 ",
            "0x46 UNUSED (Gate Vertical Variant B)",
            "0x47 City Underpass Moraga Town Entrance",
            "0x48 Owsauri Daycare",
            "0x49 Botan City - Route 58 Gate (Vertical Variant B)",
            "0x4A City Underpass Route 56 Entrance",
            "0x4B UNUSED (Underpass Entrance)",
            "0x4C UNUSED (Gate Horizontal Variant A)",
            "0x4D Dock Underpass Route 52 Entrance",
            "0x4E UNUSED (Underpass Entrance)",
            "0x4F Moraga Town Prism Museum",
            "0x50 Dock Underpass Route 55 Entrance",
            "0x51 Azalea Town PokéCenter",
            "0x52 Final Dungeon Underground Cave Maze B1F",
            "0x53 Power Plant",
            "0x54 UNUSED (Gate Horizontal Variant B)",
            "0x55 Final Dungeon Final Cave",
            "0x56 UNUSED (Gate 2F Binoculars)",
            "0x57 Route 49 - Route 50 Gate 1F (Vertical Variant C)",
            "0x58 UNUSED (Bill's House)",
            "0x59 Castro Valley PokéCenter",
            "0x5A Merson City Pokémon Fan Club",
            "0x5B Castro Valley PokéMart",
            "0x5C Jaeru Gym",
            "0x5D Seneca Caverns B1F",
            "0x5E UNUSED (Castro Valley Dock)",
            "0x5F UNUSED (S.S. Anne)",
            "0x60 UNUSED (S.S. Anne)",
            "0x61 UNUSED (S.S. Anne)",
            "0x62 UNUSED (S.S. Anne)",
            "0x63 Final Dungeon Main Building B3F",
            "0x64 Castro Valley Dock",
            "0x65 UNUSED (S.S. Anne)",
            "0x66 Final Dungeon Teleport Rooms A",
            "0x67 Final Dungeon Teleport Rooms B",
            "0x68 Final Dungeon Teleport Rooms C",
            "0x69 Slowpoke Well 1F",
            "0x6A Route 60 - Route 61 Gate",
            "0x6B Route 61 - Route 62 Gate",
            "0x6C Eagulou Cave (above Eagulou Gym)",
            "0x6D Route 62 - Castro Forest Gate (Hallway)",
            "0x6E Route 62 - Castro Forest Gate (Entrance)",
            "0x6F International Tunnel 1F",
            "0x70 UNUSED",
            "0x71 Drake's Room (Elite 4)",
            "0x72 UNUSED",
            "0x73 UNUSED (Seneca Caverns B2F copy)",
            "0x74 Route 65 - Route 67 Gate",
            "0x75 EMPTY",
            "0x76 Hall of Fame Room",
            "0x77 City Underpass (Route 56 - Moraga Town)",
            "0x78 Mura's Room (Rival/Champion)",
            "0x79 Dock Underpass (Route 52 - Route 55)",
            "0x7A Hayward City Dept. Store 1F",
            "0x7B Hayward City Dept. Store 2F",
            "0x7C Hayward City Dept. Store 3F",
            "0x7D Hayward City Dept. Store 4F",
            "0x7E Hayward City Dept. Store Roof",
            "0x7F Hayward City Dept. Store Elevator",
            "0x80 KBM Games Building 1F",
            "0x81 KBM Games Building 2F",
            "0x82 KBM Games Building 3F",
            "0x83 KBM Games Building 4F",
            "0x84 KBM Games Building 4F Porygon Room",
            "0x85 Hayward City PokéCenter",
            "0x86 Moraga Town Gym",
            "0x87 Owsauri City Game Corner 1F",
            "0x88 Hayward City Dept. Store 5F",
            "0x89 Owsauri City Game Corner B1F",
            "0x8A Moraga Town Nation's Burgers",
            "0x8B ",
            "0x8C ",
            "0x8D Merson City PokéCenter",
            "0x8E Haunted Forest Area 1",
            "0x8F Haunted Forest Area 2",
            "0x90 Haunted Forest Area 3",
            "0x91 Haunted Forest Area 4",
            "0x92 Haunted Forest Area 5",
            "0x93 Haunted Forest Area 6",
            "0x94 Haunted Forest Area 7",
            "0x95 Mr. Rumiko's House",
            "0x96 Merson City PokéMart",
            "0x97 Merson Cubone House",
            "0x98 Owsauri City PokéMart",
            "0x99 Owsauri Gambler Husband House",
            "0x9A Owsauri PokéCenter",
            "0x9B Hayward City HM04 Strength House",
            "0x9C Eagulou Park Gate",
            "0x9D Castro Valley Gym",
            "0x9E ",
            "0x9F Silk Tunnel B1F",
            "0xA0 Silk Tunnel B2F",
            "0xA1 Mt. Boulder 1F",
            "0xA2 Mt. Boulder B1F",
            "0xA3 Castro Valley Old Rod House",
            "0xA4 Route 67 Teleport Scientist House",
            "0xA5 Koolboyman Mansion 1F",
            "0xA6 Route 57 Out of City Gym",
            "0xA7 UNUSED (Cinnabar Lab)",
            "0xA8 Botan City Trade House",
            "0xA9 UNUSED (Cinnabar Lab)",
            "0xAA Hayward City Fossil Lab",
            "0xAB Eagulou PokéCenter",
            "0xAC Eagulou City PokéMart",
            "0xAD UNUSED (PokéMart)",
            "0xAE Rijon League Lobby",
            "0xAF ",
            "0xB0 UNUSED (Pokédoll House 1F)",
            "0xB1 Azalea Town Gym",
            "0xB2 Seashore City Gym",
            "0xB3 ",
            "0xB4 Botan City PokéMart",
            "0xB5 Silph Co. Warehouse 1F",
            "0xB6 Moraga Town PokéCenter",
            "0xB7 Slowpoke Well B1F",
            "0xB8 UNUSED (Gate Horizontal Variant B)",
            "0xB9 UNUSED (Gate 2F Binoculars)",
            "0xBA Route 47-B - Route 48-B Gate 1F",
            "0xBB Route 47-B - Route 48-B Gate 2F",
            "0xBC Moraga Town HM02 Fly House",
            "0xBD Route 61 Good Rod House",
            "0xBE Route 49 Gate 1F",
            "0xBF Route 49 Gate 2F",
            "0xC0 Silk Tunnel 1F",
            "0xC1 Jaeru City - Route 65 Gate",
            "0xC2 30 Years Cave",
            "0xC3 Route 49 - Route 50 Gate 2F",
            "0xC4 Castro Valley Chansey Trade House",
            "0xC5 Rijon Tunnel",
            "0xC6 Eagulou Park Secret Cave B1F",
            "0xC7 Final Dungeon Main Building 1F",
            "0xC8 Final Dungeon Main Building B2F",
            "0xC9 Final Dungeon Main Building B1F",
            "0xCA Final Dungeon Final Island",
            "0xCB UNUSED (Rocket Hideout Elevator)",
            "0xCC UNUSED (65-67 Gate)",
            "0xCD Route 34 - Route47-B - Ilex Forest Gate",
            "0xCE ",
            "0xCF Silph Co. Warehouse 2F",
            "0xD0 Final Dungeon Teleport Rooms D",
            "0xD1 Silph Co. Warehouse B1F",
            "0xD2 International Tunnel B1F",
            "0xD3 Silph Co. Warehouse 3F",
            "0xD4 Final Dungeon Underground Cave Maze B1F Large Room",
            "0xD5 Seneca Caverns 1F",
            "0xD6 Koolboyman Mansion 2F",
            "0xD7 Koolboyman Mansion 3F",
            "0xD8 Koolboyman Mansion B1F",
            "0xD9 Eagulou Park Area 3",
            "0xDA Eagulou Park Area 2",
            "0xDB Seneca Caverns B2F",
            "0xDC Eagulou Park Area 1",
            "0xDD Eagulou Park Area 1 House",
            "0xDE Route 61 HM03 Surf House",
            "0xDF UNUSED (Eagulou Park House)",
            "0xE0 Eagulou Park Area 3 House",
            "0xE1 Eagulou Park Area 2 House",
            "0xE2 Azalea Town - Ilex Forest Gate",
            "0xE3 Eagulou Park Secret Cave B2F",
            "0xE4 Ilex Forest",
            "0xE5 Owsauri Name Rater's House",
            "0xE6 ",
            "0xE7 ",
            "0xE8 Silk Tunnel B3F",
            "0xE9 Final Dungeon Final Island *Pokécenter*",
            "0xEA Route 34 (Johto)",
            "0xEB Silph Co. Warehouse 4F",
            "0xEC ",
            "0xED ",
            "0xEE ",
            "0xEF Link Trade Room",
            "0xF0 Link Battle Room",
            "0xF1 Final Dungeon Healing Room",
            "0xF2 Final Dungeon Shop",
            "0xF3 Merson Cave Healing Room",
            "0xF4 ",
            "0xF5 Redd's Room (Elite 4)",
            "0xF6 Jared's Room (Elite 4)",
            "0xF7 Agatha's Room (Elite 4)" //This is the last map, there's only 248 maps, this is ID 247
        };

        private void speciesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (speciesBox.SelectedIndex < 0 || speciesBox.SelectedIndex > TotalSpecies)
            {
                MessageBox.Show("Please select a valid species.");
                speciesBox.SelectedIndex = 0;
            }
            else
            {

                FillEvoMoveData(speciesBox.SelectedIndex);
                loadEvoData(0);
                loadMoveData(0);

                bool doesEvolve = false;

                //Fill evo information
                evolveFromLabel.Text = "This species evolves from:";
                int i = 0;
                for (i = 0; i < TotalSpecies; i++)
                {
                    int j = 0;
                    if (pokemon[i].evos.Count() != 0)
                    {
                        for (j = 0; j < pokemon[i].evos.Count(); j++)
                        {
                            if (pokemon[i].evos[j].evospecies == speciesBox.SelectedIndex + 1)
                            {
                                doesEvolve = true;
                                evolveFromLabel.Text += "\n\t   " + brownSpecies[i + 1].ToString() + " at level " + pokemon[i].evos[j].evolevel.ToString();
                                //if (pokemon[i].evos[j].evospecies == EV_LEVEL)
                                //   ;
                                if (pokemon[i].evos[j].evomethod == EV_ITEM)
                                    evolveFromLabel.Text += " with " + brownItems[pokemon[i].evos[j].evoitem_map].ToString();
                                if (pokemon[i].evos[j].evomethod == EV_GEO)
                                    evolveFromLabel.Text += " on MAP " + pokemon[i].evos[j].evoitem_map.ToString();
                                if (pokemon[i].evos[j].evomethod == EV_TRADE)
                                    evolveFromLabel.Text += " with TRADE";
                                if (pokemon[i].evos[j].evomethod == EV_ATTAK)
                                    evolveFromLabel.Text += " with ATK";
                                if (pokemon[i].evos[j].evomethod == EV_DEFENSE)
                                    evolveFromLabel.Text += " with DEF";
                                if (pokemon[i].evos[j].evomethod == EV_ATKEQDEF)
                                    evolveFromLabel.Text += " with ATK=DEF";

                            }
                        }
                    }
                }
                if (doesEvolve == false)
                {

                    evolveFromLabel.Text = "This species doesn't evolve\n\t" +
                                            "from another one";
                }
            }
        }

        private void SortEvoMoveData()
        {
            int j = 0;
            for (j = 0; j < EvomovesTotalEntries; j++)
            {
                pokemon[j].evos = pokemon[j].evos
                    .OrderBy(o => o.evomethod == 1)//Put level evolution last (rom relies in these being last)
                    .ThenBy(o => o.evomethod)
                    .ThenBy(o => o.evospecies) //If tie sort by species
                    .ThenBy(o => o.evoitem_map) //If same method sort by item/geolocation (will be 0 for other methods)
                    .ThenBy(o => o.evolevel)  //If tie sort by level
                    .ToList();


                pokemon[j].moves = pokemon[j].moves
                    .OrderBy(o => o.level)
                    .ThenBy(o => o.move)
                    .ToList();
            }
        }

        private void loadEvoData(int index)
        {
            //Sort all pokémon data (just to ensure it is always sorted for later dumping)
            SortEvoMoveData();

            evoItemMapBox.Items.Clear();
            if (pokemon[speciesBox.SelectedIndex].evos.Count()> 0 && pokemon[speciesBox.SelectedIndex].offset != 0)
            {
                evoTypeBox.SelectedIndex = pokemon[speciesBox.SelectedIndex].evos[index].evomethod;
                evoLevelUD.Value = pokemon[speciesBox.SelectedIndex].evos[index].evolevel;
                evoSpeciesBox.SelectedIndex = pokemon[speciesBox.SelectedIndex].evos[index].evospecies;
                
                if (pokemon[speciesBox.SelectedIndex].evos[index].evomethod == EV_ITEM)
                {
                    evoItemMapBox.Items.AddRange(brownItems);
                    evoItemMapBox.SelectedIndex = pokemon[speciesBox.SelectedIndex].evos[index].evoitem_map;

                }
                else if (pokemon[speciesBox.SelectedIndex].evos[index].evomethod == EV_GEO)
                {
                    evoItemMapBox.Items.AddRange(brownMaps);
                    evoItemMapBox.SelectedIndex = pokemon[speciesBox.SelectedIndex].evos[index].evoitem_map;
                }
                else
                {
                    evoItemMapBox.Items.Add("Unused");
                   // evoItemMapBox.SelectedIndex = pokemon[speciesBox.SelectedIndex].evos[index].evoitem_map;

                }
                pokemon[speciesBox.SelectedIndex].currentEvo = index;
            }
            else //Pokémon either has no evolution or has no offset assigned (empty slot)
            {
                pokemon[speciesBox.SelectedIndex].currentEvo = 0;
                evoTypeBox.SelectedIndex = 0;
                evoLevelUD.Value = 1;
                evoSpeciesBox.SelectedIndex = 1;
                evoItemMapBox.Items.Add("Unused");
                evoItemMapBox.SelectedIndex = 0;
            }
            toogleEvoButtons();
        }
        private void toogleEvoButtons()
        {
            //If there is no entry for the pokemon disable all buttons
            if (pokemon[speciesBox.SelectedIndex].offset == 0)
            {
                saveEvoBut.Enabled = false;
                addEvoBut.Enabled = false;
                removeEvoBut.Enabled = false;
            }
            else
            {
                if (pokemon[speciesBox.SelectedIndex].evos.Count() == 0)
                {
                    //If there's no evo for the mon only have the add evo button
                    saveEvoBut.Enabled = false;
                    addEvoBut.Enabled = true;
                    removeEvoBut.Enabled = false;
                }
                else //If there's already an evo enable all
                {
                    saveEvoBut.Enabled = true;
                    addEvoBut.Enabled = true;
                    removeEvoBut.Enabled = true;
                }
            }
        }
        private void toogleMoveButtons()
        {
            //If there is no entry for the pokemon disable all buttons
            if (pokemon[speciesBox.SelectedIndex].offset == 0)
            {
                addMoveBut .Enabled = false;
                removeMoveBut.Enabled = false;
                saveMoveBut.Enabled = false;
            }
            else
            {
                if (pokemon[speciesBox.SelectedIndex].moves.Count() == 0)
                {
                    //If there's no moves for the mon only keep the add move button
                    addMoveBut.Enabled = true;
                    removeMoveBut.Enabled = false;
                    saveMoveBut.Enabled = false;
                }
                else //If there's already moves enable all
                {
                    addMoveBut.Enabled = true;
                    removeMoveBut.Enabled = true;
                    saveMoveBut.Enabled = true;
                }
            }
        }
        private void loadMoveData(int index)
        {
            if (pokemon[speciesBox.SelectedIndex].moves.Count() > 0 && pokemon[speciesBox.SelectedIndex].offset != 0)
            {
                moveLevelUD.Value = pokemon[speciesBox.SelectedIndex].moves[index].level;
                moveLearnBox.SelectedIndex = pokemon[speciesBox.SelectedIndex].moves[index].move;
                pokemon[speciesBox.SelectedIndex].currentMove = index;

            }
            else
            {
                moveLevelUD.Value = 1;
                moveLearnBox.SelectedIndex = 1;
                pokemon[speciesBox.SelectedIndex].currentMove = 0;
            }
            toogleMoveButtons();
        }
        private void exitBut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void evosGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            loadEvoData(evosGrid.CurrentRow.Index);
        }

        private void evosGrid_KeyDown(object sender, KeyEventArgs e)
        {
            loadEvoData(evosGrid.CurrentRow.Index);
        }

        private void evosGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            loadEvoData(evosGrid.CurrentRow.Index);
        }

        private void evosGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            loadEvoData(evosGrid.CurrentRow.Index);
        }

        private void evosGrid_KeyUp(object sender, KeyEventArgs e)
        {
            loadEvoData(evosGrid.CurrentRow.Index);
        }
        private void learnsetGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            loadMoveData(learnsetGrid.CurrentRow.Index);
        }

        private void learnsetGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            loadMoveData(learnsetGrid.CurrentRow.Index);
        }

        private void learnsetGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            loadMoveData(learnsetGrid.CurrentRow.Index);
        }

        private void learnsetGrid_KeyDown(object sender, KeyEventArgs e)
        {
            loadMoveData(learnsetGrid.CurrentRow.Index);
        }

        private void learnsetGrid_KeyUp(object sender, KeyEventArgs e)
        {
            loadMoveData(learnsetGrid.CurrentRow.Index);
        }

        private void evoTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            evoItemMapBox.Items.Clear();

            if (evoTypeBox.SelectedIndex == EV_ITEM)
            {
                evoItemMapBox.Items.AddRange(brownItems);
                evoItemMapBox.SelectedIndex = 0;
                evoItemMapBox.Enabled = true;
            }
            else if (evoTypeBox.SelectedIndex == EV_GEO)
            {
                evoItemMapBox.Items.AddRange(brownMaps);
                evoItemMapBox.SelectedIndex = 0;
                evoItemMapBox.Enabled = true;
            }
            else
            {
                evoItemMapBox.Items.Add("Unused");
                evoItemMapBox.Enabled = false;
            }

        }

        private void moveLearnBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (moveLearnBox.SelectedIndex == 0)
            {
                MessageBox.Show("Move can't be 0x00, that is the data stop identifier");
                moveLearnBox.SelectedIndex = 1;
            }
        }

        private void saveEvoBut_Click(object sender, EventArgs e)
        {
            if (evoTypeBox.SelectedIndex == 0)
            {
                MessageBox.Show("Please select an evolution method.");
                return;
            }
            else if (EvoMovesFreeBytes > 0) //Technically should handle having no bytes left and changing a 3 byte evolution into a 4 byte evolution, but the current rom has +1000 bytes free space for evomovedata...so not bothering right now
            {
                //Supposedly this button won't work if there's no evo data, but let's add a cuple checks anyways
                if (pokemon[speciesBox.SelectedIndex].evos[pokemon[speciesBox.SelectedIndex].currentEvo].evomethod == 0)
                {
                    MessageBox.Show("This message shouldn't appear as this button shouldn't be active. Selected species doesn't have any evolution, use \"Save as new EVO\n button instead.");
                    return;
                }
                if (pokemon[speciesBox.SelectedIndex].offset == 0)
                {
                    MessageBox.Show("This message shouldn't appear as this button shouldn't be active as selected species doesn't have any data in the pointer table.");
                    return;
                }

                //Ok, now let's actually save the changes
                pokemon[speciesBox.SelectedIndex].evos[pokemon[speciesBox.SelectedIndex].currentEvo].evomethod = (byte)evoTypeBox.SelectedIndex;
                pokemon[speciesBox.SelectedIndex].evos[pokemon[speciesBox.SelectedIndex].currentEvo].evolevel = (byte)evoLevelUD.Value;
                pokemon[speciesBox.SelectedIndex].evos[pokemon[speciesBox.SelectedIndex].currentEvo].evospecies = (byte)evoSpeciesBox.SelectedIndex;
                pokemon[speciesBox.SelectedIndex].evos[pokemon[speciesBox.SelectedIndex].currentEvo].evoitem_map = (byte)evoItemMapBox.SelectedIndex;

                //reload
                SortEvoMoveData();
                FillEvoMoveData(speciesBox.SelectedIndex);
                evosGrid.CurrentCell = evosGrid.Rows[0].Cells[0];
                loadEvoData(0);//currentEvo is updated by loadEvoData

                //Update pointer and evomove data buffers and re-calculate freespace
                EvoMovesFreeBytes = SaveEvoMoveDataToBuffer();
                freespace.Text = EvoMovesFreeBytes.ToString() + " bytes free";

                MessageBox.Show("Evolution saved.");
            }
            else
            {
                MessageBox.Show("Not enough free space to save evolution (Free space: " + EvoMovesFreeBytes.ToString() + "bytes");
            }
        }

        private void addEvoBut_Click(object sender, EventArgs e)
        {
            if(evoTypeBox.SelectedIndex == 0)
            {
                MessageBox.Show("Please select an evolution method.");
                return;
            }
            else if //Free space check
                (
                    (evoTypeBox.SelectedIndex == 2
                        && EvoMovesFreeBytes >= 4)
                    ||
                    (evoTypeBox.SelectedIndex == 4
                        && EvoMovesFreeBytes >= 4)
                    ||
                    (evoTypeBox.SelectedIndex != 2
                        && evoTypeBox.SelectedIndex != 4
                        && EvoMovesFreeBytes >= 3)
                )
            {

                pokemon[speciesBox.SelectedIndex].currentEvo = pokemon[speciesBox.SelectedIndex].evos.Count();

                pokemon[speciesBox.SelectedIndex].evos.Add(new EVOLUTION());
                //Ok, now let's actually save the changes
                pokemon[speciesBox.SelectedIndex].evos[pokemon[speciesBox.SelectedIndex].currentEvo].evomethod = (byte)evoTypeBox.SelectedIndex;
                pokemon[speciesBox.SelectedIndex].evos[pokemon[speciesBox.SelectedIndex].currentEvo].evolevel = (byte)evoLevelUD.Value;
                pokemon[speciesBox.SelectedIndex].evos[pokemon[speciesBox.SelectedIndex].currentEvo].evospecies = (byte)evoSpeciesBox.SelectedIndex;
                pokemon[speciesBox.SelectedIndex].evos[pokemon[speciesBox.SelectedIndex].currentEvo].evoitem_map = (byte)evoItemMapBox.SelectedIndex;

                //reload
                SortEvoMoveData();
                FillEvoMoveData(speciesBox.SelectedIndex);
                //When adding an evo put the cursor to the first entry again, getting the new index after sorting is a pain
                evosGrid.CurrentCell = evosGrid.Rows[0].Cells[0];
                loadEvoData(0);//currentEvo is updated by loadEvoData

                //Update pointer and evomove data buffers and re-calculate freespace
                EvoMovesFreeBytes = SaveEvoMoveDataToBuffer();
                freespace.Text = EvoMovesFreeBytes.ToString() + " bytes free";

                MessageBox.Show("Evolution added.");
            }
            else
            {
                MessageBox.Show("Not enough free space to add evolution (Free space: " + EvoMovesFreeBytes.ToString() + "bytes");
            }
        }

        private void removeEvoBut_Click(object sender, EventArgs e)
        {
            //Supposedly this button won't work if there's no evo data, but let's add a cuple checks anyways
            if (pokemon[speciesBox.SelectedIndex].evos[pokemon[speciesBox.SelectedIndex].currentEvo].evomethod == 0)
            {
                MessageBox.Show("This message shouldn't appear as this button shouldn't be active. Selected species doesn't have any evolution.");
                return;
            }
            if (pokemon[speciesBox.SelectedIndex].offset == 0)
            {
                MessageBox.Show("This message shouldn't appear as this button shouldn't be active as selected species doesn't have any data in the pointer table.");
                return;
            }

            pokemon[speciesBox.SelectedIndex].evos.RemoveAt(pokemon[speciesBox.SelectedIndex].currentEvo);

            //Update current evo index
            if (pokemon[speciesBox.SelectedIndex].currentEvo - 1 >= 0)
                pokemon[speciesBox.SelectedIndex].currentEvo--;
            //reload
            //SortEvoMoveData(); //No needed when removing as data should already be sorted
            FillEvoMoveData(speciesBox.SelectedIndex);
            loadEvoData(pokemon[speciesBox.SelectedIndex].currentEvo);
            evosGrid.CurrentCell = evosGrid.Rows[pokemon[speciesBox.SelectedIndex].currentEvo].Cells[0];//currentEvo is updated by loadEvoData

            //Update pointer and evomove data buffers and re-calculate freespace
            EvoMovesFreeBytes = SaveEvoMoveDataToBuffer();
            freespace.Text = EvoMovesFreeBytes.ToString() + " bytes free";

            MessageBox.Show("Evolution removed.");
        }

        private void saveMoveBut_Click(object sender, EventArgs e)
        {
            //Supposedly this button won't work if there's no move data, but let's add a cuple checks anyways
            if (pokemon[speciesBox.SelectedIndex].moves[pokemon[speciesBox.SelectedIndex].currentMove].level == 0)
            {
                MessageBox.Show("This message shouldn't appear as this button shouldn't be active. Selected species doesn't have any moves, , use \"Save as new Move\n button instead.");
                return;
            }
            if (pokemon[speciesBox.SelectedIndex].offset == 0)
            {
                MessageBox.Show("This message shouldn't appear as this button shouldn't be active as selected species doesn't have any data in the pointer table.");
                return;
            }

            //Save the changes
            pokemon[speciesBox.SelectedIndex].moves[pokemon[speciesBox.SelectedIndex].currentMove].level = (byte)moveLevelUD.Value;
            pokemon[speciesBox.SelectedIndex].moves[pokemon[speciesBox.SelectedIndex].currentMove].move = (byte)moveLearnBox.SelectedIndex;

            //reload
            SortEvoMoveData();
            FillEvoMoveData(speciesBox.SelectedIndex);
            learnsetGrid.CurrentCell = learnsetGrid.Rows[0].Cells[0];
            loadMoveData(0);//currentMove is updated by loadMoveData

            //Update pointer and evomove data buffers and re-calculate freespace
            EvoMovesFreeBytes = SaveEvoMoveDataToBuffer();
            freespace.Text = EvoMovesFreeBytes.ToString() + " bytes free";

            MessageBox.Show("Move saved.");
        }

        private void addMoveBut_Click(object sender, EventArgs e)
        {
            if (EvoMovesFreeBytes >= 2)
            {

                pokemon[speciesBox.SelectedIndex].currentMove = pokemon[speciesBox.SelectedIndex].moves.Count();

                pokemon[speciesBox.SelectedIndex].moves.Add(new LEARNSET());
                //Ok, now let's actually save the changes
                pokemon[speciesBox.SelectedIndex].moves[pokemon[speciesBox.SelectedIndex].currentMove].level = (byte)moveLevelUD.Value;
                pokemon[speciesBox.SelectedIndex].moves[pokemon[speciesBox.SelectedIndex].currentMove].move = (byte)moveLearnBox.SelectedIndex;

                //reload
                SortEvoMoveData();
                FillEvoMoveData(speciesBox.SelectedIndex);
                learnsetGrid.CurrentCell = learnsetGrid.Rows[0].Cells[0];
                loadMoveData(0);//currentMove is updated by loadMoveData

                //Update pointer and evomove data buffers and re-calculate freespace
                EvoMovesFreeBytes = SaveEvoMoveDataToBuffer();
                freespace.Text = EvoMovesFreeBytes.ToString() + " bytes free";

                MessageBox.Show("Move added.");
            }
            else
            {
                MessageBox.Show("Not enough free space to add move (Free space: " + EvoMovesFreeBytes.ToString() + "bytes");
            }
        }

        private void removeMoveBut_Click(object sender, EventArgs e)
        {
            //Supposedly this button won't work if there's no move data, but let's add a cuple checks anyways
            if (pokemon[speciesBox.SelectedIndex].moves[pokemon[speciesBox.SelectedIndex].currentMove].level == 0)
            {
                MessageBox.Show("This message shouldn't appear as this button shouldn't be active. Selected species doesn't have any moves.");
                return;
            }
            if (pokemon[speciesBox.SelectedIndex].offset == 0)
            {
                MessageBox.Show("This message shouldn't appear as this button shouldn't be active as selected species doesn't have any data in the pointer table.");
                return;
            }

            pokemon[speciesBox.SelectedIndex].moves.RemoveAt(pokemon[speciesBox.SelectedIndex].currentMove);

            //Update current move index
            if (pokemon[speciesBox.SelectedIndex].currentMove - 1 >= 0)
                pokemon[speciesBox.SelectedIndex].currentMove--;
            //reload
            //SortEvoMoveData(); //Not needed as data should already be correctly sorted previously
            FillEvoMoveData(speciesBox.SelectedIndex);
            loadMoveData(pokemon[speciesBox.SelectedIndex].currentMove);
            learnsetGrid.CurrentCell = learnsetGrid.Rows[pokemon[speciesBox.SelectedIndex].currentMove].Cells[0];//currentMove is updated by loadMoveData

            //Update pointer and evomove data buffers and re-calculate freespace
            EvoMovesFreeBytes = SaveEvoMoveDataToBuffer();
            freespace.Text = EvoMovesFreeBytes.ToString() + " bytes free";

            MessageBox.Show("Move removed.");
        }

        private void saveExitBut_Click(object sender, EventArgs e)
        {
            EvoMovesFreeBytes = SaveEvoMoveDataToBuffer();
            freespace.Text = EvoMovesFreeBytes.ToString() + " bytes free";
            //Copy changes to rom and close
            //Copy pointer table
            Buffer.BlockCopy(EvoMovePointerTableBuffer, 0, BrownEditor.MainForm.filebuffer, EvomovesPointerTableOffset, EvomovesTotalEntries*2);
            //Copy evomove data
            Buffer.BlockCopy(EvoMoveDataBuffer, 0, BrownEditor.MainForm.filebuffer, EvomovesDataStartOffset, EvomovesDataSize);
            this.Close();
            MessageBox.Show("Saved Evolution and Learnset data to Rom");
        }
    }
}
