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
           var keyset = ((ComboBoxItem)this.Get<ComboBox>("Keyset").SelectedItem).Content.ToString();
            var board = ((ComboBoxItem?)this.Get<ComboBox>("Board").SelectedItem).Content.ToString();
             var wincondition = ((ComboBoxItem?)this.Get<ComboBox>("WinCondition").SelectedItem).Content.ToString();
              var player_selector = ((ComboBoxItem?)this.Get<ComboBox>("PlayerSelector").SelectedItem).Content.ToString();
               var key_selector = ((ComboBoxItem?)this.Get<ComboBox>("KeySelector").SelectedItem).Content.ToString();
             string[] configs = new string[]{game_name,keyset,board,wincondition,player_selector,key_selector};            
            if(keyset=="" || board=="" || wincondition==""|| player_selector=="" || key_selector=="")
            {
                    
            }else
            {
               
                ConfigFile game_config = new ConfigFile(configs);
                foreach(var a in configs)
                {
                    System.Console.WriteLine(a);
                }
            }                       
        }
    }
    
}
