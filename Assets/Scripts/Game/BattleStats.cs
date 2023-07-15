using System.Linq;
using Units;
using UnityEngine;

namespace Game
{
    public class BattleStats : MonoBehaviour
    {
        private int _coins = 0;
        
        public int GetAllyCount()
        {
            return GameObject.FindGameObjectsWithTag("Ally").Length;
        }

        public int GetEnemyCount()
        {
            return GameObject.FindGameObjectsWithTag("Enemy").Length;
        }
        
        public int GetCoins()
        {
            return _coins;
        }

        public void AddCoins(int value)
        {
            _coins += value;
        }
    }
}
