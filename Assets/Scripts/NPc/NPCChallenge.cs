using TMPro;
using UnityEngine;

public class NPCChallenge : MonoBehaviour
{
    [SerializeField] private GameObject npcText;
    [SerializeField] private TMP_Text challengeNpcText;
    [SerializeField] private GameObject itemPosohChallenge;
    [SerializeField] private Collider colliderKvest;



    [SerializeField] private GameObject challengePanel;
    [SerializeField] private GameObject challengeImage;
    [SerializeField] private TMP_Text challenge;
    [TextArea(3, 10)]
    [SerializeField] private string challengeText;
    [TextArea(3, 10)]
    [SerializeField] private string completChallengeText;
    [SerializeField] private FirstPersonLook firstPersonLook;
    public bool _isKvest = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!_isKvest)
            {
                npcText.SetActive(true);
                challengePanel.SetActive(true);
                challengeImage.SetActive(true);
                challenge.text = challengeText;
                _isKvest = true;
            }
            else
            {
                if (firstPersonLook.valueTree >= 3)
                {
                    challengeNpcText.text = completChallengeText;
                    challengePanel.SetActive(false);
                    challengeImage.SetActive(false);
                    itemPosohChallenge.SetActive(true);
                    colliderKvest.enabled = false;
                }
            }
        }
    }
}
