using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{

    public GameObject belt;
    public GameObject miner;
    [HideInInspector] public GameObject currentSelectedItem = null;

    public TMP_Text inventoryText;

    int inventoryIndex = 1;

    void Start()
    {
        currentSelectedItem = belt;
    }

    void Update()
    {   

       
        manegeInventory();
        if(inventoryIndex == 1){
            currentSelectedItem = belt;
        }
        if(inventoryIndex == 2){
            currentSelectedItem = miner;
        }
    }

    // void manegeInventory(){
    //     if (!Input.GetKeyUp(KeyCode.Space)) {return;}

    //     inventoryIndex += 1;
    //     if  (inventoryIndex >= 3){inventoryIndex = 1;}

    //     if (inventoryIndex == 1) {inventoryText.SetText("conveyor");}
    //     if (inventoryIndex == 2) {inventoryText.SetText("miner");}
        
    // }

    void manegeInventory(){
    if (!Input.GetKeyUp(KeyCode.Space)) {return;}

    inventoryIndex += 1;
    if  (inventoryIndex >= 3){inventoryIndex = 1;}

    if (inventoryText != null) {
        if (inventoryIndex == 1) {inventoryText.SetText("conveyor");}
        if (inventoryIndex == 2) {inventoryText.SetText("miner");}
    } else {
        return;
        //Debug.LogWarning("inventoryText is not assigned!");
    }
}

}
