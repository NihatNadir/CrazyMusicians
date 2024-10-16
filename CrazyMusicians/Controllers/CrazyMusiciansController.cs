using CrazyMusicians.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CrazyMusicians.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrazyMusiciansController : ControllerBase
    {
       
        // static Liste

        private static List<CrazyMusician> _crazyMusicians = new List<CrazyMusician>()
        {
            new CrazyMusician{Id = 1,Name = "Ahmet Çalgı",Profession = "Ünlü Çalgı Çalar",FunFeature = "Her zaman yanlış nota çalar, ama çok eğlenceli"},
            new CrazyMusician{Id = 2,Name = "Zeynep Melodi",Profession = "Popüler Melodi Yazarı",FunFeature = "Şarkıları yanlış anlaşılır ama çok popüler"},
            new CrazyMusician{Id = 3,Name = "Cemil Akkor",Profession = "Çılgın Akorist",FunFeature = "Akorları sık değiştirir, ama şaşırtıcı derecede yetenekli"},
            new CrazyMusician{Id = 4,Name = "Fatma Nota",Profession = "Sürpriz Nota Üreticisi",FunFeature = "Nota üretirken sürekli sürprizler hazırlar"},
            new CrazyMusician{Id = 5,Name = "Hasan Ritim",Profession = "Ritim Canavarı",FunFeature = "Her ritmi kendi tarzında yapar, hiç uymaz ama komiktir",IsDeleted = true},
            new CrazyMusician{Id = 6,Name = "Elif Armoni",Profession = "Armoni Ustası",FunFeature = "Armonilerini bazen yanlış çalar, ama çok yaratıcıdır"},
            new CrazyMusician{Id = 7,Name = "Ali Perde",Profession = "Perde Uygulayıcı",FunFeature = "Her perdeyi farklı şekilde çalar, her zaman sürprizlidir"},
            new CrazyMusician{Id = 8,Name = "Ayşe Rezonans",Profession = "Rezonans Uzmanı",FunFeature = "Rezonans konusunda uzman, ama bazen çok gürültü çıkarır"},
            new CrazyMusician{Id = 9,Name = "Murat Ton",Profession = "Tonlama Meraklısı",FunFeature = "Tonlamalarındaki farklılıklar bazen komik, ama oldukça ilginç"},
            new CrazyMusician{Id = 10,Name = "Selin Akor",Profession = "Akor Sihirbazı",FunFeature = "Akorları değiştirdiğinde bazen sihirli bir hava yaratır"}
           
        };

        // HttpGet metodu ile listedeki tüm elemanları getirir.

        [HttpGet]
        public ActionResult<IEnumerable<CrazyMusician>> Get()
        {
            var musicianList = _crazyMusicians.Where(x=>x.IsDeleted == false).ToList();

            return Ok(musicianList);
        }

        // HttpGet metodu ile id swagger üzerinden alınır eğer id isDeleted = true ise 400 BadRequest döner id bulunamazsa 404 NotFound döner id bulunursa 200 ve bilgilerle beraber döner

        [HttpGet("{id:int:min(1)}")]
        public ActionResult<CrazyMusician> Get(int id)
        {
            
            var musician = _crazyMusicians.FirstOrDefault(x=> x.Id == id);

            if (musician is null)
                return NotFound(); // 404

            if (musician.IsDeleted == true)
                return BadRequest(); // 400

          

            return Ok(musician);
        }

        // HttpGet metodu sorgu ? yöntemi ile name alınır listede name geçen tüm nesneler alınır ve 200 döner, eğer nesne yoksa 404 NotFound döner
                   
        [HttpGet("search/name")]
        public ActionResult<IEnumerable<CrazyMusician>> SearchByName([FromQuery] string name)
        {
            
            var musicianList = _crazyMusicians.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            var musician = musicianList.FirstOrDefault(x => x.Name.ToLower().Contains(name.ToLower()));

            if (musician is null)
                return NotFound();


            return Ok(musicianList);

        }

        // HttpGet metodu sorgu ? yöntemi ile profession alınır listede profession geçen tüm nesneler alınır ve 200 döner, eğer nesne yoksa 404 NotFound döner

        [HttpGet("search/profession")]
        public ActionResult<IEnumerable<CrazyMusician>> SearchByProfession([FromQuery] string profession)
        {

            var musicianList = _crazyMusicians.Where(x => x.Profession.ToLower().Contains(profession.ToLower()));
            var musician = musicianList.FirstOrDefault(x => x.Profession.ToLower().Contains(profession.ToLower()));

            if (musician is null)
                return NotFound();


            return Ok(musicianList);

        }

        // HttpGet metodu sorgu ? yöntemi ile funfeature alınır listede funfeature geçen tüm nesneler alınır ve 200 döner, eğer nesne yoksa 404 NotFound döner

        [HttpGet("search/funfeature")]
        public ActionResult<IEnumerable<CrazyMusician>> SearchByFunFeature([FromQuery] string fun)
        {

            var musicianList = _crazyMusicians.Where(x => x.Profession.ToLower().Contains(fun.ToLower()));
            var musician = musicianList.FirstOrDefault(x => x.Profession.ToLower().Contains(fun.ToLower()));
            
            if (musician is null)
                return NotFound();


            return Ok(musicianList);

        }

        // HttpPost metodu ile yeni bir nesne oluşturulur 201 Created ve oluşturulan nesne döner

        [HttpPost]
        public ActionResult<CrazyMusician> Post([FromBody] CrazyMusician request)
        {
            var id = _crazyMusicians.Max(x => x.Id)+1;
            request.Id = id;
            _crazyMusicians.Add(request);
            return CreatedAtAction(nameof(Get), new {id = request.Id},request);
        }

        // HttpPut metodu id swagger üzerinden ve body id kısmında girilen bilgilerle eşleşme durumunda tüm değerler değiştirilir 200 Ok döner
        // eğer swagger id ve body id eşleşmezse 400 BadRequest döner, girilen id aynı olup listede bulunamazsa 404 NotFound döner.

        [HttpPut("{id:int:min(1)}")]
        public IActionResult Put(int id, [FromBody] CrazyMusician request)
        {
            if(request is null || request.Id != id)
                return BadRequest();
            
            var musician = _crazyMusicians.FirstOrDefault(x=>x.Id == id);
            
            if (musician is null)
                return NotFound();

            musician.Name = request.Name;
            musician.Profession = request.Profession;
            musician.FunFeature = request.FunFeature;
            musician.IsDeleted = request.IsDeleted;
            return Ok(musician);

        }

        // HttpPatch metodu ile id girilen nesne listede bulunursa body kısmında girilen değerle name değiştirilir ve geriye 200 ile nesne döner id si bulunamazsa geriye 404 NotFound döner

        [HttpPatch("name/{id:int:min(1)}")]
        public IActionResult Patch(int id, [FromBody] string name)
        {
            var musician = _crazyMusicians.FirstOrDefault(x=> x.Id == id);

            if (musician is null)
                return NotFound();

            musician.Name = name;
            return Ok(musician);
        }

        // HttpPatch metodu ile id girilen nesne listede bulunursa body kısmında girilen değerle isDeleted değiştirilir ve geriye 200 ile nesne döner id si bulunamazsa geriye 404 NotFound döner

        [HttpPatch("toggle/{id:int:min(1)}")]
        public IActionResult Toggle(int id, [FromBody] bool toggle)
        {
            var musician = _crazyMusicians.FirstOrDefault(x => x.Id == id);

            if (musician is null)
                return NotFound();

            musician.IsDeleted = toggle;
            return Ok(musician);
        }

        // HttpDelete metodu ile id girilen nesne listede bulunursa soft / hard delete olarak silinir geriye 204 NoContent döner, eğer id listede yoksa 404 NotFound döner

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var musician = _crazyMusicians.FirstOrDefault(x => x.Id == id);

            if (musician is null)
                return NotFound();

            musician.IsDeleted = true; // Soft Delete
            _crazyMusicians.Remove(musician); // Hard Delete

            
            return NoContent();

        }


    }
}
