using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public float turnSpeed = 4.0f;
    public float moveSpeed = 3.0f;

    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 90.0f;
    private float rotX;

    void Update()
    {
        MouseAiming();
        KeyboardMovement();
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // the object identified by hit.transform was clicked
                if (hit.transform.gameObject.name == "Turtle")
                {
                    Debug.Log("Hey! You are looking for Peter the Pizza? I'm not sure where he is now, but I saw him a while ago with Walter the Whale and Susan the Sardine. Hope that helps!");
                }
                if (hit.transform.gameObject.name == "Whale")
                {
                    Debug.Log("You can't find Peter the Pizza? Sounds about right he is always runnign around. I saw him with Susan the Sardine and Taylor the Turtle earlier. They should be behind a bush somewhere.");
                }
                if (hit.transform.gameObject.name == "Sardine")
                {
                    Debug.Log("You have been looking to Peter the Pizza? We have been here for hours and haven't moved.");
                }
                if (hit.transform.gameObject.name == "Pizza")
                {
                    Debug.Log("Sorry I forgot about our meeting, I lost track of time.");
                }
            }
        }
    }

    void MouseAiming()
    {
        // get the mouse inputs
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed;

        // clamp the vertical rotation
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

        // rotate the camera
        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
    }

    void KeyboardMovement()
    {
        Vector3 dir = new Vector3(0, 0, 0);

        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
}
