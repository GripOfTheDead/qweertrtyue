using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScenePosleKillBoss : MonoBehaviour
{
    public Slider healthBAr;

    void Start()
    {
        
    }

   
    void Update()
    {
        if (healthBAr.value <= 0)
        {
            SceneManager.LoadScene("EndGame");
            
        }
    }
}
