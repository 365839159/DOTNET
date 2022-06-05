package initialize

import (
	"context"
	"github.com/go-redis/redis/v8"
	"go.uber.org/zap"
	"server/global"
)

func InitializeRedis() {
	r := global.GVA_CONFIG.Redis
	client := redis.NewClient(&redis.Options{
		Addr:     r.Addr,
		Password: r.Password, // 密码
		DB:       r.DB,       // 数据库
		PoolSize: r.PoolSize, // 连接池大小
	})
	pong, err := client.Ping(context.Background()).Result()
	if err != nil {
		global.GVA_LOG.Error("redis connect ping failed, err:", zap.Error(err))
	} else {
		global.GVA_LOG.Info("redis connect ping response:", zap.String("pong", pong))
		global.GVA_REDIS = client
	}
}
