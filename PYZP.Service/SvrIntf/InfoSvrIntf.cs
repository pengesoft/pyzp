#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 马云滔 
 * 创建时间 : 2019/9/5 15:55:01 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

using System;
using System.Collections;
using System.Text;
using PengeSoft.Data;
using PengeSoft.Enterprise.Appication;
using PengeSoft.WorkZoneData;
using PengeSoft.Service;

namespace PYZP.Service
{
    /// <summary>
    /// IInfoMgeSvr 接口定义。
    /// </summary>
    [PublishName("InfoMgeSvr")]
    public interface IInfoMgeSvr : IApplication

    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="info"></param>
        [PublishMethod("info")]
        Info AddUpdateInfo(string token, Info info);
        /// <summary>
        /// 新增        /// </summary>
        /// <param name="token">token</param>
        /// <param name="info"></param>
        [PublishMethod("info")]
        Info AddInfo(string token, Info info);

        /// <summary>
        /// 删除        /// </summary>
        /// <param name="token">token</param>
        /// <param name="dataTel">电话</param>
        [PublishMethod]
        int DelInfo(string token, string dataTel);

        /// <summary>
        /// 修改        /// </summary>
        /// <param name="token">token</param>
        /// <param name="dataTel">电话</param>
        /// <param name="info"></param>
        [PublishMethod("info")]
        Info UpdateInfo(string token, string dataTel, Info info);

        /// <summary>
        /// 获取        /// </summary>
        /// <param name="token">token</param>
        /// <param name="dataTel">电话</param>
        [PublishMethod]
        Info GetInfo(string token, string dataTel);

        /// <summary>
        /// 查询数量
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="para">查询参数</param>
        [PublishMethod("para")]
        int QueryInfoCount(string token, InfoQueryPara para);

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="para">查询参数</param>
        /// <param name="start">开始序号</param>
        /// <param name="pageSize">分页大小</param>
        [PublishMethod("para")]
        InfoList QueryInfoList(string token, InfoQueryPara para, int start, int pageSize);


    }


}