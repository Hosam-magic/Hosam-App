using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosam_App.FrontEnd.Game
{
    class GameViewModel: INotifyPropertyChanged
    {
        bool _isPlayingVisible;
        string _playGameName;

        public bool IsPlayingVisible
        {
            get { return _isPlayingVisible; }
            set { _isPlayingVisible = value; NotifyPropertyChanged("IsPlayingVisible"); }
        }
        public string PlayGameName
        {
            get { return _playGameName; }
            set { _playGameName = value; NotifyPropertyChanged("PlayGameName"); }
        }

        public void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
