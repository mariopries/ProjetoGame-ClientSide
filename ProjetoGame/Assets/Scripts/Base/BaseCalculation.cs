using System.Collections;
using System.Collections.Generic;

public class BaseCalculation
{

    public static int DecreasePercentage(int value, int percentage)
    {
        float perc = ((float)percentage / 100);
        value -= (int)(value * perc);
        return value;
    }

}
 