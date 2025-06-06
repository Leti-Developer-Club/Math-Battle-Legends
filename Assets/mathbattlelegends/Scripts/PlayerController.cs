using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float moveSpeed;

    [Header("Control")]
    [SerializeField] private float slideSpeed;
    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       MoveForward();

       ManageControl();
    }

    private void MoveForward()
    {
         transform.position +=Vector3.forward  * Time.deltaTime;
    }

    private void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
           float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;

           xScreenDifference /= Screen.width;
            xScreenDifference *= slideSpeed;
            
            Vector3 position = transform.position;
            position.x = clickedPlayerPosition.x + xScreenDifference;
            transform.position = position;
            
            transform.position = clickedPlayerPosition +Vector3.right * xScreenDifference;
        }
    }
}
