using System.Xml.Serialization;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    private Vector2 dragOrigin; // s�r�klemenin ba�lang�� noktas�
    private Vector3 velocity= Vector3.zero;
    private Vector3 targetPosition;
    private Vector3 initialCameraPosition; // kameran�n ba�lang�� pozisyonu
    private bool isDragging=false; // s�r�kleniyor mu?

    public float dragSpeed = 2.0f; // s�r�kleme h�z�
    public float smoothSpeed = 5.0f;
    public Vector2 minLimits; // x ve z koordinatlar�nda minimum limitler
    public Vector2 maxLimits; // x ve z koordinatlar�nda maksimum limitler

    private void Start()
    {
        targetPosition = transform.position;
    }

    private void Update()
    {
        if(Application.isMobilePlatform)
        {
            HandleTouchInput();
        }
        else
        {
            HandleMouseInput();
            HandleKeyboardInput();
        }
        
        transform.position = Vector3.SmoothDamp(transform.position,targetPosition,ref velocity,smoothSpeed);
    }

    private void HandleKeyboardInput()
    {
        float moveX = 0;

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveX = -dragSpeed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveX = dragSpeed * Time.deltaTime;
        }

        if(moveX !=0)
        {
            float newX=Mathf.Clamp(transform.position.x + moveX, minLimits.x, maxLimits.x);
            targetPosition = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin =(Vector2)Input.mousePosition;
            isDragging = true;
        }
        else if (Input.GetMouseButton(0) && isDragging)
        {
            Vector2 difference = Camera.main.ScreenToViewportPoint(dragOrigin -(Vector2)Input.mousePosition);
            float moveX = difference.x * dragSpeed;

            float newX = Mathf.Clamp(transform.position.x + moveX, minLimits.x, maxLimits.x);
            targetPosition = new Vector3(newX, transform.position.y, transform.position.z);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }


    private void HandleTouchInput()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                dragOrigin = touch.position;
                initialCameraPosition = transform.position;
                isDragging = true;
            }
            else if (touch.phase == TouchPhase.Moved && isDragging == true)
            {
                // S�r�kleme devam ederken
                Vector2 difference = Camera.main.ScreenToViewportPoint(dragOrigin - touch.position);
                float moveX = difference.x * dragSpeed;


                // Kameray� s�r�kleme hareketine g�re hareket ettir
                float newX = Mathf.Clamp(transform.position.x + moveX, minLimits.x, maxLimits.x);

                targetPosition = new Vector3(newX, transform.position.y, transform.position.z);

                // Kameray� yumu�ak bir �ekilde hedef pozisyona ta��r
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                // S�r�kleme sona erdi�inde
                isDragging = false;
            }
        }
    }
    
}
