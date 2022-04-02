using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPICore.Infrastructure.Extensions
{
    public class ResultItem
    {
        private int m_idx;
        private string m_name;
        private List<object> m_list;
        private string m_prop;
        private object m_obj;

        public int Num { get; set; }

        public ResultItem()
        {
            m_idx = 0;
            m_name = null;
            m_list = null;
            m_prop = null;
            m_obj = null;
        }

        public ResultItem(int idx, string name, object obj = null, string prop = null)
        {
            m_idx = idx;
            m_name = name;
            m_list = null;
            m_prop = prop;
            m_obj = obj;
        }

        public string Idx
        {
            get
            {
                return m_idx == 0 ? null : m_idx.ToString();
            }
            set
            {
                m_idx = 0;
                int.TryParse(value, out m_idx);
            }
        }

        public string Name
        {
            get
            {
                return m_name;
            }

            set
            {
                m_name = value;
            }
        }

        public string Prop
        {
            get
            {
                return m_prop;
            }

            set
            {
                m_prop = value;
            }
        }

        public object Obj
        {
            get
            {
                return m_obj;
            }

            set
            {
                m_obj = value;
            }
        }

        public List<object> ChildList
        {
            get
            {
                return m_list;
            }
            set
            {
                m_list = value;
            }
        }

        public void Add(object child)
        {
            if (m_list == null)
                m_list = new List<object>();
            m_list.Add(child);
        }

        public bool ContainsChildIdx(int idx)
        {
            if (m_list != null && m_list.Count > 0)
            {
                foreach (object item in m_list)
                {
                    if (item is IChildList
                        && ((IChildList)item).ContainsIdx(idx))
                        return true;
                }
            }
            return false;
        }

        public object FindChildListItem(int idx)
        {
            if (m_list != null && m_list.Count > 0)
            {
                foreach (object item in m_list)
                {
                    if (item is IChildList
                        && ((IChildList)item).ContainsIdx(idx))
                        return item;
                }
            }
            return null;
        }

        public bool ContainsIdx(int idx)
        {
            return m_idx == idx;
        }
    }

    interface IChildList
    {
        bool ContainsIdx(int idx);
    }
}
