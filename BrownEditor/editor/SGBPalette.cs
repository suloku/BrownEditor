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

        public static int testpicAddr = 0x152002;
        private static byte[] bppbuffer = new byte[784];

        Bitmap bmp;
        Bitmap resized;

        bool autoupdate = false;
        public SGBPalette()
        {
            sgbpalettes = new SGBPALETTEDATA(BrownEditor.MainForm.filebuffer.Skip(SGBPaletteOffset).Take(SGBPalettes_totalSize).ToArray());
            InitializeComponent();
            bmp = new Bitmap(56, 56);
            resized = new Bitmap(bmp, new Size(bmp.Width * 8, bmp.Height * 8));
            load_palette((int)paletteIndex.Value);

            /*//Load image
            Buffer.BlockCopy(BrownEditor.MainForm.filebuffer, testpicAddr, bppbuffer, 0, 784);
            bmp = new Bitmap(56, 56);
            process_5656_2bpp(bppbuffer, bmp, true);
            resized = new Bitmap(bmp, new Size(bmp.Width * 8, bmp.Height * 8));
            pictureBox1.Image = ResizeBitmap(bmp, 168, 168);*/

        }
        void reload_image()
        {
            //bmp.Dispose();
            //bmp = new Bitmap(56, 56);
            Buffer.BlockCopy(BrownEditor.MainForm.filebuffer, testpicAddr, bppbuffer, 0, 784);
            process_5656_2bpp(bppbuffer, bmp, true);
            //resized.Dispose();
            resized = new Bitmap(bmp, new Size(bmp.Width * 8, bmp.Height * 8));
            pictureBox1.Image = ResizeBitmap(bmp, 168, 168);
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

        void process_5656_2bpp(byte [] twobpp, Bitmap bmp, bool colMajor)
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
                        drawtile(rawtile, bmp, column, row);
                    else
                        drawtile(rawtile, bmp, row, column);
                    curtile++;
                }
                column = 0;
            }
            //drawtile(twobpp, bmp, row, column, color0, color1, color2, color3);
        }
        void drawtile(byte[] rawtile, Bitmap bmp, int row, int column)
        {
            int tilerow = 0;
            int tilecolumn = 0;
            int pixel = 0;
            byte [] pixelcolors = gettilepixels(rawtile);
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

                    bmp.SetPixel((column*8)+tilecolumn, (row*8)+tilerow, sgbpalettes.toRGB(pixelcolors[pixel]));
                    //Debug.WriteLine(pixel.ToString());
                    //Debug.WriteLine("X:" + ((column*8) + tilecolumn).ToString() + " Y:" + ((row*8) + tilerow).ToString()) ;
                    pixel++;
                }
                tilecolumn = 0;
            }
        }

        byte [] gettilepixels(byte [] tile)
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

        void load_palette(int index)
        {
            sgbpalettes.SetcurrentPalette (index);
            palettePanel0.BackColor = sgbpalettes.toRGB(0);
            palettePanel1.BackColor = sgbpalettes.toRGB(1);
            palettePanel2.BackColor = sgbpalettes.toRGB(2);
            palettePanel3.BackColor = sgbpalettes.toRGB(3);

            LoadPaletteColour(0);

            reload_image();
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
        public static int ConvertColortoSFC(Color c)
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

            public void storeSGBPalette(int palette, Color color0, Color color1, Color color2, Color color3 )
            {

            }
        }

        private void paletteIndex_ValueChanged(object sender, EventArgs e)
        {
            load_palette((int)paletteIndex.Value);
        }
        private void palettePanel0_MouseClick(object sender, MouseEventArgs e)
        {
            LoadPaletteColour(0);
        }

        private void palettePanel1_MouseClick(object sender, MouseEventArgs e)
        {
            LoadPaletteColour(1);
        }

        private void palettePanel2_MouseClick(object sender, MouseEventArgs e)
        {
            LoadPaletteColour(2);
        }

        private void palettePanel3_MouseClick(object sender, MouseEventArgs e)
        {
            LoadPaletteColour(3);
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
    }
}
