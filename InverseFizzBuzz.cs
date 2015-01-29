using System;

namespace pokornylukas
{
    public class InverseFizzBuzz
    {
        private string[] list;

        public InverseFizzBuzz(string[] list)
        {
            this.list = list;
        }

        public int[] Sequence() 
        {
            int min = 0;
            int max = 100;
            int currentMin = 1;
            int currentMax = 1;
            int fizzBuzzPosstion = 0;

            for(int i=1; i<=100;i++)
            {
              if(isFizzBuzz(i, list[fizzBuzzPosstion]))
              {
                  fizzBuzzPosstion += 1;
                  if (currentMin == 1 && fizzBuzzPosstion == list.Length)
                  {
                      // for case of one item in list array
                      return new int[] { i };
                  }
                  else if (currentMin == 1)
                      currentMin = i;
                  else if (currentMax == 1 && fizzBuzzPosstion == list.Length)
                  {
                      currentMax = i;
                      if (min == 0 || (currentMax - currentMin) < (max - min))
                      {
                          min = currentMin;
                          max = currentMax;
                      }

                      // new iteration setup for long fbfb's
                      i = currentMin + 2;
                      currentMin = 1;
                      currentMax = 1;
                      fizzBuzzPosstion = 0;
                  }                  
              }                
            }

            return prepareIntArray(min, max);
        }

        private int[] prepareIntArray(int min, int max)
        {
            int[] retval = new int[max - min + 1];
            for (int j = min; j <= max; j++)
            {
                retval[j - min] = j;
            }

            return retval;
        }
                
        private bool isFizzBuzz(int number, string fizzBuzz)
        {
            if (fizzBuzz == "fizz" && ((number % 3) == 0))
                return true;
            else if (fizzBuzz == "buzz" && ((number % 5) == 0))
                return true;
            else
                return false;
        }
    }

}