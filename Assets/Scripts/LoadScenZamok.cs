using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenZamok : MonoBehaviour
{
    public OpenScenes LoadScen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            {
            SceneManager.LoadScene(2);
            /*if (Input.GetKeyDown(KeyCode.F))
            {
                
            }*/
        }
    }
}
