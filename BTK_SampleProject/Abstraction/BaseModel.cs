namespace BTK_SampleProject.Abstraction
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            CreatedDate = DateTime.Now;
            Id = Guid.NewGuid();
        }

        public DateTime CreatedDate { get; set; }
        public Guid Id { get; set; }

    }
}
