using UnityEngine;
using UnityEngine.AI;

namespace Game
{
    public class SpawnController : MonoBehaviour
    {
        public GameObject unitPrefab;
        public Material allyMat;
        public Material enemyMat;

        private int _enemyCount = 10;
        private int _allyCount = 10;
        private int _allySpeed = 4;
        private int _allyAcceleration = 8;

        private GameObject _allyPrefab;
        private GameObject _enemyPrefab;

        private void Start()
        {
            SpawnUnits();
        }

        public int[] GetSpawnCounts()
        {
            return new[] { _allyCount, _enemyCount };
        }

        public void SpawnUnits()
        {
            RespawnPlayer();
            for (var i = 0; i < _allyCount; i++)
            {
                var allyUnit = Instantiate(unitPrefab);
                allyUnit.transform.position = new Vector3((i*2)-_allyCount, 1, -10);
                allyUnit.GetComponent<Renderer>().material = allyMat;
                allyUnit.GetComponent<NavMeshAgent>().speed = _allySpeed;
                allyUnit.GetComponent<NavMeshAgent>().acceleration = _allyAcceleration + (_allySpeed * 2);
                allyUnit.tag = "Ally";
            }
            
            for (var i = 0; i < _enemyCount; i++)
            {
                var enemyUnit = Instantiate(unitPrefab);
                enemyUnit.transform.position = new Vector3((i*2)-_enemyCount, 1, 30);
                enemyUnit.GetComponent<Renderer>().material = enemyMat;
                enemyUnit.tag = "Enemy";
            }
        }

        private void RespawnPlayer()
        {
            var player = GameObject.Find("Player");
            player.transform.position = new Vector3(0, 2, 0);
            player.GetComponent<NavMeshAgent>().ResetPath();
        }

        public void KillAllUnits()
        {
            foreach (var o in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(o);
            }
            
            foreach (var o in GameObject.FindGameObjectsWithTag("Ally"))
            {
                Destroy(o);
            }
        }

        public void IncreaseUnitCount(int amount, bool isAlly)
        {
            if (isAlly) _allyCount += amount;
            else _enemyCount += amount;
        }

        public void IncreaseUnitSpeed(int amount)
        {
            _allySpeed += amount;
        }
    }
}