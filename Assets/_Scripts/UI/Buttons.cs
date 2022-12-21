using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Button _incomeButton, _increaseProductionSpeedButton, _addNewSellerButton;
    //Decide values while thinking on game maths
    public void IncreaseIncome(){
        GameManager.Instance.MoneyPerSecond += 1.0f;
    }
    public void IncreaseProductionSpeed(){
        GameManager.Instance.ProductPerSecond += 1.0f;
    }
    public void AddNewSeller(){
        GameManager.Instance.CustomerPerSecond += 1.0f;
    }
}
