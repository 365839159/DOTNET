package main

import "fmt"

func CreateUsuer() {
	//dbContext := Glabal_DB.Create(&[]User{{Name: "zxc", Age: 18}, {Name: "zxcz", Age: 19}})
	//dbContext := Glabal_DB.Select("Name").Create(&User{ Name: "123", Age: 111, })
	//dbContext := Glabal_DB.Omit("Name").Create(&User{Name: "123", Age: 111})
	dbContext := Glabal_DB.Create(&User{})
	if dbContext.Error != nil {
		fmt.Println(dbContext.Error)
	}
	fmt.Println(dbContext.RowsAffected)
}
func FindUser() {

	users := []User{}
	Glabal_DB.Select("name").Find(&users)
	fmt.Println(users)
}
