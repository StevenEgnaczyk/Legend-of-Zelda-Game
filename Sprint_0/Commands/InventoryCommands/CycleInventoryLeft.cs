using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class CycleInventoryLeft : ICommand
{

    Inventory inventory;

    public CycleInventoryLeft(Inventory userInventory)
    {
        inventory = userInventory;
    }

    public void Execute()
    {
        //moved selected inventory item to the left
        inventory.inventoryManager.cycleItemLeft();
    }
}