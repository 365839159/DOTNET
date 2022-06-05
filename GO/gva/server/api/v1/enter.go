package v1

import "server/api/v1/system"

type apiGroup struct {
	SystemApiGroup system.ApiGroup
}

var ApiGroupApp = new(apiGroup)
