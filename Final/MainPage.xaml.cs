using Final.ViewModels;

namespace Final
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(new RiotID(), new PlayerInfo(), new PlayerInfoMatch());
        }
    }
}
