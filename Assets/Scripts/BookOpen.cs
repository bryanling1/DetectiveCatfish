using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookOpen : MonoBehaviour
{
    [SerializeField] List<GameObject> Pages;
    int currentPage = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void flipBack(){
        Debug.Log("flip back");
        if(currentPage > 0){
            hidePage(Pages[currentPage]);
            if(Pages.Count - currentPage != 1){
                hidePage(Pages[currentPage + 1]);
            }
            currentPage -= 2;
            showPage(Pages[currentPage]);
            showPage(Pages[currentPage+1]);
        }
    }

    public void flipForward(){
        
        if(Pages.Count - currentPage > 2){
            Debug.Log("flip forward ");
            hidePage(Pages[currentPage]);
            hidePage(Pages[currentPage+1]);
            currentPage += 2;
            showPage(Pages[currentPage]);
            if(Pages.Count - currentPage != 1){
                showPage(Pages[currentPage + 1]);
            }
    
        }
    }

    private void hidePage(GameObject page){
        page.SetActive(false);
    }

    private void showPage(GameObject page){
        page.SetActive(true);
    }

}
