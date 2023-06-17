using UnityEngine;

public class ChangeSpriteColor : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    void Start()
    {
        // Get the SpriteRenderer component if not assigned
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        // Change the color to red
        spriteRenderer.color = Color.red;
    }
}
