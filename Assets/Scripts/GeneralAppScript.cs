using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralAppScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenProfileWebsite()
    {
        Application.OpenURL("http://aoneahsan.website");
    }
}
