using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Enter : MonoBehaviour
{
    private bool isMoving = false;
    private Transform objectToMove;
    private Vector3 targetPosition;
    private float moveSpeed = 2f; // Pozisyonun değişme hızı


    public GameObject PlayButton;

    void Start()
    {
        PlayButton.SetActive(false);
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.CompareTag("Level1Block"))
                    {
                        PlayButton.SetActive(true);
                            objectToMove = hit.transform;
                        targetPosition = new Vector3(objectToMove.position.x, 8, objectToMove.position.z);
                        isMoving = true;
                        }
                }
            }
        
         }
    }
    public void Lvl1Enter()
    {

        SceneManager.LoadScene("Helix");
    }
    public void LVL1XPress()
    {
        PlayButton.SetActive(false);
    }
}