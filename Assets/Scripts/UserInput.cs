﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UserInput : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0)) {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();

            //swipe upwards
            if (currentSwipe.y > 0 & currentSwipe.x > -0.5f & currentSwipe.x < 0.5f) {
                Debug.Log("up swipe");
            }
            //swipe down
            if (currentSwipe.y < 0 & currentSwipe.x > -0.5f & currentSwipe.x < 0.5f) {
                Debug.Log("down swipe");
            }
            //swipe left
            if (currentSwipe.x < 0 & currentSwipe.y > -0.5f & currentSwipe.y < 0.5f) {
                Debug.Log("left swipe");
                transform.DOMoveX(transform.position.x + 0.5f, 0.2f);
            }
            //swipe right
            if (currentSwipe.x > 0 & currentSwipe.y > -0.5f & currentSwipe.y < 0.5f) {
                Debug.Log("right swipe");
                transform.DOMoveX(transform.position.x - 0.5f, 0.2f);
            }
        }
    }
}


