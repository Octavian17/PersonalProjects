﻿#pragma checksum "..\..\Cautare.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "81C35FE78307868C206D6A11654012FC19089194EF71C2CE62A028A930F07D86"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Dictionar;
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


namespace Dictionar {
    
    
    /// <summary>
    /// Cautare
    /// </summary>
    public partial class Cautare : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\Cautare.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SelectCat;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Cautare.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox autoTextBox;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Cautare.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup autoListPopup;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\Cautare.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox autoList;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\Cautare.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock cuv;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\Cautare.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock cat;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\Cautare.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock desc;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\Cautare.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Img;
        
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
            System.Uri resourceLocater = new System.Uri("/Dictionar;component/cautare.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Cautare.xaml"
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
            this.SelectCat = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            
            #line 21 "..\..\Cautare.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.autoTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\Cautare.xaml"
            this.autoTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.AutoTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 38 "..\..\Cautare.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cauta);
            
            #line default
            #line hidden
            return;
            case 5:
            this.autoListPopup = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 6:
            this.autoList = ((System.Windows.Controls.ListBox)(target));
            
            #line 51 "..\..\Cautare.xaml"
            this.autoList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.AutoList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cuv = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.cat = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.desc = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.Img = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

