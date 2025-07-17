using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private InventoryController _controller;
    [SerializeField] private Transform _slotsContainer;
    [SerializeField] private GameObject _slotPrefab;

    private void Start()
    {
        _controller.OnInventoryUpdated += UpdateView;
        UpdateView();
    }

    private void UpdateView()
    {
        // Очистка контейнера
        foreach (Transform child in _slotsContainer) Destroy(child.gameObject);

        // Создание слотов
        foreach (ItemData item in _controller.GetItems())
        {
            GameObject slot = Instantiate(_slotPrefab, _slotsContainer);
            slot.transform.Find("Icon").GetComponent<Image>().sprite = item.Icon;
            slot.transform.Find("Name").GetComponent<TMP_Text>().text = item.Name;
            slot.transform.Find("Description").GetComponent<TMP_Text>().text = item.Description;
        }
    }

    private void OnDestroy() => _controller.OnInventoryUpdated -= UpdateView;
}
