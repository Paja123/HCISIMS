﻿#pragma checksum "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D28E9034DCF055E9132A206A962178BF1457A768"
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
    /// ActiveToursView
    /// </summary>
    public partial class ActiveToursView : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainContent;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridTours;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DimmedOverlay;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup MyPopover1;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlock1;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup MyPopover2;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlock2;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
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
            System.Uri resourceLocater = new System.Uri("/InitialProject;component/view/guideviews/activetoursview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
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
            
            #line 26 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.HamburgerButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 35 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowPopover);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DataGridTours = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            
            #line 55 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelTour);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 60 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowPopover2);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 65 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PregledajTuru);
            
            #line default
            #line hidden
            return;
            case 8:
            this.DimmedOverlay = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
            this.DimmedOverlay.Click += new System.Windows.RoutedEventHandler(this.DimmedOverlay_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.MyPopover1 = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 10:
            this.TextBlock1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.MyPopover2 = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 12:
            this.TextBlock2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 13:
            this.NavigationMenu = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 14:
            
            #line 120 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowTodaysTours);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 122 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowGuideHistory);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 123 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowFirstCreateTourView);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 124 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowSuperVodic);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 125 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowTourRequests);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 127 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowSuperVodic);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 128 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SignOut);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 130 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowSuperVodic);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 131 "..\..\..\..\..\View\GuideViews\ActiveToursView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.QuitJob);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

