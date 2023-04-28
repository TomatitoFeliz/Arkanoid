using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public int puntos;
    public float timer = 10f;
    public int daño = 1;
    public int dañoInstance;

    public static PowerUps instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        dañoInstance = daño;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Puntos
        if (collision.gameObject.tag == "Player" && gameObject.tag == "puntos")
        {
            GameManagerGameplay.instance.puntuación += puntos;
            Destroy(gameObject);
        }

        //Salud
        if (collision.gameObject.tag == "Player" && gameObject.tag == "salud")
        {
            BallBehaviour.instance.vida++;
            Destroy(gameObject);
        }

        //Lentitud
        if (collision.gameObject.tag == "Player" && gameObject.tag == "lentitud")
        {
            StartCoroutine(Slow(collision));
        }
        
        IEnumerator Slow(Collider2D player)
        {
            BallBehaviour.instance.speed = 3;
            //GetComponent<Rigidbody2D>().velocity = dir * 3;

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            yield return new WaitForSeconds(timer);

            BallBehaviour.instance.speed = BallBehaviour.instance.speedinstance;
            Destroy(gameObject);
        }

        //Destruction
        if (collision.gameObject.tag == "Player" && gameObject.tag == "destruction")
        {
            StartCoroutine(Destruction(collision));
        }

        IEnumerator Destruction(Collider2D player)
        {
            daño = 3;

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            yield return new WaitForSeconds(timer);

            daño = dañoInstance;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Fin")
        {
            Destroy(gameObject);
        }

    }
}
