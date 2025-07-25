using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hasPlant = false;
    private GameObject currentPlantOnTile;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0)
        {
            hasPlant = false;
        }
    }

    public void PlantPlant(GameObject plant, bool canRemove)
    {
        if (!hasPlant && plant != null && !canRemove)
        {
            currentPlantOnTile = Instantiate(plant, transform.position, Quaternion.identity, gameObject.transform);
            hasPlant = true;
        }
        else if(canRemove)
        {
            RemovePlant();
        }
    }

    private void RemovePlant()
    {
        //removes plant
        if(currentPlantOnTile != null)
        {
            Destroy(currentPlantOnTile);
            hasPlant = false;
        }
    }
}
