using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Camera mainCamera;
    public Transform spawnBullet;
    public Slider manaSlider;
    public AudioSource fireAudio;
    //public EnemyScript enemyScript;
     
    public int Damage = 10;
    public float shootForce;
    

    void Update()
    {
        manaSlider.value += 0.5f;
        if (Input.GetButtonDown("Fire1"))
            Shoot();
       
    }
    private void OnTriggerEnter(Collider other)
    {

        EnemyScript Enemy = other.GetComponent<EnemyScript>();
        if (Enemy != null)
        {
            Enemy.TakeDamage(Damage);
        }

        Destroy(gameObject); // Уничтожение объекта при столкновении
    }
    private void Shoot()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        
        if (manaSlider.value >= 0)
        {
            if (bullet)
            {
                fireAudio.Play();
                Vector3 targetPoint;
                if (Physics.Raycast(ray, out hit))
                    targetPoint = hit.point;
                else
                    targetPoint = ray.GetPoint(75);

                Vector3 dirWithoutSpread = targetPoint - spawnBullet.position;

                GameObject currentBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity);

                
                currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce, ForceMode.Impulse);
                manaSlider.value -= 15;

            }
        }
    }
}
