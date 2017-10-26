using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Process mysprocess = new Process();

           
            try
            {

                mysprocess.StartInfo.UseShellExecute = false;
               

                mysprocess.StartInfo.FileName = @"C:\Users\Systeembeheer\Desktop\WebMaster\PMasterWorkingOnBeta\PMaster\Sim\sim_c.exe";
                //mysprocess.StartInfo.Arguments = @"C:\Users\Systeembeheer\Desktop\WebMaster\PMasterWorkingOnBeta\PMaster\Sim\sim_c.exe";
                mysprocess.StartInfo.Arguments = @"C:\Users\Systeembeheer\Desktop\test\test\Add.cs  C:\Users\Systeembeheer\Desktop\test\test\Multiplication.cs";
                //mysprocess.StartInfo.CreateNoWindow = false; 


                mysprocess.Start();
                mysprocess.WaitForExit();

                Console.ReadKey();



            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                throw;
            }
        }
    }
}
