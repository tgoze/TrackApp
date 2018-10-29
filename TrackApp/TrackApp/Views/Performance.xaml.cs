using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrackApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Performance : ContentPage
	{
        SfListView listView;
        public Performance ()
		{
            BookInfoRepository viewModel = new BookInfoRepository();
            listView = new SfListView();
            listView.ItemSize = 100;
            listView.ItemsSource = viewModel.BookInfo;
            listView.ItemTemplate = new DataTemplate(() => {
                var grid = new Grid();
                var bookName = new Label { FontAttributes = FontAttributes.Bold, BackgroundColor = Color.Teal, FontSize = 21 };
                bookName.SetBinding(Label.TextProperty, new Binding("BookName"));
                var bookDescription = new Label { BackgroundColor = Color.Teal, FontSize = 15 };
                bookDescription.SetBinding(Label.TextProperty, new Binding("BookDescription"));

                grid.Children.Add(bookName);
                grid.Children.Add(bookDescription, 1, 0);

                return grid;
            });
            //MainPage = new ContentPage { Content = listView };
            InitializeComponent ();
		}
	}
}