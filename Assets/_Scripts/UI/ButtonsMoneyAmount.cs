using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonsMoneyAmount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _incomeButtonAmount, _increaseProductionSpeedButtonAmount, _addNewSellerButtonAmount;
    private Button _incomeButton, _speedButton, _sellerButton;
    private float _incomeStartValue = 5, _speedStartValue = 10, _sellerStartValue = 1000;

    void Start()
    {
        _incomeButtonAmount.text = _incomeStartValue.ToString();
        _increaseProductionSpeedButtonAmount.text = _speedStartValue.ToString();
        _addNewSellerButtonAmount.text = _sellerStartValue.ToString();

        StringEdit(_incomeStartValue, _incomeButtonAmount.gameObject);
        StringEdit(_speedStartValue, _increaseProductionSpeedButtonAmount.gameObject);
        StringEdit(_sellerStartValue, _addNewSellerButtonAmount.gameObject);

        _incomeButton = _incomeButtonAmount.transform.parent.transform.parent.GetComponent<Button>();
        _speedButton = _increaseProductionSpeedButtonAmount.transform.parent.transform.parent.GetComponent<Button>();
        _sellerButton = _addNewSellerButtonAmount.transform.parent.transform.parent.GetComponent<Button>();
    }


    private void Update()
    {
        if (GameManager.Instance.Money >= _incomeStartValue)
        {
            _incomeButton.interactable = true;
        }
        else _incomeButton.interactable = false;

        if (GameManager.Instance.Money >= _speedStartValue)
        {
            _speedButton.interactable = true;
        }
        else _speedButton.interactable = false;

        if (GameManager.Instance.Money >= _sellerStartValue && GameManager.Instance.SellerLevel < 3)
        {
            _sellerButton.interactable = true;
        }
        else _sellerButton.interactable = false;

    }


    public void LevelUp(GameObject buttonObj, float multiplier)
    {
        var textObj = buttonObj.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        float updatedValue;
        float oldValue;

        if (textObj.name.Contains("Income"))
        {
            oldValue = _incomeStartValue;
            updatedValue = _incomeStartValue * multiplier;
            _incomeStartValue = updatedValue;
        }
        else if (textObj.name.Contains("Speed"))
        {
            oldValue = _speedStartValue;
            updatedValue = _speedStartValue * multiplier;
            _speedStartValue = updatedValue;
        }
        else
        {
            oldValue = _sellerStartValue;
            updatedValue = _sellerStartValue * multiplier;
            _sellerStartValue = updatedValue;
        }

        StringEdit(updatedValue, textObj);


        //GameManager.Instance.Money -= updatedValue - multiplier;
        GameManager.Instance.Money -= oldValue;
    }


    private void StringEdit(float value, GameObject textObject)
    {
        value = (int)(value);
        var textString = textObject.GetComponent<TextMeshProUGUI>().text;
        if (value < 1000)   //1K dan küçük ise ise
        {
            textString = value.ToString();
        }
        else if (value >= 1000 && value < 1000000)   //1K ile 1M ile arasında ise
        {
            textString = ((value) / 1000).ToString("F1") + "K";
        }
        else if (value / 1000 >= 1000) //1M den büyük ise
        {
            textString = ((value) / 1000000f).ToString("F1") + "M";
        }

        textObject.GetComponent<TextMeshProUGUI>().text = textString;
    }
}
