using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int sunValue = 25;
    [SerializeField] float speed = 2;
    [SerializeField] List<float> stopAtYAxis = new List<float>();

    private float stopAxis;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        stopAxis = stopAtYAxis[Random.Range(0, stopAtYAxis.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= stopAxis)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnMouseDown()
    {
        FindAnyObjectByType<SunCount>().AddSun(sunValue);
        Destroy(gameObject);
    }
}
