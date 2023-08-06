using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PKHeX.Core;

namespace BrownEditor.editor
{
    public partial class MoveEditor : Form
    {
		public static MOVEDATA movedata;
		public static MOVENAMEDATA namedata;
		public static MOVEPSDATA psdata;

		public static int moveDataSlots = 255;
		public static int moveDataSingleSize = 6;
		public static int moveDataSize = moveDataSlots * moveDataSingleSize;
		public static int MoveDataOffset = 0x3B250;
		public static int MoveNamesOffset = 0xB0000;
		public static int MoveNamesSize = 13 * 255;
		public static int PSsplitDataOffset = 0x3ffb0;//Phisical/Special moves are stored 3ffb0-3ffCf (32 bytes, 256 flags)
		public static int movePSDataSize = 32;
		public MoveEditor()
        {
            InitializeComponent();
			movedata = new MOVEDATA(BrownEditor.MainForm.filebuffer.Skip(MoveDataOffset).Take(moveDataSize).ToArray());
			namedata = new MOVENAMEDATA(BrownEditor.MainForm.filebuffer.Skip(MoveNamesOffset).Take(MoveNamesSize).ToArray());
			psdata = new MOVEPSDATA(BrownEditor.MainForm.filebuffer.Skip(PSsplitDataOffset).Take(movePSDataSize).ToArray());
			dataGridView1.Rows.Add(255);
			//var nametest = new byte[] { 0x8F,  0xA0, 0xAB, 0xAB, 0xA4, 0xB3, 0x8F, 0xA0, 0xB3, 0xB1, 0xAE, 0xAB, 0x50 };
			//MoveNameBox.Text = PKHeX.Core.StringConverter12.GetString(nametest, false);
			namedata.populateNameList();
			SelectedMove.SelectedIndex = 0;


		}

		public void loadMove (int move)
        {
			movedata.currentMove = move;

			int i = 0;
			for (i=0;i<255;i++)
            {
				movedata.currentMove = i;
				dataGridView1.Rows[i].Cells[0].Value = i+1;
				//dataGridView1.Rows[i].Cells[1].Value = SelectedMove.Items[i].ToString();
				dataGridView1.Rows[i].Cells[1].Value = namedata.moveNamesList[i];
				dataGridView1.Rows[i].Cells[2].Value = moveType.Items[movedata.type].ToString();
				dataGridView1.Rows[i].Cells[3].Value = psdata.CheckSpecial(i) ? "Special":"Physical";//PS split
				dataGridView1.Rows[i].Cells[3].Style.BackColor = psdata.CheckSpecial(i) ? Color.Yellow : Color.White;//PS split

				dataGridView1.Rows[i].Cells[4].Value = movedata.power.ToString();
				//dataGridView1.Rows[i].Cells[5].Value = movedata.accuracy.ToString();
				dataGridView1.Rows[i].Cells[5].Value = string.Format("{0:#.##}", movedata.accuracy*100 / 255) + "%";
				dataGridView1.Rows[i].Cells[6].Value = movedata.powerpoints.ToString();
				dataGridView1.Rows[i].Cells[7].Value = moveAnim.Items[movedata.anim].ToString();
				dataGridView1.Rows[i].Cells[8].Value = moveEffect.Items[movedata.effect].ToString();



			}
			movedata.currentMove = move;

			MoveNameBox.Text = namedata.moveNamesList[move];
			groupBox1.Text = "Move "+(move+1).ToString();

			moveAnim.SelectedIndex = movedata.anim;
			moveEffect.SelectedIndex = movedata.effect;
			movePower.Value = movedata.power;
			moveType.SelectedIndex = movedata.type;
			moveAccuracy.Value = movedata.accuracy;
			accuracypercentLab.Text = string.Format("{0:#.##}", ((moveAccuracy.Value / 255) * 100)) + "%";
			movePP.Value = movedata.powerpoints;

			psSplitCheckbox.Checked = psdata.CheckSpecial(move);

			if (move == 180-1)//Move 0x00 is ommited in the list
			{
				MessageBox.Show("Warning!\n\nMove index 180 is (for some reason) usable as Surf outside battle!");
			}
		}

        private void SelectedMove_SelectedIndexChanged(object sender, EventArgs e)
        {
			loadMove(SelectedMove.SelectedIndex);

		}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
			SelectedMove.SelectedIndex = dataGridView1.CurrentRow.Index;
		}

		private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
			SelectedMove.SelectedIndex = dataGridView1.CurrentRow.Index;
		}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
			SelectedMove.SelectedIndex = dataGridView1.CurrentRow.Index;
		}

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
			SelectedMove.SelectedIndex = dataGridView1.CurrentRow.Index;
		}

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
			//SelectedMove.SelectedIndex = dataGridView1.CurrentRow.Index;
		}

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
			SelectedMove.SelectedIndex = dataGridView1.CurrentRow.Index;
		}

        private void moveAccuracy_ValueChanged(object sender, EventArgs e)
        {
			accuracypercentLab.Text = string.Format("{0:#.##}", ((moveAccuracy.Value / 255) * 100)) + "%";

		}

        private void SaveMoveBut_Click(object sender, EventArgs e)
        {
			//Store move data to buffer
			movedata.anim = (byte)(moveAnim.SelectedIndex);
			movedata.effect = (byte)(moveEffect.SelectedIndex);
			movedata.power = (byte)(movePower.Value);
			movedata.type = (byte)(moveType.SelectedIndex);
			movedata.accuracy = (byte)(moveAccuracy.Value);
			movedata.powerpoints = (byte)(movePP.Value);

			//Store name
			namedata.moveNamesList[SelectedMove.SelectedIndex] = MoveNameBox.Text;
			namedata.RebuildNameList();

			//Save PS split data
			psdata.SetSpecial(SelectedMove.SelectedIndex, psSplitCheckbox.Checked);

			//Reload data to update grid
			loadMove(SelectedMove.SelectedIndex);

		}

        private void SaveExitBut_Click(object sender, EventArgs e)
        {
			//Copy changes to rom and close
			Buffer.BlockCopy(movedata.Data, 0, BrownEditor.MainForm.filebuffer, MoveDataOffset, moveDataSize);
			Buffer.BlockCopy(namedata.Data, 0, BrownEditor.MainForm.filebuffer, MoveNamesOffset, MoveNamesSize);
			Buffer.BlockCopy(psdata.Data, 0, BrownEditor.MainForm.filebuffer, PSsplitDataOffset, movePSDataSize);
			this.Close();
        }

        private void ExitBut_Click(object sender, EventArgs e)
        {
			this.Close();
        }
    }
    public class MOVENAMEDATA
	{
		internal int Size = MoveEditor.MoveNamesSize;
		public string[] moveNamesList = new string[255];

		public byte[] Data;
		public MOVENAMEDATA(byte[] data = null)
		{
			Data = data ?? new byte[Size];
		}
		public void populateNameList()
        {
			int curbyte = 0;
			int i = 0;
			int j = 0;
			var tempname = new byte[13];

			for (i = 0; i < 255; i++)
			{
				j = 0;
				for (j =0;j<13;j++)
                {
					tempname[j] = 0x00;
                }
				j = 0;
				while (true)
				{
					tempname[j] = Data[curbyte];
					j++;
					curbyte++;
					if (Data[curbyte] == 0x50)
					{
						curbyte++;
						break;
					}
					if (curbyte > MoveEditor.MoveNamesSize)
					{
						MessageBox.Show("Something went wrong retrieving move name data");
						break;
					}
				}
				moveNamesList[i] = PKHeX.Core.StringConverter12.GetString(tempname, false);
				//MessageBox.Show(moveNamesList[i]);
			}
		}
		//This function gets all names in moveNamesList and encodes the strings back to gen 1 format in the Data block
		public void RebuildNameList()
        {
			var tempname = new byte[13];
			int curmove = 0;
			int curbyte = 0;
			int i = 0;

			for (curmove = 0; curmove < 255; curmove++)
            {
				PKHeX.Core.StringConverter12.SetString(tempname, moveNamesList[curmove].ToArray(), 12, false, StringConverterOption.ClearZero);
				//MessageBox.Show(BitConverter.ToString(tempname));
				for (i=0; i<14;i++)
                {
					Data[curbyte] = tempname[i];
					curbyte++;
					if (tempname[i] == 0x50) break;
                }
			}
        }
	}

	public class MOVEPSDATA
	{
		internal int Size = MoveEditor.movePSDataSize;
		internal int curByte;
		internal int curBit;

		public byte[] Data;
		public MOVEPSDATA(byte[] data = null)
		{
			Data = data ?? new byte[Size];
		}
		internal void GetBitFromIndex (int index)
        {
			curByte = index / 8;
			curBit = index % 8;
		}
		public bool CheckSpecial(int moveIndex)
        {
			if (moveIndex > 255) MessageBox.Show("Invalid move index " + moveIndex.ToString());
			GetBitFromIndex(moveIndex);
			return Convert.ToBoolean(Data[curByte] >> curBit & 1);		
        }
		
		public void SetSpecial(int moveIndex, bool special)
        {
			GetBitFromIndex(moveIndex);
			if (special)
            {
				Data[curByte] |= (byte)(1 << curBit);
			}
			else
            {
				Data[curByte] &= (byte) (~(1 << curBit));
			}
		}
	}
	public class MOVEDATA
	{

		internal int Size = MoveEditor.moveDataSize;
		internal byte animbyte = 0;
		internal byte effectbyte = 0;
		internal byte powerbyte = 0;
		internal byte typebyte = 0;
		internal byte accuracybyte = 0;
		internal byte ppbyte = 0;

		internal int currentMove = 0;

		public byte[] Data;
		public MOVEDATA(byte[] data = null)
		{
			Data = data ?? new byte[Size];
		}

		public void readMove(int move)
        {
			if (move > MoveEditor.moveDataSlots)
			{ MessageBox.Show("Move has to be between 0 and 255");
				currentMove = 255;
			}
			else { currentMove = move; }
			return;
        }

		public byte anim
        {
			get {
				animbyte = Data[currentMove*MoveEditor.moveDataSingleSize];
				return animbyte;
			}
			set {
				animbyte = value;
				Data[currentMove * MoveEditor.moveDataSingleSize] = animbyte;
			}
		}
		public byte effect
		{
			get
			{
				effectbyte = Data[(currentMove * MoveEditor.moveDataSingleSize)+1];
				return effectbyte;
			}
			set {
				effectbyte = value;
				Data[(currentMove * MoveEditor.moveDataSingleSize) + 1] = effectbyte;
			}
		}
		public byte power
		{
			get
			{
				powerbyte = Data[(currentMove * MoveEditor.moveDataSingleSize)+2];
				return powerbyte;
			}
			set {
				powerbyte = value;
				Data[(currentMove * MoveEditor.moveDataSingleSize) + 2] = powerbyte;
			}
		}
		public byte type
		{
			get
			{
				typebyte = Data[(currentMove * MoveEditor.moveDataSingleSize) + 3];
				return typebyte;
			}
			set {
				typebyte = value;
				Data[(currentMove * MoveEditor.moveDataSingleSize) + 3] = typebyte;
			}
		}
		public byte accuracy
		{
			get
			{
				accuracybyte = Data[(currentMove * MoveEditor.moveDataSingleSize) + 4];
				return accuracybyte;
			}
			set {
				accuracybyte = value;
				Data[(currentMove * MoveEditor.moveDataSingleSize) + 4] = accuracybyte;
			}
		}
		public byte powerpoints
		{
			get
			{
				ppbyte = Data[(currentMove * MoveEditor.moveDataSingleSize) + 5];
				return ppbyte;
			}
			set {
				ppbyte = value;
				Data[(currentMove * MoveEditor.moveDataSingleSize) + 5] = ppbyte;

			}
		}
	}

}
