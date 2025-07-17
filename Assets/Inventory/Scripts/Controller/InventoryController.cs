using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryData _inventoryData;
    public event Action OnInventoryUpdated; // ������� ��� ���������� View

    public void AddItem(ItemData item) // ���������� �������� � ���������
    {
        _inventoryData.Items.Add(item);
        OnInventoryUpdated?.Invoke();
    }

    public void RemoveItem(ItemData item) // �������� �������� �� ���������
    {
        _inventoryData.Items.Remove(item);
        OnInventoryUpdated?.Invoke();
    }

    // ������ � ������
    public IReadOnlyList<ItemData> GetItems() => _inventoryData.Items.AsReadOnly();
}