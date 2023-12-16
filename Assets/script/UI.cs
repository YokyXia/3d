using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    public TMPro.TextMeshProUGUI m_difficulty;
    void Start()
    {
        if (GlobalData.Instance.normal)
        {
            m_difficulty.text = "Normal Mode";
        }
        else
        {
            m_difficulty.text = "Hard Mode";
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
