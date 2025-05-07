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

    //ī�޶� �� ��� ����
    public float zoomSpeed = 2f;
    public float minZoom = 3f;
    public float maxZoom = 10f;

    //���� �ϴ� ���� ���� ī�޶��̱� ������ ī�޶� �ҷ��� ����
    private Camera mainCam;

    //bool ������ ���� ī�޶� ������� �ƴ��� üũ�� ����
    private bool isFreeLook = false;
    private Vector3 freeLookPosition;

    //ī�޶� �ʿ��� �ʹ� ����� �ʰ� ������ ����
    public Tilemap tilemap;
    private Bounds mapBounds;


    void Start()
    {
        mainCam = Camera.main;
        //Ÿ�ϸ��� ��踦 ���
        mapBounds = tilemap.localBounds;
    }



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
                virtualCam.gameObject.SetActive(false);
            }
            else
            {
                // �ٽ� ���󰡱� Ȱ��ȭ
                virtualCam.gameObject.SetActive(true);
                // �÷��̾� �ٽ� ���󰡱�
                virtualCam.Follow = player;             
            }
        }

        //Ž�� ����� �� ī�޶� ������ �� �ֵ���
        if (isFreeLook)
        {
            FreeLookCameraMovement();
        }

        //���콺�ٷ� Ȯ��, ��� ���
        ZoomControl();

    }



    void FreeLookCameraMovement()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f) * panSpeed * Time.deltaTime;
        mainCam.transform.position += move;

        // ī�޶� ��� ���
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
