using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterController : MonoBehaviour
{
    public enum FighterState
    {
        Run,
        Attack,
        Special,
        Hurt,
        Die
    }
    FighterState fighterState;

    [SerializeField] FighterStat fighterStat;

    IFighterRun fighterRun;
    IFighterAttack fighterAttack;

    AnimationController animationController;

    private void Awake()
    {
        fighterRun = GetComponent<IFighterRun>();
        fighterAttack = GetComponent<IFighterAttack>();
        animationController = GetComponent<AnimationController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        fighterRun.fighterMoveSpeed = fighterStat.fighterMoveSpeed;
        fighterAttack.fighterDamage = fighterStat.fighterDamage;
        fighterAttack.fighterAttackInterval = fighterStat.fighterAttackInterval;
        fighterAttack.fighterSpecialAttackInterval = fighterStat.fighterSpecialAttackInterval;
        GetComponent<IFighterHealth>().fighterHealth = fighterStat.fighterHealth;
        GetComponent<IFighterHealth>().fighterMaxHealth = fighterStat.fighterHealth;
        SwitchState(FighterState.Run);
    }

    private void Update()
    {
        fighterAttack.Timer();
    }

    public void SwitchState(FighterState toState)
    {
        fighterState = toState;
        animationController.Animate(fighterState.ToString());

        if (!toState.Equals(FighterState.Run))
            fighterRun.Stop();
        else
            fighterRun.Run();
    }

}
