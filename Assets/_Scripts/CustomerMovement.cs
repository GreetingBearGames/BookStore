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
        _animator.SetFloat("cycleOffst", Random.Range(0f, 0.99f));
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
            // AnimationName["ClipName"].time = Random.Range(0f, AnimationName["ClipName"].length)

            _animator.SetBool("isWalking", false);
            _animator.SetBool("isTurning", true);
            _isCollided = true;
        }
    }
}
