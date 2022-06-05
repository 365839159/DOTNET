package system

import (
	"errors"
	"fmt"
	"server/global"
	"server/model/system/entity"
	"server/utils"
)

type UserService struct {
}

func (userService *UserService) Login(u *entity.SysUser) (userInter *entity.SysUser, err error) {
	if global.GVA_DB == nil {
		return nil, fmt.Errorf("db not init")
	}
	var user entity.SysUser
	err = global.GVA_DB.Where("username = ?", u.Username).First(&user).Error
	if err == nil {
		if ok := utils.BcryptCheck(u.Password, user.Password); !ok {
			return nil, errors.New("密码错误")
		}
	}
	return &user, err
}
