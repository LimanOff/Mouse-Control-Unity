using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [Range(100,400f)] public float Sensitivity;

    [SerializeField] GameObject Player; // you can remove this field if you dont have model a Player

    float xRotation; 
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // turn off and lock the mouse inside the game
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.fixedDeltaTime;

        xRotation -= mouseY;
        yRotation += mouseX; // if you want turn on inversion just swap += and -= in xRotation and yRotation,
		             // Example: xRotation += mouseY;
                             // yRotation -= mouseX;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Restriction for the camera not to rotate 360

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f); // Rotation of camera

        Player.transform.rotation = Quaternion.Euler(0f, yRotation, 0f); // Rotation of Player (if you have)
    }
}
