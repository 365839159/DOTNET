package request

type Login struct {
	UserName  string `json:"username"`
	Password  string `json:"password"`
	Captcha   string `json:"captcha"`
	CaptchaId string `json:"captchaId"`
}

type Captcha struct {
	TimeSpan string `json:"timeSpan"`
}
