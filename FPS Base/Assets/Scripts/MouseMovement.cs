using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivy = 500f;

    private float _xRotation = 0f;
    private float _yRotation = 0f;

    public float topClamp = -90f;
    public float bottomClamp = 90f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Lock the cursor on start
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Get Mouse inputs from player
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivy * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivy * Time.deltaTime;

        // Roate around x Axis (Up and down)
        _xRotation -= mouseY; 
        
        // Clamp Roation
        _xRotation = Mathf.Clamp(_xRotation, topClamp, bottomClamp);

        //Rotate around y Axis (left and right)
        _yRotation += mouseX;

        // Apply rotation calculations to the camera's transform component
        transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);

    }   

}
