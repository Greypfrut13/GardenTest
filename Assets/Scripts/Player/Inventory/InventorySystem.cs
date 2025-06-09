using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player.Inventory
{
    public class InventorySystem : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] [Min(1)] private int _slotsCount = 10;
        
        [Header("UI References")]
        [SerializeField] private Transform _slotsContainer;
        [SerializeField] private GameObject _slotPrefab;
        
        private List<InventorySlot> _slots = new List<InventorySlot>();
        
        public IReadOnlyList<InventorySlot> Slots => _slots;

        private void Awake()
        {
            InitializeSlots();
        }

        private void InitializeSlots()
        {
            if (_slots.Count > 0) return;
            
            for (int i = 0; i < _slotsCount; i++)
            {
                if (_slotPrefab == null)
                {
                    Debug.LogError("Slot prefab is not assigned!");
                    continue;
                }
                
                var slot = Instantiate(_slotPrefab, _slotsContainer).GetComponent<InventorySlot>();
                if (slot != null)
                {
                    _slots.Add(slot);
                }
            }
        }

        public bool AddItem(Item item, int count = 1)
        {
            if (item == null || count <= 0) return false;

            foreach (var slot in _slots)
            {
                if (!slot.IsEmpty && slot.Item == item && item.MaxStack > slot.Count)
                {
                    int canAdd = item.MaxStack - slot.Count;
                    int addAmount = Mathf.Min(canAdd, count);
                    
                    slot.AddItem(item, slot.Count + addAmount);
                    count -= addAmount;
                    
                    if (count <= 0) return true;
                }
            }
            
            foreach (var slot in _slots)
            {
                if (slot.IsEmpty)
                {
                    int addAmount = Mathf.Min(count, item.MaxStack);
                    slot.AddItem(item, addAmount);
                    count -= addAmount;
                    
                    if (count <= 0) return true;
                }
            }
            
            Debug.LogWarning("Inventory is full!");
            return false;
        }
    }
}