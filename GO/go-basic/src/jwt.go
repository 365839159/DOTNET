package src

import (
	"errors"
	"fmt"
	"github.com/golang-jwt/jwt/v4"
	"time"
)

func JWTRun() {
	//cliaimsRun()
	customCliaimsRun()
}
func customCliaimsRun() {
	tokenString, err := GenToken("zhangxiancheng")
	if err != nil {
		fmt.Println(err)
	}
	claims, err := ParseToken(tokenString)
	if err != nil {
		fmt.Println(err)
	}
	fmt.Println(claims.UserId, claims.UserName)
}

//自定义 claim

type CustomClaims struct {
	UserId   int    `json:"user_id,omitempty"`
	UserName string `json:"user_name,omitempty"`
	jwt.RegisteredClaims
}

var customSecret = []byte("custom_secret")

func GenToken(userNmae string) (string, error) {

	//声明一个自己的 claim
	constomClaims := &CustomClaims{
		UserId:   100,
		UserName: userNmae,
		RegisteredClaims: jwt.RegisteredClaims{
			ExpiresAt: jwt.NewNumericDate(time.Now().Add(time.Hour)),
			Issuer:    "zxc",
		},
	}
	token := jwt.NewWithClaims(jwt.SigningMethodHS256, constomClaims)
	return token.SignedString(customSecret)
}

func ParseToken(tokenString string) (*CustomClaims, error) {
	token, err := jwt.ParseWithClaims(tokenString, &CustomClaims{}, func(token *jwt.Token) (interface{}, error) {
		return customSecret, nil
	})
	if err != nil {
		return nil, err
	}
	//对 token 对象中的 claim 进行类型断言
	if claims, ok := token.Claims.(*CustomClaims); ok && token.Valid {
		return claims, nil
	}
	return nil, errors.New("invalid token")
}

//======================================================

//默认 claim
var mySigningKey = []byte("zhangxiancheng")

func cliaimsRun() {
	tokenString, err := GenRegisteredClaims()
	if err != nil {
		fmt.Println(err)
	}
	isOk := ValidateRefisteredClaims(tokenString)
	if isOk {
		fmt.Println("OK")
	} else {
		fmt.Println("token 无效")
	}
}

func GenRegisteredClaims() (string, error) {

	claims := &jwt.RegisteredClaims{
		ExpiresAt: jwt.NewNumericDate(time.Now().Add(time.Hour)),
		Issuer:    "zxc",
	}
	token := jwt.NewWithClaims(jwt.SigningMethodHS256, claims)
	return token.SignedString(mySigningKey)
}

func ValidateRefisteredClaims(tokenString string) bool {
	token, err := jwt.Parse(tokenString, func(token *jwt.Token) (interface{}, error) {
		return mySigningKey, nil
	})
	if err != nil {
		return false
	}
	fmt.Println(token.Claims)
	return token.Valid
}
