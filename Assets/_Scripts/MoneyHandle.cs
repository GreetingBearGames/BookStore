using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyHandle : MonoBehaviour
{
    private IEnumerator Start()
    {
        while (true)
        {
            GameManager.Instance.Money += MoneyPerSecond();
            yield return new WaitForSeconds(1);
        }
    }
    public float MoneyPerSecond()
    {
        GameManager.Instance.MoneyPerSecond = GameManager.Instance.BookValue * GameManager.Instance.CustomerPerSecond * GameManager.Instance.ProductPerSecond;
        return GameManager.Instance.MoneyPerSecond;
    }
}
