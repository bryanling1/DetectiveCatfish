using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Books : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setAllBooksToFirstLayer(){
        var books = GetComponentsInChildren<SpriteRenderer>();
        for(int i=0; i<books.Length; i++){
            books[i].sortingOrder = 1;
        }
    }

}
