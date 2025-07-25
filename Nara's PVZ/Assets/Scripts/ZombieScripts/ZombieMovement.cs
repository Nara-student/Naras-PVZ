using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 4.7f;

    public Vector2 moveDirection = new Vector2(-1, 0);

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = moveDirection * speed;
    }
}
