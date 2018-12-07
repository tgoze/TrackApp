using System;
using TrackApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Syncfusion.XForms.PopupLayout; 

namespace TrackApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GroupRun : ContentPage
    {
        DataTemplate contentTemplateView;
        Label popupContent;
        public GroupRun()
        {
            InitializeComponent();

            contentTemplateView = new DataTemplate(() =>
            {
                popupContent = new Label();
                popupContent.Text = "Window loads under the parent window surrounded by an overlay which prevents clicking anywhere else on the screen apart from the control of the modal. Modal opens in the same window. It also does not require any user action to open, and give callbacks when closing or opening the modal.";
                popupContent.WidthRequest = 260;
                popupContent.BackgroundColor = Color.White;
                popupContent.HorizontalOptions = LayoutOptions.FillAndExpand;
                return popupContent;
            });

            popUpLayout.PopupView.HeightRequest = 230;
            popUpLayout.PopupView.HeaderTitle = "Modal Window";
            popUpLayout.PopupView.ContentTemplate = contentTemplateView;
            popUpLayout.PopupView.ShowFooter = false;

            clickToShowPopup.Clicked += ClickToShowPopup_Clicked;

            BindingContext = new RunViewModel();
        }

        private void ClickToShowPopup_Clicked(object sender, EventArgs e)
        {
            // Below code ensures that the popup doesn't collapse when user interacts outside the popup.
            popUpLayout.StaysOpen = true;
            popUpLayout.PopupView.ShowCloseButton = true;
            popUpLayout.IsOpen = true;
        }
    }

}