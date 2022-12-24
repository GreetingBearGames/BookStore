using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerCreator : MonoBehaviour
{
    [SerializeField] private GameObject _customerPrefab;
    [SerializeField] private float creationDelay = 2f;
    private Vector3 _line1Pos;


    void Start()
    {
        var sellerPos = GameObject.FindGameObjectWithTag("Seller").transform.position;
        _line1Pos = new Vector3(sellerPos.x + 1.6f, 0, -24);    //seller'ın 1.6 birim sağında oluştur.
        InvokeRepeating("CreateCustomer", 0, creationDelay);
    }

    private void CreateCustomer()
    {
        var createdObj = Instantiate(_customerPrefab, _line1Pos, Quaternion.identity);
        createdObj.transform.parent = this.transform;
        Destroy(createdObj, 20);    //destroy after 20sec
    }

}
