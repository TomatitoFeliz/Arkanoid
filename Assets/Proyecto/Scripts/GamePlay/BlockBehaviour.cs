using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    [SerializeField] int vida;

    [SerializeField] GameObject salud, puntos, lento, fuerte;

    //Sonido
    public AudioClip destuccion;
    public AudioSource audiosource;

    //Declara la puntuaci�n que da cada tipo de bloque seg�n su dureza:
    int valor;

    public static BlockBehaviour instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        PowerUps.instance.da�oInstance = PowerUps.instance.da�o;
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
            vida -= PowerUps.instance.da�o;

            if (vida <= 0)
            {
                int randomPUPChance = Random.Range(1, 101);
                if (randomPUPChance < 50)
                {
                    int randomPUPType = Random.Range(1, 101);
                    if (randomPUPType < 25 && randomPUPType >= 0)
                    {
                        Instantiate(salud, collision.transform.position, Quaternion.identity);
                    }
                    if (randomPUPType < 101 && randomPUPType >= 75)
                    {
                        Instantiate(fuerte, collision.transform.position, Quaternion.identity);
                    }
                    if (randomPUPType < 75 && randomPUPType >= 50)
                    {
                        Instantiate(lento, collision.transform.position, Quaternion.identity);
                    }
                    if (randomPUPType < 50 && randomPUPType >= 25)
                    {
                        Instantiate(puntos, collision.transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }

    private void Update()
    {
        if (vida <= 0)
        {
            AudioSource.PlayClipAtPoint(destuccion, new Vector3(0f, 0f, -10f));
            GameManagerGameplay.instance.puntuaci�n += 100 * valor;
            Destroy(gameObject);;
            Debug.Log(GameManagerGameplay.instance.puntuaci�n);
        }
    }
}
