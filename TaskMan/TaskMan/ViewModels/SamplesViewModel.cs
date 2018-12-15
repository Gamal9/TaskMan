using MVVM_Task.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TaskMan.Models;

namespace TaskMan.ViewModels
{
    public class SamplesViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Sample> _sample;
        public ObservableCollection<Sample> Samples
        {
            get
            {
                return _sample;
            }
            set
            {
                _sample = value;
                OnPropertyChanged();
            }
        }


        
        public SamplesViewModel()
        {
            IntializaDataAsync();
        }

        private async Task IntializaDataAsync()
        {
            SampleServices _service = new SampleServices();
            Samples = await _service.GetAll();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
