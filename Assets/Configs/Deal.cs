using System;
using UnityEngine;

[Serializable]
public class Deal
{
    public string Name;
    public float Delay;
    public float BasicCost;
    public float BasicIncome;
    public int Level;

    public string UpgradeName1;
    public float UpgradeCost1;
    public float UpgradeMultiplier1;
    public bool HasUpgrade1;

    public string UpgradeName2;
    public float UpgradeCost2;
    public float UpgradeMultiplier2;
    public bool HasUpgrade2;
}
