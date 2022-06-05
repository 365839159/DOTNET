package config

type Mysql struct {
	GeneralDB `yaml:",inline" mapstructure:",squash"`
}

func (m *Mysql) Dsn() string {
	return m.UserName + ":" + m.PassWord + "@tcp(" + m.Path + ":" + m.Port + ")/" + m.DbName + "?" + m.Config
}
