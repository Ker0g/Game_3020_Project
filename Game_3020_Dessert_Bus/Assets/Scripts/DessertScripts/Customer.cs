using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Customer : MonoBehaviour
{
    public List<string> itemList = new List<string>() { "cup", "cone"};
    public List<string> flavorList = new List<string>() { "Vanilla", "Chocolate", "Strawberry"};
    [SerializeField] float orderTimer = 10f;
    float timerReset = 10f;

    [SerializeField] public float difficultyTimer = 30f;

    [SerializeField] int difficulty = 1;

    //[SerializeField] public TMP_Text orderText;

    public string order;

    [SerializeField] public OrderPopup orderPrefab;
    [SerializeField] public Canvas canvas;

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
        difficultyTimer -= Time.deltaTime;


        if (orderTimer <= 0)
        {
            if (openOrder)
            {
                Debug.Log("Order Failed");
                StuffManager.Instance.IncreaseApproval(-10);

                openOrder = false;
            }
            randomContainer = Random.Range(0, itemList.Count);
            randomFlavor = Random.Range(0, difficulty);
            Debug.Log("May I have a " + itemList[randomContainer] + " of " + flavorList[randomFlavor] +  " ice cream please?");
            order = "May I have a " + itemList[randomContainer] + " of " + flavorList[randomFlavor] + " ice cream please?";

            OrderPopup popup = Instantiate(orderPrefab, canvas.transform);
            popup.Setup(order);
            orderTimer = timerReset;
            openOrder = true;
        }

        if (difficultyTimer <= 0f)
        {
            if(difficulty < itemList.Count)
            {
                difficulty += 1;
            }
            
            difficultyTimer = 30f;
            timerReset -= 0.5f;
        }

        if (Input.GetKey(KeyCode.Keypad0) && difficulty < itemList.Count)
        {
            difficulty += 1;
        }

        if (Input.GetKey(KeyCode.Keypad1))
        {
            StuffManager.Instance.DecreaseApproval(10);
        }
    }
}
