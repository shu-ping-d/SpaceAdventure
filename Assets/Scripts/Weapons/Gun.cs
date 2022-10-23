using System.Collections;
using UnityEngine;

public class Gun : WeaponBase
{
    public GameObject BulletPrefab;
    public GameObject Muzzle;

    protected override void Awake()
    {
        base.Awake();
        Muzzle = transform.Find("Muzzle").gameObject;
        Muzzle.SetActive(false);
    }
    public override void Attack()
    {
        GameObject bullet = Instantiate(BulletPrefab , Muzzle.transform.position ,  Quaternion.Euler(0,0, transform.eulerAngles.z +90));
        bullet.GetComponent<Bullet>().SetVelocity(direction);
        StartCoroutine("MuzzleControl");
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
