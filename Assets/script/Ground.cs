using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject isGround;
    // Start is called before the first frame update
    void Start()
    {
        if (isGround != null)
        {
            Renderer renderer = isGround.GetComponent<Renderer>();
            if (renderer != null)
            {
                Color color = renderer.material.color;
                color.a = 0f; // 设置不透明度为0%
                renderer.material.color = color;
            }
            else
            {
                Debug.LogError("Cube does not have a Renderer component.");
            }
        }
        else
        {
            Debug.LogError("Cube GameObject is not assigned.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
