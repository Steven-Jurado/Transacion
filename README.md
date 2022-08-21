
![NTTDATA](https://upload.wikimedia.org/wikipedia/commons/thumb/0/09/NTT-Data-Logo.svg/2560px-NTT-Data-Logo.svg.png)

## Docker 😎 

[Docker](https://hub.docker.com/r/steven1999/nttdatatransaction "Docker")

```sh
docker pull steven1999/nttdatatransaction
```
***
## Swagger 
[Swagger](https://editor.swagger.io/?_ga=2.260912580.839361268.1658197344-1447516963.1658197344 "Swagger")


``` json
{
  "openapi": "3.0.1",
  "info": {
    "title": "Api de transaccionalidad",
    "description": "Contiene los endpoints necesarios para el funcionamiento del transaccionalidad",
    "contact": {
      "name": "Desarrollador Software",
      "email": "stevejurado797@gmail.com"
    },
    "version": "1.0.0.0"
  },
  "paths": {
    "/api/BankAccount/Accounts": {
      "get": {
        "tags": [
          "BankAccount"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/BankAccount/AccountId": {
      "get": {
        "tags": [
          "BankAccount"
        ],
        "parameters": [
          {
            "name": "idBankAccount",
            "in": "query",
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/BankAccount/AccountAdd": {
      "post": {
        "tags": [
          "BankAccount"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/BankAccountRequest"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/BankAccountRequest"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/BankAccountRequest"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/BankAccount/AccountUpdate": {
      "put": {
        "tags": [
          "BankAccount"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/BankAccountRequest"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/BankAccountRequest"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/BankAccountRequest"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/BankAccount/AccountDelete": {
      "delete": {
        "tags": [
          "BankAccount"
        ],
        "parameters": [
          {
            "name": "idBankAccount",
            "in": "query",
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Client/Client": {
      "get": {
        "tags": [
          "Client"
        ],
        "responses": {
          "200": {
            "description": "Success"
          },
          "204": {
            "description": "Success"
          },
          "400": {
            "description": "Bad Request",
            "content": {
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              }
            }
          }
        }
      }
    },
    "/api/Client/ClientId": {
      "get": {
        "tags": [
          "Client"
        ],
        "parameters": [
          {
            "name": "IdClient",
            "in": "query",
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          },
          "204": {
            "description": "Success"
          },
          "400": {
            "description": "Bad Request",
            "content": {
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              }
            }
          }
        }
      }
    },
    "/api/Client/ClientAdd": {
      "post": {
        "tags": [
          "Client"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/ClientRequest"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/ClientRequest"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/ClientRequest"
              }
            }
          }
        },
        "responses": {
          "201": {
            "description": "Success"
          },
          "204": {
            "description": "Success"
          },
          "400": {
            "description": "Bad Request",
            "content": {
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              }
            }
          }
        }
      }
    },
    "/api/Client/ClientUpdate": {
      "put": {
        "tags": [
          "Client"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/ClientRequest"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/ClientRequest"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/ClientRequest"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          },
          "400": {
            "description": "Bad Request",
            "content": {
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              }
            }
          },
          "404": {
            "description": "Not Found",
            "content": {
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              }
            }
          }
        }
      }
    },
    "/api/Client/ClientDelete": {
      "delete": {
        "tags": [
          "Client"
        ],
        "parameters": [
          {
            "name": "IdClient",
            "in": "query",
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          },
          "400": {
            "description": "Bad Request",
            "content": {
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              }
            }
          },
          "404": {
            "description": "Not Found",
            "content": {
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              }
            }
          }
        }
      }
    },
    "/api/Transaction/Transactions": {
      "get": {
        "tags": [
          "Transaction"
        ],
        "parameters": [
          {
            "name": "startDate",
            "in": "query",
            "schema": {
              "type": "string",
              "format": "date-time"
            }
          },
          {
            "name": "endDate",
            "in": "query",
            "schema": {
              "type": "string",
              "format": "date-time"
            }
          },
          {
            "name": "idClient",
            "in": "query",
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Transaction/TransactionId": {
      "get": {
        "tags": [
          "Transaction"
        ],
        "parameters": [
          {
            "name": "idTransaction",
            "in": "query",
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Transaction/TransactionSave": {
      "post": {
        "tags": [
          "Transaction"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/TransacctionRequest"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/TransacctionRequest"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/TransacctionRequest"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    }
  },
  "components": {
    "schemas": {
      "BankAccountType": {
        "enum": [
          1,
          2
        ],
        "type": "integer",
        "format": "int32"
      },
      "Status": {
        "enum": [
          0,
          1
        ],
        "type": "integer",
        "format": "int32"
      },
      "BankAccountRequest": {
        "required": [
          "bankAccountBalance",
          "bankAccountNumber",
          "bankAccountType",
          "idUsuario"
        ],
        "type": "object",
        "properties": {
          "idUsuario": {
            "type": "string",
            "format": "uuid"
          },
          "bankAccountNumber": {
            "pattern": "^([0-9]){6,16}",
            "type": "string"
          },
          "bankAccountType": {
            "$ref": "#/components/schemas/BankAccountType"
          },
          "bankAccountBalance": {
            "type": "number",
            "format": "double"
          },
          "bankAccountAvailableBalance": {
            "type": "number",
            "format": "double"
          },
          "bankAccountStatus": {
            "$ref": "#/components/schemas/Status"
          }
        },
        "additionalProperties": false
      },
      "ProblemDetails": {
        "type": "object",
        "properties": {
          "type": {
            "type": "string",
            "nullable": true
          },
          "title": {
            "type": "string",
            "nullable": true
          },
          "status": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "detail": {
            "type": "string",
            "nullable": true
          },
          "instance": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": {}
      },
      "Gender": {
        "enum": [
          1,
          2,
          3
        ],
        "type": "integer",
        "format": "int32"
      },
      "ClientRequest": {
        "required": [
          "address",
          "gender",
          "name",
          "password",
          "telephone"
        ],
        "type": "object",
        "properties": {
          "idClient": {
            "type": "string",
            "format": "uuid"
          },
          "userName": {
            "type": "string",
            "nullable": true
          },
          "password": {
            "type": "string"
          },
          "name": {
            "type": "string"
          },
          "address": {
            "type": "string"
          },
          "telephone": {
            "pattern": "^([0-9]){10}",
            "type": "string"
          },
          "gender": {
            "$ref": "#/components/schemas/Gender"
          },
          "age": {
            "pattern": "^([0-9]){1,2}",
            "type": "integer",
            "format": "int32"
          },
          "status": {
            "$ref": "#/components/schemas/Status"
          }
        },
        "additionalProperties": false
      },
      "TransacctionRequest": {
        "required": [
          "transactionDate",
          "transactionType",
          "transactionValue"
        ],
        "type": "object",
        "properties": {
          "idTransaction": {
            "type": "string",
            "format": "uuid"
          },
          "idBankAccount": {
            "type": "string",
            "format": "uuid"
          },
          "transactionDate": {
            "type": "string",
            "format": "date-time"
          },
          "transactionType": {
            "$ref": "#/components/schemas/BankAccountType"
          },
          "transactionValue": {
            "type": "number",
            "format": "double"
          }
        },
        "additionalProperties": false
      }
    }
  }
}
```

## Creacion Base Datos
Estamos Utilizando EntityFrameCore con Base De Datos Relacion SQL Server Ejecutaremos algunos Comando en  El Package Manager Console 

Tomando en cuenta que debe seleccionar proyecto DataAccess\laboratorio.data.access

```sh
PM> Update-DataBase
```
***
## Informacion Estados
```sh
public enum Status 
{
    Inactive = 0,
    Active = 1
}
```
***
## Informacion Cuenta Bancaria
```sh
public enum BankAccountType 
{
    Ahorro = 1,
    Corrient = 2
}
```
***
## Informacion Genero
```sh
public enum Gender
{
    Male = 1,
    Feminine = 2,
    Others = 3
}
```
## Creacion de cliente (usuario) 


### 'Objecto JSON'
```json
{
  "password": "1234",
  "name": "Jose Lema ",
  "address": "Otavalo sn y principal",
  "telephone": "0998254785",
  "gender": 1,
  "age": 50,
  "status": 1
}
```
***
## Creacion de Cuenta Bancaria (BankAccount)

idUsuario Id De Creacion Del Cliente (usuario) 
```sh
idUsuario Id De Creacion Del Cliente (usuario) 
```

```json
{
  "idUsuario": "ce620da7-5c00-40b2-6bb9-08da8323f012",
  "bankAccountNumber": "478758",
  "bankAccountType": 1,
  "bankAccountBalance": 2000,
  "bankAccountAvailableBalance": 0,
  "bankAccountStatus": 1
}
```

***
## Creacion de Movimiento (Transaction)

idUsuario Id De Creacion Del Cliente (usuario) 
```sh
idBankAccount Id De Creacion Del Cuenta Bancaria (BankAccount) 
```
```json
{
  "idBankAccount": "E27CCD30-4ED8-4472-97DC-08DA8326992A",
  "transactionDate": "2022-08-20T03:39:08.213Z",
  "transactionType": 1,
  "transactionValue": 10
}
```
