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
	//
    internal static List<List<List<int>>> getRoomInformation(int currentRoomIndex)
	{
        List<List<List<int>>> roomInformation = new List<List<List<int>>>();
        List<List<int>> doorInfo = new List<List<int>>();
        List<List<int>> blockInfo = new List<List<int>>();
        List<List<int>> enemyInfo = new List<List<int>>();
        List<List<int>> itemInfo = new List<List<int>>();

        List<int> doorInfoLine = new List<int>();
        List<int> blockInfoLine = new List<int>();
        List<int> enemyInfoLine = new List<int>();
        List<int> itemInfoLine = new List<int>();


        using (var reader = new StreamReader("..\\..\\..\\Dungeon\\RoomCSVs\\Map" + (currentRoomIndex) + ".csv"))
        {

            string[] doorInformation = reader.ReadLine().Split(",");
            doorInfoLine = new List<int>(Array.ConvertAll(doorInformation, s => int.Parse(s)));
            doorInfo.Add(doorInfoLine);

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                string[] values = line.Split(',');

                if (Int32.Parse(values[0]) < 20)
                {
                    blockInfoLine = new List<int>(Array.ConvertAll(values, s => int.Parse(s)));
                    blockInfo.Add(blockInfoLine);
                } else if (Int32.Parse(values[0]) >= 20 && Int32.Parse(values[0]) < 30)
                {
                    enemyInfoLine = new List<int>(Array.ConvertAll(values, s => int.Parse(s)));
                    enemyInfo.Add(enemyInfoLine);

                } else
                {
                    itemInfoLine = new List<int>(Array.ConvertAll(values, s => int.Parse(s)));
                    itemInfo.Add(itemInfoLine);
                }

            }
        }

        roomInformation.Add(doorInfo);
        roomInformation.Add(blockInfo);
        roomInformation.Add(enemyInfo);
        roomInformation.Add(itemInfo);
        
        return roomInformation;
    }
}
