using UnityEngine;
using UnityEngine.UI;


public class GameState : MonoBehaviour
{
    public GameObject winsign;
    public GameObject scoresign;
    public GameObject getscore;

    public float gameTimer = 60;
    // Start is called before the first frame update
    void Start()
    {
        winsign.SetActive(false);
        scoresign.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;
        if (gameTimer <= 0)
        {
            winsign.SetActive(true);
            scoresign.SetActive(true);

            scoresign.GetComponent<Text>().text = "you're score is \n" + getscore.GetComponent<points>().score;
            Time.timeScale = 0;
        }
    }

    void OnExit()
    {
        Application.Quit();
    }
}
