package src

import "fmt"

func ArrayRun() {
	//数组声明及初始化
	fmt.Println("数组的声明和初始化")
	arrInit()
	//遍历数组
	fmt.Println("遍历一维数组")
	bianli()
	//二维数组的初始化和遍历
	fmt.Println("遍历二维数组")
	erWeiArray()
	fmt.Println("求数组[1, 3, 5, 7, 8]所有元素的和")
	sum()
	fmt.Println("找出数组中和为指定值的两个元素的下标，比如从数组[1, 3, 5, 7, 8]中找出和为8的两个元素的下标分别为(0,3)和(1,2)。\n")
	GetIndexBySum()
}

func arrInit() {
	var arr [3]int                          //零值
	var arr1 = [3]int{1, 2, 3}              //三个长度数组
	var arr2 = [...]int{12, 3, 123, 12, 31} // 自动推断长度
	var arr3 = [...]int{1: 1, 5: 2}         //索引赋值
	fmt.Println(arr)
	fmt.Println(arr1)
	fmt.Println(arr2)
	fmt.Println(arr3)

}

func bianli() {
	var arr1 = [3]int{1, 2, 3} //三个长度数组
	//遍历数组
	fmt.Println("遍历数组")
	for i := 0; i < len(arr1); i++ {
		fmt.Println(arr1[i])
	}

	for i, v := range arr1 {
		fmt.Println(i, v)
	}
}

func erWeiArray() {

	a := [...][2]int{
		{1, 2},
		{2, 4},
	}

	for _, ints := range a {

		for _, i3 := range ints {
			fmt.Println(i3)
		}

	}

}

//求数组[1, 3, 5, 7, 8]所有元素的和
func sum() {
	arr := [...]int{1, 3, 5, 7, 8}

	result := 0

	for _, i2 := range arr {
		result += i2
	}
	fmt.Println(result)
}

//找出数组中和为指定值的两个元素的下标，比如从数组[1, 3, 5, 7, 8]中找出和为8的两个元素的下标分别为(0,3)和(1,2)。
func GetIndexBySum() {
	arr := [...]int{1, 3, 5, 7, 8}
	for i, i2 := range arr {

		for x := i + 1; x < len(arr); x++ {
			if i2+arr[x] == 8 {
				fmt.Println(i, x)
			}
		}
	}
}
