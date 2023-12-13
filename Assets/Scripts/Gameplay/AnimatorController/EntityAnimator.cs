using UnityEngine;

public class EntityAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private int directionXHash = Animator.StringToHash("DirectionX");
    private int directionYHash = Animator.StringToHash("DirectionY");
    private int isJumpHash = Animator.StringToHash("IsJump");
    private int isAttackHash = Animator.StringToHash("IsAttack");

    public void SetDirection(Vector2 direction)
    {
        direction.Normalize();
        var movementDirection = new Vector3(direction.x, 0f, direction.y);
        var relativeDirection = transform.InverseTransformDirection(movementDirection);

        animator.SetFloat(directionXHash, relativeDirection.x);
        animator.SetFloat(directionYHash, relativeDirection.z);
    }

    public void SetJump(bool isJump)
    {
        animator.SetBool(isJumpHash, isJump);
    }

    public void SetAttack(bool isAttack)
    {
        animator.SetBool(isAttackHash, isAttack);
    }
}
