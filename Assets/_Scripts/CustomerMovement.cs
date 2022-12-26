using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    private Animator _animator;
    private bool _isCollided = false;
    [SerializeField] private GameObject _humanExplodeParticle;

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
            _isCollided = true;
            StartCoroutine("DestroyHuman");
        }
    }

    IEnumerator DestroyHuman()
    {
        yield return new WaitForSeconds(1);
        var particleCreatePos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        GameObject particle = Instantiate(_humanExplodeParticle, particleCreatePos, Quaternion.identity);
        particle.GetComponent<ParticleSystem>().Play();

        yield return new WaitForSeconds(0.1f);
        Destroy(this.transform.parent.gameObject);
    }
}
