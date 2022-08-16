namespace Assets.Scripts._0.DTO.Models
{
    public class StateModel
    {/// <summary>
     /// Nhìn trái hay phải
     /// </summary>
        public bool IsViewLeft; //Nhìn trái hay phải

        /// <summary>
        /// Sống hay chết
        /// </summary>
        public bool Live; //Sống hay die

        /// <summary>
        /// Dính thiêu đốt
        /// </summary>
        public bool Burn; //Dính thiêu đốt

        /// <summary>
        /// Dính độc
        /// </summary>
        public bool Poison; //Dính độc

        /// <summary>
        /// Rỉa máu
        /// </summary>
        public bool Bleed;

        /// <summary>
        /// Đóng băng
        /// </summary>
        public bool Freeze;

        /// <summary>
        /// Hồi máu mạnh
        /// </summary>
        public bool Healing;

        /// <summary>
        /// Dính choáng
        /// </summary>
        public bool Stun; //Dính choáng

        /// <summary>
        /// Bị đẩy lùi
        /// </summary>
        public bool Repel; //Đẩy lùi

        /// <summary>
        /// Bị đánh
        /// </summary>
        public bool Knock; //Bị đánh

        /// <summary>
        /// Hất văng
        /// </summary>
        public bool Hurl; //Hất văng

        /// <summary>
        /// Hất tung
        /// </summary>
        public bool HurlUp; //Hất tung

        /// <summary>
        /// Không nhận sát thương
        /// </summary>
        public bool BlockDamage; //Ko nhận sát thương

        /// <summary>
        /// Không nhận hiệu ứng bất lợi
        /// </summary>
        public bool BlockEffect; //Ko nhận hiệu ứng

        /// <summary>
        /// Chặn toàn bộ sát thương và mọi hiệu ứng hiện có và trong thời gian hiệu lực
        /// </summary>
        public bool BlockAll; //Ko nhận bất cứ sát thương hay hiệu ứng gì
    }
}