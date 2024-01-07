using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;
    public float rotationSpeed = 3.0f;
  //  private bool isGrounded;
    private bool isJumping=false;
    private float jumpTimeCounter;
    public float jumpTime =0.5f;
    private int flag = 0;
    private bool flag2=false;
    private float time = 0f;
    private float time2 = 0f;
    public float suberModeTime = 2f;
    private float suberModeRealContainTime = 10f;
    public float suberModeContainTime = 10f;
    private bool authorizationGet=false;
    public GameObject subermode_ui;
    public Image supermode_ui;
    private bool isShow = false;
    public GameObject menu;
    public GameObject dif;
    public GameObject transmit_to;
    public TMPro.TextMeshProUGUI m_enegy;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = (1);
        if (GlobalData.Instance.normal == false)
        {
            transmit_to.SetActive(false);
        }
        
    }

    void Update()
    {
        // 玩家移动控制
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;
        Vector3 movement = transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime;
        if (!GlobalData.Instance.timeFreeze)
        {
            rb.MovePosition(rb.position + movement);
        }
        

        // 玩家跳跃控制
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //}


        if (Input.GetKeyDown(KeyCode.Space) && !isJumping )
        {
           // Debug.Log("1");
            isJumping = true;
            jumpTimeCounter = jumpTime;
            flag++;
            if (flag == 1)
            Jump();
            
        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
         //   Debug.Log("2");
            
            if (jumpTimeCounter > 0)
            {
                if(flag==1)
                Jump();
                jumpTimeCounter -= Time.deltaTime;
            }
           
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }


        //if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log("111");
        //    isJumping = true;
        //    jumpTimeCounter = jumpTime;
        //    rb.velocity = Vector3.up * jumpForce;
        //  //  rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //}


        //if(Input.GetKey(KeyCode.Space)&& isJumping)
        //{
        //    Debug.Log("222");
        //    if (jumpTimeCounter > 0)
        //    {
        //        // rb.velocity = Vector3.down * jumpForce;
        //        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //        jumpTimeCounter -= Time.deltaTime;
        //    }
        //    else
        //    {
        //        Debug.Log("4444");
        //        isJumping =false;
        //    }
        //}

        //    Debug.Log(isGrounded);

        if (!isShow)
        {
            // 视角旋转控制
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            Vector3 rotation = new Vector3(0.0f, mouseX, 0.0f) * rotationSpeed;
            rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
            Camera.main.transform.Rotate(-mouseY, 0.0f, 0.0f);
        }
        //Debug.Log("flag=" + flag);
        // Debug.Log(GlobalData.Instance.suberMode);
        m_enegy.text = "Enegy: " + GlobalData.Instance.enegy + "/100";
        if (GlobalData.Instance.enegy <= 0)
        {
            //Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.Locked;
            SceneManager.LoadScene("Lose");
        }

        if (flag != 0)
        {
            time += Time.deltaTime;
          //  Debug.Log(time);
            if(time > suberModeTime && GlobalData.Instance.normal)
            {
                authorizationGet = true;
                suberModeRealContainTime = suberModeContainTime + (time-suberModeTime)/2;


            }
        }
        if (flag == 0)
        {
            time = 0f;
        }

        if (GlobalData.Instance.suberMode)
        {
            if (!flag2)
            {
                GlobalData.Instance.enegy -= 2;
                flag2 = true;
            }
            time2 += Time.deltaTime;
            subermode_ui.SetActive(true);
            supermode_ui.fillAmount = (suberModeRealContainTime-time2) / suberModeRealContainTime;
            if (time2> suberModeRealContainTime)
            {
                GlobalData.Instance.suberMode = false;
                subermode_ui.SetActive(false);
                time2 = 0f;
                flag2 = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //如果面板正在显示，关掉面板并让游戏继续运行
            if (isShow)
            {
                menu.SetActive(false);
                isShow = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = (1);
                dif.SetActive(false);
            }
            //否则开启面板并暂停游戏
            else
            {
                menu.SetActive(true);
                isShow = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = (0);
            }
        }
    }
    

    //private void OnTriggerEnter(Collider other)
    //{

    //    if (other.GetComponent<Ground>()!=null)
    //    {
    //        isGrounded=true;
    //        Debug.Log("aaaaaaaaaaaa");
    //    }
    //    else
    //    {
    //        isGrounded=false;
    //    }
    //}
    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.GetComponent<Ground>()!=null) // 假设Ground物体有一个"Ground"的tag
    //    {
    //      //  Debug.Log("物体与Ground接触");
            
    //            isGrounded = true;
                
    //        }
    //         else
    //        {
    //            isGrounded = false;
    //        }
        
    // }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ground>() != null)
        {
            flag = 0;
            if(authorizationGet)
            {
                GlobalData.Instance.suberMode = true;
                authorizationGet = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Ground>() != null)
        {
            flag = 0;
            if (authorizationGet)
            {
                GlobalData.Instance.suberMode = true;
                authorizationGet = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Ground>() != null)
        {
            flag=1;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ground>() != null)
        {
            flag=1;
        }
    }


    void Jump()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, jumpForce, GetComponent<Rigidbody>().velocity.z);
    }

}
