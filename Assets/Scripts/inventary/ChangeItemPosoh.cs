using System.Collections.Generic;
using UnityEngine;

public class ChangeItemPosoh : MonoBehaviour
{
    public Transform QuickPanel;
    public int currentQuickSlotID = 0;
    public List<GameObject> QuickPanelPosohPrefab;
    public Weapon weapon;
    private RaycastHit hit;
    public FirstPersonLook firstPersonLook;

    void Update()
    {
        MoveMouseWheel();
        if (IdPosoh._isFire)
        {
            if (currentQuickSlotID == 0)
            {
                if (QuickPanelPosohPrefab[0])
                {
                    QuickPanelPosohPrefab[0].gameObject.SetActive(true);
                }
            }
            else
            {
                if (QuickPanelPosohPrefab[0])
                {
                    if (IdPosoh._isFire)
                        QuickPanelPosohPrefab[0].gameObject.SetActive(false);
                }
            }
        }
        if (IdPosoh._isWinter)
        {
            if (currentQuickSlotID == 1)
            {
                if (QuickPanelPosohPrefab[1])
                {
                    QuickPanelPosohPrefab[1].gameObject.SetActive(true);
                }
            }
            else
            {
                if (QuickPanelPosohPrefab[1])
                {
                    if (IdPosoh._isWinter)
                        QuickPanelPosohPrefab[1].gameObject.SetActive(false);
                }
            }
        }

    }
    private void MoveMouseWheel()
    {
        float MouseWheel = Input.GetAxis("Mouse ScrollWheel");

        if (IdPosoh._isFire && IdPosoh._isWinter)
        {
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
}
