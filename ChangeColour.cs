using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Color aColour = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        gameObject.GetComponent<Renderer>().material.color = aColour;
    }
}