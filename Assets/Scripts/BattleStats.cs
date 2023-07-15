using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleStats : MonoBehaviour
{
    UnitStats[] GetUnitList()
    {
        return (UnitStats[])FindObjectsOfType(typeof(UnitStats));
    }

    public int GetAllyCount(bool allySearch)
    {
        var unitStatsList = GetUnitList();
        var allyCount = unitStatsList.Sum(unitStats => unitStats.CompareTag("Ally") ? 1 : 0);

        if (!allySearch) allyCount = unitStatsList.Length - allyCount;
        return allyCount;
    }
}
