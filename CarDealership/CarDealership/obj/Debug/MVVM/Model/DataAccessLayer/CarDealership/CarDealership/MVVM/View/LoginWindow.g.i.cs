﻿#pragma checksum "..\..\..\..\..\..\..\..\..\MVVM\Model\DataAccessLayer\CarDealership\CarDealership\MVVM\View\LoginWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AE7E9D0EFBD0F9AB8D9A220B4490C59E613BAA311D6B22D622E331E272E75CFE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CarDealership.MVVM.View;
using CarDealership.MVVM.ViewModel;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace CarDealership {
    
    
    /// <summary>
    /// LoginWindow
    /// </summary>
    public partial class LoginWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\..\..\..\..\..\MVVM\Model\DataAccessLayer\CarDealership\CarDealership\MVVM\View\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CarDealership.LoginWindow login;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\..\..\..\..\..\MVVM\Model\DataAccessLayer\CarDealership\CarDealership\MVVM\View\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtemail;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\..\..\..\..\..\MVVM\Model\DataAccessLayer\CarDealership\CarDealership\MVVM\View\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtpassword;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\..\..\..\..\..\MVVM\Model\DataAccessLayer\CarDealership\CarDealership\MVVM\View\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogin;
        
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
            System.Uri resourceLocater = new System.Uri("/CarDealership;component/mvvm/model/dataaccesslayer/cardealership/cardealership/m" +
                    "vvm/view/loginwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\..\..\MVVM\Model\DataAccessLayer\CarDealership\CarDealership\MVVM\View\LoginWindow.xaml"
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
            this.login = ((CarDealership.LoginWindow)(target));
            return;
            case 2:
            this.txtemail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtpassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.btnLogin = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

