using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAni : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
  //  private Rigidbody rb;
    public GameObject player;
    private Vector3 previousPosition;
    void Start()
    {
      //  rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        previousPosition = player.transform.position;
    }

    void Update()
    {
        // rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);
        
       // if (player.transform.position != previousPosition)
       if (GlobalData.Instance.jumpTime==0f)
        {
            anim.SetBool("OnGround", true);
        }
        else
        {
            anim.SetBool("OnGround", false);
        }
        if(Input.GetKey(KeyCode.Space)|| Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetBool("Standing", false);
                anim.SetBool("Jumping", true);
                anim.SetBool("Moving", false);
            }
            else
            {
                anim.SetBool("Standing", false);
                anim.SetBool("Jumping", false);
                anim.SetBool("Moving", true);
            }
        }
        else
        {
            anim.SetBool("Jumping", false);
            anim.SetBool("Standing", true);
            anim.SetBool("Moving", false);
        }
        previousPosition = player.transform.position;
    }
}
