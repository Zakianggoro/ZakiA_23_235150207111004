using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneIndex : MonoBehaviour
{
    [SerializeField] private int Button1Index;

    [SerializeField] private int Button2Index;

    [SerializeField] private int Button3Index;

    public void Button1()
    {
        SceneManager.LoadScene(Button1Index);
    }

    public void Button2()
    {
        SceneManager.LoadScene(Button2Index);
    }

    public void Button3()
    {
        SceneManager.LoadScene(Button3Index);
    }
}