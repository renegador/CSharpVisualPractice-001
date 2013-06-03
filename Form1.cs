using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpVisualPractice_001
{
    public partial class myWindow : Form
    {
        Bitmap myBitmap;
        
        public myWindow()
        {
            InitializeComponent();
        }

        private void myWindow_Load(object sender, EventArgs e)
        {

        }

        private void onExit(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            MenuItem item = menu.MenuItems.Add("&Options");
            item.MenuItems.Add(new MenuItem("&Open...", new EventHandler(OnOpenImage), Shortcut.CtrlO));
            item.MenuItems.Add("-----");
            item.MenuItems.Add(new MenuItem("E&xit", new EventHandler(onExit)));

            // Attach the menu to the form
            Menu = menu;
        }

        private void OnOpenImage(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = "C:\\Users\\Shane\\Libraries\\Documents";
            ofd.Filter = "Image Files (JPEG, GIF, BMP, etc.)|" +
                "*.jpg;*.jpeg;*.gif;*.bmp;*.tif;*.tiff;*.png|" +
                "JPEG files (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "GIF Files (*.gif)|*.gif|" +
                "BMP Files (*.bmp)|*.bmp|" +
                "TIFF Files (*.tif;*.tiff)|*.tif;*.tiff|" +
                "PNG Files (*.png)|*.png|" +
                "All files (*.*)|*.*";
            ofd.FilterIndex = 1;
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String fileName = ofd.FileName;
                if (fileName.Length != 0)
                {
                    try
                    {
                        myBitmap = new Bitmap(fileName);
                        Text = "Image Viewer - " + fileName;
                        Invalidate();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
                if (myBitmap != null)
                {
                    Graphics g = e.Graphics;

                    ClientSize = new Size(myBitmap.Width + 10, myBitmap.Height + 10);

                    g.DrawImage(myBitmap, 0, 0,
                        myBitmap.Width, myBitmap.Height);
                }
        }
    }
}
