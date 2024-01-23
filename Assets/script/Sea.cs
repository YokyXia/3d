using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Sea : MonoBehaviour
{
    public GameObject sea;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (sea != null)
        {
            Renderer renderer = sea.GetComponent<Renderer>();
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
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.GetComponent<Player>() != null)
    //    {
    //        player.transform.position = new Vector3(0.5776469f, 4.9f, 4.2f);
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            player.transform.position = new Vector3(0.5776469f, 4.9f, 4.2f);
        }
    }
}
