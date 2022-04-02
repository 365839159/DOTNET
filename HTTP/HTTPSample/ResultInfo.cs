using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPICore.Infrastructure.Extensions
{
    [Serializable]
    public class ResultInfo
    {
        public static int RC_OK = 1;
        public static int RC_UNKOWN = 0;
        public static int RC_FAIL = -100;

        public const int ERR_INVALIDATE_PARAM = -1;
        public const int ERR_DB_SYS = -2;
        public const int ERR_INVALIDATE_SESSION = -3;
        public const int ERR_INVALIDATE_PAGE = -4;
        public const int ERR_INVALIDATE_RIGHT = -5;
        public const int ERR_DB_RETURN = 100;
        public const int ERR_INVALIDATE_SESSION2 = -9999;
        public const int ERR_DB_NO_DATA = -9;

        private static int MAX_JSON_LENGTH = 102396;

        private int retcode;

        private int m_returnCode;
        private int m_errCode;
        private string m_returnText;
        private int m_page;
        private int m_pageCount;

        public List<object> result;

        public ResultInfo()
        {
            m_returnCode = RC_OK;
            m_errCode = 0;
            m_page = 0;
            m_pageCount = 0;
            m_returnText = null;
            result = null;
        }

        public ResultInfo(int returnCode)
        {
            m_returnCode = returnCode;
            m_page = 0;
            m_pageCount = 0;
        }

        public ResultInfo(int returnCode, int errCode)
        {
            m_returnCode = returnCode;
            m_errCode = errCode;
            m_page = 0;
            m_pageCount = 0;
            m_returnText = null;
            result = null;
        }

        public ResultInfo(int returnCode, int errCode, string returnText)
        {
            m_returnCode = returnCode;
            m_errCode = errCode;
            m_page = 0;
            m_pageCount = 0;
            m_returnText = returnText;
        }

        //public static ResultInfo GetFailResultInfo(DBError err)
        //{
        //    ResultInfo ri = new ResultInfo();
        //    ri.retcode = RC_FAIL;
        //    ri.AddResult(err);

        //    return ri;
        //}

        public static ResultInfo GetFailResultInfo(int returnCode)
        {
            ReturnError re = new ReturnError(returnCode);

            //ResultInfo ri = new ResultInfo(ResultInfo.RC_FAIL, re.errcode, re.error);
            if (re.errcode > 0)
                re.errcode = 0 - re.errcode;
            ResultInfo ri = new ResultInfo(re.errcode, re.errcode, re.error);

            return ri;
        }

        public static ResultInfo GetOKResultInfo(object obj)
        {
            ResultInfo ri = new ResultInfo();
            ri.retcode = RC_OK;
            ri.AddResult(obj);

            return ri;
        }

        public static ResultInfo GetFailResultInfo(string err)
        {
            ResultInfo ri = new ResultInfo();
            ri.retcode = RC_FAIL;
            ri.AddResult(err);

            return ri;
        }

        public static ResultInfo GetFailResultInfo()
        {
            ResultInfo ri = new ResultInfo();
            ri.retcode = RC_FAIL;

            return ri;
        }

        public int InsertItem(int index, object item)
        {
            int count = 0;
            if (item != null && index >= 0)
            {
                if (result == null)
                    result = new List<object>();

                result.Insert(index, item);
                count = result.Count;
                TestLength();
            }

            return count;
        }

        public int AddItem(object item)
        {
            int count = 0;
            if (item != null)
            {
                if (result == null)
                    result = new List<object>();

                result.Add(item);
                count = result.Count;
                //TestLength();
            }

            return count;
        }

        public int AddRangeItem(object[] array)
        {
            int count = 0;
            if (array != null && array.Length > 0)
            {
                if (result == null)
                    result = new List<object>();

                result.AddRange(array);
                count = result.Count;
            }
            return count;
        }

        public object GetItem(int index)
        {
            if (result != null && result.Count > index && index >= 0)
            {
                return result[index];
            }

            return null;
        }

        public int GetItemCount()
        {
            if (result != null)
                return result.Count;
            return 0;
        }

        public void ClearResult()
        {
            if (result != null)
            {
                result.Clear();
                result = null;
            }
        }

        //public int ErrCode
        //{
        //    set
        //    {
        //        m_errCode = value;
        //        if (m_errCode == ResultInfo.ERR_DB_SYS)
        //        {
        //            m_returnText = "DB throwed Exception.";
        //        }
        //    }
        //}

        public int ErrCode
        {
            set
            {
                ReturnError re = new ReturnError(value);
                if (re.errcode > 1)
                    re.errcode = 0 - re.errcode;

                m_returnCode = re.errcode;
                m_errCode = re.errcode;
                m_page = 0;
                m_pageCount = 0;
                m_returnText = re.error;
            }
        }

        public void AddResult(object obj)
        {
            if (obj != null)
            {
                if (result == null)
                    result = new List<object>();

                if (obj is IList && obj.GetType().IsGenericType)
                    result.AddRange((List<object>)obj);
                else
                    result.Add(obj);
            }
        }

        public string NextPage
        {
            get
            {
                if (m_returnCode == RC_OK && m_page < m_pageCount)
                {
                    return string.Format("{0}", m_page + 1);
                }

                return null;
            }
            set
            {
                if (value != null)
                    m_page++;
            }
        }

        protected int PageCount
        {
            get
            {
                if (m_pageCount < 1)
                    return 1;
                return m_pageCount;
            }
            set
            {
                m_pageCount = value;
            }
        }

        public int ReturnCode
        {
            get
            {
                return m_returnCode;
            }

            set
            {
                m_returnCode = value;
            }
        }

        public string ReturnText
        {
            get
            {
                if (m_returnCode == RC_FAIL)
                {
                    return string.Format("ErrCode:{0} {1}", m_errCode
                        , m_returnText == null ? "" : m_returnText);
                }
                else
                    return m_returnText;
            }

            set
            {
                m_returnText = value;
            }
        }

        public void SetLastIdx(int lastIdx)
        {
            if (result == null)
                result = new List<object>();

            if (result.Count > 0)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    if (result[i] is LastItem)
                        ((LastItem)result[i]).LastIdx = lastIdx.ToString();
                }
            }
            else
                result.Insert(0, new LastItem(lastIdx));
        }

        public void SetTotalNumber(int total)
        {
            if (result == null)
                result = new List<object>();

            bool bNotExists = true;
            if (result.Count > 0)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    if (result[i] is TotalNumber)
                    {
                        bNotExists = false;
                        ((TotalNumber)result[i]).Total = total.ToString();
                        break;
                    }
                }
            }

            if (bNotExists)
                result.Insert(0, new TotalNumber(total));
        }

        public void SetIndexCount(int indexCount)
        {
            if (result == null)
                result = new List<object>();

            bool bNotExists = true;
            if (result.Count > 0)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    if (result[i] is IndexCount)
                    {
                        bNotExists = false;
                        ((IndexCount)result[0]).Value = indexCount.ToString();
                        break;
                    }
                }
            }

            if (bNotExists)
                result.Insert(0, new IndexCount(indexCount));
        }

        public void SetPage(int page)
        {
            m_page = page < 1 ? 1 : page;
            m_pageCount = 1;

            if (result != null && result.Count > 0)
            {
                int length = GetJsonLength(this);

                if (length > MAX_JSON_LENGTH)
                {
                    int start = 0;

                    ResultInfo ri = new ResultInfo(m_returnCode, m_errCode, m_returnText);
                    //int baseLength = GetJsonLength(ri);

                    for (int i = 0; i < result.Count; i++)
                    {
                        ri.AddItem(result[i]);
                        int l = GetJsonLength(ri);

                        if (l >= MAX_JSON_LENGTH)
                        {
                            if (m_page == m_pageCount)
                            {
                                if (i < result.Count - 1)
                                {
                                    result.RemoveRange(i, result.Count - i);
                                    m_pageCount++;
                                }

                                if (start > 0)
                                {
                                    result.RemoveRange(0, start);
                                    start = 0;
                                }
                                break;
                            }

                            m_pageCount++;
                            ri.result.RemoveRange(0, ri.result.Count - 1);

                            start = i;
                        }
                    }

                    if (start > 0)
                        result.RemoveRange(0, start);

                    if (m_page > m_pageCount)
                    {
                        ClearResult();
                        m_returnCode = RC_FAIL;
                        m_errCode = ERR_INVALIDATE_PAGE;
                    }
                }
            }
        }

        public void SetPageBy2Div(int page)
        {
            m_page = page < 1 ? 1 : page;

            if (result != null && result.Count > 0)
            {
                int length = GetJsonLength(this);

                if (length > MAX_JSON_LENGTH)
                {

                    ResultInfo ri = new ResultInfo(m_returnCode, m_errCode, m_returnText);
                    int baseLength = GetJsonLength(ri);

                    int subLength = MAX_JSON_LENGTH - baseLength;
                    List<object> subList = SplitListByJsonLength(result, subLength);
                    if (subList != null && subList.Count > 1)
                    {
                        m_pageCount = subList.Count;
                        if (m_page <= m_pageCount)
                        {
                            result = (List<object>)subList[m_page - 1];
                        }
                        else
                        {
                            ClearResult();
                            m_returnCode = RC_FAIL;
                            m_errCode = ERR_INVALIDATE_PAGE;
                        }
                    }
                }
            }
        }

        public void SetPageBy2DivF(int page)
        {
            m_page = page < 1 ? 1 : page;

            if (result != null && result.Count > 0)
            {
                int length = GetJsonLength(this);

                if (length > MAX_JSON_LENGTH)
                {
                    ResultInfo ri = new ResultInfo(m_returnCode, m_errCode, m_returnText);
                    int baseLength = GetJsonLength(ri);
                    int subLength = MAX_JSON_LENGTH - baseLength;

                    List<List<object>> subList = new List<List<object>>();

                    List<object> header = result;
                    List<object> rest = null;

                    int subCount = (int)(result.Count / ((double)(length - baseLength) / subLength));
                    while (subCount < 2)
                    {
                        subCount = header.Count / 2;

                        header = header.GetRange(0, subCount);

                        length = GetJsonLength(header);
                        subCount = (int)(header.Count / ((double)length / subLength));

                        if (header.Count < 3)
                            break;
                    }

                    if (subCount < 1)
                        subCount = 1;

                    header = result.GetRange(0, subCount);
                    rest = result.GetRange(subCount, result.Count - subCount);

                    while (subList.Count < m_page)
                    {
                        int len = GetJsonLength(header);
                        if (len <= subLength || header.Count == 1)
                        {
                            /*
                            if (rest != null)
                            {
                                double avgHeaderLen = (double)len / header.Count;
                                int leftCount = (int)((subLength - len) / avgHeaderLen);

                                if (leftCount > 0)
                                {

                                }
                            }
                            */

                            subList.Add(header);

                            if (rest == null || subList.Count >= m_page)
                                break;

                            header = rest;
                            rest = null;
                        }
                        else
                        {
                            subCount = (int)(subLength / ((double)len / header.Count));

                            if (subCount >= header.Count)
                                subCount = header.Count - 2;

                            if (subCount < 1)
                                subCount = 1;

                            List<object> list = header;
                            header = list.GetRange(0, subCount);

                            if (rest == null)
                                rest = list.GetRange(subCount, list.Count - subCount);
                            else
                                rest.InsertRange(0, list.GetRange(subCount, list.Count - subCount));
                        }
                    }

                    if (subList.Count > 0)
                    {
                        m_pageCount = subList.Count;
                        if (rest != null)
                            m_pageCount++;

                        if (m_page <= m_pageCount)
                        {
                            result = (List<object>)subList[m_page - 1];
                        }
                        else
                        {
                            ClearResult();
                            m_returnCode = RC_FAIL;
                            m_errCode = ERR_INVALIDATE_PAGE;
                        }
                    }
                }
            }
        }

        private List<object> SplitListByJsonLength(List<object> list, int length)
        {
            List<object> rt = null;
            if (list != null)
            {
                rt = new List<object>();
                if (list.Count > 1)
                {
                    int midIndex = list.Count / 2;
                    List<object> header = list.GetRange(0, midIndex);
                    List<object> tailer = list.GetRange(midIndex, list.Count - midIndex);

                    int lenh = GetJsonLength(header);
                    int lent = GetJsonLength(tailer);

                    if (lenh <= length && lent <= length)
                    {
                        rt.Add(header);
                        rt.Add(tailer);
                    }
                    else
                    {
                        SplitSubList(rt, header, length, lenh);
                        SplitSubList(rt, tailer, length, lent);
                    }
                }
                else
                {
                    rt.Add(list);
                }
            }
            return rt;
        }

        private void SplitSubList(List<object> targetList, List<object> subList, int maxLen, int subLen)
        {
            if (targetList != null)
            {
                if (subLen > maxLen)
                {
                    List<object> l = SplitListByJsonLength(subList, maxLen);
                    if (l != null)
                    {
                        targetList.AddRange(l);
                    }
                }
                else
                    targetList.Add(subList);
            }
        }

        public int TestLength()
        {
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            if (result != null)
            {
                //int lenth = serializer.MaxJsonLength;
                //string jsonString = serializer.Serialize(result);
                //return System.Text.ASCIIEncoding.Unicode.GetByteCount(jsonString);
                string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                return jsonString.Length;
            }
            return 0;
        }

        private int GetPageCount()
        {
            if (result != null && result.Count > 1)
            {
                int length = GetJsonLength(this);

                while (length >= MAX_JSON_LENGTH)
                {

                }
            }
            return 1;
        }

        private bool IsNeedPaginate()
        {
            if (result != null && result.Count > 1)
            {
                return GetJsonLength(this) >= MAX_JSON_LENGTH;
            }
            return false;
        }

        private int GetJsonLength(object obj)
        {
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //serializer.MaxJsonLength = 1000000000;
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            return jsonString.Length;
        }

        public void AddErrorItem()
        {
            if (ReturnText != null)
            {
                AddItem(new ResultItem(-1, ReturnText));
            }
        }
    }

    [Serializable]
    public class LastItem
    {
        private int m_idx;

        public LastItem()
        {
            m_idx = 0;
        }

        public LastItem(int idx)
        {
            m_idx = idx;
        }

        public string LastIdx
        {
            get
            {
                return m_idx.ToString();
            }

            set
            {
                int.TryParse(value, out m_idx);
            }
        }
    }

    [Serializable]
    public class TotalNumber
    {
        private int m_total;
        public TotalNumber()
        {
            m_total = 0;
        }

        public TotalNumber(int total)
        {
            m_total = total;
        }

        public string Total
        {
            get
            {
                return m_total.ToString();
            }

            set
            {
                int.TryParse(value, out m_total);
            }
        }
    }

    [Serializable]
    public class IndexCount
    {
        private int m_indexCount;
        public IndexCount()
        {
            m_indexCount = 0;
        }

        public IndexCount(int indexCount)
        {
            m_indexCount = indexCount;
        }

        public string Value
        {
            get
            {
                if (m_indexCount == 0)
                    return null;
                return m_indexCount.ToString();
            }
            set
            {
                if (!int.TryParse(value, out m_indexCount))
                    m_indexCount = 0;
            }
        }
    }

}
