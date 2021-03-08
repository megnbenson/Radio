using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RadioApp;

namespace RadioGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        Radio radio = new Radio();
        MediaPlayer theChannel1 = new MediaPlayer();
        Uri bbc1, bbc2, bbc3, bbc6;

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            button.Opacity = 30 ;
        }

        private void SwitchOn_Click(object sender, RoutedEventArgs e)
        {
            //use on property
            
            if (!radio.On)
            {
                radio.TurnOn();
                // change button colour and make it say on or off
                SwitchOn.Content = "ON";
                SwitchOn.Background = Brushes.Green;
                initialPic.Opacity = 100;

            }
            else
            {
                radio.TurnOff();
                SwitchOn.Content = "OFF";
                SwitchOn.Background = Brushes.Red;
                
                theChannel1.Stop();

                initialPic.Opacity = 100;

            }
        }

        private void Channel_Click(object sender, RoutedEventArgs e)
        {
            //get which button has been clicked
            string channel = (sender as Button).Content.ToString();
            var but = sender as Button;
            int channelChosen = Int32.Parse(channel);

            radio.Channel = channelChosen;
            if (radio.On)
            {
                firstPic.Opacity = 0;
                secondPic.Opacity = 0;
                thirdPic.Opacity = 0;
                fourthPic.Opacity = 0;
                initialPic.Opacity = 0;
                switch (radio.Channel)
                {
                    case 1:
                        theChannel1.Open(radio.ChannelSrc);
                        firstPic.Opacity = 100;                    
                        break;
                    case 2:
                        theChannel1.Open(radio.ChannelSrc);
                        secondPic.Opacity = 100;
                        break;
                    case 3:
                        theChannel1.Open(radio.ChannelSrc);
                        thirdPic.Opacity = 100;
                        break;
                    case 4:
                        theChannel1.Open(radio.ChannelSrc);
                        fourthPic.Opacity = 100;
                        break;

                }
                theChannel1.Play();
            }
            DisplayText.Text =  radio.Play(); 
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // getting the slider
            var slider = sender as Slider;

            //getting the volume
            int volume = (int)slider.Value;

            //set volume
            radio.Volume = volume;
            DisplayText.Text = "Volume at " + radio.Volume;

            // volume is 0-1, so /100
            theChannel1.Volume = (volSlider.Value)/100.0;
        }

        
    }
}
