using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Controls.Shapes;
using System.Collections;
using System.Collections.Generic;
namespace Grafica
{
    public partial class CustomizationWindow : Window,ITemporalWindow
    {   
        private ConfigFile game_file;   
        public CustomizationWindow()
        {
            InitializeComponent();           
        }
       
       Window parentWindow;
        public void GoToNextWindow(Window original)
        {
            parentWindow=original;
            original.Hide();
            this.Show();
        }

        
        public void ReturnToOriginal()
        {
            this.parentWindow.Show();
            this.Close();
        }
        public void GoBack(object obj,RoutedEventArgs args)
        {
           ReturnToOriginal();
        }

          public void Initialize(object obj,RoutedEventArgs args)
        {
           var game_name = this.Get<TextBox>("GameName").Text;
           var keyset = (ComboBoxItem?)this.Get<ComboBox>("Keyset").SelectedItem;
           var board = (ComboBoxItem?)this.Get<ComboBox>("Board").SelectedItem;
           var wincondition = ((ComboBoxItem?)this.Get<ComboBox>("WinCondition").SelectedItem);
           var player_selector = ((ComboBoxItem?)this.Get<ComboBox>("PlayerSelector").SelectedItem);
           var key_selector = ((ComboBoxItem?)this.Get<ComboBox>("KeySelector").SelectedItem);
                         
            if( game_name=="" || keyset==null || board==null || wincondition==null || player_selector==null || key_selector==null)
            {
                    Window emergent = new EmergentWindow("debe rellenar todos los campos");
                    emergent.Show();                                    
            }else
            {
               string[] configs = new string[]{game_name,
               keyset.Content.ToString(),
               board.Content.ToString(),
               wincondition.Content.ToString()
               ,player_selector.Content.ToString(),
               key_selector.Content.ToString()
               };

                ConfigFile game_config = new ConfigFile(configs);

                foreach(var a in configs)
                {
                    System.Console.WriteLine(a);
                }
            }                       
        }
    }
    
}
