﻿#pragma checksum "..\..\..\UI\appointment.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F2E75536D89C742FC32BFC37636E3E204694731980542D99BEBBDDBC07752950"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PhoneBook.MyControl;
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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace PhoneBook.UI {
    
    
    /// <summary>
    /// appointment
    /// </summary>
    public partial class appointment : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\UI\appointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid newAppointment;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\UI\appointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox appointmentwith;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\UI\appointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox titletxt;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\UI\appointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DateTimePicker datePicker;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\UI\appointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox detailstxt;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\UI\appointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnsave;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\UI\appointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btncancel;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\UI\appointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Warning;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\UI\appointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid appoinmentList;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\UI\appointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PhoneBook.MyControl.AppointmentListControl AppointmentList;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\UI\appointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNewAppointment;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\UI\appointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid AppointmentDetails;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\UI\appointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label appointmentTitle;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\UI\appointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock appointmentWith;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\UI\appointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock time;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\..\UI\appointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox details;
        
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
            System.Uri resourceLocater = new System.Uri("/PhoneBook;component/ui/appointment.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\appointment.xaml"
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
            
            #line 9 "..\..\..\UI\appointment.xaml"
            ((PhoneBook.UI.appointment)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.newAppointment = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.appointmentwith = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.titletxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.datePicker = ((Xceed.Wpf.Toolkit.DateTimePicker)(target));
            return;
            case 6:
            this.detailstxt = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 7:
            this.btnsave = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\UI\appointment.xaml"
            this.btnsave.Click += new System.Windows.RoutedEventHandler(this.btnsave_Click);
            
            #line default
            #line hidden
            
            #line 62 "..\..\..\UI\appointment.xaml"
            this.btnsave.MouseEnter += new System.Windows.Input.MouseEventHandler(this.btnsave_MouseEnter);
            
            #line default
            #line hidden
            
            #line 62 "..\..\..\UI\appointment.xaml"
            this.btnsave.MouseLeave += new System.Windows.Input.MouseEventHandler(this.btnsave_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btncancel = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\UI\appointment.xaml"
            this.btncancel.MouseEnter += new System.Windows.Input.MouseEventHandler(this.btncancel_MouseEnter);
            
            #line default
            #line hidden
            
            #line 69 "..\..\..\UI\appointment.xaml"
            this.btncancel.MouseLeave += new System.Windows.Input.MouseEventHandler(this.btncancel_MouseLeave);
            
            #line default
            #line hidden
            
            #line 69 "..\..\..\UI\appointment.xaml"
            this.btncancel.Click += new System.Windows.RoutedEventHandler(this.btncancel_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Warning = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.appoinmentList = ((System.Windows.Controls.Grid)(target));
            return;
            case 11:
            this.AppointmentList = ((PhoneBook.MyControl.AppointmentListControl)(target));
            return;
            case 12:
            this.btnNewAppointment = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\..\UI\appointment.xaml"
            this.btnNewAppointment.MouseEnter += new System.Windows.Input.MouseEventHandler(this.btnNewAppointment_MouseEnter);
            
            #line default
            #line hidden
            
            #line 97 "..\..\..\UI\appointment.xaml"
            this.btnNewAppointment.MouseLeave += new System.Windows.Input.MouseEventHandler(this.btnNewAppointment_MouseLeave);
            
            #line default
            #line hidden
            
            #line 97 "..\..\..\UI\appointment.xaml"
            this.btnNewAppointment.Click += new System.Windows.RoutedEventHandler(this.btnNewAppointment_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.AppointmentDetails = ((System.Windows.Controls.Grid)(target));
            return;
            case 14:
            this.appointmentTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 15:
            this.appointmentWith = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 16:
            this.time = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 17:
            this.details = ((System.Windows.Controls.RichTextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

