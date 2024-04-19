using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;


namespace project_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void openImage()
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                file = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = file;
                opened = true;
            }
        }
        void filter2()
        {
            if (!opened)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                Image img = pictureBox1.Image;
                Bitmap bmpPolaroid = new Bitmap(img.Width, img.Height);

                ImageAttributes ia = new ImageAttributes();

                // Create a color matrix for the lighter polaroid effect
                ColorMatrix cmPolaroid = new ColorMatrix(new float[][]
                {
            new float[]{1.2f, 0, 0, 0, 0},
            new float[]{0, 1.2f, 0, 0, 0},
            new float[]{0, 0, 1.2f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{-0.3f, -0.3f, -0.3f, 0, 1}
                });

                ia.SetColorMatrix(cmPolaroid);

                Graphics g = Graphics.FromImage(bmpPolaroid);

                // Fill the background with a white color to simulate the polaroid frame
                g.FillRectangle(Brushes.White, 0, 0, bmpPolaroid.Width, bmpPolaroid.Height);

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);

                // Draw a frame around the image to simulate the polaroid frame
                Pen framePen = new Pen(Color.Black, 3);
                g.DrawRectangle(framePen, 0, 0, bmpPolaroid.Width - 1, bmpPolaroid.Height - 1);

                g.Dispose();

                pictureBox1.Image = bmpPolaroid;
            }
        }


        void filter3()
        {
            if (!opened)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                Image img = pictureBox1.Image;
                Bitmap bmpPastel = new Bitmap(img.Width, img.Height);

                ImageAttributes ia = new ImageAttributes();

                // Create a color matrix for the lighter pastel effect
                ColorMatrix cmPastel = new ColorMatrix(new float[][]
                {
            new float[]{1.2f, 0, 0, 0, 0},
            new float[]{0, 1.2f, 0, 0, 0},
            new float[]{0, 0, 1.2f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0.2f, 0.2f, 0.2f, 0, 1}
                });

                ia.SetColorMatrix(cmPastel);

                Graphics g = Graphics.FromImage(bmpPastel);

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);

                g.Dispose();

                pictureBox1.Image = bmpPastel;
            }
        }



        void reload()
        {
            if (!opened)
            {
                // MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                if (opened)
                {
                    file = Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.Image = file;
                    opened = true;
                }
            }
        }

        void saveImage()
        {
            if (opened)
            {
                SaveFileDialog sfd = new SaveFileDialog(); // create a new save file dialog object
                sfd.Filter = "Images|*.png;*.bmp;*.jpg";
                ImageFormat format = ImageFormat.Png;// you want to store it in by default format
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string ext = Path.GetExtension(sfd.FileName);
                    switch (ext)
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }
                    pictureBox1.Image.Save(sfd.FileName, format);
                }



            }
            else { MessageBox.Show("No image loaded, first upload image "); }

        }

        Image file;
        bool opened = false;




        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openImage();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            saveImage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reload();
            filter2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            greenbar.Value = 0;
            redbar.Value = 0;
            bluebar.Value = 0;
            reload();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            reload();
            filter3();
        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            
        }

        private void greenbar_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void bluebar_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }
    }
}
