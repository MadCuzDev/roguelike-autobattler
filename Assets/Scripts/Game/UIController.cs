using System;
using TMPro;
using UnityEngine;

namespace Game
{
    public class UIController : MonoBehaviour
    {
        public TextMeshProUGUI allyCounterText;
        public TextMeshProUGUI enemyCounterText;
        public TextMeshProUGUI coinCounterText;
        
        public GameObject gameUI;
        public GameObject shopUI;
        private BattleStats _battleStats;
        private SpawnController _spawnController;

        private bool _isPaused;
        
        private void Start()
        {
            _battleStats = GetComponent<BattleStats>();
            _spawnController = GetComponent<SpawnController>();
        }

        public void UpdateGameUI()
        {
            if (_isPaused)
            {
                var counts = _spawnController.GetSpawnCounts();
                allyCounterText.text = "Allies: " +  counts[0];
                enemyCounterText.text = "Enemies: " + counts[1];
            }
            else
            {
                allyCounterText.text = "Allies: " + _battleStats.GetAllyCount();
                enemyCounterText.text = "Enemies: " + _battleStats.GetEnemyCount();
            }

            coinCounterText.text = "Coins: " + _battleStats.GetCoins();

            if (_isPaused || _battleStats.GetAllyCount() > 0 && _battleStats.GetEnemyCount() > 0) return;
            _isPaused = true;
            _spawnController.KillAllUnits();
            PauseGame();
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
            _isPaused = true;
            Debug.Log("Button Clicked");
            Time.timeScale = 1;
            ShowGameUI();
            _spawnController.SpawnUnits();
            _isPaused = false;
        }

        public void UpgradeUnitCount()
        {
            var coins = _battleStats.GetCoins();
            if (coins < 10) return;
            
            _battleStats.AddCoins(-10);
            _spawnController.IncreaseUnitCount(1, true);
        }
        
        public void UpgradeUnitSpeed()
        {
            var coins = _battleStats.GetCoins();
            if (coins < 5) return;
            
            _battleStats.AddCoins(-5);
            _spawnController.IncreaseUnitSpeed(.25f);
        }

        public void UpgradeUnitAttackSpeed()
        {
            var coins = _battleStats.GetCoins();
            if (coins < 5) return;
            
            _battleStats.AddCoins(-5);
            _spawnController.IncreaseUnitAttackSpeed(.8f);
        }
        
        public void UpgradeUnitAttackDamage()
        {
            var coins = _battleStats.GetCoins();
            if (coins < 5) return;
            
            _battleStats.AddCoins(-5);
            _spawnController.IncreaseUnitAttackDamage(.25f);
        }
    }
}
