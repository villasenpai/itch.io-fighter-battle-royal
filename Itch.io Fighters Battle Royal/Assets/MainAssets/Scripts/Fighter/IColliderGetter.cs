using UnityEngine;

public interface IColliderGetter
{
    Collider2D SingleCollisionCheck(Transform checkingPoint, LayerMask mask);

    Collider2D[] AllCollisionCheck(Transform checkingPoints, LayerMask mask);
}



