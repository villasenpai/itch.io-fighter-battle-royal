using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OG_Bomb : MonoBehaviour, IBullet
{
    [SerializeField] float bombSpeed;
    [SerializeField] Collider2D collision;
    LayerMask mask;
    int damage;

    IColliderGetter collisionScanner;
    Rigidbody2D bombBody;

    public LayerMask fighterMask
    {
        get
        {
            return mask;
        }
        set
        {
            mask = value;
        }
    }
    public int bulletDamage
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

    public Collider2D bulletCollision
    {
        get
        {
            return collision;
        }
        set
        {
            collision = value;
        }
    }

    private void Awake()
    {
        collisionScanner = GetComponent<IColliderGetter>();
        bombBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        bombBody.AddForce(transform.right * bombSpeed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
    }

    void Explode()
    {
        Destroy(bombBody);
        GetComponent<Animator>().SetTrigger("Explode");
        Collider2D[] hits = collisionScanner.AllCollisionCheck(collision, fighterMask);
        foreach (Collider2D hit in hits)
        {
            if (hit == null)
                continue;

            hit.transform.GetComponent<IFighterHealth>().TakeDamage(damage);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);   
    }
}
