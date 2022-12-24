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
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Seller" && !_isCollided)
        {
            Destroy(this.GetComponent<BoxCollider>());
            _animator.SetBool("isWaiting", true);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isTurning", true);
            _isCollided = true;
        }
    }
}
