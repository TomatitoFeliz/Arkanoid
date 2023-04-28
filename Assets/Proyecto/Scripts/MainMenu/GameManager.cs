using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject options;
    [SerializeField]
    Slider slider;
    [SerializeField]
    AudioSource audioSource;
    private void Start()
    {
        audioSource.volume = PlayerPrefs.GetFloat("Volume");
    }
    public void Play()
    {
        SceneManager.LoadScene("NVL-1");
    }
    public void PlayInfinito()
    {
        SceneManager.LoadScene("NVL-Infinito");
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
    private void Update()
    {
        PlayerPrefs.SetFloat("Volume", slider.value);
        audioSource.volume = PlayerPrefs.GetFloat("Volume");
    }
}
