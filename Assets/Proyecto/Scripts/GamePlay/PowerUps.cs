using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public int puntos;
    public float lTimer = 10f;
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
            StartCoroutine( slow(collision));
        }
        
        IEnumerator slow(Collider2D player)
        {
            BallBehaviour.instance.speed = 3;

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            yield return new WaitForSeconds(lTimer);

            BallBehaviour.instance.speed = BallBehaviour.instance.speedinstance;
            Destroy(gameObject);
        }

        //Destruction
        if (collision.gameObject.tag == "Player" && gameObject.tag == "destruction")
        {

            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Fin")
        {
            Destroy(gameObject);
        }

    }
}
