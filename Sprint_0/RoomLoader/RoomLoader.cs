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
	internal static List<int> getRoomInformation(int currentRoomIndex)
	{
        List<int> roomInfo;

        using (var reader = new StreamReader("C:\\Users\\steve\\Source\\Repos\\HnH\\Sprint_0\\RoomLoader\\Rooms\\Room" + currentRoomIndex + ".csv"))
        {

            string[] doorInformation = reader.ReadLine().Split(",");
            roomInfo = new List<int>(Array.ConvertAll(doorInformation, s => int.Parse(s)));
            return roomInfo;

            /*
            Debug.WriteLine(doorInformation);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                Debug.WriteLine(line);
                Debug.WriteLine(values);
            }
            */
        }
    }
}
