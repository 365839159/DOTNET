package router

import "server/router/system"

type routerGroup struct {
	SystemRouter system.RouterGroup
}

var RouterApp = new(routerGroup)
