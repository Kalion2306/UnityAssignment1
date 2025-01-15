using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject playerhealth;
    Slider bar;

    private void Start()
    {
        bar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
        bar.value = playerhealth.GetComponent<PlayerHealth>().health;
    }
}
