using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestConsole.Abstractions
{
    internal interface IInputReader
    {
        string Read(string input);
    }
}
