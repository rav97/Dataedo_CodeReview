using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Managers.Interfaces
{
    public interface IConsoleDisplayer<T>
    {
        void DisplayOnConsole(T obj);
    }
}
