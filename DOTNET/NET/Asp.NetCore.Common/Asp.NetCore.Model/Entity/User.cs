#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：User
// 创 建 者：zhang xian cheng
// 创建时间：2021年10月30日 星期六 13:16
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
    ///  User    
    /// </summary>
    public class User : EntityBase
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
        public string Account { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 用户状态  0正常 1冻结 2删除    
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 用户类型  1 普通用户 2管理员 4超级管理员    
        /// </summary>
        public int UserType { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public DateTime? LastLoginTime { get; set; }

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