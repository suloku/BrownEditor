namespace BrownEditor.editor
{
    partial class MoveEditor
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
            this.SelectedMove = new System.Windows.Forms.ComboBox();
            this.movePower = new System.Windows.Forms.NumericUpDown();
            this.moveAnim = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.moveEffect = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.movePP = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.moveAccuracy = new System.Windows.Forms.NumericUpDown();
            this.moveType = new System.Windows.Forms.ComboBox();
            this.accuracypercentLab = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MoveIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoveName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.psSplit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Power = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accuracy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Effect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaveMoveBut = new System.Windows.Forms.Button();
            this.SaveExitBut = new System.Windows.Forms.Button();
            this.MoveNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.psSplitCheckbox = new System.Windows.Forms.CheckBox();
            this.ExitBut = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.movePower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movePP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveAccuracy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectedMove
            // 
            this.SelectedMove.FormattingEnabled = true;
            this.SelectedMove.Items.AddRange(new object[] {
            "001 - Pound",
            "002 - Karate Chop",
            "003 - Doubleslap",
            "004 - Comet Punch",
            "005 - Mega Punch",
            "006 - Pay Day",
            "007 - Fire Punch",
            "008 - Ice Punch",
            "009 - Thunderpunch",
            "010 - Scratch",
            "011 - Vicegrip",
            "012 - Guillotine",
            "013 - Razor Wind",
            "014 - Swords Dance",
            "015 - Cut",
            "016 - Gust",
            "017 - Wing Attack",
            "018 - Whirlwind",
            "019 - Fly",
            "020 - Bind",
            "021 - Slam",
            "022 - Vine Whip",
            "023 - Stomp",
            "024 - Double Kick",
            "025 - Mega Kick",
            "026 - Jump Kick",
            "027 - Rolling Kick",
            "028 - Sand Attack",
            "029 - Headbutt",
            "030 - Horn Attack",
            "031 - Fury Attack",
            "032 - Horn Drill",
            "033 - Tackle",
            "034 - Body Slam",
            "035 - Wrap",
            "036 - Take Down",
            "037 - Thrash",
            "038 - Double-Edge",
            "039 - Tail Whip",
            "040 - Poison Sting",
            "041 - Twineedle",
            "042 - Pin Missile",
            "043 - Leer",
            "044 - Bite",
            "045 - Growl",
            "046 - Roar",
            "047 - Sing",
            "048 - Supersonic",
            "049 - Sonicboom",
            "050 - Disable",
            "051 - Acid",
            "052 - Ember",
            "053 - Flamethrower",
            "054 - Mist",
            "055 - Water Gun",
            "056 - Hydro Pump",
            "057 - Surf",
            "058 - Ice Beam",
            "059 - Blizzard",
            "060 - Psybeam",
            "061 - Bubblebeam",
            "062 - Aurora Beam",
            "063 - Hyper Beam",
            "064 - Peck",
            "065 - Drill Peck",
            "066 - Submission",
            "067 - Low Kick",
            "068 - Counter",
            "069 - Seismic Toss",
            "070 - Strength",
            "071 - Absorb",
            "072 - Mega Drain",
            "073 - Leech Seed",
            "074 - Growth",
            "075 - Razor Leaf",
            "076 - Solar Beam",
            "077 - Poisonpowder",
            "078 - Stun Spore",
            "079 - Sleep Powder",
            "080 - Petal Dance",
            "081 - String Shot",
            "082 - Dragon Rage",
            "083 - Fire Spin",
            "084 - Thundershock",
            "085 - Thunderbolt",
            "086 - Thunder Wave",
            "087 - Thunder",
            "088 - Rock Throw",
            "089 - Earthquake",
            "090 - Fissure",
            "091 - Dig",
            "092 - Toxic",
            "093 - Confusion",
            "094 - Psychic",
            "095 - Hypnosis",
            "096 - Meditate",
            "097 - Agility",
            "098 - Quick Attack",
            "099 - Rage",
            "100 - Teleport",
            "101 - Night Shade",
            "102 - Mimic",
            "103 - Screech",
            "104 - Double Team",
            "105 - Recover",
            "106 - Harden",
            "107 - Minimize",
            "108 - Smokescreen",
            "109 - Confuse Ray",
            "110 - Withdraw",
            "111 - Defense Curl",
            "112 - Barrier",
            "113 - Light Screen",
            "114 - Haze",
            "115 - Reflect",
            "116 - Focus Energy",
            "117 - Bide",
            "118 - Metronome",
            "119 - Mirror Move",
            "120 - Selfdestruct",
            "121 - Egg Bomb",
            "122 - Lick",
            "123 - Smog",
            "124 - Sludge",
            "125 - Bone Club",
            "126 - Fire Blast",
            "127 - Waterfall",
            "128 - Clamp",
            "129 - Swift",
            "130 - Skull Bash",
            "131 - Spike Cannon",
            "132 - Constrict",
            "133 - Amnesia",
            "134 - Kinesis",
            "135 - Softboiled",
            "136 - Hi Jump Kick",
            "137 - Glare",
            "138 - Dream Eater",
            "139 - Poison Gas",
            "140 - Barrage",
            "141 - Leech Life",
            "142 - Lovely Kiss",
            "143 - Sky Attack",
            "144 - Transform",
            "145 - Bubble",
            "146 - Dizzy Punch",
            "147 - Spore",
            "148 - Flash",
            "149 - Psywave",
            "150 - Splash",
            "151 - Acid Armor",
            "152 - Crabhammer",
            "153 - Explosion",
            "154 - Fury Swipes",
            "155 - Bonemerang",
            "156 - Rest",
            "157 - Rock Slide",
            "158 - Hyper Fang",
            "159 - Sharpen",
            "160 - Conversion",
            "161 - Tri Attack",
            "162 - Super Fang",
            "163 - Slash",
            "164 - Substitute",
            "165 - Struggle",
            "166 - Fairy Wind",
            "167 - Triple Kick",
            "168 - DrainingKiss",
            "169 - Moonblast",
            "170 - Rage Fist",
            "171 - Strange Steam",
            "172 - Flame Wheel",
            "173 - Dark Pulse",
            "174 - Night Slash",
            "175 - Play Rough",
            "176 - Burning Mist",
            "177 - Aeroblast",
            "178 - Cotton Spore",
            "179 - Laughing Gas",
            "180 - Nothing_OVERWORLDSURF",
            "181 - Powder Snow",
            "182 - Miasma",
            "183 - Mach Punch",
            "184 - Scary Face",
            "185 - Faint Attack",
            "186 - Sweet Kiss",
            "187 - Shock Smog",
            "188 - Sludge Bomb",
            "189 - Mud Slap",
            "190 - Octazooka",
            "191 - Bass Tremor",
            "192 - Zap Cannon",
            "193 - Hyper Voice",
            "194 - Flash Cannon",
            "195 - Iron Defense",
            "196 - Icy Wind",
            "197 - Iron Head",
            "198 - Bone Rush",
            "199 - Nothing",
            "200 - Outrage",
            "201 - Nothing",
            "202 - Giga Drain",
            "203 - Nothing",
            "204 - Charm",
            "205 - Rollout",
            "206 - Nothing",
            "207 - Nothing",
            "208 - Nothing",
            "209 - Spark",
            "210 - Nothing",
            "211 - Steel Wing",
            "212 - Nothing",
            "213 - Nothing",
            "214 - Nothing",
            "215 - Nothing",
            "216 - Nothing",
            "217 - Nothing",
            "218 - Nothing",
            "219 - Nothing",
            "220 - Nothing",
            "221 - Sacred Fire",
            "222 - Nothing",
            "223 - DynamicPunch",
            "224 - Megahorn",
            "225 - Dragonbreath",
            "226 - Nothing",
            "227 - Nothing",
            "228 - Nothing",
            "229 - Nothing",
            "230 - Sweet Scent",
            "231 - Iron Tail",
            "232 - Metal Claw",
            "233 - Nothing",
            "234 - Morning Sun",
            "235 - Synthesis",
            "236 - Moonlight",
            "237 - Nothing",
            "238 - Cross Chop",
            "239 - Twister",
            "240 - Nothing",
            "241 - Nothing",
            "242 - Crunch",
            "243 - Nothing",
            "244 - Nothing",
            "245 - Extremespeed",
            "246 - Nothing",
            "247 - Shadow Ball",
            "248 - Nothing",
            "249 - Rock Smash",
            "250 - Nothing",
            "251 - Nothing",
            "252 - Wood Hammer",
            "253 - Twig Slap",
            "254 - Noise Pulse",
            "255 - Nothing"});
            this.SelectedMove.Location = new System.Drawing.Point(12, 476);
            this.SelectedMove.Name = "SelectedMove";
            this.SelectedMove.Size = new System.Drawing.Size(184, 21);
            this.SelectedMove.TabIndex = 0;
            this.SelectedMove.Visible = false;
            this.SelectedMove.SelectedIndexChanged += new System.EventHandler(this.SelectedMove_SelectedIndexChanged);
            // 
            // movePower
            // 
            this.movePower.Location = new System.Drawing.Point(85, 55);
            this.movePower.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.movePower.Name = "movePower";
            this.movePower.Size = new System.Drawing.Size(62, 20);
            this.movePower.TabIndex = 2;
            this.movePower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // moveAnim
            // 
            this.moveAnim.FormattingEnabled = true;
            this.moveAnim.Items.AddRange(new object[] {
            "000 - 0x00 //move table starts with pound but pound is move 01 not 00",
            "001 - PoundAnim",
            "002 - KarateChopAnim",
            "003 - DoubleSlapAnim",
            "004 - CometPunchAnim",
            "005 - MegaPunchAnim",
            "006 - PayDayAnim",
            "007 - FirePunchAnim",
            "008 - IcePunchAnim",
            "009 - ThunderPunchAnim",
            "010 - ScratchAnim",
            "011 - VicegripAnim",
            "012 - GuillotineAnim",
            "013 - RazorWindAnim",
            "014 - SwordsDanceAnim",
            "015 - CutAnim",
            "016 - GustAnim",
            "017 - WingAttackAnim",
            "018 - WhirlwindAnim",
            "019 - FlyAnim",
            "020 - BindAnim",
            "021 - SlamAnim",
            "022 - VineWhipAnim",
            "023 - StompAnim",
            "024 - DoubleKickAnim",
            "025 - MegaKickAnim",
            "026 - JumpKickAnim",
            "027 - RollingKickAnim",
            "028 - SandAttackAnim",
            "029 - HeatButtAnim",
            "030 - HornAttackAnim",
            "031 - FuryAttackAnim",
            "032 - HornDrillAnim",
            "033 - TackleAnim",
            "034 - BodySlamAnim",
            "035 - WrapAnim",
            "036 - TakeDownAnim",
            "037 - ThrashAnim",
            "038 - DoubleEdgeAnim",
            "039 - TailWhipAnim",
            "040 - PoisonStingAnim",
            "041 - TwineedleAnim",
            "042 - PinMissileAnim",
            "043 - LeerAnim",
            "044 - BiteAnim",
            "045 - GrowlAnim",
            "046 - RoarAnim",
            "047 - SingAnim",
            "048 - SupersonicAnim",
            "049 - SonicBoomAnim",
            "050 - DisableAnim",
            "051 - AcidAnim",
            "052 - EmberAnim",
            "053 - FlamethrowerAnim",
            "054 - MistAnim",
            "055 - WaterGunAnim",
            "056 - HydroPumpAnim",
            "057 - SurfAnim",
            "058 - IceBeamAnim",
            "059 - BlizzardAnim",
            "060 - PsyBeamAnim",
            "061 - BubbleBeamAnim",
            "062 - AuroraBeamAnim",
            "063 - HyperBeamAnim",
            "064 - PeckAnim",
            "065 - DrillPeckAnim",
            "066 - SubmissionAnim",
            "067 - LowKickAnim",
            "068 - CounterAnim",
            "069 - SeismicTossAnim",
            "070 - StrengthAnim",
            "071 - AbsorbAnim",
            "072 - MegaDrainAnim",
            "073 - LeechSeedAnim",
            "074 - GrowthAnim",
            "075 - RazorLeafAnim",
            "076 - SolarBeamAnim",
            "077 - PoisonPowderAnim",
            "078 - StunSporeAnim",
            "079 - SleepPowderAnim",
            "080 - PetalDanceAnim",
            "081 - StringShotAnim",
            "082 - DragonRageAnim",
            "083 - FireSpinAnim",
            "084 - ThunderShockAnim",
            "085 - ThunderBoltAnim",
            "086 - ThunderWaveAnim",
            "087 - ThunderAnim",
            "088 - RockThrowAnim",
            "089 - EarthquakeAnim",
            "090 - FissureAnim",
            "091 - DigAnim",
            "092 - ToxicAnim",
            "093 - ConfusionAnim",
            "094 - PsychicAnim",
            "095 - HypnosisAnim",
            "096 - MeditateAnim",
            "097 - AgilityAnim",
            "098 - QuickAttackAnim",
            "099 - RageAnim",
            "100 - TeleportAnim",
            "101 - NightShadeAnim",
            "102 - MimicAnim",
            "103 - ScreechAnim",
            "104 - DoubleTeamAnim",
            "105 - RecoverAnim",
            "106 - HardenAnim",
            "107 - MinimizeAnim",
            "108 - SmokeScreenAnim",
            "109 - ConfuseRayAnim",
            "110 - WithdrawAnim",
            "111 - DefenseCurlAnim",
            "112 - BarrierAnim",
            "113 - LightScreenAnim",
            "114 - HazeAnim",
            "115 - ReflectAnim",
            "116 - FocusEnergyAnim",
            "117 - BideAnim",
            "118 - MetronomeAnim",
            "119 - MirrorMoveAnim",
            "120 - SelfdestructAnim",
            "121 - EggBombAnim",
            "122 - LickAnim",
            "123 - SmogAnim",
            "124 - SludgeAnim",
            "125 - BoneClubAnim",
            "126 - FireBlastAnim",
            "127 - WaterfallAnim",
            "128 - ClampAnim",
            "129 - SwiftAnim",
            "130 - SkullBashAnim",
            "131 - SpikeCannonAnim",
            "132 - ConstrictAnim",
            "133 - AmnesiaAnim",
            "134 - KinesisAnim",
            "135 - SoftboiledAnim",
            "136 - HiJumpKickAnim",
            "137 - GlareAnim",
            "138 - DreamEaterAnim",
            "139 - PoisonGasAnim",
            "140 - BarrageAnim",
            "141 - LeechLifeAnim",
            "142 - LovelyKissAnim",
            "143 - SkyAttackAnim",
            "144 - TransformAnim",
            "145 - BubbleAnim",
            "146 - DizzyPunchAnim",
            "147 - SporeAnim",
            "148 - FlashAnim",
            "149 - PsywaveAnim",
            "150 - SplashAnim",
            "151 - AcidArmorAnim",
            "152 - CrabHammerAnim",
            "153 - ExplosionAnim",
            "154 - FurySwipesAnim",
            "155 - BonemerangAnim",
            "156 - RestAnim",
            "157 - RockSlideAnim",
            "158 - HyperFangAnim",
            "159 - SharpenAnim",
            "160 - ConversionAnim",
            "161 - TriAttackAnim",
            "162 - SuperFangAnim",
            "163 - SlashAnim",
            "164 - SubstituteAnim",
            "165 - StruggleAnim //Move Animations end here",
            "166 - ShowPicAnim",
            "167 - EnemyFlashAnim",
            "168 - PlayerFlashAnim",
            "169 - EnemyHUDShakeAnim",
            "170 - TradeBallDropAnim",
            "171 - TradeBallAppear1Anim",
            "172 - TradeBallAppear2Anim",
            "173 - TradeBallPoofAnim",
            "174 - XStatItemAnim",
            "175 - XStatItemAnim",
            "176 - ShrinkingSquareAnim",
            "177 - ShrinkingSquareAnim",
            "178 - XStatItemBlackAnim",
            "179 - XStatItemBlackAnim",
            "180 - ShrinkingSquareBlackAnim",
            "181 - ShrinkingSquareBlackAnim",
            "182 - GigaImpactAnim",
            "183 - UnusedAnim",
            "184 - ParalyzeAnim",
            "185 - ParalyzeAnim",
            "186 - PoisonAnim",
            "187 - PoisonAnim",
            "188 - SleepPlayerAnim",
            "189 - SleepEnemyAnim",
            "190 - ConfusedPlayerAnim",
            "191 - ConfusedEnemyAnim",
            "192 - FaintAnim",
            "193 - BallTossAnim",
            "194 - BallShakeAnim",
            "195 - BallPoofAnim",
            "196 - BallBlockAnim",
            "197 - GreatTossAnim",
            "198 - UltraTossAnim",
            "299 - ShakeScreenAnim",
            "200 - HidePicAnim",
            "201 - ThrowRockAnim",
            "202 - ThrowBaitAnim //Combat animations end here",
            "203 - ZigZagScreenAnim",
            "204 - TripleKickAnim",
            "205 - SacredFireAnim",
            "206 - FeintAttackAnim"});
            this.moveAnim.Location = new System.Drawing.Point(357, 29);
            this.moveAnim.Name = "moveAnim";
            this.moveAnim.Size = new System.Drawing.Size(270, 21);
            this.moveAnim.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Animation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(298, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Effect";
            // 
            // moveEffect
            // 
            this.moveEffect.FormattingEnabled = true;
            this.moveEffect.Items.AddRange(new object[] {
            "000 - NO_ADDITIONAL_EFFECT",
            "001 - CONFUSION_20P_SIDE_EFFECT (20%) (BROWN)",
            "002 - POISON_SIDE_EFFECT1 (10%)",
            "003 - DRAIN_HP_EFFECT",
            "004 - BURN_SIDE_EFFECT1 (10%)",
            "005 - FREEZE_SIDE_EFFECT (10%)",
            "006 - PARALYZE_SIDE_EFFECT1 (10%)",
            "007 - EXPLODE_EFFECT (Explosion, Self Destruct)",
            "008 - DREAM_EATER_EFFECT",
            "009 - MIRROR_MOVE_EFFECT (SplashEffect on other move IDs)",
            "010 - ATTACK_UP1_EFFECT",
            "011 - DEFENSE_UP1_EFFECT",
            "012 - SPEED_UP1_EFFECT",
            "013 - SPECIAL_UP1_EFFECT",
            "014 - ACCURACY_UP1_EFFECT",
            "015 - EVASION_UP1_EFFECT",
            "016 - PAY_DAY_EFFECT",
            "017 - SWIFT_EFFECT (SplashEffect on other move IDs)",
            "018 - ATTACK_DOWN1_EFFECT",
            "019 - DEFENSE_DOWN1_EFFECT",
            "020 - SPEED_DOWN1_EFFECT",
            "021 - SPECIAL_DOWN1_EFFECT",
            "022 - ACCURACY_DOWN1_EFFECT",
            "023 - EVASION_DOWN1_EFFECT",
            "024 - CONVERSION_EFFECT",
            "025 - HAZE_EFFECT",
            "026 - BIDE_EFFECT",
            "027 - THRASH_PETAL_DANCE_EFFECT",
            "028 - SWITCH_AND_TELEPORT_EFFECT",
            "029 - TWO_TO_FIVE_ATTACKS_EFFECT (random 2-5 attacks)",
            "030 - TRIPLE KICK_EFFECT (always 3 attacks) (BROWN)",
            "031 - FLINCH_SIDE_EFFECT1 (10%)",
            "032 - SLEEP_EFFECT",
            "033 - POISON_SIDE_EFFECT2  (30%)",
            "034 - BURN_SIDE_EFFECT2 (30%)",
            "035 - CONFUSION_SIDE_EFFECT (100%) (DynamicPunch)(BROWN)",
            "036 - PARALYZE_SIDE_EFFECT2 (30%)",
            "037 - FLINCH_SIDE_EFFECT2 (30%)",
            "038 - OHKO_EFFECT (moves like Horn Drill)",
            "039 - CHARGE_EFFECT (moves like Solar Beam)",
            "040 - SUPER_FANG_EFFECT",
            "041 - SPECIAL_DAMAGE_EFFECT (Seismic Toss, Night Shade, Sonic Boom, Dragon Rage, " +
                "Psywave)",
            "042 - TRAPPING_EFFECT (moves like Wrap)",
            "043 - FLY_EFFECT",
            "044 - ATTACK_TWICE_EFFECT (always 2 attacks)",
            "045 - JUMP_KICK_EFFECT (SplashEffect on other move IDs)",
            "046 - MIST_EFFECT",
            "047 - FOCUS_ENERGY_EFFECT",
            "048 - RECOIL_EFFECT (moves like Double Edge)",
            "049 - CONFUSION_EFFECT (100%) - Status moves",
            "050 - ATTACK_UP2_EFFECT",
            "051 - DEFENSE_UP2_EFFECT",
            "052 - SPEED_UP2_EFFECT",
            "053 - SPECIAL_UP2_EFFECT",
            "054 - ACCURACY_UP2_EFFECT",
            "055 - EVASION_UP2_EFFECT",
            "056 - HEAL_EFFECT (Recover, Softboiled, Rest)",
            "057 - TRANSFORM_EFFECT",
            "058 - ATTACK_DOWN2_EFFECT",
            "059 - DEFENSE_DOWN2_EFFECT",
            "060 - SPEED_DOWN2_EFFECT",
            "061 - SPECIAL_DOWN2_EFFECT",
            "062 - ACCURACY_DOWN2_EFFECT",
            "063 - EVASION_DOWN2_EFFECT",
            "064 - LIGHT_SCREEN_EFFECT",
            "065 - REFLECT_EFFECT",
            "066 - POISON_EFFECT",
            "067 - PARALYZE_EFFECT",
            "068 - ATTACK_DOWN_SIDE_EFFECT",
            "069 - DEFENSE_DOWN_SIDE_EFFECT",
            "070 - SPEED_DOWN_SIDE_EFFECT",
            "071 - SPECIAL_DOWN_SIDE_EFFECT",
            "072 - ACCURACY_DOWN_SIDE_EFFECT (BROWN)",
            "073 - EVASION_DOWN_SIDE_EFFECT (BROWN)",
            "074 - ANCIENTPOWER_EFFECT",
            "075 - TRIATTACK_SIDE_EFFECT3 (BROWN)",
            "076 - CONFUSION_SIDE_EFFECT (10%)",
            "077 - TWINEEDLE_EFFECT (always 2 attacks)",
            "078 - FLINCH_SIDE_EFFECT3 (20%) (BROWN)",
            "079 - SUBSTITUTE_EFFECT",
            "080 - HYPER_BEAM_EFFECT",
            "081 - RAGE_EFFECT",
            "082 - MIMIC_EFFECT",
            "083 - METRONOME_EFFECT",
            "084 - LEECH_SEED_EFFECT",
            "085 - SPLASH_EFFECT",
            "086 - DISABLE_EFFECT",
            "087 - ATTACK_UP1_SIDE_EFFECT (10%) (BROWN)",
            "088 - ATTACK_DOWN1_SIDE_EFFECT (100%)",
            "089 - DICEROLL_EFFECT",
            "090 - ",
            "091 - ",
            "092 - ",
            "093 - ",
            "094 - ",
            "095 - ",
            "096 - ",
            "097 - ",
            "098 - ",
            "099 - ",
            "100 - ",
            "101 - ",
            "102 - ",
            "103 - ",
            "104 - ",
            "105 - ",
            "106 - ",
            "107 - ",
            "108 - ",
            "109 - ",
            "110 - ",
            "111 - ",
            "112 - ",
            "113 - ",
            "114 - ",
            "115 - ",
            "116 - ",
            "117 - ",
            "118 - ",
            "119 - ",
            "120 - ",
            "121 - ",
            "122 - ",
            "123 - ",
            "124 - ",
            "125 - ",
            "126 - ",
            "127 - ",
            "128 - ",
            "129 - ",
            "130 - ",
            "131 - ",
            "132 - ",
            "133 - ",
            "134 - ",
            "135 - ",
            "136 - ",
            "137 - ",
            "138 - ",
            "139 - ",
            "140 - ",
            "141 - ",
            "142 - ",
            "143 - ",
            "144 - ",
            "145 - ",
            "146 - ",
            "147 - ",
            "148 - ",
            "149 - ",
            "150 - ",
            "151 - ",
            "152 - ",
            "153 - ",
            "154 - ",
            "155 - ",
            "156 - ",
            "157 - ",
            "158 - ",
            "159 - ",
            "160 - ",
            "161 - ",
            "162 - ",
            "163 - ",
            "164 - ",
            "165 - ",
            "166 - ",
            "167 - ",
            "168 - ",
            "169 - ",
            "170 - ",
            "171 - ",
            "172 - ",
            "173 - ",
            "174 - ",
            "175 - ",
            "176 - ",
            "177 - ",
            "178 - ",
            "179 - ",
            "180 - ",
            "181 - ",
            "182 - ",
            "183 - ",
            "184 - ",
            "185 - ",
            "186 - ",
            "187 - ",
            "188 - ",
            "189 - ",
            "190 - ",
            "191 - ",
            "192 - ",
            "193 - ",
            "194 - ",
            "195 - ",
            "196 - ",
            "197 - ",
            "198 - ",
            "199 - ",
            "200 - ",
            "201 - ",
            "202 - ",
            "203 - ",
            "204 - ",
            "205 - ",
            "206 - ",
            "207 - ",
            "208 - ",
            "209 - ",
            "210 - ",
            "211 - ",
            "212 - ",
            "213 - ",
            "214 - ",
            "215 - ",
            "216 - ",
            "217 - ",
            "218 - ",
            "219 - ",
            "220 - ",
            "221 - ",
            "222 - ",
            "223 - ",
            "224 - ",
            "225 - ",
            "226 - ",
            "227 - ",
            "228 - ",
            "229 - ",
            "230 - ",
            "231 - ",
            "232 - ",
            "233 - ",
            "234 - ",
            "235 - ",
            "236 - ",
            "237 - ",
            "238 - ",
            "239 - ",
            "240 - ",
            "241 - ",
            "242 - ",
            "243 - ",
            "244 - ",
            "245 - ",
            "246 - ",
            "247 - ",
            "248 - ",
            "249 - ",
            "250 - ",
            "251 - ",
            "252 - ",
            "253 - ",
            "254 - ",
            "255 - "});
            this.moveEffect.Location = new System.Drawing.Point(357, 60);
            this.moveEffect.Name = "moveEffect";
            this.moveEffect.Size = new System.Drawing.Size(270, 21);
            this.moveEffect.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 57);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Power";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(299, 91);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(179, 63);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "PP";
            // 
            // movePP
            // 
            this.movePP.Location = new System.Drawing.Point(215, 55);
            this.movePP.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.movePP.Name = "movePP";
            this.movePP.Size = new System.Drawing.Size(58, 20);
            this.movePP.TabIndex = 10;
            this.movePP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 87);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Accuracy";
            // 
            // moveAccuracy
            // 
            this.moveAccuracy.Hexadecimal = true;
            this.moveAccuracy.Location = new System.Drawing.Point(85, 85);
            this.moveAccuracy.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.moveAccuracy.Name = "moveAccuracy";
            this.moveAccuracy.Size = new System.Drawing.Size(62, 20);
            this.moveAccuracy.TabIndex = 12;
            this.moveAccuracy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.moveAccuracy.ValueChanged += new System.EventHandler(this.moveAccuracy_ValueChanged);
            // 
            // moveType
            // 
            this.moveType.FormattingEnabled = true;
            this.moveType.Items.AddRange(new object[] {
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
            this.moveType.Location = new System.Drawing.Point(357, 88);
            this.moveType.Name = "moveType";
            this.moveType.Size = new System.Drawing.Size(270, 21);
            this.moveType.TabIndex = 14;
            // 
            // accuracypercentLab
            // 
            this.accuracypercentLab.AutoSize = true;
            this.accuracypercentLab.Location = new System.Drawing.Point(102, 108);
            this.accuracypercentLab.Name = "accuracypercentLab";
            this.accuracypercentLab.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.accuracypercentLab.Size = new System.Drawing.Size(48, 13);
            this.accuracypercentLab.TabIndex = 15;
            this.accuracypercentLab.Text = "000.00%";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MoveIndex,
            this.MoveName,
            this.Type,
            this.psSplit,
            this.Power,
            this.Accuracy,
            this.PP,
            this.Anim,
            this.Effect});
            this.dataGridView1.Location = new System.Drawing.Point(12, 153);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(986, 317);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
            // 
            // MoveIndex
            // 
            this.MoveIndex.Frozen = true;
            this.MoveIndex.HeaderText = "Move Index";
            this.MoveIndex.Name = "MoveIndex";
            this.MoveIndex.ReadOnly = true;
            this.MoveIndex.Width = 50;
            // 
            // MoveName
            // 
            this.MoveName.HeaderText = "Name";
            this.MoveName.Name = "MoveName";
            this.MoveName.ReadOnly = true;
            this.MoveName.Width = 150;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // psSplit
            // 
            this.psSplit.HeaderText = "P/S";
            this.psSplit.Name = "psSplit";
            this.psSplit.ReadOnly = true;
            this.psSplit.Width = 75;
            // 
            // Power
            // 
            this.Power.HeaderText = "Power";
            this.Power.Name = "Power";
            this.Power.ReadOnly = true;
            this.Power.Width = 50;
            // 
            // Accuracy
            // 
            this.Accuracy.HeaderText = "Accuracy";
            this.Accuracy.Name = "Accuracy";
            this.Accuracy.ReadOnly = true;
            this.Accuracy.Width = 75;
            // 
            // PP
            // 
            this.PP.HeaderText = "PP";
            this.PP.Name = "PP";
            this.PP.ReadOnly = true;
            this.PP.Width = 50;
            // 
            // Anim
            // 
            this.Anim.HeaderText = "Anim";
            this.Anim.Name = "Anim";
            this.Anim.ReadOnly = true;
            this.Anim.Width = 150;
            // 
            // Effect
            // 
            this.Effect.HeaderText = "Effect";
            this.Effect.Name = "Effect";
            this.Effect.ReadOnly = true;
            this.Effect.Width = 225;
            // 
            // SaveMoveBut
            // 
            this.SaveMoveBut.Location = new System.Drawing.Point(673, 92);
            this.SaveMoveBut.Name = "SaveMoveBut";
            this.SaveMoveBut.Size = new System.Drawing.Size(107, 43);
            this.SaveMoveBut.TabIndex = 17;
            this.SaveMoveBut.Text = "Save Move";
            this.SaveMoveBut.UseVisualStyleBackColor = true;
            this.SaveMoveBut.Click += new System.EventHandler(this.SaveMoveBut_Click);
            // 
            // SaveExitBut
            // 
            this.SaveExitBut.Location = new System.Drawing.Point(401, 476);
            this.SaveExitBut.Name = "SaveExitBut";
            this.SaveExitBut.Size = new System.Drawing.Size(159, 23);
            this.SaveExitBut.TabIndex = 18;
            this.SaveExitBut.Text = "Save and Exit";
            this.SaveExitBut.UseVisualStyleBackColor = true;
            this.SaveExitBut.Click += new System.EventHandler(this.SaveExitBut_Click);
            // 
            // MoveNameBox
            // 
            this.MoveNameBox.Location = new System.Drawing.Point(85, 29);
            this.MoveNameBox.MaxLength = 12;
            this.MoveNameBox.Name = "MoveNameBox";
            this.MoveNameBox.Size = new System.Drawing.Size(188, 20);
            this.MoveNameBox.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Move Name";
            // 
            // psSplitCheckbox
            // 
            this.psSplitCheckbox.AutoSize = true;
            this.psSplitCheckbox.Location = new System.Drawing.Point(178, 92);
            this.psSplitCheckbox.Name = "psSplitCheckbox";
            this.psSplitCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.psSplitCheckbox.Size = new System.Drawing.Size(95, 17);
            this.psSplitCheckbox.TabIndex = 23;
            this.psSplitCheckbox.Text = "Special Attack";
            this.psSplitCheckbox.UseVisualStyleBackColor = true;
            // 
            // ExitBut
            // 
            this.ExitBut.Location = new System.Drawing.Point(839, 476);
            this.ExitBut.Name = "ExitBut";
            this.ExitBut.Size = new System.Drawing.Size(159, 23);
            this.ExitBut.TabIndex = 24;
            this.ExitBut.Text = "Exit without saving";
            this.ExitBut.UseVisualStyleBackColor = true;
            this.ExitBut.Click += new System.EventHandler(this.ExitBut_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.psSplitCheckbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.MoveNameBox);
            this.groupBox1.Controls.Add(this.SaveMoveBut);
            this.groupBox1.Controls.Add(this.accuracypercentLab);
            this.groupBox1.Controls.Add(this.moveType);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.moveAccuracy);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.movePP);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.moveEffect);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.moveAnim);
            this.groupBox1.Controls.Add(this.movePower);
            this.groupBox1.Location = new System.Drawing.Point(99, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(797, 141);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // MoveEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 509);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ExitBut);
            this.Controls.Add(this.SaveExitBut);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.SelectedMove);
            this.Name = "MoveEditor";
            this.Text = "Move Editor";
            ((System.ComponentModel.ISupportInitialize)(this.movePower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movePP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveAccuracy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox SelectedMove;
        private System.Windows.Forms.NumericUpDown movePower;
        private System.Windows.Forms.ComboBox moveAnim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox moveEffect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown movePP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown moveAccuracy;
        private System.Windows.Forms.ComboBox moveType;
        private System.Windows.Forms.Label accuracypercentLab;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button SaveMoveBut;
        private System.Windows.Forms.Button SaveExitBut;
        private System.Windows.Forms.TextBox MoveNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox psSplitCheckbox;
        private System.Windows.Forms.Button ExitBut;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoveIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoveName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn psSplit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Power;
        private System.Windows.Forms.DataGridViewTextBoxColumn Accuracy;
        private System.Windows.Forms.DataGridViewTextBoxColumn PP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anim;
        private System.Windows.Forms.DataGridViewTextBoxColumn Effect;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
