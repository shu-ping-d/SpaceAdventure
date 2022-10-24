using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class expBar : MonoBehaviour
{
    Slider slider;
    public void update_exp_slider(int cur, int target){
        slider.maxValue = target;
        slider.value = cur; 
    }
    public void set_level_text(int level){
        level_text.text = "LEVEL: " + level.ToString();
    }
}
