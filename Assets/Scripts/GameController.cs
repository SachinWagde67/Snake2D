using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;
    public float snakeSpeed;
    public BodyPart bodyPrefab;
    public Sprite tailSprite;
    public Sprite bodyPartSprite;
    public SnakeHead snakeHead;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartGame()
    {
        snakeHead.ResetSnake();
    }
}
