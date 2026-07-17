using TMPro;
using UnityEngine;

namespace Source.Objects.Space
{
    public class OutOfAreaPlaceholder: MonoBehaviour
    {
        [SerializeField] private TMP_Text outOfAreaPrefabText;


        public void SetEstimated(float time)
        {
            outOfAreaPrefabText.text = $"Out of Area: you would be destroyed in {Mathf.RoundToInt(time)} seconds.";
        }
    }
}