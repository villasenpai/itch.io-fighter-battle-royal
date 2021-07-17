using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FighterStat", menuName = "SOs/FighterStat")]
public class FighterStat : ScriptableObject
{
    public int fighterHealth;
    public int fighterDamage;
    public int fighterSpecialDamage;
    public float fighterAttackInterval;
    public float fighterSpecialAttackInterval;
    public float fighterMoveSpeed;
}
