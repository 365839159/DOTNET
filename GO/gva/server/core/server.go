package core

import (
	ginSwagger "github.com/swaggo/gin-swagger"
	"github.com/swaggo/gin-swagger/swaggerFiles"
	"server/initialize"
)

func RunServer() {
	initialize.InitializeRedis()
	Router := initialize.Routers()
	Router.GET("/swagger/*any", ginSwagger.WrapHandler(swaggerFiles.Handler))
	Router.Run(":8080")
}
