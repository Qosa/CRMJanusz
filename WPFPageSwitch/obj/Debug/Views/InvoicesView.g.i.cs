﻿#pragma checksum "..\..\..\Views\InvoicesView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6EBC884623245FCDFDF7DFFBA807DC6B8090CA96"
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
using WPFPageSwitch.Views;


namespace WPFPageSwitch.Views {
    
    
    /// <summary>
    /// InvoicesView
    /// </summary>
    public partial class InvoicesView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 2 "..\..\..\Views\InvoicesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WPFPageSwitch.Views.InvoicesView invoicesviewpage;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Views\InvoicesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox timePeriodComboBox;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Views\InvoicesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button printButton;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Views\InvoicesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView transactionsList;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Views\InvoicesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn testowe;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Views\InvoicesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backButton;
        
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
            System.Uri resourceLocater = new System.Uri("/JagoanFisika;component/views/invoicesview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\InvoicesView.xaml"
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
            this.invoicesviewpage = ((WPFPageSwitch.Views.InvoicesView)(target));
            return;
            case 2:
            
            #line 38 "..\..\..\Views\InvoicesView.xaml"
            ((System.Windows.Controls.ComboBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.timeperiodComboBox_Changed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.timePeriodComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 43 "..\..\..\Views\InvoicesView.xaml"
            this.timePeriodComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.timeperiod2ComboBox_Changed);
            
            #line default
            #line hidden
            return;
            case 4:
            this.printButton = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\Views\InvoicesView.xaml"
            this.printButton.Click += new System.Windows.RoutedEventHandler(this.Print_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.transactionsList = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.testowe = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 9:
            this.backButton = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\Views\InvoicesView.xaml"
            this.backButton.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 7:
            
            #line 60 "..\..\..\Views\InvoicesView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Show_Contract_Click);
            
            #line default
            #line hidden
            break;
            case 8:
            
            #line 61 "..\..\..\Views\InvoicesView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete_Contract_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
