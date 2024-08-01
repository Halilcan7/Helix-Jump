using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheeses_Spawn : MonoBehaviour
{
    public GameObject Cheese;
    public GameObject Cylinder;

    // Start is called before the first frame update
    void Start()
    {
        CreateCheeses();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateCheeses()
    {
        int levels = 7; //Random.Range(6,10);
        float axisY = 14f;
        float offsetY = 2f;

        GameObject TopParent = new GameObject("Level_General");

        Cylinder.transform.parent = TopParent.transform;

        for (int level = 0; level < levels; level++)
        {
            float currentY = axisY - level * offsetY;
            GameObject levelParent = new GameObject("Level_" + level);
            levelParent.transform.parent = TopParent.transform;
            List<GameObject> cheeses = new List<GameObject>();

            for (int i = 0; i <= 7; i++)
            {
                Vector3 Position = new Vector3(0f, currentY, 0f);
                Quaternion Rotation = Quaternion.Euler(0f, 45f * i, 0f);
                GameObject CheeseInstance = Instantiate(Cheese, Position, Rotation);
                CheeseInstance.transform.parent = levelParent.transform;
                cheeses.Add(CheeseInstance);
            }

            // Rastgele bazı siyah cheeseleri kırmızıya boya ve RedCheese tagı ver
            int redCheeseCount = 2;
            for (int i = 0; i < redCheeseCount; i++)
            {
                int randomIndex = Random.Range(0, cheeses.Count);
                GameObject redCheeseInstance = cheeses[randomIndex];
                redCheeseInstance.GetComponent<Renderer>().material.color = Color.red;
                redCheeseInstance.tag = "RedCheese";
            }

            int invisibleCount = Random.Range(2, 5);
            List<int> usedIndices = new List<int>();

            for (int i = 0; i < invisibleCount; i++)
            {
                int randomIndex;
                do
                {
                    randomIndex = Random.Range(0, cheeses.Count);
                } while (usedIndices.Contains(randomIndex));

                usedIndices.Add(randomIndex);
                cheeses[randomIndex].SetActive(false);
            }
        }
    }
}
