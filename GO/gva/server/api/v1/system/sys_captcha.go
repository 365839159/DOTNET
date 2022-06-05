package system

import (
	"context"
	"github.com/gin-gonic/gin"
	"math/rand"
	"server/global"
	"server/model/common/response"
	"server/model/system/request"
	"time"
)

// @Tags Base
// @Summary 验证码
// @Produce  application/json
// @Param data body request.Captcha true "用户名, 密码, 验证码"
// @Success 200 {object} response.Response{data=response.CaptchaResponse,msg=string} "返回包括用户信息,token,过期时间"
// @Router /base/captcha [post]
func (b *BaseApi) Captcha(c *gin.Context) {
	var timespan request.Captcha
	c.ShouldBindJSON(&timespan)
	rand.Seed(time.Now().Unix())
	myrand := random(100000, 999999)
	global.GVA_REDIS.Set(context.Background(), timespan.TimeSpan, myrand, time.Minute*5)
	response.OkWithData(myrand, c)
}

func random(min, max int) int {
	return rand.Intn(max-min) + min
}
