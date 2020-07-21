# InterviewQuestion

### 1. You have a list of QueryElement objects:

QueryElement Model:

```
public class QueryElement 
{
  public short Index { get; set; }
  public AggregateType Aggregate { get; set; }
}
```

AggregateType Model:
	
```
public enum AggregateType
{
  ///<summary>Sum</summary>
  sum,
  ///<summary>Avg</summary>
  avg,
  ///<summary>Max</summary>
  max,
  ///<summary>Min</summary>
  min
}
```
	
QueryElement members:
	
```
{
  Index = 1,
  Aggregate = AggregateType.sum
},
{
  Index = 2,
  Aggregate = AggregateType.avg
},
{
  Index = 3,
  Aggregate = AggregateType.avg
},
{
  Index = 4,
  Aggregate = AggregateType.max
},
{
  Index = 5,
  Aggregate = AggregateType.sum
},
{
  Index = 6,
  Aggregate = AggregateType.min
}
```

### 2. You have a list of QueryResultTable objects:

QueryResultTable Model:
	
```
public class QueryResultTable
{
  public DateTime perfdate { get; set; }
  public string column0 { get; set; }
  public string column1 { get; set; }
  public string column2 { get; set; }
  public string column3 { get; set; }
  public string column4 { get; set; }
  public string column5 { get; set; }
  public string column6 { get; set; }
  public string column7 { get; set; }
  public string column8 { get; set; }
  public string column9 { get; set; }
  public string column10 { get; set; }
  public string column11 { get; set; }
  public string column12 { get; set; }
  public string column13 { get; set; }
  public string column14 { get; set; }
  public string column15 { get; set; }
  public string column16 { get; set; }
  public string column17 { get; set; }
  public string column18 { get; set; }
  public string column19 { get; set; }
  public string column20 { get; set; }
  public string column21 { get; set; }
  public string column22 { get; set; }
  public string column23 { get; set; }
  public string column24 { get; set; }
  public string column25 { get; set; }
  public string column26 { get; set; }
  public string column27 { get; set; }
  public string column28 { get; set; }
  public string column29 { get; set; }
  public string column30 { get; set; }
}
```

QueryResultTable members:
	
Starts from 01.01.2020 00:05 and iterates 1.576.800 times to increase date with 5 minutes intervals.
So it will be around 15 years of data. Every date period has the exact same values.
	
```
{
  perfdate = "01.01.2020 00:05",
  column1 = "50",
  column2 = "10",
  column3 = "30",
  column4 = "20",
  column5 = "45",
  column6 = "15"
},
{
  perfdate = "01.01.2020 00:05",
  column1 = "150",
  column2 = "110",
  column3 = "130",
  column4 = "120",
  column5 = "145",
  column6 = "115"
},
{
  perfdate = "01.01.2020 00:05",
  column1 = "250",
  column2 = "210",
  column3 = "230",
  column4 = "220",
  column5 = "245",
  column6 = "215"
},
{
  perfdate = "01.01.2020 00:05",
  column1 = "350",
  column2 = "310",
  column3 = "330",
  column4 = "320",
  column5 = "345",
  column6 = "315"
},
{
  perfdate = "01.01.2020 00:10",
  column1 = "50",
  column2 = "10",
  column3 = "30",
  column4 = "20",
  column5 = "45",
  column6 = "15"
},
{
  perfdate = "01.01.2020 00:10",
  column1 = "150",
  column2 = "110",
  column3 = "130",
  column4 = "120",
  column5 = "145",
  column6 = "115"
},
{
  perfdate = "01.01.2020 00:10",
  column1 = "250",
  column2 = "210",
  column3 = "230",
  column4 = "220",
  column5 = "245",
  column6 = "215"
},
{
  perfdate = "01.01.2020 00:10",
  column1 = "350",
  column2 = "310",
  column3 = "330",
  column4 = "320",
  column5 = "345",
  column6 = "315"
}
..................................
```

### 3. Every column in QueryResultTable represents a QueryElement by Index identifier

For example:

```
Index = 1 corresponds with column1;
Index = 2 corresponds with column2;
Index = 3 corresponds with column3;
Index = 4 corresponds with column4;
......
```
	
### 4. You need to aggreate QueryResultTable results by groupping their perfdate

You should get the aggregation formula of the each column by using their QueryElement definition.

For example, in this case:

```
column1 = Sum(values);
column2 = Avg(values);
column3 = Avg(values);
column4 = Max(values);
...........
```

### 5. Think about dynamic members

List<QueryElement> might have dynamic members. 
Max List<QueryElement> member count is always 30. 
So aggregation function should also support other member counts.

### 6. Be careful about data types

In this example, columns always have integer values but in real life situation, they might also contain string values. 
That's why all integer values are in string format. So during the aggregation process, you can safely cast them into the integer/double values.

### 7. External library usage

You can use any Nuget library to solve the problem. If you can solve the problem without any Nuget library, it's better.

### 8. Think about big data!

There will be large number of datasets, so aggregation should be as fast as possible. 
You can alter QueryElement and QueryResultTable models but you can not change their data types.

### 9. Be careful about null or empty values

Some column values might be null or empty. So please keep in mind casting them into integer/double or when you are using aggregation function.

### 10. Good luck! :)