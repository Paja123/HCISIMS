﻿#pragma checksum "..\..\..\..\..\View\GuideViews\TodayTours.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "509E5343106F80A78BE7451AF9959A1B357EC99F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.WPF;
using FontAwesome.WPF.Converters;
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
    /// TodayTours
    /// </summary>
    public partial class TodayTours : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\..\View\GuideViews\TodayTours.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainContent;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\View\GuideViews\TodayTours.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridTours;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\..\View\GuideViews\TodayTours.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DimmedOverlay;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\..\View\GuideViews\TodayTours.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup MyPopover;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\..\View\GuideViews\TodayTours.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlock;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\..\View\GuideViews\TodayTours.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel NavigationMenu;
        
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
            System.Uri resourceLocater = new System.Uri("/InitialProject;component/view/guideviews/todaytours.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\GuideViews\TodayTours.xaml"
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
            this.MainContent = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            
            #line 26 "..\..\..\..\..\View\GuideViews\TodayTours.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.HamburgerButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 32 "..\..\..\..\..\View\GuideViews\TodayTours.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowPopover);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DataGridTours = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            
            #line 52 "..\..\..\..\..\View\GuideViews\TodayTours.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 56 "..\..\..\..\..\View\GuideViews\TodayTours.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DimmedOverlay = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\..\..\View\GuideViews\TodayTours.xaml"
            this.DimmedOverlay.Click += new System.Windows.RoutedEventHandler(this.DimmedOverlay_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.MyPopover = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 9:
            this.TextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.NavigationMenu = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 11:
            
            #line 104 "..\..\..\..\..\View\GuideViews\TodayTours.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowActiveTours);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 105 "..\..\..\..\..\View\GuideViews\TodayTours.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowGuideHistory);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 106 "..\..\..\..\..\View\GuideViews\TodayTours.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowFirstCreateTourView);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 107 "..\..\..\..\..\View\GuideViews\TodayTours.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowSuperVodic);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 108 "..\..\..\..\..\View\GuideViews\TodayTours.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowTourRequests);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 110 "..\..\..\..\..\View\GuideViews\TodayTours.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowSuperVodic);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 111 "..\..\..\..\..\View\GuideViews\TodayTours.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SignOut);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 113 "..\..\..\..\..\View\GuideViews\TodayTours.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowSuperVodic);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 114 "..\..\..\..\..\View\GuideViews\TodayTours.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.QuitJob);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
