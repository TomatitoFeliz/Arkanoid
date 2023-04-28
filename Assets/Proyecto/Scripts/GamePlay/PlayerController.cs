using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fVelocidad = 10;
    public int puntos;

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = Vector2.right * horizontal * fVelocidad;
    }
}
