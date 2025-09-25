using UnityEngine;

public class StuffManager : MonoBehaviour
{
    public static StuffManager Instance { get; private set; }

    public int ApprovalRating { get; private set; } = 100;

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void DecreaseApproval(int amount)
    {
        ApprovalRating -= amount;
        if (ApprovalRating < 0)
        {
            ApprovalRating = 0;
        }
    }

    public void IncreaseApproval(int amount)
    {
        ApprovalRating += amount;
        if (ApprovalRating > 100)
        {
            ApprovalRating = 100;
        }
    }
}
