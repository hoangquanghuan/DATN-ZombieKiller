using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerObject : Person
{
    [Header("Propertise of Player")]
    public float speedMouse;
    public float minCamera, MaxCamera;
    public StateForPlayer.StateMovePlayer StateMovePlayer;
    public CharacterController characterControllerPlayer;
    public Animator ThanTren, ThanDuoi;
    public Transform posSpine;
    public Transform transformCam;

    [Header("Propertise Check Ground")]
    public Transform posCheckGround;
    public Transform posCheckGroundToChangeAnim;

    [Header("Propertise when to jump of player")]
    public LayerMask layerMask;
    public bool isGround, isCheckAnimEndJump;

    public StateForPlayer.StateMovePlayer InputKeyMove()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StateMovePlayer = StateForPlayer.StateMovePlayer.Jump;
            return StateMovePlayer;
        }
        StateMovePlayer = StateForPlayer.StateMovePlayer.unset;
        if (Input.GetKey(KeyCode.W))
        {
            StateMovePlayer = StateForPlayer.StateMovePlayer.W;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                StateMovePlayer = StateForPlayer.StateMovePlayer.Shift_W;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            StateMovePlayer = StateForPlayer.StateMovePlayer.S;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                StateMovePlayer = StateForPlayer.StateMovePlayer.Shift_S;
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            StateMovePlayer = StateForPlayer.StateMovePlayer.A;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                StateMovePlayer = StateForPlayer.StateMovePlayer.Shift_A;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            StateMovePlayer = StateForPlayer.StateMovePlayer.D;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                StateMovePlayer = StateForPlayer.StateMovePlayer.Shift_D;
            }
        }
        return StateMovePlayer;
    }

    public void ResetPosYOfPlayer()
    {
        if (isGround)
        {
            Func.vecMovePlayer = Vector3.zero;
            Func.vecMovePlayer = transform.localPosition;
            Func.vecMovePlayer.y = 0.15f;
            transform.localPosition = Func.vecMovePlayer;
        }
    }

    public void SetUpMovePlayer(string nameAnim)
    {
        if (isCheckAnimMove)
        {
            ThanDuoi.SetBool(nameAnim, true);
        }
    }

    public void ResetAnimMovePlayer()
    {
        ThanDuoi.SetBool("W", false);
        ThanDuoi.SetBool("S", false);
        ThanDuoi.SetBool("A", false);
        ThanDuoi.SetBool("D", false);
        ThanDuoi.SetBool("Shift_W", false);
        ThanDuoi.SetBool("Shift_S", false);
        ThanDuoi.SetBool("Shift_A", false);
        ThanDuoi.SetBool("Shift_D", false);
    }
}
