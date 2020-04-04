using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookBackArrow : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider2D boxCollider;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        onPress();
    }

    private void onPress(){
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            var touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if(boxCollider == Physics2D.OverlapPoint(touchPos) && touch.phase == TouchPhase.Began){
                GetComponentInParent<BookOpen>().flipBack();
            }
        }
    }
}
