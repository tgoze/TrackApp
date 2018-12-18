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
        List<Models.Run> Runs = new List<Models.Run>();

        public History()
        {
            InitializeComponent();
            BindingContext = new HistoryViewModel();

            picker.ItemsSource = new List<Models.Run>();
        }

        protected override void OnAppearing()
        {
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