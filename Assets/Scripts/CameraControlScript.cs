using UnityEngine;

public class CameraControlScript : MonoBehaviour
{
    //#if UNITY_IOS || UNITY_ANDROID

    private Camera _mainCamera;
    public GameObject Player;
    protected Plane Plane;                                                                                                  //plane just for calculation
    public bool Rotate;                                                                                                     //variable do You want camera to ratate
    float LastClickTime;
    float ClickTime;


    // Start is called before the first frame update
    void Awake()
    {
        _mainCamera = Camera.main;
        Player = GameObject.Find("PlayerTarget");
    }

    // Update is called once per frame
    void Update()
    {
        //Updating calculation Plane so its always in the correct place
        if (Input.touchCount >= 1)
        {
            Plane.SetNormalAndPosition(transform.up, transform.position);
        }

        var DeltaFirst = Vector3.zero;                                                                                      //creating variables for deltas
        var DeltaSecond = Vector3.zero;

        //Scrolling and moving the screen
        if (Input.touchCount >= 1)                                                                                          //executes when there are one or more touches on the screen
        {
            DeltaFirst = PlanePositionDelta(Input.GetTouch(0));                                                             //calculates the distance traveled by the first fingertouch while touching the screen
            if (Input.GetTouch(0).phase == TouchPhase.Moved)                                                                //checks whether the user moved the finger while touching
            {
                _mainCamera.transform.Translate(DeltaFirst, Space.World);                                                   //if yes then move the camera by the distance calculated in DeltaFirst in the world space
            }

            //Double Tapping
            if (Input.GetTouch(0).phase == TouchPhase.Began)                                                                //checking if the touching began
            {
                float doubleClickTime = 0.2f;                                                                               //setting the allowed time between double click
                ClickTime = Time.time - LastClickTime;                                                                      //calculating time between clicks
                if (ClickTime <= doubleClickTime)
                {
                    _mainCamera.transform.position = 
                        new Vector3(Player.transform.position.x, 180, Player.transform.position.z - 100);   //if the time is less than doubleClickTime move the camera to the position of the player
                    _mainCamera.transform.rotation = Quaternion.Euler(60, 0, 0);
                }
                LastClickTime = Time.time;                                                                                  //notes the last click time for calculating difference between clicks
            }
        }

        //pinching
        if (Input.touchCount >= 2)
        {
            var posFirst = PlanePosition(Input.GetTouch(0).position);                                                       //creating variables of first and last touch of the moving phase of the touch for 2 finger touches
            var posSecond = PlanePosition(Input.GetTouch(1).position);
            var posFirstInit = PlanePosition(Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition);
            var posSecondInit = PlanePosition(Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition);

            //calculating zoom
            var zoom = Vector3.Distance(posFirst, posSecond) / Vector3.Distance(posFirstInit, posSecondInit);               //calculating zoom by dividing the distance of the initial touches by distance of the final touches

            //edge case 
            if (zoom == 0 || zoom > 9)
            {
                return;                                                                                                     //if result of zoom is not ok dont zoom
            }

            //move the camera from zoom
            _mainCamera.transform.position = Vector3.LerpUnclamped(posFirst, _mainCamera.transform.position, 1 / zoom);

            //rotating
            if (Rotate == true && posSecondInit != posSecond)                                                               //executes if the rotate is set to true and the position of the second finger changed
            {
                _mainCamera.transform.RotateAround(posFirst, Plane.normal,
                    Vector3.SignedAngle(posSecond - posFirst, posSecondInit - posFirstInit, Plane.normal));                 //rotating around the first finger and Plane.normal axis, distance of the moved fingers
            }
        }
    }

    protected Vector3 PlanePosition(Vector2 screenPos)                                                                      //screenPos - finger position on the screen 
    {
        //position
        var rayNow = _mainCamera.ScreenPointToRay(screenPos);                                                               //creating a ray with function passing the screen pos of the finger

        if (Plane.Raycast(rayNow, out var enterNow))                                                                        //checks whether the ray hit the plane and creates variable of the distance the ray traveled to the plane
        {
            return rayNow.GetPoint(enterNow);                                                                               //returns the point of intersection
        }

        return Vector3.zero;
    }

    protected Vector3 PlanePositionDelta(Touch touch)                                                                       //calculates the distance the finger traveled during touching phase
    {
        //if not moving the finger
        if (touch.phase != TouchPhase.Moved)
        {
            return Vector3.zero;
        }

        //calculating delta of the touch movement
        var rayFirst = _mainCamera.ScreenPointToRay(touch.position - touch.deltaPosition);                      //getting the first touch of the movement
        var raySecond = _mainCamera.ScreenPointToRay(touch.position);                                           //getting the last touch of the movement

        if (Plane.Raycast(rayFirst, out var enterFirst) && Plane.Raycast(raySecond, out var enterSecond))       //checking if both of the touches intersected with the plane
        {
            return rayFirst.GetPoint(enterFirst) - raySecond.GetPoint(enterSecond);                             //returning the distance difference between the touches
        }

        //if touch not on the plane
        return Vector3.zero;                                                                                    //if the touches were not on the plane return zero vector
    }
//#endif
}
