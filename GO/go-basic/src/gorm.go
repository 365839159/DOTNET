package src

import (
	"database/sql"
	"gorm.io/driver/mysql"
	"gorm.io/gorm"
	"time"
)

func GormRun() {
	db, _ := getDb()
	db.AutoMigrate(&User{})

}

//1、安装 ：go get -u gorm.io/gorm  go get -u gorm.io/driver/mysql
//2、模型
//3、连接

type User struct {
	ID           uint
	Name         string
	Email        *string
	Age          uint8
	Birthday     *time.Time
	MemberNumber sql.NullString
	gorm.Model
}

func getDb() (*gorm.DB, error) {

	// 参考 https://github.com/go-sql-driver/mysql#dsn-data-source-name 获取详情
	dsn := "root:123456@tcp(114.116.116.70:3306)/testing?charset=utf8mb4&parseTime=True&loc=Local"
	db, err := gorm.Open(mysql.Open(dsn), &gorm.Config{})
	return db, err
}
