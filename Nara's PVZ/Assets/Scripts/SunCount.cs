using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SunCount : MonoBehaviour
{
    // Start is called before the first frame update
    public int sun = 50;

    private TextMeshProUGUI sunAmount;
    void Start()
    {
        sunAmount = GetComponent<TextMeshProUGUI>();
        sunAmount.text = (sun.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        sunAmount.text = (sun.ToString());
    }

    public void DeductSun(int amount)
    {
        sun -= amount;
    }

    public void AddSun(int amount)
    {
        sun += amount;
    }
}
