﻿#pragma checksum "..\..\..\RGB.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0A2C584CA78EF990DBFE4BA3242999135B534522"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SnapStudio;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SnapStudio {
    
    
    /// <summary>
    /// RGB
    /// </summary>
    public partial class RGB : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\RGB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider RedSlider;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\RGB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label RedLabel;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\RGB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label RedValue;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\RGB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider BlueSlider;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\RGB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label BlueLabel;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\RGB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label BlueValue;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\RGB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider GreenSlider;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\RGB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label GreenLabel;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\RGB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label GreenValue;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\RGB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Preview_btn;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\RGB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Apply_btn;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\RGB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancel_btn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SnapStudio;component/rgb.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\RGB.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.RedSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 9 "..\..\..\RGB.xaml"
            this.RedSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.RedSlider_ValueChanged_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RedLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.RedValue = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.BlueSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 13 "..\..\..\RGB.xaml"
            this.BlueSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.BlueSlider_ValueChanged_1);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BlueLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.BlueValue = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.GreenSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 17 "..\..\..\RGB.xaml"
            this.GreenSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.GreenSlider_ValueChanged_1);
            
            #line default
            #line hidden
            return;
            case 8:
            this.GreenLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.GreenValue = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.Preview_btn = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\RGB.xaml"
            this.Preview_btn.Click += new System.Windows.RoutedEventHandler(this.Preview_btn_Click_1);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Apply_btn = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\RGB.xaml"
            this.Apply_btn.Click += new System.Windows.RoutedEventHandler(this.Apply_btn_Click_1);
            
            #line default
            #line hidden
            return;
            case 12:
            this.Cancel_btn = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\RGB.xaml"
            this.Cancel_btn.Click += new System.Windows.RoutedEventHandler(this.Cancel_btn_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

