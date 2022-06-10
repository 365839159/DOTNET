package src

import (
	"context"
	"fmt"
	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
	"go.mongodb.org/mongo-driver/mongo/readpref"
	"log"
)

func MongoRun() {

	//ctx, cancel := context.WithTimeout(context.Background(), 10*time.Second)
	//defer cancel()

	//client, err := mongo.Connect(context.TODO(), options.Client().ApplyURI("mongodb://root:cexZhongtai0412%2B%40%2B@82.156.193.96:28625"))
	client, err := mongo.Connect(context.TODO(), options.Client().ApplyURI("mongodb://localhost:27017"))

	client.Ping(context.TODO(), readpref.Primary())
	if err != nil {
		fmt.Println(err)
		return
	}

	//collection := client.Database("BasicDataCenterTest").Collection("D_AttachmentType")
	collection := client.Database("testing").Collection("numbers")

	//ctx, cancel = context.WithTimeout(context.Background(), 5*time.Second)
	//defer cancel()
	//res, err := collection.InsertOne(ctx, bson.D{{"name", "pi"}, {"value", 3.14159}})
	//id := res.InsertedID
	//fmt.Println(id)

	result := bson.D{}
	filter := bson.D{{"PeriodIdx", 1}}
	//ctx, cancel = context.WithTimeout(context.Background(), 50*time.Second)
	//defer cancel()
	err = collection.FindOne(context.TODO(), filter).Decode(&result)
	if err == mongo.ErrNoDocuments {
		// Do something when no record was found
		fmt.Println("record does not exist")
	} else if err != nil {
		log.Fatal(err)
	}
	fmt.Println(result)

	//defer func() {
	//	if err = client.Disconnect(ctx); err != nil {
	//		panic(err)
	//	}
	//}()
}
