# Gear List API

- [Gear List API](#gear-list-api)
  - [Create](#create-user)
    - [Create User Request](#create-user)
  - [Create](#create-item)
    - [Create Item Request](#create-item)

## Create User

```js
POST / user;
```

```json
{
  "Id": "Guid",
  "TrailName": "String",
  "Email": "String"
}
```

### Create Item

```js
POST / item;
```

```json
{
  "Id": "Guid",
  "Name": "String",
  "Category": "String",
  "Description": "String",
  "Price": "Decimal",
  "Qty": "Int",
  "Weight": "Decimal",
  "Worn": "Boolean",
  "Consumable": "Boolean",
  "URL": "String"
}
```
