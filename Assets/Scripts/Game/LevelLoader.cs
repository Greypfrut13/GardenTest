using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;

        private void Start()
        {
            _restartButton.onClick.AddListener(RestartLevel);
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}