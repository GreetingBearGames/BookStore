using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    private Animator _animator;
    private bool _isCollided = false;
    void Start()
    {
        _animator = this.transform.parent.gameObject.GetComponent<Animator>();
        _animator.SetBool("isWalking", true);
        _animator.SetFloat("cycleOffst", Random.Range(0f, 0.99f));  //her bir instance'ın farklı yürüme başlangıç noktaları
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SellerDesk" && !_isCollided)
        {
            this.GetComponent<BoxCollider>().isTrigger = true;
            _animator.SetBool("isWaiting", true);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isTurning", true);
            _isCollided = true;
        }
    }
}
