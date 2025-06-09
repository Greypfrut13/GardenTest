using UnityEngine;

namespace Player.Inventory
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
    public class Item : ScriptableObject
    {
        [SerializeField] private string _itemName;
        [SerializeField] private Sprite _icon;
        [SerializeField] [Min(0)] private int _maxStack;
        
        public string ItemName => _itemName;
        public Sprite Icon => _icon;
        public int MaxStack => _maxStack;
    }
}