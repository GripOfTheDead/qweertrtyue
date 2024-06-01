using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CameraRayCast : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public bool keyInHands;
    public float _distanceHit = 2;
    public Vector3 positionCamera;
    public Vector3 moveTransformCamera;
    private RaycastHit hit;
    private Ray ray;
    [SerializeField] private Inventorymanager manager;
    private bool _isFire;
    private bool _isWinter;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        positionCamera = mainCamera.transform.position;
        moveTransformCamera = mainCamera.transform.forward;
       
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (Physics.Raycast(positionCamera, moveTransformCamera, out hit, _distanceHit) || Physics.Raycast(ray, out hit, _distanceHit))
            {
                if (hit.collider.gameObject.GetComponent<Posoh>() != null)
                {
                    if (hit.collider.gameObject.GetComponent<Posoh>().number == 0) _isFire = true;
                    else _isWinter = true;
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
