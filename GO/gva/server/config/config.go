package config

type Server struct {
	Mysql Mysql `yaml:"mysql"`
	Zap   Zap   `yaml:"zap"`
	Redis Redis `json:"redis"`
}
