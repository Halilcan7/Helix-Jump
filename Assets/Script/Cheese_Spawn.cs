using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese_Spawn : MonoBehaviour
{
    public GameObject Cheese;
    public GameObject RedCheese;
    public GameObject Cylinder;

    private void Start() {
        Create();
    }

    public void Create()
    {
        int levels = 7;
        float axisY = 14f;
        float yOffset = 2f;

        GameObject TopParent = new GameObject("Level_General");
        Cylinder.transform.parent = TopParent.transform;

        for (int level = 0; level < levels; level++)
        {
            float currentY = axisY - level * yOffset;
            GameObject levelParent = new GameObject("Level_" + level);
            levelParent.transform.parent = TopParent.transform;

            List<GameObject> cheeses = new List<GameObject>();
            List<GameObject> redcheeses = new List<GameObject>();

            for (int i = 0; i <= 7; i++)
            {
                Vector3 Position = new Vector3(0f, currentY, 0f);
                Quaternion Rotation = Quaternion.Euler(0, 45 * i, 0);
                GameObject cheeseInstance = Instantiate(Cheese, Position, Rotation);
                cheeseInstance.transform.parent = levelParent.transform;
                cheeses.Add(cheeseInstance);
            }

            for(int i = 0; i <= 1; i++)
            {
                Vector3 Position = new Vector3(0f, currentY + 0.01f, 0f);
                Quaternion Rotation = Quaternion.Euler(0, 45 * i, 0);
                GameObject redcheeseInstance = Instantiate(RedCheese,Position,Rotation);
                redcheeseInstance.transform.parent = levelParent.transform;
                redcheeses.Add(redcheeseInstance);
            }

            int invisibleCount = Random.Range(2, 5);
            int redİnvisibleCount = Random.Range(1, 2);

            for (int i = 0; i < redcheeses.Count; i++)
            {
                int RedRandomIndex = Random.Range(i, redcheeses.Count);
                GameObject redtemp = redcheeses[i];
                redcheeses[i] = redcheeses[RedRandomIndex];
                redcheeses[RedRandomIndex] = redtemp;
            }

            for (int i = 0; i < cheeses.Count; i++)
            {
                int randomIndex = Random.Range(i, cheeses.Count);
                GameObject temp = cheeses[i];
                cheeses[i] = cheeses[randomIndex];
                cheeses[randomIndex] = temp;
            }

            for (int i = 0; i < invisibleCount; i++)
            {
                cheeses[i].SetActive(false);
            }
        }
    }
}
