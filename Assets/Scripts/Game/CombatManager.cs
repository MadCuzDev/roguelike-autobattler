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
            if (!attacker.CanAttack()) return;
            target.DoDamage(damage);
            attacker.UseAttack();

            if (target.GetHealth() > 0) return;
            Debug.Log(target.GetGameObject().name + " died");
            var isEnemy = target.CompareTag("Enemy");
            target.Die();
            _gameController.HandleUnitDeath(isEnemy);
        }
    }
}