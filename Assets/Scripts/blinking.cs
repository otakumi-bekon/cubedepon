using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class blinking : MonoBehaviour
{
    public TextMeshProUGUI Blinking;
    public Image image;
    private int Flag;
    
    // Start is called before the first frame update
    void Start()
    {
        Flag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Flag == 0)
        {
            Blinking.alpha += 0.02f;
            if(Blinking.alpha >= 1)
            {
                Flag = 1;
            }
        }else
        {
            Blinking.alpha -= 0.02f;
            if(Blinking.alpha < 0)
            {
                Flag = 0;
            }
        }
    }
}
