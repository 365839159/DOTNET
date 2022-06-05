package response

import "server/model/system/entity"

type LoginResponse struct {
	User      entity.SysUser `json:"user"`
	Token     string         `json:"token"`
	ExpiresAt int64          `json:"expiresAt"`
}

type CaptchaResponse struct {
	Code string `json:"code"`
}
