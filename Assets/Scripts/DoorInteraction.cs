using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    // 확인용 이름
    public string doorName;
    // 연결할 씬 이름
    public string targetSceneName;

    public void Interact()
    {
        Debug.Log($"[{doorName}] 문과 상호작용했습니다.");

        if (!string.IsNullOrEmpty(targetSceneName))
        {
            SceneManager.LoadScene(targetSceneName);
        }
        else
        {
            // 애니메이션 효과 등
            Debug.Log($"{doorName} 문이 열립니다!");
        }
    }
}
