using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Inventory/InventoryData")]
public class InventoryData : ScriptableObject   // Модель слотов инвентаря
{
    public int MaxSlots = 5;   // Максимальное число слотов
    public List<ItemData> Items = new List<ItemData>(); // Список того, сколько слотов в инвентаре
}