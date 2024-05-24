using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTruger : MonoBehaviour
{
    public GameObject item;

    void Start()
    {

    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            item.SetActive(true);
        }
    }
}
