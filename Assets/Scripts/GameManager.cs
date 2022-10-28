using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverui; 
    public GameObject inGameUI;
    GameStage stage; // stage flags
    static GameManager instance;
    // Start is called before the first frame update
    private void Awake() {
        if(instance != null){
            Destroy(gameObject);
        }
        instance = this;
        // Debug.Log(this);
    }
    void Start()
    {
        stage = GameStage.START;
    }
    public static void GameOver(bool dead){
        if(dead){
            instance.gameoverui.SetActive(true);
            Time.timeScale = 0f;
        } 
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
