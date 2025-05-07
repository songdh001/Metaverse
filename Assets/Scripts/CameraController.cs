using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCam;
    public Transform player;
    public float panSpeed = 5f;

    //카메라 줌 기능 구현
    public float zoomSpeed = 2f;
    public float minZoom = 3f;
    public float maxZoom = 10f;

    //줌을 하는 것은 메인 카메라이기 때문에 카메라도 불러올 거임
    private Camera mainCam;

    //bool 값으로 자유 카메라 모드인지 아닌지 체크할 거임
    private bool isFreeLook = false;
    private Vector3 freeLookPosition;

    //카메라가 맵에서 너무 벗어나지 않게 조절할 거임
    public Tilemap tilemap;
    private Bounds mapBounds;


    void Start()
    {
        mainCam = Camera.main;
        //타일맵의 경계를 계산
        mapBounds = tilemap.localBounds;
    }



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
                virtualCam.gameObject.SetActive(false);
            }
            else
            {
                // 다시 따라가기 활성화
                virtualCam.gameObject.SetActive(true);
                // 플레이어 다시 따라가기
                virtualCam.Follow = player;             
            }
        }

        //탐색 모드일 때 카메라만 움직일 수 있도록
        if (isFreeLook)
        {
            FreeLookCameraMovement();
        }

        //마우스휠로 확대, 축소 기능
        ZoomControl();

    }



    void FreeLookCameraMovement()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f) * panSpeed * Time.deltaTime;
        mainCam.transform.position += move;

        // 카메라 경계 계산
        float camHalfHeight = mainCam.orthographicSize;
        float camHalfWidth = camHalfHeight * mainCam.aspect;

        float minX = mapBounds.min.x + camHalfWidth;
        float maxX = mapBounds.max.x - camHalfWidth;
        float minY = mapBounds.min.y + camHalfHeight;
        float maxY = mapBounds.max.y - camHalfHeight;

        Vector3 clampedPos = mainCam.transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, minX, maxX);
        clampedPos.y = Mathf.Clamp(clampedPos.y, minY, maxY);
        mainCam.transform.position = clampedPos;
    }

    void ZoomControl()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            mainCam.orthographicSize -= scroll * zoomSpeed;
            mainCam.orthographicSize = Mathf.Clamp(mainCam.orthographicSize, minZoom, maxZoom);
        }
    }
}
