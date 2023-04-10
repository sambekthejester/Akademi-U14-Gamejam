
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mini1
{

    public class gamemanager : MonoBehaviour
    {
        [SerializeField] MinigameManager _minigameManager;
        
        [SerializeField] Text txt;
        int score = 0;

        
        void Update()
        {
            
            if (score >= 100)
            {
                Win();
            }
        }

        private void Win()
        {
            _minigameManager.Win();
        }

        public void scoreUp()
        {
            score += 10;
            txt.text = score.ToString();
        }
    }

}
