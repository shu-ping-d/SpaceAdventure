using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerController : MonoBehaviour{
    //public float speed = 30f;
    float speed = 30f;
    Vector3 moveVector;
    //public float forceValue=2f;
    Rigidbody2D rbody2D;
    Animator anim;
    //start?awake?
    private void Awake() {
        rbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveVector = new Vector3();
    }
    // Update is called once per frame
    void Update(){
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");
        rbody2D.velocity = moveVector*speed;
        anim.SetFloat("horizontal",Mathf.Abs(rbody2D.velocity.x));
        anim.SetFloat("vertical",Mathf.Abs(rbody2D.velocity.y));
        if(rbody2D.velocity.x != 0){
            transform.localScale = new Vector3(-moveVector.x, 1, 0);
            //Debug.Log("x!=0");
        }              
    }
    // void OnTriggerEnter2D(Collider2D other){
    //     Destroy(other.gameObject);
    // }
    // void dead(){
    //     Destroy(other.gameObject);
    // }
}
