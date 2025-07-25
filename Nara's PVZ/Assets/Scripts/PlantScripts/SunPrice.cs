using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunPrice : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int price = 0;
    [SerializeField] string nativeButtonName;
    private GameObject nativeButton;
    void Start()
    {
        //removes suns and sets cooldown
        FindAnyObjectByType<SunCount>().DeductSun(price);
        nativeButton = GameObject.Find(nativeButtonName);
        nativeButton.GetComponent<SeedCooldown>().isCooldown = true;
        nativeButton.GetComponent<SeedCooldown>().SetFill();
    }
}
