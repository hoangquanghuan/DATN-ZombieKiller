using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateForPlayer
{
    public enum StateMovePlayer
    {
        unset = 0,
        A,
        D,
        W,
        S,
        Shift_A,
        Shift_D,
        Shift_W,
        Shift_S,
        Jump
    }
}
