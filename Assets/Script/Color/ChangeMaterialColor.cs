using UnityEngine;

public class ChangeMaterialColor : MonoBehaviour
{
    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            
            // GlobalColorManager'dan rengi al ve materyale uygula
            objectRenderer.material.color = GlobalColorManager.GetColor();
        }
        else
        {
            Debug.LogError("Renderer component is missing on this GameObject.");
        }
    }
}
