using UnityEngine;

public class OldGuardian : MonoBehaviour, IFighterAttack
{
    [Header("Attack State")]
    [SerializeField] LayerMask fighterMask;
    [SerializeField] CircleCollider2D[] attackPoints;
    [SerializeField] GameObject bombPrefab;
    float attackInterval;
    float specialAttackInterval;
    int damage;
    float attackTimer = 0;
    float specialAttackTimer = 0;

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
        GameObject bomb = Instantiate(bombPrefab, attackPoints[1].gameObject.transform.position, attackPoints[1].gameObject.transform.rotation);
        IBullet bombBullet = bomb.GetComponent<IBullet>();
        bombBullet.bulletCollision = attackPoints[0];
        bombBullet.bulletDamage = fighterDamage;
        bombBullet.fighterMask = fighterMask;
    }
}




