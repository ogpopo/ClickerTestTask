using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.HUD
{
    public class HUDRoot : MonoBehaviour, IHUDRoot
    {
        [SerializeField] private TextMeshProUGUI _gemValueText;
        [SerializeField] private TextMeshProUGUI _maxEnergyValueText;
        [SerializeField] private TextMeshProUGUI _currentEnergyValueText;

        public void ChangeVariableByType(HUDElementType changedType, int newValue)
        {
            switch (changedType)
            {
                case HUDElementType.Gem:
                    _gemValueText.text = newValue.ToString();
                    break;
                case HUDElementType.MaxEnergy:
                    _maxEnergyValueText.text = newValue.ToString();
                    break;
                case HUDElementType.CurrentlyEnergy:
                    _currentEnergyValueText.text = newValue.ToString();
                    break;
            }
        }

        public class Factory : PlaceholderFactory<string, UniTask<HUDRoot>>
        {
        }
    }
}