using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnSun : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float Cooldown = 10;
    private float timer;

    [SerializeField] GameObject sun;
    [SerializeField] List<Vector2> spawnRows = new List<Vector2>();
    void Start()
    {
        timer = Cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if(timer <= 0)
        {
            Instantiate(sun, spawnRows[Random.Range(0, spawnRows.Count)], Quaternion.identity);
            timer = Cooldown;
        }
    }
}
