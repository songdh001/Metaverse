using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCam;
    public Transform player;
    public float panSpeed = 5f;

    //bool 값으로 자유 카메라 모드인지 아닌지 체크할 거임
    private bool isFreeLook = false;
    private Vector3 freeLookPosition;

    // Update is called once per frame
    void Update()
    {
        // Tab을 눌러서 모드 전환
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isFreeLook = !isFreeLook;

            if (isFreeLook)
            {
                // 탐색 모드니까 따라가는 거 없애기
                virtualCam.Follow = null;
                freeLookPosition = virtualCam.transform.position;
            }
            else
            {
                // 다시 따라가기 활성화
                virtualCam.Follow = player;
            }
        }
        //탐색 모드일 때 카메라만 움직일 수 있도록
        if (isFreeLook)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            freeLookPosition += new Vector3(h, v, 0) * panSpeed * Time.deltaTime;
            virtualCam.transform.position = new Vector3(freeLookPosition.x, freeLookPosition.y, virtualCam.transform.position.z);
        }
    }
}
