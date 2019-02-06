using System;
using System.IO;
using FestivalManager.Core.IO.Contracts;


namespace FestivalManager.Core.IO
{
	using System.IO;

    public class Writer : IWriter
    {
        public void Write(string contents)
        {
            Console.Write(contents);
        }

        public void WriteLine(string contents)
        {
            Console.WriteLine(contents);
        }
    }
}