using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Customer : MonoBehaviour
{
    public List<string> itemList = new List<string>() { "cup", "cone"};
    public List<string> flavorList = new List<string>() { "Vanilla", "Chocolate", "Strawberry"};
    [SerializeField] float orderTimer = 10f;

    [SerializeField] public TMP_Text orderText;

    [SerializeField] public bool openOrder = false;

    public int randomContainer;
    public int randomFlavor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        orderTimer -= Time.deltaTime;

        if (orderTimer <= 0)
        {
            if (openOrder)
            {
                Debug.Log("Order Failed");
                StuffManager.Instance.IncreaseApproval(-10);
                openOrder = false;
            }
            randomContainer = Random.Range(0, itemList.Count);
            randomFlavor = Random.Range(0, flavorList.Count);
            Debug.Log("Customer ordered a " + itemList[randomContainer] + " of " + flavorList[randomFlavor] +  " ice cream.");
            orderText.text = "Customer ordered a " + itemList[randomContainer] + " of " + flavorList[randomFlavor] + " ice cream.";
            orderTimer = 10f;
            openOrder = true;
        }
    }
}
