using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BallBehaviour : MonoBehaviour
{
    //Agarre de la pelota:
    bool isActive = false;
    Rigidbody2D bRigidbody2D;
    Vector2 bPosition;
    [SerializeField]
    GameObject player;

    //Sonido:
    public AudioClip choque;
    public AudioClip muerte;
    public AudioSource audiosource;

    //Datos para el Sistema de rebote de la pelota:
    public float speed = 100.0f;
    public float speedinstance;

    //Datos para el Sistema de Vida y Reinicio:
    public int vida = 3;
    [SerializeField] 
    GameObject cReinicio;

    public static BallBehaviour instance;


    private void Awake()
    {
        Time.timeScale = 1.0f;
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        speedinstance = speed;
        bRigidbody2D = GetComponent<Rigidbody2D>();
        audiosource = GetComponent<AudioSource>();
        cReinicio.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlaySound(choque);

        //Sistema de rebote de la pelota:
        float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
        {
            return (ballPos.x - racketPos.x) / racketWidth;
        }

        if (collision.gameObject.name == "Player")
        {
            float x = hitFactor(transform.position,
                              collision.transform.position,
                              collision.collider.bounds.size.x);

            Vector2 dir = new Vector2(x, 1).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        //Sistema de Vidas y Reinicio:
        if (collision.gameObject.tag == "Fin")
        {
            isActive = false;
            PlaySound(muerte);

            //gameObject.transform.position;
            if (vida >= 1)
            {
                vida--;
                Debug.Log("-1 VIDA");
            }
            else if (vida == 0)
            {

                cReinicio.SetActive(true);
                GuardarDatos();
                Time.timeScale = 0.0f;
            }
        }
    }

    private void Update()
    {
        //Bloques eliminados:
        GameObject[] bloques = GameObject.FindGameObjectsWithTag("Bloque");
        if (bloques == null || bloques.Length == 0)
        {
            Time.timeScale = 0.0f;
            GuardarDatos();
            cReinicio.SetActive(true);
            if (vida > 0)
            {
                GameManagerGameplay.instance.puntuación += 200 * vida;
                vida--;
            }
        }

        //Agarre de la pelota
        bPosition = gameObject.transform.position;
        if (isActive == false)
        {
            bRigidbody2D.velocity = (new Vector2(0f, 0f));
            Vector2 follow = new Vector2(player.transform.position.x, -2.876f);
            gameObject.transform.position = follow;
        }
        if (isActive == false && Input.GetKey("space") == true)
        {
            isActive = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        }
    }

    //Guardando Record:
    void GuardarDatos()
    {
        if (PlayerPrefs.GetFloat("record", 0.0f) < GameManagerGameplay.instance.puntuación)
        {
            PlayerPrefs.SetFloat("record", GameManagerGameplay.instance.puntuación);
        }
        PlayerPrefs.Save();
    }

    //Sonido
    public void PlaySound(AudioClip clip)
    {
        audiosource.PlayOneShot(clip);
    }
}
