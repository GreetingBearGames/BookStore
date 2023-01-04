using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CustomerCreator : MonoBehaviour
{
    [SerializeField] private GameObject _customerPrefab1, _customerPrefab2, _sellerPrefab;
    private GameObject[] customers = new GameObject[2];
    [SerializeField] private float creationDelay = 3f;
    private List<GameObject> _sellers = new List<GameObject>();
    private int _index = 0;

    private void Start()
    {
        AddNewSeller();
        InvokeRepeating("CreateCustomer", 0, creationDelay);
        customers[0] = _customerPrefab1;
        customers[1] = _customerPrefab2;
    }


    private void CreateCustomer()
    {
        for (int i = 0; i < _sellers.Count; i++)
        {
            if (_sellers[i] != null)
            {
                var createPos = new Vector3(_sellers[i].transform.position.x, 0, -24);
                var cretationObj = customers[Random.Range(0, 2)];
                var createdObj = Instantiate(cretationObj, createPos, Quaternion.identity);
                createdObj.transform.parent = this.transform;
                Destroy(createdObj, 20);    //destroy after 20sec
            }
        }
    }


    public void AddNewSeller()
    {
        if (_index == 0)
        {
            var createdObj = Instantiate(_sellerPrefab);
            _sellers.Insert(_index, createdObj);
        }
        else
        {
            var createPos = new Vector3(_sellers[_index - 1].transform.position.x - 3f,
                            _sellers[_index - 1].transform.position.y,
                            _sellers[_index - 1].transform.position.z);
            var createdObj = Instantiate(_sellerPrefab, createPos, Quaternion.Euler(0, 180, 0));
            _sellers.Insert(_index, createdObj);
        }

        _index++;
    }
}
