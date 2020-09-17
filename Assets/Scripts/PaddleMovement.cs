﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] private PaddleData _data;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - _data.MoveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + _data.MoveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }
}