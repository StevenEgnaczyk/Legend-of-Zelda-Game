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

    internal static List<List<List<int>>> getRoomInformation(int currentRoomIndex)
	{

        //Room information
        List<List<List<int>>> roomInformation = new List<List<List<int>>>();
        List<List<int>> backgroundInfo = new List<List<int>>();
        List<List<int>> doorInfo = new List<List<int>>();
        List<List<int>> blockInfo = new List<List<int>>();
        List<List<int>> enemyInfo = new List<List<int>>();
        List<List<int>> itemInfo = new List<List<int>>();

        //Intermediate room information
        List<int> backgroundInfoLine = new List<int>();
        List<int> doorInfoLine = new List<int>();
        List<int> blockInfoLine = new List<int>();
        List<int> enemyInfoLine = new List<int>();
        List<int> itemInfoLine = new List<int>();

        //Load the information about a particular room
        using (var reader = new StreamReader("..\\..\\..\\Dungeon\\RoomCSVs\\Map" + (currentRoomIndex) + ".csv"))
        {

            //Add the background info (always on the first line)
            string[] backgroundInformtion = reader.ReadLine().Split(",");
            backgroundInfoLine = new List<int>(Array.ConvertAll(backgroundInformtion, s => int.Parse(s)));
            backgroundInfo.Add(backgroundInfoLine);

            //Add the door info (always on the second line)
            string[] doorInformation = reader.ReadLine().Split(",");
            doorInfoLine = new List<int>(Array.ConvertAll(doorInformation, s => int.Parse(s)));
            doorInfo.Add(doorInfoLine);

            //While there are still lines
            while (!reader.EndOfStream)
            {
                //Read in the next line
                var line = reader.ReadLine();
                string[] values = line.Split(',');

                //Less than 20 its a tile
                if (Int32.Parse(values[0]) < 20)
                {
                    blockInfoLine = new List<int>(Array.ConvertAll(values, s => int.Parse(s)));
                    blockInfo.Add(blockInfoLine);

                } 

                //If it's greater than 20 less than 30 it's a enemy
                else if (Int32.Parse(values[0]) >= 20 && Int32.Parse(values[0]) < 30)
                {
                    enemyInfoLine = new List<int>(Array.ConvertAll(values, s => int.Parse(s)));
                    enemyInfo.Add(enemyInfoLine);

                } 
                //Else it's an item
                else
                {
                    itemInfoLine = new List<int>(Array.ConvertAll(values, s => int.Parse(s)));
                    itemInfo.Add(itemInfoLine);
                }

            }
        }

        //Add the entitiy informatino to roomInformation and return it
        roomInformation.Add(backgroundInfo);
        roomInformation.Add(doorInfo);
        roomInformation.Add(blockInfo);
        roomInformation.Add(enemyInfo);
        roomInformation.Add(itemInfo);
        return roomInformation;
    }
}
