
using System.Collections.Generic;
using System.ComponentModel;
using Hosam_App.Logic.Entity;

namespace Hosam_App.FrontEnd.Game
{
    class GameModel : INotifyPropertyChanged
    {
        int _farvoriteSort;
        int _gameSort;
        List<GameData> _farvoriteList;
        List<GameData> _gameList;

        string _runningGameName;
        bool _isPlaying;

        public List<GameData> FarvoriteList
        {
            get { return _farvoriteList; }
            set { _farvoriteList = value; NotifyPropertyChanged("FarvoriteList"); }
        }

        public List<GameData> GameList
        {
            get { return _gameList; }
            set { _gameList = value; NotifyPropertyChanged("GameList"); }
        }

        public bool IsPlaying
        {
            get { return _isPlaying; }
            set { _isPlaying = value; NotifyPropertyChanged("isPlaying"); }
        }

        public string RunningGameName
        {
            get { return _runningGameName; }
            set { _runningGameName = value; NotifyPropertyChanged("RunningGameName"); }
        }




        public void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
