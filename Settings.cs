using System;
using System.Collections.Generic;
using System.Text;

namespace BachFlixAudioAnalyzer
{
    class Settings
    {
        public string silenceDetection { get; set; }
        public string silenceDuration { get; set; }
        public string vlcLocation { get; set; }
        public string outputLocation { get; set; }
        public string deleteOriginal { get; set; }
        public string removeSplashScreens { get; set; }
    }
}
