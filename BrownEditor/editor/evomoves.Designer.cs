namespace BrownEditor.editor
{
    partial class evomoves
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
            this.evosGrid = new System.Windows.Forms.DataGridView();
            this.Entry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EvoMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EvoLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EvoSpecies = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemGeo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.learnsetGrid = new System.Windows.Forms.DataGridView();
            this.LSEntry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LSLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LSMove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.evoTypeBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.evoLevelUD = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.evoSpeciesBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.evoItemMapBox = new System.Windows.Forms.ComboBox();
            this.speciesBox = new System.Windows.Forms.ComboBox();
            this.moveLevelUD = new System.Windows.Forms.NumericUpDown();
            this.moveLearnBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveEvoBut = new System.Windows.Forms.Button();
            this.removeEvoBut = new System.Windows.Forms.Button();
            this.addEvoBut = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.saveMoveBut = new System.Windows.Forms.Button();
            this.removeMoveBut = new System.Windows.Forms.Button();
            this.addMoveBut = new System.Windows.Forms.Button();
            this.evolveFromLabel = new System.Windows.Forms.Label();
            this.exitBut = new System.Windows.Forms.Button();
            this.saveExitBut = new System.Windows.Forms.Button();
            this.ReminderLabel = new System.Windows.Forms.Label();
            this.freespace = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.freespace_text = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.evosGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.learnsetGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evoLevelUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveLevelUD)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // evosGrid
            // 
            this.evosGrid.AllowUserToAddRows = false;
            this.evosGrid.AllowUserToDeleteRows = false;
            this.evosGrid.AllowUserToResizeRows = false;
            this.evosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.evosGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Entry,
            this.EvoMethod,
            this.EvoLevel,
            this.EvoSpecies,
            this.ItemGeo});
            this.evosGrid.Location = new System.Drawing.Point(6, 95);
            this.evosGrid.Name = "evosGrid";
            this.evosGrid.Size = new System.Drawing.Size(689, 150);
            this.evosGrid.TabIndex = 0;
            this.evosGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.evosGrid_CellClick);
            this.evosGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.evosGrid_CellContentClick_1);
            this.evosGrid.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.evosGrid_RowHeaderMouseClick);
            this.evosGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.evosGrid_KeyDown);
            this.evosGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.evosGrid_KeyUp);
            // 
            // Entry
            // 
            this.Entry.HeaderText = "Entry";
            this.Entry.Name = "Entry";
            // 
            // EvoMethod
            // 
            this.EvoMethod.HeaderText = "Evolution Method";
            this.EvoMethod.Name = "EvoMethod";
            this.EvoMethod.ReadOnly = true;
            // 
            // EvoLevel
            // 
            this.EvoLevel.HeaderText = "Evolution Level";
            this.EvoLevel.Name = "EvoLevel";
            this.EvoLevel.ReadOnly = true;
            // 
            // EvoSpecies
            // 
            this.EvoSpecies.HeaderText = "Evo Species";
            this.EvoSpecies.Name = "EvoSpecies";
            this.EvoSpecies.ReadOnly = true;
            // 
            // ItemGeo
            // 
            this.ItemGeo.HeaderText = "Item/Map";
            this.ItemGeo.Name = "ItemGeo";
            this.ItemGeo.ReadOnly = true;
            this.ItemGeo.Width = 200;
            // 
            // learnsetGrid
            // 
            this.learnsetGrid.AllowUserToAddRows = false;
            this.learnsetGrid.AllowUserToDeleteRows = false;
            this.learnsetGrid.AllowUserToResizeRows = false;
            this.learnsetGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.learnsetGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LSEntry,
            this.LSLevel,
            this.LSMove});
            this.learnsetGrid.Location = new System.Drawing.Point(8, 19);
            this.learnsetGrid.Name = "learnsetGrid";
            this.learnsetGrid.Size = new System.Drawing.Size(347, 215);
            this.learnsetGrid.TabIndex = 1;
            this.learnsetGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.learnsetGrid_CellClick);
            this.learnsetGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.learnsetGrid_CellContentClick);
            this.learnsetGrid.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.learnsetGrid_RowHeaderMouseClick);
            this.learnsetGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.learnsetGrid_KeyDown);
            this.learnsetGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.learnsetGrid_KeyUp);
            // 
            // LSEntry
            // 
            this.LSEntry.HeaderText = "Entry";
            this.LSEntry.Name = "LSEntry";
            this.LSEntry.ReadOnly = true;
            // 
            // LSLevel
            // 
            this.LSLevel.HeaderText = "Level";
            this.LSLevel.Name = "LSLevel";
            this.LSLevel.ReadOnly = true;
            // 
            // LSMove
            // 
            this.LSMove.HeaderText = "Move";
            this.LSMove.Name = "LSMove";
            this.LSMove.ReadOnly = true;
            // 
            // evoTypeBox
            // 
            this.evoTypeBox.FormattingEnabled = true;
            this.evoTypeBox.Items.AddRange(new object[] {
            "NO EVOLUTION",
            "EV_LEVEL",
            "EV_ITEM",
            "EV_TRADE",
            "EV_GEO",
            "EV_ATTAK",
            "EV_DEFENSE",
            "EV_ATKEQDEF"});
            this.evoTypeBox.Location = new System.Drawing.Point(6, 36);
            this.evoTypeBox.Name = "evoTypeBox";
            this.evoTypeBox.Size = new System.Drawing.Size(121, 21);
            this.evoTypeBox.TabIndex = 2;
            this.evoTypeBox.SelectedIndexChanged += new System.EventHandler(this.evoTypeBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Evolution Type";
            // 
            // evoLevelUD
            // 
            this.evoLevelUD.Location = new System.Drawing.Point(158, 36);
            this.evoLevelUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.evoLevelUD.Name = "evoLevelUD";
            this.evoLevelUD.Size = new System.Drawing.Size(120, 20);
            this.evoLevelUD.TabIndex = 4;
            this.evoLevelUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Evolution Level";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Evolve to Species";
            // 
            // evoSpeciesBox
            // 
            this.evoSpeciesBox.FormattingEnabled = true;
            this.evoSpeciesBox.Items.AddRange(new object[] {
            "0x00",
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
            "Mr.Mime",
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
            "Farfetch\'d",
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
            "Eevee(Espeon)",
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
            "Tyrogue(Hitmonchan)",
            "Muk",
            "Suicune",
            "Kingler",
            "Cloyster",
            "Tyrogue(Hitmonlee)",
            "Electrode",
            "Clefable",
            "Weezing",
            "Persian",
            "Marowak",
            "Noibat",
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
            "Ghost(MissingNo.)",
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
            "Eevee(Umbreon)",
            "Eevee(Leafeon)",
            "Eevee(Glaceon)",
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
            "Noivern"});
            this.evoSpeciesBox.Location = new System.Drawing.Point(303, 36);
            this.evoSpeciesBox.Name = "evoSpeciesBox";
            this.evoSpeciesBox.Size = new System.Drawing.Size(121, 21);
            this.evoSpeciesBox.TabIndex = 6;
            this.evoSpeciesBox.SelectedIndexChanged += new System.EventHandler(this.evoSpeciesBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(454, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Evolution Item / Map";
            // 
            // evoItemMapBox
            // 
            this.evoItemMapBox.FormattingEnabled = true;
            this.evoItemMapBox.Items.AddRange(new object[] {
            "NO EVOLUTION",
            "EV_LEVEL",
            "EV_ITEM",
            "EV_TRADE",
            "EV_GEO",
            "EV_ATTAK",
            "EV_DEFENSE",
            "EV_ATKEQDEF"});
            this.evoItemMapBox.Location = new System.Drawing.Point(457, 37);
            this.evoItemMapBox.Name = "evoItemMapBox";
            this.evoItemMapBox.Size = new System.Drawing.Size(238, 21);
            this.evoItemMapBox.TabIndex = 8;
            // 
            // speciesBox
            // 
            this.speciesBox.FormattingEnabled = true;
            this.speciesBox.Location = new System.Drawing.Point(66, 15);
            this.speciesBox.Name = "speciesBox";
            this.speciesBox.Size = new System.Drawing.Size(172, 21);
            this.speciesBox.TabIndex = 10;
            this.speciesBox.SelectedIndexChanged += new System.EventHandler(this.speciesBox_SelectedIndexChanged);
            // 
            // moveLevelUD
            // 
            this.moveLevelUD.Location = new System.Drawing.Point(403, 19);
            this.moveLevelUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.moveLevelUD.Name = "moveLevelUD";
            this.moveLevelUD.Size = new System.Drawing.Size(120, 20);
            this.moveLevelUD.TabIndex = 11;
            this.moveLevelUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // moveLearnBox
            // 
            this.moveLearnBox.FormattingEnabled = true;
            this.moveLearnBox.Location = new System.Drawing.Point(402, 50);
            this.moveLearnBox.Name = "moveLearnBox";
            this.moveLearnBox.Size = new System.Drawing.Size(121, 21);
            this.moveLearnBox.TabIndex = 12;
            this.moveLearnBox.SelectedIndexChanged += new System.EventHandler(this.moveLearnBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(361, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Level:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(360, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Move:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.saveEvoBut);
            this.groupBox1.Controls.Add(this.removeEvoBut);
            this.groupBox1.Controls.Add(this.addEvoBut);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.evoItemMapBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.evoSpeciesBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.evoLevelUD);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.evoTypeBox);
            this.groupBox1.Controls.Add(this.evosGrid);
            this.groupBox1.Location = new System.Drawing.Point(12, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(811, 251);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Evolutions";
            // 
            // saveEvoBut
            // 
            this.saveEvoBut.Enabled = false;
            this.saveEvoBut.Location = new System.Drawing.Point(718, 24);
            this.saveEvoBut.Name = "saveEvoBut";
            this.saveEvoBut.Size = new System.Drawing.Size(75, 40);
            this.saveEvoBut.TabIndex = 12;
            this.saveEvoBut.Text = "Save EVO";
            this.saveEvoBut.UseVisualStyleBackColor = true;
            this.saveEvoBut.Click += new System.EventHandler(this.saveEvoBut_Click);
            // 
            // removeEvoBut
            // 
            this.removeEvoBut.Enabled = false;
            this.removeEvoBut.Location = new System.Drawing.Point(718, 205);
            this.removeEvoBut.Name = "removeEvoBut";
            this.removeEvoBut.Size = new System.Drawing.Size(75, 40);
            this.removeEvoBut.TabIndex = 11;
            this.removeEvoBut.Text = "Remove EVO";
            this.removeEvoBut.UseVisualStyleBackColor = true;
            this.removeEvoBut.Click += new System.EventHandler(this.removeEvoBut_Click);
            // 
            // addEvoBut
            // 
            this.addEvoBut.Location = new System.Drawing.Point(718, 95);
            this.addEvoBut.Name = "addEvoBut";
            this.addEvoBut.Size = new System.Drawing.Size(75, 40);
            this.addEvoBut.TabIndex = 10;
            this.addEvoBut.Text = "Save as new EVO";
            this.addEvoBut.UseVisualStyleBackColor = true;
            this.addEvoBut.Click += new System.EventHandler(this.addEvoBut_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Species:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.saveMoveBut);
            this.groupBox2.Controls.Add(this.removeMoveBut);
            this.groupBox2.Controls.Add(this.addMoveBut);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.moveLearnBox);
            this.groupBox2.Controls.Add(this.moveLevelUD);
            this.groupBox2.Controls.Add(this.learnsetGrid);
            this.groupBox2.Location = new System.Drawing.Point(10, 313);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(562, 251);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Learnset";
            // 
            // saveMoveBut
            // 
            this.saveMoveBut.Location = new System.Drawing.Point(426, 77);
            this.saveMoveBut.Name = "saveMoveBut";
            this.saveMoveBut.Size = new System.Drawing.Size(75, 40);
            this.saveMoveBut.TabIndex = 13;
            this.saveMoveBut.Text = "Save Move";
            this.saveMoveBut.UseVisualStyleBackColor = true;
            this.saveMoveBut.Click += new System.EventHandler(this.saveMoveBut_Click);
            // 
            // removeMoveBut
            // 
            this.removeMoveBut.Location = new System.Drawing.Point(481, 194);
            this.removeMoveBut.Name = "removeMoveBut";
            this.removeMoveBut.Size = new System.Drawing.Size(75, 40);
            this.removeMoveBut.TabIndex = 14;
            this.removeMoveBut.Text = "Remove Move";
            this.removeMoveBut.UseVisualStyleBackColor = true;
            this.removeMoveBut.Click += new System.EventHandler(this.removeMoveBut_Click);
            // 
            // addMoveBut
            // 
            this.addMoveBut.Location = new System.Drawing.Point(364, 194);
            this.addMoveBut.Name = "addMoveBut";
            this.addMoveBut.Size = new System.Drawing.Size(75, 40);
            this.addMoveBut.TabIndex = 13;
            this.addMoveBut.Text = "Add Move";
            this.addMoveBut.UseVisualStyleBackColor = true;
            this.addMoveBut.Click += new System.EventHandler(this.addMoveBut_Click);
            // 
            // evolveFromLabel
            // 
            this.evolveFromLabel.AutoSize = true;
            this.evolveFromLabel.Location = new System.Drawing.Point(6, 17);
            this.evolveFromLabel.Name = "evolveFromLabel";
            this.evolveFromLabel.Size = new System.Drawing.Size(132, 13);
            this.evolveFromLabel.TabIndex = 15;
            this.evolveFromLabel.Text = "This species evolves from:";
            // 
            // exitBut
            // 
            this.exitBut.Location = new System.Drawing.Point(125, 626);
            this.exitBut.Name = "exitBut";
            this.exitBut.Size = new System.Drawing.Size(109, 23);
            this.exitBut.TabIndex = 18;
            this.exitBut.Text = "Exit without saving";
            this.exitBut.UseVisualStyleBackColor = true;
            this.exitBut.Click += new System.EventHandler(this.exitBut_Click);
            // 
            // saveExitBut
            // 
            this.saveExitBut.Location = new System.Drawing.Point(10, 626);
            this.saveExitBut.Name = "saveExitBut";
            this.saveExitBut.Size = new System.Drawing.Size(109, 23);
            this.saveExitBut.TabIndex = 19;
            this.saveExitBut.Text = "Save and Exit";
            this.saveExitBut.UseVisualStyleBackColor = true;
            this.saveExitBut.Click += new System.EventHandler(this.saveExitBut_Click);
            // 
            // ReminderLabel
            // 
            this.ReminderLabel.AutoSize = true;
            this.ReminderLabel.Location = new System.Drawing.Point(12, 567);
            this.ReminderLabel.Name = "ReminderLabel";
            this.ReminderLabel.Size = new System.Drawing.Size(35, 13);
            this.ReminderLabel.TabIndex = 20;
            this.ReminderLabel.Text = "label8";
            // 
            // freespace
            // 
            this.freespace.AutoSize = true;
            this.freespace.Location = new System.Drawing.Point(161, 11);
            this.freespace.Name = "freespace";
            this.freespace.Size = new System.Drawing.Size(35, 13);
            this.freespace.TabIndex = 21;
            this.freespace.Text = "label8";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.freespace_text);
            this.groupBox3.Controls.Add(this.freespace);
            this.groupBox3.Location = new System.Drawing.Point(240, 570);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(332, 69);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Free EvoMove data space";
            // 
            // freespace_text
            // 
            this.freespace_text.AutoSize = true;
            this.freespace_text.Location = new System.Drawing.Point(6, 26);
            this.freespace_text.Name = "freespace_text";
            this.freespace_text.Size = new System.Drawing.Size(35, 13);
            this.freespace_text.TabIndex = 22;
            this.freespace_text.Text = "label8";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.evolveFromLabel);
            this.groupBox4.Location = new System.Drawing.Point(578, 313);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(245, 326);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            // 
            // evomoves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 661);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.ReminderLabel);
            this.Controls.Add(this.saveExitBut);
            this.Controls.Add(this.exitBut);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.speciesBox);
            this.Name = "evomoves";
            this.Text = "Evolution and Learnset Editor";
            ((System.ComponentModel.ISupportInitialize)(this.evosGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.learnsetGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evoLevelUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveLevelUD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView evosGrid;
        private System.Windows.Forms.DataGridView learnsetGrid;
        private System.Windows.Forms.ComboBox evoTypeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown evoLevelUD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox evoSpeciesBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox evoItemMapBox;
        private System.Windows.Forms.ComboBox speciesBox;
        private System.Windows.Forms.NumericUpDown moveLevelUD;
        private System.Windows.Forms.ComboBox moveLearnBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn LSEntry;
        private System.Windows.Forms.DataGridViewTextBoxColumn LSLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn LSMove;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entry;
        private System.Windows.Forms.DataGridViewTextBoxColumn EvoMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn EvoLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn EvoSpecies;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemGeo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button saveEvoBut;
        private System.Windows.Forms.Button removeEvoBut;
        private System.Windows.Forms.Button addEvoBut;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button saveMoveBut;
        private System.Windows.Forms.Button removeMoveBut;
        private System.Windows.Forms.Button addMoveBut;
        private System.Windows.Forms.Button exitBut;
        private System.Windows.Forms.Button saveExitBut;
        private System.Windows.Forms.Label ReminderLabel;
        private System.Windows.Forms.Label freespace;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label freespace_text;
        private System.Windows.Forms.Label evolveFromLabel;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}