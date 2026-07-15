using System;
using Sourceг;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.UI
{
    public class LevelHandler: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private Slider _slider;
        private void Awake()
        {
            G.OnLevelChanged += OnLevelChanged;
            G.OnExpChanged += OnExpChanged;
        }

        private void OnExpChanged(int value)
        {
            var v = 0f;
            if (G.LevelMap.TryGetValue(G.CurrentLevel + 1, out var expForNextLevel))
            {
                v = (float)value / expForNextLevel;
            }
            else
            {
                v = Math.Clamp(value / G.LevelMap[G.CurrentLevel], 0, 1);
            }
            _slider.value = v;
        }
        private void OnLevelChanged(int i)
        {
            _levelText.text = $"Level {i}";
        }
    }
}