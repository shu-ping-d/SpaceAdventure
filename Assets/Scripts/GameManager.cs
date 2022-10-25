using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject inGameUI;
    GameStage stage; // stage flags

    // Start is called before the first frame update
    void Start()
    {
        stage = GameStage.START;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    enum GameStage
    {
        START, IN_GAME, PAUSE, DEAD
    }
}
