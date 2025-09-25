using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
public class DessertMaker : MonoBehaviour
{
    [SerializeField] Customer customer;
    [SerializeField] GameObject ConePrefab;
    [SerializeField] GameObject CupPrefab;
    [SerializeField] GameObject IceCreamPrefab;


    [SerializeField] Button coneButton;
    [SerializeField] Button cupButton;
    [SerializeField] Button iceCreamButton;
    [SerializeField] Button resetButton;
    [SerializeField] Button serveButton;

    public List<GameObject> myGameObjects = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coneButton.onClick.AddListener(AddCone);
        cupButton.onClick.AddListener(AddCup);
        iceCreamButton.onClick.AddListener(AddIceCream);
        serveButton.onClick.AddListener(ServeButton);

        resetButton.onClick.AddListener(ResetButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddCone()
    {
        Debug.Log("Cone Added");
        GameObject cone = Instantiate(ConePrefab, transform.position, Quaternion.Euler(0f, 0f, 180f));
        myGameObjects.Add(cone);
        

    }

    void AddCup()
    {
        Debug.Log("Cup Added");
        GameObject cup = Instantiate(CupPrefab, transform.position, Quaternion.identity);
        myGameObjects.Add(cup);
       
    }

    void AddIceCream()
    {
        Debug.Log("Ice Cream Added");
        Vector3 spawnPosition = new Vector3(transform.position.x, -0.8f, transform.position.z);
        GameObject iceCream = Instantiate(IceCreamPrefab, spawnPosition, Quaternion.identity);
        myGameObjects.Add(iceCream);

    }

    void ResetButton()
    {
        {
            foreach (var obj in myGameObjects)
            {
                Destroy(obj);
            }
            myGameObjects.Clear();

        }
    }

    void Serve(Customer currentCustomer)
    {
        if (myGameObjects.Count == 0) return;

        
        string servedItem = myGameObjects[0].tag;

        string requestedItem = currentCustomer.itemList[currentCustomer.randomIndex];

        if (servedItem == requestedItem)
        {
            Debug.Log("Correct order served!");
            StuffManager.Instance.IncreaseApproval(10);
        }
        else
        {
            Debug.Log("Wrong order served!");
            StuffManager.Instance.IncreaseApproval(-5); 
        }
        currentCustomer.orderText.text = "";

        ResetButton(); 
    }

    void ServeButton()
    {
        Serve(customer);
    }
}
