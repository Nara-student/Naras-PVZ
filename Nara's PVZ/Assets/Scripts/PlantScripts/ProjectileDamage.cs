using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float speed = 4;
    [SerializeField] float damage = 20;

    private Rigidbody2D rb;
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        Destroy(gameObject, 10);

        rb.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ZombieHealth zombieHealth = collision.gameObject.GetComponent<ZombieHealth>();

        if(zombieHealth != null)
        {
            rb.velocity = Vector2.zero;
            zombieHealth.TakeDamage(damage);
            anim.SetBool("IsExploding", true);
            Destroy(gameObject, 0.33f);
        }
    }
}
