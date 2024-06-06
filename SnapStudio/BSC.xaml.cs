﻿using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
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
    public partial class BSC : UserControl
    {
        private MainWindow myParentWindow;
        private ColorDialog myColorDialog;
        private int originalBitmapCount = new int();
        private Bitmap previewBitmap;

        private float brightV = 0f;
        private float satV = 1f;
        private float conV = 1f;

        public BSC(MainWindow mPW, ColorDialog cD)
        {
            myParentWindow = mPW;
            myColorDialog = cD;
            InitializeComponent();
            originalBitmapCount = myParentWindow.CurrentBitmap;

            CSlider.Value = 100;
        }

        private ColorMatrix createTransformMatrix(float bV, float sV, float cV)
        {
            float lumR, lumG, lumB, sR, sG, sB, tV;

            if (HighRed.IsChecked == true)
            {
                lumR = 0.3086f;
            }
            else
            {
                lumR = 0.2125f;
            }

            if (HighGreen.IsChecked == true)
            {
                lumG = 0.7154f;
            }
            else
            {
                lumG = 0.6094f;
            }

            if (HighBlue.IsChecked == true)
            {
                lumB = 0.0820f;
            }
            else
            {
                lumB = 0.0721f;
            }

            sR = (1 - sV) * lumR;
            sG = (1 - sV) * lumG;
            sB = (1 - sV) * lumB;
            tV = (float)((1.0 - cV) / 2.0);

            ColorMatrix sMatrix = new ColorMatrix(
                new float[][]
                {
            new float[] { cV*(sR+sV),  cV*(sR),    cV*(sR),    0, 0},
            new float[] {  cV*(sG),   cV*(sG+sV),  cV*(sG),    0, 0},
            new float[] {  cV*(sB),     cV*(sB),  cV*(sB+sV),  0, 0},
            new float[] {      0,          0,          0,      1, 0},
            new float[] {    bV+tV,      bV+tV,      bV+tV,    0, 1}
                });
            return sMatrix;
        }

        private void setMainBitmap()
        {
            // Create the appropriate matrix
            ColorMatrix cMatrix = createTransformMatrix(brightV, satV, conV);

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
            ColorMatrix cMatrix = createTransformMatrix(brightV, satV, conV);

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

        private void BrightSlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            brightV = ((float)BrightSlider.Value / (float)100);
            BrightValue.Content = "" + brightV;
        }

        private void CSlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            conV = ((float)CSlider.Value / (float)100);
            CValue.Content = "" + conV;
        }

        private void SatSlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            satV = ((float)SatSlider.Value / (float)100);
            SatValue.Content = "" + satV;
        }

        #endregion
    }
}
