using UnityEngine;

public class MinotaurAttack : MonoBehaviour, IFighterAttack
{
    [Header("Attack State")]
    [SerializeField] LayerMask fighterMask;
    [SerializeField] CircleCollider2D[] attackPoints;
    float attackInterval;
    float specialAttackInterval;
    int damage;
    float attackTimer = 0;
    float specialAttackTimer = 0;
    int specialAttackCounter = 1;

    FighterController fighterController;
    IColliderGetter collisionScanner;

    public float fighterAttackInterval
    {
        get
        {
            return attackInterval;
        }
        set
        {
            attackInterval = value;
        }
    }
    public float fighterSpecialAttackInterval
    {
        get
        {
            return specialAttackInterval;
        }
        set
        {
            specialAttackInterval = value;
        }
    }
    public int fighterDamage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }

    private void Awake()
    {
        fighterController = GetComponent<FighterController>();
        collisionScanner = GetComponent<IColliderGetter>();
    }

    public void Timer()
    {
        float mainTimer = Time.deltaTime;

        if (attackTimer < attackInterval)
            attackTimer += mainTimer;

        if (specialAttackTimer < specialAttackInterval)
            specialAttackTimer += mainTimer;

        if (specialAttackTimer >= specialAttackInterval)
        {
            specialAttackTimer -= specialAttackInterval;
            attackTimer -= attackInterval;
            fighterController.SwitchState(FighterController.FighterState.Special);
        }
        else if (attackTimer >= attackInterval)
        {
            attackTimer -= attackInterval;
            fighterController.SwitchState(FighterController.FighterState.Attack);
        }
    }

    public void Attack()
    {
        Collider2D hit = collisionScanner.SingleCollisionCheck(attackPoints[0], fighterMask);
        if (hit == null)
            return;

        hit.transform.GetComponent<IFighterHealth>().TakeDamage(damage);
    }

    public void SpecialAttack()
    {
        print("hit " + (specialAttackCounter % 2));
        Collider2D[] hits = collisionScanner.AllCollisionCheck(attackPoints[specialAttackCounter % 2], fighterMask);
        foreach (Collider2D hit in hits)
        {
            if (hit == null)
                continue;

            hit.transform.GetComponent<IFighterHealth>().TakeDamage(damage);
        }
        specialAttackCounter++;
    }
}


