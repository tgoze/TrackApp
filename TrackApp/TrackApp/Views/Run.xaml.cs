using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TrackApp.ViewModels;

namespace TrackApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Run : ContentPage
	{                      
        public Run()
		{
            InitializeComponent();
            BindingContext = new RunViewModel();
            NewRunBtn.Clicked += ShowPopup;
            StartNewRunBtn.Clicked += StartRun;
            CancelNewRunBtn.Clicked += HidePopup;
        }
           
        private void ShowPopup(object sender, EventArgs e)
        {          
            NewRunPopup.IsVisible = true;            
        }

        private void HidePopup(object sender, EventArgs e)
        {
            NewRunPopup.IsVisible = false;
        }
        
        private void StartRun(object sender, EventArgs e)
        {
            NewRunPopup.IsVisible = false;
            StartNewRunBtn.Text = "Stop";
        }
    }
}