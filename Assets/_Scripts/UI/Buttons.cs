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
        buttonsMoneyAmount.LevelUp(_incomeButton.gameObject, 1.5f);
    }
    public void IncreaseProductionSpeed()
    {
        GameManager.Instance.ProductPerSecond *= 1.2f;
        _speedLvl++;
        GameManager.Instance.ProductionLevel = _speedLvl;
        SoundManager.instance.Play("Button Sound");
        buttonsMoneyAmount.LevelUp(_increaseProductionSpeedButton.gameObject, 1.5f);
    }
    public void AddNewSeller()
    {
        _sellerCountLvl++;
        if (_sellerCountLvl == 3)
        {
            _addNewSellerButton.interactable = false;
        }
        GameManager.Instance.CustomerPerSecond *= _sellerCountLvl;
        SoundManager.instance.Play("Button Sound");
        buttonsMoneyAmount.LevelUp(_addNewSellerButton.gameObject, 1.5f);
    }
}
