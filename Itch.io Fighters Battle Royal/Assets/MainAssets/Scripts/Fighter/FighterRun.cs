using UnityEngine;

public class FighterRun : MonoBehaviour, IFighterRun
{
    [Header("Run State")]
    [SerializeField] Transform wallScanPoint;
    [SerializeField] LayerMask wallMask;
    float movementSpeed;
    bool canRun = true;

    IColliderGetter collisionScanner;
    Rigidbody2D fighterBody;

    public float fighterMoveSpeed
    {
        get
        {
            return movementSpeed;
        }
        set
        {
            movementSpeed = value;
        }
    }

    private void Awake()
    {
        collisionScanner = GetComponent<IColliderGetter>();
        fighterBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!canRun)
            return;

        float horizontalSpeed = 0f;
        horizontalSpeed = transform.right.x * movementSpeed * Time.fixedDeltaTime;
        CheckForCollision();
        fighterBody.velocity = new Vector2(horizontalSpeed, fighterBody.velocity.y);

    }

    public void Run()
    {
        canRun = true;
    }

    public void Stop()
    {
        fighterBody.velocity = new Vector2(0f, fighterBody.velocity.y);
        canRun = false;
    }

    void CheckForCollision()
    {
        if (collisionScanner.SingleCollisionCheck(wallScanPoint, wallMask))
        {
            transform.Rotate(0f, 180f, 0);
        }
    }
}



