namespace BrownEditor.editor
{
    partial class StatsEvos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Species = new System.Windows.Forms.ComboBox();
            this.label_Species = new System.Windows.Forms.Label();
            this.HP = new System.Windows.Forms.NumericUpDown();
            this.ATK = new System.Windows.Forms.NumericUpDown();
            this.DEF = new System.Windows.Forms.NumericUpDown();
            this.SPE = new System.Windows.Forms.NumericUpDown();
            this.SPC = new System.Windows.Forms.NumericUpDown();
            this.type1 = new System.Windows.Forms.ComboBox();
            this.type2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.GrowthRate = new System.Windows.Forms.ComboBox();
            this.catchRate = new System.Windows.Forms.NumericUpDown();
            this.baseEXP = new System.Windows.Forms.NumericUpDown();
            this.move1 = new System.Windows.Forms.ComboBox();
            this.move2 = new System.Windows.Forms.ComboBox();
            this.move3 = new System.Windows.Forms.ComboBox();
            this.move4 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.picFrontLab = new System.Windows.Forms.Label();
            this.picBackLab = new System.Windows.Forms.Label();
            this.picsBank_label = new System.Windows.Forms.Label();
            this.TMHMListBox = new System.Windows.Forms.CheckedListBox();
            this.dexnum = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.InjectFrontBut = new System.Windows.Forms.Button();
            this.InjectBackBut = new System.Windows.Forms.Button();
            this.SaveBut = new System.Windows.Forms.Button();
            this.ExitBut = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.picSize = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tempSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.HP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ATK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catchRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseEXP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dexnum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSize)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Species
            // 
            this.Species.FormattingEnabled = true;
            this.Species.Items.AddRange(new object[] {
            "001 - Bulbasaur",
            "002 - Ivysaur",
            "003 - Venusaur",
            "004 - Charmander",
            "005 - Charmeleon",
            "006 - Charizard",
            "007 - Squirtle",
            "008 - Wartortle",
            "009 - Blastoise",
            "010 - Caterpie",
            "011 - Metapod",
            "012 - Butterfree",
            "013 - Weedle",
            "014 - Kakuna",
            "015 - Beedrill",
            "016 - Pidgey",
            "017 - Pidgeotto",
            "018 - Pidgeot",
            "019 - Rattata",
            "020 - Raticate",
            "021 - Spearow",
            "022 - Fearow",
            "023 - Ekans",
            "024 - Arbok",
            "025 - Pikachu",
            "026 - Raichu",
            "027 - Sandshrew",
            "028 - Sandslash",
            "029 - NidoranF",
            "030 - Nidorina",
            "031 - Nidoqueen",
            "032 - NidoranM",
            "033 - Nidorino",
            "034 - Nidoking",
            "035 - Clefairy",
            "036 - Clefable",
            "037 - Vulpix",
            "038 - Ninetales",
            "039 - Jigglypuff",
            "040 - Wigglytuff",
            "041 - Zubat",
            "042 - Golbat",
            "043 - Oddish",
            "044 - Gloom",
            "045 - Vileplume",
            "046 - Paras",
            "047 - Parasect",
            "048 - Venonat",
            "049 - Venomoth",
            "050 - Diglett",
            "051 - Dugtrio",
            "052 - Meowth",
            "053 - Persian",
            "054 - Psyduck",
            "055 - Golduck",
            "056 - Mankey",
            "057 - Primeape",
            "058 - Growlithe",
            "059 - Arcanine",
            "060 - Poliwag",
            "061 - Poliwhirl",
            "062 - Poliwrath",
            "063 - Abra",
            "064 - Kadabra",
            "065 - Alakazam",
            "066 - Machop",
            "067 - Machoke",
            "068 - Machamp",
            "069 - Bellsprout",
            "070 - Weepinbell",
            "071 - Victreebel",
            "072 - Tentacool",
            "073 - Tentacruel",
            "074 - Geodude",
            "075 - Graveler",
            "076 - Golem",
            "077 - Ponyta",
            "078 - Rapidash",
            "079 - Slowpoke",
            "080 - Slowbro",
            "081 - Magnemite",
            "082 - Magneton",
            "083 - Farfetch\'d",
            "084 - Doduo",
            "085 - Dodrio",
            "086 - Seel",
            "087 - Dewgong",
            "088 - Grimer",
            "089 - Muk",
            "090 - Shellder",
            "091 - Cloyster",
            "092 - Gastly",
            "093 - Haunter",
            "094 - Gengar",
            "095 - Onix",
            "096 - Drowzee",
            "097 - Hypno",
            "098 - Krabby",
            "099 - Kingler",
            "100 - Voltorb",
            "101 - Electrode",
            "102 - Exeggcute",
            "103 - Exeggutor",
            "104 - Cubone",
            "105 - Marowak",
            "106 - Hitmonlee",
            "107 - Hitmonchan",
            "108 - Lickitung",
            "109 - Koffing",
            "110 - Weezing",
            "111 - Rhyhorn",
            "112 - Rhydon",
            "113 - Chansey",
            "114 - Tangela",
            "115 - Kangaskhan",
            "116 - Horsea",
            "117 - Seadra",
            "118 - Goldeen",
            "119 - Seaking",
            "120 - Staryu",
            "121 - Starmie",
            "122 - Mr. Mime",
            "123 - Scyther",
            "124 - Jynx",
            "125 - Electabuzz",
            "126 - Magmar",
            "127 - Pinsir",
            "128 - Tauros",
            "129 - Magikarp",
            "130 - Gyarados",
            "131 - Lapras",
            "132 - Ditto",
            "133 - Eevee",
            "134 - Vaporeon",
            "135 - Jolteon",
            "136 - Flareon",
            "137 - Porygon",
            "138 - Omanyte",
            "139 - Omastar",
            "140 - Kabuto",
            "141 - Kabutops",
            "142 - Aerodactyl",
            "143 - Snorlax",
            "144 - Articuno",
            "145 - Zapdos",
            "146 - Moltres",
            "147 - Dratini",
            "148 - Dragonair",
            "149 - Dragonite",
            "150 - Mewtwo",
            "151 - Mew",
            "152 - Chikorita",
            "153 - Bayleef",
            "154 - Meganium",
            "155 - Cyndaquil",
            "156 - Quilava",
            "157 - Typhlosion",
            "158 - Totodile",
            "159 - Croconaw",
            "160 - Feraligatr",
            "161 - Houndour",
            "162 - Houndoom",
            "163 - Heracross",
            "164 - Yanma",
            "165 - Yanmega",
            "166 - Spinarak",
            "167 - Ariados",
            "168 - Chinchou",
            "169 - Lanturn",
            "170 - Swinub",
            "171 - Piloswine",
            "172 - Mamoswine",
            "173 - Natu",
            "174 - Xatu",
            "175 - Mareep",
            "176 - Flaaffy",
            "177 - Ampharos",
            "178 - Marill",
            "179 - Azumarill",
            "180 - Murkrow",
            "181 - Honchkrow",
            "182 - Larvitar",
            "183 - Pupitar",
            "184 - Tyranitar",
            "185 - Phanpy",
            "186 - Donphan",
            "187 - Wooper",
            "188 - Quagsire",
            "189 - Togepi",
            "190 - Togetic",
            "191 - Togekiss",
            "192 - Gligar",
            "193 - Gliscor",
            "194 - Sneasel",
            "195 - Weavile",
            "196 - Tyrogue",
            "197 - Hitmontop",
            "198 - Misdreavus",
            "199 - Mismagius",
            "200 - Espeon",
            "201 - Umbreon",
            "202 - Leafeon",
            "203 - Glaceon",
            "204 - Magnezone",
            "205 - Electivire",
            "206 - Magmortar",
            "207 - Porygon2",
            "208 - Porygon-Z",
            "209 - Tangrowth",
            "210 - Scizor",
            "211 - Steelix",
            "212 - Slowking",
            "213 - Kingdra",
            "214 - Rhyperior",
            "215 - Blissey",
            "216 - Crobat",
            "217 - Politoed",
            "218 - Raikou",
            "219 - Entei",
            "220 - Suicune",
            "221 - Lugia",
            "222 - Ho-Oh",
            "223 - Cranidos",
            "224 - Rampardos",
            "225 - Sylveon",
            "226 - Annihilape",
            "227 - G.Weezing",
            "228 - Lickilicky",
            "229 - ?????",
            "230 - ?????",
            "231 - ?????",
            "232 - ?????",
            "233 - ?????",
            "234 - ?????",
            "235 - ?????",
            "236 - ?????",
            "237 - ?????",
            "238 - ?????",
            "239 - ?????",
            "240 - ?????",
            "241 - ?????",
            "242 - ?????",
            "243 - ?????",
            "244 - ?????",
            "245 - ?????",
            "246 - ?????",
            "247 - ?????",
            "248 - ?????",
            "249 - ?????",
            "250 - ?????",
            "251 - ?????",
            "252 - Phancero",
            "253 - ?????",
            "254 - ?????",
            "255 - ?????"});
            this.Species.Location = new System.Drawing.Point(95, 6);
            this.Species.Name = "Species";
            this.Species.Size = new System.Drawing.Size(205, 21);
            this.Species.TabIndex = 0;
            this.Species.SelectedIndexChanged += new System.EventHandler(this.comboBox_Species_SelectedIndexChanged);
            // 
            // label_Species
            // 
            this.label_Species.AutoSize = true;
            this.label_Species.Location = new System.Drawing.Point(12, 9);
            this.label_Species.Name = "label_Species";
            this.label_Species.Size = new System.Drawing.Size(77, 13);
            this.label_Species.TabIndex = 1;
            this.label_Species.Text = "Species Index:";
            // 
            // HP
            // 
            this.HP.Location = new System.Drawing.Point(15, 74);
            this.HP.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.HP.Name = "HP";
            this.HP.Size = new System.Drawing.Size(42, 20);
            this.HP.TabIndex = 2;
            // 
            // ATK
            // 
            this.ATK.Location = new System.Drawing.Point(63, 74);
            this.ATK.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ATK.Name = "ATK";
            this.ATK.Size = new System.Drawing.Size(42, 20);
            this.ATK.TabIndex = 3;
            // 
            // DEF
            // 
            this.DEF.Location = new System.Drawing.Point(111, 74);
            this.DEF.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.DEF.Name = "DEF";
            this.DEF.Size = new System.Drawing.Size(42, 20);
            this.DEF.TabIndex = 4;
            // 
            // SPE
            // 
            this.SPE.Location = new System.Drawing.Point(159, 74);
            this.SPE.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.SPE.Name = "SPE";
            this.SPE.Size = new System.Drawing.Size(42, 20);
            this.SPE.TabIndex = 5;
            // 
            // SPC
            // 
            this.SPC.Location = new System.Drawing.Point(207, 74);
            this.SPC.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.SPC.Name = "SPC";
            this.SPC.Size = new System.Drawing.Size(42, 20);
            this.SPC.TabIndex = 6;
            // 
            // type1
            // 
            this.type1.FormattingEnabled = true;
            this.type1.Items.AddRange(new object[] {
            "0x00 NORMAL",
            "0x01 FIGHTING",
            "0x02 FLYING",
            "0x03 POISON",
            "0x04 GROUND",
            "0x05 ROCK",
            "0x06 BIRD",
            "0x07 BUG",
            "0x08 GHOST",
            "0x09 STEEL",
            "0x0A",
            "0x0B",
            "0x0C",
            "0x0D WIND",
            "0x0E SOUND",
            "0x0F TRI",
            "0x10",
            "0x11",
            "0x12",
            "0x13",
            "0x14 FIRE",
            "0x15 WATER",
            "0x16 GRASS",
            "0x17 ELECTRIC",
            "0x18 PSYCHIC",
            "0x19 ICE",
            "0x1A DRAGON",
            "0x1B DARK",
            "0x1C WOOD",
            "0x1D GAS",
            "0x1E ABNORMAL",
            "0x1F FAIRY"});
            this.type1.Location = new System.Drawing.Point(15, 125);
            this.type1.Name = "type1";
            this.type1.Size = new System.Drawing.Size(121, 21);
            this.type1.TabIndex = 7;
            // 
            // type2
            // 
            this.type2.FormattingEnabled = true;
            this.type2.Items.AddRange(new object[] {
            "0x00 NORMAL",
            "0x01 FIGHTING",
            "0x02 FLYING",
            "0x03 POISON",
            "0x04 GROUND",
            "0x05 ROCK",
            "0x06 BIRD",
            "0x07 BUG",
            "0x08 GHOST",
            "0x09 STEEL",
            "0x0A",
            "0x0B",
            "0x0C",
            "0x0D WIND",
            "0x0E SOUND",
            "0x0F TRI",
            "0x10",
            "0x11",
            "0x12",
            "0x13",
            "0x14 FIRE",
            "0x15 WATER",
            "0x16 GRASS",
            "0x17 ELECTRIC",
            "0x18 PSYCHIC",
            "0x19 ICE",
            "0x1A DRAGON",
            "0x1B DARK",
            "0x1C WOOD",
            "0x1D GAS",
            "0x1E ABNORMAL",
            "0x1F FAIRY"});
            this.type2.Location = new System.Drawing.Point(142, 125);
            this.type2.Name = "type2";
            this.type2.Size = new System.Drawing.Size(121, 21);
            this.type2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "HP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "ATK";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "DEF";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "SPE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(204, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "SPC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Type 1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(139, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Type 2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(139, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Base EXP";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Catch Rate";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Growth Rate";
            // 
            // GrowthRate
            // 
            this.GrowthRate.FormattingEnabled = true;
            this.GrowthRate.Items.AddRange(new object[] {
            "Medium Fast",
            "Slightly Fast",
            "Slightly Slow",
            "Medium Slow",
            "Fast",
            "Slow"});
            this.GrowthRate.Location = new System.Drawing.Point(15, 214);
            this.GrowthRate.Name = "GrowthRate";
            this.GrowthRate.Size = new System.Drawing.Size(121, 21);
            this.GrowthRate.TabIndex = 20;
            // 
            // catchRate
            // 
            this.catchRate.Location = new System.Drawing.Point(15, 169);
            this.catchRate.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.catchRate.Name = "catchRate";
            this.catchRate.Size = new System.Drawing.Size(121, 20);
            this.catchRate.TabIndex = 22;
            // 
            // baseEXP
            // 
            this.baseEXP.Location = new System.Drawing.Point(142, 169);
            this.baseEXP.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.baseEXP.Name = "baseEXP";
            this.baseEXP.Size = new System.Drawing.Size(121, 20);
            this.baseEXP.TabIndex = 23;
            // 
            // move1
            // 
            this.move1.FormattingEnabled = true;
            this.move1.Location = new System.Drawing.Point(142, 241);
            this.move1.Name = "move1";
            this.move1.Size = new System.Drawing.Size(121, 21);
            this.move1.TabIndex = 80;
            // 
            // move2
            // 
            this.move2.FormattingEnabled = true;
            this.move2.Location = new System.Drawing.Point(142, 268);
            this.move2.Name = "move2";
            this.move2.Size = new System.Drawing.Size(121, 21);
            this.move2.TabIndex = 81;
            // 
            // move3
            // 
            this.move3.FormattingEnabled = true;
            this.move3.Location = new System.Drawing.Point(142, 295);
            this.move3.Name = "move3";
            this.move3.Size = new System.Drawing.Size(121, 21);
            this.move3.TabIndex = 82;
            // 
            // move4
            // 
            this.move4.FormattingEnabled = true;
            this.move4.Location = new System.Drawing.Point(142, 322);
            this.move4.Name = "move4";
            this.move4.Size = new System.Drawing.Size(121, 21);
            this.move4.TabIndex = 83;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 244);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 84;
            this.label11.Text = "Level 1 Learnset:";
            // 
            // picFrontLab
            // 
            this.picFrontLab.AutoSize = true;
            this.picFrontLab.Location = new System.Drawing.Point(6, 40);
            this.picFrontLab.Name = "picFrontLab";
            this.picFrontLab.Size = new System.Drawing.Size(83, 13);
            this.picFrontLab.TabIndex = 85;
            this.picFrontLab.Text = "Front Pic Offset:";
            // 
            // picBackLab
            // 
            this.picBackLab.AutoSize = true;
            this.picBackLab.Location = new System.Drawing.Point(6, 57);
            this.picBackLab.Name = "picBackLab";
            this.picBackLab.Size = new System.Drawing.Size(84, 13);
            this.picBackLab.TabIndex = 86;
            this.picBackLab.Text = "Back Pic Offset:";
            // 
            // picsBank_label
            // 
            this.picsBank_label.AutoSize = true;
            this.picsBank_label.Location = new System.Drawing.Point(6, 76);
            this.picsBank_label.Name = "picsBank_label";
            this.picsBank_label.Size = new System.Drawing.Size(58, 13);
            this.picsBank_label.TabIndex = 87;
            this.picsBank_label.Text = "Pics Bank:";
            // 
            // TMHMListBox
            // 
            this.TMHMListBox.CheckOnClick = true;
            this.TMHMListBox.FormattingEnabled = true;
            this.TMHMListBox.Location = new System.Drawing.Point(282, 59);
            this.TMHMListBox.Name = "TMHMListBox";
            this.TMHMListBox.Size = new System.Drawing.Size(200, 409);
            this.TMHMListBox.TabIndex = 88;
            // 
            // dexnum
            // 
            this.dexnum.Location = new System.Drawing.Point(387, 7);
            this.dexnum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.dexnum.Name = "dexnum";
            this.dexnum.ReadOnly = true;
            this.dexnum.Size = new System.Drawing.Size(56, 20);
            this.dexnum.TabIndex = 89;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(330, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 13);
            this.label14.TabIndex = 90;
            this.label14.Text = "DexNum:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(116, 244);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 13);
            this.label15.TabIndex = 91;
            this.label15.Text = "#1";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(116, 271);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(20, 13);
            this.label16.TabIndex = 92;
            this.label16.Text = "#2";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(116, 298);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 13);
            this.label17.TabIndex = 93;
            this.label17.Text = "#3";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(116, 327);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 13);
            this.label18.TabIndex = 94;
            this.label18.Text = "#4";
            // 
            // InjectFrontBut
            // 
            this.InjectFrontBut.Location = new System.Drawing.Point(34, 92);
            this.InjectFrontBut.Name = "InjectFrontBut";
            this.InjectFrontBut.Size = new System.Drawing.Size(93, 22);
            this.InjectFrontBut.TabIndex = 95;
            this.InjectFrontBut.Text = "Inject FrontPic";
            this.InjectFrontBut.UseVisualStyleBackColor = true;
            this.InjectFrontBut.Click += new System.EventHandler(this.InjectFrontBut_Click);
            // 
            // InjectBackBut
            // 
            this.InjectBackBut.Location = new System.Drawing.Point(133, 92);
            this.InjectBackBut.Name = "InjectBackBut";
            this.InjectBackBut.Size = new System.Drawing.Size(93, 22);
            this.InjectBackBut.TabIndex = 96;
            this.InjectBackBut.Text = "Inject BackPic";
            this.InjectBackBut.UseVisualStyleBackColor = true;
            this.InjectBackBut.Click += new System.EventHandler(this.InjectBackBut_Click);
            // 
            // SaveBut
            // 
            this.SaveBut.Location = new System.Drawing.Point(63, 518);
            this.SaveBut.Name = "SaveBut";
            this.SaveBut.Size = new System.Drawing.Size(138, 22);
            this.SaveBut.TabIndex = 97;
            this.SaveBut.Text = "Apply all to Rom and exit";
            this.SaveBut.UseVisualStyleBackColor = true;
            this.SaveBut.Click += new System.EventHandler(this.SaveBut_Click);
            // 
            // ExitBut
            // 
            this.ExitBut.Location = new System.Drawing.Point(293, 518);
            this.ExitBut.Name = "ExitBut";
            this.ExitBut.Size = new System.Drawing.Size(159, 23);
            this.ExitBut.TabIndex = 98;
            this.ExitBut.Text = "Exit without saving";
            this.ExitBut.UseVisualStyleBackColor = true;
            this.ExitBut.Click += new System.EventHandler(this.ExitBut_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 13);
            this.label12.TabIndex = 99;
            this.label12.Text = "Sprite Dimensions (HEX):";
            // 
            // picSize
            // 
            this.picSize.Hexadecimal = true;
            this.picSize.Location = new System.Drawing.Point(137, 14);
            this.picSize.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.picSize.Name = "picSize";
            this.picSize.ReadOnly = true;
            this.picSize.Size = new System.Drawing.Size(58, 20);
            this.picSize.TabIndex = 100;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.picSize);
            this.groupBox1.Controls.Add(this.picFrontLab);
            this.groupBox1.Controls.Add(this.picBackLab);
            this.groupBox1.Controls.Add(this.picsBank_label);
            this.groupBox1.Controls.Add(this.InjectFrontBut);
            this.groupBox1.Controls.Add(this.InjectBackBut);
            this.groupBox1.Location = new System.Drawing.Point(19, 349);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 124);
            this.groupBox1.TabIndex = 101;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Battle Sprites";
            // 
            // tempSave
            // 
            this.tempSave.Location = new System.Drawing.Point(207, 479);
            this.tempSave.Name = "tempSave";
            this.tempSave.Size = new System.Drawing.Size(93, 22);
            this.tempSave.TabIndex = 102;
            this.tempSave.Text = "Save";
            this.tempSave.UseVisualStyleBackColor = true;
            this.tempSave.Click += new System.EventHandler(this.tempSave_Click);
            // 
            // StatsEvos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 553);
            this.Controls.Add(this.tempSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ExitBut);
            this.Controls.Add(this.SaveBut);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dexnum);
            this.Controls.Add(this.TMHMListBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.move4);
            this.Controls.Add(this.move3);
            this.Controls.Add(this.move2);
            this.Controls.Add(this.move1);
            this.Controls.Add(this.baseEXP);
            this.Controls.Add(this.catchRate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.GrowthRate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.type2);
            this.Controls.Add(this.type1);
            this.Controls.Add(this.SPC);
            this.Controls.Add(this.SPE);
            this.Controls.Add(this.DEF);
            this.Controls.Add(this.ATK);
            this.Controls.Add(this.HP);
            this.Controls.Add(this.label_Species);
            this.Controls.Add(this.Species);
            this.Name = "StatsEvos";
            this.Text = "Base Stats Editor";
            ((System.ComponentModel.ISupportInitialize)(this.HP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ATK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catchRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseEXP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dexnum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Species;
        private System.Windows.Forms.Label label_Species;
        private System.Windows.Forms.NumericUpDown HP;
        private System.Windows.Forms.NumericUpDown ATK;
        private System.Windows.Forms.NumericUpDown DEF;
        private System.Windows.Forms.NumericUpDown SPE;
        private System.Windows.Forms.NumericUpDown SPC;
        private System.Windows.Forms.ComboBox type1;
        private System.Windows.Forms.ComboBox type2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox GrowthRate;
        private System.Windows.Forms.NumericUpDown catchRate;
        private System.Windows.Forms.NumericUpDown baseEXP;
        private System.Windows.Forms.ComboBox move1;
        private System.Windows.Forms.ComboBox move2;
        private System.Windows.Forms.ComboBox move3;
        private System.Windows.Forms.ComboBox move4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label picFrontLab;
        private System.Windows.Forms.Label picBackLab;
        private System.Windows.Forms.Label picsBank_label;
        private System.Windows.Forms.CheckedListBox TMHMListBox;
        private System.Windows.Forms.NumericUpDown dexnum;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button InjectFrontBut;
        private System.Windows.Forms.Button InjectBackBut;
        private System.Windows.Forms.Button SaveBut;
        private System.Windows.Forms.Button ExitBut;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown picSize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button tempSave;
    }
}