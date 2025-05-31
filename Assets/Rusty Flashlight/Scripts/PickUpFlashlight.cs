using UnityEngine;

public class PickUpFlashlight : MonoBehaviour
{
    public GameObject PickUpText;
    public GameObject flashlight;
    private bool playerInRange = false;

    void Start()
    {
        if (flashlight != null)
            flashlight.SetActive(false);

        if (PickUpText != null)
            PickUpText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && PickUpText != null)
        {
            PickUpText.SetActive(true);
            playerInRange = true;
            Debug.Log("Player entered: Text shown.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && PickUpText != null)
        {
            PickUpText.SetActive(false);
            playerInRange = false;
            Debug.Log("Player exited: Text hidden.");
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (PickUpText != null)
            {
                Debug.Log("Hiding text...");
                PickUpText.SetActive(false); 
            }

            if (flashlight != null)
                flashlight.SetActive(true);

            Destroy(gameObject);
        }
    }
}
