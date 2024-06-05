﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media.Imaging;


namespace SnapStudio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Bitmap currentPicture;
        private List<Bitmap> bitmapList = new List<Bitmap>();
        private int currentBitmap = 0;
        private ColorMatrix greyscaleConMatrix = new ColorMatrix(
            new float[][]
            {
        new float[] {.22f,.22f,.22f, 0, 0},
        new float[] {.59f,.59f,.59f, 0, 0},
        new float[] {.11f,.11f,.11f, 0, 0},
        new float[] {  0,   0,   0,  1, 0},
        new float[] {  0,   0,   0,  0, 1}
            });

        private ColorMatrix invertConMatrix = new ColorMatrix(
           new float[][]
            {
        new float[] { -1,   0,   0,  0,  1},
        new float[] {  0,  -1,   0,  0,  1},
        new float[] {  0,   0,  -1,  0,  1},
        new float[] {  0,   0,   0,  1,  0},
        new float[] {  1,   1,   1,  0,  1}
            });

        public MainWindow()
        {
            InitializeComponent();
        }

        public void addPicture(Bitmap aBitmap)
        {
            bitmapList.Add(aBitmap);
            mainImage.Source = BitmapToBitmapSource(aBitmap);
            currentBitmap = bitmapList.Count - 1;

            Console.WriteLine(currentBitmap);
            Console.WriteLine(bitmapList.Count);
        }

        public void undoPicture()
        {
            if (currentBitmap > 0)
            {
                currentBitmap--;
                setMainPicture(currentBitmap);
            }
        }

        public void redoPicture()
        {
            if (currentBitmap < bitmapList.Count - 1)
            {
                currentBitmap++;
                setMainPicture(currentBitmap);
            }
        }

        /// <summary>
        /// This changes the main image to a bitmap from the array of bitmaps
        /// Bitmap class for manipulation needs to be converted to bitmap source
        /// to be displayed by WPF
        /// </summary>
        /// <param name="currentState"></param>
        public void setMainPicture(int currentState)
        {
            mainImage.Source = BitmapToBitmapSource(bitmapList[currentState]);
            currentBitmap = currentState;
        }

        /// <summary>
        /// For non permanent changes to the main image and aren't added to the state
        /// </summary>
        /// <param name="aBitmap"></param>
        public void setTempPicture(Bitmap aBitmap)
        {
            mainImage.Source = BitmapToBitmapSource(aBitmap);
        }

        /// <summary>
        /// Applies a color matrix to the pixels of a bitmap
        /// </summary>
        /// <param name="original">Bitmap to be converted</param>
        /// <param name="cM">ColorMatrix which does the changing</param>
        /// <returns>Converted Bitmap</returns>
        public Bitmap MatrixConvertBitmap(Bitmap original, ColorMatrix cM)
        {
            Bitmap aBitmap = new Bitmap(original.Width, original.Height);
            Graphics g = Graphics.FromImage(aBitmap);

            ColorMatrix colorMatrix = cM;

            // Set an image attribute to our color matrix so that we can apply it to a bitmap
            ImageAttributes attr = new ImageAttributes();
            attr.SetColorMatrix(colorMatrix);

            //Uses graphics class to redraw the bitmap with our Color matrix applied
            g.DrawImage(original,                                                                   // Bitmap
                            new System.Drawing.Rectangle(0, 0, original.Width, original.Height),    // Contains the image
                            0,                                                                      // x, y, width, and height
                            0,
                            original.Width,
                            original.Height,
                            GraphicsUnit.Pixel,                                     // Unit of measure
                            attr);                                                  // Our ColorMatrix being applied
            g.Dispose();

            return aBitmap;
        }

        /// <summary>
        /// Bitmap -> BitmapSource
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static BitmapSource BitmapToBitmapSource(Bitmap source)
        {
            BitmapSource bitSrc = null;
            var hBitmap = source.GetHbitmap();

            try
            {
                bitSrc = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            }
            catch (Win32Exception)
            {
                bitSrc = null;
            }
            finally
            {
                NativeMethods.DeleteObject(hBitmap);
            }
            return bitSrc;
        }

        internal static class NativeMethods
        {
            [DllImport("gdi32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool DeleteObject(IntPtr hObject);
        }



        #region event_handlers

        private void open_FileDialog(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);
            openFileDialog.Filter = "JPEG Compressed Image (*.jpg)|*.jpg|GIF Image(*.gif)|*.gif|Bitmap Image(*.bmp)|*.bmp|PNG Image (*.png)|*.png";
            openFileDialog.FilterIndex = 1;

            Nullable<bool> result = openFileDialog.ShowDialog();

            if (result == true)
            {
                currentPicture = new Bitmap(openFileDialog.FileName);

                addPicture(currentPicture);
                this.Title = openFileDialog.FileName;
            }
        }

        private void Save_item_Click_1(object sender, EventArgs e)
        {
            
        }

        private void RGB_item_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void BSC_item_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void Grey_item_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void Custom_item_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void Op_grey_item_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void Invert_item_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void Undo_item_Click_1(object sender, RoutedEventArgs e)
        {
            undoPicture();
        }

        private void Redo_item_Click_1(object sender, RoutedEventArgs e)
        {
            redoPicture();
        }

        /// <summary>
        /// Sets the picture window to the first state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Discard_item_Click_1(object sender, RoutedEventArgs e)
        {
            setMainPicture(0);
        }

        /// <summary>
        /// Quits the program cleanly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Quit_item_Click_1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        #endregion



        #region field_getters_setters

        public List<Bitmap> BitmapList
        {
            get { return bitmapList; }
            set { bitmapList = value; }
        }

        public int CurrentBitmap
        {
            get { return currentBitmap; }
            set { currentBitmap = value; }
        }
        #endregion
    }
}
