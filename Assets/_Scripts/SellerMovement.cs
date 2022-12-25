using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellerMovement : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = this.transform.parent.gameObject.GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Customer")
        {
            _animator.SetBool("isTakingMoney", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Customer")
        {
            _animator.SetBool("isTakingMoney", false);
            Destroy(other.gameObject.GetComponent<BoxCollider>());
        }
    }
}
