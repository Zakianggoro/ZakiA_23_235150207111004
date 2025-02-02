using TMPro;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public GameObject flarePrefab;
    public int maxFlares = 5; 
    private int currentFlares;

    public float throwForce = 10f; 

    public TMP_Text flareCountText; 

    private void Start()
    {
        currentFlares = maxFlares; 
        UpdateFlareText();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentFlares > 0) 
        {
            ThrowFlare();
        }
    }

    private void ThrowFlare()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; 

        Vector2 throwDirection = (mousePosition - transform.position).normalized;

        GameObject flareInstance = Instantiate(flarePrefab, transform.position, Quaternion.identity);
        
        Rigidbody2D rb = flareInstance.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = throwDirection * throwForce;
        }

        currentFlares--; // Reduce flare count
        UpdateFlareText();
    }

    private void UpdateFlareText()
    {
        if (flareCountText != null)
        {
            flareCountText.text = "Flares: " + currentFlares;
        }
    }
}
