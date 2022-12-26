using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellerMovement : MonoBehaviour
{
    private Animator _animator;
    private bool _firstCollide = false;

    void Start()
    {
        _animator = this.transform.parent.gameObject.GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Customer")
        {
            _animator.SetBool("isTakingMoney", true);
            StartCoroutine("StopTakingMoney");

            if (!_firstCollide)
            {
                GameManager.Instance.MoneyPerSecond = 1;
                _firstCollide = true;
            }
        }
    }


    IEnumerator StopTakingMoney()
    {
        yield return new WaitForSeconds(0.2f);
        _animator.SetBool("isTakingMoney", false);
    }
}
