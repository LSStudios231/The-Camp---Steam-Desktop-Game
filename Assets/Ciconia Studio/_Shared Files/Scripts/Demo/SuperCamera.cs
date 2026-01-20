using UnityEngine;
using System.Collections;

public class SuperCamera : MonoBehaviour {

    public GameObject pivot;

    public KeyCode resetShortcut = KeyCode.Space;

    [Range(0f, 100f)]
    public float rotationSensibility = 10f;
    public bool invertRotationX = false;
    public bool invertRotationY = false;

    [Range(0f, 100f)]
    public float translationSensibility = 10f;
    public bool invertTranslationX = false;
    public bool invertTranslationY = false;

    public float zoomMax = 2f;
    public float zoomMin = 20f;

    [Range(0f, 100f)]
    public float wheelSensibility = 10;


    private float delayDoubleClic = 0.2f;


    private Vector3 oldCamPos;
    private Quaternion oldCamRot;
    private Vector3 oldMousePos;
    private float timeDoubleClic;
    private bool firstClic = false;
    private Vector3 pivotPos;
    private Camera cam;

	// Use this for initialization
	void Start () {
        pivotPos = pivot.transform.position;
        oldCamPos = cam.transform.position;
        oldCamRot = cam.transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {

        Debug.DrawRay(pivotPos, Vector3.up, Color.red);
        Debug.DrawRay(pivotPos, cam.transform.right, Color.green);

        if (Input.GetKeyDown(resetShortcut))
        {
            cam.transform.position = oldCamPos;
            cam.transform.rotation = oldCamRot;
        }

        float wheel = Input.GetAxis("Mouse ScrollWheel");
        if (wheel != 0f)
        {
            Vector3 movVec = (pivotPos - cam.transform.position);
            movVec.Normalize();
            movVec *= wheel/ 20 * wheelSensibility;
            Vector3 newPos = cam.transform.position + movVec;
            if ((newPos - pivotPos).magnitude >= zoomMax && (newPos - pivotPos).magnitude <= zoomMin)
            {
                cam.transform.position = newPos;
            }
        }

         bool doubleClic = false;

        if (Input.GetMouseButtonDown(0))
        {
            if (firstClic)
            {
                doubleClic = true;
                firstClic = false;
            }
            else
            {
                firstClic = true;
                timeDoubleClic = Time.time;
            }
        }
       
        if (firstClic && Time.time - timeDoubleClic > delayDoubleClic)
        {
            firstClic = false;
        }


        

        if (!Input.GetMouseButton(0) && !Input.GetMouseButton(2))
        {
            //Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
            return;
        }
        else
        {
            Cursor.visible = false;
        }

        Vector3 mousePos = Input.mousePosition;

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(2))
        {
            oldMousePos = mousePos;
            return;
        }
        

        if (Input.GetMouseButton(2))
        {
            int factor = -1;
            if (invertTranslationX)
            {
                factor = 1;
            }
            gameObject.transform.Translate(new Vector3(factor * translationSensibility * (mousePos.x - oldMousePos.x) / 100f,0,  0));
            factor = -1;
            if (invertTranslationY)
            {
                factor = 1;
            }
            gameObject.transform.Translate(new Vector3(0, factor * translationSensibility * (mousePos.y - oldMousePos.y) / 100f, 0));

        }
        else
        {
            int factor = 1;
            if (invertRotationX)
            {
                factor = -1;
            }
            gameObject.transform.RotateAround(pivotPos, Vector3.up, factor * rotationSensibility * (mousePos.x - oldMousePos.x)/100f);
            factor = 1;
            if (invertRotationY)
            {
                factor = -1;
            }
            gameObject.transform.RotateAround(pivotPos, cam.transform.right, factor * - rotationSensibility * (mousePos.y - oldMousePos.y)/100f);

        }


        oldMousePos = mousePos;

    }
}
