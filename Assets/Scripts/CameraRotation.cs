using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float speed = 10f;
    public GameObject gameManagerObject;
    GameManager gameManager;
    public float downSpeed = 3f;
    public float upSpeed =3f;
    private Vector3 lastMousePosition;
    private bool isMouseDown = false;
    public float sensitivity = 1f;
    
    
    void Start(){
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(1) && gameManager.SpawnObjectUIActive == false)
        {
            lastMousePosition = Input.mousePosition;
            isMouseDown = true;
        }

        if (Input.GetMouseButtonUp(1) && gameManager.SpawnObjectUIActive == false)
        {
            isMouseDown = false;
        }

        if (isMouseDown && gameManager.SpawnObjectUIActive == false)
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            this.transform.localEulerAngles += new Vector3(-delta.y, delta.x, 0) * sensitivity * Time.deltaTime;
            lastMousePosition = Input.mousePosition;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = this.transform.right * x + this.transform.forward * z;
        moveDirection.y = 0;
        moveDirection = moveDirection.normalized;

        if (Input.GetKey(KeyCode.Q))
        {
            moveDirection.y = 1;
            this.transform.position += moveDirection * upSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            moveDirection.y = -1;
            this.transform.position += moveDirection * downSpeed * Time.deltaTime;
        }
        else
        {
            this.transform.position += moveDirection * speed * Time.deltaTime;
        }
    }
}
