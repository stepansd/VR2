﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grap : MonoBehaviour
{
    public GameObject ball, hand;
    bool inHands = false;
    Vector3 ballPosition;
    // Start is called before the first frame update
    void Start()
    {
        ballPosition = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        //{
            if (!inHands)
            {
                ball.transform.SetParent(hand.transform);
                ball.transform.localPosition = new Vector3(0f, -0.9f, 0f);
                inHands = true;
            }

            else if (inHands)
            {
            this.GetComponent<Grap>().enabled = false;
                ball.transform.SetParent(null);
                ball.transform.localPosition = ballPosition;
                inHands = false;
            }
        //}
        

    }
}
