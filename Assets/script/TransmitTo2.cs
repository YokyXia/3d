using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitTo2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject transmit2;
    public GameObject transmit2_active;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            transmit2_active.SetActive(true);
            GlobalData.Instance.transmit_to = 2;
            transmit2.SetActive(false);
        }
    }
}
