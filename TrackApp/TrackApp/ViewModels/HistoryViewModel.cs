using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace TrackApp.ViewModels
{
    public class HistoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Command UpdateDataCommand { get; }

        public List<Models.Run> _Runs = new List<Models.Run>();
        public List<Models.Run> Runs
        {
            set
            {
                _Runs = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Runs"));
            }
            get
            {
                return _Runs;
            }
        }

        public HistoryViewModel()
        {
            UpdateDataCommand = new Command(UpdateData);
        }

        // Pulls the saved splits from the local storage
        private void UpdateData()
        {
            int numberOfRunners = 0;
            List<Models.Run> runs = new List<Models.Run>();
            if (Application.Current.Properties.ContainsKey("NumberOfRunners"))
            {
                    numberOfRunners = (int) Application.Current.Properties["NumberOfRunners"];

                for (int i = 1; i <= numberOfRunners; i++)
                {
                    if (Application.Current.Properties.ContainsKey(i.ToString()))
                    {
                        var jsonData = Application.Current.Properties[i.ToString()] as string;
                        Models.Run run = JsonConvert.DeserializeObject<Models.Run>(jsonData);
                        runs.Add(run);
                    }
                }
                Runs = runs;
            }

        }
    }
}