using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    public GameObject time;


    // Update is called once per frame
    void Update()
    {
        float gametime = time.GetComponent<GameState>().gameTimer;
        GetComponent<Slider>().value = gametime;
        
    }
}
