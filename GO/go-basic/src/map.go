package src

import (
	"fmt"
	"math/rand"
	"sort"
	"strconv"
	"time"
)

func MapRun() {

	mapInit()

	mapKeyExit()

	mapBianLi()

	mapDelete()

	mapSortFor()
}

func mapInit() {

	//语法
	//map[keyType]valueType

	fmt.Println("map 初始化")
	person := make(map[string]int)

	for i := 0; i < 10; i++ {
		person[strconv.Itoa(i)] = i
	}
	fmt.Println(person)
}

func mapKeyExit() {
	fmt.Println("判断key 是否存在")
	person := map[string]string{
		"小明": "北京",
		"小红": "天津",
	}
	val, ok := person["小兰"]
	if ok {
		fmt.Println(val)
	} else {
		fmt.Println("人员不存在")
	}
}

func mapBianLi() {
	//遍历map时的元素顺序与添加键值对的顺序无关。
	fmt.Println("遍历map")

	person := map[string]int{
		"小红": 1,
		"小黄": 1,
		"小蓝": 1,
		"小嘿": 1,
	}

	for i, v := range person {
		fmt.Println(i, v)
	}

}

func mapDelete() {

	person := map[string]int{
		"小红": 1,
		"小黄": 1,
		"小兰": 1,
		"小黑": 1,
	}

	delete(person, "小黑")

	fmt.Println(person)
}

//有顺序的遍历
func mapSortFor() {
	rand.Seed(time.Now().UnixNano()) //初始化随机数种子

	var scoreMap = make(map[string]int, 200)

	for i := 0; i < 100; i++ {
		key := fmt.Sprintf("stu%02d", i) //生成stu开头的字符串
		value := rand.Intn(100)          //生成0~99的随机整数
		scoreMap[key] = value
	}
	//取出map中的所有key存入切片keys
	var keys = make([]string, 0, 200)
	for key := range scoreMap {
		keys = append(keys, key)
	}
	//对切片进行排序
	sort.Strings(keys)
	//按照排序后的key遍历map
	for _, key := range keys {
		fmt.Println(key, scoreMap[key])
	}

}
