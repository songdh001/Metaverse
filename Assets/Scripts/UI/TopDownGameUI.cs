using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace TopDown
{
    public class GameUI : BaseUI
    {
        [SerializeField] private TextMeshProUGUI waveText;
        [SerializeField] private Slider hpSlider;

        private void Start()
        {

        }


        public void UpdateHPSlider(float percentage)
        {
            hpSlider.value = percentage;
        }


        public void UpdateWaveText(int wave)
        {
            waveText.text = wave.ToString();
        }

        protected override UIState GetUIState()
        {
            return UIState.Game;
        }
    }

}

