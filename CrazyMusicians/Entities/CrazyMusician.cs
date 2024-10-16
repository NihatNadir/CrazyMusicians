namespace CrazyMusicians.Entities
{
    public class CrazyMusician
    {
        public CrazyMusician()
        {
            CreatedDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
        public string FunFeature { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
