using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shoot : MonoBehaviour
{
    public float bulletLife = 1;
    public int damageAmount = 20;
    void Awake()
    {
        Destroy(gameObject, bulletLife);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<EnemyScript>().TakeDamage(damageAmount);
            Destroy(transform.gameObject);

        }
    }
}