using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrackApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Run : ContentPage
	{
		public Run ()
		{
            InitializeComponent ();
		}

        private void BeepButton_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IBeep>().playBeep();
        }
    }
}