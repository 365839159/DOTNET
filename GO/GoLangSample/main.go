package main

import (
	"encoding/json"
	"fmt"
	"log"
	"net/http"
)

type incomingEvent struct {
	Data interface{} `json:"data""`
}

func main() {
	http.HandleFunc("/greeting", func(writer http.ResponseWriter, request *http.Request) {
		var event incomingEvent
		Decoder := json.NewDecoder(request.Body)
		Decoder.Decode(&event)
		fmt.Println(event.Data)
		fmt.Fprint(writer, "hello world")
	})
	log.Fatal(http.ListenAndServe(":8008", nil))
}
