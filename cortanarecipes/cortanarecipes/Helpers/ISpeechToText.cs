using System;
using System.Collections.Generic;
using System.Text;

namespace cortanarecipes.Helpers
{
    public interface ISpeechToText
    {
        void StartSpeechToText();
        void StopSpeechToText();
    }
}
