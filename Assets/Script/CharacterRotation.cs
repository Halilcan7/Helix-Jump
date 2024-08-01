using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    public GameObject Level_General;
    public float rotationSpeed = 200f;

    private Vector2 touchStartPos;

    void Update()
    {
        if (Level_General == null)
        {
            Level_General = GameObject.Find("Level_General");

            if (Level_General == null)
            {
                return;
            }
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                float deltaX = touch.position.x - touchStartPos.x;
                RotateLevel(deltaX);
                touchStartPos = touch.position;
            }
        }
        else if (Input.GetMouseButton(0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                touchStartPos = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0))
            {
                float deltaX = Input.mousePosition.x - touchStartPos.x;
                RotateLevel(deltaX);
                touchStartPos = Input.mousePosition;
            }
        }
    }

    void RotateLevel(float deltaX)
    {
        float rotation = deltaX * rotationSpeed * Time.deltaTime;
        Level_General.transform.Rotate(0f, -rotation, 0f);
    }
 }   