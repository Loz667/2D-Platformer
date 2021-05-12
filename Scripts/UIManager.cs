using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public Image[] heartUnits;

    public static UIManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void UpdateLives(int LivesRemaining)
    {
        for (int i=0; i<= LivesRemaining; i++)
            if (i == LivesRemaining)
            {
                heartUnits[i].enabled = false;
            }
    }
}
