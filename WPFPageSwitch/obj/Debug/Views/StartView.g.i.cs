﻿#pragma checksum "..\..\..\Views\StartView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2068B55EF00892C42CEAA53943F34B391C0BFEE0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace WPFPageSwitch {
    
    
    /// <summary>
    /// StartView
    /// </summary>
    public partial class StartView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\Views\StartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Views\StartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition imageRow;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Views\StartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image mainImage;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\Views\StartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid importButtonRow;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\Views\StartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button importButton;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Views\StartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button importInfo;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/JagoanFisika;component/views/startview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\StartView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.imageRow = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 3:
            this.mainImage = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            
            #line 70 "..\..\..\Views\StartView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button1_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 71 "..\..\..\Views\StartView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button2_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.importButtonRow = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.importButton = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\Views\StartView.xaml"
            this.importButton.Click += new System.Windows.RoutedEventHandler(this.Button3_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.importInfo = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\..\Views\StartView.xaml"
            this.importInfo.Click += new System.Windows.RoutedEventHandler(this.ImportInfo_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 80 "..\..\..\Views\StartView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button4_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

