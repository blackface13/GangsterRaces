using BlackFace.SkullTribalIntrusion.Core.Constants;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts._1.BUS.UIController
{
    /// <summary>
    /// Show danh sách các UI object với animation DoTween
    /// </summary>
    public class InitUIController : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        [TabGroup("Cấu hình chung")]
        [Title("Danh sách gameobject")]
        [Required]
        private List<GameObject> _gameObjectList;

        [SerializeField]
        [TabGroup("Cấu hình chung")]
        [Title("Kiểu hiển thị")]
        private Ease _tweenType = Ease.OutBack;

        [SerializeField]
        [TabGroup("Cấu hình chung")]
        [Title("Delay xuất hiện")]
        private float _delayTimeStart = 0;

        [SerializeField]
        [TabGroup("Cấu hình chung")]
        [Title("Delay time giữa 2 object")]
        private float _delayTimeBetween = 0;

        [SerializeField]
        [TabGroup("Cấu hình chung")]
        [Title("Thời gian thực thi anim")]
        private float _duration = UISettings.SHOW_ITEM_IN_LIST_TIME;

        [SerializeField]
        [TabGroup("Cấu hình hiển thị")]
        [Title("Kiểu xuất hiện")]
        private AnimTypes AnimType = AnimTypes.Scale;

        [ShowIf("AnimType", AnimTypes.Scale)]
        [SerializeField]
        [TabGroup("Cấu hình hiển thị")]
        [Title("Scale ban đầu")]
        private Vector3 _fromScale;

        [ShowIf("AnimType", AnimTypes.Scale)]
        [SerializeField]
        [TabGroup("Cấu hình hiển thị")]
        [Title("Scale target")]
        private Vector3 _toScale = Vector3.one;

        [ShowIf("AnimType", AnimTypes.MovePos)]
        [SerializeField]
        [TabGroup("Cấu hình hiển thị")]
        [Title("Di chuyển tới")]
        private List<Vector3> _toPos;
        #endregion

        #region Functions
        private void Awake()
        {
            SetupDefaultValue();
            UniTask.Create(() => StartAction());
        }

        /// <summary>
        /// Khởi tạo giá trị mặc định cho các object
        /// </summary>
        private void SetupDefaultValue()
        {
            if (AnimType == AnimTypes.Scale)
            {
                foreach (var obj in _gameObjectList)
                {
                    obj.transform.localScale = _fromScale;
                }
            }
        }

        /// <summary>
        /// Thực thi move
        /// </summary>
        /// <returns></returns>
        private async UniTask StartAction()
        {
            await UniTask.Delay(_delayTimeStart.ToMiliseconds());
            switch (AnimType)
            {
                case AnimTypes.Scale:
                    foreach (var obj in _gameObjectList)
                    {
                        obj.transform.DOScale(_toScale, _duration).SetEase(_tweenType);
                        await UniTask.Delay(_delayTimeBetween.ToMiliseconds());
                    }
                    break;
                case AnimTypes.MovePos:
                    int index = 0;
                    foreach (var obj in _gameObjectList)
                    {
                        obj.transform.DOLocalMove(_toPos[index], _duration).SetEase(_tweenType);
                        index++;
                        await UniTask.Delay(_delayTimeBetween.ToMiliseconds());
                    }
                    break;
                default: break;
            }
        }

        public enum AnimTypes
        {
            Scale,
            MovePos,
            Fade
        }
        #endregion
    }
}
