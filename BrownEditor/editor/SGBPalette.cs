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

        Bitmap bmp = new Bitmap(16, 14);

        bool autoupdate = false;
        public SGBPalette()
        {
            sgbpalettes = new SGBPALETTEDATA(BrownEditor.MainForm.filebuffer.Skip(SGBPaletteOffset).Take(SGBPalettes_totalSize).ToArray());
            InitializeComponent();
            load_palette((int)paletteIndex.Value);

            //Load image
            Buffer.BlockCopy(BrownEditor.MainForm.filebuffer, testpicAddr, bppbuffer, 0, 784);
            bmp = new Bitmap(56, 56);
            process_5656_2bpp(bppbuffer, bmp);
            Bitmap resized = new Bitmap(bmp, new Size(bmp.Width * 8, bmp.Height * 8));
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

        void process_5656_2bpp(byte [] twobpp, Bitmap bmp)
        {
            //Load current palette colors
            Color color0 = sgbpalettes.toRGB(0);
            Color color1 = sgbpalettes.toRGB(1);
            Color color2 = sgbpalettes.toRGB(2);
            Color color3 = sgbpalettes.toRGB(3);

            int column = 0;
            int row = 0;
            //Each tile is 8x8 pixels, a 56x56 image has 7x7 tiles

            for (row = 0; row < 7; row++)
            {

                for (column = 0; column < 7; column++)
                {
                    drawtile(twobpp, bmp, row, column, color0, color1, color2, color3);
                }
                column = 0;
            }
            //drawtile(twobpp, bmp, row, column, color0, color1, color2, color3);
        }
        void drawtile(byte[] twobpp, Bitmap bmp, int row, int column, Color color0, Color color1, Color color2, Color color3)
        {
            int tilerow = 0;
            int tilecolumn = 0;
            for (tilerow = 0; tilerow < 8; tilerow++)
            {
                for (tilecolumn = 0; tilecolumn < 8; tilecolumn++)
                {
                    //
                    //twobpp[i]
                    bmp.SetPixel((column*8)+tilecolumn, (row*8)+tilerow, color2);
                    Debug.WriteLine("X:" + ((column*8) + tilecolumn).ToString() + " Y:" + ((row*8) + tilerow).ToString()) ;
                }
                tilecolumn = 0;
            }
        }

        void load_palette(int index)
        {
            sgbpalettes.SetcurrentPalette (index);
            palettePanel0.BackColor = sgbpalettes.toRGB(0);
            palettePanel1.BackColor = sgbpalettes.toRGB(1);
            palettePanel2.BackColor = sgbpalettes.toRGB(2);
            palettePanel3.BackColor = sgbpalettes.toRGB(3);

            LoadPaletteColour(0);
 
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
