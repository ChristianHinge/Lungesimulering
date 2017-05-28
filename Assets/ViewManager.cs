using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour {
    Vector3 mousePosStart;
    Vector3 rotationOffset;
    Vector3 difference;
    Camera cam;
    bool rotatingDisabled;
    bool rotating;
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !rotatingDisabled)
        {
            mousePosStart = Input.mousePosition;
            rotationOffset = UIManager.instance.tree.transform.localRotation.eulerAngles;
            rotating = true;
        }
        if (Input.GetMouseButton(0) && rotating)
        {
            difference = (Input.mousePosition - mousePosStart) / 3;
            UIManager.instance.tree.transform.localRotation = Quaternion.Euler(-difference.y + rotationOffset.x, -difference.x + rotationOffset.y, rotationOffset.z);
        }
        else
            rotating = false;

        cam.transform.Translate(0,0, Input.mouseScrollDelta.y);
    }
    public void DisableRoating()
    {
        rotatingDisabled = true;
    }
    public void EnableRotating()
    {
        rotatingDisabled = false;
    }


}
