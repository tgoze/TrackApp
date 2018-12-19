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
    }
}