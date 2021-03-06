﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class SuperRabbit : MonoBehaviour
{
    [SerializeField] private float _yOffsetToPaddle;

    [SerializeField] private Transform _paddleTransform;

    [SerializeField] private PaddleMovement _paddleMovement;

    [SerializeField] private BallThrowing _ballThrowing;

    private Animator _animator;

    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _paddleMovement.OnPaddleMoveInputChanged += ToggleIsWalkingBoolInAnimator;
        _paddleMovement.OnPaddleMovingRight += FlipSpriteRendererX;
        _paddleMovement.OnPaddleMovingLeft += UnflipSpriteRendererX;

        _ballThrowing.OnStartThrowingBall += PlayThrowingAnimation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_paddleTransform.position.x, _paddleTransform.position.y - _yOffsetToPaddle, _paddleTransform.position.z);
    }

    private void ToggleIsWalkingBoolInAnimator()
    {
        _animator.SetBool("isWalking", !_animator.GetBool("isWalking"));
    }

    private void FlipSpriteRendererX()
    {
        _spriteRenderer.flipX = true;
    }

    public void StopMoving()
    {
        _animator.SetBool("isWalking", false);
    }

    private void UnflipSpriteRendererX()
    {
        _spriteRenderer.flipX = false;
    }

    private void PlayThrowingAnimation()
    {
        _animator.SetBool("isThrowingBall", true);
    }

    private void StopThrowingAnimation()
    {
        _animator.SetBool("isThrowingBall", false);
    }

    private void OnReleasedBallAnimationFrame()
    {
        _ballThrowing.ThrowBall();
    }
}
