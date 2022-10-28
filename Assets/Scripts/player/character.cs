using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class character : MonoBehaviour
{
    bool playerDead;
    public int maxHP = 1000;
    public int curHP = 1000;
    public statusBar hpBar;
    Animator anim;
    private void Awake() {
        anim = GetComponent<Animator>();
        //game = gameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void takeDamage(int damage){
        
        curHP -= damage;
        if(curHP <= 0){
            anim.SetTrigger("dead");
        }
            
        hpBar.setState(curHP, maxHP);

    }
    public void PlayerDead(){
        GameManager.GameOver(true);
    }
    public void heal(int amount){
        if(curHP <= 0){
            return;
        }
        curHP += amount;
        if(curHP > maxHP){
            curHP = maxHP;
        }
    }
}
