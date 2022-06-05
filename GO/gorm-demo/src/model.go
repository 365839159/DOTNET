package main

import (
	"gorm.io/gorm"
)

type User struct {
	gorm.Model
	Name string
	Age  uint8
}

func CreateTableUser() {
	Glabal_DB.AutoMigrate(&User{})
}
