package core

import (
	"fmt"
	"go.uber.org/zap"
	"os"
	"server/global"
	"server/utils"
)

func Zap() *zap.Logger {

	if ok, _ := utils.PathExists(global.GVA_CONFIG.Zap.Director); !ok {
		fmt.Printf("create %v directory\n", global.GVA_CONFIG.Zap.Director)
		_ = os.Mkdir(global.GVA_CONFIG.Zap.Director, os.ModePerm)
	}
	logger, _ := zap.NewProduction()
	return logger
}
