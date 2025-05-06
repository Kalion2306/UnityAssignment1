using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomisationUI : MonoBehaviour
{

    public GameObject player;
    Customisation customSettings;

    public GameObject colourVal;
    public GameObject headVal;
    public GameObject shooterVal;

    public GameObject[] selectedSetting;
    // Start is called before the first frame update
    void Start()
    {
        customSettings = player.GetComponent<Customisation>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < selectedSetting.Length; i++)
        {
            if (i == customSettings.setting)
            {
                selectedSetting[i].SetActive(true);
            }
            else
            {
                selectedSetting[i].SetActive(false);
            }
        }

        colourVal.GetComponent<Image>().color = customSettings.colors[customSettings.col];
        headVal.GetComponent<TextMeshProUGUI>().text = customSettings.head.ToString();
        shooterVal.GetComponent<TextMeshProUGUI>().text = customSettings.gun.ToString();
    }
}
