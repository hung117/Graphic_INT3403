using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Vector3 horizontal_L, horizontal_R, vertical_T, vertical_D;
    [SerializeField] protected InputHandler _InputHandler;

    public Camera _Camera;
    public bool bRotateCamera = false;
    [SerializeField] GameObject _target2Follow;
    [SerializeField] float f_offsetDistance = 6;
    [SerializeField] float cameraOffsetY = 2;

    Vector3 offset = Vector3.zero;
    float _cameraSpeed = 1.0f;
    Vector3 pivotPoint;

    void Start()
    {
        bRotateCamera = true;
    }

    // Update is called once per frame
    void Update()
    {
        changeCameraDirection();
        zoomInOut();
    }
    // Look around
    public void changeCameraDirection()
    {
        bRotateCamera = _InputHandler.getRightClick();
        // camera rotate and change position behavior
        if (_InputHandler.getRightClick())
        { // if this is true, rotate the camera
          // Get the PivotPoint
            Vector3 camCentre = _Camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, _Camera.nearClipPlane));
            // RaycastHit hit;
            // if (Physics.Raycast(_Camera.transform.position, camCentre - _Camera.transform.position, out hit, Mathf.Infinity, ~0))
            // {
            //     Debug.DrawLine(_Camera.transform.position, hit.transform.position, new Color(0.3f, 0.4f, 0.6f, 0.3f));
            //     pivotPoint = hit.transform.position;
            //     Debug.Log("HIT ");
            // }
            pivotPoint = _target2Follow.transform.position;
            // rotate the camera
            float mouseH = _InputHandler.getLook().y;
            float mouseV = _InputHandler.getLook().x;
            transform.RotateAround(pivotPoint, new Vector3(0, 1, 0f), mouseH * 100 * _cameraSpeed * Time.deltaTime);
            // Get the offset position
            offset = this.transform.position - _target2Follow.transform.position;
            offset = offset.normalized;
            offset.y = cameraOffsetY / f_offsetDistance;

            getCameraDirection();
        }
        followTarget();
        getCameraDirection();
        bRotateCamera = false;
    }
    //zoom in, out
    void zoomInOut()
    {
        if (f_offsetDistance > 1 && _InputHandler.getMouseZoom() > 0 || _InputHandler.getMouseZoom() < 0)
        {
            f_offsetDistance += _InputHandler.getMouseZoom() * -1.5f;
            // cameraOffsetY += _InputHandler.getMouseZoom() * 1.5f;

        }
    }
    // follow around
    void followTarget()
    {
        // Debug.Log("OFFSET: " + offset);
        // this.transform.position = Vector3.Lerp(
        //     this.transform.position,
        //     _target2Follow.transform.position + offset * f_offsetDistance,
        //     _cameraSpeed * Time.deltaTime);
        this.transform.position = _target2Follow.transform.position + offset * f_offsetDistance;
    }
    void getCameraDirection()
    {
        vertical_T = -1 * _Camera.transform.forward;
        vertical_T.y = 0;
        vertical_D = -vertical_T;
        horizontal_R = _Camera.transform.right;
        horizontal_L = -horizontal_R;
    }
}
