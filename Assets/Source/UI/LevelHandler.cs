using System;
using Source.UI.Level;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.UI
{
    public class LevelHandler: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private Image fillImage;
        
        private void Start()
        {
            G.OnExpChanged += OnExpChanged;
            G.OnLevelChanged += OnLevelChanged;

            OnExpChanged(G.CurrentExp);
            OnLevelChanged(G.CurrentLevel);
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
            fillImage.fillAmount = v;
        }
        private void OnLevelChanged(int i)
        {
            _levelText.text = $"Level {i}";
        }

        private void OnDestroy()
        {
            G.OnLevelChanged -= OnLevelChanged;
            G.OnExpChanged -= OnExpChanged;
        }
    }
}