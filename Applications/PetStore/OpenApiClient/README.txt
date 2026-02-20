To recreate new swagger client use i.e
swagger-codegen generate -i https://petstore.swagger.io/v2/swagger.json -l csharp -o temp -c config.json

This uses the config.json to set the namespace to something sane

Content of config.json
{
  2  "packageName": "Applications.PetStore.Swagger"
  3 
}
