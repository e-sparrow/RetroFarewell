﻿using System.Linq;
using UnityEngine;

namespace Utils.Extensions
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Возвращает все дочерние объекты Transform'а.
        /// </summary>
        public static Transform[] GetChilds(this Transform transform)
        {
            return Collections.For(value => transform.GetChild(value), transform.childCount).ToArray();
        }
    }
}
