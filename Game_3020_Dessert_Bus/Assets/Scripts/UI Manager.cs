using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] TMP_Text ApprovalRatingText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ApprovalRatingText.text = "Approval Rating: " + Mathf.RoundToInt(StuffManager.Instance.ApprovalRating) + "%";
    }
}
