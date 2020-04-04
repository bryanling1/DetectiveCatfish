using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tabs : MonoBehaviour
{
    [SerializeField] List<GameObject> tabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hideAllTabs(){
        for(int i=0; i<tabs.Count; i ++){
            tabs[i].SetActive(false);
        }
    }
}
