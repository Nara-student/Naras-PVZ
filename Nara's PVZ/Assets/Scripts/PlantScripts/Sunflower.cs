using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject spawn;
    [SerializeField] GameObject sun;
    [SerializeField] float cooldown = 24;
    private float timer;
    private Animator anim;
    void Start()
    {
        timer = cooldown;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if(timer < 0)
        {
            anim.SetTrigger("GiveSun");
            timer = cooldown;
        }
    }

    public void SpawnSun()
    {
        Instantiate(sun, transform.position, Quaternion.identity, gameObject.transform);
    }
}
