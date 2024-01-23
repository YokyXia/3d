using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class ControllerBAF : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject footstep;
    public GameObject BAF;
    private bool flag=false;
    private bool isin=false;
    public Transform pointA;
    public Transform pointB;
    public float speed = 10f; // 移动速度
 //   private bool isMovingToPointA=false; // 是否正在向A点移动

    private bool isMoving = false; // 是否正在移动
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isin)
        {
            flag = !flag;
            isMoving = true;
        }


        if (flag&& isMoving)
        {
            Debug.Log("true");
            Vector3 direction = (pointB.position - pointA.position).normalized;
            float distance = Vector3.Distance(footstep.transform.position, pointB.position);

            // 判断是否到达终点
            if (distance <= 0.1f)
            {
                // 停止移动物体
                isMoving = false;
            }
            else
            {
                // 移动物体
                footstep.transform.Translate(direction * speed * Time.deltaTime);
            }
        }
        else
        {
            if (isMoving)
            {
                Debug.Log("false");
                Vector3 direction = (pointA.position - pointB.position).normalized;
                float distance = Vector3.Distance(footstep.transform.position, pointA.position);

                // 判断是否到达终点
                if (distance <= 0.1f)
                {
                    // 停止移动物体
                    isMoving = false;
                }
                else
                {
                    // 移动物体
                    footstep.transform.Translate(direction * speed * Time.deltaTime);
                }
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            BAF.SetActive(true);
            isin = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            BAF.SetActive(false);
            isin = false;
        }

    }

    private void MoveToPoint(Transform target)
    {
        footstep.transform.position = target.position;
    }


}
