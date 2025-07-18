using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/ItemData")]
public class ItemData : ScriptableObject    // ������ ���������� �������� ���������
{
    public string Name; // �������� ��������
    [TextArea] public string Description;   // ��������
    public Sprite Icon; // ������
}