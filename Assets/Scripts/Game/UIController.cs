using System;
using TMPro;
using UnityEngine;

namespace Game
{
    public class UIController : MonoBehaviour
    {
        public TextMeshProUGUI unitCounterText;
        
        public GameObject gameUI;
        public GameObject shopUI;
        private BattleStats _battleStats;

        private bool pauseBypass = true;
        
        private void Start()
        {
            _battleStats = GetComponent<BattleStats>();
        }

        public void UpdateGameUI()
        {
            unitCounterText.text = "Allies: " + _battleStats.GetAllyCount() + 
                                   "\nEnemies: " + _battleStats.GetEnemyCount() + 
                                   "\nCoins: " + _battleStats.GetCoins();
            
            if (_battleStats.GetAllyCount() <= 0 || _battleStats.GetEnemyCount() <= 0 && pauseBypass)
            {
                PauseGame();
            }
        }

        public void ShowShopUI()
        {
            gameUI.SetActive(false);
            shopUI.SetActive(true);
        }

        public void ShowGameUI()
        {
            shopUI.SetActive(false);
            gameUI.SetActive(true);
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
            ShowShopUI();
        }
        
        public void ResumeGame()
        {
            pauseBypass = false;
            Debug.Log("Button Clicked");
            Time.timeScale = 1;
            ShowGameUI();
        }
    }
}
