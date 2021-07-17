public interface IFighterAttack
{

    float fighterAttackInterval { get; set; }
    float fighterSpecialAttackInterval { get; set; }
    int fighterAttackDamage { get; set; }
    int fighterSpecialAttackDamage { get; set; }


    void Timer();
    void Attack();
    void SpecialAttack();

}



