using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Inventory/InventoryData")]
public class InventoryData : ScriptableObject   // Модель слотов инвентаря
{
    public List<ItemData> Items = new List<ItemData>();
}