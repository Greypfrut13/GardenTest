using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Inventory
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private TMP_Text _countText;
        [SerializeField] private Button _slotButton;
        [SerializeField] private Button _deleteButton;

        private Item _item;
        private int _count;
        
        public Item Item => _item;
        public int Count => _count;
        public bool IsEmpty => _item == null;

        private void Awake()
        {
            _slotButton.onClick.AddListener(OnSlotClicked);
            _deleteButton.onClick.AddListener(DeleteItem);
            _deleteButton.gameObject.SetActive(false);
        }

        public void AddItem(Item item, int count)
        {
            if (item == null)
            {
                return;
            }
            
            _item = item;
            _count = count;

            UpdateUI();
        }

        private void UpdateUI()
        {
            bool hasItem = !IsEmpty;
            _iconImage.gameObject.SetActive(hasItem);
            
            if (hasItem)
            {
                _iconImage.sprite = _item.Icon;
                _countText.text = _count > 1 ? _count.ToString() : "";
            }
            else
            {
                _countText.text = "";
            }
        }

        private void OnSlotClicked()
        {
            if (IsEmpty)
            {
                return;
            }
            
            bool showDelete = _item != null && !_deleteButton.gameObject.activeSelf;
            _deleteButton.gameObject.SetActive(showDelete);
            
            foreach (Transform sibling in transform.parent)
            {
                if (sibling != transform && sibling.TryGetComponent<InventorySlot>(out var slot))
                {
                    slot.HideDeleteButton();
                }
            }
        }
        
        public void HideDeleteButton()
        {
            if (_deleteButton != null)
                _deleteButton.gameObject.SetActive(false);
        }

        private void DeleteItem()
        {
            _item = null;
            _count = 0;
            _deleteButton.gameObject.SetActive(false);
            UpdateUI();
        }
    }
}