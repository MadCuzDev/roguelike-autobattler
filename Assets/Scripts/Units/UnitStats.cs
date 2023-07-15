using System.Threading.Tasks;
using UnityEngine;

namespace Units
{
    public class UnitStats : MonoBehaviour
    {
        private double _health = 3;
        private bool _canAttack = true;
        
        public void UseAttack()
        {
            _canAttack = false;
            Task.Delay(1000).ContinueWith(_=> _canAttack = true);
        }

        public bool CanAttack()
        {
            return _canAttack;
        }

        public Vector3 GetLocation()
        {
            return gameObject.transform.position;
        }

        public bool IsAlly()
        {
            return gameObject.CompareTag("Ally");
        }

        public double GetHealth()
        {
            return _health;
        }

        public void DoDamage(double healthDif)
        {
            _health -= healthDif;
        }

        public GameObject GetGameObject()
        {
            return gameObject;
        }

        public void Die()
        {
            Destroy(gameObject);
            Destroy(this);
        }
    }
}
