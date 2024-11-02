using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerLogic : MonoBehaviour
{
    public enum MinerType{
        Iron,
        Coal
    }

    [HideInInspector] Item item;

    public GameObject itemToSpwan;
    
    public MinerType minerType;
    private Renderer itemRenerer;
  

    Tile tile;

    void Start(){ 
       InvokeRepeating("SpwanItem", 3.0f, 0.50f);
    }

    void Update()
    {   

    }


    void SpwanItem(){
        Instantiate(itemToSpwan, this.transform.position, this.transform.rotation);
    }
}
