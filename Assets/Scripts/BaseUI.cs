using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;


namespace Stack
{
    public abstract class BaseUI : MonoBehaviour
    {
        protected UIManager uiManager;

        public virtual void Init(UIManager uiManager)
        {
            this.uiManager = uiManager;
        }


        protected abstract UIState GetUIStates();

        public void SetActive(UIState state)
        {
            gameObject.SetActive(GetUIStates() == state);

        }
    }
}

