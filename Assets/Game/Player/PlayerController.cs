using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : NetworkBehaviour
{
    public Animator CharacterAnimator
    {
        get;
        private set;
    }
    public Rigidbody2D CharacterRigid
    {
        get;
        private set;
    }

    Vector2 _move;

    private void Start()
    {
        CharacterAnimator = GetComponentInChildren<Animator>();
        CharacterRigid = GetComponentInChildren<Rigidbody2D>();
    }

    private void Update()
    {
        if (!IsLocalPlayer)
        {
            return;
        }
        Move(_move);
    }

    private void Move(Vector2 direction)
    {
        Vector2 moveDir = ((transform.up * direction.y) + (transform.right * direction.x)) * 0.65f;
        CharacterRigid.velocity = new Vector2(moveDir.x, moveDir.y);
    }

    #region InputEvents
    public void OnMove(InputAction.CallbackContext context)
    {
        _move = context.ReadValue<Vector2>();
    }
    #endregion

}
