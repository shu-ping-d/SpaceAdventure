using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : WeaponBase
{
    public Transform HandPos;
    public float Gx;
    public float Gy;
    public float Gz;
    public float Distance;
    public float angle;
    private new Collider2D[] collider = new Collider2D[20];
    

    public override void Attack()
    {
        animator.SetTrigger("Attack");
    }
    public override void Hit()
    {
        float a = transform.eulerAngles.z - 0;
        int count = Physics2D.OverlapBoxNonAlloc(transform.position + HandPos.up.normalized * Distance, new Vector2(Gx, Gy), a, collider ,enemyLayer);
        Debug.Log(a);
        if(count > 0)
        {
            for(int i = 0; i < count; i++)
            {
                Destroy(collider[i].gameObject);
            }
        }
    }
}
