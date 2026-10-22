using UnityEngine;

public class Weights : MonoBehaviour
{
    public float weightAmount = 1f;
    private Rigidbody2D weightBody;

    void Awake()
    {
        weightBody = GetComponent<Rigidbody2D>();

        if (weightBody != null)
        {
            weightBody.mass = weightAmount;
        }
    }
}