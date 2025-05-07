using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI restartTxt;
    public GameObject exitButton;

    // Start is called before the first frame update
    void Start()
    {
        if (restartTxt == null) Debug.Log("����ŸƮ �ؽ�Ʈ ����");

        if (scoreTxt == null) Debug.Log("���ھ� �ؽ�Ʈ ����");

        restartTxt.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        restartTxt.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreTxt.text = score.ToString();
    }

    public void OnClickExit()
    {
        SceneManager.LoadScene("MainMetaverseScene");
    }
}
