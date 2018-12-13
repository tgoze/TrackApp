using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrackApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class History : ContentPage
	{
		public History()
		{
			InitializeComponent();
            picker.ItemsSource = new List<Models.Run>();
		}

        protected override void OnAppearing()
        {
            picker.ItemsSource = new List<Models.Run>()
            {
                new Models.Run() { RunnerNumber = 0, Splits = new List<string>() { "12", "34" }, TotalTime = "test" }
                , new Models.Run() { RunnerNumber = 1, Splits = new List<string>() { "56", "78" }, TotalTime = "test1" }
                , new Models.Run() { RunnerNumber = 2, Splits = new List<string>() { "90", "00" }, TotalTime = "test2" }
            };
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
            Display.Text = "Test";
        }

    }
}