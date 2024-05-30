using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    Vector2 storedDirection;
    bool isMoving = false;
    void Start() {
        animator.SetFloat("LastYMovement", -1);
    }
    public void GetMoveInput(Vector2 direction) {
        storedDirection = direction;

        animator.SetFloat("LastXMovement", storedDirection.x);
        animator.SetFloat("LastYMovement", storedDirection.y);

        isMoving = true;

        SetAnimatorParameters();
    }

    public void GetPush(Vector2 direction) {
        animator.SetBool("isPushing", true);
    }
    public void ResetParameters() {
        isMoving = false;
        storedDirection = Vector2.zero;
        animator.SetBool("isPushing", false);

        SetAnimatorParameters();
    }
   
    void SetAnimatorParameters() {
        animator.SetFloat("xMovement", storedDirection.x);
        animator.SetFloat("yMovement", storedDirection.y);
        animator.SetBool("isMoving", isMoving);
    }
}
