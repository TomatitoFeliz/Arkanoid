using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    [SerializeField] int vida;

    //Sonido
    public AudioClip destuccion;
    public AudioSource audiosource;

    //Declara la puntuaci�n que da cada tipo de bloque seg�n su dureza:
    int valor;
    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        valor = vida;
    }

    public void PlaySound(AudioClip clip)
    {
        audiosource.PlayOneShot(clip);
    }

    //Sistema de restado de vida, destrucci�n del objeto y obtenci�n de puntos:
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pelota")
        {
            vida--;
        }
    }

    private void Update()
    {
        if (vida == 0)
        {
            AudioSource.PlayClipAtPoint(destuccion, new Vector3(0f, 0f, -10f));
            GameManagerGameplay.instance.puntuaci�n += 100 * valor;
            Destroy(gameObject);;
            Debug.Log(GameManagerGameplay.instance.puntuaci�n);
        }
    }
}
