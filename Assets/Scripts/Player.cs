using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform objectFrontVector;

    private float h = 0.0f;
    private float v = 0.0f;
    public float moveSpeed = 10.0f;

    private float yRotate, yRotateMove;
    public float rotateSpeed = 500.0f;

    void Update()
    {
        /* debug */
        Debug.DrawLine(transform.position, objectFrontVector.position, Color.red);

        /* player 이동 */
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        transform.Translate(moveDir.normalized * Time.deltaTime * moveSpeed, Space.Self);

        /* 회전 */
        yRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;

        yRotate = transform.eulerAngles.y + yRotateMove;

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotate, 0);
    }

    //private void LateUpdate()
    //{
    //    Camera.main.transform.position = transform.position;
    //}
}
