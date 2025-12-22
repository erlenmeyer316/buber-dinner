#Buber Diner API

- [Auth](#auth)
- [Register](#register)
  - [Register Request](#register-request)
  - [Register Response](#register-response)

## Auth

## Register

```js
POST {{host}}/auth/register
```

### Register Request
```json
{ 
    "firstname": "João",
    "lastname": "da Silva",
    "email": "joaodasolva@gmail.com",
    "password": "joao123"
}
```

### Register Response 

```js
200 OK
```

```json
{
    "id" : "1",
    "firstname": "João",
    "lastname": "da Silva",
    "email": "joaodasolva@gmail.com",
    "token": "tyJhb.x9bj"
}