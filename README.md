# CrazyMusicians

## ActionResult ile IActionResult arasındaki farklar
- ActionResult<IEnumerable<CrazyMusician>> ile geriye liste döner. IActionResult kullanılsaydı liste dönmezdi.
- ActionResult<CrazyMusician> ile nesne dönerdi. IActionResult burada kullanılabilir (Geriye nesne dönmesini istiyorsak metodumuz Get ise ActionResult<T> kullanılmalı ama IActionResult'ta kullanılabilir.
- HttpGet ile ActionResult diğer yöntemlerde geriye bir nesne dönmeyecekse IActionResult kullanılabilir.

## Verilen tabloda bulunan verileri kullanarak static liste tanımladım ve Http metotlarını kullandım

 ![image](https://github.com/user-attachments/assets/ce46193d-98fc-44a1-a494-6c4a9429b27c)

- API Routing kurallarına dikkat etmeye çalıştım.
- FromQuery ile ("search") sorgu yöntemini kullandım.

