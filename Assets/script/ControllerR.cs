using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerR : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject footstep_r;
    public GameObject ConR;
    public float rotationAngle = 10f;
    private bool isin = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && isin)
        {
            RotateClockwise();
        }

        if (Input.GetKeyDown(KeyCode.M) && isin)
        {
            RotateCounterClockwise();
        }
    }

    void RotateClockwise()
    {
        StartCoroutine(Rotate(rotationAngle));
    }

    void RotateCounterClockwise()
    {
        StartCoroutine(Rotate(-rotationAngle));
    }

    IEnumerator Rotate(float angle)
    {
        Quaternion startRotation = footstep_r.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0f, angle,0f) * startRotation;
        float elapsedTime = 0f;
        float rotationTime = 1f; // 自转时间

        while (elapsedTime < rotationTime)
        {
            footstep_r.transform.RotateAround(footstep_r.transform.position, Vector3.up, angle * Time.deltaTime / rotationTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        footstep_r.transform.rotation = endRotation;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            ConR.SetActive(true);
            isin = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            ConR.SetActive(false);
            isin = false;
        }

    }
}
