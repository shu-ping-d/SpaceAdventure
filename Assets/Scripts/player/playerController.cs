using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerController : MonoBehaviour{
    public float speed = 30f;
    // float speed = 30f;
    Vector3 moveVector,defaultScale;
    Rigidbody2D rbody2D;
    Animator anim;
    character chara;
    //start?awake?

    public GameObject MainWeapon;
    public GameObject SecondWeapon;

    private void Awake() {
        rbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        chara = GetComponent<character>();
        moveVector = new Vector3();
        defaultScale = transform.localScale;
    }
    void Update(){
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");
        rbody2D.velocity = moveVector*speed;
        anim.SetFloat("horizontal",Mathf.Abs(rbody2D.velocity.x));
        anim.SetFloat("vertical",Mathf.Abs(rbody2D.velocity.y));
        if(rbody2D.velocity.x != 0){
            transform.localScale = new Vector3(-moveVector.x * defaultScale.x, defaultScale.y, defaultScale.z);
            //Debug.Log("x!=0");
        }
        if (Input.GetKeyDown(KeyCode.Q))
            ChangeWeapon();
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Enemy"){
            chara.takeDamage(300);
            Destroy(other.gameObject);
        }
        
    }
    public void ChangeWeapon()
    {
        MainWeapon.SetActive(!MainWeapon.activeInHierarchy);
        SecondWeapon.SetActive(!SecondWeapon.activeInHierarchy);
    }

    // void dead(){
    //     Destroy(other.gameObject);
    // }
}
