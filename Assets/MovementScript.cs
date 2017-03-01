using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementScript : MonoBehaviour
{
    private Vector3 movementVector = new Vector3();
    private Vector3 axisMovementVector = new Vector3();
    private Vector3 firstpoint; //change type on Vector3
    private Vector3 secondpoint;
    private float xAngle = 0.0f; //angle for axes x for rotation
    private float yAngle = 0.0f;
    private float xAngTemp = 0.0f; //temp variable for angle
    private float yAngTemp = 0.0f;
    public float speedModifier = 10f;
    public float acceleration = 6f;

    // Use this for initialization
    void Start()
    {
        xAngle = 0.0f;
        yAngle = 0.0f;
        this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        var body = this.GetComponent<Rigidbody>();
        var velocityVector = Camera.main.transform.TransformDirection(movementVector);
        velocityVector.y = 0;
        body.AddForce(velocityVector * acceleration, ForceMode.Acceleration);
        if (axisMovementVector != Vector3.zero)
        {
            this.GetComponent<Rigidbody>().velocity = axisMovementVector;
        }

        CheckTouchMovement();
        CheckAxisMovement();
        CheckMouseMovement();
    }

    public void CheckTouchMovement()
    {
        //Check count touches
        if (Input.touchCount > 0)
        {
            var dPadDimensions = FindObjectOfType<MovementDpadManagement>().GetDimensions();
            if (EventSystem.current.IsPointerOverGameObject())
            {
                //Touch began, save position
                if (Input.GetTouch(0).phase == TouchPhase.Began && !dPadDimensions.Contains(Input.GetTouch(0).position))
                {
                    firstpoint = Input.GetTouch(0).position;
                    xAngTemp = xAngle;
                    yAngTemp = yAngle;
                }
                //Move finger by screen
                if (Input.GetTouch(0).phase == TouchPhase.Moved && !dPadDimensions.Contains(Input.GetTouch(0).position))
                {
                    secondpoint = Input.GetTouch(0).position;
                    //Mainly, about rotate camera. For example, for Screen.width rotate on 180 degree
                    xAngle = xAngTemp + (secondpoint.x - firstpoint.x) * 180.0f / Screen.width;
                    yAngle = yAngTemp - (secondpoint.y - firstpoint.y) * 90.0f / Screen.height;
                    //Rotate camera
                    Camera.main.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
                }
            }
        }
    }

    public void CheckAxisMovement()
    {
        var verticalAxis = Input.GetAxis("Vertical");
        axisMovementVector.z = verticalAxis * speedModifier;


        var horizontalAxis = Input.GetAxis("Horizontal");
        axisMovementVector.x = horizontalAxis * speedModifier;
    }

    public void CheckMouseMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var dPadDimensions = FindObjectOfType<MovementDpadManagement>().GetDimensions();
            if (!dPadDimensions.Contains(Input.mousePosition))
            {
                firstpoint = Input.mousePosition;
                xAngTemp = xAngle;
                yAngTemp = yAngle;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            secondpoint = Input.mousePosition;
            xAngle = xAngTemp + (secondpoint.x - firstpoint.x) * 180.0f / Screen.width;
            yAngle = yAngTemp - (secondpoint.y - firstpoint.y) * 90.0f / Screen.height;
            var z = Quaternion.Euler(yAngle, xAngle, 0.0f);
            this.transform.rotation = z;
        }
    }

    public void MoveForward()
    {
        movementVector.z += 1f * speedModifier;
    }

    public void MoveBackward()
    {
        movementVector.z -= 1f * speedModifier;
    }

    public void MoveLeft()
    {
        movementVector.x -= 1f * speedModifier;
    }

    public void MoveRight()
    {
        movementVector.x += 1f * speedModifier;
    }
}
