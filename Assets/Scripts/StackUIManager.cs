using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.XR;

namespace Stack
{
    public enum UIState
    {
        Home,
        Game,
        Score,
    }
    public class UIManager : MonoBehaviour
    {
        static UIManager instance;
        public static UIManager Instance
        {
            get { return instance; }
        }

        UIState currentState = UIState.Home;
        HomeUI homeUI = null;
        GameUI gameUI = null;
        ScoreUI scoreUI = null;

        TheStack theStack = null;

        private void Awake()
        {
            instance = this;

            theStack = FindObjectOfType<TheStack>();

            homeUI = GetComponentInChildren<HomeUI>(true); //true는 꺼져있는 오브젝트도 찾는다는 이야기
            homeUI?.Init(this);

            gameUI = GetComponentInChildren<GameUI>(true);
            gameUI?.Init(this);

            scoreUI = GetComponentInChildren<ScoreUI>(true);
            scoreUI?.Init(this);

            ChangeState(UIState.Home);
        }

        public void ChangeState(UIState state)
        {
            currentState = state;
            homeUI?.SetActive(currentState);
            gameUI?.SetActive(currentState);
            scoreUI?.SetActive(currentState);
        }

        public void OnClickStart()
        {
            theStack.Restart();
            ChangeState(UIState.Game);
        }

        public void OnClickExit()
        {
#if UNITY_EDITOR
            SceneManager.LoadScene("MainMetaverseScene");
#else
        SceneManager.LoadScene("MainMetaverseScene");
#endif
        }


        public void UpdateScore()
        {
            gameUI.SetUI(theStack.Score, theStack.Combo, theStack.maxCombo);
        }

        public void SetScoreUI()
        {
            scoreUI.SetUI(theStack.Score, theStack.maxCombo, theStack.BestScore, theStack.BestCombo);
            ChangeState(UIState.Score);
        }
    }

}
