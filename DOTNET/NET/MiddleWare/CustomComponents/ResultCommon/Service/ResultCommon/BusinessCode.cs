using System;
using System.Collections.Generic;
using System.Text;

namespace CustomComponents.ResultCommon
{
    public  class BusinessCode
    {
        /// <summary>
        /// 用户中心
        /// </summary>
        public static readonly string UserCenter = "001";
         /// <summary>
         /// 资源中心
         /// </summary>
        public static readonly string ResourceCenter = "002";
        /// <summary>
        /// 数据中心
        /// </summary>
        public static readonly string DataCenter = "003";
        /// <summary>
        /// 课堂
        /// </summary>
        public static readonly string Classroom = "101";
        /// <summary>
        /// 课程
        /// </summary>
        public static readonly string Course = "201";
        /// <summary>
        /// 精准学习
        /// </summary>
        public static readonly string AccurateLearning = "301";
        /// <summary>
        /// 公共工具
        /// </summary>
        public static readonly string PublicTools = "401";

        public  static BusinessCodeIndex BusinessIndexValue { get; } = new BusinessCodeIndex();

    }
    public class BusinessCodeIndex
    {
        private Dictionary<BusinessEnum, string> arr
        {
            get
            {
                var dict = new Dictionary<BusinessEnum, string>();

                foreach (var item in typeof(BusinessEnum).GetFields())
                {
                    foreach (var items in typeof(BusinessCode).GetFields())
                    {
                        if (item.Name == items.Name)
                        {
                            dict.Add((BusinessEnum)(int)item.GetValue(null), items.GetValue(null).ToString());
                            break;
                        }
                    }
                }
                return dict;
            }
        }

        public string this[BusinessEnum index]
        {
            get
            {
                return this.arr[index];
            }
        }

    }
}
