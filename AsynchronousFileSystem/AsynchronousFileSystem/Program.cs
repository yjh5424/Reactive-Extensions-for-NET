using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousFileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            FileContoroller contoroller = new FileContoroller();
            contoroller.ExecuteFileSystem();
            
        }
    }
}
