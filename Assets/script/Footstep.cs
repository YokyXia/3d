using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject qte;
    public GameObject qte_hard;
    void Start()
    {
        if (GlobalData.Instance.normal)
        {
            qte.SetActive(true); 
            qte_hard.SetActive(false);  
        }
        else
        {
            qte.SetActive(false);
            qte_hard.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
