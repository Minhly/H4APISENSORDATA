using SensorDataCenter.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorDataCenter.Services;
using System.Diagnostics;
using Debug = System.Diagnostics.Debug;


namespace SensorDataCenter.ViewModel
{
    public class SoundViewModel : BaseViewModel
    {
        public ObservableCollection<SoundData> Temperatures { get; } = new();
        public Command PostSoundCommand { get; }

        SoundService soundService;

        string soundText;
        public string SoundText
        {
            get => soundText;
            set
            {
                if (soundText == value)
                    return;
                soundText = value;
                OnPropertyChanged();
            }
        }
        public SoundViewModel(SoundService soundService)
        {
            Title = "Temperature Sensor Center";
            this.soundService = soundService;
            PostSoundCommand = new Command(async () => await PostSoundDataAsync());
        }
        async Task PostSoundDataAsync()
        {
            try
            {
                var postCall = await soundService.PostSound(SoundText);
                SoundText = "";
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "Ok");
            }
        }

    }
}
