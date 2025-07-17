using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryData _inventoryData;
    public event Action OnInventoryUpdated; // Событие для обновления View

    public void AddItem(ItemData item) // Добавление предмета в инвентарь
    {
        _inventoryData.Items.Add(item);
        OnInventoryUpdated?.Invoke();
    }

    public void RemoveItem(ItemData item) // Удаление предмета из инвентаря
    {
        _inventoryData.Items.Remove(item);
        OnInventoryUpdated?.Invoke();
    }

    // Доступ к данным
    public IReadOnlyList<ItemData> GetItems() => _inventoryData.Items.AsReadOnly();
}