package config

type Redis struct {
	Addr     string `json:"addr"`
	DB       int    `json:"db"`
	Password string `json:"password"`
	PoolSize int    `json:"poolSize"`
}
