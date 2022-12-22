using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyHandle : MonoBehaviour {
    private IEnumerator Start() {
        while(true){
            yield return new WaitForSeconds(1);
            GameManager.Instance.Money += MoneyPerSecond();
        }
    }
    public float MoneyPerSecond(){
        GameManager.Instance.MoneyPerSecond = GameManager.Instance.BookValue * GameManager.Instance.CustomerPerSecond * GameManager.Instance.ProductPerSecond;
        return GameManager.Instance.MoneyPerSecond;
    }
    private void Update() {
        MoneyPerSecond();
    }
}
