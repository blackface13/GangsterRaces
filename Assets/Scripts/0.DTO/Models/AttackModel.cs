using Assets.Scripts._0.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts._0.DTO.Models
{
    public class AttackModel : IAttackModel
    {
        /// <summary>
        /// Object gây ra sát thương
        /// </summary>
        public GameObject AttackSourceObject { get; set; }

        /// <summary>
        /// Đối tượng bị đánh trúng
        /// </summary>
        public GameObject TargetObject { get; set; }

        /// <summary>
        /// Script controller của đối tượng bị đánh trúng
        /// </summary>
        public object TargetController { get; set; }

        /// <summary>
        /// Hiệu ứng của atk
        /// </summary>
        public StateModel State { get; set; }

        /// <summary>
        /// Chỉ số của atk
        /// </summary>
        public StatsModel Stats { get; set; }
    }
}