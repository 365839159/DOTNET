using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A_IdentityserverCenter
{
    public class Config
    {
        /// <summary>
        /// 定义api
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IdentityServer4.Models.ApiResource> GetApiResources()
        {
            return new List<IdentityServer4.Models.ApiResource>
            {
                new IdentityServer4.Models.ApiResource("api","my api"){  Scopes={ "api"} }
            };
        }
        /// <summary>
        /// 定义客户端
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IdentityServer4.Models.Client> GetClients()
        {
            return new List<IdentityServer4.Models.Client>
            {
                new IdentityServer4.Models.Client
                {
                    ClientId = "client",
                    AllowedGrantTypes =IdentityServer4.Models. GrantTypes.ClientCredentials, // 没有交互性用户，使用 clientid/secret 实现认证。
                    ClientSecrets = // 用于认证的密码
                    {
                      new IdentityServer4.Models. Secret( IdentityServer4.Models.HashExtensions.Sha256("secret"))
                    },
                     AllowedScopes = { "api" } // 客户端有权访问的范围（Scopes）
                }
            };
        }

        public static IEnumerable<IdentityServer4.Models.ApiScope> GetApiScopes()
        {
            return new List<IdentityServer4.Models.ApiScope>
            {
                new IdentityServer4.Models.ApiScope("api")
            };
        }

        public static IEnumerable<IdentityServer4.Models.IdentityResource> GetIdentityResources()
        {
            return new List<IdentityServer4.Models.IdentityResource>
            {
                new IdentityServer4.Models.IdentityResources.OpenId()
            };
        }
    }
}


