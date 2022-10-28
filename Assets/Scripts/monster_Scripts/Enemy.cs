using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int hp = 400;
    int damage = 400;
    private float speed =1.5f;
    [SerializeField]
    private GameObject player;
    private GameObject GameManager;
    //character chara;
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("UI");
        player = GameObject.FindGameObjectWithTag("Player");
        //chara = GetComponent<character>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Swarm();
    }
    private void Swarm()
    {
        transform.position=Vector2.MoveTowards(transform.position,player.transform.position,speed*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D Collider)
    {
        if(Collider.CompareTag("weapon"))
        {
            GameManager.GetComponent<InGameUIController>().addEXP(400);
            Destroy(gameObject,0.5f);
        }
        if(Collider.CompareTag("Player"))
        {
            player.GetComponent<character>().takeDamage(100);
            Destroy(gameObject,0.5f);
        }
    }
    // public void takeDamage(int damage){
    //     hp -= damage;
    //     if(hp < 1)
    //     {
    //         Debug.Log("i am here");
    //         player.GetComponent<level>().addEXP(10);
    //         Destroy(gameObject);
    //     }
    // }
}
