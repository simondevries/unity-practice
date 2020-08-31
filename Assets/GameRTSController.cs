using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GameRTSController : MonoBehaviour
{
    [SerializeField] private Transform selectionAreaTransform;

    private Vector3 startPoistion;

    private List<UnitRTS> SelectedUnitRTSList;
    
    private void Awake()
    {
        SelectedUnitRTSList = new List<UnitRTS>();
        selectionAreaTransform.gameObject.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selectionAreaTransform.gameObject.SetActive(true);
            startPoistion = UtilsClass.GetMouseWorldPosition();
        }

        if (Input.GetMouseButton(0))
        {
            var mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            var lowerLeft = new Vector3(Mathf.Min(startPoistion.x, mouseWorldPosition.x),
                Mathf.Min(startPoistion.y, mouseWorldPosition.y));
            var upperRight  = new Vector3(Mathf.Max(startPoistion.x, mouseWorldPosition.x), Mathf.Max(startPoistion.y, mouseWorldPosition.y));
            selectionAreaTransform.position = lowerLeft;
            selectionAreaTransform.localScale = upperRight - lowerLeft;
        }
        
        if (Input.GetMouseButtonUp(0))
        {            
            selectionAreaTransform.gameObject.SetActive(false);

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
