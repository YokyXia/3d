using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitTo1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject transmit1;
    public GameObject transmit1_active;
    public GameObject transmit;
    public GameObject transmit_active;
    public GameObject T_01;
    public bool IsSaved;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSaved && Input.GetKey(KeyCode.R))
        {
            T_01.SetActive(false);

            transmit1_active.SetActive(true);
            GlobalData.Instance.transmit_to = 1;
            transmit.SetActive(false);
            transmit_active.SetActive(true);
            transmit1.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            T_01.SetActive(true);
            IsSaved = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            IsSaved = false;
            T_01.SetActive(false);
        }
    }
}
