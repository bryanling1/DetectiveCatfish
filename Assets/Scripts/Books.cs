using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Books : MonoBehaviour
{
    bool isBookOpen = false;

    public void setAllBooksToFirstLayer(){
        var books = GetComponentsInChildren<SpriteRenderer>();
        for(int i=0; i<books.Length; i++){
            books[i].sortingOrder = 1;
        }
    }

    public void openTheBook(){
        isBookOpen = true;
    }

    public void closeTheBook(){
        isBookOpen = false;
    }

    public bool isABookOpen(){
        return isBookOpen;
    }



}
