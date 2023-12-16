using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour
{
    public GameObject Diff;
    private bool button=false;
    // Start is called before the first frame update
    void Start()
    {
        Diff.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void goStart()
    {
        SceneManager.LoadScene("Start");
        Debug.Log("starty");
    }

    public void adjustDiff()
    {
        if(!button)
        {
            Diff.SetActive(true);
            button = true;
        }
        else
        {
            Diff.SetActive(false);
            button = false;
        }
    }

    public void start_normal()
    {
        GlobalData.Instance.normal = true;
        SceneManager.LoadScene("Game");
    }

    public void start_hard()
    {
        GlobalData.Instance.normal = false;
        SceneManager.LoadScene("Game");
    }
}
