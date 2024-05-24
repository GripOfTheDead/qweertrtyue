using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private Vector3 vectorStart;
    private Vector3 vectorEnd;
    public Transform startMarker;
    public Transform endMarker;
    public GameObject slime;
    // Start is called before the first frame update
    void Start()
    {
        vectorStart = new Vector3(128f, 92f, 111f);
        vectorEnd = new Vector3(128f, 82f, 111f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!slime)
        {
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, Time.deltaTime);
        }
    }
}
