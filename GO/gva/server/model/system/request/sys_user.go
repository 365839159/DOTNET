package request

type Login struct {
	UserName  string `json:"username" gorm:"comment:用户名"`
	Password  string `json:"password"`
	Captcha   string `json:"captcha"`
	CaptchaId string `json:"captchaId"`
}

type Captcha struct {
	TimeSpan string `json:"timeSpan"`
}

type GetUserInfo struct {
	Id int `json:"id"`
}
