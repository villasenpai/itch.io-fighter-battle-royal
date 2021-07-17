public interface IFighterAttack
{

    float fighterAttackInterval { get; set; }
    float fighterSpecialAttackInterval { get; set; }
    int fighterDamage { get; set; }


    void Timer();
    void Attack();
    void SpecialAttack();

}



