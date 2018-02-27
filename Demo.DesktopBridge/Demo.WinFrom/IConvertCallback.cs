using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.WinFrom
{
    public interface IConvertCallback
    {
        void OnCurrencyConverted(Currency currency);
    }
}
