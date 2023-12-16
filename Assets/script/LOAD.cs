using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOAD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GlobalData.Instance.qteSuccess = false;
        GlobalData.Instance.suberMode = false;
        GlobalData.Instance.timeFreeze = false;
        GlobalData.Instance.enegy = 100;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
