using System;
using System.Collections.Generic;
using System.Text;

namespace BachFlixAudioAnalyzer
{
    class Timestamp
    {
        public string lineId { get; set; }
        public string silenceStart { get; set; }
        public string silenceEnd { get; set; }
        public string silenceDuration { get; set; }
    }
}
