using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TrackApp.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        // Indicates that the ViewModel is busy
        public bool IsBusy { get; protected set; }
    }
}
