using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Final.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private bool _enable_button = false; 
        private string _opacity="0";
        private string _error;
        private string _region;
        private string _response="put in your gamename and tagline";
        private string _gameNameandTag = "";
        private string _background = "https://ddragon.leagueoflegends.com/cdn/img/champion/splash/Zed_10.jpg";
        private string _item0;
        private string _item1;
        private string _item2;
        private string _item3;
        private string _item4;
        private string _item5;
        private string _item6;
        private string _rank;
        private string _wintext = "";
        private Color _wincolor;

        public bool Enable_Button { get => _enable_button; set => _enable_button = value; }
        public string Opacity { get=>_opacity; set=>_opacity = value; }
        public string Error { get => _error; set => _error = value; }
        public string Region { get => _region; set => _region = value; }
        public string Response { get => _response; set => _response = value; }
        public string GameNameandTag {get=> _gameNameandTag; set=> _gameNameandTag = value; }
        public string BackgroundImagePath { get => _background;  set => _background = value;  }
        public string WinText { get => _wintext; set => _wintext = value; }
        public Color WinColor { get => _wincolor; set => _wincolor = value; }

        public string Item0ImagePath { get => _item0 ; set => _item0 = value; }
        public string Item1ImagePath { get => _item1; set => _item0 = value; }
        public string Item2ImagePath { get => _item2; set => _item2 = value; }
        public string Item3ImagePath { get=> _item3 ; set => _item3 = value; }
        public string Item4ImagePath { get => _item4; set => _item4 = value; }
        public string Item5ImagePath { get => _item5; set => _item5 = value; }
        public string Item6ImagePath { get => _item6; set => _item6 = value; }
        public string RankImagePath { get => _rank; set => _rank = value; }

        public Command SetImageCommand { get; set; }
        public Command SetLabelRankCommand { get; set; }
        public Command SetLabelItem0Command { get; set; }
        public Command SetLabelItem1Command { get; set; }
        public Command SetLabelItem2Command { get; set; }
        public Command SetLabelItem3Command { get; set; }
        public Command SetLabelItem4Command { get; set; }
        public Command SetLabelItem5Command { get; set; }
        public Command SetLabelItem6Command { get; set; }

        I_RiotID Summoner;
        I_PlayerInfo PlayerInfo;
        I_PlayerInfoMatch PlayerInfoMatch;


        public MainViewModel(I_RiotID _Summoner, I_PlayerInfo _PlayerInfo, I_PlayerInfoMatch _PlayerInfoMatch) 
        {
            Summoner = _Summoner;
            PlayerInfo=_PlayerInfo;
            PlayerInfoMatch=_PlayerInfoMatch;
            SetImageCommand = new Command(() => UpdateUI());
            SetLabelRankCommand = new Command(execute: () =>  SetLabelText(PlayerInfo.RankPlayer), canExecute: () => { return PlayerInfo?.RankPlayer!=null; });
            SetLabelItem0Command = new Command(execute: () => SetLabelText(PlayerInfo.Item0), canExecute: () => { return PlayerInfo?.Item0 != null; });
            SetLabelItem1Command = new Command(execute: () => SetLabelText(PlayerInfo.Item1), canExecute: () => { return PlayerInfo?.Item1 != null; });
            SetLabelItem2Command = new Command(execute: () => SetLabelText(PlayerInfo.Item2), canExecute: () => { return PlayerInfo?.Item2 != null; });
            SetLabelItem3Command = new Command(execute: () => SetLabelText(PlayerInfo.Item3), canExecute: () => { return PlayerInfo?.Item3 != null; });
            SetLabelItem4Command = new Command(execute: () => SetLabelText(PlayerInfo.Item4), canExecute: () => { return PlayerInfo?.Item4 != null; });
            SetLabelItem5Command = new Command(execute: () => SetLabelText(PlayerInfo.Item5), canExecute: () => { return PlayerInfo?.Item5 != null; });
            SetLabelItem6Command = new Command(execute: () => SetLabelText(PlayerInfo.Item6), canExecute: () => { return PlayerInfo?.Item6 != null; });
        }
        private void SetLabelText(I_Icons Icon) 
        {
            _response = Icon.description();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Response)));
        }
        private async Task<bool> UpdateUI() 
        {
            Enable_Button = false;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Enable_Button)));
            I_Regions Region = new Regions(_region);  
            await PlayerInfo.SetData(Region, _gameNameandTag, Summoner, PlayerInfoMatch);
            _error=PlayerInfo.ErrorMessage;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Error)));
            Enable_Button=true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Enable_Button)));
            if (PlayerInfo.Error == false)
            {
                _opacity = "1";
                _wintext = PlayerInfo.WinText();
                _wincolor = PlayerInfo.WinColor();
                _response = PlayerInfo.RankPlayer.description();
                _background = PlayerInfo.Champion.image;
                _item0 = PlayerInfo.Item0.image;
                _item1 = PlayerInfo.Item1.image;
                _item2 = PlayerInfo.Item2.image;
                _item3 = PlayerInfo.Item3.image;
                _item4 = PlayerInfo.Item4.image;
                _item5 = PlayerInfo.Item5.image;
                _item6 = PlayerInfo.Item6.image;
                _rank = PlayerInfo.RankPlayer.Image;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BackgroundImagePath)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Item0ImagePath)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Item1ImagePath)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Item2ImagePath)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Item3ImagePath)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Item4ImagePath)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Item5ImagePath)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Item6ImagePath)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RankImagePath)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Response)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WinText)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WinColor)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Error)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Opacity)));
                (SetLabelRankCommand as Command).ChangeCanExecute();
                (SetLabelItem0Command as Command).ChangeCanExecute();
                (SetLabelItem1Command as Command).ChangeCanExecute();
                (SetLabelItem2Command as Command).ChangeCanExecute();
                (SetLabelItem3Command as Command).ChangeCanExecute();
                (SetLabelItem4Command as Command).ChangeCanExecute();
                (SetLabelItem5Command as Command).ChangeCanExecute();
                (SetLabelItem6Command as Command).ChangeCanExecute();
            }
            return true;
        }
    }
}
