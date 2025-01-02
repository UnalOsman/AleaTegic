using System.Xml.Serialization;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    private Vector2 dragOrigin; // sürüklemenin baþlangýç noktasý
    private Vector3 velocity= Vector3.zero;
    private Vector3 targetPosition;
    private Vector3 initialCameraPosition; // kameranýn baþlangýç pozisyonu
    private bool isDragging=false; // sürükleniyor mu?

    public float dragSpeed = 2.0f; // sürükleme hýzý
    public float smoothSpeed = 5.0f;
    public Vector2 minLimits; // x ve z koordinatlarýnda minimum limitler
    public Vector2 maxLimits; // x ve z koordinatlarýnda maksimum limitler

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
                // Sürükleme devam ederken
                Vector2 difference = Camera.main.ScreenToViewportPoint(dragOrigin - touch.position);
                float moveX = difference.x * dragSpeed;


                // Kamerayý sürükleme hareketine göre hareket ettir
                float newX = Mathf.Clamp(transform.position.x + moveX, minLimits.x, maxLimits.x);

                targetPosition = new Vector3(newX, transform.position.y, transform.position.z);

                // Kamerayý yumuþak bir þekilde hedef pozisyona taþýr
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                // Sürükleme sona erdiðinde
                isDragging = false;
            }
        }
    }
    
}
