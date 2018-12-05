using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testArray = { 8, 6, 7, 5, 3, 0, 9 };
            int[] _testArray = { 4, 6, 2, 7, 6, 8, 9, 5, 4, 3, 2, 6, 7, 3, 1, 2, 5, 3, 8, 9, 5, 0, 7, 5, 4, 3, 0, 3, 2, 6 };
            //int testArray_Minimum = Minimums.FindMinimum(testArray);
            //int testArray_2ndMinimum = Minimums.Find2ndMinimum(testArray);
            NthMinimums.FindNthMinimum(_testArray, 3);
        }
    }
}
