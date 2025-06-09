using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Player.Shooting
{
    [System.Serializable]
    public class AmmoSystem
    {
        [SerializeField] [Min(0)] private int _maxAmmo;
        [SerializeField] private TMP_Text _ammoText;
        
        private int _currentAmmo;
        
        public int CurrentAmmo => _currentAmmo;

        public void Init()
        {
            _currentAmmo = _maxAmmo;
            UpdateUI();
        }

        public bool TryConsumeAmmo()
        {
            if (_currentAmmo <= 0)
            {
                return false;
            }
            
            _currentAmmo--;
            UpdateUI();
            return true;
        }

        private void UpdateUI()
        {
            _ammoText.text = $"{_currentAmmo}/{_maxAmmo}";
        }
    }
}