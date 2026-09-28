using _Project.Develop.Runtime.Gameplay.Characters;
using TMPro;
using UnityEngine;

namespace _Project.Develop.Runtime.UI
{
    public class CollectablesView : MonoBehaviour
    {
        // Consts
        private const string CoinsAmountPrefix = "x ";

        [Header("References:")]
        [SerializeField] private Character _character = null;
        [SerializeField] private TMP_Text _coinsCountText = null;

        private void Update()
            => _coinsCountText.SetText($"{CoinsAmountPrefix}{_character.CoinsCount}");
    }
}