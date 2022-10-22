using System.Threading;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public float coolDown;
    protected float TimeCount;
    [SerializeField]
    protected LayerMask enemyLayer;


    protected Animator animator;

    protected void Awake()
    {
        animator = GetComponent<Animator>();
        TimeCount = 0;
    }

    // Update is called once per frame
    protected void Update()
    {
        if (TimeCount > 0)
            TimeCount -= Time.deltaTime;
        if(Input.GetKey(KeyCode.Mouse0) && TimeCount <= 0)
        {
            TimeCount = coolDown;
            Attack();
        }

    }
    public virtual void Attack()
    {
        Debug.Log("WeaponBase  Attack");
    }
    public virtual void Hit()
    {
        Debug.Log("WeaponBase  Hit");
    }
}
