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
    public partial class gymEditor : Form
    {
        //Team data
        public static int TeamDataOffset = 0x1f6140;
        public static int TeamDataSize = 454;
        //Mura's hayward and haunted forest teams aren't contiguous in the rom due to implementing them afterwards and being lazy to rebuild the pointer tables
        public static int MuraTeamDataOffset = 0x1f6700;
        public static int MuraTeamDataSize = 78;

        public static int TeamDataTotalSize = TeamDataSize+MuraTeamDataSize+1;

        //Move data
        public static int MoveDataOffset = 0x1f6310;
        public static int MoveDataSize = 984; //includes padding



        public byte[] TeamData;
        public byte[] MoveData;

        public static MOVENAMEDATA movenamedata;

        public gymEditor()
        {
            InitializeComponent();

            poke1CB.Items.AddRange(brownSpecies);
            poke2CB.Items.AddRange(brownSpecies);
            poke3CB.Items.AddRange(brownSpecies);
            poke4CB.Items.AddRange(brownSpecies);
            poke5CB.Items.AddRange(brownSpecies);
            poke6CB.Items.AddRange(brownSpecies);

            TeamData = BrownEditor.MainForm.filebuffer.Skip(TeamDataOffset).Take(TeamDataTotalSize).ToArray(); //This gets some of the move data in, but is overwritten later with correct data
            MoveData = BrownEditor.MainForm.filebuffer.Skip(MoveDataOffset).Take(MoveDataSize).ToArray();
            //Append Mura's team data to TeamData
            Buffer.BlockCopy(BrownEditor.MainForm.filebuffer, MuraTeamDataOffset, TeamData, TeamDataSize+1, MuraTeamDataSize);            

            movenamedata = new MOVENAMEDATA(BrownEditor.MainForm.filebuffer.Skip(BrownEditor.editor.MoveEditor.MoveNamesOffset).Take(BrownEditor.editor.MoveEditor.MoveNamesSize).ToArray());
            movenamedata.populateNameList();

            //Move name list starts at index 01
            //Poke 1
            poke1Move1CB.Items.Add("NO MOVE");
            poke1Move1CB.Items.AddRange(movenamedata.moveNamesList);
            poke1Move1CB.Items.RemoveAt(255);
            poke1Move1CB.Items.Add("DEFAULT");

            poke1Move2CB.Items.Add("NO MOVE");
            poke1Move2CB.Items.AddRange(movenamedata.moveNamesList);
            poke1Move2CB.Items.RemoveAt(255);
            poke1Move2CB.Items.Add("DEFAULT");

            poke1Move3CB.Items.Add("NO MOVE");
            poke1Move3CB.Items.AddRange(movenamedata.moveNamesList);
            poke1Move3CB.Items.RemoveAt(255);
            poke1Move3CB.Items.Add("DEFAULT");

            poke1Move4CB.Items.Add("NO MOVE");
            poke1Move4CB.Items.AddRange(movenamedata.moveNamesList);
            poke1Move4CB.Items.RemoveAt(255);
            poke1Move4CB.Items.Add("DEFAULT");
            //Poke 2
            poke2Move1CB.Items.Add("NO MOVE");
            poke2Move1CB.Items.AddRange(movenamedata.moveNamesList);
            poke2Move1CB.Items.RemoveAt(255);
            poke2Move1CB.Items.Add("DEFAULT");

            poke2Move2CB.Items.Add("NO MOVE");
            poke2Move2CB.Items.AddRange(movenamedata.moveNamesList);
            poke2Move2CB.Items.RemoveAt(255);
            poke2Move2CB.Items.Add("DEFAULT");

            poke2Move3CB.Items.Add("NO MOVE");
            poke2Move3CB.Items.AddRange(movenamedata.moveNamesList);
            poke2Move3CB.Items.RemoveAt(255);
            poke2Move3CB.Items.Add("DEFAULT");

            poke2Move4CB.Items.Add("NO MOVE");
            poke2Move4CB.Items.AddRange(movenamedata.moveNamesList);
            poke2Move4CB.Items.RemoveAt(255);
            poke2Move4CB.Items.Add("DEFAULT");
            //Poke 3
            poke3Move1CB.Items.Add("NO MOVE");
            poke3Move1CB.Items.AddRange(movenamedata.moveNamesList);
            poke3Move1CB.Items.RemoveAt(255);
            poke3Move1CB.Items.Add("DEFAULT");

            poke3Move2CB.Items.Add("NO MOVE");
            poke3Move2CB.Items.AddRange(movenamedata.moveNamesList);
            poke3Move2CB.Items.RemoveAt(255);
            poke3Move2CB.Items.Add("DEFAULT");

            poke3Move3CB.Items.Add("NO MOVE");
            poke3Move3CB.Items.AddRange(movenamedata.moveNamesList);
            poke3Move3CB.Items.RemoveAt(255);
            poke3Move3CB.Items.Add("DEFAULT");

            poke3Move4CB.Items.Add("NO MOVE");
            poke3Move4CB.Items.AddRange(movenamedata.moveNamesList);
            poke3Move4CB.Items.RemoveAt(255);
            poke3Move4CB.Items.Add("DEFAULT");
            //Poke 4
            poke4Move1CB.Items.Add("NO MOVE");
            poke4Move1CB.Items.AddRange(movenamedata.moveNamesList);
            poke4Move1CB.Items.RemoveAt(255);
            poke4Move1CB.Items.Add("DEFAULT");

            poke4Move2CB.Items.Add("NO MOVE");
            poke4Move2CB.Items.AddRange(movenamedata.moveNamesList);
            poke4Move2CB.Items.RemoveAt(255);
            poke4Move2CB.Items.Add("DEFAULT");

            poke4Move3CB.Items.Add("NO MOVE");
            poke4Move3CB.Items.AddRange(movenamedata.moveNamesList);
            poke4Move3CB.Items.RemoveAt(255);
            poke4Move3CB.Items.Add("DEFAULT");

            poke4Move4CB.Items.Add("NO MOVE");
            poke4Move4CB.Items.AddRange(movenamedata.moveNamesList);
            poke4Move4CB.Items.RemoveAt(255);
            poke4Move4CB.Items.Add("DEFAULT");
            //Poke 5
            poke5Move1CB.Items.Add("NO MOVE");
            poke5Move1CB.Items.AddRange(movenamedata.moveNamesList);
            poke5Move1CB.Items.RemoveAt(255);
            poke5Move1CB.Items.Add("DEFAULT");

            poke5Move2CB.Items.Add("NO MOVE");
            poke5Move2CB.Items.AddRange(movenamedata.moveNamesList);
            poke5Move2CB.Items.RemoveAt(255);
            poke5Move2CB.Items.Add("DEFAULT");

            poke5Move3CB.Items.Add("NO MOVE");
            poke5Move3CB.Items.AddRange(movenamedata.moveNamesList);
            poke5Move3CB.Items.RemoveAt(255);
            poke5Move3CB.Items.Add("DEFAULT");

            poke5Move4CB.Items.Add("NO MOVE");
            poke5Move4CB.Items.AddRange(movenamedata.moveNamesList);
            poke5Move4CB.Items.RemoveAt(255);
            poke5Move4CB.Items.Add("DEFAULT");
            //Poke 6
            poke6Move1CB.Items.Add("NO MOVE");
            poke6Move1CB.Items.AddRange(movenamedata.moveNamesList);
            poke6Move1CB.Items.RemoveAt(255);
            poke6Move1CB.Items.Add("DEFAULT");

            poke6Move2CB.Items.Add("NO MOVE");
            poke6Move2CB.Items.AddRange(movenamedata.moveNamesList);
            poke6Move2CB.Items.RemoveAt(255);
            poke6Move2CB.Items.Add("DEFAULT");

            poke6Move3CB.Items.Add("NO MOVE");
            poke6Move3CB.Items.AddRange(movenamedata.moveNamesList);
            poke6Move3CB.Items.RemoveAt(255);
            poke6Move3CB.Items.Add("DEFAULT");

            poke6Move4CB.Items.Add("NO MOVE");
            poke6Move4CB.Items.AddRange(movenamedata.moveNamesList);
            poke6Move4CB.Items.RemoveAt(255);
            poke6Move4CB.Items.Add("DEFAULT");


            trainerCB.SelectedIndex = 0;
            //ReadTrainer(trainerCB.SelectedIndex);
        }

        private void ReadTrainer(int index)
        {
            int offset = index * (13); //Each team is 13 bytes long (lvl+species)*6 + terminator 0xff

            if (TeamData[offset] == 0xff)
            {
                MessageBox.Show("Warning! This team's first byte is the 0xFF terminator!");
                ReadMoves(index);
                return;
            }
            poke1Lvl.Value = TeamData[offset];
            offset++;
            poke1CB.SelectedIndex = TeamData[offset];
            offset++;

            if (TeamData[offset] == 0xff)
            {
                poke2CB.SelectedIndex = 0;
                poke3CB.SelectedIndex = 0;
                poke4CB.SelectedIndex = 0;
                poke5CB.SelectedIndex = 0;
                poke6CB.SelectedIndex = 0;
                ReadMoves(index);
                return;
            }
            poke2Lvl.Value = TeamData[offset];
            offset++;
            poke2CB.SelectedIndex = TeamData[offset];
            offset++;

            if (TeamData[offset] == 0xff)
            {
                poke3CB.SelectedIndex = 0;
                poke4CB.SelectedIndex = 0;
                poke5CB.SelectedIndex = 0;
                poke6CB.SelectedIndex = 0;
                ReadMoves(index);
                return;
            }
            poke3Lvl.Value = TeamData[offset];
            offset++;
            poke3CB.SelectedIndex = TeamData[offset];
            offset++;

            if (TeamData[offset] == 0xff)
            {
                poke4CB.SelectedIndex = 0;
                poke5CB.SelectedIndex = 0;
                poke6CB.SelectedIndex = 0;
                ReadMoves(index);
                return;
            }
            poke4Lvl.Value = TeamData[offset] & 0xff;
            offset++;
            poke4CB.SelectedIndex = TeamData[offset] & 0xff;
            offset++;

            if (TeamData[offset] == 0xff)
            {
                poke5CB.SelectedIndex = 0;
                poke6CB.SelectedIndex = 0;
                ReadMoves(index);
                return;
            }
            poke5Lvl.Value = TeamData[offset] & 0xff;
            offset++;
            poke5CB.SelectedIndex = TeamData[offset] & 0xff;
            offset++;

            if (TeamData[offset] == 0xff)
            {
                poke6CB.SelectedIndex = 0;
                ReadMoves(index);
                return;
            }
            poke6Lvl.Value = TeamData[offset] & 0xff;
            offset++;
            poke6CB.SelectedIndex = TeamData[offset] & 0xff;
            offset++;


            ReadMoves(index);
        }

        private void ReadMoves(int index)
        {
            int offset = index * (4*6); //Each team moves are stored as consecutive 4byte per move arrays (so 4 moves per 6 pokemon per team)

            //1
            poke1Move1CB.SelectedIndex = MoveData[offset];
            offset++;
            poke1Move2CB.SelectedIndex = MoveData[offset];
            offset++;
            poke1Move3CB.SelectedIndex = MoveData[offset];
            offset++;
            poke1Move4CB.SelectedIndex = MoveData[offset];
            offset++;

            //2
            poke2Move1CB.SelectedIndex = MoveData[offset];
            offset++;
            poke2Move2CB.SelectedIndex = MoveData[offset];
            offset++;
            poke2Move3CB.SelectedIndex = MoveData[offset];
            offset++;
            poke2Move4CB.SelectedIndex = MoveData[offset];
            offset++;

            //3
            poke3Move1CB.SelectedIndex = MoveData[offset];
            offset++;
            poke3Move2CB.SelectedIndex = MoveData[offset];
            offset++;
            poke3Move3CB.SelectedIndex = MoveData[offset];
            offset++;
            poke3Move4CB.SelectedIndex = MoveData[offset];
            offset++;

            //4
            poke4Move1CB.SelectedIndex = MoveData[offset];
            offset++;
            poke4Move2CB.SelectedIndex = MoveData[offset];
            offset++;
            poke4Move3CB.SelectedIndex = MoveData[offset];
            offset++;
            poke4Move4CB.SelectedIndex = MoveData[offset];
            offset++;

            //5
            poke5Move1CB.SelectedIndex = MoveData[offset];
            offset++;
            poke5Move2CB.SelectedIndex = MoveData[offset];
            offset++;
            poke5Move3CB.SelectedIndex = MoveData[offset];
            offset++;
            poke5Move4CB.SelectedIndex = MoveData[offset];
            offset++;

            //6
            poke6Move1CB.SelectedIndex = MoveData[offset];
            offset++;
            poke6Move2CB.SelectedIndex = MoveData[offset];
            offset++;
            poke6Move3CB.SelectedIndex = MoveData[offset];
            offset++;
            poke6Move4CB.SelectedIndex = MoveData[offset];
            offset++;
        }

        private void SaveTrainer()
        {
            int index = trainerCB.SelectedIndex;

            //Team Data
            int offsetTeam = index * (13);


            //Pokémon 1

            //Teams need at least 1 pokémon, so ensure it has at least one...
            if (poke1CB.SelectedIndex == 0)
            {
                MessageBox.Show("No pokémon detected in party slot 1, enforcing a level 5 Rhydon");
                TeamData[offsetTeam + 1] = 0x01;
                TeamData[offsetTeam] = 0x05;//enforce level
            }
            else
            {
                TeamData[offsetTeam] = (byte)poke1Lvl.Value;
                offsetTeam++;
                TeamData[offsetTeam] = (byte)poke1CB.SelectedIndex;
                offsetTeam++;
            }

            //Pokémon 2
            if (poke2CB.SelectedIndex == 0) //No species, put terminator
            {
                TeamData[offsetTeam] = 0xff;
                offsetTeam++;
                TeamData[offsetTeam] = 0xff;
                offsetTeam++;
            }
            else
            {
                TeamData[offsetTeam] = (byte)poke2Lvl.Value;
                offsetTeam++;
                TeamData[offsetTeam] = (byte)poke2CB.SelectedIndex;
                offsetTeam++;
            }

            //Pokémon 3
            if (poke3CB.SelectedIndex == 0) //No species, put terminator
            {
                TeamData[offsetTeam] = 0xff;
                offsetTeam++;
                TeamData[offsetTeam] = 0xff;
                offsetTeam++;
            }
            else
            {
                TeamData[offsetTeam] = (byte)poke3Lvl.Value;
                offsetTeam++;
                TeamData[offsetTeam] = (byte)poke3CB.SelectedIndex;
                offsetTeam++;
            }


            //Pokémon 4
            if (poke4CB.SelectedIndex == 0) //No species, put terminator
            {
                TeamData[offsetTeam] = 0xff;
                offsetTeam++;
                TeamData[offsetTeam] = 0xff;
                offsetTeam++;
            }
            else
            {
                TeamData[offsetTeam] = (byte)poke4Lvl.Value;
                offsetTeam++;
                TeamData[offsetTeam] = (byte)poke4CB.SelectedIndex;
                offsetTeam++;
            }

            //Pokémon 5
            if (poke5CB.SelectedIndex == 0) //No species, put terminator
            {
                TeamData[offsetTeam] = 0xff;
                offsetTeam++;
                TeamData[offsetTeam] = 0xff;
                offsetTeam++;
            }
            else
            {
                TeamData[offsetTeam] = (byte)poke5Lvl.Value;
                offsetTeam++;
                TeamData[offsetTeam] = (byte)poke5CB.SelectedIndex;
                offsetTeam++;
            }

            //Pokémon 6
            if (poke6CB.SelectedIndex == 0) //No species, put terminator
            {
                TeamData[offsetTeam] = 0xff;
                offsetTeam++;
                TeamData[offsetTeam] = 0xff;
                offsetTeam++;
            }
            else
            {
                TeamData[offsetTeam] = (byte)poke6Lvl.Value;
                offsetTeam++;
                TeamData[offsetTeam] = (byte)poke6CB.SelectedIndex;
                offsetTeam++;
            }

            //Move Data
            int offsetMoves = index * (4 * 6);

            //Poke 1
            MoveData[offsetMoves] = (byte)poke1Move1CB.SelectedIndex;
            offsetMoves++;
            MoveData[offsetMoves] = (byte)poke1Move2CB.SelectedIndex;
            offsetMoves++;
            MoveData[offsetMoves] = (byte)poke1Move3CB.SelectedIndex;
            offsetMoves++;
            MoveData[offsetMoves] = (byte)poke1Move4CB.SelectedIndex;
            offsetMoves++;

            //Poke 2
            MoveData[offsetMoves] = (byte)poke2Move1CB.SelectedIndex;
            offsetMoves++;
            MoveData[offsetMoves] = (byte)poke2Move2CB.SelectedIndex;
            offsetMoves++;
            MoveData[offsetMoves] = (byte)poke2Move3CB.SelectedIndex;
            offsetMoves++;
            MoveData[offsetMoves] = (byte)poke2Move4CB.SelectedIndex;
            offsetMoves++;

            //Poke 3
            MoveData[offsetMoves] = (byte)poke3Move1CB.SelectedIndex;
            offsetMoves++;
            MoveData[offsetMoves] = (byte)poke3Move2CB.SelectedIndex;
            offsetMoves++;
            MoveData[offsetMoves] = (byte)poke3Move3CB.SelectedIndex;
            offsetMoves++;
            MoveData[offsetMoves] = (byte)poke3Move4CB.SelectedIndex;
            offsetMoves++;

            //Poke 4
            MoveData[offsetMoves] = (byte)poke4Move1CB.SelectedIndex;
            offsetMoves++;
            MoveData[offsetMoves] = (byte)poke4Move2CB.SelectedIndex;
            offsetMoves++;
            MoveData[offsetMoves] = (byte)poke4Move3CB.SelectedIndex;
            offsetMoves++;
            MoveData[offsetMoves] = (byte)poke4Move4CB.SelectedIndex;
            offsetMoves++;

            //Poke 5
            MoveData[offsetMoves] = (byte)poke5Move1CB.SelectedIndex;
            offsetMoves++;
            MoveData[offsetMoves] = (byte)poke5Move2CB.SelectedIndex;
            offsetMoves++;
            MoveData[offsetMoves] = (byte)poke5Move3CB.SelectedIndex;
            offsetMoves++;
            MoveData[offsetMoves] = (byte)poke5Move4CB.SelectedIndex;
            offsetMoves++;

            //Poke 6
            MoveData[offsetMoves] = (byte)poke6Move1CB.SelectedIndex;
            offsetMoves++;
            MoveData[offsetMoves] = (byte)poke6Move2CB.SelectedIndex;
            offsetMoves++;
            MoveData[offsetMoves] = (byte)poke6Move3CB.SelectedIndex;
            offsetMoves++;
            MoveData[offsetMoves] = (byte)poke6Move4CB.SelectedIndex;
            offsetMoves++;
        }

        private void trainerCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            trainerGB.Text = trainerCB.SelectedItem.ToString();
            ReadTrainer(trainerCB.SelectedIndex);
        }

        private void saveTeamBut_Click(object sender, EventArgs e)
        {
            SaveTrainer();
            MessageBox.Show("Team Saved");

        }

        private void exitBut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveExitBut_Click(object sender, EventArgs e)
        {
            /* EvoMovesFreeBytes = SaveEvoMoveDataToBuffer();
             freespace.Text = EvoMovesFreeBytes.ToString() + " bytes free";
             //Copy changes to rom and close
             //Copy pointer table
             Buffer.BlockCopy(EvoMovePointerTableBuffer, 0, BrownEditor.MainForm.filebuffer, EvomovesPointerTableOffset, EvomovesTotalEntries * 2);
             //Copy evomove data
             Buffer.BlockCopy(EvoMoveDataBuffer, 0, BrownEditor.MainForm.filebuffer, EvomovesDataStartOffset, EvomovesDataSize);
            */
            Buffer.BlockCopy(TeamData, 0, BrownEditor.MainForm.filebuffer, TeamDataOffset, TeamDataSize);
            Buffer.BlockCopy(MoveData, 0, BrownEditor.MainForm.filebuffer, MoveDataOffset, MoveDataSize);
            Buffer.BlockCopy(TeamData, TeamDataSize+1, BrownEditor.MainForm.filebuffer, MuraTeamDataOffset, MuraTeamDataSize);
            this.Close();
            MessageBox.Show("Saved Gym Leader/E4 teams data to Rom");
        }

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
            "Noivern",
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
        };
    }
}
