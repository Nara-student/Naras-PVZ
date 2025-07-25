using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnDetector : MonoBehaviour
{
    // Start is called before the first frame update
    public bool canFire = false;

    private List<ZombieHealth> onLawn = new List<ZombieHealth>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //detects zombies on lawn
        ZombieHealth zombieHealth = collision.gameObject.GetComponent<ZombieHealth>();

        if(zombieHealth == null)
        {
            return;
        }

        canFire = true;
        onLawn.Add(zombieHealth);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //removes zombie from lawn
        ZombieHealth zombieHealth = collision.gameObject.GetComponent<ZombieHealth>();

        if(zombieHealth == null)
        {
            return;
        }

        onLawn.Remove(zombieHealth);
        //checks if theres no zombies on lawn
        if (onLawn.Count == 0)
        {
            canFire = false;
        }
    }
}
