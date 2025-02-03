using TMPro;
using UnityEngine;

public class TriggerMessage : MonoBehaviour
{
    public TMP_Text messageText; 

    private void Start()
    {
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if (messageText != null)
            {
                messageText.gameObject.SetActive(true);
                messageText.text = "You have entered the area!";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (messageText != null)
            {
                messageText.gameObject.SetActive(false);
            }
        }
    }
}