using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRTS : MonoBehaviour
{
    private GameObject selGameObj;

    private void Awake()
    {
        selGameObj = transform.Find("Selected").gameObject;
        SetSelectedVisible(false);
    }
    public void SetSelectedVisible(bool b)
    {
        selGameObj.SetActive(b);
    }
}
