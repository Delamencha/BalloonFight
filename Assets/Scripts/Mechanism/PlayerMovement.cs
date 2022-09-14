using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float horiForce = 1.0f;
    [SerializeField] float groundFixer = 0.5f;
    [SerializeField] float vertForce = 1.0f;
    [SerializeField] float maxHoriVelocity = 10f;
    [SerializeField] float maxVertVelocity = 5f;
    [SerializeField] ForceMode horiForceMode = ForceMode.Acceleration;
    [SerializeField] ForceMode vertForceMode = ForceMode.VelocityChange;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;

    Rigidbody rb;
    Health ph;
    bool isGrounded = false;
    bool isFacingRight = true;
    bool isSlowingDown = false;
    float t = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ph = GetComponent<Health>();

    }

    private void Update()
    {
        if (ph.IsDead()) return;
        float horizontalInput = Input.GetAxis("Horizontal");    
        if((horizontalInput <0 && isFacingRight) || (horizontalInput > 0 && !isFacingRight)) //左右直接控制朝向
        {
            transform.Rotate(new Vector3(0, 180, 0));
            isFacingRight = !isFacingRight;
        }

        isGrounded = Physics.CheckBox(groundCheck.position, new Vector3(0.5f, 0.35f, 0.48f), Quaternion.identity, groundMask); //检查是否在平地上，在平地上时控制逻辑改变
        
        if (Input.GetButtonDown("Jump")) //在空中只有向上飞时才能控制左右加速
        {
            rb.AddForce(Vector3.up * vertForce * Time.deltaTime, vertForceMode);
            rb.AddForce(Vector3.forward * horiForce * Time.deltaTime * horizontalInput, horiForceMode);
        }

        if (isGrounded)  //在平地时，控制左右移动更自由
        {
            rb.useGravity = false;
            Vector3 temp = rb.velocity;
            temp.y = 0;
            rb.velocity = temp;

            rb.AddForce(Vector3.forward * horiForce * groundFixer * Time.deltaTime * horizontalInput, horiForceMode);
            if(horizontalInput == 0 && rb.velocity.z != 0 ) //模拟惯性
            {
                SlowDown(rb.velocity.z);
            }
            else
            {
                isSlowingDown = false;
            }

        }
        else
        {
            rb.useGravity = true;
            isSlowingDown = false;
        }


        Vector3 v = rb.velocity;
        v.z = Mathf.Clamp(rb.velocity.z, -maxHoriVelocity, maxHoriVelocity);
        v.y = Mathf.Clamp(rb.velocity.y, -maxVertVelocity * 2, maxVertVelocity);  //限制垂直以及水平速度最大值
        rb.velocity = v;


    }

    private void SlowDown(float z)
    {
        //Debug.Log("SlowDown");
        if (!isSlowingDown) t = 0; //上一帧如果不在slowdown过程中，则重置slowdown计时器t
        isSlowingDown = true; //标记player这一帧进入slowdown
        t += Time.deltaTime;    

        Vector3 vel = new Vector3(0, 0, Mathf.Lerp(z,0,t)); //线性插值模拟减速
        rb.velocity = vel;
        if (t >= 1) t = 0;
    }

    public void ProcessBounce(Vector3 targetToPlayer, float bounceForce)
    {
        rb.AddForce(targetToPlayer.normalized * bounceForce , ForceMode.VelocityChange);

    }

    public bool IsGrounded()
    {
        return isGrounded;
    }

    public bool IsFacingRight()
    {
        return isFacingRight;
    }

    //private void OnDrawGizmos() //查看checkbox范围
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(groundCheck.position, new Vector3(1.0f, 0.7f, 1.1f));
    //}

}
