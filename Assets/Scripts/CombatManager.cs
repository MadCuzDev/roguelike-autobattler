using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Attack(UnitStats attacker, UnitStats target, double damage)
    {
        target.DoDamage(damage);
        attacker.UseAttack();
        if (target.GetHealth() <= 0)
        {
            Destroy(target.GetGameObject());
        }
    }
}
