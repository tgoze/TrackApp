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
            ResetRunBtn.Clicked += ResetRun;
            TimeLabel.FontSize += 32;
            progressBar.Minimum = 0;
            
            
        }
           
        private void ShowPopup(object sender, EventArgs e)
        {       
            
            if ("Stop".Equals(NewRunBtn.Text))
            {
                NewRunBtn.Text = "Start";
                //NewRunBtn.SetBinding(Button.CommandProperty, "StartRunCommand");
                ResetRunBtn.IsVisible = true;

            } else
            {
                NewRunPopup.IsVisible = true;
                NewRunBtn.SetBinding(Button.CommandProperty, "StopRunCommand");
               



            }
                     
        }

        private void HidePopup(object sender, EventArgs e)
        {
            NewRunPopup.IsVisible = false;
        }

        private void ResetRun(object sender, EventArgs e)
        {
            ResetRunBtn.IsVisible = false;
        }

        private void StartRun(object sender, EventArgs e)
        {
            NewRunPopup.IsVisible = false;
            NewRunBtn.Text = "Stop";
            GoalTimeInput.Value = "";
            RunDistanceInput.Value = "";
            SplitDistanceInput.Value = "";
        }
    }
}