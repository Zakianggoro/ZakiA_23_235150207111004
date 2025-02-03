using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public Button startButton;         
    public Image transitionImage;       
    public TMP_Text countdownText; 
    public string nextSceneName = "Stage"; 
    private float countdownTime = 10f;

    void Start()
    {
        transitionImage.gameObject.SetActive(false);
        countdownText.gameObject.SetActive(false);
        startButton.onClick.AddListener(StartTransition);
    }

    void StartTransition()
    {
        startButton.gameObject.SetActive(false);  
        transitionImage.gameObject.SetActive(true);
        countdownText.gameObject.SetActive(true);
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
