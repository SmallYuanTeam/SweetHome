using UnityEngine;

[CreateAssetMenu(fileName = "New Story Object", menuName = "Inventory System/Items/Story")]
public class StoryObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Story;
    }
}
