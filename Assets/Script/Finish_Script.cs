using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish_Script : MonoBehaviour
{
    public Color colorToSet; // Eklendi:

    // Start is called before the first frame update
    void Start()
    {
        // Renk bilgisini hex kodu kullanarak ayarla
        colorToSet = GlobalColorManager.HexToColor("6FAB66");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider coll) {
        if (coll.gameObject.CompareTag("Finish"))
        {
            // Renk bilgisini ayarla
            GlobalColorManager.SetColor(colorToSet);
            // Yeni sahneyi yükle
            SceneManager.LoadScene("StartScene");
        }
    }
}
