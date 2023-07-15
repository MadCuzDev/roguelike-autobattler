using System;
using Units;
using UnityEngine;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        private BattleStats _battleStats;
        private UIController _uiController;


        private void Start()
        {
            _battleStats = GetComponent<BattleStats>();
            _uiController = GetComponent<UIController>();
        }

        private void Update()
        {
            _uiController.UpdateGameUI();
        }

        public void HandleUnitDeath(bool isEnemy)
        {
            if (isEnemy) _battleStats.AddCoins(1);
        }
    }
}
