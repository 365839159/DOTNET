package global

import (
	"github.com/go-redis/redis/v8"
	"github.com/spf13/viper"
	"go.uber.org/zap"
	"gorm.io/gorm"
	"server/config"
)

var (
	GVA_VP     *viper.Viper
	GVA_CONFIG config.Server
	GVA_LOG    *zap.Logger
	GVA_DB     *gorm.DB
	GVA_REDIS  *redis.Client
)
