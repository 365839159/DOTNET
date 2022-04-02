using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPICore.Infrastructure.Extensions
{
    public class ReturnError
    {
        public string error;
        public int errcode;

        public ReturnError()
        {
            error = null;
            errcode = 0;
        }

        public ReturnError(int code)
        {
            errcode = code;
            error = GetReturnErrorText(code);
        }

        internal string GetReturnErrorText(int code)
        {
            string ret = null;
            switch (code)
            {
                case 1:
                    ret = null;
                    break;
                case -1:
                    ret = "无效参数";
                    break;
                case -2:
                    ret = "系统错误";
                    break;
                case -3:
                    ret = "无效Session";
                    break;
                case -4:
                    ret = "数据库错误";
                    break;

                #region 名师工作室
                case 100001:
                    ret = "无数据";
                    break;
                case 100002:
                    ret = "无权限";
                    break;
                case 100003:
                    ret = "你没有工作室";
                    break;
                case 100004:
                    ret = "这不是你的工作室";
                    break;
                case 100005:
                    ret = "你的工作室已停用,开通请联系管理员";
                    break;
                case 100006:
                    ret = "不能添加该类型的栏目";
                    break;
                case 100007:
                    ret = "栏目名不能为空";
                    break;
                case 100008:
                    ret = "工作室已关闭";
                    break;
                case 100009:
                    ret = "工作室不允许申请加入,请联系工作室管理员";
                    break;
                case 100010:
                    ret = "你不是该工作室成员";
                    break;
                case 100011:
                    ret = "该工作室不存在";
                    break;
                case 100012:
                    ret = "评论不可空";
                    break;
                case 100013:
                    ret = "文章不存在";
                    break;
                case 100014:
                    ret = "该文章不允许评论";
                    break;
                case 100015:
                    ret = "不是你的评论,不允许删除";
                    break;
                case 100016:
                    ret = "不是你的新闻,不允许删除";
                    break;
                case 100017:
                    ret = "不是你的文章,不允许删除";
                    break;
                case 100018:
                    ret = "不是你的资源,不允许删除";
                    break;
                #endregion

                #region 用户中心
                case 101001:
                    ret = "用户不存在";
                    break;
                case 101002:
                    ret = "密码错误";
                    break;
                case 101003:
                    ret = "账号状态不可用";
                    break;
                case 101004:
                    ret = "账号已过期";
                    break;
                case 101005:
                    ret = "账号无有效登录信息";
                    break;
                case 101006:
                    ret = "绑定设备数超出最大允许值";
                    break;
                case 102001:
                    ret = "用户缺少角色信息";
                    break;
                case 102002:
                    ret = "用户缺少区域信息";
                    break;
                case 102003:
                    ret = "用户缺少学科信息";
                    break;
                case 102004:
                    ret = "班级无学生信息";
                    break;
                case 102005:
                    ret = "用户无区域角色信息";
                    break;
                case 102006:
                    ret = "无区域数据";
                    break;
                case 102007:
                    ret = "无权限在此区域新建区域";
                    break;
                case 102008:
                    ret = "班级无教师信息";
                    break;
                case 102009:
                    ret = "用户缺少社区教研组信息";
                    break;
                case 102010:
                    ret = "教研组无成员信息";
                    break;
                case 102011:
                    ret = "无学校数据";
                    break;
                case 102012:
                    ret = "无权限在此区域编辑学校";
                    break;
                case 102013:
                    ret = "无班级数据";
                    break;
                case 102014:
                    ret = "用户无操作权限";
                    break;
                case 102015:
                    ret = "无用户信息";
                    break;
                case 102016:
                    ret = "班级Id、学校Id、班级名称不可全部为空";
                    break;
                #endregion

                #region 订单管理系统
                case 103001:
                    ret = "旧订单无效";
                    break;
                #endregion

                #region 角色权限
                case 105000:
                    ret = "该名称已存在";
                    break;
                case 105001:
                    ret = "数据不存在";
                    break;
                case 105002:
                    ret = "平台编号已存在";
                    break;
                case 105003:
                    ret = "已存在该区域的数据";
                    break;
                case 105004:
                    ret = "平台名已存在";
                    break;
                case 105005:
                    ret = "该系统已被平台引用，不允许删除！";
                    break;
                case 105006:
                    ret = "角色名不能为空！";
                    break;
                case 105007:
                    ret = "角色范围不能为空！";
                    break;
                case 105008:
                    ret = "已配置给账号，不允许删除角色！";
                    break;
                case 105009:
                    ret = "无平台权限！";
                    break;
                case 105010:
                    ret = "角色不存在！";
                    break;
                case 105011:
                    ret = "该系统类型下有数据,不能删！";
                    break;
                case 105012:
                    ret = "无权限！";
                    break;
                case 105013:
                    ret = "无权限获取学校下年级数据！";
                    break;
                #endregion

                #region 开放平台
                case 104000:
                    ret = "未授权的访问";
                    break;
                case 104001:
                    ret = "ticket无效";
                    break;
                case 104002:
                    ret = "client_id无效";
                    break;
                case 104003:
                    ret = "host不合法";
                    break;
                case 104004:
                    ret = "token无效";
                    break;
                case 104005:
                    ret = "refresh_token无效";
                    break;
                #endregion

                #region 数据中心
                case 106000:
                    ret = "数据不存在";
                    break;
                case 106001:
                    ret = "操作失败";
                    break;
                #endregion

                case 109001:
                    ret = "验证码无效";
                    break;
                case 109002:
                    ret = "文件内容错误";
                    break;
                case 109003:
                    ret = "全部创建失败，请检查Excel文件，必须是15列！";
                    break;

                default:
                    ret = "未知错误";
                    break;
            }

            return ret;
        }
    }
}