using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainIslandPortal : MonoBehaviour
{
    public GameObject player;
    public Vector3 housePosition;
    public Vector3 islandPosition;
 
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.position = housePosition;
        }
    }
}
