using UnityEngine;

public interface IBullet
{
    Collider2D bulletCollision { get; set; }
    int bulletDamage { get; set; }
    LayerMask fighterMask { get; set; }

    void Destroy();
}
