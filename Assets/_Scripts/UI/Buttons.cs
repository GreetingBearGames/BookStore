using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Button _incomeButton, _increaseProductionSpeedButton, _addNewSellerButton;
    [SerializeField] private ButtonsMoneyAmount buttonsMoneyAmount;
    private int _incomeLvl = 1, _speedLvl = 1, _sellerCountLvl = 1;
    //Decide values while thinking on game maths
    public void IncreaseIncome()
    {
        _incomeLvl++;
        GameManager.Instance.BookValue = _incomeLvl;
        SoundManager.instance.Play("Button Sound");
        buttonsMoneyAmount.LevelUp(_incomeButton.gameObject, 10f);
    }
    public void IncreaseProductionSpeed()
    {
        _speedLvl++;
        GameManager.Instance.ProductPerSecond = _speedLvl;
        GameManager.Instance.ProductionLevel = _speedLvl;
        SoundManager.instance.Play("Button Sound");
        buttonsMoneyAmount.LevelUp(_increaseProductionSpeedButton.gameObject, 20f);
    }
    public void AddNewSeller()
    {
        _sellerCountLvl++;

        GameManager.Instance.SellerLevel = _sellerCountLvl;
        GameManager.Instance.CustomerPerSecond *= _sellerCountLvl;
        SoundManager.instance.Play("Button Sound");
        buttonsMoneyAmount.LevelUp(_addNewSellerButton.gameObject, 2);
    }
}
