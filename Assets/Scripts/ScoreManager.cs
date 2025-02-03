using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int score = 2000;
    
    private bool isReducing = false;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Listen for scene changes
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        if (!SceneManager.GetActiveScene().name.Equals("Score"))
        {
            StartReducingScore();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Score")
        {
            StopReducingScore();
        }
        else if (scene.name == "Game Over")
        {
            Debug.Log("Game Over scene loaded. Destroying ScoreManager.");
            Destroy(gameObject);
        }
        else if (scene.name == "Main Menu")
        {
            Debug.Log("Destryo Main Menu");
            Destroy(gameObject);
        }
        else
        {
            StartReducingScore();
        }
    }

    private void StartReducingScore()
    {
        if (!isReducing)
        {
            isReducing = true;
            InvokeRepeating(nameof(ReduceScore), 1f, 1f);
            Debug.Log("Score reduction started.");
        }
    }

    private void StopReducingScore()
    {
        if (isReducing)
        {
            isReducing = false;
            CancelInvoke(nameof(ReduceScore));
            Debug.Log("Score reduction stopped.");
        }
    }

    private void ReduceScore()
    {
        if (score > 0)
        {
            score--;
            Debug.Log("Score decreased: " + score);
        }
    }
}