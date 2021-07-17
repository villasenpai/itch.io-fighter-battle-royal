public interface IFighterHealth
{
    int fighterHealth { get; set; }
    int fighterMaxHealth { get; set; }
    void TakeDamage(int damage);
}
