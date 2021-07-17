using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Animate(string trigger)
    {
        animator.SetTrigger(trigger);
    }
}

