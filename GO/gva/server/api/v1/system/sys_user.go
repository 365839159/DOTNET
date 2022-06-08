package system

import (
	"fmt"
	"github.com/gin-gonic/gin"
	"go.uber.org/zap"
	"server/global"
	"server/model/common/response"
	"server/model/system/entity"
	systemReq "server/model/system/request"
	systemRes "server/model/system/response"
	"server/utils"
)

type BaseApi struct {
}

// @Tags Base
// @Summary 用户登录
// @Produce  application/json
// @Param data body systemReq.Login true "用户名, 密码, 验证码"
// @Success 200 {object} response.Response{data=systemRes.LoginResponse,msg=string} "返回包括用户信息,token,过期时间"
// @Router /base/login [post]
func (b *BaseApi) Login(c *gin.Context) {
	var loginRequest systemReq.Login
	_ = systemRes.LoginResponse{}
	_ = c.ShouldBindJSON(&loginRequest)
	u := &entity.SysUser{Username: loginRequest.UserName, Password: loginRequest.Password}
	if _, err := userService.Login(u); err != nil {
		global.GVA_LOG.Error("登录失败！用户名不存在或者密码错误！", zap.Error(err))
		response.FailWithMessage("用户名不存在或者密码错误", c)
	} else {
		token, _ := utils.CreateToken()
		fmt.Println(token)
		utils.ParseToken(token)
		response.OkWithData(token, c)
	}
}

func (b *BaseApi) GetUserInfo(c *gin.Context) {
	var getUserInfoRequest systemReq.GetUserInfo
	c.ShouldBindJSON(getUserInfoRequest)
	user, err := userService.GetUserInfo(getUserInfoRequest.Id)
	if err != nil {
		global.GVA_LOG.Error(err.Error(), zap.Error(err))
		response.FailWithMessage(err.Error(), c)
	}
	response.OkWithData(user, c)
}
