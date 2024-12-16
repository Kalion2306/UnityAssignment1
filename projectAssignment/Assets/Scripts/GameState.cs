using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameState : MonoBehaviour
{
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 60)
        {
            print("Game Won!");
            Time.timeScale = 0;
        }
    }
}
