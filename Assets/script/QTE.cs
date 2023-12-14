using UnityEngine;
using UnityEngine.UI;

public class QTE : MonoBehaviour
{
    public GameObject qte;
    private bool init = false;
    public GameObject player;
    public Transform position;
    public GameObject qte_ui;
    private bool canUse = false;
    private float time = 0f;
    private float time2 = 0f;
    private bool flag=false;
    public Image qteCD;
    public GameObject qteCD2;


    void Start()
    {
        time = 0f;
        time2 = 0f;
        if (qte != null)
        {
            Renderer renderer = qte.GetComponent<Renderer>();
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

    private void Update()
    {
        if(init && GlobalData.Instance.suberMode)
        {
            player.transform.position = position.position;
            flag = true;
        }
        if (canUse)
        {
            if (Input.GetKeyDown(KeyCode.Q) && !GlobalData.Instance.qteSuccess)
            {
                qte_ui.SetActive(false);
                GlobalData.Instance.qteSuccess = true;
                player.transform.position = position.position;
                flag = true;

            }
        }
      // Debug.Log(GlobalData.Instance.qteSuccess+"+"+time);
        if (GlobalData.Instance.qteSuccess)
        {
            time += Time.deltaTime;
            qteCD2.SetActive(true);
            qteCD.fillAmount = time/10f;//重要！！！ cd时间
            if (time > 10f)//重要！！！ cd时间
            {
                time = 0f;
                qteCD2.SetActive(false);
                GlobalData.Instance.qteSuccess = false;
                
            }
        }
        if (!GlobalData.Instance.qteSuccess)
        {
            time = 0f;
        }

        if (flag)
        {
            Time.timeScale = 0.1f;
            GlobalData.Instance.timeFreeze = true;
            time2 += Time.deltaTime;
            if (time2 > 0.1f)
            {
                GlobalData.Instance.timeFreeze = false;
                time2 = 0f;
                Time.timeScale = 1f;
                flag = false;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            if(!GlobalData.Instance.qteSuccess)
            {
                qte_ui.SetActive(true);
                canUse=true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Player>() != null)
        {
            init = true;   
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            init = false;
            qte_ui.SetActive(false);
            canUse = false;
        }
    }

}
