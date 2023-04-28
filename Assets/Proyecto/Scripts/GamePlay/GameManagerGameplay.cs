using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerGameplay : MonoBehaviour
{
    [SerializeField]
    GameObject options;
    public int nvl = 0;
    public int puntuación;
    public static GameManagerGameplay instance;

    //Record:
    public TextMeshProUGUI tRecord, tVida, tPuntuacion, tPuntuaciónEnd;

    private void Awake()
    {
        Time.timeScale = 1.0f;
        if (instance == null)
            instance = this;
    }
    private void Update()
    {
        //Textos
        tRecord.text = ("RECORD: " + PlayerPrefs.GetFloat("record"));
        tPuntuacion.text = ("PUNTUACIÓN: " + puntuación);
        tPuntuaciónEnd.text = ("PUNTUACIÓN: " + puntuación);
        tVida.text = ("VIDA: 0" + BallBehaviour.instance.vida.ToString());
    }

    //Menu opciones
    public void Options()
    {

        if (options.activeInHierarchy == false)
        {
            Time.timeScale = 0.0f;
            options.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            options.SetActive(false);
        }
    }

    //Funciones de Reinicio o Salida:
    public void Reiniciar()
    {
        SceneManager.LoadScene("NVL-" + nvl.ToString());
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
