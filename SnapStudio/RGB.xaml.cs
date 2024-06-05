using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SnapStudio
{
    /// <summary>
    /// Interaction logic for RGB.xaml
    /// </summary>
    public partial class RGB : UserControl
    {
        private MainWindow myParentWindow;
        private ColorDialog myColorDialog;
        private int originalBitmapCount = new int();
        private Bitmap previewBitmap;

        private float redV;
        private float greenV;
        private float blueV;

        public RGB(MainWindow mPW, ColorDialog cD)
        {
            myParentWindow = mPW;
            myColorDialog = cD;
            InitializeComponent();
            originalBitmapCount = myParentWindow.CurrentBitmap;
        }

        private ColorMatrix createColorMatrix(float rV, float gV, float bV)
        {
            ColorMatrix cMatrix = new ColorMatrix(
                new float[][]
                {
                    new float[] {1, 0, 0, 0, 0},
                    new float[] {0, 1, 0, 0, 0},
                    new float[] {0, 0, 1, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {rV, gV, bV, 0, 1}
                });
            return cMatrix;
        }


        private void setMainBitmap()
        {
            // Create the appropriate matrix
            ColorMatrix cMatrix = createColorMatrix(redV, greenV, blueV);

            // Get the current bitmap to edit
            previewBitmap = myParentWindow.BitmapList[myParentWindow.CurrentBitmap];

            // Apply the matrix to the bitmap
            previewBitmap = myParentWindow.MatrixConvertBitmap(previewBitmap, cMatrix);

            // Display the bitmap in the main window, add it to BitmapList, and increment the counter
            myParentWindow.addPicture(previewBitmap);
        }

        private void setTempBitmap()
        {
            // Create the appropriate matrix
            ColorMatrix cMatrix = createColorMatrix(redV, greenV, blueV);

            // Get the current bitmap to edit
            previewBitmap = myParentWindow.BitmapList[myParentWindow.CurrentBitmap];

            // Apply the matrix to the bitmap
            previewBitmap = myParentWindow.MatrixConvertBitmap(previewBitmap, cMatrix);

            // Display the bitmap temporarily
            myParentWindow.setTempPicture(previewBitmap);
        }

        #region event_handlers

        private void Preview_btn_Click_1(object sender, RoutedEventArgs e)
        {
            setTempBitmap();
        }

        private void Apply_btn_Click_1(object sender, RoutedEventArgs e)
        {
            setMainBitmap();
            myParentWindow.setMainPicture(myParentWindow.CurrentBitmap);
            myColorDialog.Close();
        }

        private void Cancel_btn_Click_1(object sender, RoutedEventArgs e)
        {
            myParentWindow.setMainPicture(originalBitmapCount);
            myColorDialog.Close();
        }

        private void RedSlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            redV = ((float)RedSlider.Value / (float)100);
            RedValue.Content = "" + redV;
        }

        private void BlueSlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            blueV = ((float)BlueSlider.Value / (float)100);
            BlueValue.Content = "" + blueV;
        }

        private void GreenSlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            greenV = ((float)GreenSlider.Value / (float)100);
            GreenValue.Content = "" + greenV;
        }

        #endregion
    }
}
