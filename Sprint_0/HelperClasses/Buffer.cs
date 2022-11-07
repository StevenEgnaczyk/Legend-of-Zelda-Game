using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Buffer
{
    
    public static int[] itemBuffer(int[] bufferInts)
    {
        int currentIndex = bufferInts[0];
        int bufferIndex = bufferInts[1];
        int bufferMax = bufferInts[2];
        int numFrames = bufferInts[3];
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
            bufferIndex = 0;
            currentIndex++;
            if (currentIndex == numFrames)
            {
                currentIndex = 0;
            }
        }
        bufferInts[0] = currentIndex;
        bufferInts[1] = bufferIndex;
        bufferInts[2] = bufferMax;
        return bufferInts;
    }
}
