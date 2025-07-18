using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotView : MonoBehaviour
{
    // ������ �� ��������, ������������� � ����������
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Button _removeButton;

    // ��������� ������ ��� �������� �����
    private ItemData _item;
    private InventoryController _controller;

    public void Setup(ItemData item, InventoryController controller)
    {
        _item = item;   // ������ �������� ��� �����������
        _controller = controller;   //���������� ��������� ��� ��������

        // ���������� ����� UI
        _icon.sprite = item.Icon;
        _name.text = item.Name;
        _description.text = item.Description;

        // ����� ������ � ���������� ����� ���������� ��� ��������
        _removeButton.onClick.RemoveAllListeners();
        _removeButton.onClick.AddListener(() =>
        {
            _controller.RemoveItem(_item);
        });
    }
}