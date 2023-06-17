using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class POVG : MonoBehaviour
{
    public GameObject Shadow;
   
   
    public void povred()
    {
        Shadow.SetActive(false);
    }

    public void povgreen()
    {
        Shadow.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
