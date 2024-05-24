using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public int HP = 100;
    public Animator animatok;
    public Slider healthBar;


    void Start()
    {

   
    }
    private void Update()
    {
        healthBar.value = HP;
        

    }
    bool CheckAniClip(string clipname)
    {
        if (this.GetComponent<Animation>().GetClip(clipname) == null)
            return false;
        else if (this.GetComponent<Animation>().GetClip(clipname) != null)
            return true;

        return false;
    }

    public void TakeDamage(int damageAmount)
    { 
        HP -= damageAmount;
            if (healthBar.value <= 0)
            {
            
                    GetComponent<Collider>().enabled = false;
                    healthBar.gameObject.SetActive(false);
                    Destroy(transform.gameObject);
            }
            else
            {

            }
        }
}
