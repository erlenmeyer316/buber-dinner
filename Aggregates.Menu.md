# Domain Models

## Menu

```csharp
class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection()

}
```

```json
{
    "id": "0000000-000000-000000-0000000",
    "name": "My Menu",
    "description": "A description of my menu",
    "averageRating": 4.5
    "sections": [
        {
            "id":  "0000000-000000-000000-0000000",
            "name": "Appetizers",
            "description": "Starters",
            "items": [
                {
                    "id":  "0000000-000000-000000-0000000",
                    "name": "Fried Pickles",
                    "description": "Deep fried pickles",
                    "price": 5.99
                },
            ]
        }
    ],
    "createdDateTime": "2020-01-01T00:00:00.0000000Z",
    "updatedDateTime": "2020-01-01T00:00:00.0000000Z",
    "hostId":  "0000000-000000-000000-0000000",
    "dinnerIds": [
        "0000000-000000-000000-0000000",
        "0000000-000000-000000-0000000",
    ],
    "menuReviewIds": [
         "0000000-000000-000000-0000000",
          "0000000-000000-000000-0000000",
    ]
}
```