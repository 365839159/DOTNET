package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strconv"
	"strings"
)

func main() {

	fmt.Println("请输入分数")
	reader := bufio.NewReader(os.Stdin)   // os.Stdin Reader 将从标准输入中读取；bufio.NewReader 返回bufio.Reader
	input, err := reader.ReadString('\n') //以字符串形式返回用户输入的内容；\n 表示换行符前的所有内容都将被读取

	if err != nil {
		log.Fatal(err)
	}
	input = strings.TrimSpace(input)
	grade, err := strconv.ParseFloat(input, 64)
	if err != nil {
		log.Fatal(err)
	}
	if grade > 60 {
		fmt.Println("及格")
	} else {
		fmt.Println("不及格")
	}
	fmt.Println(input)

}
