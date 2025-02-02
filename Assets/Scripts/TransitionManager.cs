using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public Button startButton;          // Assign in Inspector
    public Image transitionImage;       // Assign in Inspector
    public TextMeshProUGUI countdownText; // Assign in Inspector
    public string nextSceneName = "Stage"; // Change to your target scene
    private float countdownTime = 10f;

    void Start()
    {
        transitionImage.gameObject.SetActive(false);
        countdownText.gameObject.SetActive(false);
        startButton.onClick.AddListener(StartTransition);
    }

    void StartTransition()
    {
        startButton.gameObject.SetActive(false);  // Hide button
        transitionImage.gameObject.SetActive(true); // Show image
        countdownText.gameObject.SetActive(true); // Show countdown
        StartCoroutine(CountdownAndLoad());
    }

    IEnumerator CountdownAndLoad()
    {
        float timeLeft = countdownTime;
        while (timeLeft > 0)
        {
            countdownText.text = "Transition in: " + timeLeft.ToString("0") + "s";
            yield return new WaitForSeconds(1f);
            timeLeft--;
        }

        SceneManager.LoadScene(nextSceneName);
    }
}
