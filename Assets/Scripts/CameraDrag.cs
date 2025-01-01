using System.Xml.Serialization;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    private Vector2 dragOrigin; // s�r�klemenin ba�lang�� noktas�
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
        CameraForPc();
        
    }

    private void CameraForPc()
    {
        float x = Input.GetAxis("Horizontal");
        if(Input.GetKeyDown(KeyCode.A))
        {
            targetPosition -= new Vector3(x * Time.deltaTime * dragSpeed, targetPosition.y, targetPosition.z);
            transform.position += Vector3.Lerp(targetPosition, transform.position, smoothSpeed);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            targetPosition += new Vector3(x * Time.deltaTime * dragSpeed, targetPosition.y, targetPosition.z);
            transform.position += Vector3.Lerp(targetPosition, transform.position, smoothSpeed);
        }
        
    }

    /*
    private void CameraForPhone()
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
                Vector2 difference = dragOrigin - touch.position;
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
    */
}
