﻿#pragma checksum "..\..\..\..\..\View\GuideViews\RequestsFilterWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7642F6C60E2AF03AC2BBF3B02852C0A1D07655D3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using InitialProject.View.GuideViews;
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


namespace InitialProject.View.GuideViews {
    
    
    /// <summary>
    /// RequestsFilterWindow
    /// </summary>
    public partial class RequestsFilterWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\..\..\View\GuideViews\RequestsFilterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Country;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\..\View\GuideViews\RequestsFilterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker LowerDateLimit;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\..\View\GuideViews\RequestsFilterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox City;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\..\View\GuideViews\RequestsFilterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker UpperDateLimit;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\..\View\GuideViews\RequestsFilterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Language;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\..\View\GuideViews\RequestsFilterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GuestsNumber;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/InitialProject;component/view/guideviews/requestsfilterwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\GuideViews\RequestsFilterWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Country = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.LowerDateLimit = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.City = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.UpperDateLimit = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.Language = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.GuestsNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 81 "..\..\..\..\..\View\GuideViews\RequestsFilterWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ApplyFilters);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 86 "..\..\..\..\..\View\GuideViews\RequestsFilterWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ResetInputs);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 91 "..\..\..\..\..\View\GuideViews\RequestsFilterWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
