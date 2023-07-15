using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI unitCounterText;

    private BattleStats _battleStats;

    private void Start()
    {
        _battleStats = GetComponent<BattleStats>();
    }

    // Update is called once per frame
    void Update()
    {
        unitCounterText.text = "Allies: " + _battleStats.GetAllyCount(true) + "\nEnemies: " +
                               _battleStats.GetAllyCount(false);
    }
}
