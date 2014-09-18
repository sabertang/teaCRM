﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using Spring.Context.Support;
using teaCRM.Common;
using teaCRM.Entity;
using teaCRM.Service.Settings;
using teaCRM.Web.Helpers;

namespace teaCRM.Web.Controllers.Api.Settings
{
    public class AppMakerController : MyWebApiController
    {
        //spring 创建service依赖
        private IAppMakerService AppMakerService =
            (IAppMakerService) ContextRegistry.GetContext().GetObject("appMakerService");

        #region 当前公司应用信息列表 14-09-15 By 唐有炜

        // Get /api/settings/appMaker/getAllApps
        //current 1
        //rowCount 10
        //sort[UserName]
        //searchPhrase 
        [HttpPost]
        public string GetAllApps()
        {
            HttpContextBase context = (HttpContextBase) Request.Properties["MS_HttpContext"]; //获取传统context
            HttpRequestBase request = context.Request; //定义传统request对象
            string compNum = request.Params.Get("compNum");
            int current = int.Parse(request.Params.Get("current"));
            int rowCount = int.Parse(request.Params.Get("rowCount"));
            //排序
            IDictionary<string, teaCRM.Entity.teaCRMEnums.OrderEmum> orders =
                new Dictionary<string, teaCRMEnums.OrderEmum>();
            orders.Add(new KeyValuePair<string, teaCRMEnums.OrderEmum>("id", teaCRMEnums.OrderEmum.Asc));
            string sort = request.Params.AllKeys.SingleOrDefault(a => a.Contains("sort"));
            //string sortName = sort.Split('[')[0];
            string sortField = sort.Split('[')[1].TrimEnd(']');
            string sortType = request.Params.GetValues(sort).SingleOrDefault();
            string searchPhrase = request.Params.Get("searchPhrase");

            var total = 0;
            IEnumerable<VAppCompany> apps = null;
            orders.Add(sortType == "desc"
                ? new KeyValuePair<string, teaCRMEnums.OrderEmum>(sortField, teaCRMEnums.OrderEmum.Desc)
                : new KeyValuePair<string, teaCRMEnums.OrderEmum>(sortField, teaCRMEnums.OrderEmum.Asc));
            //搜索
            if (!String.IsNullOrEmpty(searchPhrase))
            {
                apps = AppMakerService.GetAppLsit(compNum, current, rowCount, out total, orders,
                    a => a.CompNum == compNum && a.AppName.Contains(searchPhrase));
            }
            else
            {
                apps = AppMakerService.GetAppLsit(compNum, current, rowCount, out total, orders,
                    a => a.CompNum == compNum);
                      }
            return JSONHelper.ToJson(new
            {
                current = current,
                rowCount = rowCount,
                rows = apps,
                total = total
            });
        }

        #endregion

        #region 检测该应用是否安装过

        // /api/settings/appMaker/isInstalled?id=2&compNum=10000&appType=1
        [HttpGet]
        public ResponseMessage IsInstalled()
        {
            ResponseMessage rmsg = new ResponseMessage();
            HttpContextBase context = (HttpContextBase) Request.Properties["MS_HttpContext"]; //获取传统context
            HttpRequestBase request = context.Request; //定义传统request对象
            int appId = int.Parse(request.Params.Get("id"));
            string compNum = request.Params.Get("compNum");
            int appType = int.Parse(request.Params.Get("appType"));
            bool status = AppMakerService.IsInstalled(compNum, appId, appType);
            if (status)
            {
                rmsg.Status = true;
            }
            else
            {
                rmsg.Status = false;
            }
            return rmsg;
        }

        #endregion

        #region 安装应用

        // /api/settings/appMaker/Install?id=2&compNum=10000
        [HttpGet]
        public ResponseMessage Install()
        {
            ResponseMessage rmsg = new ResponseMessage();
            HttpContextBase context = (HttpContextBase) Request.Properties["MS_HttpContext"]; //获取传统context
            HttpRequestBase request = context.Request; //定义传统request对象
            int appId = int.Parse(request.Params.Get("id"));
            string compNum = request.Params.Get("compNum");

            bool status = AppMakerService.Install(compNum, appId);
            if (status)
            {
                rmsg.Status = true;
            }
            else
            {
                rmsg.Status = false;
            }
            return rmsg;
        }

        #endregion

        #region 安装应用

        // /api/settings/appMaker/unIstall?id=2&compNum=10000
        [HttpGet]
        public ResponseMessage UnInstall()
        {
            ResponseMessage rmsg = new ResponseMessage();
            HttpContextBase context = (HttpContextBase) Request.Properties["MS_HttpContext"]; //获取传统context
            HttpRequestBase request = context.Request; //定义传统request对象
            string appIds = request.Params.Get("ids");
            string compNum = request.Params.Get("compNum");
            bool isClear = bool.Parse(request.Params.Get("isClear"));
            bool status = AppMakerService.UnInstall(compNum, appIds, isClear);
            if (status)
            {
                rmsg.Status = true;
            }
            else
            {
                rmsg.Status = false;
            }
            return rmsg;
        }

        #endregion
    }
}