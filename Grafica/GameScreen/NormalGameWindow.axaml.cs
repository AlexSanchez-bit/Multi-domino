using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Grafica
{
    public partial class NormalGameWindow : Window,ITemporalWindow
    {      
        int ways;
        (int,int) rightPos;
        (int,int) leftPos;
        public NormalGameWindow()
        {
            InitializeComponent();           
            PrintPlayerKeys(10);
            rightPos=(0,0);
            leftPos=(0,0);
            var generator = new NormalGenerator();
            int i=0;
            foreach(var a in generator.GenerateKeyset())
            {
                if(i++ == 100)break;
                PlayKey(a,(i%2)+1);
            }
        }

        Window parentWindow;
        public void GoToNextWindow(Window original)  
        {
            parentWindow=original;
            original.Hide();
            this.Show();        
        }
        
        private bool IsDouble(IKey key)
        {
            return key.GetAllFaces().All(elem=>elem.Equals(key.GetFace(0)));
        }
        private void PlayKey(IKey key,int place)
        {           
                if(rightPos==leftPos)
                {
                    PrintHorizontalKey(rightPos.Item1,rightPos.Item2);
                    rightPos=(rightPos.Item1+65,rightPos.Item2);
                    leftPos=(leftPos.Item1-65,leftPos.Item2);                    
                }
                switch(place)
                {
                    case 1:
                    PrintHorizontalKey(rightPos.Item1,rightPos.Item2);
                    rightPos=(rightPos.Item1+65,rightPos.Item2);
                    break;
                    case 2:
                    PrintHorizontalKey(leftPos.Item1,leftPos.Item2);
                    leftPos=(leftPos.Item1-65,leftPos.Item2);                    
                    break;

                
             }
        }
        
        public void ReturnToOriginal()
        {
            this.parentWindow.Show();
            this.Close();
        }
        
        private void ErasePlayerKeys()
        {
             var maincanvas = this.Get<Canvas>("tablero");                                                   
             var player_keys = maincanvas.Children.Where(elem=>elem.Classes.Contains("PlayerKeys"));
        }

        private void PrintPlayerKeys(int cant)
        {
             var maincanvas = this.Get<Canvas>("tablero");             
             var width = (float)maincanvas.Width;
             var Height = (float)maincanvas.Height;

             for(int i=0;i<cant;i++)
             {
                PrintVerticalKey((width/-2)+(i*40),Height*2);
             }

        }

        public void PrintHorizontalKey(float left,float top)
        {
             var maincanvas = this.Get<Canvas>("tablero");             
             Rectangle rect = new Rectangle(){
                Width=30,
                Height=30,                        
                Fill= Brushes.Black
              };              
                Canvas.SetTop(rect,top);
                Canvas.SetLeft(rect,left); 
                rect.Classes.Add("PlayerKeys");
              maincanvas.Children.Add(rect);

             Rectangle rect2 = new Rectangle(){
                Width=30,
                Height=30,            
                Fill= Brushes.Black
              };
                Canvas.SetTop(rect2,top);
                Canvas.SetLeft(rect2,left+30); 
                rect2.Classes.Add("PlayerKeys");
              maincanvas.Children.Add(rect2);
        }

        public void PrintVerticalKey(float left,float  top)
        {
            
             var maincanvas = this.Get<Canvas>("tablero");
             Rectangle rect = new Rectangle(){
                Width=30,
                Height=30,            
                Fill= Brushes.Black
              };
                Canvas.SetLeft(rect,left);
                Canvas.SetTop(rect,top+9); 
                rect.Classes.Add("PlayerKeys");
              maincanvas.Children.Add(rect);

             Rectangle rect2 = new Rectangle(){
                Width=30,
                Height=30,            
                Fill= Brushes.Black
              };
                Canvas.SetLeft(rect2,left);
                Canvas.SetTop(rect2,top-21); 
                rect2.Classes.Add("PlayerKeys");
              maincanvas.Children.Add(rect2);
        }      

    }
    
}
