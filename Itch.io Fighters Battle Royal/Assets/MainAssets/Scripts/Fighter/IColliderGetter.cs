using UnityEngine;

public interface IColliderGetter
{
    Collider2D SingleCollisionCheck(Collider2D checkingBound, LayerMask mask);

    Collider2D[] AllCollisionCheck(Collider2D checkingBound, LayerMask mask);
}



