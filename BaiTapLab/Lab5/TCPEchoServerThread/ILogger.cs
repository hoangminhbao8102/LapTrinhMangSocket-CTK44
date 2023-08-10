using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPEchoServerThread
{
    public interface ILogger
    {
        void WriteEntry(ArrayList entry);
        void WriteEntry(String entry);
    }
}
