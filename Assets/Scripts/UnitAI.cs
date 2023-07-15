using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class UnitAI : MonoBehaviour
{
    private NavMeshAgent _agent;
    private bool _isAlly;
    private CombatManager _combatManager;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _isAlly = gameObject.CompareTag("Ally");
    }

    private void Update()
    {
        Vector3 location = default;
        var targets = FindObjectsOfType(typeof(UnitStats));
        foreach (var target in targets)
        {
            var unitStats = (UnitStats)target;
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
                if (gameObject.GetComponent<UnitStats>().CanAttack())
                    CombatManager.Attack(gameObject.GetComponent<UnitStats>(), unitStats, 1);
            }
        }
        
        _agent.SetDestination(location);
    }
}
