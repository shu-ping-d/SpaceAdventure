using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : WeaponBase
{
    public Transform HandPos;
    public float Gx;
    public float Gy;
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
        if(count > 0)
        {
            for(int i = 0; i < count; i++)
            {
                Destroy(collider[i].gameObject);
            }
        }
    }
    /// <summary>
    /// 升級長度 ?
    /// </summary>
    public override void Upgrade_0()
    {
        transform.localScale *= 1.1f;
        Gx *= 1.1f;
        Gy *= 1.1f;
        Distance = Gy / 2;
    }
    /// <summary>
    /// 降低冷卻
    /// </summary>
    public override void Upgrade_1()
    {
        coolDown = Mathf.Max(0.2f, coolDown * 0.9f);
    }
}
