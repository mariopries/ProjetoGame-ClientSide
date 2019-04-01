using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusPanel : MonoBehaviour
{

    public Text statusText;
    public GameObject statusPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (statusText.text != "")
        {
            if (!statusPanel.activeSelf)
                statusPanel.SetActive(true);
        }
        else
        {
            if (statusPanel.activeSelf)
                statusPanel.SetActive(false);
        }
    }
}
