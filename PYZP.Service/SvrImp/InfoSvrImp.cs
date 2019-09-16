#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 马云滔 
 * 创建时间 : 2019/9/5 15:54:53 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

/*
      <!---->
      <component id="InfoMgeSvr" type="PYZP.Service.InfoMgeSvr, PYZP.Service" service="PYZP.Service.IInfoMgeSvr, PYZP.Service" lifestyle="Singleton" />
*/
using System;
using PengeSoft.Data;
using PengeSoft.Service;
using IBatisNet.DataAccess;
using PengeSoft.db.IBatis;
using PengeSoft.Enterprise.Application;

namespace PYZP.Service
{
    /// <summary>
    /// InfoMgeSvr 实现。
    /// </summary>
    [PublishName("InfoMgeSvr")]
    public class InfoMgeSvr : ApplicationBase, IInfoMgeSvr

    {
        #region 服务描述

        private IDaoManager _daoManager = null;
        private IInfoDao _Infodao;

        public InfoMgeSvr()
            : base()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            _Infodao = (IInfoDao)_daoManager.GetDao(typeof(IInfoDao));

        }

        #endregion

        #region IInfoMgeSvr 函数


        /// <summary>
        /// 新增或修改
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="info"></param>
        [PublishMethod("info")]
        public Info AddUpdateInfo(string token, Info info)
        {
            _logger.Info(info);
            info.Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DataPacket data = _Infodao.GetDetail(new Info {
                Tel = info.Tel
            });
            if (data != null)
                _Infodao.Update(info);
            else
                _Infodao.Insert(info);
            return info;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="info"></param>
        [PublishMethod("info")]
        public Info AddInfo(string token, Info info)
        {
            info.Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _Infodao.Insert(info);
            return info;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="dataTel">电话</param>
        [PublishMethod]
        public int DelInfo(string token, string dataTel)
        {
            Info info = new Info() { Tel = dataTel };
            _Infodao.Delete(info);
            return 1;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="dataTel">电话</param>
        /// <param name="info"></param>
        [PublishMethod("info")]
        public Info UpdateInfo(string token, string dataTel, Info info)
        {
            info.Tel = dataTel;
            info.Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _Infodao.Update(info);
            return info;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="dataTel">电话</param>
        [PublishMethod]
        public Info GetInfo(string token, string dataTel)
        {
            Info info = new Info() { Tel = dataTel };
            DataPacket data = _Infodao.GetDetail(info);
            if (data != null)
                info = (Info)data;
            return info;
        }

        /// <summary>
        /// 查询数量
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="para">查询参数</param>
        [PublishMethod("para")]
        public int QueryInfoCount(string token, InfoQueryPara para)
        {
            return _Infodao.QueryCount(para);
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="para">查询参数</param>
        /// <param name="start">开始序号</param>
        /// <param name="pageSize">分页大小</param>
        [PublishMethod("para")]
        public InfoList QueryInfoList(string token, InfoQueryPara para, int start, int pageSize)
        {
            InfoList result = new InfoList();
            DataList list = _Infodao.QueryList(para, start, pageSize);
            if (list.Count > 0)
                result.AddFrom(list);
            return result;
        }

        #endregion

    }


}