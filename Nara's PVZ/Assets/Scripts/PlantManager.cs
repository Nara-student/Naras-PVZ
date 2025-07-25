using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantManager : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject currentPlant;
    private Sprite currentPlantSprite;
    private int price = 0;

    [SerializeField] GameObject shovel;

    private bool canRemove = false;

    [SerializeField] LayerMask tileMask;
    [SerializeField] Transform tiles;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, tileMask);

        foreach(Transform tile in tiles)
        {
            //remove sneakpeek of plant
            tile.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (hit.collider)
        {
            //sneakPeak on plant
            if(hit.collider.GetComponent<Tile>().hasPlant == false)
            {
                hit.collider.GetComponent<SpriteRenderer>().sprite = currentPlantSprite;
                hit.collider.GetComponent<SpriteRenderer>().enabled = true;
            }

            if (Input.GetMouseButtonDown(0))
            {
                //spawn plant
                hit.collider.GetComponent<Tile>().PlantPlant(currentPlant, canRemove);
                currentPlant = null;
                currentPlantSprite = null;
                canRemove = false;
                shovel.GetComponent<Image>().enabled = true;
            }
        }
    }

    public void SelectPlant(GameObject currentPlant)
    {
        //checks for if you can afford it
        if(FindAnyObjectByType<SunCount>().sun >= price)
        {
            //select plant type
            this.currentPlant = currentPlant;
            canRemove = false;
            shovel.GetComponent<Image>().enabled = true;
        }
    }

    public void  SelectPlantSprite(Sprite currentPlantSprite)
    {
        //checks for if you can afford it
        if (FindAnyObjectByType<SunCount>().sun >= price)
        {
            //select plantsprite
            this.currentPlantSprite = currentPlantSprite;
        }
    }

    public void GivePriceValue(int price)
    {
        this.price = price;
    }

    public void RemovePlant()
    {
        currentPlant = null;
        canRemove = true;
        currentPlantSprite = null;
        shovel.GetComponent<Image>().enabled = false;
    }
}
