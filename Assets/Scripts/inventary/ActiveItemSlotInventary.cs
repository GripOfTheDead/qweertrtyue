using UnityEngine;
using UnityEngine.UI;

public class ActiveItemSlotInventary : MonoBehaviour
{
    public Transform QuickPanel;
    public int currentQuickSlotID = 0;
    private RaycastHit hit;
    void Update()
    {
        float MouseWheel = Input.GetAxis("Mouse ScrollWheel");
        if (MouseWheel > 0.1)
        {
            if (currentQuickSlotID >= QuickPanel.childCount - 1)
            {
                currentQuickSlotID = 0;
            }
            else
            {
                currentQuickSlotID++;
            }
        }
        if (MouseWheel < -0.1)
        {
            if (currentQuickSlotID <= 0)
            {
                currentQuickSlotID = QuickPanel.childCount - 1;
            }
            else
            {
                currentQuickSlotID--;
            }
        }
    }
}
