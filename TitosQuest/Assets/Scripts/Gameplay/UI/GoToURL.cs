using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToURL : MonoBehaviour
{
    public string link;

    public void GoToLink()
    {
        Application.OpenURL(link);
    }
}
