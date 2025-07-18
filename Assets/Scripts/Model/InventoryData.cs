using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Inventory/InventoryData")]
public class InventoryData : ScriptableObject   // ������ ������ ���������
{
    public int MaxSlots = 5;   // ������������ ����� ������
    public List<ItemData> Items = new List<ItemData>(); // ������ ����, ������� ������ � ���������
}