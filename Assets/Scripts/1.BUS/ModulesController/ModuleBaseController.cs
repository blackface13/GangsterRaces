using Assets.Scripts._1.BUS.Settings;
using Assets.Scripts._1.BUS.SystemManagers;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts._1.BUS.ModulesController
{
    /// <summary>
    /// Feature base cho các tính năng trong game
    /// </summary>
    public class ModuleBaseController : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        [TabGroup("Cấu hình chung")]
        [Title("background")]
        private Image _backgroundImg;
        [SerializeField]

        [TabGroup("Cấu hình chung")]
        [Title("Object root của feature")]
        private Transform _rootObject;
        #endregion

        #region Initialize
        public virtual void Awake()
        {
            ShowFeatureUIWithFade();
        }

        public virtual void Start()
        {

        }

        /// <summary>
        /// Show UI với hiệu ứng
        /// </summary>
        private void ShowFeatureUIWithFade()
        {
            _backgroundImg?.DOFade(0, 0).SetUpdate(true);
            _backgroundImg?.DOFade(UISettings.FEATURE_BACKGROUND_OPACITY, UISettings.FEATURE_SHOW_DURATION).SetUpdate(true);
            _rootObject?.DOScale(Vector3.one, UISettings.FEATURE_SHOW_DURATION).SetEase(Ease.OutBack).SetUpdate(true);
        }
        #endregion

        #region Functions
        /// <summary>
        /// Đóng tính năng
        /// </summary>
        public virtual void CloseMe()
        {
            if (GameSystems.IsUIControl)
            {
                _backgroundImg?.DOFade(0, UISettings.FEATURE_SHOW_DURATION).SetUpdate(true);
                _rootObject?.DOScale(Vector3.zero, UISettings.FEATURE_SHOW_DURATION).SetUpdate(true).OnComplete(() => GameSystems.CloseFeatureUI());
            }
        }
        #endregion
    }
}