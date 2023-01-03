using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyDataTexts : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private TextMeshProUGUI _moneyPerSecText;
    private string _moneyPerSecValue, _moneyValue;

    // Update is called once per frame
    private void Update()
    {
        //MONEY PER SECOND VALUE
        var mps = GameManager.Instance.MoneyPerSecond;
        _moneyPerSecValue = mps.ToString("F1");

        if (mps >= 1000 && mps < 1000000)   //1K ile 1M ile arasında ise
        {
            _moneyPerSecValue = (mps / 1000).ToString("F1") + "K";
        }
        else if (mps / 1000 >= 1000) //1M den büyük ise
        {
            _moneyPerSecValue = (mps / 1000000f).ToString("F1") + "M";
        }

        _moneyPerSecText.text = "$" + _moneyPerSecValue + " / sec";


        //MONEY VALUE
        var m = GameManager.Instance.Money;
        _moneyValue = m.ToString("F1");

        if (m >= 1000 && m < 1000000)   //1K ile 1M ile arasında ise
        {
            _moneyValue = (m / 1000).ToString("F1") + "K";
        }
        else if (m / 1000 >= 1000) //1M den büyük ise
        {
            _moneyValue = (m / 1000000f).ToString("F1") + "M";
        }

        _moneyText.text = "$" + _moneyValue + " / sec";



        //1.000 den büyükse 1K şeklinde
        //10.000 den büyükse 10K şeklinde
        //100.000 den büyükse 100K şeklinde
        //1.000.000 den büyükse 1M şeklinde
        //17654 --> /1000 = 17,6K
    }
}
