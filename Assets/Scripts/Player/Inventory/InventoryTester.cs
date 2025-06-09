using UnityEngine;

namespace Player.Inventory
{
    public class InventoryTester : MonoBehaviour
    {
        [SerializeField] private InventorySystem _inventory;
        [SerializeField] private Item[] _testItems;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && _testItems.Length > 0)
                _inventory.AddItem(_testItems[0]);
        
            if (Input.GetKeyDown(KeyCode.Alpha2) && _testItems.Length > 1)
                _inventory.AddItem(_testItems[1], 5); // Добавим несколько
        
            if (Input.GetKeyDown(KeyCode.Alpha3) && _testItems.Length > 2)
                _inventory.AddItem(_testItems[2]);
        }
    }
}