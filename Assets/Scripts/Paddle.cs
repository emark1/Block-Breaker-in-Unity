using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float screenWidthInUnits = 16f;    
    [SerializeField] float maxPaddleX = 15f;
    [SerializeField] float minPaddleX = 1f;
    
    GameStatus gameStatus;
    Ball ball;
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        // float mousePosUnits = Mathf.Clamp(Input.mousePosition.x / Screen.width * screenWidthInUnits, minPaddleX, maxPaddleX);
        Vector2 paddlePos = new Vector2 (GetXPos(), transform.position.y);
        transform.position = paddlePos;
    }

    private float GetXPos() {
        if (gameStatus.IsAutoPlayEnabled()) {
            return ball.transform.position.x;
        }
        else {
            return Mathf.Clamp(Input.mousePosition.x / Screen.width * screenWidthInUnits, minPaddleX, maxPaddleX);
        }
    }
}
