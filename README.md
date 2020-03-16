# Cases Endpoints:

1. List out cases

```
GET '/cases?pageNumber=1&pageSize=20'
```

Will fetch you list of cases based of your params

2. Fetch a Cases

```
GET '/cases/:id'
```

Success Response will hold the case which matches the id.

3. Create a new case

```
POST '/cases'
```


4. Edit a case

```
PUT '/cases/:id'
```

5. Delete a case

```
DELETE '/cases/:id'
```

2. Sorting

To get a sorted list of response you have to send the field to be sorted with the query.

```
GET 'cases?pageNumber=1&sort=Judge_asc'
```

```
GET 'cases?pageNumber=1&sort=Judge_dsc'
```

'asc' suffix for ascending and 'dsc' suffix for descending



There are similar endpoints for Plaintiffs and Defendants