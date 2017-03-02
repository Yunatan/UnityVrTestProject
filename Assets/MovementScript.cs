using System.Collections;
using System.Linq;
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
        ////CheckMouseMovement();
    }

    public void CheckTouchMovement()
    {
        var TouchString = string.Empty;
        foreach (var x in Input.touches)
        {
            var dPadPosition = FindObjectOfType<MovementDpadManagement>().GetDimensions();
            if (!dPadPosition.Contains(x.position))
            {
                //Touch began, save position
                if (x.phase == TouchPhase.Began)
                {
                    firstpoint = x.position;
                    xAngTemp = xAngle;
                    yAngTemp = yAngle;
                }
                //Move finger by screen
                if (x.phase == TouchPhase.Moved)
                {
                    secondpoint = x.position;
                    //Mainly, about rotate camera. For example, for Screen.width rotate on 180 degree
                    xAngle = xAngTemp + (secondpoint.x - firstpoint.x) * 180.0f / Screen.width;
                    yAngle = yAngTemp - (secondpoint.y - firstpoint.y) * 90.0f / Screen.height;
                    //Rotate camera
                    transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
                }
            }

            ////TouchString += string.Format("Input {0}: x - {1}, y - {2} \n", x.fingerId, x.position.x.ToString(), x.position.y.ToString());
        }
        
        ////var dPadPosition2 = FindObjectOfType<MovementDpadManagement>().GetDimensions();
        ////FindObjectOfType<TextManagement>().AppendMesage(
        ////    string.Format(
        ////        "{0} \n x: {1}, y: {2} \n sizeWidth: {3}, sizeHeight: {4}", 
        ////        TouchString,
        ////        dPadPosition2.position.x.ToString(),
        ////        dPadPosition2.position.y.ToString(),
        ////        dPadPosition2.size.x,
        ////        dPadPosition2.size.y));
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

                firstpoint = Input.mousePosition;
                xAngTemp = xAngle;
                yAngTemp = yAngle;

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
