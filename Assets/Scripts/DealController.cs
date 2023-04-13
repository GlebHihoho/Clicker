using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealController : MonoBehaviour
{
    [SerializeField] DealConfig dealConfig;
    [SerializeField] BalanceController balanceController;

    private float _delay;

    private void Start()
    {
        InvokeRepeating("UpdateBalance", 0f, dealConfig.deal.Delay);
    }

    private void UpdateBalance()
    {
        float currentIncome = GetCurrentIncome();

        balanceController.Append(currentIncome);
    }

    public void UpdateLvl(Action CallBack)
    {
        float currentBalance = balanceController.GetBalance();
        float currentLvlCost = GetCurrentLvlCoast();

        if (currentBalance >= currentLvlCost)
        {
            dealConfig.deal.Level += 1;
            balanceController.Subtract(currentLvlCost);
            CallBack();
        }
    }

    public void BuyFirstUpgrade(Action CallBack)
    {
        if (dealConfig.deal.HasUpgrade1) return;

        float currentBalance = balanceController.GetBalance();

        if (currentBalance >= dealConfig.deal.UpgradeCost1)
        {
            dealConfig.deal.HasUpgrade1 = true;
            balanceController.Subtract(dealConfig.deal.UpgradeCost1);
            CallBack();
        }
    }

    public void BuySecondUpgrade(Action CallBack)
    {
        if (dealConfig.deal.HasUpgrade2) return;

        float currentBalance = balanceController.GetBalance();

        if (currentBalance >= dealConfig.deal.UpgradeCost2)
        {
            dealConfig.deal.HasUpgrade2 = true;
            balanceController.Subtract(dealConfig.deal.UpgradeCost2);
            CallBack();
        }
    }

    public float GetCurrentLvlCoast()
    {
        return (dealConfig.deal.Level + 1) * dealConfig.deal.BasicCost;
    }

    public float GetCurrentIncome()
    {
        float firstMultiply = dealConfig.deal.HasUpgrade1 ? dealConfig.deal.UpgradeMultiplier1 * 0.01f : 0;
        float secondMultiply = dealConfig.deal.HasUpgrade2 ? dealConfig.deal.UpgradeMultiplier2 * 0.01f : 0;

        return dealConfig.deal.Level * dealConfig.deal.BasicIncome * (1 + firstMultiply + secondMultiply);
    }
}
