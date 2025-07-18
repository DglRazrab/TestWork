using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryView : MonoBehaviour
{
    // ������ �� ��������, ������������� � ����������
    [SerializeField] private InventoryController _controller;
    [SerializeField] private Transform _slotsContainer;
    [SerializeField] private GameObject _slotPrefab;

    private void Start()
    {
        // ������� ���������� ��������� � ��������� ���������
        _controller.OnInventoryUpdated += UpdateView;
        UpdateView();
    }

    private void UpdateView()
    {
        // �������� ������ ������
        foreach (Transform child in _slotsContainer)
            Destroy(child.gameObject);

        var items = _controller.GetItems(); // ��������� ������� ���������
        int maxSlots = _controller.MaxSlots;    // ��������� ������ ���������� ��������� ������

        for (int i = 0; i < maxSlots; i++)
        {
            // ���������� ������ �����
            var slotGO = Instantiate(_slotPrefab, _slotsContainer);

            // ����� ������ ��������� UI ������ �����
            var icon = slotGO.transform.Find("Icon").GetComponent<Image>();
            var nameTxt = slotGO.transform.Find("Name").GetComponent<TMP_Text>();
            var descTxt = slotGO.transform.Find("Description").GetComponent<TMP_Text>();
            var remBtn = slotGO.transform.Find("RemoveButton").GetComponent<Button>();

            if (i < items.Count)
            {
                // ���������� �����
                var item = items[i];
                icon.sprite = item.Icon;
                nameTxt.text = item.Name;
                descTxt.text = item.Description;

                // �������� ����������
                remBtn.onClick.RemoveAllListeners();

                // ����� ���������� ������ ��������
                remBtn.onClick.AddListener(() => _controller.RemoveItem(item));
            }
            else
            {
                // ������ ����: �������������� ������, ������� ������
                icon.color = new Color(1, 1, 1, 0.3f);
                nameTxt.text = "";
                descTxt.text = "";
                remBtn.gameObject.SetActive(false);
            }
        }
    }

    private void OnDestroy() => _controller.OnInventoryUpdated -= UpdateView;
}
