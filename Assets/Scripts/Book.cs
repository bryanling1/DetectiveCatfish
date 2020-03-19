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
    float deltaX, deltaY;
    bool isDragging = false;
    

    BoxCollider2D boxCollider; 
    SpriteRenderer bookSprite;
    
    // Update is called once per frame
    void Start(){
        boxCollider = GetComponent<BoxCollider2D>();
        bookSprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        dragMode();
    }


    IEnumerator activeDragMode(){
        yield return new WaitForSeconds(holdSecondsToDrag);
        if(isTouchingBook()){
            bookSprite.color = UnityEngine.Color.gray;
            dragModeOn();
        }else{
            bookSprite.color = UnityEngine.Color.white;
            StopAllCoroutines();
        }   
        
    }

    private bool isTouchingBook(){
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if(boxCollider == Physics2D.OverlapPoint(touchPos)){
                return true;
            }
            return false;
        }
        return false;
    }

    private void dragMode(){
        if(Input.touchCount > 0){
            if(isTouchingBook()){
                StartCoroutine(activeDragMode());
            }
        }
    }
    private void dragModeOn(){
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
}
