#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：Company
// 创 建 者：zhang xian cheng
// 创建时间：2021年10月30日 星期六 13:18
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using System;

namespace Asp.NetCore.Model.Entity
{
    /// <summary>
    ///  Company    
    /// </summary>
    public class Company : EntityBase
    {
        /// <summary>
        /// 无    
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public int? LastModifierId { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public DateTime? LastModifyTime { get; set; }
    }
}