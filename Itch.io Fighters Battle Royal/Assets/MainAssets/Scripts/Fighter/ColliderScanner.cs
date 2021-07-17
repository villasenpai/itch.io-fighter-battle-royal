using UnityEngine;

public class ColliderScanner : MonoBehaviour, IColliderGetter
{
    public Collider2D SingleCollisionCheck(Collider2D checkingBound, LayerMask mask)
    {
        return Physics2D.OverlapCircle(checkingBound.bounds.center, checkingBound.bounds.size.x, mask);
    }

    public Collider2D[] AllCollisionCheck(Collider2D checkingBound, LayerMask mask)
    {

        return Physics2D.OverlapCircleAll(checkingBound.bounds.center, checkingBound.bounds.size.x, mask);
    }
}



