package main

import (
	"server/core"
	_ "server/docs" // 这里需要引入本地已生成文档
	"server/global"
	"server/initialize"
)

func main() {
	global.GVA_VP = core.Viper()
	global.GVA_LOG = core.Zap()
	global.GVA_DB = initialize.InitializeGorm()
	core.RunServer()

}
