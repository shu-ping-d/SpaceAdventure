using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level : MonoBehaviour
{
    int levels = 1;
    int exp = 0;
    
    public expBar exp_bar; 
    int level_up{
        get{
            return levels * 1000;
        }
    }
    private void start(){
        exp_bar.update_exp_slider(exp, level_up);
        exp_bar.set_level_text(levels);
    }
    public void add_experience(int amount){
        exp += amount;
        check_level();
        exp_bar.update_exp_slider(exp, level_up);
    }
    public void check_level(){
        if(exp >= level_up){
            exp -= level_up;
            levels += 1;
            exp_bar.set_level_text(levels);
        }
    }
}
