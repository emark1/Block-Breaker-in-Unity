﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle1;
    [SerializeField] float velocityX = 2f;
    [SerializeField] float velocityY = 15f;
    [SerializeField] AudioClip[] ballSounds;

    Vector2 paddleToBallVector;
    bool hasStarted = false;
    AudioSource myAudioSource;

    private void BallToPaddleLock() {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchBall() {
        if (Input.GetMouseButtonDown(0)) {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2 (velocityX, velocityY);           
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted == false) {
            BallToPaddleLock();
            LaunchBall();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (hasStarted) {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }
}
