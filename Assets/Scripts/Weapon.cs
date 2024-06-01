using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public GameObject bulletFire;
    public GameObject bulletWinter;

    public Camera mainCamera;
    public Transform spawnBulletFire;
    public Transform spawnBulletWinter;
    public Slider manaSlider;
    public AudioSource fireAudio;
    public AudioSource winterAudio;

    public ChangeItemPosoh _idPosoh;
    //public EnemyScript enemyScript;

    public int Damage = 10;
    public float shootForce;


    void Update()
    {
        manaSlider.value += 0.5f;
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

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
        if (manaSlider.value >= 30)
        {
            if (bulletFire || bulletWinter)
            {
                if (_idPosoh.currentQuickSlotID == 0)
                {
                    if (IdPosoh._isFire)
                    {
                        fireAudio.Play();
                        Vector3 targetPoint;
                        if (Physics.Raycast(ray, out hit))
                            targetPoint = hit.point;
                        else
                            targetPoint = ray.GetPoint(75);
                        Vector3 dirWithoutSpread = targetPoint - spawnBulletFire.position;
                        GameObject currentBullet = Instantiate(bulletFire, spawnBulletFire.position, Quaternion.identity);
                        currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce, ForceMode.Impulse);
                        manaSlider.value -= 15;
                    }
                }
                else if (_idPosoh.currentQuickSlotID == 1)
                {
                    if (IdPosoh._isWinter)
                    {
                        winterAudio.Play();
                        Vector3 targetPoint;
                        if (Physics.Raycast(ray, out hit))
                            targetPoint = hit.point;
                        else
                            targetPoint = ray.GetPoint(75);
                        Vector3 dirWithoutSpread = targetPoint - spawnBulletWinter.position;
                        GameObject currentBullet = Instantiate(bulletWinter, spawnBulletWinter.position, Quaternion.identity);
                        currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce, ForceMode.Impulse);
                        manaSlider.value -= 25;
                    }

                }
            }
        }
    }
}
