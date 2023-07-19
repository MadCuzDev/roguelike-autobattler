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
            foreach (var target in (UnitStats[])FindObjectsOfType(typeof(UnitStats)))
            {
                var targetPos = target.GetLocation();
                var pos = gameObject.transform.position;
                if (location != default)
                {
                    if (Vector3.Distance(pos, targetPos) <
                        Vector3.Distance(pos, location))
                    {
                        if (target.IsAlly() != _isAlly) location = targetPos;
                    }
                }
                else
                {
                    if (target.IsAlly() != _isAlly) location = targetPos;
                }

                if (Vector3.Distance(pos, targetPos) < 0.5 && target.IsAlly() != _isAlly)
                {
                        _combatManager.Attack(gameObject.GetComponent<UnitStats>(), target, gameObject.GetComponent<UnitStats>().GetAttackDamage());
                }
            }
        
            _agent.SetDestination(location);
        }
    }
}
