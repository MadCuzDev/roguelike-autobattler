using System.Threading.Tasks;
using Game;
using Units;
using Unity.VisualScripting;
using UnityEngine;

namespace Skills
{
    public class Bullet : MonoBehaviour
    {
        private float speed = 20f;

        private void Start()
        {
            gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;
            transform.parent = null;
            DestroyTimer();
        }

        private async void DestroyTimer()
        {
            await Task.Delay(10000);
            try
            {
                Destroy(gameObject);
            }
            catch (MissingReferenceException)
            {
                // Ignored
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.GetComponent<UnitStats>() != null && collision.collider.gameObject.CompareTag("Enemy"))
            {
                GameObject.Find("Canvas").GetComponent<CombatManager>().Attack(default, collision.collider.GetComponent<UnitStats>(), 1);
            }
            Destroy(gameObject);
        }
    
    }
}