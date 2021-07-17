using UnityEngine;

public class ColliderScanner : MonoBehaviour, IColliderGetter
{
    public Collider2D SingleCollisionCheck(Transform checkingPoint, LayerMask mask)
    {
        return Physics2D.OverlapCircle(checkingPoint.position, 0.5f, mask);
    }

    public Collider2D[] AllCollisionCheck(Transform checkingPoint, LayerMask mask)
    {

        return Physics2D.OverlapCircleAll(checkingPoint.position, 0.5f, mask);
    }
}



