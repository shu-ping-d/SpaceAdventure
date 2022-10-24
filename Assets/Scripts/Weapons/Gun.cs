using System.Collections;
using UnityEngine;

public class Gun : WeaponBase
{
    public GameObject BulletPrefab;
    public GameObject Muzzle;

    public float bulletAngle;
    public int bulletNum;

    protected override void Awake()
    {
        base.Awake();
        Muzzle = transform.Find("Muzzle").gameObject;
        Muzzle.SetActive(false);
    }
    /// <summary>
    /// 提升子彈數量
    /// </summary>
    public override void Upgrade_0()
    {
        bulletNum++;
    }
    /// <summary>
    /// 降低冷卻
    /// </summary>
    public override void Upgrade_1()
    {
        coolDown = Mathf.Max(0.2f , coolDown * 0.9f); 
    }

    public override void Attack()
    {
        int median = bulletNum / 2;
        for(int i = 0; i < bulletNum; i++)
        {
            GameObject bullet = Instantiate(BulletPrefab, Muzzle.transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z + 90));
            if(bulletNum % 2 == 0)
            {
                bullet.GetComponent<Bullet>().SetVelocity(Quaternion.AngleAxis(bulletAngle * (i - median) + bulletAngle / 2 , Vector3.forward) * direction);
            }
            else
            {
                bullet.GetComponent<Bullet>().SetVelocity(Quaternion.AngleAxis(bulletAngle * (i - median), Vector3.forward) * direction);
            }
        }
        StartCoroutine(nameof(MuzzleControl));
    }
    public override void DirectToCamera()
    {
        direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        if(direction.x < 0)
        {
            transform.localScale = new Vector2(1,1);
        }
        else
        {
            transform.localScale = new Vector2(1, -1);
        }
        transform.right = -direction;
    }
    private IEnumerator MuzzleControl()
    {
        Muzzle.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Muzzle.SetActive(false);
    }
}
