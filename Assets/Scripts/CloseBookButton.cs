using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBookButton : MonoBehaviour
{
    [SerializeField] GameObject bookObject;
    Book book;
    
    //cached references
    BoxCollider2D boxCollider;

    
    private void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
        book = bookObject.GetComponent<Book>();
    }

    private void Update() {
        closeTheBook();
    }
    private void closeTheBook(){
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            var touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if(boxCollider == Physics2D.OverlapPoint(touchPos)){
                book.closeBook();
            }
        }
    }
}
