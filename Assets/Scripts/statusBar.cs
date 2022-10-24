using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statusBar : MonoBehaviour
{
    public Transform bar;
    public void setState(int cur, int max){
        float state = (float) cur;
        state /= max;
        if(state < 0f) state = 0f;
        bar.transform.localScale = new Vector3(state, 1f, 1f);
    }
}
