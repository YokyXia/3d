using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmit : MonoBehaviour
{
    // Start is called before the first frame update
    private bool transmit=false;
    public GameObject player;
    public GameObject transmit_ui;
    public Transform transmit_transform1;
    public Transform transmit_transform2;
    private bool flag=false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalData.Instance.normal == true && GlobalData.Instance.transmit_to>0)
        {
            transmit=true;
        }
        else
        {
            transmit = false;
        }

        if(flag && (Input.GetKeyDown(KeyCode.R)) && transmit)
        {
            if (GlobalData.Instance.transmit_to == 1)
            {
                player.transform.position = transmit_transform1.position;
            }
            if (GlobalData.Instance.transmit_to == 2)
            {
                player.transform.position = transmit_transform2.position;
            }
        }

        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null && transmit)
        {
            transmit_ui.SetActive(true);
            flag = true;
        }
        
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    //Debug.Log("11");
    //    if (other.gameObject.GetComponent<Player>() != null && (Input.GetKeyDown(KeyCode.R)) && transmit)
    //    {
    //        Debug.Log("22");
    //        if (GlobalData.Instance.transmit_to == 1)
    //        {
    //            Debug.Log("33");
    //            player.transform.position = transmit_transform1.position;
    //        }
    //        if (GlobalData.Instance.transmit_to == 2)
    //        {
    //            player.transform.position = transmit_transform2.position;
    //        }
    //    }
    //}
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null && transmit)
        {
            transmit_ui.SetActive(false);
            flag = false;
        }
    }
}
