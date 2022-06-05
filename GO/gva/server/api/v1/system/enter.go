package system

import "server/service"

type ApiGroup struct {
	BaseApi
}

var (
	userService = service.ServiceApp.SystemServiceGroup.UserService
)
