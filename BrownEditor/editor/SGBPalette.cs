using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace BrownEditor.editor
{
    public partial class SGBPalette : Form
    {
        public static SGBPALETTEDATA sgbpalettes;

        public static int SGBPaletteOffset = 0x1f4000;
        public static int SGBPaletteSize = 8;
        public static int SGBPaletteNum = 256;
        public static int SGBPalettes_totalSize = SGBPaletteSize * SGBPaletteNum;

        public static int normalPalettesAddr = 0x73250;
        public static int shinyPalettesAddr = 0x725d0;
        private static byte[] frontbppbuffer = new byte[784];
        private static byte[] backbppbuffer = new byte[784];

        private static byte[] tempbuffer;

        private string twobppfilter = "2 byte per pixel image|*.2bpp|All Files (*.*)|*.*";
        private static byte[] external2bpp;

        private bool SwapColumns2bpp = true;


        Color [] CurrentPaletteColors = new Color[4];

        Bitmap Frontbmp = new Bitmap(56, 56);
        Bitmap Frontresized;
        Bitmap Backbmp = new Bitmap(56, 56);
        Bitmap Backresized;

        bool autoupdate = false;
        public SGBPalette()
        {
            InitializeComponent();

            SwapColumns2bpp = true;

            tempbuffer = new byte[0x200000];
            BrownEditor.MainForm.filebuffer.CopyTo(tempbuffer, 0);
            sgbpalettes = new SGBPALETTEDATA(tempbuffer.Skip(SGBPaletteOffset).Take(SGBPalettes_totalSize).ToArray());

            Note_label.Text = "Note: Color 0 is forced to 7fbf in most\n" +
                              "circumstances regardless of the palette.\n" +
                              "The same happens with Color 3 and black.";

            load_palette((int)paletteIndex.Value); //Also loads images

            pokemonComboBox.SelectedIndex = 5; //Default to charizard


        }
        void reload_images(bool columnOrder)
        {

            process_5656_2bpp(frontbppbuffer, Frontbmp, columnOrder, CurrentPaletteColors); 
            process_5656_2bpp(backbppbuffer, Backbmp, columnOrder, CurrentPaletteColors);

            pictureBox1.Image = ResizeBitmap(Frontbmp, 168, 168);
            pictureBox2.Image = ResizeBitmap(Backbmp, 168, 168);
        }

        private Bitmap ResizeBitmap(Bitmap sourceBMP, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(sourceBMP, 0, 0, width, height);
            }
            return result;
        }

        void process_5656_2bpp(byte [] twobpp, Bitmap bmp, bool colMajor, Color[] palette)
        {

            byte [] rawtile = new byte[16];


            int column = 0;
            int row = 0;
            int curtile = 0;

            //Each tile is 8x8 pixels, a 56x56 image has 7x7 tiles

            for (row = 0; row < 7; row++)
            {
                //Buffer.BlockCopy(twobpp, row*16+16*column, rawtile, 0, 16);
                for (column = 0; column < 7; column++)
                {
                    Buffer.BlockCopy(twobpp, curtile*16, rawtile, 0, 16);
                    if (colMajor)
                        drawtile(rawtile, bmp, column, row, CurrentPaletteColors);
                    else
                        drawtile(rawtile, bmp, row, column, CurrentPaletteColors);
                    curtile++;
                }
                column = 0;
            }
            //drawtile(twobpp, bmp, row, column, color0, color1, color2, color3);
        }
        void drawtile(byte[] rawtile, Bitmap bmp, int row, int column, Color[] palette)
        {
            int tilerow = 0;
            int tilecolumn = 0;
            int pixel = 0;
            byte [] pixelcolors = gettilepixelcolors(rawtile);
            foreach (byte i in pixelcolors)
            {
                //Debug.WriteLine (i.ToString("X"));
            }
            for (tilerow = 0; tilerow < 8; tilerow++)
            {
                for (tilecolumn = 0; tilecolumn < 8; tilecolumn++)
                {
                    //Get the color for each pixel
                    //get2bppcolor(twobpp[1], twobpp[0], tilecolumn;

                    bmp.SetPixel((column*8)+tilecolumn, (row*8)+tilerow, CurrentPaletteColors[pixelcolors[pixel]]);
                    //Debug.WriteLine(pixel.ToString());
                    //Debug.WriteLine("X:" + ((column*8) + tilecolumn).ToString() + " Y:" + ((row*8) + tilerow).ToString()) ;
                    pixel++;
                }
                tilecolumn = 0;
            }
        }

        //bye[] tile: 16 byte 2bpp tile array
        byte [] gettilepixelcolors(byte [] tile)
        {
            byte [] pixels = new byte[8*8];
            int j = 0;
            int i = 0;
            for (j = 0; j < 8; j++)
            {
                for (i = 0; i < 8; i++)
                {
                    byte hiBit = (byte)( (tile[j * 2 + 1] >> (7 - i)) & 1 );
                    byte loBit = (byte)( (tile[j * 2] >> (7 - i)) & 1 );
                    pixels[j * 8 + i] = (byte) ((hiBit << 1) | loBit);
                }
            }
            return pixels;
        }

        void UpdateDrawingColors()
        {
            CurrentPaletteColors[0] = palettePanel0.BackColor;
            CurrentPaletteColors[1] = palettePanel1.BackColor;
            CurrentPaletteColors[2] = palettePanel2.BackColor;
            CurrentPaletteColors[3] = palettePanel3.BackColor;
        }

        void load_palette(int index)
        {
            sgbpalettes.SetcurrentPalette (index);

            palettePanel0.BackColor = sgbpalettes.toRGB(0);
            palettePanel1.BackColor = sgbpalettes.toRGB(1);
            palettePanel2.BackColor = sgbpalettes.toRGB(2);
            palettePanel3.BackColor = sgbpalettes.toRGB(3);

            UpdateDrawingColors();

            LoadPaletteColour(0);

            reload_images(SwapColumns2bpp);
        }

        void LoadPaletteColour(int index)
        {
            autoupdate = false;

            panelActiveColor.BackColor = sgbpalettes.toRGB(index);


            RGBupdownR.Value = panelActiveColor.BackColor.R;
            RGBupdownG.Value = panelActiveColor.BackColor.G;
            RGBupdownB.Value = panelActiveColor.BackColor.B;

            RGBHupdownR.Value = panelActiveColor.BackColor.R;
            RGBHupdownG.Value = panelActiveColor.BackColor.G;
            RGBHupdownB.Value = panelActiveColor.BackColor.B;

            trackBarR.Value = panelActiveColor.BackColor.R;
            trackBarG.Value = panelActiveColor.BackColor.G;
            trackBarB.Value = panelActiveColor.BackColor.B;


            RGB15updownR.Value = sgbpalettes.RGB15(index, 'r');
            RGB15updownG.Value = sgbpalettes.RGB15(index, 'g');
            RGB15updownB.Value = sgbpalettes.RGB15(index, 'b');

            textboxRGBHex.Text = panelActiveColor.BackColor.R.ToString("X2") + panelActiveColor.BackColor.G.ToString("X2") + panelActiveColor.BackColor.B.ToString("X2");
            textboxBGR15.Text = sgbpalettes.RGB15(index, 'z').ToString("X");

            autoupdate = true;

        }

        void ReloadLoadPannelColour(int panel)
        {
            autoupdate = false;

            if (panel == 0)
            {
                RGBupdownR.Value = palettePanel0.BackColor.R;
                RGBupdownG.Value = palettePanel0.BackColor.G;
                RGBupdownB.Value = palettePanel0.BackColor.B;

                RGBHupdownR.Value = palettePanel0.BackColor.R;
                RGBHupdownG.Value = palettePanel0.BackColor.G;
                RGBHupdownB.Value = palettePanel0.BackColor.B;

                trackBarR.Value = palettePanel0.BackColor.R;
                trackBarG.Value = palettePanel0.BackColor.G;
                trackBarB.Value = palettePanel0.BackColor.B;

                /*
                RGB15updownR.Value = sgbpalettes.RGB15(index, 'r');
                RGB15updownG.Value = sgbpalettes.RGB15(index, 'g');
                RGB15updownB.Value = sgbpalettes.RGB15(index, 'b');
                */

                panelActiveColor.BackColor = palettePanel0.BackColor;
            }
            if (panel == 1)
            {
                RGBupdownR.Value = palettePanel1.BackColor.R;
                RGBupdownG.Value = palettePanel1.BackColor.G;
                RGBupdownB.Value = palettePanel1.BackColor.B;

                RGBHupdownR.Value = palettePanel1.BackColor.R;
                RGBHupdownG.Value = palettePanel1.BackColor.G;
                RGBHupdownB.Value = palettePanel1.BackColor.B;

                trackBarR.Value = palettePanel1.BackColor.R;
                trackBarG.Value = palettePanel1.BackColor.G;
                trackBarB.Value = palettePanel1.BackColor.B;

                /*
                RGB15updownR.Value = sgbpalettes.RGB15(index, 'r');
                RGB15updownG.Value = sgbpalettes.RGB15(index, 'g');
                RGB15updownB.Value = sgbpalettes.RGB15(index, 'b');
                */

                panelActiveColor.BackColor = palettePanel1.BackColor;
            }
            if (panel == 2)
            {
                RGBupdownR.Value = palettePanel2.BackColor.R;
                RGBupdownG.Value = palettePanel2.BackColor.G;
                RGBupdownB.Value = palettePanel2.BackColor.B;

                RGBHupdownR.Value = palettePanel2.BackColor.R;
                RGBHupdownG.Value = palettePanel2.BackColor.G;
                RGBHupdownB.Value = palettePanel2.BackColor.B;

                trackBarR.Value = palettePanel2.BackColor.R;
                trackBarG.Value = palettePanel2.BackColor.G;
                trackBarB.Value = palettePanel2.BackColor.B;

                /*
                RGB15updownR.Value = sgbpalettes.RGB15(index, 'r');
                RGB15updownG.Value = sgbpalettes.RGB15(index, 'g');
                RGB15updownB.Value = sgbpalettes.RGB15(index, 'b');
                */

                panelActiveColor.BackColor = palettePanel2.BackColor;
            }
            if (panel == 3)
            {
                RGBupdownR.Value = palettePanel3.BackColor.R;
                RGBupdownG.Value = palettePanel3.BackColor.G;
                RGBupdownB.Value = palettePanel3.BackColor.B;

                RGBHupdownR.Value = palettePanel3.BackColor.R;
                RGBHupdownG.Value = palettePanel3.BackColor.G;
                RGBHupdownB.Value = palettePanel3.BackColor.B;

                trackBarR.Value = palettePanel3.BackColor.R;
                trackBarG.Value = palettePanel3.BackColor.G;
                trackBarB.Value = palettePanel3.BackColor.B;

                /*
                RGB15updownR.Value = sgbpalettes.RGB15(index, 'r');
                RGB15updownG.Value = sgbpalettes.RGB15(index, 'g');
                RGB15updownB.Value = sgbpalettes.RGB15(index, 'b');
                */

                panelActiveColor.BackColor = palettePanel3.BackColor;
            }

            textboxRGBHex.Text = panelActiveColor.BackColor.R.ToString("X2") + panelActiveColor.BackColor.G.ToString("X2") + panelActiveColor.BackColor.B.ToString("X2");
            //textboxBGR15.Text = sgbpalettes.RGB15(index, 'z').ToString("X");

            autoupdate = true;

        }

        void UpdateRGBDecColor()
        {
            if (autoupdate)
            {
                panelActiveColor.BackColor = Color.FromArgb(255, (int)RGBupdownR.Value, (int)RGBupdownG.Value, (int)RGBupdownB.Value);

                RGBHupdownR.Value = panelActiveColor.BackColor.R;
                RGBHupdownG.Value = panelActiveColor.BackColor.G;
                RGBHupdownB.Value = panelActiveColor.BackColor.B;

                trackBarR.Value = panelActiveColor.BackColor.R;
                trackBarG.Value = panelActiveColor.BackColor.G;
                trackBarB.Value = panelActiveColor.BackColor.B;

                RGB15updownR.Value = ((ConvertColortoSFC(panelActiveColor.BackColor) & 0x7C00) >> 10);
                RGB15updownG.Value = ((ConvertColortoSFC(panelActiveColor.BackColor) & 0x03e0) >> 5);
                RGB15updownB.Value = (ConvertColortoSFC(panelActiveColor.BackColor) & 0x1f);

                textboxRGBHex.Text = panelActiveColor.BackColor.R.ToString("X2") + panelActiveColor.BackColor.G.ToString("X2") + panelActiveColor.BackColor.B.ToString("X2");
                int rgb15 = (int)RGB15tou16Color((int)RGB15updownR.Value, (int)RGB15updownG.Value, (int)RGB15updownB.Value);
                textboxBGR15.Text = rgb15.ToString("X");

            }
        }

        void UpdateRGBHexColor()
        {
            if (autoupdate)
            {
                panelActiveColor.BackColor = Color.FromArgb(255, (int)RGBHupdownR.Value, (int)RGBHupdownG.Value, (int)RGBHupdownB.Value);

                RGBupdownR.Value = panelActiveColor.BackColor.R;
                RGBupdownG.Value = panelActiveColor.BackColor.G;
                RGBupdownB.Value = panelActiveColor.BackColor.B;

                trackBarR.Value = panelActiveColor.BackColor.R;
                trackBarG.Value = panelActiveColor.BackColor.G;
                trackBarB.Value = panelActiveColor.BackColor.B;

                RGB15updownR.Value = ((ConvertColortoSFC(panelActiveColor.BackColor) & 0x7C00) >> 10);
                RGB15updownG.Value = ((ConvertColortoSFC(panelActiveColor.BackColor) & 0x03e0) >> 5);
                RGB15updownB.Value = (ConvertColortoSFC(panelActiveColor.BackColor) & 0x1f);

                textboxRGBHex.Text = panelActiveColor.BackColor.R.ToString("X2") + panelActiveColor.BackColor.G.ToString("X2") + panelActiveColor.BackColor.B.ToString("X2");
                int rgb15 = (int)RGB15tou16Color((int)RGB15updownR.Value, (int)RGB15updownG.Value, (int)RGB15updownB.Value);
                textboxBGR15.Text = rgb15.ToString("X");

            }
        }
        UInt16 RGB15tou16Color(int r, int g, int b)
        {
            int rgb15 = (r << 10) + (g << 5) + b;
            return (UInt16)rgb15;
        }
        Color RGB15toColor(int r, int g, int b)
        {
            int rgb15 = (r << 10) + (g << 5) + b;
            Color tempcolor = ConvertSFCtoColor((UInt16)rgb15);
            return tempcolor;
        }
        void UpdateRGB15Color()
        {
            if (autoupdate)
            {
                //Build rgb15 u16 color

                int rgb15 = (int)RGB15tou16Color((int)RGB15updownR.Value, (int)RGB15updownG.Value, (int)RGB15updownB.Value);
                panelActiveColor.BackColor = ConvertSFCtoColor((UInt16)rgb15);

                RGBupdownR.Value = panelActiveColor.BackColor.R;
                RGBupdownG.Value = panelActiveColor.BackColor.G;
                RGBupdownB.Value = panelActiveColor.BackColor.B;

                RGBHupdownR.Value = panelActiveColor.BackColor.R;
                RGBHupdownG.Value = panelActiveColor.BackColor.G;
                RGBHupdownB.Value = panelActiveColor.BackColor.B;

                trackBarR.Value = panelActiveColor.BackColor.R;
                trackBarG.Value = panelActiveColor.BackColor.G;
                trackBarB.Value = panelActiveColor.BackColor.B;

                textboxRGBHex.Text = panelActiveColor.BackColor.R.ToString("X2") + panelActiveColor.BackColor.G.ToString("X2") + panelActiveColor.BackColor.B.ToString("X2");
                textboxBGR15.Text = rgb15.ToString("X");

            }
        }

        void UpdateTrackBarColor()
        {
            if (autoupdate)
            {
                panelActiveColor.BackColor = Color.FromArgb(255, (int)trackBarR.Value, (int)trackBarG.Value, (int)trackBarB.Value);

                RGBupdownR.Value = panelActiveColor.BackColor.R;
                RGBupdownG.Value = panelActiveColor.BackColor.G;
                RGBupdownB.Value = panelActiveColor.BackColor.B;

                RGBHupdownR.Value = panelActiveColor.BackColor.R;
                RGBHupdownG.Value = panelActiveColor.BackColor.G;
                RGBHupdownB.Value = panelActiveColor.BackColor.B;

                RGB15updownR.Value = ((ConvertColortoSFC(panelActiveColor.BackColor) & 0x7C00) >> 10);
                RGB15updownG.Value = ((ConvertColortoSFC(panelActiveColor.BackColor) & 0x03e0) >> 5);
                RGB15updownB.Value = (ConvertColortoSFC(panelActiveColor.BackColor) & 0x1f);

                textboxRGBHex.Text = panelActiveColor.BackColor.R.ToString("X2") + panelActiveColor.BackColor.G.ToString("X2") + panelActiveColor.BackColor.B.ToString("X2");
                int rgb15 = RGB15tou16Color((int)RGB15updownR.Value, (int)RGB15updownG.Value, (int)RGB15updownB.Value);
                textboxBGR15.Text = rgb15.ToString("X");

            }
        }

        public static Color ConvertSFCtoColor(int bgr15)
        {
            var (r, g, b) = ConvertSFCtoRGB(bgr15);
            return Color.FromArgb(r, g, b);
        }

        // Convert 15 bit BGR value to 24 bit RGB value
        // Algorithm from: https://wiki.superfamicom.org/palettes
        public static (int r, int g, int b) ConvertSFCtoRGB(int bgr15)
        {
            if (bgr15 > 0x7FFF)
            {
                return (255, 255, 255);
            }
            int r = bgr15 % 32 << 3;
            int g = (bgr15 >> 5) % 32 << 3;
            int b = bgr15 >> 10 % 32 << 3;
            // adjust for higher precision
            r += r / 32;
            g += g / 32;
            b += b / 32;
            return (r, g, b);
        }
        public static UInt16 ConvertColortoSFC(Color c)
        {
            return ConvertRGBtoSFC(c.R, c.G, c.B);
        }

        public static UInt16 ConvertRGBtoSFC(int r, int g, int b)
        {
            int bgr15 = (b >> 3 << 10) + (g >> 3 << 5) + (r >> 3);
            return (UInt16)bgr15;
        }

        public class SGBPALETTEDATA
        {
            internal int Size = SGBPalette.SGBPalettes_totalSize;
            internal int _currentPalette = 0;

            public byte[] Data;
            public SGBPALETTEDATA(byte[] data = null)
            {
                Data = data ?? new byte[Size];
            }
            public int CurrentPalette
            {
                get
                {
                    return _currentPalette;
                }
            }
            public void SetcurrentPalette(int palette)
            {
                if (palette > 255)
                    _currentPalette = 255;
                else
                    _currentPalette = palette;
            }
            public Color toRGB(int colorIndex)
            {

                if (colorIndex > 3) colorIndex = 3;
                UInt16 color15 = RGB15(colorIndex, 'z');

                Color colorRGB = ConvertSFCtoColor(color15);

                return colorRGB;
            }

            public UInt16 RGB15(int colorIndex, char rgbcol)
            {
                if (colorIndex > 3) colorIndex = 3;
                UInt16 color15 = BitConverter.ToUInt16(Data, (SGBPaletteSize * _currentPalette) + (colorIndex * 2));

                if (rgbcol == 'r')
                {
                    return (UInt16)((color15 & 0x7C00) >> 10);
                }
                if (rgbcol == 'g')
                {
                    return (UInt16)((color15 & 0x03e0) >> 5);
                }
                if (rgbcol == 'b')
                {
                    return (UInt16)(color15 & 0x1f);
                }

                return color15;

            }

            public void storeSGBPalette(Color color0, Color color1, Color color2, Color color3 )
            {
                UInt16 u16color = ConvertColortoSFC(color0);
                Buffer.BlockCopy(BitConverter.GetBytes(u16color), 0, Data, (SGBPaletteSize * _currentPalette), 2);
                u16color = ConvertColortoSFC(color1);
                Buffer.BlockCopy(BitConverter.GetBytes(u16color), 0, Data, (SGBPaletteSize * _currentPalette)+2, 2);
                u16color = ConvertColortoSFC(color2);
                Buffer.BlockCopy(BitConverter.GetBytes(u16color), 0, Data, (SGBPaletteSize * _currentPalette)+4, 2);
                u16color = ConvertColortoSFC(color3);
                Buffer.BlockCopy(BitConverter.GetBytes(u16color), 0, Data, (SGBPaletteSize * _currentPalette)+6, 2);
            }
        }

        private void paletteIndex_ValueChanged(object sender, EventArgs e)
        {
            load_palette((int)paletteIndex.Value);
            palSlotHexLabel.Text = "0x"+ ((int)paletteIndex.Value).ToString("X2");
            saveSlotNUD.Value = paletteIndex.Value;
        }
        private void palettePanel0_MouseClick(object sender, MouseEventArgs e)
        {
            ReloadLoadPannelColour(0);
        }

        private void palettePanel1_MouseClick(object sender, MouseEventArgs e)
        {
            ReloadLoadPannelColour(1);
        }

        private void palettePanel2_MouseClick(object sender, MouseEventArgs e)
        {
            ReloadLoadPannelColour(2);
        }

        private void palettePanel3_MouseClick(object sender, MouseEventArgs e)
        {
            ReloadLoadPannelColour(3);
        }

        private void RGB15updown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown activeNUD = (NumericUpDown)sender;
            if (!activeNUD.Focused)
                return;
            UpdateRGB15Color();
        }

        private void RGBHupdown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown activeNUD = (NumericUpDown)sender;
            if (!activeNUD.Focused)
                return;
            UpdateRGBHexColor();
        }


        private void RGBupdown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown activeNUD = (NumericUpDown)sender;
            if (!activeNUD.Focused)
                return;
            UpdateRGBDecColor();
        }

        private void trackBarChanged(object sender, EventArgs e)
        {
            if (!((TrackBar)sender).Focused)
                return;
            UpdateTrackBarColor();
        }

        private void setPal0_Click(object sender, EventArgs e)
        {
            palettePanel0.BackColor = panelActiveColor.BackColor;
            UpdateDrawingColors();
            reload_images(SwapColumns2bpp);
        }

        private void setPal1_Click(object sender, EventArgs e)
        {
            palettePanel1.BackColor = panelActiveColor.BackColor;
            UpdateDrawingColors();
            reload_images(SwapColumns2bpp);
        }

        private void setPal2_Click(object sender, EventArgs e)
        {
            palettePanel2.BackColor = panelActiveColor.BackColor;
            UpdateDrawingColors();
            reload_images(SwapColumns2bpp);
        }

        private void setPal3_Click(object sender, EventArgs e)
        {
            palettePanel3.BackColor = panelActiveColor.BackColor;
            UpdateDrawingColors();
            reload_images(SwapColumns2bpp);
        }

        private void savePaletteBut_Click(object sender, EventArgs e)
        {
            sgbpalettes.SetcurrentPalette((int)saveSlotNUD.Value);
            sgbpalettes.storeSGBPalette(palettePanel0.BackColor, palettePanel1.BackColor, palettePanel2.BackColor, palettePanel3.BackColor);
            paletteIndex.Value = saveSlotNUD.Value;

            MessageBox.Show("Palette Saved at index" + saveSlotNUD.Value.ToString()+"\nPalette is switched to that index.");
        }

        private void ReloadPaletteBut_Click(object sender, EventArgs e)
        {
            load_palette((int)paletteIndex.Value);
        }


        void loadMonPic(int dexnum)
        {
            int BasesstatsOffset = 0xFC336;
            int basestat_size = 28;
            int FrontpicAddr = BasesstatsOffset+(dexnum*basestat_size)+11;
            int BackpicAddr = BasesstatsOffset + (dexnum * basestat_size)+13;
            int BankAddr = BasesstatsOffset + (dexnum * basestat_size)+27;

            int truepointer = 0;

            UInt16 pointer = BitConverter.ToUInt16(tempbuffer, FrontpicAddr);
            truepointer = BrownEditor.MainForm.ThreeByteToTwoByte(tempbuffer[BankAddr], pointer);
            Buffer.BlockCopy(tempbuffer, truepointer, frontbppbuffer, 0, 784);

            //Debug.WriteLine(pointer.ToString());
            //Debug.WriteLine(truepointer.ToString());

            pointer = BitConverter.ToUInt16(tempbuffer, BackpicAddr);
            truepointer = BrownEditor.MainForm.ThreeByteToTwoByte(tempbuffer[BankAddr], pointer);
            Buffer.BlockCopy(tempbuffer, truepointer, backbppbuffer, 0, 784);

            //Debug.WriteLine(pointer.ToString());
            //Debug.WriteLine(truepointer.ToString());

            reload_images(SwapColumns2bpp);

        }
        private int getMonPalette(int index, bool shiny)
        {
            if (shiny)
                return tempbuffer[shinyPalettesAddr + index];
            return tempbuffer[normalPalettesAddr + index];

        }

        private void setMonPalette(int index, bool shiny)
        {
            if (shiny)
            {
                tempbuffer[shinyPalettesAddr + index] = (byte)monpaletteUD.Value;
            }
            else
            {
                tempbuffer[normalPalettesAddr + index] = (byte)monpaletteUD.Value;
            }

        }
        private void pokemonComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMonPic(pokemonComboBox.SelectedIndex);
            monpaletteUD.Value = getMonPalette(pokemonComboBox.SelectedIndex+1, shinyRadioBut.Checked);
        }

        private void monpaletteUD_ValueChanged(object sender, EventArgs e)
        {
            paletteIndex.Value = monpaletteUD.Value;
            monPalIndexHex.Text = "0x" + ((int)monpaletteUD.Value).ToString("X2");
        }

        private void normalRadioBut_CheckedChanged(object sender, EventArgs e)
        {
            loadMonPic(pokemonComboBox.SelectedIndex);
            monpaletteUD.Value = getMonPalette(pokemonComboBox.SelectedIndex + 1, shinyRadioBut.Checked);

        }

        private void shinyRadioBut_CheckedChanged(object sender, EventArgs e)
        {
            loadMonPic(pokemonComboBox.SelectedIndex);
            monpaletteUD.Value = getMonPalette(pokemonComboBox.SelectedIndex + 1, shinyRadioBut.Checked);

        }

        private void saveMonPalBut_Click(object sender, EventArgs e)
        {
            setMonPalette(pokemonComboBox.SelectedIndex + 1, shinyRadioBut.Checked);
            MessageBox.Show("Pokémon Palette ID saved.");
        }

        private void exitBut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveExitBut_Click(object sender, EventArgs e)
        {
            //Mon palettes and picture...should be more more self contained instead of a whole rom copy...
            Buffer.BlockCopy(tempbuffer, 0, BrownEditor.MainForm.filebuffer, 0, 0x200000);
            Buffer.BlockCopy(sgbpalettes.Data, 0, BrownEditor.MainForm.filebuffer, SGBPaletteOffset, SGBPalettes_totalSize);
            MessageBox.Show("Saved.");
            this.Close();
        }


        void load2bpp(bool back)
        {
            MessageBox.Show("2BPP image must be exactly 784 bytes.\nGenerate it from a 4 colour 56x56 PNG image file with the following command using rgbgfx:\n\n\trgbgfx -Z -o battlesprite.2bpp battlepsrite.png.\n\n(Trainer sprites don't use the -Z option in-game, but to see one here you'll need to)");
            string filepath = null;
            int filesize = FileIO.load_file(ref external2bpp, ref filepath, twobppfilter);
            if (filesize != 784)
            {
                MessageBox.Show("Wrong image size: " + filesize + " bytes");
            }
            else
            {
                if (back)
                    Buffer.BlockCopy(external2bpp, 0, backbppbuffer, 0, 784);
                else
                    Buffer.BlockCopy(external2bpp, 0, frontbppbuffer, 0, 784);

                reload_images(SwapColumns2bpp);
            }
        }

        private void loadFront2bppBut_Click(object sender, EventArgs e)
        {
            load2bpp(false);
        }

        private void loadBack2bppBut_Click(object sender, EventArgs e)
        {
            load2bpp(true);
        }
    }
}
