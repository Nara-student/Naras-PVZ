using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieEating : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float damage = 50;

    private Animator anim;
    List<PlantHealth> plantHealth = new List<PlantHealth>();

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlantHealth ph = collision.gameObject.GetComponent<PlantHealth>();
        if (ph == null)
        {
            return;
        }

        anim.SetBool("IsEating", true);
        GetComponent<ZombieMovement>().moveDirection = Vector2.zero;
        plantHealth.Add(ph);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlantHealth ph = collision.gameObject.GetComponent<PlantHealth>();

        if (ph != null)
        {
            anim.SetBool("IsEating", false);
            plantHealth.Remove(ph);
            GetComponent<ZombieMovement>().moveDirection = new Vector2(-1, 0);
        }
    }

    public void Eat()
    {
        plantHealth[0].TakeDamage(damage);
    }
}
