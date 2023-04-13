using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class ViewController : MonoBehaviour
{
    [SerializeField] DealConfig dealConfig;
    [SerializeField] DealController dealController;

    [SerializeField] TextMeshProUGUI _dealNameLabel;
    [SerializeField] TextMeshProUGUI _lvlLabel;
    [SerializeField] TextMeshProUGUI _incomeLabel;
    [SerializeField] Slider _slider;
    [SerializeField] Button _updateLvlButton;
    [SerializeField] Button _upgradeButton1;
    [SerializeField] Button _upgradeButton2;

    private bool isSliderStart = false;

    private void Start() {
        _dealNameLabel.text = dealConfig.deal.Name;

        _lvlLabel.text = "LVL " + dealConfig.deal.Level.ToString();
        _incomeLabel.text = dealController.GetCurrentIncome().ToString() + " $";

        _updateLvlButton.GetComponentInChildren<TextMeshProUGUI>().text =
            "LVL UP " + dealController.GetCurrentLvlCoast().ToString() + " $";

        _upgradeButton1.GetComponentInChildren<TextMeshProUGUI>().text =
            "'" + dealConfig.deal.UpgradeName1 + "'" +
            " Доход:" + dealConfig.deal.UpgradeMultiplier1.ToString() + " % " +
            " Цена:" + dealConfig.deal.UpgradeCost1.ToString() + " $ " +
            (dealConfig.deal.HasUpgrade1 ? "Куплено" : "Купить");

        _upgradeButton2.GetComponentInChildren<TextMeshProUGUI>().text =
            "'" + dealConfig.deal.UpgradeName2 + "'" +
            " Доход:" + dealConfig.deal.UpgradeMultiplier2.ToString() + " % " +
            " Цена:" + dealConfig.deal.UpgradeCost2.ToString() + " $ " +
            (dealConfig.deal.HasUpgrade2 ? "Куплено" : "Купить");

        _updateLvlButton.onClick.AddListener(() => dealController.UpdateLvl(UpdateLvlCb));
        _upgradeButton1.onClick.AddListener(() => dealController.BuyFirstUpgrade(BuyFirstUpgradeCb));
        _upgradeButton2.onClick.AddListener(() => dealController.BuySecondUpgrade(BuySecondUpgradeCb));

        // TODO
        // if (dealConfig.deal.Level != 0)
        // {
        //     isSliderStart = true;
        //     StartSliderAnimation();
        // }
        StartSliderAnimation();
    }

    // private void Update() {
    //     // TODO
    //     if (!isSliderStart) return;
    //     if (dealConfig.deal.Level != 0) return;

    //     StartSliderAnimation();
    // }

    private void UpdateLvlCb()
    {
        isSliderStart = true;

        _lvlLabel.text = dealConfig.deal.Level.ToString();
        _incomeLabel.text = dealController.GetCurrentIncome().ToString();
        _updateLvlButton.GetComponentInChildren<TextMeshProUGUI>().text =
            "LVL UP " + dealController.GetCurrentLvlCoast().ToString() + " $";
    }

    private void StartSliderAnimation()
    {
        print("StartSliderAnimation");
        DOTween
            .To(() => 0, x => _slider.value = x, 100, dealConfig.deal.Delay)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);
    }

    private void BuyFirstUpgradeCb()
    {
        _incomeLabel.text = dealController.GetCurrentIncome().ToString();
        _upgradeButton1.GetComponentInChildren<TextMeshProUGUI>().text =
            "'" + dealConfig.deal.UpgradeName1 + "'" +
            " Доход:" + dealConfig.deal.UpgradeMultiplier1.ToString() + " % " +
            "Куплено";
    }

    private void BuySecondUpgradeCb()
    {
        _incomeLabel.text = dealController.GetCurrentIncome().ToString();
        _upgradeButton2.GetComponentInChildren<TextMeshProUGUI>().text =
            "'" + dealConfig.deal.UpgradeName2 + "'" +
            " Доход:" + dealConfig.deal.UpgradeMultiplier2.ToString() + " % " +
            "Куплено";
    }
}
