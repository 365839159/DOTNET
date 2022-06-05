package config

type GeneralDB struct {
	Path         string `yaml:"path"`
	Port         string `yaml:"port"`
	Config       string `yaml:"config"`
	DbName       string `yaml:"dbName" `
	UserName     string `yaml:"username"`
	PassWord     string `yaml:"password"`
	MaxIdleConns int    `yaml:"maxIdleConns"`
	MaxOpenConns int    `yaml:"maxOpenConns"`
	LogMode      string `yaml:"logMode"`
	LogZap       bool   `yaml:"logZap"`
}
