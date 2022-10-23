using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public int maxHP = 1000;
    public int curHP = 1000;
    public statusBar hpBar;
    public void takeDamage(int damage){
        curHP -= damage;
        if(curHP <= 0)
            Debug.Log("GAME OVER"); 
        hpBar.setState(curHP, maxHP);

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
