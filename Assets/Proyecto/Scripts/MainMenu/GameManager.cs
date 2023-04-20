using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject options;
    public void Play()
    {
        SceneManager.LoadScene("NVL-1");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Options()
    {
        if (options.activeInHierarchy == false)
        {
            options.SetActive(true);
        }
        else
        {
            options.SetActive(false);
        }
    }
}
