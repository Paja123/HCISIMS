﻿#pragma checksum "..\..\..\..\..\View\GuideViews\ComplexTourRequestView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E6DF90D78AE0E9FA42C0135462DA009DBDAEC37A"
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
    /// ComplexTourRequestView
    /// </summary>
    public partial class ComplexTourRequestView : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\..\View\GuideViews\ComplexTourRequestView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainContent;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\View\GuideViews\ComplexTourRequestView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridRequests;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\..\View\GuideViews\ComplexTourRequestView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DimmedOverlay;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\..\View\GuideViews\ComplexTourRequestView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup MyPopover;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\..\View\GuideViews\ComplexTourRequestView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlock;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\..\View\GuideViews\ComplexTourRequestView.xaml"
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
            System.Uri resourceLocater = new System.Uri("/InitialProject;component/view/guideviews/complextourrequestview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\GuideViews\ComplexTourRequestView.xaml"
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
            
            #line 27 "..\..\..\..\..\View\GuideViews\ComplexTourRequestView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.HamburgerButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 33 "..\..\..\..\..\View\GuideViews\ComplexTourRequestView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowPopover);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DataGridRequests = ((System.Windows.Controls.DataGrid)(target));
            
            #line 39 "..\..\..\..\..\View\GuideViews\ComplexTourRequestView.xaml"
            this.DataGridRequests.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGridRequests_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 50 "..\..\..\..\..\View\GuideViews\ComplexTourRequestView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ViewComplexTour);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DimmedOverlay = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\..\..\View\GuideViews\ComplexTourRequestView.xaml"
            this.DimmedOverlay.Click += new System.Windows.RoutedEventHandler(this.DimmedOverlay_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.MyPopover = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 8:
            this.TextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.NavigationMenu = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 10:
            
            #line 97 "..\..\..\..\..\View\GuideViews\ComplexTourRequestView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowTodaysTours);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 98 "..\..\..\..\..\View\GuideViews\ComplexTourRequestView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowActiveTours);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 99 "..\..\..\..\..\View\GuideViews\ComplexTourRequestView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowGuideHistory);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 100 "..\..\..\..\..\View\GuideViews\ComplexTourRequestView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowFirstCreateTourView);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 101 "..\..\..\..\..\View\GuideViews\ComplexTourRequestView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowSuperVodic);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 102 "..\..\..\..\..\View\GuideViews\ComplexTourRequestView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowTourRequests);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 104 "..\..\..\..\..\View\GuideViews\ComplexTourRequestView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowSuperVodic);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 105 "..\..\..\..\..\View\GuideViews\ComplexTourRequestView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SignOut);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 107 "..\..\..\..\..\View\GuideViews\ComplexTourRequestView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowSuperVodic);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 108 "..\..\..\..\..\View\GuideViews\ComplexTourRequestView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.QuitJob);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

