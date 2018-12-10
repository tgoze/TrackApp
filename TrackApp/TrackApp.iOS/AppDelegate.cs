using System;
using System.Collections.Generic;
using System.Linq;

using Syncfusion.SfPicker.XForms.iOS;
using Syncfusion.XForms.iOS.ProgressBar;
using Syncfusion.XForms.iOS.Buttons;
using Syncfusion.XForms.iOS.ComboBox;
using Syncfusion.XForms.iOS.DataForm;
using Syncfusion.XForms.iOS.MaskedEdit;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.XForms.iOS.TextInputLayout;
using Syncfusion.SfNumericTextBox.XForms.iOS;
using Syncfusion.SfNumericUpDown.XForms.iOS;

using Foundation;
using UIKit;

namespace TrackApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            global::Xamarin.Forms.Forms.Init();
            SfPickerRenderer.Init();
            SfCheckBoxRenderer.Init();
            SfComboBoxRenderer.Init();
            SfDataFormRenderer.Init();
            SfMaskedEditRenderer.Init();
            SfCircularProgressBarRenderer.Init();
            SfListViewRenderer.Init();
            SfTextInputLayoutRenderer.Init();
            SfNumericTextBoxRenderer.Init();
            new SfNumericUpDownRenderer();
            LoadApplication(new App());
            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
