using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyHandle : MonoBehaviour {
    private IEnumerator Start() {
        while(true){
            yield return new WaitForSeconds(1);
            GameManager.Instance.Money += GameManager.Instance.MoneyPerSecond;
        }
    }
}
