using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TrackApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async Task Button_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
    }
   
}
