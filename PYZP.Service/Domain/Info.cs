#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 马云滔 
 * 创建时间 : 2019/9/5 15:54:39 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PengeSoft.Data;
using PengeSoft.WorkZoneData;

namespace PYZP.Service
{
    /// <summary>
    /// Info 的摘要说明。
    /// </summary>
    public partial class Info : DataPacket
    {
        #region 私有字段

        private string _Name;      // 姓名
        private string _Tel;      // 电话
        private string _School;      // 学校
        private string _Major;      // 专业
        private string _Station;      // 岗位
        private string _Time;      // 时间

        #endregion

        #region 属性定义

        /// <summary>
        /// 姓名.
        /// </summary>
        public string Name { get { return _Name; } set { _Name = value; } }
        /// <summary>
        /// 电话.
        /// </summary>
        public string Tel { get { return _Tel; } set { _Tel = value; } }
        /// <summary>
        /// 学校.
        /// </summary>
        public string School { get { return _School; } set { _School = value; } }
        /// <summary>
        /// 专业.
        /// </summary>
        public string Major { get { return _Major; } set { _Major = value; } }
        /// <summary>
        /// 岗位.
        /// </summary>
        public string Station { get { return _Station; } set { _Station = value; } }
        /// <summary>
        /// 时间.
        /// </summary>
        public string Time { get { return _Time; } set { _Time = value; } }

        #endregion

        #region 重载公共函数

        /// <summary>
        /// 清除所有数据。
        /// </summary>
        public override void Clear()
        {
            base.Clear();

            _Name = null;
            _Tel = null;
            _School = null;
            _Major = null;
            _Station = null;
            _Time = null;
        }

#if SILVERLIGHT
#else
        /// <summary>
        /// 用指定节点序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于序列化的 XmlNode 节点。</param>
        public override void XMLEncode(System.Xml.XmlNode node)
        {
            base.XMLEncode(node);

            WriteXMLValue(node, "Name", _Name);
            WriteXMLValue(node, "Tel", _Tel);
            WriteXMLValue(node, "School", _School);
            WriteXMLValue(node, "Major", _Major);
            WriteXMLValue(node, "Station", _Station);
            WriteXMLValue(node, "Time", _Time);
        }

        /// <summary>
        /// 用指定节点反序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于反序列化的 XmlNode 节点。</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode(node);

            ReadXMLValue(node, "Name", ref _Name);
            ReadXMLValue(node, "Tel", ref _Tel);
            ReadXMLValue(node, "School", ref _School);
            ReadXMLValue(node, "Major", ref _Major);
            ReadXMLValue(node, "Station", ref _Station);
            ReadXMLValue(node, "Time", ref _Time);
        }
#endif

        /// <summary>
        /// 复制数据对象
        /// </summary>
        /// <param name="sou">源对象,需从DataPacket继承</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom(sou);

            Info s = sou as Info;
            if (s != null)
            {
                _Name = s._Name;
                _Tel = s._Tel;
                _School = s._School;
                _Major = s._Major;
                _Station = s._Station;
                _Time = s._Time;
            }
        }


        #endregion
    }


    /// <summary>
    /// Info  列表的摘要说明。
    /// </summary>
    public partial class InfoList : NorDataList<Info>
    {
        /// <summary>
        /// 初始化  默认实例
        /// </summary>
        public InfoList()
        {
        }

        /// <summary>
        /// 以  列表数据初始化实例
        /// </summary>
        /// <param name="list"> 列表数据</param>
        public InfoList(IEnumerable<Info> list)
        {
            if (list != null && list.Any())
            {
                foreach (var item in list)
                {
                    base.Add(item);
                }
            }
        }
    }

    /// <summary>
    /// InfoList 静态便捷方法扩展
    /// </summary>
    public static class InfoListEx
    {
        /// <summary>
        /// 转换为 InfoList 类型
        /// </summary>
        /// <param name="list"> 列表</param>
        /// <returns></returns>
        public static InfoList ToInfoList(this IEnumerable<Info> list)
        {
            return list == null ? null : new InfoList(list);
        }
    }

}

