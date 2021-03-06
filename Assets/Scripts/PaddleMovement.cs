﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] private PaddleData _data;

    [SerializeField] private BallMovement _ballMovement;

    [SerializeField] private Vector3 _startPos;

    private bool isMoving;

    public bool IsMoving { get => isMoving; set => isMoving = value; }

    public delegate void PaddleMoveInputChangedHandler();

    public event PaddleMoveInputChangedHandler OnPaddleMoveInputChanged;

    public delegate void PaddleMovingRightHandler();

    public event PaddleMovingRightHandler OnPaddleMovingRight;

    public delegate void PaddleMovingLeftHandler();

    public event PaddleMovingLeftHandler OnPaddleMovingLeft;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Mouse X") < 0)
        {
            transform.position = new Vector3(transform.position.x - _data.MoveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Mouse X") > 0)
        {
            transform.position = new Vector3(transform.position.x + _data.MoveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            IsMoving = true;
            OnPaddleMoveInputChanged?.Invoke();

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                OnPaddleMovingRight?.Invoke();
            }
            else
            {
                OnPaddleMovingLeft?.Invoke();
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            IsMoving = false;
            OnPaddleMoveInputChanged?.Invoke();


        }
    }

    public void SetEnabled(bool isEnabled)
    {
        enabled = isEnabled;
    }

    public void GoToStartPosition()
    {
        transform.position = new Vector3(_startPos.x, _startPos.y);
    }
}
