using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    bool isActive = false;
    public float power = 3;
    Rigidbody2D bRigidbody2D;
    [SerializeField]
    GameObject player;

    Vector2 bPosition;

    void Start()
    {
        bRigidbody2D = GetComponent<Rigidbody2D>();
        bRigidbody2D.AddForce(new Vector2(0f, power), ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //bRigidbody2D.velocity = (new Vector2(0f, 0f));
            //bRigidbody2D.AddForce(new Vector2(player.transform.position.x, power), ForceMode2D.Impulse);
        }
    }
    void Update()
    {
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
            bRigidbody2D.AddForce(new Vector2(0f, -power), ForceMode2D.Impulse);
        }
    }
}
