using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TrackApp.ViewModels;
using System.Text;

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
        private ArrayList splitsList = new ArrayList();
        private List<Models.Run> runs = new List<Models.Run>()
        {
             new Models.Run() { RunnerNumber = 1, StrSplits = new List<string>() { "12", "34","34","34","34","66","77","88","99","134" }, StrTotalTime = "4:26" }
                , new Models.Run() { RunnerNumber = 2, StrSplits = new List<string>() { "56", "78" }, StrTotalTime = "8:49" }
                , new Models.Run() { RunnerNumber = 3, StrSplits = new List<string>() { "90", "00" }, StrTotalTime = "1:20" }
        };

        protected override void OnAppearing()
        {
            Results.ItemsSource = runs;
            //createList(runs);
            //picker.ItemsSource = new List<String>()
            //{
            //    "Testing1", "Testing2", "Testing3"
            //};            
        }

        private void createList(List<Models.Run> pRuns)
        {
            StringBuilder sb = new StringBuilder();
            foreach(Models.Run run in pRuns)
            {
                foreach(string split in run.StrSplits)
                {
                    //Console.WriteLine(split);
                   // Test.Text = split;
                    
                }
                
                //sb.Append(string.Format("Split: {0} | Value: {1}", properties.Name, properties.GetValue(run, null)));                                    
            }
        }

        private void UpdateBtn_Clicked(object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("1"))
            {
                var jsonData = Application.Current.Properties["1"] as string;
                Models.Run run = JsonConvert.DeserializeObject<Models.Run>(jsonData);
            }
        }

    }
}