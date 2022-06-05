package initialize

import (
	"github.com/gin-gonic/gin"
	"server/global"
	"server/router"
)

func Routers() *gin.Engine {
	Router := gin.Default()
	systemRouter := router.RouterApp.SystemRouter
	publicRouter := Router.Group("")
	{
		systemRouter.InitBaseRouter(publicRouter)
	}
	global.GVA_LOG.Info("router register success")
	return Router
}
