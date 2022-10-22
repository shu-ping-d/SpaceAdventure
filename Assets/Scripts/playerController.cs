using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerController : MonoBehaviour
{
    public float move_speed = 30f;
    private Vector3 moveDir;
    //public float forceValue=2f;
    private Rigidbody2D rbody2D;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator> ();
        rbody2D = this.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        move();
        //rbody2D.AddForce(force2D);

        
    }
    void move(){
        float moveX = 0f;
        float moveY = 0f;
        if (Input.GetKey(KeyCode.W)|| Input.GetKey("up")){
            moveY += 1f;
            anim.SetInteger("state", 1);
            //transform.position += new Vector3(0,+1);
            //force2D.y += forceValue;
        }
        if (Input.GetKey(KeyCode.S)|| Input.GetKey("down")){
            anim.SetInteger("state", 1);
            moveY -= 1f;
            //force2D.y -= forceValue;
        }
        if (Input.GetKey(KeyCode.A)|| Input.GetKey("left")){
            anim.SetInteger("state", 1);
            moveX -= 1f;
            //force2D.x -= forceValue;
        }
        if (Input.GetKey(KeyCode.D)|| Input.GetKey("right")){
            anim.SetInteger("state", 1);
            moveX += 1f;
            //force2D.x += forceValue;
        }
        moveDir = new Vector3(moveX, moveY);
    }
    private void FixedUpdate() {
        rbody2D.velocity = moveDir * move_speed;
    }
    void OnTriggerEnter2D(Collider2D other){
        Destroy(other.gameObject);
    }
    void dead(){
        Destroy(other.gameObject);
    }
}
