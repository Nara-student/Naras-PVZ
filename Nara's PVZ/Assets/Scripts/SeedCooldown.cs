using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedCooldown : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float cooldown = 5;
    public bool isCooldown = false;
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
        image.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Cooldown();
    }

    private void Cooldown()
    {
        if (isCooldown)
        {
            image.fillAmount -= 1 / cooldown * Time.deltaTime;
            image.GetComponent<Button>().interactable = false;

            if(image.fillAmount <= 0)
            {
                image.fillAmount = 0;
                isCooldown = false;
                image.GetComponent<Button>().interactable = true;
            }
        }
    }

    public void SetFill()
    {
        image.fillAmount = 1;
    }
}
