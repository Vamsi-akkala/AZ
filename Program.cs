using Microsoft.Azure.Cosmos;

String connectionString = " " ;
CosmosClient client = new (connectionString);
Container container = client.GetContainer();

string sql = " " ;
QueryDefinition query = new  QueryDefinition(sql);
FeedIterator<product> iterator = container.GetItemQueryIterator<product>(query);

while (iterator.HasMoreResults)
{

 FeedResponse<product> products = await iterator.ReadNextAsync();
 foreach ( Product product in products)
 {
     Console.WriteLine($"[ { product.name, 30}\t{product.price}]");
 }
}