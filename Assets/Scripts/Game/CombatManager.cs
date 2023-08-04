using Units;
using UnityEngine;

namespace Game
{
    public class CombatManager : MonoBehaviour
    {
        private GameController _gameController;

        private void Start()
        {
            _gameController = GetComponent<GameController>();
        }


        public void Attack(UnitStats attacker, UnitStats target, double damage)
        {
            if (attacker != default)
            {
                if (!attacker.CanAttack()) return;
                attacker.UseAttack();
            }
            target.DoDamage(damage);
            
            if (target.GetHealth() > 0) return;
            Debug.Log(target.GetGameObject().name + " died");
            var isEnemy = target.CompareTag("Enemy");
            target.Die();
            _gameController.HandleUnitDeath(isEnemy);
        }
    }
}