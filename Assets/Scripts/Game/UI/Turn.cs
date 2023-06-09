using UnityEngine;
using TMPro;
using GameSystem;

namespace UI
{
    public class Turn : MonoBehaviour
    {
        [SerializeField]
        GameManager manager;
        [SerializeField]
        TextMeshProUGUI text; 
        void Start()
        {
            manager.turnChange = textUpdate;
        }

        public void textUpdate(int currentTurn)
        {
            text.text = $"築いた死体の数: {currentTurn}";
        }
    }
}