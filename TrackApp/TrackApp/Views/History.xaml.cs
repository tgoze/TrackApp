using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TrackApp.ViewModels;

namespace TrackApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class History : ContentPage
	{
        public History()
        {
            InitializeComponent();
            BindingContext = new HistoryViewModel();
        }

        protected override void OnAppearing()
        {
            //Results.ItemsSource = new List<Models.Run>()
            //{
            //    new Models.Run() { RunnerNumber = 1, Splits = new List<string>() { "12", "34" }, TotalTime = "4:26" }
            //    , new Models.Run() { RunnerNumber = 2, Splits = new List<string>() { "56", "78" }, TotalTime = "8:49" }
            //    , new Models.Run() { RunnerNumber = 3, Splits = new List<string>() { "90", "00" }, TotalTime = "1:20" }
            //};
            //picker.ItemsSource = new List<String>()
            //{
            //    "Testing1", "Testing2", "Testing3"
            //};            
        }

        public void SetRuns(List<Run> runs)
        {
            //HistoryLv.ItemsSource = runs;
        }

        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem; // This is the model selected in the picker
            //Display.Text = "Test";
        }

    }
}