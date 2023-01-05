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


        if (mps < 1000)   //1K dan küçük ise ise
        {
            _moneyPerSecValue = ((int)(mps)).ToString();
        }
        else if (mps >= 1000 && mps < 1000000)   //1K ile 1M arasında ise
        {
            _moneyPerSecValue = (mps / 1000).ToString("F1") + "K";
        }
        else if (mps >= 1000000 && mps < 1000000000) //1M ile 1B arasında ise
        {
            _moneyPerSecValue = (mps / 1000000f).ToString("F1") + "M";
        }
        else if (mps >= 1000000000) //1B den büyük ise
        {
            _moneyPerSecValue = (mps / 1000000000f).ToString("F1") + "B";
        }

        _moneyPerSecText.text = "$" + _moneyPerSecValue + " / sec";


        //MONEY VALUE
        var m = GameManager.Instance.Money;
        _moneyValue = m.ToString("F1");

        if (m >= 1000 && m < 1000000)   //1K ile 1M arasında ise
        {
            _moneyValue = (m / 1000).ToString("F1") + "K";
        }
        else if (m >= 1000000 && m < 1000000000) //1M ile 1B arasında ise
        {
            _moneyValue = (m / 1000000f).ToString("F1") + "M";
        }
        else if (m >= 1000000000) //1B den büyük ise
        {
            _moneyValue = (m / 1000000000f).ToString("F1") + "B";
        }

        _moneyText.text = "$" + _moneyValue;



        //1.000 den büyükse 1K şeklinde
        //10.000 den büyükse 10K şeklinde
        //100.000 den büyükse 100K şeklinde
        //1.000.000 den büyükse 1M şeklinde
        //17654 --> /1000 = 17,6K
    }
}
