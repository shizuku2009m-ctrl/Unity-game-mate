using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody pleyerRigidbody;
    float speed =30.0f;
    public int jumpcount;
    public int maxjumpcount = 3;
    float inputHorizontal;
    float inputVertical;
    
    // 25=Au$SCH
    // Start is called before the first frame update
    void Start()
    {
        pleyerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        if(Input.GetKeyDown(KeyCode.Space) && jumpcount < maxjumpcount)
       {
            pleyerRigidbody.velocity = new Vector3(0,6,0);
            jumpcount ++;
            Debug.Log(jumpcount);
       }

        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
    
        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;
    
        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        pleyerRigidbody.velocity = moveForward * speed + new Vector3(0, pleyerRigidbody.velocity.y, 0);
    
        // キャラクターの向きを進行方向に
        // if (moveForward != Vector3.zero) {
        //     transform.rotation = Quaternion.LookRotation(moveForward);
        // }

       if(Input.GetKey(KeyCode.W))
       {
        // transform.position += new Vector3(0,0,speed*Time.deltaTime );
        //Debug.Log("Go");
       }
       if(Input.GetKey(KeyCode.S))
       {
        // transform.position += new Vector3(0,0,-speed*Time.deltaTime);
        //Debug.Log("back");
       }
       if(Input.GetKey(KeyCode.A))
       {
        // transform.position += new Vector3(-speed*Time.deltaTime,0,0);
        //Debug.Log("Left");
       }
       if(Input.GetKey(KeyCode.D))
       {
        // transform.position += new Vector3(speed*Time.deltaTime,0,0);
        //Debug.Log("Right");
       }
       
    }  

    void OnCollisionEnter (Collision other)
    {
        if(other.gameObject.tag == "floor")
        {
            jumpcount = 0;
        }
    }
}
