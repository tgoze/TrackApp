﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrackApp

{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class User : ContentPage
    {
        public User()
        {
            InitializeComponent();
            BindingContext = new ViewModels.UserViewModel(Navigation);
        }
    }
}