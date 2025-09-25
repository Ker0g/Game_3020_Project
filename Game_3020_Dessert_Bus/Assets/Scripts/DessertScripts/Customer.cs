using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Customer : MonoBehaviour
{
    public List<string> itemList = new List<string>() { "cup", "cone"};

    [SerializeField] float orderTimer = 10f;

    [SerializeField] public TMP_Text orderText;

    public int randomIndex;

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
            randomIndex = Random.Range(0, itemList.Count);
            Debug.Log("Customer ordered a " + itemList[randomIndex] + " of ice cream.");
            orderText.text = "I would like a " + itemList[randomIndex] + " of ice cream.";
            orderTimer = 10f;
        }
    }
}
