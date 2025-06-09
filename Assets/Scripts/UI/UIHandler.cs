using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIHandler : MonoBehaviour
    {
        [Header("Inventory")]
        [SerializeField] private Button _inventoryButton;
        [SerializeField] private GameObject _inventoryPanel;

        private void Awake()
        {
            _inventoryButton.onClick.AddListener(OpenAndCloseInventory);
        }

        public void OpenAndCloseInventory()
        {
            if (_inventoryPanel.activeInHierarchy)
            {
                _inventoryPanel.SetActive(false);
            }
            else
            {
                _inventoryPanel.SetActive(true);
            }
        }
    }
}