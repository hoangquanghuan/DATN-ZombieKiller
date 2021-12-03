using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public StateGamePlay stateGamePlay;

    [Header("Gravity Of Environment")]
    public float gravityEnvir;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        stateGamePlay = StateGamePlay.PlayGame;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public enum StateGamePlay
    {
        unset = 0,
        Home,
        PlayGame,
        Pause,
        Win,
        Lose
    }

}
