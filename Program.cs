using Microsoft.Azure.Cosmos;

String connectionString = "oBvrW6z5IOoB1Aojs4bA0ik1WtGEqKoSYdS1RvRWd7VM6O6BAFw5GIgrdG7dpqTNhDEwliQuK4xEBWasWAUiWg== " ;
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

from azure.cosmos import CosmosClient
import os
import json

url = 'https://csm-lam-usw-dfab-prd-eng-001.documents.azure.com:443/'
key = 'oBvrW6z5IOoB1Aojs4bA0ik1WtGEqKoSYdS1RvRWd7VM6O6BAFw5GIgrdG7dpqTNhDEwliQuK4xEBWasWAUiWg=='

#ACCOUNT_URI = 'https://csm-lam-usw-dfab-prd-eng-001.documents.azure.com:443/'
#ACCOUNT_KEY = 'oBvrW6z5IOoB1Aojs4bA0ik1WtGEqKoSYdS1RvRWd7VM6O6BAFw5GIgrdG7dpqTNhDEwliQuK4xEBWasWAUiWg=='
database_name = 'Tracker_v1'
container_name = 'ent-cosmos-api-helm-chart'

#url = os.environ[ACCOUNT_URI]
#key= os.environ[ACCOUNT_KEY]
client = CosmosClient(url, credential = key)
database = client.get_database_client(database_name)
container = database.get_container_client(database_name)

#item = []

for item in container.query_items ( query='select count(1) from c where c.file_type = "DataLog" and c.tool_id= 'J2-Platform' and c.iReach_ingested_time>="2022-11-21T04:00:00" and c.iReach_ingested_time <= "2022-11-21T08:00:00"',enable_cross_partition_query=True ):
  item = (json.dumps(item,indent=True))
  print("this is result",item)