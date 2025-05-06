using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCam;
    public Transform player;
    public float panSpeed = 5f;

    //bool ������ ���� ī�޶� ������� �ƴ��� üũ�� ����
    private bool isFreeLook = false;
    private Vector3 freeLookPosition;

    // Update is called once per frame
    void Update()
    {
        // Tab�� ������ ��� ��ȯ
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isFreeLook = !isFreeLook;

            if (isFreeLook)
            {
                // Ž�� ���ϱ� ���󰡴� �� ���ֱ�
                virtualCam.Follow = null;
                freeLookPosition = virtualCam.transform.position;
            }
            else
            {
                // �ٽ� ���󰡱� Ȱ��ȭ
                virtualCam.Follow = player;
            }
        }
        //Ž�� ����� �� ī�޶� ������ �� �ֵ���
        if (isFreeLook)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            freeLookPosition += new Vector3(h, v, 0) * panSpeed * Time.deltaTime;
            virtualCam.transform.position = new Vector3(freeLookPosition.x, freeLookPosition.y, virtualCam.transform.position.z);
        }
    }
}
