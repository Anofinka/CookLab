using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;    // Obiekt gracza
    public float distance = 5.0f;  // Odleg�o�� kamery od gracza
    public float height = 2.0f;    // Wysoko�� kamery nad graczem
    public float rotationSpeed = 5.0f;  // Szybko�� rotacji kamery

    private float currentX = 0.0f;
    private float currentY = 0.0f;

    void Update()
    {
        if (Input.GetMouseButton(1))  // Sprawdza, czy prawy przycisk myszy jest przytrzymywany
        {
            currentX += Input.GetAxis("Mouse X") * rotationSpeed;
            currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;
            currentY = Mathf.Clamp(currentY, -20, 80);
        }
    }

    void LateUpdate()
    {
        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = player.position + rotation * direction + new Vector3(0, height, 0);
        transform.LookAt(player.position + new Vector3(0, height, 0));

        // Synchronizacja rotacji gracza z kamer�
        if (Input.GetMouseButton(1))  // Sprawdza, czy prawy przycisk myszy jest przytrzymywany
        {
            player.rotation = Quaternion.Euler(0, currentX, 0);
        }
    }
}