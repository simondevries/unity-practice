using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GameRTSController : MonoBehaviour
{
    [SerializeField] private Transform selectionAreaTransform;

    private Vector3 startPosition;

    private List<UnitRTS> SelectedUnitRTSList;

    public GameObject tile;
    
    //void Start()
    //{
     
    //}
    
    private void Awake()
    {
        Debug.Log("Fill");
        ////2 for sentences to create a vidirectional array
        //for(int i = 0; i<5;i++){            //for move on Y
        //    for(int j = 0; j<5;j++){        //for move on X
        //        var spriteRenderer = tile.GetComponent<SpriteRenderer>();
        //        var next = new System.Random().Next(4);
        //        switch (next)
        //        {
        //            case 0:
        //            spriteRenderer.color = Color.red;
        //            break;
        //            case 1:
        //                spriteRenderer.color = Color.blue;
        //                break;
        //            case 2:
        //                spriteRenderer.color = Color.magenta;
        //                break;
        //            case 3:
        //                spriteRenderer.color = Color.yellow;
        //                break;
        //        }
        //        Instantiate(tile, new Vector3(i, j, 0), Quaternion.identity);
        //        // transform.Translate(1f,0,0);    //Move on X
        //    }
        //    // transform.Translate(0,1f,0);    //When fill X translate on Y and start again
        //    // transform.Translate(-5f,0,0);   //Reset out transform position 5 units as set in the first for sentence
        //    //For mor space between objects just change the values in Translate function
        //}
        
        SelectedUnitRTSList = new List<UnitRTS>();
        selectionAreaTransform.gameObject.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selectionAreaTransform.gameObject.SetActive(true);
            startPosition = UtilsClass.GetMouseWorldPosition();
        }

        if (Input.GetMouseButton(0))
        {
            var mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            var lowerLeft = new Vector3(Mathf.Min(startPosition.x, mouseWorldPosition.x),
                Mathf.Min(startPosition.y, mouseWorldPosition.y));
            var upperRight  = new Vector3(Mathf.Max(startPosition.x, mouseWorldPosition.x), Mathf.Max(startPosition.y, mouseWorldPosition.y));
            selectionAreaTransform.position = lowerLeft;
            selectionAreaTransform.localScale = upperRight - lowerLeft;
        }
        
        if (Input.GetMouseButtonUp(0))
        {            
            selectionAreaTransform.gameObject.SetActive(false);

            Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(startPosition, UtilsClass.GetMouseWorldPosition());
            Debug.Log("#####");
            

            foreach (UnitRTS unitRts in SelectedUnitRTSList)
            {
                unitRts.SetSelectedVisible(false);
            }
            SelectedUnitRTSList.Clear();
            
            foreach (Collider2D collider2D1 in collider2DArray)
            {
                UnitRTS unitRts = collider2D1.GetComponent<UnitRTS>();
                if (unitRts != null)
                {
                    unitRts.SetSelectedVisible(true);
                    SelectedUnitRTSList.Add(unitRts);
                }
            }
            
            Debug.Log(SelectedUnitRTSList.Count);
        }
    }
}
