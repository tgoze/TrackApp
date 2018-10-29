using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace TrackApp.ViewModels
{
    public class IndexToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var listviewX = parameter as SfListView;
            var index = listviewX.DataSource.DisplayItems.IndexOf(value);

            if (index % 2 == 0)
                return Color.White;
            return Color.FromHex("#d8dbe2");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
