package service

import "server/service/system"

type serviceGroup struct {
	SystemServiceGroup system.SystemServiceGroup
}

var ServiceApp = new(serviceGroup)
