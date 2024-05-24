using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPause : MonoBehaviour
{
    public GameObject pause;
    public bool isPaused = false;

    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused =!isPaused;
            if (isPaused == true)
            {
                pause.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
            else
            {
                
                pause.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
            }
           
        }
    }
}
