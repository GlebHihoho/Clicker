using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BalanceController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _balanceLabel;

    [SerializeField] private float _balance = 0;

    void Start()
    {
        _balanceLabel.text = "Balance: " + GetBalance().ToString() + " $";
    }

    public float GetBalance()
    {
        return _balance;
    }

    public void Subtract(float value)
    {
        _balance -= value;
        _balanceLabel.text = "Balance: " + GetBalance().ToString() + " $";
    }

    public void Append(float value)
    {
        _balance += value;
        _balanceLabel.text = "Balance: " + GetBalance().ToString() + " $";
    }
}
