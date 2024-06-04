using TMPro;
using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    Transform character;
    public float sensitivity = 2;
    public float smoothing = 1.5f;
    public Vector3 positionCamera;
    public Vector3 moveTransformCamera;
    [SerializeField] private Camera mainCamera;
    private RaycastHit hit;
    private Ray ray;
    public float _distanceHit = 2;
    [SerializeField] private GameObject posohGameObject;
    [SerializeField] private GameObject buttonE;
    Vector2 velocity;
    Vector2 frameVelocity;
    public GameObject _isFireGameObject;
    public GameObject _isWinterGameObject;

    [SerializeField] private NPCChallenge _challenge;
    [SerializeField] private TMP_Text valueTreeText;
    public int valueTree;



    void Reset()
    {
        // Get the character from the FirstPersonMovement in parents.
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        // Lock the mouse cursor to the game screen.
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        valueTreeText.text = "x " + valueTree.ToString();
        // Get smooth velocity.
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);

        // Rotate camera up-down and controller left-right from velocity.
        transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
        positionCamera = mainCamera.transform.position;
        moveTransformCamera = mainCamera.transform.forward;
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (Physics.Raycast(positionCamera, moveTransformCamera, out hit, _distanceHit) || Physics.Raycast(ray, out hit, _distanceHit))
            {
                if (hit.collider.gameObject.GetComponent<Posoh>() != null)
                {
                    if (hit.collider.gameObject.GetComponent<Posoh>().number == 0)
                    {
                        _isFireGameObject.SetActive(true);
                        IdPosoh._isFire = true;
                    }
                    else
                    {
                        _isWinterGameObject.SetActive(true);
                        IdPosoh._isWinter = true;
                    }
                    Destroy(hit.collider.gameObject);
                }
                if (hit.collider.gameObject.GetComponent<TreeKvest>() != null)
                {
                    if (_challenge)
                    {
                        if (_challenge._isKvest)
                        {
                            if (valueTree <= 3)
                            {
                                valueTree++;
                                Destroy(hit.collider.gameObject);
                            }
                        }
                    }
                }
            }
        }
        if (Physics.Raycast(positionCamera, moveTransformCamera, out hit, _distanceHit))
        {
            if (hit.collider.gameObject.GetComponent<Posoh>() != null || hit.collider.gameObject.GetComponent<TreeKvest>() != null) buttonE.SetActive(true);
            else buttonE.SetActive(false);
        }
    }
}
