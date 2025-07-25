using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Health")]
    [SerializeField] float health = 181;
    [SerializeField] float protectionHealth;
    private float nativeProtectionHealth;

    private Animator anim;
    private Rigidbody2D rb;

    [Header("Protection")]
    [SerializeField] List<Sprite> helmets = new List<Sprite>();
    [SerializeField] GameObject helmet;
    private GameObject helmetClone;
    private bool hasHelmetOn = true;

    [Header("DeathPrefabs")]
    [SerializeField] GameObject head;
    private GameObject headClone;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        nativeProtectionHealth = protectionHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        if(protectionHealth > 0)
        {
            protectionHealth -= amount;

            if(protectionHealth < nativeProtectionHealth * 0.5f && protectionHealth > nativeProtectionHealth * 0.25f)
            {
                helmet.GetComponent<SpriteRenderer>().sprite = helmets[1];
            }
            else if(protectionHealth < nativeProtectionHealth * 0.25f)
            {
                helmet.GetComponent<SpriteRenderer>().sprite = helmets[2];
            }
        }
        else
        {
            if(hasHelmetOn == true)
            {
                HelmetFly();
            }

            health -= amount;
            hasHelmetOn = false;
        }

        Death();
    }

    private void Death()
    {
        if (health <= 0)
        {
            anim.SetTrigger("Death1");
            Destroy(gameObject, 10);

            //disable detection
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<ZombieHealth>().enabled = false;

            HeadFly();
        }
    }

    private void HeadFly()
    {
        //head flies
        headClone = Instantiate(head, head.transform.position, Quaternion.identity);
        Destroy(headClone, 10);
        head.SetActive(false);

        headClone.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 3.5f, ForceMode2D.Impulse);
        headClone.GetComponent<Rigidbody2D>().gravityScale = 1;
        Invoke("HeadStop", 1f);
    }

    private void HeadStop()
    {
        //head stops on ground and stops zombie from moving
        GetComponent<ZombieMovement>().enabled = false;
        rb.velocity = Vector2.zero;
        headClone.GetComponent<Rigidbody2D>().gravityScale = 0;
        headClone.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void HelmetFly()
    {
        //helmet flies
        helmetClone = Instantiate(helmet, helmet.transform.position, Quaternion.identity);
        helmetClone.GetComponent<SpriteRenderer>().sprite = helmets[2];
        Destroy(helmetClone, 10);
        helmet.SetActive(false);

        helmetClone.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 3.5f, ForceMode2D.Impulse);
        helmetClone.GetComponent<Rigidbody2D>().gravityScale = 1;
        Invoke("HelmetStop", 1);
    }

    private void HelmetStop()
    {
        //helmet stops on ground and stops zombie from moving
        helmetClone.GetComponent<Rigidbody2D>().gravityScale = 0;
        helmetClone.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
