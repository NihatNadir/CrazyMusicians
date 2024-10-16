# CrazyMusicians ENG || TR

## Differences Between ActionResult and IActionResult
- ActionResult<IEnumerable<CrazyMusician> returns a list. If IActionResult were used, a list would not be returned.
- ActionResult<CrazyMusician> returns an object. IActionResult could be used here as well (if we want to return an object in our method, we should use ActionResult<T>, but IActionResult can also be used).
- For HttpGet, if ActionResult does not return an object in other methods, IActionResult can be used.

## Defined a static list using the data in the given table and used HTTP methods.

 ![image](https://github.com/user-attachments/assets/ce46193d-98fc-44a1-a494-6c4a9429b27c)

- I tried to pay attention to API routing rules.
- I used the query method with FromQuery ("search").

---

## ActionResult ile IActionResult arasındaki farklar
- ActionResult<IEnumerable<CrazyMusician>> ile geriye liste döner. IActionResult kullanılsaydı liste dönmezdi.
- ActionResult<CrazyMusician> ile nesne dönerdi. IActionResult burada kullanılabilir (Geriye nesne dönmesini istiyorsak metodumuz Get ise ActionResult<T> kullanılmalı ama IActionResult'ta kullanılabilir.
- HttpGet ile ActionResult diğer yöntemlerde geriye bir nesne dönmeyecekse IActionResult kullanılabilir.

## Verilen tabloda bulunan verileri kullanarak static liste tanımladım ve Http metotlarını kullandım

 ![image](https://github.com/user-attachments/assets/ce46193d-98fc-44a1-a494-6c4a9429b27c)

- API Routing kurallarına dikkat etmeye çalıştım.
- FromQuery ile ("search") sorgu yöntemini kullandım.

