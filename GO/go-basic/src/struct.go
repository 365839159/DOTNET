package src

import (
	"fmt"
	"unsafe"
)

func StructRun() {
	structInstantiate()
}

//1、结构体定义
type Person struct {
	name, city string
	age        uint8
}

type student struct {
	name string
	age  int
}

//2、实例化：实例化才会分配内存，才能使用结构体字段

func structInstantiate() {
	//实例化一个person
	p := Person{
		name: "zxc",
		city: "zxc",
		age:  10,
	}
	fmt.Println(p)

	//匿名结构体
	var user struct{ name, city string }
	user.name = "zxc"
	user.city = "zxc"
	fmt.Println(user)

	//创建指针类型结构体
	p2 := new(Person) //*Person
	p2.name = "zxc"
	p2.age = 18
	p2.city = "123"
	fmt.Println(p2)

	//使用 & 对结构体取地址操作相当于对该结构体进行一次 new 操作
	p3 := &Person{
		name: "zxc",
		city: "zxc",
	}
	p3.age = 18 // 底层是 (*p3).age=18
	fmt.Println(p3)

	//内存布局
	var test struct{ a, b, c, d int8 }
	test.a = 1
	test.b = 2
	test.c = 3
	test.d = 4
	fmt.Printf("%p\n", &test.a)
	fmt.Printf("%p\n", &test.b)
	fmt.Printf("%p\n", &test.c)
	fmt.Printf("%p\n", &test.d)

	//空结构体：不占空间
	var v struct{}
	fmt.Println(unsafe.Sizeof(v))

	//面试题

	m := make(map[string]*student)
	stus := []student{
		{name: "小王子", age: 18},
		{name: "娜扎", age: 23},
		{name: "大王八", age: 9000},
	}

	for _, stu := range stus {
		m[stu.name] = &stu
	}
	for k, v := range m {
		fmt.Println(k, "=>", v.name)
	}

	/*
		result: &stu
		小王子 => 大王八
		娜扎 => 大王八
		大王八 => 大王八
	*/

}

//构造函数
func newPerson(name, city string, age uint8) *Person {
	return &Person{
		name: name,
		city: city,
		age:  age,
	}
}

//方法与函数的区别是，函数不属于任何类型，方法属于特定的类型。
//方法:指针类型接收
//什么时候应该使用指针类型接收者:
//1、需要修改接收者中的值
//2、接收者是拷贝代价比较大的大对象
//3、保证一致性，如果有某个方法使用了指针接收者，那么其他的方法也应该使用指针接收者。
func (p *Person) SetAge(age uint8) {
	p.age = age
}

//方法:值类型接收者
func (p Person) SetAge2(age uint8) {
	//将接收者的值复制一份,修改操作只是针对副本，无法修改接收者变量本身
	p.age = age
}
