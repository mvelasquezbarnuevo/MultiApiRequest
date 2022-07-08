using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestConsole.Abstractions
{
    internal interface IProcessor
    {
        Task Process(string filePath);
    }
}
