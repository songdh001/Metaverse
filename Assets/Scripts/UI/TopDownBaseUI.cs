using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;


namespace TopDown
{
    public abstract class BaseUI : MonoBehaviour
    {
        protected UIManager uiManager;
        public virtual void Init(UIManager uIManager)
        {
            this.uiManager = uIManager;
        }


        protected abstract UIState GetUIState();

        public void SetActive(UIState state)
        {
            this.gameObject.SetActive(GetUIState() == state);
        }
    }

}

