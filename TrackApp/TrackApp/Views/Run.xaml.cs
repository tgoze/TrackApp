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
            TimeLabel.FontSize += 28;
            progressBar.Minimum = 0;
            SplitField.FontSize += 12;
            
            
        }
           
        private void ShowPopup(object sender, EventArgs e)
        {       
            
            if ("Stop".Equals(NewRunBtn.Text))
            {
                NewRunBtn.Text = "Continue";
                NewRunBtn.SetBinding(Button.CommandProperty, "ContinueRunCommand");
                ResetRunBtn.Text = "Reset";
                ResetRunBtn.SetBinding(Button.CommandProperty, "ResetRunCommand");

               // ResetRunBtn.IsVisible = true;

            } else if ("Continue".Equals(NewRunBtn.Text))
            {
                NewRunBtn.Text = "Stop";
                NewRunBtn.SetBinding(Button.CommandProperty, "StopRunCommand");
                ResetRunBtn.Text = "Split";
                ResetRunBtn.SetBinding(Button.CommandProperty, "ResetRunCommand");

            } else
            {
                NewRunPopup.IsVisible = true;
                NewRunBtn.SetBinding(Button.CommandProperty, "StopRunCommand");
                ResetRunBtn.IsEnabled = true;
            }
                     
        }

        private void HidePopup(object sender, EventArgs e)
        {
            NewRunPopup.IsVisible = false;
        }

        private void ResetRun(object sender, EventArgs e)
        {
            NewRunBtn.Text = "Start";
            
            if(ResetRunBtn.Text.Equals("Reset"))
            {
                NewRunBtn.Text = "Start";
                ResetRunBtn.IsEnabled = false;
            } else
            {

            }
            //ResetRunBtn.IsVisible = false;
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