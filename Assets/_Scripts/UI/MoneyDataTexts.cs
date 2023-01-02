using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyDataTexts : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private TextMeshProUGUI _moneyPerSecText;

    // Update is called once per frame
    private void Update() {
        _moneyText.text = ((int)GameManager.Instance.Money).ToString();
        _moneyPerSecText.text = "$" + ((int)GameManager.Instance.MoneyPerSecond).ToString() + " / sec";
    }
}
