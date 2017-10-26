using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesst
{
    abstract class State
    {
		int c = 0;
       public void Test(var name_A, int name_B)
	   {
		   if(name_A != nameB )
		{
			 name_B = new List<string>() { "John", "Tom", "Peter" };
			foreach (string name in name_B)
			{
				if (name == "Tom")
				{
					break;
				}
				Console.WriteLine(name);
			}
			Console.WriteLine("OK");
		}
		else
		{
			
			 name_A = new List<string>() { "John", "Tom", "Peter" };
			foreach (string name in name_A)
			{
				if (name == "Peter")
				{
					continue;
				}
				Console.WriteLine(name);
			}
			  
		}
	   }
	   
	   
	   
      }
}
