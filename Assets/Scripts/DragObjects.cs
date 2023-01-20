using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjects : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoords; 
    GameObject gameManagerObject;
    GameManager gameManager;



    void Start(){
        gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    private void Update() {
    if(gameManager.SpawnObjectUIActive == false){
    var currentPos = transform.position;
    transform.position = new Vector3(Mathf.Round(currentPos.x),
                             Mathf.Round(currentPos.y),
                             Mathf.Round(currentPos.z));    
    }
    }

    private void OnMouseDown() {
        
         if(gameManager.SpawnObjectUIActive == false){
            mZCoords = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset  = gameObject.transform.position - GetMouseWorldPos();
         }
    }

    private Vector3 GetMouseWorldPos(){
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoords;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    
    private void OnMouseDrag() {
         if(gameManager.SpawnObjectUIActive == false){
            transform.position = GetMouseWorldPos() + mOffset;
         }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            gameManager.OpenObjectMenu(this.gameObject);
        }
    }
}
