using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts._1.BUS.SystemManagers
{
    public static class GameSystems
    {
        #region Fields

        /// <summary>
        /// Feature UI đang được active
        /// </summary>
        public static List<GameObject> FeatureUIActive = new List<GameObject>(5);

        /// <summary>
        /// Cho phép thao tác UI hay ko
        /// </summary>
        public static bool IsUIControl;
        #endregion

        #region General functions

        /// <summary>
        /// Khởi tạo giao diện cho function controller
        /// </summary>
        /// <param name="function"></param>
        public static void ShowFeatureUI(EnumBase.FeatureUI feature)
        {
            FeatureUIActive.Add(MonoBehaviour.Instantiate(Resources.Load<GameObject>(String.Concat("Prefabs/UI/FunctionController/", feature)), Vector3.zero, Quaternion.identity));
        }

        /// <summary>
        /// Đóng feature UI và giải phóng bộ nhớ
        /// </summary>
        public static void CloseFeatureUI()
        {
            MonoBehaviour.Destroy(FeatureUIActive[FeatureUIActive.Count - 1]);
            FeatureUIActive.RemoveAt(FeatureUIActive.Count - 1);
            Resources.UnloadUnusedAssets();
        }
        #endregion
    }
}
