using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    public GameObject pickupParent; // Assign in Inspector
    public GameObject deliveryParent; // Assign in Inspector

    private GameObject[] pickupLocations;
    private GameObject[] deliveryLocations;

    public GameObject icecreamPrefab; // Assign your Icecream prefab in the Inspector
    public GameObject deliveryPrefab; // Assign your Delivery prefab in the Inspector

    private GameObject currentPickupLocation;
    private GameObject currentDeliveryLocation;

    private GameObject currentIcecream;
    private GameObject currentDelivery;


    void Start()
    {

        InitializeLocations();

        SetRandomLocations();
    }

    void Update()
    {
      if(IceCream.deliveryComplete)
      {
        OnDeliveryComplete();
        IceCream.deliveryComplete = false;
      }
    }

    void InitializeLocations()
    {

        pickupLocations = new GameObject[pickupParent.transform.childCount];
        deliveryLocations = new GameObject[deliveryParent.transform.childCount];

        for (int i = 0; i < pickupLocations.Length; i++)
        {
            pickupLocations[i] = pickupParent.transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < deliveryLocations.Length; i++)
        {
            deliveryLocations[i] = deliveryParent.transform.GetChild(i).gameObject;
        }
    }

    public void SetRandomLocations()
    {
        // Clean up previous instances if they exist
        if (currentIcecream != null) Destroy(currentIcecream);
        if (currentDelivery != null) Destroy(currentDelivery);


        int pickupIndex = Random.Range(0, pickupLocations.Length);
        currentPickupLocation = pickupLocations[pickupIndex];


        int deliveryIndex = Random.Range(0, deliveryLocations.Length);
        currentDeliveryLocation = deliveryLocations[deliveryIndex];


        currentIcecream = Instantiate(icecreamPrefab, currentPickupLocation.transform.position, Quaternion.identity);


        currentDelivery = Instantiate(deliveryPrefab, currentDeliveryLocation.transform.position, Quaternion.identity);

        Debug.Log($"New pickup location: {currentPickupLocation.name}, New delivery location: {currentDeliveryLocation.name}");
    }

    // Call this method to refresh locations after a delivery
    public void OnDeliveryComplete()
    {
        SetRandomLocations();
    }
}
