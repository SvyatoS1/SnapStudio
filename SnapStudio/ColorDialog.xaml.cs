using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace SnapStudio
{
    /// <summary>
    /// Interaction logic for ColorDialog.xaml
    /// </summary>
    public partial class ColorDialog : Window
    {
        private MainWindow myParentWindow;
        private String controlType;
        private RGB rgbControl;
        private BSC bscControl;
        private GreyCustom greyControl;
        public ColorDialog(MainWindow parentWindow, String cT)
        {
            myParentWindow = parentWindow;
            controlType = cT;

            InitializeComponent();
            InitControl();
        }

        private void InitControl()
        {
            if (controlType == "RGB")
            {
                CreateRGB();
                this.Width = rgbControl.Width + 26;
                this.Height = rgbControl.Height + 26;
                this.Title = "Red, Green, and Blue Channel Modifier";
            }
            else if (controlType == "BSC")
            {
                CreateColorBSC();
                this.Width = bscControl.Width + 26;
                this.Height = bscControl.Height + 26;
                this.Title = "Brightness, Saturation, and Contrast Modifier";
            }
            else if (controlType == "Grey")
            {
                CreateCustomGrey();
                this.Width = greyControl.Width + 26;
                this.Height = greyControl.Height + 26;
                this.Title = "Custom Grayscale Filter";
            }


        }

        private void CreateRGB()
        {
            rgbControl = new SnapStudio.RGB(myParentWindow, this);
            this.Content = rgbControl;
        }

        private void CreateColorBSC()
        {
            bscControl = new BSC(myParentWindow, this);
            this.Content = bscControl;
        }

        private void CreateCustomGrey()
        {
            greyControl = new GreyCustom(myParentWindow, this);
            this.Content = greyControl;
        }
    }
}
