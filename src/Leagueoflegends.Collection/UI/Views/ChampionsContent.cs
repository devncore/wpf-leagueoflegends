using Jamesnet.Foundation;
using Jamesnet.Platform.WPF;
using System.Windows.Controls;

namespace Leagueoflegends.Collection.UI.Views;

public class ChampionsContent : ContentControl, IView
{
    public ChampionsContent()
    { 
        DefaultStyleKey = typeof(ChampionsContent);    
    }
}
