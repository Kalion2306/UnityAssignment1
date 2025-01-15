using UnityEngine;
using UnityEngine.UI;

public class points : MonoBehaviour
{
    public int score;


    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Points - " + score;
    }
}
