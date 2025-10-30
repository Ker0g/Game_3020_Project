using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.ComponentModel;
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

    bool isCup = false;

    [SerializeField] TMP_Dropdown flavorDropdown;

    public string selectedFlavor;

    public string flavor; //the scooped ice cream flavor

    Dictionary<string, Color> flavorColours = new Dictionary<string, Color>() 
    {
        {"vanilla", Color.white },
        { "chocolate", new Color(0.36f, 0.25f, 0.20f) },
        { "strawberry", Color.red },
        { "mint", Color.green },
        { "blueberry", Color.blue }

    };

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
        selectedFlavor = flavorDropdown.options[flavorDropdown.value].text;
    }

    void AddCone()
    {
        Debug.Log("Cone Added");
        GameObject cone = Instantiate(ConePrefab, transform.position, Quaternion.Euler(0f, 0f, 0f));
        myGameObjects.Add(cone);
        // now here, this adds the cone and then it.. uhm... yup, it picks the container! -gf
        ContainerPicked();
    }

    void AddCup()
    {
        Debug.Log("Cup Added");
        GameObject cup = Instantiate(CupPrefab, transform.position, Quaternion.identity);
        myGameObjects.Add(cup);
        // now here, it does the same thing as above but instead it does IDENTITY instead of oh wait it's a differnet function,, -gf
        ContainerPicked();
        isCup = true;
    }

    void AddIceCream()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, -0.7f, transform.position.z);
        Debug.Log("Ice Cream Added of flavor: " + selectedFlavor);
        if (isCup == false)
        {
            spawnPosition = new Vector3(transform.position.x, 0.1f, transform.position.z);
        }
        

        flavor = selectedFlavor;
        GameObject iceCream = Instantiate(IceCreamPrefab, spawnPosition, Quaternion.identity);
        //iceCream.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("IceCreams/" + selectedFlavor);
        iceCream.GetComponent<SpriteRenderer>().color = flavorColours[flavor];
        myGameObjects.Add(iceCream);
        // mmm icecream ouhhhh -gf
    }

    void ResetButton()
    {
        cupButton.interactable = true;
        coneButton.interactable = true;
        isCup = false;
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

        
        string container = myGameObjects[0].tag;
        string flavor = this.flavor;

        string requestedContainer = currentCustomer.itemList[currentCustomer.randomContainer];
        string requestedFlavor = currentCustomer.flavorList[currentCustomer.randomFlavor];

        if (container == requestedContainer && flavor == requestedFlavor)
        {
            Debug.Log("Correct order served!");
            StuffManager.Instance.IncreaseApproval(10); // YAYAY THANK YOU FOR THE ICE CREAM -gf
        }
        else
        {
            Debug.Log("Wrong order served!");
            StuffManager.Instance.IncreaseApproval(-10); // >:( -gf
        }
        currentCustomer.orderText.text = ""; // I'd like 5 ice creams... and 5, more ice creams... -gf
        currentCustomer.openOrder = false;
        ResetButton(); 
    }

    void ServeButton()
    {
        Serve(customer);
    }

    void ContainerPicked()
    {
        cupButton.interactable = false;
        coneButton.interactable = false;
    }
} // girl you need a shot of b12
