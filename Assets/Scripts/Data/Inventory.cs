using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Game/Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> items = new List<Item>(); // 背包物品列表

    // 添加物品
    public void AddItem(Item item)
    {
        if (item != null)
        {
            items.Add(item);
            Debug.Log("获得物品：" + item.itemName);
        }
    }

    // 检查是否有指定物品
    public bool HasItem(Item item)
    {
        return items.Contains(item);
    }

    // 移除物品
    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
        }
    }

    // 清空背包（可选）
    public void ClearInventory()
    {
        items.Clear();
    }
}