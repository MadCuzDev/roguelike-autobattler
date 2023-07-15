using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    private double health = 3;
    private bool canAttack = true;
    
    private GameObject _gameObject;

    public void UseAttack()
    {
        canAttack = false;
        Task.Delay(1000).ContinueWith(t=> SetCanAttackTrue());
    }

    private void SetCanAttackTrue()
    {
        canAttack = true;
    }

    public bool CanAttack()
    {
        return canAttack;
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
        return health;
    }

    public void DoDamage(double healthDif)
    {
        health -= healthDif;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
