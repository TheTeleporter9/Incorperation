using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class Tile : MonoBehaviour
{
     [SerializeField] private Color32 _baseColor;
     [SerializeField] private Color32 _offsetColor;
     [SerializeField] private SpriteRenderer _renderer;
     [SerializeField] private GameObject _highlight;


     [HideInInspector]  public GameManager gm;
     [HideInInspector]  public BuildingManager bm;

     [HideInInspector] public Storage storage = new Storage();

     public bool isTaken = false;
     public bool isActive = false;

     [HideInInspector]   public GameObject objectOnTileReferance;
     [HideInInspector]   public int rotationCounter = 1;

     [HideInInspector]  public MinerLogic ml;

     [SerializeField]
     public string tileSIdentidy = ""; // Don't make this become a NullRefernece Error

     [HideInInspector]  public Vector3[] tileRotations = {      new Vector3(0 ,0, 0),    // This makes the object look up
                                             new Vector3(0 ,0, 180),  // This makes the object look down
                                             new Vector3(0 ,0, -90),  // This makes the object look right
                                             new Vector3(0 ,0, 90),   // This makes the object look left
                                             new Vector3(0 ,0, 0)};   // This makes the object look up

     void Start(){
          _renderer.GetComponent<SpriteRenderer>();
          _highlight.SetActive(false);
     }
     

     void Update()
     {    
          Debug.Log(this.ToString() + " : " + rotationCounter.ToString());
          setTileIdentidy();
          placeTile();
          removeTile();
          rotationSafe(); // Make shure that rotationSafe comes before rotateTile!!!
          rotateTile();   
     }     
     public void Init(bool isOffset){
          _renderer.color = isOffset ? _offsetColor : _baseColor;
     }

     void OnMouseEnter(){
          _highlight.SetActive(true);
          isActive = true;
     }
     void OnMouseExit(){
          _highlight.SetActive(false);
          isActive = false;
     }

     void  placeTile(){

          if (Input.GetMouseButton(0)){

               if (isActive != true){return;} 
               if (isTaken == true) {return;}

               var objectOnTile = Instantiate(bm.currentSelectedItem, this.transform.position - new Vector3(0, 0), Quaternion.Euler(tileRotations[0]));
                    objectOnTile.transform.SetParent(this.transform);

               objectOnTile.transform.SetParent(this.transform);

               objectOnTileReferance = objectOnTile;
               isTaken = true;

          }
     }

     void removeTile(){

          if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButton(2))
          {
               if (isActive == false) {return;}
               if (isTaken == false) {return;}

                    Destroy(objectOnTileReferance);
                    isTaken = false;
          }
     }
     void rotateTile(){
          
          if (Input.GetKeyDown(KeyCode.R))
          {
               if (isActive == false)   {return;}
               if (isTaken == false)    {return;}

               

               rotationCounter ++;
               storage.sGlobaleTileRotation = rotationCounter;

               objectOnTileReferance.transform.rotation = Quaternion.Euler(tileRotations[rotationCounter]);
          }
     }

     void rotationSafe(){
          if (rotationCounter >= 4) {rotationCounter = 0;}
     }

     void setTileIdentidy(){
          tileSIdentidy = bm.currentSelectedItem.ToString();
     }
      
     public void getTileRotation(){

     //Debug.LogError("Tile Rotation got");

          if(rotationCounter == 0) {tileSIdentidy = "Up";}
          if(rotationCounter == 1) {tileSIdentidy = "Down";}
          if(rotationCounter == 2) {tileSIdentidy = "Right";}
          if(rotationCounter == 3) {tileSIdentidy = "Left";}
          if(rotationCounter == 4) {tileSIdentidy = "Up";}

     } 

     
          
}
