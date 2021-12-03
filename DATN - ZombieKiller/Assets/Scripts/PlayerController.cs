using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerObject
{
    private void Awake()
    {
        isCheckAnimMove = false; 
        isGround = false;
    }
    private void Start()
    {
        Camera.main.transform.parent = transformCam;
        Camera.main.transform.localPosition = Vector3.zero;

    }

    private void FixedUpdate()
    {
        if (GameManager.instance.stateGamePlay == GameManager.StateGamePlay.PlayGame)
        {
            ChangeAnimAndMove(InputKeyMove());
            MoveOfTheMouse();
        }
    }

    public void MoveOfTheMouse()//di chuyển chuột
    {
        Func.mouseX = Input.GetAxis("Mouse X") * speedMouse * Time.deltaTime;
        Func.mouseY = Input.GetAxis("Mouse Y") * speedMouse * Time.deltaTime;

        Func.moveMouse -= Func.mouseY;
        ThanTren.transform.localRotation = Quaternion.Euler(Mathf.Clamp(Func.moveMouse, minCamera, MaxCamera), 0f, 0f);
        transform.Rotate(Vector3.up * Func.mouseX);
    }

    public void ChangeAnimAndMove(StateForPlayer.StateMovePlayer stateMovePlayer)//di chuyển cho thân dưới
    {
        ThanTren.transform.position = posSpine.position;
        isGround = Physics.CheckSphere(posCheckGround.position, characterControllerPlayer.radius, layerMask);
        isCheckAnimEndJump = Physics.CheckSphere(posCheckGroundToChangeAnim.position, Mathf.Abs(posCheckGroundToChangeAnim.localPosition.y), layerMask);


        if (isCheckAnimEndJump)
        {
            ThanDuoi.SetInteger("StartJump", 3); 
        }


        if (isGround)
        {
            Func.vecJump.y = 0;
            isCheckAnimMove = true;
        }
        else
        {
            isCheckAnimMove = false;
            Func.hightPlayer1 = transform.localPosition.y;
            Func.vecJump.y += GameManager.instance.gravityEnvir * Time.deltaTime;
            characterControllerPlayer.Move(Func.vecJump * Time.deltaTime);
            Func.hightPlayer2 = transform.localPosition.y;
            if(Func.hightPlayer2 <= Func.hightPlayer1 && !ThanDuoi.GetCurrentAnimatorClipInfo(0)[0].Equals("Jump Loop"))
            {
                ThanDuoi.SetInteger("StartJump", 2);
            }
        }

        ResetAnimMovePlayer();
        Func.x_Move = Func.z_Move = 0;
        switch (stateMovePlayer)
        {
            case StateForPlayer.StateMovePlayer.W:
                SetUpMovePlayer(nameof(StateForPlayer.StateMovePlayer.W));
                run = 1;
                Func.z_Move = 1;
                break;
            case StateForPlayer.StateMovePlayer.S:
                SetUpMovePlayer(nameof(StateForPlayer.StateMovePlayer.S));
                run = 1;
                Func.z_Move = -1;
                break;
            case StateForPlayer.StateMovePlayer.A:
                SetUpMovePlayer(nameof(StateForPlayer.StateMovePlayer.A));
                run = 1;
                Func.x_Move = -1;
                break;
            case StateForPlayer.StateMovePlayer.D:
                SetUpMovePlayer(nameof(StateForPlayer.StateMovePlayer.D));
                run = 1;
                Func.x_Move = 1;
                break;
            case StateForPlayer.StateMovePlayer.Shift_W:
                SetUpMovePlayer(nameof(StateForPlayer.StateMovePlayer.Shift_W));
                run = 2;
                Func.z_Move = 1;
                break;
            case StateForPlayer.StateMovePlayer.Shift_S:
                SetUpMovePlayer(nameof(StateForPlayer.StateMovePlayer.Shift_S));
                run = 2;
                Func.z_Move = -1;
                break;
            case StateForPlayer.StateMovePlayer.Shift_A:
                SetUpMovePlayer(nameof(StateForPlayer.StateMovePlayer.Shift_A));
                run = 2;
                Func.x_Move = -1;
                break;
            case StateForPlayer.StateMovePlayer.Shift_D:
                SetUpMovePlayer(nameof(StateForPlayer.StateMovePlayer.Shift_D));
                run = 2;
                Func.x_Move = 1;
                break;
            case StateForPlayer.StateMovePlayer.Jump:
                if (isCheckAnimMove)
                {
                    ThanDuoi.SetInteger("StartJump", 2); 
                    Func.vecJump.y += jumpHeight * (-1f) * GameManager.instance.gravityEnvir * Time.deltaTime;
                    characterControllerPlayer.Move(Func.vecJump * Time.deltaTime);
                    isCheckAnimMove = false;
                }
                break;
        }
        characterControllerPlayer.Move((transform.right * Func.x_Move + transform.forward * Func.z_Move) * speed * run * Time.deltaTime);
    }
}
