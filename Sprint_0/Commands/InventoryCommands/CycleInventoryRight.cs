using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class CycleInventoryRight : ICommand
{

    Inventory inventory;

    public CycleInventoryRight(Inventory userInventory)
    {
        inventory = userInventory;
    }

    public void Execute()
    {
        inventory.inventoryManager.cycleItemRight();
    }
}