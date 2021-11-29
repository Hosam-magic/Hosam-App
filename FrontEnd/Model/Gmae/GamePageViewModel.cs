
using Hosam_App.Logic.Controller;
using Hosam_App.Logic.DTO;
using Hosam_App.Logic.Entity;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;

namespace Hosam_App.FrontEnd.Model.Gmae
{
    public class GamePageViewModel:ViewModelBase
    {
        string _gameName;
        string _imgPath;

        public GamePageViewModel(GameData data)
        {
            gameName = data.gameName ;
            imgPath = "./Image/Game/MainPage/GamePage/AssetoCorsa.jpg";
        }

        public string gameName
        {
            get { return _gameName; }
            set { _gameName = value; OnPropertyChanged(); }
        }

        public string imgPath
        {
            get { return _imgPath; }
            set { _imgPath = value; OnPropertyChanged(); }
        }
    }
}
