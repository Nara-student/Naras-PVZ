using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPrice : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int price = 10;
    [SerializeField] GameObject shadow;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //checks for if you can afford it
        if (FindAnyObjectByType<SunCount>().sun >= price)
        {
            shadow.SetActive(false);
        }
        else
        {
            shadow.SetActive(true);
        }
    }
}
