using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EggMobileApp.ViewModel
{
    public class EggPageViewModel : INotifyPropertyChanged
    {
        private string _duration;

        public EggPageViewModel()
        {
            StartTimerCommand = new Command(OnStartTimerExecute);
            StartTime = TimeSpan.FromSeconds(0);
            Duration = StartTime.ToString();
        }

        private void OnStartTimerExecute()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), (() =>
            {
                if (StartTime.TotalSeconds > 0)
                {
                    StartTime = StartTime - TimeSpan.FromSeconds(1);
                    Duration = StartTime.ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }));
        }

        
        public ICommand StartTimerCommand { get; set; }

        public TimeSpan StartTime { get; set; }

        public string Duration
        {
            get { return _duration; }
            set 
            {
                _duration = value;
                OnPropertyChanged();
            }
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
