﻿#pragma checksum "..\..\..\Pages\TakeMedicinePage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6D592840659101026B12B0A4868E43B9E0084467"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Xpf.DXBinding;
using RfEleTagSysApp;
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


namespace RfEleTagSysApp.Pages {
    
    
    /// <summary>
    /// TakeMedicinePage
    /// </summary>
    public partial class TakeMedicinePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Pages\TakeMedicinePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg_medicineList;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Pages\TakeMedicinePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_takeMedicines;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Pages\TakeMedicinePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_lastPage;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Pages\TakeMedicinePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_indexPage;
        
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
            System.Uri resourceLocater = new System.Uri("/RfEleTagSysApp;component/pages/takemedicinepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\TakeMedicinePage.xaml"
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
            
            #line 8 "..\..\..\Pages\TakeMedicinePage.xaml"
            ((RfEleTagSysApp.Pages.TakeMedicinePage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dg_medicineList = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.btn_takeMedicines = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\Pages\TakeMedicinePage.xaml"
            this.btn_takeMedicines.Click += new System.Windows.RoutedEventHandler(this.btn_takeMedicines_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_lastPage = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Pages\TakeMedicinePage.xaml"
            this.btn_lastPage.Click += new System.Windows.RoutedEventHandler(this.btn_lastPage_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_indexPage = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\Pages\TakeMedicinePage.xaml"
            this.btn_indexPage.Click += new System.Windows.RoutedEventHandler(this.btn_indexPage_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
