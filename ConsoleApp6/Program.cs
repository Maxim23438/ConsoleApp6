using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            if (n == 1)
            {
                Directory.CreateDirectory(@"C:\temp");
                File.Create(@"C:\temp\Loc.txt");
            }
            
            TraceMainSender a = new TraceMainSender();
            
            for(int i = 0;i < 175;++i)
            {
                a.WriteLine("Hello world" + i);
            }
            
        }

        class TraceMainSender : TraceListener
        {
            UInt64 logsCount = 0;
            List<String> c = new List<String>();
            
            public override void Write(string message)
            {
                Console.Write(message);
                 
                
            }

            public override void Flush()
            {
                ++logsCount;
                File.WriteAllLines($"C:\\temp\\Loc{logsCount}.txt", c);

                c.Clear();
            }

            public override void WriteLine(string message)
            {
                
                c.Add(message);
                if(c.Count == 50)
                {
                    ++logsCount;
                    File.WriteAllLines($"C:\\temp\\Loc{logsCount}.txt", c);
                    
                    c.Clear();
                }
                
                
            }
        }

    }
}
