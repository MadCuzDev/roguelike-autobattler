using System;
using Units;
using UnityEngine;
using UnityEngine.AI;

namespace Game
{
    public class SpawnController : MonoBehaviour
    {
        public GameObject unitPrefab;
        public Material allyMat;
        public Material enemyMat;

        private int _enemyCount = 7;
        private int _allyCount = 10;

        private const float BaseAllySpeed = 4;
        private const float BaseAllyAcceleration = 8;
        private const float BaseAllyAngularSpeed = 120;
        private const float BaseAllyAttackSpeed = 1000;
        private const float BaseAllyAttackDamage = 1;

        private float _allySpeed = 1;
        private float _allyAttackSpeed = 1;
        private float _allyAttackDamage = 1;
        
        private int _wave;

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
            _wave++;
            RespawnPlayer();
            for (var i = 0; i < _allyCount; i++)
            {
                var allyUnit = Instantiate(unitPrefab);
                allyUnit.transform.position = new Vector3((i*2)-_allyCount, 1, -10);
                allyUnit.GetComponent<Renderer>().material = allyMat;
                allyUnit.GetComponent<NavMeshAgent>().speed = BaseAllySpeed * _allySpeed;
                allyUnit.GetComponent<NavMeshAgent>().acceleration = BaseAllyAcceleration * _allySpeed;
                allyUnit.GetComponent<NavMeshAgent>().angularSpeed = BaseAllyAngularSpeed * _allySpeed;
                allyUnit.GetComponent<UnitStats>().SetAttackDelay((int)(BaseAllyAttackSpeed * _allyAttackSpeed));
                allyUnit.GetComponent<UnitStats>().SetAttackDamage(BaseAllyAttackDamage * _allyAttackDamage);
                allyUnit.tag = "Ally";
            }

            var enemiesToSpawn = _enemyCount + _wave;
            for (var i = 0; i < enemiesToSpawn; i++)
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

        public void IncreaseUnitSpeed(float amount)
        {
            _allySpeed += amount;
        }

        public void IncreaseUnitAttackSpeed(float amount)
        {
            _allyAttackSpeed *= amount;
        }
        
        public void IncreaseUnitAttackDamage(float amount)
        {
            _allyAttackDamage += amount;
        }
    }
}