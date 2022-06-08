package src

import (
	"github.com/natefinch/lumberjack"
	"go.uber.org/zap"
	"go.uber.org/zap/zapcore"
	"log"
	"net/http"
	"os"
	"strconv"
	"time"
)

func LogRun() {
	// 默认log
	//fmt.Println("go 内置 log")
	//goLog()

	//zap log
	//fmt.Println("Uber-go Zap")
	//zapLog()

	// zap file log
	for i := 0; i < 10; {
		zapFileLogger()
	}
}

//Uber-go Zap
func zapLog() {
	zapLogger()
	zapSugaredLogger()
}

//zap-logger
func zapLogger() {

	logger, _ := zap.NewProduction()
	url := "http://www.baidu.com"
	resp, err := http.Get(url)
	if err != nil {
		logger.Error("Error url ", zap.String("url", url), zap.Error(err))
	} else {
		logger.Info("Success url", zap.String("statusCode", resp.Status), zap.String("url", url))
		resp.Body.Close()
	}
}

//zap - sugaredLogger
func zapSugaredLogger() {
	logger, _ := zap.NewProduction()
	sugaredLogger := logger.Sugar()
	url := "www.baidu.com"
	resp, err := http.Get(url)
	if err != nil {
		sugaredLogger.Errorf("Error url ", zap.String("url", url), zap.Error(err))
	} else {
		sugaredLogger.Infof("Success url", zap.String("statusCode", resp.Status), zap.String("url", url))
		resp.Body.Close()
	}
}

//zap - file - logger
func zapFileLogger() {

	//ws := getWriteAsync()
	ws := getwriteAsyncByLumberjack()
	//json
	encoder := zapcore.NewJSONEncoder(getEncoder())
	// 普通
	//encoder := zapcore.NewConsoleEncoder(getEncoder())
	//配置核心
	core := zapcore.NewCore(encoder, ws, zapcore.DebugLevel)

	//创建log  zap.AddCaller() 添加调用者
	logger := zap.New(core, zap.AddCaller())
	sugaredLogger := logger.Sugar()

	//使用
	url := "http://www.baidu.com"
	resp, err := http.Get(url)
	if err != nil {
		logger.Error("Error url ", zap.String("url", url), zap.Error(err))
	} else {
		logger.Info("Success url", zap.String("statusCode", resp.Status), zap.String("url", url))
		resp.Body.Close()
	}

	url = "www.baidu.com"
	resp, err = http.Get(url)
	if err != nil {
		sugaredLogger.Errorf("Error url ", zap.String("url", url), zap.Error(err))
	} else {
		sugaredLogger.Infof("Success url", zap.String("statusCode", resp.Status), zap.String("url", url))
		resp.Body.Close()
	}
}

//getb  编码配置
func getEncoder() zapcore.EncoderConfig {
	encoderConfig := zap.NewProductionEncoderConfig()
	//时间格式
	encoderConfig.EncodeTime = zapcore.ISO8601TimeEncoder
	encoderConfig.EncodeLevel = zapcore.CapitalLevelEncoder
	return encoderConfig
}

//获取写入log
func getWriteAsync() zapcore.WriteSyncer {
	file, _ := os.OpenFile("./log/test.log", os.O_CREATE|os.O_APPEND|os.O_RDWR, 0744)
	return zapcore.AddSync(file)
}

func getwriteAsyncByLumberjack() zapcore.WriteSyncer {

	year, month, day := time.Now().Date()
	currentData := strconv.Itoa(year) + "-" + strconv.Itoa(int(month)) + "-" + strconv.Itoa(day)

	lumberJackLogger := &lumberjack.Logger{
		Filename:   "./log/" + currentData + "/log.log", //日志文件的位置
		MaxSize:    1,                                   //在进行切割之前，日志文件的最大大小（以MB为单位）
		MaxBackups: 5,                                   //保留旧文件的最大个数
		MaxAge:     30,                                  //保留旧文件的最大天数
		Compress:   false,                               //是否压缩/归档旧文件
	}
	return zapcore.AddSync(lumberJackLogger)
}

//默认的Go Logger
func goLog() {
	//创建|追加|读写
	w, _ := os.OpenFile("C:\\Users\\xian_cheng\\Desktop\\Learm\\Net\\DotNet\\Go\\go-basic\\log\\test.log", os.O_CREATE|os.O_APPEND|os.O_RDWR, 0744)
	//设置log的输出
	log.SetOutput(w)

	url := "http://www.baidu.com"
	resp, err := http.Get(url)
	if err != nil {
		log.Printf("Error fetching url %s : %s", url, err.Error())
	} else {
		log.Printf("Status Code for %s : %s", url, resp.Status)
		resp.Body.Close()
	}
}
