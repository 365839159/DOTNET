using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm.Model
{
    /// <summary>
    ///  Company    
    /// </summary>
    public class Company
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
