using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

public static class RoomLoader
{
	internal static List<List<int>> getRoomInformation(int currentRoomIndex)
	{
        List<List<int>> roomInformation = new List<List<int>>();
        List<int> doorInfo;
        List<int> blockInfo;

        using (var reader = new StreamReader("C:\\Users\\steve\\Source\\Repos\\HnH\\Sprint_0\\RoomLoader\\Rooms\\Map" + (currentRoomIndex + 1) + ".csv"))
        {

            string[] doorInformation = reader.ReadLine().Split(",");
            doorInfo = new List<int>(Array.ConvertAll(doorInformation, s => int.Parse(s)));
            roomInformation.Add(doorInfo);

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                string[] values = line.Split(',');
                blockInfo = new List<int>(Array.ConvertAll(values, s => int.Parse(s)));
                roomInformation.Add(blockInfo);

            }
        }

        return roomInformation;
    }
}
