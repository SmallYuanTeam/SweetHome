using UnityEngine;

[CreateAssetMenu(fileName = "New Crafting Object", menuName = "Inventory System/Items/Crafting")]

public class CraftingObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Craftable;
    }
}