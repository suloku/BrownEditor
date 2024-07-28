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
	public partial class StatsEvos : Form
	{
		public string twobppfilter = "2 byte per pixel image|*.2bpp|All Files (*.*)|*.*";
		public static byte[] spritebuffer;

		public static STATSDATA statsdata;
		public static MOVENAMEDATA movenamedata;
		public static TMHMLIST tmhmlist;

		public static int totalmon = 255;
		//Base stats
		public static int BasesstatsOffset = 0xFC336;
		public static int basestat_size = 28;
		public static int statDataSize = 256 * basestat_size;

		//TM/HM list
		public static int tmhmmovesOffset = 0x13960;
		public static int totalTMHM = 55;
		public StatsEvos()
		{
			InitializeComponent();
			tmhmlist = new TMHMLIST(BrownEditor.MainForm.filebuffer.Skip(tmhmmovesOffset).Take(totalTMHM).ToArray());
			movenamedata = new MOVENAMEDATA(BrownEditor.MainForm.filebuffer.Skip(BrownEditor.editor.MoveEditor.MoveNamesOffset).Take(BrownEditor.editor.MoveEditor.MoveNamesSize).ToArray());
			movenamedata.populateNameList();
			buildMoveList();
			buildTMHMList();

			statsdata = new STATSDATA(BrownEditor.MainForm.filebuffer.Skip(BasesstatsOffset).Take(statDataSize).ToArray());
			loadStatData(0);

		}

		internal void loadStatData(int index)
		{
			statsdata.setMonIndex(index);
			Species.SelectedIndex = index;
			dexnum.Value = statsdata.dexnum;
			HP.Value = statsdata.hp;
			ATK.Value = statsdata.atk;
			DEF.Value = statsdata.def;
			SPE.Value = statsdata.speed;
			SPC.Value = statsdata.special;
			catchRate.Value = statsdata.catchRate;
			baseEXP.Value = statsdata.baseExp;
			GrowthRate.SelectedIndex = statsdata.growth;
			type1.SelectedIndex = statsdata.type1;
			type2.SelectedIndex = statsdata.type2;
			move1.SelectedIndex = statsdata.move1;
			move2.SelectedIndex = statsdata.move2;
			move3.SelectedIndex = statsdata.move3;
			move4.SelectedIndex = statsdata.move4;
			picSize.Value = statsdata.spriteDim;
			picFrontLab.Text =    "Front Pic Offset: 0x" + statsdata.picfront.ToString("X") + " (0x"+ BrownEditor.MainForm.ThreeByteToTwoByte(statsdata.picbank, statsdata.picfront).ToString("X")+")";
			picBackLab.Text =     "Front Pic Offset: 0x" + statsdata.picback.ToString("X") + " (0x" + BrownEditor.MainForm.ThreeByteToTwoByte(statsdata.picbank, statsdata.picback).ToString("X") + ")";
			picsBank_label.Text = "Pics Bank:        0x" + statsdata.picbank.ToString("X");

			int i = 0;
			for (i = 0; i < 55;i++)
            {
				TMHMListBox.SetItemChecked(i, statsdata.CheckTMHM(i));
            }
		}
		internal void saveStatData()
		{
			
			//statsdata.dexnum = dexnum.Value;
			statsdata.hp = (byte)HP.Value;
			statsdata.atk = (byte)ATK.Value;
			statsdata.def = (byte)DEF.Value;
			statsdata.speed = (byte)SPE.Value;
			statsdata.special = (byte)SPC.Value;
			statsdata.catchRate = (byte)catchRate.Value;
			statsdata.baseExp = (byte)baseEXP.Value;
			statsdata.growth = (byte)GrowthRate.SelectedIndex;
			statsdata.type1 = (byte)type1.SelectedIndex;
			statsdata.type2 = (byte)type2.SelectedIndex;
			statsdata.move1 = (byte)move1.SelectedIndex;
			statsdata.move2 = (byte)move2.SelectedIndex;
			statsdata.move3 = (byte)move3.SelectedIndex;
			statsdata.move4 = (byte)move4.SelectedIndex;
			//statsdata.spriteDim = picSize.Value;
			//picfront
			//picback
			//picbank
			//tmhm
			int i = 0;
			for (i = 0; i < 55; i++)
			{
				statsdata.SetTMHM(i, TMHMListBox.GetItemChecked(i));
			}
		}

		internal void buildMoveList()
        {
			move1.Items.Add("No Move");
			move2.Items.Add("No Move");
			move3.Items.Add("No Move");
			move4.Items.Add("No Move");

			//Move name list starts at index 01
			int i = 0;
			foreach (string element in movenamedata.moveNamesList)
            {
				move1.Items.Add(movenamedata.moveNamesList[i]);
				move2.Items.Add(movenamedata.moveNamesList[i]);
				move3.Items.Add(movenamedata.moveNamesList[i]);
				move4.Items.Add(movenamedata.moveNamesList[i]);

				i++;
            }
        }
		internal void buildTMHMList()
		{

			//Move name list starts at index 01
			int i = 0;
			for (i=0; i<50;i++)
			{
				TMHMListBox.Items.Add("TM " + (i+1).ToString("00") + " " + movenamedata.moveNamesList[tmhmlist.getMove(i)-1]);
			}
			for (i = 50; i < 55; i++)
			{
				TMHMListBox.Items.Add("HM " + (i-49).ToString("00") + " " + movenamedata.moveNamesList[tmhmlist.getMove(i)-1]);
			}
		}

		private void comboBox_Species_SelectedIndexChanged(object sender, EventArgs e)
		{
			loadStatData(Species.SelectedIndex);
		}
		public class TMHMLIST
		{
			internal int Size = totalTMHM;

			public byte[] Data;
			public TMHMLIST(byte[] data = null)
			{
				Data = data ?? new byte[Size];
			}

			public byte getMove(int index)
			{
					if (index >= Size)
					{
						MessageBox.Show("Invalid TM/HM index " + index);
						return 0x01;
					}
					return Data[index];
			}
		}
			public class STATSDATA
		{
			internal int Size = StatsEvos.statDataSize;

			internal int currentMon = 0;
			internal int currentPointer = 0;
			internal int tmstart = 20;
			internal int tmtotalbytes = 7;

			internal int curByte;
			internal int curBit;

			public byte[] Data;
			public STATSDATA(byte[] data = null)
			{
				Data = data ?? new byte[Size];
			}

			public void setMonIndex(int index)
			{
				if (index >= StatsEvos.totalmon)
				{
					MessageBox.Show("Pokémon index has to be between 0 and " + (StatsEvos.totalmon-1).ToString());
					currentMon = StatsEvos.totalmon-1;
				}
				else
				{
					currentMon = index;
				}
				currentPointer = currentMon * StatsEvos.basestat_size;
				return;
			}

			public byte dexnum
			{
				get { return Data[currentPointer + 0]; }
				set { Data[currentPointer + 0] = value; }
			}
			public byte hp
			{
				get { return Data[currentPointer + 1]; }
				set { Data[currentPointer + 1] = value; }
			}
			public byte atk
			{
				get { return Data[currentPointer + 2]; }
				set { Data[currentPointer + 2] = value; }
			}
			public byte def
			{
				get { return Data[currentPointer + 3]; }
				set { Data[currentPointer + 3] = value; }
			}
			public byte speed
			{
				get { return Data[currentPointer + 4]; }
				set { Data[currentPointer + 4] = value; }
			}
			public byte special
			{
				get { return Data[currentPointer + 5]; }
				set { Data[currentPointer + 5] = value; }
			}
			public byte type1
			{
				get { return Data[currentPointer + 6]; }
				set { Data[currentPointer + 6] = value; }
			}
			public byte type2
			{
				get { return Data[currentPointer + 7]; }
				set { Data[currentPointer + 7] = value; }
			}
			public byte catchRate
			{
				get { return Data[currentPointer + 8]; }
				set { Data[currentPointer + 8] = value; }
			}
			public byte baseExp
			{
				get { return Data[currentPointer + 9]; }
				set { Data[currentPointer + 9] = value; }
			}
			public byte spriteDim
			{
				get { return Data[currentPointer + 10]; }
				set { Data[currentPointer + 10] = value; }
			}
			public UInt16 picfront
			{
				get { return BitConverter.ToUInt16(Data, currentPointer+11); }
				//set { Data[currentPointer + 1] = value; }
			}
			public UInt16 picback
			{
				get { return BitConverter.ToUInt16(Data, currentPointer + 13); }
				//set { Data[currentPointer + 1] = value; }
			}
			public byte move1
			{
				get { return Data[currentPointer + 15]; }
				set { Data[currentPointer + 15] = value; }
			}
			public byte move2
			{
				get { return Data[currentPointer + 16]; }
				set { Data[currentPointer + 16] = value; }
			}
			public byte move3
			{
				get { return Data[currentPointer + 17]; }
				set { Data[currentPointer + 17] = value; }
			}
			public byte move4
			{
				get { return Data[currentPointer + 18]; }
				set { Data[currentPointer + 18] = value; }
			}
			public byte growth
			{
				get { return Data[currentPointer + 19]; }
				set { Data[currentPointer + 19] = value; }
			}
			public byte picbank
			{
				get { return Data[currentPointer + 27]; }
				set { Data[currentPointer + 27] = value; }
			}

			internal void GetBitFromIndex(int index)
			{
				curByte = index / 8;
				curBit = index % 8;
			}
			public bool CheckTMHM(int tmIndex)
			{
				if (tmIndex >= totalTMHM) MessageBox.Show("Invalid TM/HM index " + tmIndex.ToString());
				GetBitFromIndex(( (currentPointer+tmstart)*8)+ tmIndex);
				//MessageBox.Show( (((currentPointer + tmstart)*8) + tmIndex).ToString()+" "+curByte.ToString() + " " + curBit.ToString());
				return Convert.ToBoolean(Data[curByte] >> curBit & 1);
			}

			public void SetTMHM(int tmIndex, bool canlearn)
			{
				GetBitFromIndex( ((currentPointer + tmstart)*8) + tmIndex);
				if (canlearn)
				{
					Data[curByte] |= (byte)(1 << curBit);
				}
				else
				{
					Data[curByte] &= (byte)(~(1 << curBit));
				}
			}

		}

        private void ExitBut_Click(object sender, EventArgs e)
        {
			this.Close();
		}

        private void SaveBut_Click(object sender, EventArgs e)
        {
			saveStatData();
			//Copy changes to rom and close
			Buffer.BlockCopy(statsdata.Data, 0, BrownEditor.MainForm.filebuffer, BasesstatsOffset, statDataSize);
			this.Close();
			MessageBox.Show("Saved Basestats to Rom");
		}

        private void tempSave_Click(object sender, EventArgs e)
        {
			saveStatData();
			MessageBox.Show("Saved");
		}

        private void InjectFrontBut_Click(object sender, EventArgs e)
        {
			MessageBox.Show("2BPP image must be exactly 784 bytes.\nGenerate it from a 4 colour 56x56 PNG image file with the following command using rgbgfx:\n\n\trgbgfx -Z -o battlesprite.2bpp battlepsrite.png");
			string filepath = null;
			int filesize = FileIO.load_file(ref spritebuffer, ref filepath, twobppfilter);
			if (filesize != 784)
			{
				MessageBox.Show("Wrong image size: "+filesize+" bytes");
			}
			else
            {
				DialogResult dialogresult = MessageBox.Show("WARNING!\nThis change will persist even if you click on \"Exit without saving\" button.\n\nContinue?", "Are you sure?", MessageBoxButtons.YesNo);
				if (dialogresult == DialogResult.Yes)
                {
					Buffer.BlockCopy(spritebuffer, 0, BrownEditor.MainForm.filebuffer, BrownEditor.MainForm.ThreeByteToTwoByte(statsdata.picbank, statsdata.picfront), 784);
					MessageBox.Show("Front battle Sprite injected to ROM.");
				}
				else
				{
					MessageBox.Show("Canceled.");
				}
			}
		}

        private void InjectBackBut_Click(object sender, EventArgs e)
        {
			MessageBox.Show("2BPP image must be exactly 784 bytes.\nGenerate it from a 4 colour 56x56 PNG image file with the following command using rgbgfx:\n\n\trgbgfx -Z -o battlesprite.2bpp battlepsrite.png");

			string filepath = null;
			int filesize = FileIO.load_file(ref spritebuffer, ref filepath, twobppfilter);
			if (filesize != 784)
			{
				MessageBox.Show("Wrong image size: " + filesize + " bytes");
			}
			else
			{
				DialogResult dialogresult = MessageBox.Show("WARNING!\nThis change will persist even if you click on \"Exit without saving\" button.\n\nContinue?", "Are you sure?", MessageBoxButtons.YesNo);
				if (dialogresult == DialogResult.Yes)
				{
					Buffer.BlockCopy(spritebuffer, 0, BrownEditor.MainForm.filebuffer, BrownEditor.MainForm.ThreeByteToTwoByte(statsdata.picbank, statsdata.picback), 784);
					MessageBox.Show("Back battle Sprite injected to ROM.");
				}
                else
				{
					MessageBox.Show("Canceled.");
				}
			}
		}
    }
}
