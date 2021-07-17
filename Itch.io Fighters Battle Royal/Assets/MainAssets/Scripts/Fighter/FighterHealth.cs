using UnityEngine;

public class FighterHealth : MonoBehaviour, IFighterHealth
{

    FighterController fighterController;

    [Header("Health")]
    [SerializeField] HealthBar hpBar;
    int health;
    int maxHealth;

    public int fighterHealth 
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }
    public int fighterMaxHealth
    {
        get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = value;
        }
    }


    private void Awake()
    {
        fighterController = GetComponent<FighterController>();
    }

    private void Start()
    {
        maxHealth = health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        hpBar.UpdateHP(health / (float)maxHealth);

        if (health <= 0)
            fighterController.SwitchState(FighterController.FighterState.Die);
        else
            fighterController.SwitchState(FighterController.FighterState.Hurt);

    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
