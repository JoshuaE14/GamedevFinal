using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public GameObject duplicateItem; 
    public Text pickupText; 
    public float interactionRange = 3f; 
    private GameObject player; 
    private bool isPlayerInRange = false; 
    private bool itemPickedUp = false; 

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pickupText.gameObject.SetActive(false); 
    }

    private void Update()
    {
        
        if (isPlayerInRange && !itemPickedUp)
        {
            pickupText.gameObject.SetActive(true); 

            if (Input.GetKeyDown(KeyCode.E)) 
            {
                PickupItem();
            }
        }
        else
        {
            pickupText.gameObject.SetActive(false);
        }
    }

    private void PickupItem()
    {
        itemPickedUp = true; 
        gameObject.SetActive(false); 
        duplicateItem.SetActive(true); 

       
        if (pickupText != null)
        {
            pickupText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false; 
            if (!itemPickedUp)
            {
                pickupText.gameObject.SetActive(false); 
            }
        }
    }
}
