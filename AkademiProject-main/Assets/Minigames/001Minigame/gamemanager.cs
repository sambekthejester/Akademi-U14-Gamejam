
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace mini2 {
    public class gamemanager : MonoBehaviour
    {
        [SerializeField] MinigameManager _minigameManager;
        float timer = 10f;
        [SerializeField] GameObject deadpanel;
        [SerializeField] GameObject winpanel;
        [SerializeField] TMP_Text txt;
        private void Update()
        {
            timer -= Time.deltaTime;
            txt.text = System.Math.Round(timer, 1).ToString();
            if (timer <= 0)
            {
                win();
            }
        }
        public void dead()
        {
            _minigameManager.Lose();
        }
        void win()
        {
            _minigameManager.Win();
        }
    
    }
    
}

