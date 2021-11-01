using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;

namespace DataStructureDemo
{
    public class MyArrayList
    {
        private int[] _data;
        private int _n;

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="capacity">数据容量</param>
        public MyArrayList(int capacity)
        {
            _data = new int[capacity];
        }

        /// <summary>
        /// 无参构造函数 默认10数据容量
        /// </summary>
        public MyArrayList() : this(10)
        {
        }

        /// <summary>
        /// 获取数组的长度
        /// </summary>
        /// <returns></returns>
        public int Capacity => _data.Length;

        /// <summary>
        /// 实际数量
        /// </summary>
        public int Count => _n;

        /// <summary>
        /// 判断数据是否为空
        /// </summary>
        public bool IsEmpty => _n.Equals(0);
        
        /// <summary>
        /// 重写Tostring()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"count:{_n}  capacity:{Capacity}\r\n");
            stringBuilder.Append('[');
            stringBuilder.Append($"{string.Join(",", _data)}");
            stringBuilder.Append(']');
            return stringBuilder.ToString();
        }
        
        #region 增删改查

        ///==================================ADD============================================
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Add(int index, int value)
        {
            // if (index < 0 || index > _n)
            //     throw new ArgumentException("下标越界");
            CheckIndex(index);

            if (_n.Equals(Capacity))
                throw new ArgumentException("数组已满");

            for (var i = _n - 1; i >= index; i--)
            {
                _data[i + 1] = _data[i];
            }

            _data[_n] = value;
            _n++;
        }

        /// <summary>
        /// 末尾添加
        /// </summary>
        /// <param name="value">值</param>
        public void AddList(int value) => Add(_n, value);

        /// <summary>
        /// 开头添加
        /// </summary>
        /// <param name="value">值</param>
        public void AddFirst(int value) => Add(0, value);

        /// ===========================================Find===========================================
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int Find(int index)
        {
            CheckIndex(index);
            return _data[index];
        }

        /// <summary>
        /// 查找最后一位元素
        /// </summary>
        public int FindLast => Find(_n);

        /// <summary>
        /// 查找第一位元素
        /// </summary>
        public int FindFirst => Find(0);
        
        ///=============================================SET============================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">下标</param>
        /// <param name="value">值</param>
        public void Set(int index, int value)
        {
            CheckIndex(index);
            _data[index] = value;
        }

        /// <summary>
        /// 修改最后一位
        /// </summary>
        /// <param name="value">值</param>
        public void SetLast(int value) => Set(_n, value);

        /// <summary>
        /// 修改第一位
        /// </summary>
        /// <param name="value"></param>
        public void SetFirst(int value) => Set(0, value);
        
        ///===================================DELETE=========================================
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            CheckIndex(index);
            for (int i = index; i <= _n - 1; i++)
            {
                _data[i] = _data[i + 1];
            }

            _n--;
            _data[_n] = default(int);
        }
        
        /// <summary>
        /// 移除最后一个
        /// </summary>
        public void RemoveLast() => Remove(_n);

        /// <summary>
        /// 移除第一个
        /// </summary>
        public void RemoveFirst() => Remove(0);

        /// <summary>
        /// 移除所有
        /// </summary>
        /// <param name="value"></param>
        public void RemoveAll(int value)
        {
            var index = IndexOf(value);
            while (!index.Equals(-1))
            {
                Remove(index);
                index = IndexOf(value);
            }
        }

        #endregion

        /// <summary>
        /// 是否包含
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(int value)
        {
            foreach (var item in _data)
            {
                if (EqualityComparer<int>.Default.Equals(item, value))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 第一次出现的索引位置
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(int value)
        {
            for (var i = 0; i < _data.Length; i++)
            {
                if (EqualityComparer<int>.Default.Equals(_data[i], value))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 校验索引
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="ArgumentException"></exception>
        private void CheckIndex(int index)
        {
            if (index < 0 || index > _n)
                throw new ArgumentException("下标越界");
        }
    }
}