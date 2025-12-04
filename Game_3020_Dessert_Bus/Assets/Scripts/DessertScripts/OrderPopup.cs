using TMPro;
using UnityEngine;

public class OrderPopup : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Setup(string orderText)
    {
        text.text = orderText;
        Destroy(gameObject, 5f);
    }
}
