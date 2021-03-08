using System.Linq;
using System.Collections.Generic;
using System;

namespace RadioApp
{
    public class Radio
    {
        private int _channel = 1;
        private int _volume = 10;
        private bool _on = false;
        private Uri _channelSrc;


        public int Channel
        {
            //it has 4 channels
            // and can only change channel if _on is true
            get { return _channel; }
            set
            {
                if ((value == 1 || value == 2 || value == 3 || value == 4) && _on)
                {
                    _channel = value;
                }
                else
                {
                    _channel = 2;
                }

                /// Sets channel src when changing the channel
                //radio urls from http://www.suppertime.co.uk/blogmywiki/2015/04/updated-list-of-bbc-network-radio-urls/
                if (value == 1)
                {
                    _channelSrc = new Uri("http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio1_mf_p");
                }
                else if (value == 2)
                {
                    _channelSrc = new Uri("http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio2_mf_p");
                }
                else if (value == 3)
                {
                    _channelSrc = new Uri("http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio3_mf_p");
                }
                else
                {
                    _channelSrc = new Uri("http://bbcmedia.ic.llnwd.net/stream/bbcmedia_6music_mf_p");
                }
            }
        }
        public Uri ChannelSrc
        {
            //it has 4 channels
            // and can only change channel if _on is true
            //TO PUSH THROUGH TO XAML
            

            get { return _channelSrc; }
            private set
            {
            }
        }

        public int Volume
        {
            get => _volume;
            set
            {
                if (value >= 0 && value < 101)
                {
                    _volume = value;
                }
                else
                {
                    _volume = 0;
                }
            }
        }

        public string Play()
        {
            //Radio can play only if _on = true, and returns a string with the channel 
            // e.g. "Playing channel 4"
            if (_on)
            {
                if(_channel == 4)
                {
                    return $"Playing BBC Radio 6";
                }
                else
                {
                    return $"Playing BBC Radio {_channel}";
                }
                
                
            }
            else
            {
                return $"Radio is off";
            }
            
        }

        //make on property
        public bool On
        {
            get { return _on; }
            set { _on = value; }
        }
        public void TurnOff()
        {
            _on = false;
            //throw new System.NotImplementedException();
        }

        public void TurnOn()
        {
            _on = true;
            //throw new System.NotImplementedException();
        }

        


    }
    // implement a class Radio that corresponds to the Class diagram 
    //   and specification in the Radio_Mini_Project document
}