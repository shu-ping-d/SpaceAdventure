using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIController : MonoBehaviour
{
    int next
    {
        get{
            return currentLvl*1000;
        }
    }
    int currentXP = 0, currentLvl = 1;
    public Text levelText;
    public Scrollbar expBar;
    // Update is called once per frame
    // void Update()
    // {
    //     int next = getNext(currentLvl);
    //     levelText.text = "Lv " + currentLvl;
    //     expBar.size = (float) currentXP / next;
    // }
    public void addEXP(int xp) // TODO: implement this
    {
        Debug.Log(currentXP);
        currentXP += xp;
        checked_level();
    }
    public int getNext(int currentLvl)
    {
        return currentLvl > 1 ? currentLvl + getNext(currentLvl - 1) : 1000;
    }
    public void checked_level()
    {
        if (currentXP >= next)
        {
            currentXP -= (currentLvl*1000);
            currentLvl++;
            levelText.text = "Lv " + currentLvl;
            expBar.size = (float) currentXP / next;
        }
    }
}
