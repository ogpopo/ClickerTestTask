using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.UI.LoadingCurtain
{
    public class LoadingCurtain : MonoBehaviour, ILoadingCurtain
    {
        [SerializeField] private CanvasGroup _curtain;

        public void Show()
        {
            gameObject.SetActive(true);
            _curtain.alpha = 1;
        }
    
        public void Hide() => StartCoroutine(DoFadeIn());
    
        private IEnumerator DoFadeIn()
        {
            while (_curtain.alpha > 0)
            {
                _curtain.alpha -= 0.03f;
                yield return new WaitForSeconds(0.03f);
            }
      
            gameObject.SetActive(false);
        }

        public class Factory : PlaceholderFactory<string, UniTask<LoadingCurtain>>
        {
        }
    }
}