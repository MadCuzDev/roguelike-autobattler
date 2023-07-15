using Game;
using UnityEngine;
using UnityEngine.AI;

namespace Units
{
    public class UnitAI : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private bool _isAlly;
        private CombatManager _combatManager;

        private void Start()
        {
            _combatManager = GameObject.Find("Canvas").GetComponent<CombatManager>();
            _agent = GetComponent<NavMeshAgent>();
            _isAlly = gameObject.CompareTag("Ally");
        }

        private void Update()
        {
            Vector3 location = default;
            foreach (var unitStats in (UnitStats[])FindObjectsOfType(typeof(UnitStats)))
            {
                var targetPos = unitStats.GetLocation();
                var pos = gameObject.transform.position;
                if (location != default)
                {
                    if (Vector3.Distance(pos, targetPos) <
                        Vector3.Distance(pos, location))
                    {
                        if (unitStats.IsAlly() != _isAlly) location = targetPos;
                    }
                }
                else
                {
                    if (unitStats.IsAlly() != _isAlly) location = targetPos;
                }

                if (Vector3.Distance(pos, targetPos) < 0.5 && unitStats.IsAlly() != _isAlly)
                {
                        _combatManager.Attack(gameObject.GetComponent<UnitStats>(), unitStats, 1);
                }
            }
        
            _agent.SetDestination(location);
        }
    }
}
