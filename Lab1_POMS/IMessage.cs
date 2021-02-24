using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_POMS
{
    public interface IMessage
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
