# InterviewQuestion

Burada sizden istediğimiz şey, elinizde bulunan büyük sayıda bir datanın, tarihlere göre gruplandırılarak, 
kullanıcının daha önceden belirtmiş olduğu birleştirme formülleri ile getirilmesidir.

Aşağıdaki örneklerde görebileceğiniz gibi, elinizde her 5 dk'lık tarih için, 4 adet örnekleme bulunuyor.
Sizden işlem sonunda, bu örnekleri 1 adete indirmenizi istiyoruz. Bunu yaparken de değerlerin, avg, sum, max, min gibi değerlerini,
kullanıcının istemiş olduğu şekilde getirmenizi istiyoruz.

Bu soruda görmeye çalıştığımız şey, bu tarz bir probleme nasıl bir çözüm üretebileceğiniz.
linq kullanacak olursa, linq üzerinde ne kadar bilginiz olduğu. Aynı zamanda büyük boyutlu veriler üzerinde sonuçları ne kadar hızlı getirebildiğiniz.

Şimdi sorumuza ait adımlarla başlayalım.

### 1. Elinizde bir liste halinde QueryElement objeleri bulunmakta:

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
	
QueryElement elemanları:
	
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

### 2. Elinizde aynı zamanda liste halinde QueryResultTable elemanları bulunmakta:

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

QueryResultTable üyeleri:
	
01.01.2020 00:05 tarihinden başlayarak, 1.576.800 kez bir iterasyona giriyoruz ve her iterasyonda tarihi 5 dk arttırıyoruz.
Yaklaşık olarak 15 yıllık bir data vermiş oluyor bize. Tüm tarihler birebir aynı verileri içeriyor.
	
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

### 3. QueryResultTable içindeki tüm column'lar QueryElement içindeki Index field'ı ile temsil ediliyor.

Örneğin:

```
Index = 1 column1'e karşılık geliyor;
Index = 2 column2'e karşılık geliyor;
Index = 3 column3'e karşılık geliyor;
Index = 4 column4'e karşılık geliyor;
......
```
Buradaki amacımız, QueryResultTable içindeki verileri kullanırken, hangi kurallara göre kullanacağımızı QueryElement ile bulabilmek.
  
### 4. Sizden istediğimiz QueryResultTable içindeki verileri perfdate'e göre gruplayarak getirmeniz.

QueryResultTable içindeki verileri, 4 dataset şeklinde düşünebilirsiniz. Çünkü her bir tarihten 4 tane örnekleme bulunuyor.
Amacımız, bu örnekleri teke indirmek. Dolayısıyla her dakika için bir adet sonuç bulunuyor olacak.

Tabiki gruplama yapabilmek için, hangi kolonları hangi birleştirme formulune göre almanız gerektiğini bilmeniz lazım.
Bunun için, ilgili kolon id'lerinin QueryElement'te Index'ine göre bakarak, birleştirme formuluna ulaşabilirsiniz.

Örneğin elimizdeki veri grubuna göre söyle bir şey olması lazım:

```
column1 = Sum(values);
column2 = Avg(values);
column3 = Avg(values);
column4 = Max(values);
...........
```

### 5. Dinamik üyeleri düşünün

List<QueryElement> içindeki dinamik sayıda eleman barındırabilir.
Dolayısıyla bu örnekte olduğu gibi sadece column6'ya kadar kullanılacak değil.
List<QueryElement> üye sayısının ise maksimum 30 olacağını, column30'dan görebilirsiniz.
Bu sebeple çözümünüzün, üye sayılarını karşılayacak şekilde olduğuna dikkat edin.

### 6. Data tiplerine dikkat edin

Bu örneğimizde tüm değerlerin integer tipinde olduğunu görüyorsunuz. Fakat property ise string olarak tanımlanmış. 
Bunun sebebi, ilgili kolonlara her zaman integer değer gelmiyor olması. Fakat bu örnekte, hazır verilmiş bir veri seti olduğu için,
tüm kolonlar integer ya da double gibi davranabilirsiniz. Fakat bu durumda yine de, gelebilecek datanın boş ya da null olduğunu dikkat almalısınız.

### 7. Dış kütüphane kullanımı

Sorunu çözmek için herhangi bir Nuget kütüphanesini kullanabilirsiniz. Sorunu herhangi bir Nuget kütüphanesi olmadan çözebilirseniz, daha iyidir.

### 8. Büyük verileri düşünün!

Çok sayıda veri kümesi olacaktır, bu nedenle toplama mümkün olduğunca hızlı olmalıdır.
QueryElement ve QueryResultTable modellerini değiştirebilirsiniz ancak bu modellerin veri tiplerini değiştirmemelisiniz.

### 9. Boş veya null değerlere dikkat edin

Bazı sütun değerleri boş veya değer atanmamış olabilir. Bu nedenle, değerleri integer/double olarak çevirirken, bu durumu aklınızda bulundurun.

### 10. İyi şanslar! :)
