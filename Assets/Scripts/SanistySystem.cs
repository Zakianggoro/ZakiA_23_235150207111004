using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SanistySystem : MonoBehaviour
{
    public float sanity = 100f;
    public float sanityDecayRate = 5f; 
    public Slider sanityBar;
    public TMP_Text sanityText;
    public string gameOverScene = "GameOver"; 

    void Update()
    {
        sanity -= sanityDecayRate * Time.deltaTime;
        sanityBar.value = sanity / 100f;
        sanityText.text = "" + Mathf.CeilToInt(sanity);

        
        if (sanity <= 0)
        {
            PlayerPrefs.SetInt("FinalScore", 0); 
            SceneManager.LoadScene(gameOverScene);
        }
    }

    public void RestoreSanity(float amount)
    {
        sanity = Mathf.Min(sanity + amount, 100f);
    }

    public void SaveSanityScore()
    {
        PlayerPrefs.SetInt("FinalScore", Mathf.CeilToInt(sanity));
        PlayerPrefs.Save();
    }

    public void CompleteStage()
    {
        SaveSanityScore();
        SceneManager.LoadScene("ResultsScene"); 
    }
}