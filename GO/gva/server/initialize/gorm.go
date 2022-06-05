package initialize

import "gorm.io/gorm"

func InitializeGorm() *gorm.DB {
	return mysqlGorm()
}
