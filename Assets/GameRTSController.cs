using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GameRTSController : MonoBehaviour
{


    private Vector3 startPoistion;

    private List<UnitRTS> SelectedUnitRTSList;
    
    public GameRTSController()
    {
        SelectedUnitRTSList = new List<UnitRTS>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoistion = UtilsClass.GetMouseWorldPosition();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(startPoistion, UtilsClass.GetMouseWorldPosition());
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
