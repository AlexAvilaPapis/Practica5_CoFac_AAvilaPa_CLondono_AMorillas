using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsUI : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI HealthPoints;
    public TextMeshProUGUI AttackPoints;
    public TextMeshProUGUI DefensePoints;

    private Fighter _fighter;
    
    void OnEnable()
    {
        Fighter.OnChange += OnStatsChange;
        ChooseTarget.OnSelected += SetEntity;
    }

    void OnDisable()
    {
        Fighter.OnChange -= OnStatsChange;
        ChooseTarget.OnSelected -= SetEntity;
    }

    public void SetEntity(Fighter fighter)
    {
        _fighter = fighter;
        UpdateStats(fighter);
    }

    private void OnStatsChange()
    {
        UpdateStats(_fighter);
    }

    void UpdateStats(Fighter fighter)
    {
        Name.text = fighter.transform.name;
        HealthPoints.text = "HP: "+fighter.CurrentHealth.ToString();
        AttackPoints.text = "ATT: " + fighter.Attack.ToString();
        DefensePoints.text = "DEF: " + fighter.Defense.ToString();
    }
}
