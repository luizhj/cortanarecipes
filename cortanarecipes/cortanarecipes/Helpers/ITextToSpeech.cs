using System;
using System.Collections.Generic;
using System.Text;

namespace cortanarecipes.Helpers
{
    public interface ITextToSpeech
    {
        void Speak(string text);
    }
}
