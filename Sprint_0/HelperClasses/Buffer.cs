using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Buffer
{
    
    public static bool itemBuffer(int[] bufferInts)
    {
        bool ready = false;
        int currentIndex = bufferInts[0];
        int bufferIndex = bufferInts[1];
        int bufferMax = bufferInts[2];
        if (currentIndex == 0)
        {
            bufferIndex++;
        }
        else
        {
            bufferIndex += 2;
        }

        if (bufferIndex == bufferMax)
        {
            ready = true;
            bufferIndex = 0;
            currentIndex++;
            if (currentIndex == 2)
            {
                currentIndex = 0;
            }
        }
        bufferInts[0] = currentIndex;
        bufferInts[1] = bufferIndex;
        bufferInts[2] = bufferMax;
        
        return ready;
    }
}
