
using Hosam_App.Logic.Controller;
using Hosam_App.Logic.DTO;
using Hosam_App.Logic.Entity;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;

namespace Hosam_App.FrontEnd.Model.Gmae
{
    public class GameViewModel:ViewModelBase
    {
        //左側最愛遊戲列所需參數
        bool _isPlayingVisible;
        string _playGameName;
        int _favoriteSort = 0;
        PackIconKind _sortIcon = PackIconKind.SortClockAscendingOutline;
        List<GameData> _favoriteGameList;

        //右側遊戲頁面所需參數
        List<GameData> _GameList;


        public bool isPlayingVisible
        {
            get { return _isPlayingVisible; }
            set { _isPlayingVisible = value; OnPropertyChanged(); }
        }
        public string playGameName
        {
            get { return _playGameName; }
            set { _playGameName = value; OnPropertyChanged(); }
        }

        public int favoriteSort
        {
            get { return _favoriteSort; }
            set { _favoriteSort = value; OnPropertyChanged(); }
        }

        public PackIconKind sortIcon
        {
            get { return _sortIcon; }
            set { _sortIcon = value; OnPropertyChanged(); }
        }

        public List<GameData> favoriteGameList
        {
            get { return _favoriteGameList; }
            set { _favoriteGameList = value; OnPropertyChanged(); }
        }

        public List<GameData> gameList
        {
            get { return _GameList; }
            set { _GameList = value; OnPropertyChanged(); }
        }

    }
}
