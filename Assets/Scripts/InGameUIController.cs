using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIController : MonoBehaviour
{
    int currentXP = 0, currentLvl = 1;
    public Text levelText;
    public Scrollbar expBar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int next = getNext(currentLvl);
        levelText.text = "Lv " + currentLvl;
        expBar.size = (float) currentXP / next;
        if (currentXP >= next)
        {
            currentXP -= next;
            currentLvl++;
        }
    }

    public void addEXP(int xp) // TODO: implement this
    {
        currentXP += xp;
    }

    public int getNext(int currentLvl)
    {
        return currentLvl > 1 ? currentLvl + getNext(currentLvl - 1) : 1;
    }
}
