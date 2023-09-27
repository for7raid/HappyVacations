using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2.Model.Internal.MarshallTransformations;
using Amazon.Runtime.Endpoints;
using HappyVacations.Models;
using YDBTest;

Console.WriteLine("Hello, World!");


/*
 
 Идентификатор ключа:
YCAJEx14pOZBAG_lNwNM6dnd5
Ваш секретный ключ:
YCPReH4EDy6ysBj0J691-14EOu4oVVrZBp8pKHR0

 */


AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig();
clientConfig.ServiceURL = "https://docapi.serverless.yandexcloud.net/ru-central1/b1g6cr7j44q82g1q3hmc/etnlllp146mvdtat958n";
AmazonDynamoDBClient client = new AmazonDynamoDBClient("YCAJEx14pOZBAG_lNwNM6dnd5", "YCPReH4EDy6ysBj0J691-14EOu4oVVrZBp8pKHR0", clientConfig);
DynamoDBContext context = new DynamoDBContext(client);

var team = new Team { Name = "adacta", Id = "sdf323asdf" };

await context.SaveAsync(team);

var team2 = await context.LoadAsync<Team>(team);

//string tableName = "ProductCatalog";

//var request = new PutItemRequest
//{
//    TableName = tableName,
//    Item = new Dictionary<string, AttributeValue>()
//      {
//          { "Id", new AttributeValue { S = "201" }},
//          { "Title", new AttributeValue { S = "Book 201 Title" }},
//          { "ISBN", new AttributeValue { S = "11-11-11-11" }},
//          { "Price", new AttributeValue { S = "20.00" }},
//          {
//            "Authors",
//            new AttributeValue
//            { SS = new List<string>{"Author1", "Author2"}   }
//          }
//      }
//};
//await client.PutItemAsync(request);

Console.WriteLine("Done");