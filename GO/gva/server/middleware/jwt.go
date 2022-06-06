package middleware

import (
	"github.com/gin-gonic/gin"
	"server/model/common/response"
	"strings"
)

func JwtAuth() gin.HandlerFunc {
	return func(c *gin.Context) {
		token := c.Request.Header.Get("x-token")
		if strings.TrimSpace(token) == "" {
			response.FailWithDetailed(gin.H{"reload": true}, "未登录或非法访问", c)
			c.Abort()
			return
		}

	}
}
