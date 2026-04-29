using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Game/Item")]
public class Item : ScriptableObject
{
    public string itemName;   // 物品名称
    public Sprite itemIcon;   // 物品图标
}