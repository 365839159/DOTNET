package main

import (
	"gorm.io/driver/mysql"
	"gorm.io/gorm"
	"gorm.io/gorm/schema"
)

var (
	Glabal_DB *gorm.DB
)

func main() {
	/*方式一
	dsn := "root:root@tcp(127.0.0.1:3306)/gormDemo?charset=utf8mb4&parseTime=True&loc=Local"
	db, err := gorm.Open(mysql.Open(dsn), &gorm.Config{})
	*/
	db, err := gorm.Open(mysql.New(mysql.Config{
		DSN:               "root:root@tcp(127.0.0.1:3306)/gormDemo?charset=utf8mb4&parseTime=True&loc=Local",
		DefaultStringSize: 171,
	}), &gorm.Config{
		SkipDefaultTransaction: false,
		NamingStrategy: schema.NamingStrategy{
			TablePrefix: "t_",
		},
		DisableForeignKeyConstraintWhenMigrating: true,
	})
	if err == nil {
		Glabal_DB = db
	}
	//CreateTableUser()
	//CreateUsuer()
	FindUser()
}
