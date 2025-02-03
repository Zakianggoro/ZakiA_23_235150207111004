using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; // Assign in Inspector

    private void Start()
    {
        if (scoreText == null)
        {
            Debug.LogError("ScoreDisplay: No TextMeshProUGUI assigned! Please assign it in the Inspector.");
            return;
        }

        if (ScoreManager.Instance != null)
        {
            scoreText.text = "Score: " + ScoreManager.Instance.score;
        }
        else
        {
            Debug.LogError("ScoreDisplay: ScoreManager instance not found!");
        }
    }
}