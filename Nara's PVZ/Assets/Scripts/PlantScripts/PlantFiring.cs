using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantFiring : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject firingSpot;

    [SerializeField] List<float> lawns = new List<float>();
    private int lawnIndex = 1;

    private LawnDetector lawnDetector;

    [SerializeField] float cooldown;
    private float timer;

    private Animator anim;
    void Start()
    {
        timer = cooldown;
        anim = GetComponent<Animator>();

        //checks which lawn theyre on and assigns detector
        foreach(float lawn in lawns)
        {
            if(transform.position.y == lawn)
            {
                lawnDetector = GameObject.Find("Lawn" + lawnIndex).GetComponent<LawnDetector>();
            }
            lawnIndex++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //attack per seconds
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0 && lawnDetector.canFire)
        {
            anim.SetTrigger("Fire");
        }
    }

    public void Fire()
    {
        GameObject projectileClone = Instantiate(projectile, firingSpot.transform.position, Quaternion.identity);
    }

    public void ResetCooldown()
    {
        timer = cooldown;
    }
}
