using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tab : MonoBehaviour
{
    [SerializeField] GameObject tab;

    //Cached references
    Tabs tabs;
    // Start is called before the first frame update
    void Start()
    {   
        tabs = FindObjectOfType<Tabs>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateTab(){
        tabs.hideAllTabs();
        tab.SetActive(true);
    }
}
