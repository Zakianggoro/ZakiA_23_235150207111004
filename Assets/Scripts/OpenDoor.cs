using TMPro;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public TMP_Text promptText;
    public GameObject blockToDisappear; 

    private bool isPlayerInTrigger = false;

    private void Start()
    {
        if (promptText != null)
        {
            promptText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            isPlayerInTrigger = true;
            if (promptText != null)
            {
                promptText.gameObject.SetActive(true);
                promptText.text = "Press [E] to remove the block";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            if (promptText != null)
            {
                promptText.gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (blockToDisappear != null)
            {
                blockToDisappear.SetActive(false);
                Debug.Log("Block removed!");
            }

            if (promptText != null)
            {
                promptText.gameObject.SetActive(false);
            }
        }
    }
}