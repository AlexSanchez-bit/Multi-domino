using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Controls.Shapes;
namespace Grafica
{
    public partial class MainWindow : Window
    {      
        public MainWindow()
        {
            InitializeComponent();           
        }
       
        public void GameConfiguration(object obj,RoutedEventArgs args)
        {
            var button =(Button)obj;                               
            button.Content="iniciando";
            var window = new CustomizationWindow();
                window.GoToNextWindow(this);
        }

         public void CustomGames(object obj,RoutedEventArgs args)
        {
            var button =(Button)obj;   
            var window = new PrefabsWindow();
            window.GoToNextWindow(this);          
        }

         public void Exit(object obj,RoutedEventArgs args)
        {
            var button =(Button)obj;                               
           this.Close();
        }
    }
    
}
