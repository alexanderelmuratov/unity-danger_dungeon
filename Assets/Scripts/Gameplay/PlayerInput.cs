using System.Collections;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputService inputService;
    [SerializeField] private Movement playerMove;
    [SerializeField] private EntityAnimator animator;
    [SerializeField] private string stepSfxKey;
    private IWeaponController weaponController;
    private Coroutine stepRoutine;
    private float stepTime = 0.3f;

    private void Start()
    {
        weaponController = GetComponent<IWeaponController>();
    }

    private void Update()
    {
        playerMove.Direction = inputService.Direction;
        playerMove.LookDirection = inputService.LookDirection;

        animator.SetDirection(inputService.Direction);
        animator.SetJump(inputService.OnJump);

        if (inputService.OnJump)
            playerMove.Jump();

        if (inputService.IsFirePressed)
            weaponController.OnFirePress();
        if (inputService.IsFireHold)
            weaponController.OnFireHold();
        if (inputService.IsFireReleased)
            weaponController.OnFireRelease();

        if (stepRoutine == null)
            stepRoutine = StartCoroutine(StepRoutine());
    }

    private IEnumerator StepRoutine()
    {
        if (inputService.InMove)
            Context.Instance.AudioSystem.PlaySFX(new AudioSettings(stepSfxKey, transform.position));

        yield return new WaitForSeconds(stepTime);
        stepRoutine = null;
    }
}
