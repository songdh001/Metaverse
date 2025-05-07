using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class InteractableDoor : MonoBehaviour, IInteractable
{
    // Ȯ�ο� �̸�
    public string doorName;
    // ������ �� �̸�
    public string targetSceneName;

    public void Interact()
    {
        Debug.Log($"[{doorName}] ���� ��ȣ�ۿ��߽��ϴ�.");

        if (!string.IsNullOrEmpty(targetSceneName))
        {
            SceneManager.LoadScene(targetSceneName);
        }
        else
        {
            // �ִϸ��̼� ȿ�� ��
            Debug.Log($"{doorName} ���� �����ϴ�!");
        }
        // �� ���� �ִϸ��̼� �Ǵ� �� ��ȯ �� ����
    }
}
