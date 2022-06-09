package src

import (
	"context"
	"fmt"
	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
	"go.mongodb.org/mongo-driver/mongo/readpref"
	"time"
)

func MongoRun() {

	ctx, cancel := context.WithTimeout(context.Background(), 10*time.Second)
	defer cancel()
	client, err := mongo.Connect(ctx, options.Client().ApplyURI("mongodb://localhost:27017"))

	client.Ping(ctx, readpref.Primary())
	if err != nil {
		fmt.Println(err)
		return
	}

	collection := client.Database("testing").Collection("numbers")

	res, err := collection.InsertOne(ctx, bson.D{{"name", "zxc"}, {"age", 18}})
	if err != nil {
		fmt.Println(err)
	}
	id := res.InsertedID

	fmt.Println(id)

	defer func() {
		if err = client.Disconnect(ctx); err != nil {
			panic(err)
		}
	}()
}
