using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptButton : MonoBehaviour
{
    public string menuAR;

    public void gotomenuAR()
    {
        Application.LoadLevel(menuAR);
    }

    public void exitApplication()
    {
        Application.Quit();
    }
}