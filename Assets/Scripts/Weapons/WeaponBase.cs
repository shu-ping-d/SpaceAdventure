using System.Threading;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public float coolDown;
    protected float TimeCount;
    [SerializeField]
    protected LayerMask enemyLayer;


    protected Animator animator;
    protected Vector2 direction;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        TimeCount = 0;
    }

    protected void Update()
    {
        DirectToCamera();
        if (TimeCount > 0)
            TimeCount -= Time.deltaTime;
        if(Input.GetKey(KeyCode.Mouse0) && TimeCount <= 0)
        {
            TimeCount = coolDown;
            Attack();
        }
    }
    public virtual void DirectToCamera()
    {
        direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        transform.up = direction;
    }
    public virtual void Attack()
    {
        Debug.Log("WeaponBase  Attack");
    }
    public virtual void Hit()
    {
        Debug.Log("WeaponBase  Hit");
    }

    public virtual void Upgrade_0() { }
    public virtual void Upgrade_1() { }
}
