using TMPro;
using UnityEngine;

public class EndUI : MonoBehaviour
{
    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_Text ordersText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundManager.PlayMusic("venus");
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = "Final Time: " + StuffManager.Instance.TimePassed;
        ordersText.text = "Orders Served: " + StuffManager.Instance.OrdersServed;
    }
}
