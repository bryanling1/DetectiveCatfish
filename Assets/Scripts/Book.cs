using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] float minX = -5f;
    [SerializeField] float maxX = 5f;
    [SerializeField] float minY = 4f;
    [SerializeField] float maxY = 10f;
    [SerializeField] float holdSecondsToDrag = 0.6f;
    [SerializeField] GameObject OpenedBook;

    float deltaX, deltaY;
    float holdTimer = 0f;
    [SerializeField] bool isBookOpen = false;

    BoxCollider2D boxCollider; 
    SpriteRenderer bookSprite;
    Books books;
    
    
    // Update is called once per frame
    void Start(){
        boxCollider = GetComponent<BoxCollider2D>();
        bookSprite = GetComponent<SpriteRenderer>();
        books = FindObjectOfType<Books>();
    }
    void Update()
    {
        dragMode();
    }

    private bool isTouchingBook(){
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if(boxCollider == Physics2D.OverlapPoint(touchPos)){
                books.setAllBooksToFirstLayer();
                GetComponent<SpriteRenderer>().sortingOrder = 2;
                return true;
            }
            return false;
        }
        return false;
    }

    private void dragMode(){
        if(Input.touchCount > 0 && isTouchingBook()){
            holdTimer += Time.deltaTime;
            if(holdTimer > holdSecondsToDrag){
                dragModeOn();
            }
        }else{
            if(holdTimer < holdSecondsToDrag && holdTimer > 0){
                openBook();
            }
            holdTimer = 0f;
            bookSprite.color = UnityEngine.Color.white;
        }

    }
    private void dragModeOn(){
        bookSprite.color = UnityEngine.Color.gray;
        Touch touch = Input.GetTouch(0);   
        Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

        if(touch.phase == TouchPhase.Began){
            deltaX = touchPos.x - transform.position.x;
            deltaY = touchPos.y - transform.position.y;
        }else if (touch.phase == TouchPhase.Moved){
            var newX = Mathf.Clamp(touchPos.x - deltaX, minX, maxX);
            var newY = Mathf.Clamp(touchPos.y - deltaY, minY, maxY);
            transform.position = new Vector3(newX, newY, transform.position.z);
        }

    }

    private void openBook(){
        if(books.isABookOpen() == false){
            OpenedBook.SetActive(true);
            books.openTheBook();
            isBookOpen = true;
            gameObject.SetActive(false);
        }
        
    }
    public void closeBook(){
        if(isBookOpen == true){
            OpenedBook.SetActive(false);
            isBookOpen = false;
            books.closeTheBook();
            gameObject.SetActive(true);
        }
    }

}
