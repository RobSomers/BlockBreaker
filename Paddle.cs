using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    private Ball ball;

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

	void Update () {

        if (!autoPlay)
        {
        MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
	}

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, -7.5f, 7.5f);
        this.transform.position = paddlePos;
    }

    void MoveWithMouse ()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16 - 8;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, -7.5f, 7.5f);
        this.transform.position = paddlePos;
    }
}
