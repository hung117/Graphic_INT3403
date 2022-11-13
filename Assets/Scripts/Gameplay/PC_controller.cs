using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_controller : MonoBehaviour
{
    [Header("MOVEMENT")]
    [SerializeField] protected InputHandler _InputHandler;
    [SerializeField] protected Camera_Controller _cameraCotroller;
    [SerializeField] protected GameObject m_body;
    public Vector3 moveInput; protected float foward = 0; public Vector3 moveDir;
    public float f_moveSpeed = 4;
    public float f_runMultiplier = 4;
    [SerializeField] public Rigidbody m_rbody;
    [SerializeField] private float stepHeight = 1.5f;
    [SerializeField] private float f_groundCheck_rayLength = 2;
    void Start()
    {
        m_rbody = GetComponent<Rigidbody>();
    }
    protected void handleMovement()
    {
        moveDir = Vector3.zero;
        moveInput = _InputHandler.getMove();
        if (moveInput != Vector3.zero)
        {
            foward = -1;
            moveDir = moveInput.x * _cameraCotroller.horizontal_R + moveInput.z * _cameraCotroller.vertical_D;
            m_body.transform.rotation = Quaternion.LookRotation(moveDir.normalized);
            m_body.transform.rotation = Quaternion.LookRotation(new Vector3(moveDir.normalized.z, moveDir.normalized.y, -1 * moveDir.normalized.x));

            moveDir = moveDir.normalized * f_moveSpeed / 10;
            // Rotate toward moveDIr
            if (_InputHandler.getShift())
            {// Run
                moveDir *= f_runMultiplier;
                foward = 1;
            }

        }
        else
        {
            foward = 0;
            moveDir = Vector3.zero;
        }
    }
    void groundCheck()
    {
        // souls like gorund check system
        // layer define
        // int layerMask = 1 << 8;
        int layerMask = 1 << 2;
        layerMask = ~layerMask;
        // int layerMask = LayerMask.GetMask("Ignore Raycast");

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, m_body.transform.TransformDirection(Vector3.down), out hit, f_groundCheck_rayLength, layerMask))
        {
            Debug.DrawRay(transform.position, m_body.transform.TransformDirection(Vector3.down) * hit.distance, Color.green);
            // Debug.Log("hit point: " + hit.transform.position);
            m_rbody.useGravity = false;
            // make the character hover above hit point
            // m_body.transform.position = m_body.transform.position + new Vector3(0, hit.transform.position.y + stepHeight, 0);
            // both is usable (2lines below)
            // Vector3 positionToInstantiateAt = Vector3.Project((hit.point - hit.transform.position), hit.normal) + hit.transform.position;
            Vector3 positionToInstantiateAt = hit.point;
            Debug.Log("hit point vs obj pos: " + (hit.transform.position - hit.point));

            // Vector3 positionToInstantiateAt = hit.point;
            // m_body.transform.position = new Vector3(m_body.transform.position.x, hit.transform.position.y + stepHeight, m_body.transform.position.z);
            m_body.transform.position = new Vector3(m_body.transform.position.x, positionToInstantiateAt.y + stepHeight, m_body.transform.position.z);
        }
        else
        {
            m_rbody.useGravity = true;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.black);
        }

    }

    public float getFoward()
    {
        return this.foward;
    }
    void FixedUpdate()
    {
        groundCheck();
        m_rbody.AddForce(moveDir, ForceMode.Impulse);
    }
    void Update()
    {
        handleMovement();
    }
}
