using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fVelocidad = 10;
    Rigidbody2D pRigidbody2D;
    void Start()
    {
        pRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 position = pRigidbody2D.position;
        position.x = position.x + 1.0f * horizontal * fVelocidad * Time.deltaTime;
        pRigidbody2D.MovePosition(position);
    }
}
