﻿#pragma checksum "..\..\..\Views\BevWindowView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0B3F4ABF478B22E88CEB9C7E7A7957417BED59BF1BAC08643EBA943FD0A6A253"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Caliburn.Micro;
using Raktar.Views;
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


namespace Raktar.Views {
    
    
    /// <summary>
    /// BevWindowView
    /// </summary>
    public partial class BevWindowView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\Views\BevWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddCikk;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Views\BevWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Number;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Views\BevWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Name;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Views\BevWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Count;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Views\BevWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Unit;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Views\BevWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Price;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Views\BevWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Partnerek;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Views\BevWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Szamlaszam;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Views\BevWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddCikkToGrid;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Views\BevWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Ruhak;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\Views\BevWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\Views\BevWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Close;
        
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
            System.Uri resourceLocater = new System.Uri("/Raktar;component/views/bevwindowview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\BevWindowView.xaml"
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
            
            #line 13 "..\..\..\Views\BevWindowView.xaml"
            ((Raktar.Views.BevWindowView)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AddCikk = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.Number = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Count = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Unit = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Price = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Partnerek = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.Szamlaszam = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.AddCikkToGrid = ((System.Windows.Controls.Button)(target));
            return;
            case 11:
            this.Ruhak = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 12:
            this.Save = ((System.Windows.Controls.Button)(target));
            return;
            case 13:
            this.Close = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

